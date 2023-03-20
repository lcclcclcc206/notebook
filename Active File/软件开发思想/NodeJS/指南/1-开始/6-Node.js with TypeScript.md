**[TypeScript](https://www.typescriptlang.org/)** is a trendy open-source language maintained and developed by Microsoft. It's loved and used by a lot of software developers around the world.

### Examples

Take a look at this code snippet and then we can unpack it together:

```ts
type User = {
  name: string;
  age: number;
};

function isAdult(user: User): boolean {
  return user.age >= 18;
}

const justine: User = {
  name: 'Justine',
  age: 23,
};

const isJustineAnAdult: boolean = isAdult(justine);

```

**First thing to do is to install TypeScript in our project:**

```bash
npm i -D typescript
```

Now we can compile it to JavaScript using `tsc` command in the terminal. Let's do it!

**Assuming that our file is named `example.ts`, the command would look like:**

```
npx tsc example.ts
```

> [npx](https://www.npmjs.com/package/npx) here stands for Node Package Execute. This tool allows us to run TypeScript's compiler without installing it globally.

`tsc` is the TypeScript compiler which will take our TypeScript code and compile it to JavaScript. This command will result in a new file named `example.js` that we can run using Node.js. 

## More about TypeScript

TypeScript offers a whole lot of other great mechanisms like interfaces, classes, utility types and so on. Also, on bigger projects you can declare your TypeScript compiler configuration in a separate file and granularly adjust how it works, how strict it is and where it stores compiled files for example. You can read more about all this awesome stuff in [the official TypeScript docs](https://www.typescriptlang.org/docs).

Some of the other benefits of TypeScript that are worth mentioning are that it can be adopted progressively, it helps making code more readable and understandable and it allows developers to use modern language features while shipping code for older Node.js versions.

## TypeScript in the Node.js world

TypeScript is well-established in the Node.js world and used by many companies, open-source projects, tools and frameworks. Some of the notable examples of open-source projects using TypeScript are:

- [NestJS](https://nestjs.com/) - robust and fully-featured framework that makes creating scalable and well-architected systems easy and pleasant
- [TypeORM](https://typeorm.io/#/) - great ORM influenced by other well-known tools from other languages like Hibernate, Doctrine or Entity Framework
- [Prisma](https://prisma.io/) - next-generation ORM featuring a declarative data model, generated migrations and fully type-safe database queries
- [RxJS](https://rxjs.dev/) - widely used library for reactive programming
- [AdonisJS](https://adonisjs.com/) - A fully featured web framework with Node.js
- [FoalTs](https://foalts.org/) - The Elegant Nodejs Framework

And many, many more great projects... Maybe even your next one!