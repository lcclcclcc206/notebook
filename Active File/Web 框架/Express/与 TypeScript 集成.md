package.json

```json
{
  "name": "1-firstapp",
  "version": "1.0.0",
  "description": "",
  "main": "dist/app.js",
  "scripts": {
    "build": "tsc",
    "dev": "tsc && node dist/app.js"
  },
  "keywords": [],
  "author": "",
  "license": "ISC",
  "dependencies": {
    "express": "^4.18.2"
  },
  "devDependencies": {
    "@tsconfig/node18": "^1.0.1",
    "@types/express": "^4.17.17",
    "@types/node": "^18.15.3"
  }
}
```

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

