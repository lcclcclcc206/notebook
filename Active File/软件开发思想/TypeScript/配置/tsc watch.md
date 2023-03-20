Compiler supports configuring how to watch files and directories using compiler flags in TypeScript 3.8+, and environment variables before that.

## Background

The `--watch` implementation of the compiler relies on using `fs.watch` and `fs.watchFile` which are provided by node, both of these methods have pros and cons.

`fs.watch` uses file system events to notify the changes in the file/directory. But this is OS dependent and the notification is not completely reliable and does not work as expected on many OS. Also there could be limit on number of watches that can be created, e.g. linux and we could exhaust it pretty quickly with programs that include large number of files. But because this uses file system events, there is not much CPU cycle involved. Compiler typically uses `fs.watch` to watch directories (e.g. source directories included by config file, directories in which module resolution failed etc) These can handle the missing precision in notifying about the changes. But recursive watching is supported on only Windows and OSX. That means we need something to replace the recursive nature on other OS.

`fs.watchFile` uses polling and thus involves CPU cycles. However, `fs.watchFile` is the most reliable mechanism to get the update on the status of file/directory. The compiler typically uses `fs.watchFile` to watch source files, config files and missing files (missing file references). This means the CPU usage when using `fs.watchFile` depends on number of files in the program.