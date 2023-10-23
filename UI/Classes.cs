using System;
using System.Diagnostics;
using System.IO.Compression;
using System.Runtime.Serialization;
using System.Security;
using System.Text.RegularExpressions;

namespace OfficeOS;

class Program
{
    static void Main()
    {
        File NewFile = new File("Kyle", "root", "NewFile");
        Console.WriteLine("-----------Hello World-----------");
        Console.WriteLine(NewFile.Name);
    }
}

public class Object
{
    public static readonly string VersionFormat = "yyyy.MM.dd.hh.mm.ss.ff";
    public static readonly string DateTimeFormat = "yyyy-MM-dd hh:mm:ss";
    public static readonly UID UID = new("default");
    public string Version
    {
        get { return Version; }
        set { DateTime.Now.ToString(VersionFormat); }
    }
}

public class File : Object
{
    #region Properties

    public string Folder;
    public string Name;
    public string? Content;
    public string? Permission;
    public string? Type;
    public string? Language;
    public string? Encoding;
    public string? Description;
    public string? Icon;
    private int? ContentLength = 0;
    private int FileLength;
    private string? EncryptionKey; // Not sure this will stay
    private DateTime WhenCreated = DateTime.Now;
    private String WhoCreated; // How to automatically identify person who ran command
    private DateTime? WhenChanged;
    private DateTime? WhenContentChanged;
    private DateTime? WhenOpened;
    private Boolean IsDeleted = false;
    private string? WhoDeleted;
    private DateTime? WhenDeleted;
    private Boolean IsLocked = false;
    private string? WhoLocked;
    private Boolean IsReadOnly = false;
    private Boolean IsEncrypted = false;
    private Boolean IsQuarantined = false;
    private Boolean IsCompressed = false;
    private Boolean IsUpdated = false;
    private string History;

    #endregion Properties

    public File(string WhoCreated, string Folder, string Name, string Type = "Open")
    {
        this.Folder = Folder;
        this.Name = Name;
        this.Type = Type;
        this.WhoCreated = WhoCreated;
        this.History = "[" + this.WhenCreated.ToString(DateTimeFormat) + "] Created by" + this.WhoCreated;
        this.Icon = "";
    }
}

public class UID
{
    private static readonly char[] Base62Characters = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz".ToCharArray();

    private string ID;

    public UID(string UIDType)
    {
        string prefix = UIDType switch
        {
            // U-#-##-###-####-#####-######-#######-########
            "SubSystem" => "U-1-00-",
            "Task" => "U-1-01-",
            "Setting" => "U-1-02-",
            "Directory" => "U-1-03-",
            "Key" => "U-1-04-",
            "File" => "U-1-05-",
            _ => "U-1-99-"
        };

        string LastUIDofType = "0";
        string suffix = IterateBase62(LastUIDofType);
        string NewUID = FormatBase64ToUID(prefix + suffix);

        ID = NewUID;
    }

    public static string ConvertToBase62(long number)
    {
        string Base62Number;

        double divide62 = number / 62;
        long q = (long)Math.Floor(divide62);
        long r = number % 62;
        Base62Number = Base62Characters[r].ToString();

        if (q >= 0)
        {
            Base62Number = ConvertToBase62(q) + Base62Number;
        }

        return Base62Number;
    }

    public static long ConvertFromBase62(string number)
    {
        long ConvertedNumber = 0;

        char[] number_char = Regex.Replace(number, "[^0-9A-Za-z]", "").ToCharArray();
        Array.Reverse(number_char);

        for (int i = 0; i < number_char.Length; i++)
        {
            int index = Array.IndexOf(Base62Characters, number_char[i]);
            ConvertedNumber += (long)(index * Math.Pow(62, i));
        }

        return ConvertedNumber;
    }

    public static string IterateBase62(string number)
    {
        long Base10 = ConvertFromBase62(number);
        Base10 += 1;
        string Base62 = ConvertToBase62(Base10);
        return Base62;
    }

    public static string FormatBase64ToUID(string Number)
    {
        Number = Number.PadLeft(33, '0');

        Number = String.Format("{0:U-0-00-000-0000-00000-000000-0000000-00000000}", Number);

        return Number;
    }
}