# OfficeOS

**Purpose:** Just a project to learn about all that goes into an OperatingSystem and who knows maybe something cool will happen along the way.

**Notes?**

1. Customizable
2. Open

<section><details><summary>

## Table Of Contents

</summary>

- [OfficeOS](#officeos)
  - [Table Of Contents](#table-of-contents)
  - [Keywords](#keywords)
  - [BootManager \& BootLoader](#bootmanager--bootloader)
  - [Kernel](#kernel)
  - [OperatingSystem](#operatingsystem)
    - [UID](#uid)
    - [Cabinet](#cabinet)
    - [Folder Structure](#folder-structure)
    - [Terminal Tool](#terminal-tool)
    - [Desktop](#desktop)
    - [File Tool](#file-tool)
    - [Folder Tool](#folder-tool)
    - [Context Menus](#context-menus)
    - [Roster Tool](#roster-tool)
    - [Safe Tool](#safe-tool)
    - [Keys Tool](#keys-tool)
    - [Settings Tool](#settings-tool)
    - [Logs Tool](#logs-tool)
    - [Tool Store](#tool-store)

</details></section>

<section><details><summary>

## Keywords

</summary>

|   Item   |                  Purpose                  |
| :------: | :---------------------------------------: |
|  System  |                 Settings                  |
|   Task   |                  Process                  |
|   Tool   |                 Software                  |
| Cabinet  |                File System                |
| Desktop  | Background Overlay<p>Tool Icons Shortcuts |
| Widgets  |            Desktop Mini-Tools             |
|  Drawer  |     Desktop Bar<p>Showing Open Tools      |
|  Inbox   |   Desktop Pane<p>Showing Notifications    |
|  Roster  |                 Directory                 |
|   Keys   |        Passwords<p>Encryption Keys        |
|   Safe   |               Private Files               |
|   Tray   |             Quick Settings<p>             |
|   UID    |             Unique Identifier             |
| PinBoard |          Shortcuts<p>Start Menu           |

</details></section>

## BootManager & BootLoader

[GRUB](https://www.gnu.org/software/grub/grub-download.html)

## Kernel

[Linux](https://git.kernel.org/pub/scm/linux/kernel/git/stable/linux.git)
[KernelNewbies](https://kernelnewbies.org/kernelbuild)

<section><details><summary>

## OperatingSystem

</summary>
Notes: At the moment, I'm thinking C# Code will make up the majority of the Operating System.

### UID

- All Files and Processes have a Unique ID
- AlphaNumeric Case Sensitive (Base 62)
  - 0-9a-zA-Z
- U-#-##-###-####-#####-######-#######-########

**UID Structure**

|    UID    |                  Purpose                  |
| :-------: | :---------------------------------------: |
|    U-1    |                  System                   |
| U-1-00-#> |                SubSystems                 |
| U-1-01-#> |                   Tasks                   |
| U-1-02-#> |              System Settings              |
| U-1-03-#> |             Directory Objects             |
| U-1-04-#> |        Encryption Keys<p>Passwords        |
| U-1-05-#> |                   Files                   |
| U-1-99-#> | User Generated UID<p>Non-Default Software |

**Predefined UIDs**

|     UID     |       Purpose       |
| :---------: | :-----------------: |
| U-1-03-0_0  |       System        |
| U-1-03-0_1  |    Administrator    |
| U-1-03-0_2  | Administrator Group |
| U-1-03-0_3  |     User Group      |
| U-1-03-0_4  |  Remote Connection  |
| U-1-03-0_5  |     Deny Logon      |
| U-1-03-0_10 |        Self         |

### Cabinet

- File

  - File Data will be Organized in JSON Format
  - Owner: Implied Full Control
  - Folder: Content Property Contains List of File Names/UIDs
  - Trash: Folder with Content Containing File Names/UIDs of files have been deleted

- Folder
  - **Content Property:** Contains list of all file and folders within this Folder

<section><details><summary>Properties</summary>

    - Folder (Editable)
    - Name (Editable)
    - Content (Editable)
    - Permissions (Editable)
    - Type (Editable)
      - Folder, Text, Shortcut, Application
    - Language (Editable)
    - Encoding (Editable)
    - MetaData
      - UID
      - Version
      - Description (Editable)
      - ContentLength
      - FileLength
        - Length of Content & MetaData
      - EncryptedKey ?
        - Key used to encrypt the file?
      - WhenCreated (System)
      - WhoCreated (System)
      - WhenChanged (System)
      - WhenContentChanged (System)
      - WhenOpened (System)
      - IsDeleted (Editable)
        - Used to determine if a file is deleted or not
      - WhenDeleted (System)
      - WhoDeleted (System)
      - IsLocked (System)
      - WhoLocked (System)
      - IsReadOnly (System)
      - IsEncrypted (System)
        - Used to tell if a file is encrypted
      - IsQuarantined
        - Used to Prevent all processes from reading/opening
      - IsCompressed
      - IsUpdated
        - Used to trigger other instances of this to update
      - History
        - Shows when who what
        - [DateTime] UID Action Attribute (PreviousValue)
          - [2023-10-06 17:58:38:357] U-1-0_1 Updated Content
          - [2023-10-06 17:58:38:357] U-1-0_1 Updated Name (OldFileName)

</details></section>

<section><details><summary>Permissions</summary>

    - Explicit Deny, Implicit Allow/Deny
    - Type: Allow, Deny
    - _Override_
    - Open
    - OpenWith
    - OpenAs
    - Move
      - Set Folder Property
    - Copy
      - Requires ReadContent
      - Set to Deny to Prevent Copying
    - Delete
      - Requires WriteContent
      - Set to Deny to Prevent Deletion
    - Lock
      - Requires WriteContent
    - Read (Quick Permission)
      - ReadContent
      - ReadMetaData
      - ReadHistory
      - ReadPermission
      - ReadOwner
    - Write (Quick Permission)
      - WriteMetaData
      - WriteContent
      - IsLocked
      - WhoLocked
    - ReadContent
    - WriteContent
    - ReadMetaData
    - WriteMetaData
      - Name
      - Description
      - Type
      - Encoding
      - Language
    - ReadHistory
    - ReadPermission
    - WritePermission
    - ReadOwner
    - WriteOwner
    - EncryptFile
    - FullControl (Quick Permission)

</details></section>

### Folder Structure

- \ (Local Root)
  - \Tools
  - \System
    - \Information
      - OS Version, OS Type, Time, Languages
    - \Tools
    - \File
    - \Folder
    - \Desktop
    - \Command
      - GetCommand
        - Name
        - Type
      - GetHelp
        - CommandName
      - NewFile
      - DeleteFile
      - GetFile
        - Read-Only
      - ListFile
        - Recurse
        - File
        - Folder
      - MoveFile
      - SetFile (Content)
        - Replace (Default)
        - Append
      - SetFileMetaData
        - Property
        - Value
      - CopyFile
        - FilesOnly
        - FoldersOnly
        - Recurse
        - KeepMetaData
        - KeepPermission
        - KeepOwner
        - KeepEncryption
      - LogConsole (Start/Stop)
        - Path
        - Status
      - Filter
        - By Property
        - RegexR
      - Sort
        - **What Sorting Method?**
        - By Property
      - Unique
        - By Property
      - Ping
      - Network
      - NewDrive
      - GetDrive
      - SetDrive
      - DeleteDrive
      - GetVersion
      - NewUID
        - Type
      - NewKey
        - Algorithm
        - Assemetric/Symmetric
      - GetKey
      - DeleteKey
      - CompressFile
      - DecompressFile
      - EncryptFile
      - DecryptFile
      - ListTool
        - Name
      - InstallTool
      - DeleteTool
      - UpdateTool
    - \Troubleshoot
    - \Security
      - \Directory
      - \Update
      - \Network
      - \Anti-Malware
      - \Privacy
      - \Backups
      - \Safe
    - \Devices
      - \Bluetooth
      - \Displays
        - \Screensaver
        - \Background
      - \Sound
        - \Input
        - \Output
      - \Storage
      - \Hardware
    - \Users
      - \ContextMenus
    - \Policy
      - \System
      - \User
    - \Logs
    - \Cache
    - \Users
      - \Settings
      - \Desktop
      - \Documents
        - \Media
        - \Downloads
  - \Users
    - \<UserID>
      - Desktop
      - Files
        - Media
        - Documents
        - Settings
        - Temp
- \\ (Remote Root)
  - \\ComputerName(or IP)\

### Terminal Tool

- Scripting Pane
- Command History Pane
- AutoComplete
- Personalization
  - Size, Colors

### Desktop

- Widgets

- Desktop Shortcuts

- Drawer

  - Weather

  - Clock
  - Opens Calendar

- Active Tools

- Tray
- Sound
  - Output
  - Input
- Connections
  - Wifi
  - Bluetooth
  - Location
  - HotSpot
  - Cast
- Focus

- Inbox
- Focus

### File Tool

- Language Character Support
- Encoding Support
- Show Line, Row of Cursor
- Search / Replace
  - Regex
- Actions
  - Open
  - New
  - Save
  - Save As
  - Properties
    - MetaData
    - Auto Save
      - On Lose Focus
      - IdleTime
    - Auto Versioning
      - Compresses
  - Help
  - Feedback

**Processes**

<section><details><summary>Open</summary>

        Open(Path, As, With, Parameters)
        - If As
            - Prompt Authentication
            - Validate Authentication
        - Check Permissions
        - If With: Send Path and Parameters to Tool
        - Else: Open
        - Update WhenOpened Property
        - Set IsReadOnly Property to True

</details>
<details><summary>Delete</summary>

        Delete(Path, As)
        - If As
            - Prompt Authentication
            - Validate Authentication
        - Check Permissions
        - Update Folder Property to 'Deleted'
        - Update IsDeleted, WhenDeleted, WhoDeleted Properties

</details>
<details><summary>Move</summary>

        Move(Path, DestinationPath, As)
        - If As
            - Prompt Authentication
            - Validate Authentication
        - Check Permission
        - Update Folder's Content Property to Exclude Path
        - Update Folder Property to DestinationPath
        - Update DestinationPath Folder Content Property to Include Path
        - Update History Property
        - Update WhenChanged Property

</details>
<details><summary>Copy</summary>

        Copy(Path, DestinationPath, As, KeepMetaData)
        - If As
            - Prompt Authentication
            - Validate Authentication
        - Check Permission
        - Copy All but MetaData Section
            - If DestinationPath is same
            - Append Name
        - If KeepMetaData
            - Copy all MetaData
        - Set Folder as Destination
        - Update History Property

</details>
<details><summary>SaveContent</summary>

        SaveContent(NewContent)
        - Check IsLocked Property
        - Check If Opened
        - Check Permission
        - Set IsLocked Property to True
        - Set WhoLocked Property to User.UID
        - Set IsReadOnly Property to False
        - Set Content Property
        - Update History Property
        - Update WhenContentChanged Property
        - Update WhenChanged Property

</details>
<details><summary>SaveMetaData</summary>

        SaveMetaData(Property, Value)
        - Check Permission for Property
        - Set Property to Value
        - Update History Property
        - Update WhenChanged Property

</details></section>

### Folder Tool

- View: Table, Content
- Sort
- Search
  - Regex

### Context Menus

- File

  - Open
  - Move
  - Copy
  - Properties
  - Advanced
    - Open With
    - Open As
    - Open With As
    - Encrypt/Decrypt
    - Compress/Decompress
  - Delete

- Folder

  - Open
  - New
    - File
    - Folder
    - Shortcut
  - Move
  - Copy
  - Paste
  - Properties
  - Advanced
    - Open With
    - Open As
    - Open With As
    - Encrypt/Decrypt
    - Compress/Decompress
  - Delete

- Desktop

  - New
    - File
    - Folder
    - Shortcut
  - Paste
  - Next Background
  - Tools
    - Display
    - Personalize

- Drawer

  - Tasks

- Drawer (Opened Tool)

  - Minimize
  - Maximize
  - Open
  - Advanced
    - Open With
    - Open As
  - Dock/UnDuck

- Drawer (Docked Un-Opened Tool)
  - Open
  - UnDock
  - Advanced
    - Open With
    - Open As

### Roster Tool

- Default Accounts

  - System
  - Administrator
  - User

- Default Groups

  - User
  - Administrator

- Default Access Groups
  - Remote Connection
  - Deny Logon

### Safe Tool

- Encryption Keys

### Keys Tool

- Passwords

### Settings Tool

    All Settings are displayed here
    Dynamically built
    Permissions determines which Settings/Categories are shown.
    All Settings have a Default Value

<section>
<details>
<summary>Layout</summary>

- User (SignInName)
  - Accounts
  - Passwords
- Information
  - OS Type
  - OS Version
  - Time
  - Language
- Personalize
  - Drawer
    - Color
    - DateTime Format
    - Silent Inbox
  - Task Frame Colors
  - Background
    - Slide Show, Static, etc.
    - Fit, Stretch, etc.
- Security
  - Directory
    - System Name
    - Users
      - Properties: SignInName, UID, Password, Description, Disabled, Locked, AccountExpired, AccountExpiration, PasswordExpired, PasswordLastSet, EncryptProfile, Groups
      - Action: Reset Password, Change Password, Enable, Disable, Unlock, Set Account Expiration, EncryptProfile, Rename, Description, Add Groups, Remove Groups
      - Permissions: Per Property/Action
      - Default Account(s): Administrator
    - Groups
      - Properties: Name, Description, UID, Members, Groups
      - Actions: Rename, Description, Add Members, Remove Members, Add Groups, Remove Groups
      - Permissions: Per Property/Action
      - Default Group(s): Administrators, Users
    - Update
    - Anti-Malware
    - Firewall
    - Find My Device
      - Remote Wipe
    - Backups
      - Full
      - Incremental
      - Differential
      - Synthetic
      - File Versioning
    - Safe
      - Encryption Keys
      - Encrypted Items
      - Passwords
- Privacy
  - Information Sharing
    - Logs, Errors
- Troubleshoot
- Devices
  - System
    - Sleep
    - Boot Manager
    - Time Server
  - Keyboards
    - Keyboard Shortcuts
  - Mice
  - Input
  - Output
  - Bluetooth
  - Network
    - Wifi, VPN, DNS, Hot spot, IP Configurations
  - Display
    - Extend, Duplicate, Rotate, Resolution, Zoom, Screensaver
  - Sound
    - Input
    - Output
  - Storage
    - Check Integrity
  - Hardware
    - Shows Hardware Information and Usage
- Tasks
  - Shows All Open Tasks
    - File Path
    - UID
    - Who
    - Usage
    - Run Time
  - Open Files
    - Who
    - UID
    - Open Time
    - Locked
  - Automation
    - System Tasks: Sanitation, Security Scans, TimeKeeper
    - Triggers: Schedule, Log, ProcessStart, ProcessEnd, SignIn, SignOut, TurnOn, TurnOff
    - Conditions: Logged In
    - Command
- Tools
  - File Tool
  - Folders Tool
- Context Menus
  - File Menu
  - Folder Menu
  - Desktop Menu
  - Drawer Menu
- Clipboard
  - Multi-Paste Mode
- Accessibility
  - Easy Desktop Mode
  - Reader
  - Color Contrast
  - Pointer
  - Visual Effects
  - Text Size
  - Magnifier
- Help
- Feedback

</details>
</section>

### Logs Tool

### Tool Store

Supports GIT
Supports Other Linux Install Methods: apt, YUM, dnf, snap

</details></section>
