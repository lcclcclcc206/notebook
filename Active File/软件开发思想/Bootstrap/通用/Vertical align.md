Easily change the vertical alignment of inline, inline-block, inline-table, and table cell elements.

Change the alignment of elements with the [`vertical-alignment`](https://developer.mozilla.org/en-US/docs/Web/CSS/vertical-align) utilities. Please note that vertical-align only affects inline, inline-block, inline-table, and table cell elements.

Choose from `.align-baseline`, `.align-top`, `.align-middle`, `.align-bottom`, `.align-text-bottom`, and `.align-text-top` as needed.

To vertically center non-inline content (like `<div>`s and more), use our [flex box utilities](https://getbootstrap.com/docs/5.2/utilities/flex/#align-items).

With inline elements:

![image-20221225165915770](.Vertical align/image-20221225165915770.png)

```html
<span class="align-baseline">baseline</span>
<span class="align-top">top</span>
<span class="align-middle">middle</span>
<span class="align-bottom">bottom</span>
<span class="align-text-top">text-top</span>
<span class="align-text-bottom">text-bottom</span>
```

With table cells:

![image-20221225165940444](.Vertical align/image-20221225165940444.png)

```html
<table style="height: 100px;">
  <tbody>
    <tr>
      <td class="align-baseline">baseline</td>
      <td class="align-top">top</td>
      <td class="align-middle">middle</td>
      <td class="align-bottom">bottom</td>
      <td class="align-text-top">text-top</td>
      <td class="align-text-bottom">text-bottom</td>
    </tr>
  </tbody>
</table>
```