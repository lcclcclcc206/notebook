# folders

### Description

npm puts various things on your computer. That's its job.

This document will tell you what it puts where.

#### tl;dr

- Local install (default): puts stuff in `./node_modules` of the current package root.
- Global install (with `-g`): puts stuff in /usr/local or wherever node is installed.
- Install it **locally** if you're going to `require()` it.
- Install it **globally** if you're going to run it on the command line.
- If you need both, then install it in both places, or use `npm link`.

#### prefix Configuration

The [`prefix` config](https://docs.npmjs.com/cli/v9/using-npm/config#prefix) defaults to the location where node is installed. On most systems, this is `/usr/local`. On Windows, it's `%AppData%\npm`. On Unix systems, it's one level up, since node is typically installed at `{prefix}/bin/node` rather than `{prefix}/node.exe`.

When the `global` flag is set, npm installs things into this prefix. When it is not set, it uses the root of the current package, or the current working directory if not in a package already.

#### Node Modules

Packages are dropped into the `node_modules` folder under the `prefix`. When installing locally, this means that you can `require("packagename")` to load its main module, or `require("packagename/lib/path/to/sub/module")` to load other modules.

Global installs on Unix systems go to `{prefix}/lib/node_modules`. Global installs on Windows go to `{prefix}/node_modules` (that is, no `lib` folder.)

Scoped packages are installed the same way, except they are grouped together in a sub-folder of the relevant `node_modules` folder with the name of that scope prefix by the @ symbol, e.g. `npm install @myorg/package` would place the package in `{prefix}/node_modules/@myorg/package`. See [`scope`](https://docs.npmjs.com/cli/v9/using-npm/scope) for more details.

If you wish to `require()` a package, then install it locally.

#### Executables

When in global mode, executables are linked into `{prefix}/bin` on Unix, or directly into `{prefix}` on Windows. Ensure that path is in your terminal's `PATH` environment to run them.

When in local mode, executables are linked into `./node_modules/.bin` so that they can be made available to scripts run through npm. (For example, so that a test runner will be in the path when you run `npm test`.)

#### Man Pages

When in global mode, man pages are linked into `{prefix}/share/man`.

When in local mode, man pages are not installed.

Man pages are not installed on Windows systems.

#### Cache

See [`npm cache`](https://docs.npmjs.com/cli/v9/commands/npm-cache). Cache files are stored in `~/.npm` on Posix, or `%AppData%/npm-cache` on Windows.

This is controlled by the [`cache` config](https://docs.npmjs.com/cli/v9/using-npm/config#cache) param.

#### Temp Files

Temporary files are stored by default in the folder specified by the [`tmp` config](https://docs.npmjs.com/cli/v9/using-npm/config#tmp), which defaults to the TMPDIR, TMP, or TEMP environment variables, or `/tmp` on Unix and `c:\windows\temp` on Windows.

Temp files are given a unique folder under this root for each run of the program, and are deleted upon successful exit.

# npmrc

### Description

npm gets its config settings from the command line, environment variables, and `npmrc` files.

The `npm config` command can be used to update and edit the contents of the user and global npmrc files.

For a list of available configuration options, see [config](https://docs.npmjs.com/cli/v9/using-npm/config).

### Files

The four relevant files are:

- per-project config file (/path/to/my/project/.npmrc)
- per-user config file (~/.npmrc)
- global config file ($PREFIX/etc/npmrc)
- npm builtin config file (/path/to/npm/npmrc)

All npm config files are an ini-formatted list of `key = value` parameters. Environment variables can be replaced using `${VARIABLE_NAME}`. For example:

```bash
prefix = ${HOME}/.npm-packages
```

Each of these files is loaded, and config options are resolved in priority order. For example, a setting in the userconfig file would override the setting in the globalconfig file.

Array values are specified by adding "[]" after the key name. For example:

```bash
key[] = "first value"
key[] = "second value"
```

#### Comments

Lines in `.npmrc` files are interpreted as comments when they begin with a `;` or `#` character. `.npmrc` files are parsed by [npm/ini](https://github.com/npm/ini), which specifies this comment syntax.

For example:

```bash
# last modified: 01 Jan 2016
; Set a new registry for a scoped package
@myscope:registry=https://mycustomregistry.example.org
```

#### Per-project config file

When working locally in a project, a `.npmrc` file in the root of the project (ie, a sibling of `node_modules` and `package.json`) will set config values specific to this project.

Note that this only applies to the root of the project that you're running npm in. It has no effect when your module is published. For example, you can't publish a module that forces itself to install globally, or in a different location.

Additionally, this file is not read in global mode, such as when running `npm install -g`.

#### Per-user config file

`$HOME/.npmrc` (or the `userconfig` param, if set in the environment or on the command line)

#### Global config file

`$PREFIX/etc/npmrc` (or the `globalconfig` param, if set above): This file is an ini-file formatted list of `key = value` parameters. Environment variables can be replaced as above.

#### Built-in config file

```
path/to/npm/itself/npmrc
```

This is an unchangeable "builtin" configuration file that npm keeps consistent across updates. Set fields in here using the `./configure` script that comes with npm. This is primarily for distribution maintainers to override default configs in a standard and consistent manner.

# npm-shrinkwrap.json

### Description

`npm-shrinkwrap.json` is a file created by [`npm shrinkwrap`](https://docs.npmjs.com/cli/v9/commands/npm-shrinkwrap). It is identical to `package-lock.json`, with one major caveat: Unlike `package-lock.json`, `npm-shrinkwrap.json` may be included when publishing a package.

# package.json

### Description

This document is all you need to know about what's required in your package.json file. It must be actual JSON, not just a JavaScript object literal.

A lot of the behavior described in this document is affected by the config settings described in [`config`](https://docs.npmjs.com/cli/v9/using-npm/config).

**参考**

[package.json | npm Docs (npmjs.com)](https://docs.npmjs.com/cli/v9/configuring-npm/package-json)

# package-lock.json

### Description

`package-lock.json` is automatically generated for any operations where npm modifies either the `node_modules` tree, or `package.json`. It describes the exact tree that was generated, such that subsequent installs are able to generate identical trees, regardless of intermediate dependency updates.

This file is intended to be committed into source repositories, and serves various purposes:

- Describe a single representation of a dependency tree such that teammates, deployments, and continuous integration are guaranteed to install exactly the same dependencies.
- Provide a facility for users to "time-travel" to previous states of `node_modules` without having to commit the directory itself.
- Facilitate greater visibility of tree changes through readable source control diffs.
- Optimize the installation process by allowing npm to skip repeated metadata resolutions for previously-installed packages.
- As of npm v7, lockfiles include enough information to gain a complete picture of the package tree, reducing the need to read `package.json` files, and allowing for significant performance improvements.

### `package-lock.json` vs `npm-shrinkwrap.json`

Both of these files have the same format, and perform similar functions in the root of a project.

The difference is that `package-lock.json` cannot be published, and it will be ignored if found in any place other than the root project.

In contrast, [npm-shrinkwrap.json](https://docs.npmjs.com/cli/v9/configuring-npm/npm-shrinkwrap-json) allows publication, and defines the dependency tree from the point encountered. This is not recommended unless deploying a CLI tool or otherwise using the publication process for producing production packages.

If both `package-lock.json` and `npm-shrinkwrap.json` are present in the root of a project, `npm-shrinkwrap.json` will take precedence and `package-lock.json` will be ignored.