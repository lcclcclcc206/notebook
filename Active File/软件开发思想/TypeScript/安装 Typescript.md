### via npm

TypeScript is available as a [package on the npm registry](https://www.npmjs.com/package/typescript) available as `"typescript"`.

You will need a copy of [Node.js](https://nodejs.org/en/) as an environment to run the package. Then you use a dependency manager like [npm](https://www.npmjs.com/), [yarn](https://yarnpkg.com/) or [pnpm](https://pnpm.js.org/) to download TypeScript into your project.

```
npm install typescript --save-dev
```

All of these dependency managers support lockfiles, ensuring that everyone on your team is using the same version of the language. You can then run the TypeScript compiler using one of the following commands:

```
npx tsc
```

## 项目基本配置

假设 ts 代码文件位于 src 目录，生成的目录位于 dist 文件夹

需要以 node 使用的版本继承 tsconfig.json 文件，以 node 18 为例

tsconfig.json

```json
{
  "extends": "@tsconfig/node18/tsconfig.json",
  "compilerOptions": {
    "rootDir": "src",
    "outDir": "dist"
  }
}
```

package.json

```json
{
  "name": "1-firstapp",
  "version": "1.0.0",
  "description": "",
  "main": "dist/main.js",
  "scripts": {
    "build": "tsc",
    "dev": "tsc && node dist/main.js"
  },
  "keywords": [],
  "author": "",
  "license": "ISC",
  "dependencies": {
    "typescript": "^5.0.2"
  },
  "devDependencies": {
    "@tsconfig/node18": "^1.0.1",
    "@types/node": "^18.15.3"
  }
}

```

