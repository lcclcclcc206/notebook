[Contributing packages to the registry | npm Docs (npmjs.com)](https://docs.npmjs.com/packages-and-modules/contributing-packages-to-the-registry)

暂略

# Creating a package.json file

You can add a `package.json` file to your package to make it easy for others to manage and install. Packages published to the registry must contain a `package.json` file.

A `package.json` file:

- lists the packages your project depends on
- specifies versions of a package that your project can use using [semantic versioning rules](https://docs.npmjs.com/about-semantic-versioning)
- makes your build reproducible, and therefore easier to share with other developers

> To make your package easier to find on the npm website, we recommend including a custom `description` in your `package.json` file.

## `package.json` fields

### Required `name` and `version` fields

A `package.json` file must contain `"name"` and `"version"` fields.

The `"name"` field contains your package's name, and must be lowercase and one word, and may contain hyphens and underscores.

The `"version"` field must be in the form `x.x.x` and follow the [semantic versioning guidelines](https://docs.npmjs.com/about-semantic-versioning).

### Author field

If you want to include package author information in `"author"` field, use the following format (email and website are both optional):

```
Your Name <email@example.com> (http://example.com)
```

### Example

```
{
  "name": "my-awesome-package",
  "version": "1.0.0",
  "author": "Your Name <email@example.com>"
}
```

## Creating a new `package.json` file

You can create a `package.json` file by running a CLI questionnaire or creating a default `package.json` file.

### Running a CLI questionnaire

To create a `package.json` file with values that you supply, use the `npm init` command.

1. On the command line, navigate to the root directory of your package.

   ```
   cd /path/to/package
   ```

2. Run the following command:

   ```
   npm init
   ```

3. Answer the questions in the command line questionnaire.

#### Customizing the `package.json` questionnaire

https://docs.npmjs.com/creating-a-package-json-file#customizing-the-packagejson-questionnaire

### Creating a default `package.json` file

To create a default `package.json` using information extracted from the current directory, use the `npm init` command with the `--yes` or `-y` flag. For a list of default values, see "[Default values extracted from the current directory](https://docs.npmjs.com/creating-a-package-json-file#default-values-extracted-from-the-current-directory)".

1. On the command line, navigate to the root directory of your package.

   ```
   cd /path/to/package
   ```

2. Run the following command:

   ```
   npm init --yes
   ```

#### Example

```json
> npm init --yes
Wrote to /home/monatheoctocat/my_package/package.json:

{
  "name": "my_package",
  "description": "",
  "version": "1.0.0",
  "scripts": {
    "test": "echo \"Error: no test specified\" && exit 1"
  },
  "repository": {
    "type": "git",
    "url": "https://github.com/monatheoctocat/my_package.git"
  },
  "keywords": [],
  "author": "",
  "license": "ISC",
  "bugs": {
    "url": "https://github.com/monatheoctocat/my_package/issues"
  },
  "homepage": "https://github.com/monatheoctocat/my_package"
}
```

#### Default values extracted from the current directory

- `name`: the current directory name
- `version`: always `1.0.0`
- `description`: info from the README, or an empty string `""`
- `scripts`: by default creates an empty `test` script
- `keywords`: empty
- `author`: empty
- `license`: [`ISC`](https://opensource.org/licenses/ISC)
- `bugs`: information from the current directory, if present
- `homepage`: information from the current directory, if present

### Setting config options for the init command

You can set default config options for the init command. For example, to set the default author email, author name, and license, on the command line, run the following commands:

```
> npm set init-author-email "example-user@example.com"
> npm set init-author-name "example_user"
> npm set init-license "MIT"
```

# Creating Node.js modules

Node.js modules are a type of [package](https://docs.npmjs.com/about-packages-and-modules) that can be published to npm.

## Create a `package.json` file

1. To create a `package.json` file, on the command line, in the root directory of your Node.js module, run `npm init`:
   - For [scoped modules](https://docs.npmjs.com/about-scopes), run `npm init --scope=@scope-name`
   - For [unscoped modules](https://docs.npmjs.com/creating-and-publishing-unscoped-public-packages), run `npm init`
2. Provide responses for the required fields (`name` and `version`), as well as the `main` field:
   - `name`: The name of your module.
   - `version`: The initial module version. We recommend following [semantic versioning guidelines](https://docs.npmjs.com/about-semantic-versioning) and starting with `1.0.0`.

For more information on `package.json` files, see "[Creating a package.json file](https://docs.npmjs.com/creating-a-package-json-file)".

## Create the file that will be loaded when your module is required by another application

In the file, add a function as a property of the `exports` object. This will make the function available to other code:

```
exports.printMsg = function() {
  console.log("This is a message from the demo package");
}
```

## Test your module

1. Publish your package to npm:

   - For [private packages](https://docs.npmjs.com/creating-and-publishing-private-packages#publishing-private-packages) and [unscoped packages](https://docs.npmjs.com/creating-and-publishing-unscoped-public-packages#publishing-unscoped-public-packages), use `npm publish`.
   - For [scoped public packages](https://docs.npmjs.com/creating-and-publishing-scoped-public-packages#publishing-scoped-public-packages), use `npm publish --access public`

2. On the command line, create a new test directory outside of your project directory.

   ```
   mkdir test-directory
   ```

3. Switch to the new directory:

   ```
   cd /path/to/test-directory
   ```

4. In the test directory, install your module:

   ```
   npm install <your-module-name>
   ```

5. In the test directory, create a `test.js` file which requires your module and calls your module as a method.

6. On the command line, run `node test.js`. The message sent to the console.log should appear.

> 参考：https://youtu.be/3I78ELjTzlQ