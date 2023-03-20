Containers are a fundamental building block of Bootstrap that contain, pad, and align your content within a given device or viewport.

## How they work 

Containers are the most basic layout element in Bootstrap and are **required when using our default grid system**. Containers are used to contain, pad, and (sometimes) center the content within them. While containers *can* be nested, most layouts do not require a nested container.

Bootstrap comes with three different containers:

- `.container`, which sets a `max-width` at each responsive breakpoint
- `.container-{breakpoint}`, which is `width: 100%` until the specified breakpoint
- `.container-fluid`, which is `width: 100%` at all breakpoints

he table below illustrates how each container’s `max-width` compares to the original `.container` and `.container-fluid` across each breakpoint.

See them in action and compare them in our [Grid example](https://getbootstrap.com/docs/5.2/examples/grid/#containers).

|                    | Extra small<576px | Small≥576px | Medium≥768px | Large≥992px | X-Large≥1200px | XX-Large≥1400px |
| ------------------ | ----------------- | ----------- | ------------ | ----------- | -------------- | --------------- |
| `.container`       | 100%              | 540px       | 720px        | 960px       | 1140px         | 1320px          |
| `.container-sm`    | 100%              | 540px       | 720px        | 960px       | 1140px         | 1320px          |
| `.container-md`    | 100%              | 100%        | 720px        | 960px       | 1140px         | 1320px          |
| `.container-lg`    | 100%              | 100%        | 100%         | 960px       | 1140px         | 1320px          |
| `.container-xl`    | 100%              | 100%        | 100%         | 100%        | 1140px         | 1320px          |
| `.container-xxl`   | 100%              | 100%        | 100%         | 100%        | 100%           | 1320px          |
| `.container-fluid` | 100%              | 100%        | 100%         | 100%        | 100%           | 100%            |

## Default container

Our default `.container` class is a responsive, fixed-width container, meaning its `max-width` changes at each breakpoint.

```html
<div class="container">
  <!-- Content here -->
</div>
```