Use these shorthand utilities for quickly configuring the position of an element.

## Position values 

Quick positioning classes are available, though they are not responsive.

```html
<div class="position-static">...</div>
<div class="position-relative">...</div>
<div class="position-absolute">...</div>
<div class="position-fixed">...</div>
<div class="position-sticky">...</div>
```

## Arrange elements 

Arrange elements easily with the edge positioning utilities. The format is `{property}-{position}`.

Where *property* is one of:

- `top` - for the vertical `top` position
- `start` - for the horizontal `left` position (in LTR)
- `bottom` - for the vertical `bottom` position
- `end` - for the horizontal `right` position (in LTR)

Where *position* is one of:

- `0` - for `0` edge position
- `50` - for `50%` edge position
- `100` - for `100%` edge position

(You can add more position values by adding entries to the `$position-values` Sass map variable.)

![image-20221225152123251](.Position/image-20221225152123251.png)

```html
<div class="position-relative">
  <div class="position-absolute top-0 start-0"></div>
  <div class="position-absolute top-0 end-0"></div>
  <div class="position-absolute top-50 start-50"></div>
  <div class="position-absolute bottom-50 end-50"></div>
  <div class="position-absolute bottom-0 start-0"></div>
  <div class="position-absolute bottom-0 end-0"></div>
</div>
```

## Center elements 

In addition, you can also center the elements with the transform utility class `.translate-middle`.

This class applies the transformations `translateX(-50%)` and `translateY(-50%)` to the element which, in combination with the edge positioning utilities, allows you to absolute center an element.

![image-20221225152244770](.Position/image-20221225152244770.png)



```html
<div class="position-relative">
  <div class="position-absolute top-0 start-0 translate-middle"></div>
  <div class="position-absolute top-0 start-50 translate-middle"></div>
  <div class="position-absolute top-0 start-100 translate-middle"></div>
  <div class="position-absolute top-50 start-0 translate-middle"></div>
  <div class="position-absolute top-50 start-50 translate-middle"></div>
  <div class="position-absolute top-50 start-100 translate-middle"></div>
  <div class="position-absolute top-100 start-0 translate-middle"></div>
  <div class="position-absolute top-100 start-50 translate-middle"></div>
  <div class="position-absolute top-100 start-100 translate-middle"></div>
</div>
```

By adding `.translate-middle-x` or `.translate-middle-y` classes, elements can be positioned only in horizontal or vertical direction.

![image-20221225152311516](.Position/image-20221225152311516.png)

```html
<div class="position-relative">
  <div class="position-absolute top-0 start-0"></div>
  <div class="position-absolute top-0 start-50 translate-middle-x"></div>
  <div class="position-absolute top-0 end-0"></div>
  <div class="position-absolute top-50 start-0 translate-middle-y"></div>
  <div class="position-absolute top-50 start-50 translate-middle"></div>
  <div class="position-absolute top-50 end-0 translate-middle-y"></div>
  <div class="position-absolute bottom-0 start-0"></div>
  <div class="position-absolute bottom-0 start-50 translate-middle-x"></div>
  <div class="position-absolute bottom-0 end-0"></div>
</div>
```