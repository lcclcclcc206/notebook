[serve - npm (npmjs.com)](https://www.npmjs.com/package/serve)

`serve` helps you serve a static site, single page application or just a static file (no matter if on your device or on the local network). It also provides a neat interface for listing the directory's contents:

![Listing UI](https://raw.githubusercontent.com/vercel/serve/main/media/listing-ui.png)

The quickest way to get started is to just run `npx serve` in your project's directory.

If you prefer, you can also install the package globally (you'll need at least [Node LTS](https://github.com/nodejs/Release#release-schedule)):

```
> npm install --global serve
```

Once that's done, you can run this command inside your project's directory...

```
> serve
```

...or specify which folder you want to serve:

```
> serve folder-name/
```

Finally, run this command to see a list of all available options:

```
> serve --help
```

## Configuration

To customize `serve`'s behavior, create a `serve.json` file in the public folder and insert any of [these properties](https://github.com/vercel/serve-handler#options).

## API

The core of `serve` is [`serve-handler`](https://github.com/vercel/serve-handler), which can be used as middleware in existing HTTP servers:

```js
const handler = require('serve-handler');
const http = require('http');

const server = http.createServer((request, response) => {
  // You pass two more arguments for config and middleware
  // More details here: https://github.com/vercel/serve-handler#options
  return handler(request, response);
});

server.listen(3000, () => {
  console.log('Running at http://localhost:3000');
});
```

> You can also replace `http.createServer` with [`micro`](https://github.com/vercel/micro).