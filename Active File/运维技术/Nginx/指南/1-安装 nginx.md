nginx can be installed differently, depending on the operating system.

## Installation on Linux

For Linux, nginx [packages](https://nginx.org/en/linux_packages.html) from nginx.org can be used.

## nginx for Windows

To install nginx/Windows, [download](https://nginx.org/en/download.html) the latest mainline version distribution (1.23.3), since the mainline branch of nginx contains all known fixes. Then unpack the distribution, go to the nginx-1.23.3 directory, and run `nginx`. Here is an example for the drive C: root directory:

```
cd c:\
unzip nginx-1.23.3.zip
cd nginx-1.23.3
start nginx
```

Run the `tasklist` command-line utility to see nginx processes:

```
C:\nginx-1.23.3>tasklist /fi "imagename eq nginx.exe"

Image Name           PID Session Name     Session#    Mem Usage
=============== ======== ============== ========== ============
nginx.exe            652 Console                 0      2 780 K
nginx.exe           1332 Console                 0      3 112 K
```

One of the processes is the master process and another is the worker process. If nginx does not start, look for the reason in the error log file `logs\error.log`. If the log file has not been created, the reason for this should be reported in the Windows Event Log. If an error page is displayed instead of the expected page, also look for the reason in the `logs\error.log` file.

nginx/Windows uses the directory where it has been run as the prefix for relative paths in the configuration. In the example above, the prefix is `C:\nginx-1.23.3\`. Paths in a configuration file must be specified in UNIX-style using forward slashes:

> ```
> access_log   logs/site.log;
> root         C:/web/html;
> ```

nginx/Windows runs as a standard console application (not a service), and it can be managed using the following commands:

> | nginx -s stop   | fast shutdown                                                |
> | --------------- | ------------------------------------------------------------ |
> | nginx -s quit   | graceful shutdown                                            |
> | nginx -s reload | changing configuration, starting new worker processes with a new configuration, graceful shutdown of old worker processes |
> | nginx -s reopen | re-opening log files                                         |