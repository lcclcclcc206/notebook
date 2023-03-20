[Install Tailwind CSS with Vite - Tailwind CSS](https://tailwindcss.com/docs/guides/vite#vue)

## Create your project

```
npm init vue
```

## Install Tailwind CSS

```
cd project
npm install -D tailwindcss postcss autoprefixer
```

```
npx tailwindcss init -p
```

## Configure your template paths

Add the paths to all of your template files in your `tailwind.config.js` file.

```js
/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./index.html",
    "./src/**/*.{vue,js,ts,jsx,tsx}",
  ],
  theme: {
    extend: {},
  },
  plugins: [],
}
```

## Add the Tailwind directives to your CSS

Add the `@tailwind` directives for each of Tailwind’s layers to your `./src/style.css` file.

```css
@tailwind base;
@tailwind components;
@tailwind utilities;
```

> 将其复制于根 css 文件中

## Test Tailwind

Start using Tailwind’s utility classes to style your content.

```vue
<template>
  <h1 class="text-3xl font-bold underline">
    Hello world!
  </h1>
</template>
```

```
npm run dev
```

