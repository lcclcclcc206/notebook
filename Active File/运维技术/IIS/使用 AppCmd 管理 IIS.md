AppCmd.exe is the single command line tool for managing IIS 7 and above. It exposes all key server management functionality through a set of intuitive management objects that can be manipulated from the command line or from scripts.

AppCmd enables you to easily control the server without using a graphical administration tool and to quickly automate server management tasks without writing code.

Some of the things you can do with AppCmd:

- Create and configure sites, apps, application pools, and virtual directories
- Start and stop sites, and recycle application pools
- List running worker processes, and examine currently executing requests
- Search, manipulate, export, and import IIS and ASP.NET configuration

## How to Use AppCmd.exe

The AppCmd.exe command line is built on top of a set of top level server management objects, such as Site and Application. These objects expose methods that can be used to perform various actions on those objects, and object instances expose properties that can be inspected and manipulated.

For example, the Site object provides methods to list, create and delete site instances (these are standard methods that are present on almost all objects), as well as stop and start sites. Each site instance in turn will contain properties, such as site name and site id, that can be inspected, searched for, or set. The output of each command is always a list of object instances.

> AppCmd.exe is located in the `%systemroot%\system32\inetsrv\` directory. Because it is not part of the PATH automatically, you need to use the full path to the executable when executing commands like in `%systemroot%\system32\inetsrv\AppCmd.exe list sites`. Alternatively, you can manually add the *inetsrv* directory to the path on your machine so that you can access AppCmd.exe directly from any location.

The tool works by executing a command on one of the supported management objects, with optional parameters used to further customize the behavior of the command:

控制台

```console
APPCMD (command) (object-type) <identifier> < /parameter1:value1 ... >*
```

Where `<COMMAND>` is one of the commands supported by `<OBJECT>`. Most objects support this basic set of commands:

- **LIST** Display the objects on the machine. An optional <ID> can specify a unique object to list, or one or more parameters can be specified to match against object properties.
- **ADD** Create a new object with the specified object properties to set during creation.
- **DELETE** Delete the object specified by the <ID>.
- **SET** Set parameters on the object specified by <ID>.

An object will often support additional commands, such as START and STOP for the Site object.

For example, the current set of objects available through AppCmd is (where `<OBJECT>` is one of the management objects supported by the tool):

| Object  | Description                                      |
| :------ | :----------------------------------------------- |
| Site    | Administration of virtual sites                  |
| App     | Administration of applications                   |
| VDir    | Administration of virtual directories            |
| Apppool | Administration of application pools              |
| Config  | Administration of general configuration sections |
| Backup  | Management of server configuration backups       |
| WP      | Administration of worker processes               |
| Request | Display of active HTTP requests                  |
| Module  | Administration of server modules                 |
| Trace   | Management of server trace logs                  |

Where `<ID>` is the object-specific identifier for the object instance you want to specify for the command. The format of the identifier is specific to each object type. For example, the Site object uses the site name, the App object uses the application path, and the AppPool object used the application pool name.

## Getting Help

AppCmd provides self-describing help that can be used as a reference for all of the supported objects and commands. There are three types of help available as you drill into the task you would like to do.

### General Help

The general help screen shows the objects supported by the tool, as well as generally applicable tool parameters. To display general help:

```console
APPCMD /?
```

The first few lines of output are:

```console
General purpose IIS command line administration tool.
APPCMD (command) (object-type) <identifier> < /parameter1:value1 ... >

Supported object types:
       
  SITE      Administration of virtual sites
  APP       Administration of applications              

...
```

### Object Help

The object help screen shows the commands supported by a specific object. To display object help:

```console
APPCMD <OBJECT> /?
```

where `<OBJECT>` is one of the supported object types. For example, this command-line will display help for the site object:

```console
APPCMD site /?
```

### Command Help

The command help screen describes the syntax for a specific command and object, including the parameters it supports and examples of common tasks. To display command help:

```console
APPCMD <COMMAND> <OBJECT> /?
```

For example, this command-line will display help for the LIST command of the App object:

```console
APPCMD list app /?
```

## Finding Objects with the LIST Command

The LIST command is the most versatile command, and is supported by all objects. The purpose of this command is to find instances of the object based on the criteria you specify. The output of this command is a list of object instances, which you can inspect by viewing their properties, export for future re-creation on another machine, or use together with another command to perform actions on them.

### Listing All Objects

The simplest way to use the LIST command is with no parameters, which simply lists all known instances of the object:

```console
APPCMD list <OBJECT>
```

For example, to list all sites on the machine, use this command-line:

```console
%systemroot%\system32\inetsrv\APPCMD list sites
```

The output will be similar to:

```console
SITE "Default Web Site" (id:1,bindings:HTTP/*:80:,state:Started)
SITE "Site1" (id:2,bindings:http/*:81:,state:Started)
SITE "Site2" (id:3,bindings:http/*:82:,state:Stopped)
```

By default, each object is shown on a single line, specifying its object-specific identifier (such as "Default Web Site") and one or more important properties (such as id, bindings, and state).

### Listing a Specific Object

The LIST command can be used to find an instance of a specific, named object by using a command-line in this form:

```console
APPCMD list <OBJECT> <ID>
```

For example, use this command-line to find the site with a unique id of "Default Web Site":

```console
%systemroot%\system32\inetsrv\APPCMD list site "Default Web Site"
```

### Listing Objects That Satisfy a Query

To find all object instances that match particular criteria, specify one or more parameters that indicate property values of the objects to match. For example, use this command-line to find all sites that are stopped:

```console
%systemroot%\system32\inetsrv\APPCMD list sites /state:Stopped
```

You can specify any number of property-value pairs, and the tool will make sure that the returned objects satisfy all of the specified criteria. For example, use this command-line to find sites that are both stopped and configured to not start automatically:

```console
%systemroot%\system32\inetsrv\APPCMD list sites /serverAutoStart:false /state:Stopped
```

## Manipulating Objects with ADD, SET, and DELETE

In addition to LIST, most objects also support ADD, SET, and DELETE commands.

### Adding New Objects

The ADD command creates a new instance of an object. For example, this command-line will create a new Site:

```console
%systemroot%\system32\inetsrv\APPCMD add site /name:MyNewSite /bindings:"http/*:81:" /physicalPath:"C:\MyNewSite"
```

Depending on the object, some parameters will be required in order to set required properties on the new instance, and other properties may be optional. An error will be returned if a required parameter is not specified.

The command help screen indicates which parameters are required. For example, use this command-line to see what parameters are required to add a Site:

```console
%systemroot%\system32\inetsrv\APPCMD add site /?
```

Read on for more information on creating sites, applications, virtual directories and application pools with AppCmd.

### Changing Existing Objects

The SET command sets one or more properties on a specified object instance. This command requires the object-specific identifier to be specified. For example, to change the id property of the "Default Web Site", use this command-line:

```console
%systemroot%\system32\inetsrv\APPCMD set site "Default Web Site" /id:200
```

Use a form of the command help syntax to see what properties can be set on a particular object. For example, to see the properties supported by the Default Web Site use:

```console
%systemroot%\system32\inetsrv\APPCMD set site "Default Web Site" /?
```

### Deleting Objects

The DELETE command deletes an instance of an object. Like SET, this command also requires the object-specific identifier to be specified. For example, use this command-line to delete the site named "MyNewSite":

```console
%systemroot%\system32\inetsrv\APPCMD delete site "MyNewSite"
```

## Managing Backups

AppCmd allows you to create and restore backups of global server configuration. You can use this to recover from unwanted changes to server configuration, and return to known-good server state. It is a good idea to create a backup before changing server configuration, or installing a component that changes it. Each backup contains the copy of the current ApplicationHost.config root configuration file, as well as other related server-wide state including FTP configuration and the IIS Administration Tool configuration.

To create a backup, use the ADD command of the Backup object:

```console
%systemroot%\system32\inetsrv\APPCMD add backup
```

```console
BACKUP object "20060519T172530" added
```

This created a backup with an auto-generated name that represents the date and time of backup.

A specific name for the backup can be specified like this:

```console
%systemroot%\system32\inetsrv\APPCMD add backup MyBackup
```

```console
BACKUP object "MyBackup" added
```

You can display a list of available backups using the LIST command of the Backup object:

```console
%systemroot%\system32\inetsrv\APPCMD list backups
```

```console
BACKUP "20060519T172530"
```

```console
BACKUP "MyBackup"
```

Finally, to restore a backup use the RESTORE command with name of the backup:

```console
%systemroot%\system32\inetsrv\APPCMD restore backup "MyBackup"
```

```console
Restored configuration from backup "MyBackup"
```

**Restoring a backup stops the server and restores global configuration to its state at the time the backup was created.**

In Windows Server® 2008 and Windows Vista SP1, AppCmd will also be capable of working with periodic configuration backups made by the configuration history service. These backups will show up in the AppCmd list of backups and will be available to restore the same way as backups you made manually through the tool.

To learn more about managing configuration backups with AppCmd, see http://mvolo.com/most-important-appcmd-commands-backing-up-and-restoring-iis7-configuration/.

> IIS 自动备份配置文件位于 C:\inetpub\history

## Working with Sites, Applications, Virtual Directories, and Application Pools

Creating and managing sites, applications, and virtual directories are the most common tasks administrators face. IIS 7 and above uses a stricter containment hierarchy than previous versions that works like this:

1. **Web Site** A Web site receives requests on particular binding endpoints defined by IP addresses and host headers. For example, this url represents a Web site bound to port 81: `http://www.mysite.com:81`.

   A Web site contains one or more applications.

2. **Application** An application is represented by its virtual path within a Web site's url namespace. For example, an application with a virtual path of "/app1" may be represented by this url: `http://www.mysite.com:81/app1`.

   An application belongs to one application pool.

   An application contains one or more virtual directories.

3. **Virtual Directory** A virtual directory is represented by its virtual path within an application's url namespace. For example, a virtual directory with a virtual path of "/vdir1" may be represented by this url: `http://www.mysite.com:81/app1/vdir1`.

   A virtual directory maps to a physical location on disk.

This hierarchy is in contrast to IIS 6.0 where a Web site can contain a mix of virtual directories and applications, and applications are just specially marked virtual directories.

**Application Pool** An application pool specifies a group of settings for the worker processes that perform request processing for the applications in that application pool. Application pools are not part of the site-app-vdir hierarchy. Each application specifies which application pool it will run in, or it runs in the default application pool. The application pool defines a number of worker process settings, such as the version of the CLR loaded by it, the .NET integration mode, the account under which the worker process runs, and process recycle settings.

By default, IIS 7 and above are installed with a Web site named "Default Web Site" that listens on port 80 with no IP address nor host header restrictions. This Web site has a root application, and that application has a root virtual directory. There is also an application pool named "DefaultAppPool" which is used by all new applications by default.

This command-line will list all Sites, including the Default Web Site:

```console
%systemroot%\system32\inetsrv\APPCMD list sites
```

```console
SITE "Default Web Site" (id:1,bindings:HTTP/*:80:,state:Started)
```

Let's examine the applications that belong to the Default Web Site by specifying the site.name property when listing Apps:

```console
%systemroot%\system32\inetsrv\APPCMD list apps /site.name:"Default Web Site"
```

```console
APP "Default Web Site/" (applicationPool:DefaultAppPool)
```

A similar command will list the virtual directories inside the "Default Web Site/" application by specifying the app.name property when listing Vdirs:

```console
%systemroot%\system32\inetsrv\APPCMD list vdirs /app.name:"Default Web Site/"
```

```console
VDIR "Default Web Site/" (physicalPath:C:\inetpub\wwwroot)
```

Finally, let's examine the application pools:

```console
%systemroot%\system32\inetsrv\APPCMD list apppools
```

```console
APPPOOL "DefaultAppPool" (MgdVersion:v2.0,MgdMode:Integrated,state:Started)
APPPOOL "Classic .NET AppPool" (MgdVersion:v2.0,MgdMode:ISAPI,state:Started)
```

### Creating Sites, Applications, Virtual Directories, and Application Pools

Now, we will create a new Web site named "MySite", with site id of 2 that listens on port 81 for all IP addresses and host headers:

```console
%systemroot%\system32\inetsrv\APPCMD add site /name:MySite /id:2 /bindings:http/*:81: /physicalPath:C:\inetpub\mysite
```

```console
SITE object "MySite" added
APP object "MySite/" added
VDIR object "MySite/" added
```

The **name** parameters must be specified to create a Web site. The id parameter is optional, and will cause AppCmd to generate the next available site id for the new site if omitted. We also specify the **bindings** and **physicalPath** parameters, which are explained below. You can also specify additional properties to set their values.

The **bindings** property uses the format of **protocol/bindingInformation**, where bindingInformation is specific to the protocol. For HTTP, it is in the format of **IP:PORT:HOSTHEADER**. You can specify multiple bindings by using a comma to separate each definition.

We also specified a **physicalPath** property for the site. While a Web site itself does not have a physical path, this short form is used to conveniently create a Web site with a root application and a root virtual directory mapped to the specified physical path.

If you do not specify a physical path, the Web site will be created with no applications; an application and virtual directory will need to be created for it explicitly.

Let's go ahead and add another application to the Web site:

```console
%systemroot%\system32\inetsrv\APPCMD add app /site.name:MySite /path:/app1 /physicalPath:C:\inetpub\mysite\app1
```

```console
APP object "MySite/app1" added
VDIR object "MySite/app1/" added
```

This created a new application with virtual path "/app1" belonging to the site we created above, with a root virtual directory pointing to `C:\inetpub\mysite\app1`. The required **path** parameter specifies the virtual path of the new application, and the required **site.name** parameter specifies the site to which the application will belong. The optional **physicalPath** parameter is a shortcut, much like in the Site case, that creates a root virtual directory together with the application.

If you do not specify the **physicalPath** parameter, or would like to add another virtual directory to the application, use a command-line like this:

```console
%systemroot%\system32\inetsrv\APPCMD add vdir /app.name:"MySite/app1" /path:/vdir1 /physicalPath:C:\inetpub\mysite\app1\vdir1
```

```console
VDIR object "MySite/app1/vdir1" added
```

This created a new virtual directory with virtual path "/vdir1" belonging to the application we created above and pointing to `C:\inetpub\mysite\app1\vdir1`. The required **path** parameter specifies the virtual path of the new virtual directory, and the required **app.name** parameter specifies the application to which the virtual directory will belong. The **physicalPath** parameter specifies the physical location of the virtual directory.

Finally, let's create a new application pool:

```console
%systemroot%\system32\inetsrv\APPCMD add apppool /name:MyAppPool
```

```console
APPPOOL object "MyAppPool" added
```

This created a new application pool named "MyAppPool".

To learn more about sites, applications, and virtual directories in IIS 7 and above, and the options you have in creating them with AppCmd, see [Creating IIS7 and Above Sites, Applications and Virtual directories](https://mvolo.com/creating-iis7-sites-applications-and-virtual-directories/).

### Configuring Sites, Applications, Virtual Directories, and Application Pools

Previously, we added a new Web site, complete with a few applications and virtual directories. Now, we will use AppCmd to modify some of their properties. All AppCmd objects support the same standard syntax for setting properties:

```console
APPCMD SET <OBJECT> <ID> [ /property:value ]*
```

First, let's display the applications available on the machine:

```console
%systemroot%\system32\inetsrv\APPCMD list apps
```

```console
APP "Default Web Site/" (applicationPool:DefaultAppPool)
APP "MySite/" (applicationPool:DefaultAppPool)
APP "MySite/app1" (applicationPool:DefaultAppPool)
```

Notice the two applications we created earlier under the Web site "MySite". Both of these applications are set to use the DefaultAppPool application pool. Let's change the applicationPool property of the "MySite/" root application to use the new application pool we created earlier named "MyAppPool":

```console
%systemroot%\system32\inetsrv\APPCMD set app "MySite/" /applicationPool:MyAppPool
```

```console
APP object "MySite/" changed
```

This changed the value of the applicationPool property of the "MySite/" application to the new value, effectively moving the application to the new application pool.

The reason we moved the application to the new application pool is so that we can change some of the runtime parameters of the worker process within which this application will run. To do that, we will change some of the properties on the "MyAppPool" application pool. Before changing property values, it if often useful to first display the available properties and their current values. We can do that by listing our application in detailed view:

```console
%systemroot%\system32\inetsrv\APPCMD list apppool "MyAppPool" /text:*
```

```console
APPPOOL
  APPPOOL.NAME: MyAppPool
  managedPipelineMode: Integrated
  managedRuntimeVersion: v2.0
  state: Started
  [add]
    name:"MyAppPool"
    queueLength:"1000"
    autoStart:"true"
    enable32BitAppOnWin64:"false"
    managedRuntimeVersion:"v2.0"
    managedPipelineMode:"Integrated"
    passAnonymousToken:"true"
    [processModel]
      identityType:"NetworkService"
      userName:""
      password:""
```

```console
...
      pingingEnabled:"true"
...
```

Notice the number of properties on the application pool object; the full output is not shown here.

## Working with Configuration

https://learn.microsoft.com/zh-cn/iis/get-started/getting-started-with-iis/getting-started-with-appcmdexe#working-with-configuration