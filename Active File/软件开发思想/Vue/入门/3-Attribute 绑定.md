# Attribute 绑定

在 Vue 中，mustache 语法 (即双大括号) 只能用于文本插值。为了给 attribute 绑定一个动态值，需要使用 `v-bind` 指令：

```vue
<div v-bind:id="dynamicId"></div>
```

**指令**是由 `v-` 开头的一种特殊 attribute。它们是 Vue 模板语法的一部分。和文本插值类似，指令的值是可以访问组件状态的 JavaScript 表达式。关于 `v-bind` 和指令语法的完整细节请详阅[指南 - 模板语法](https://cn.vuejs.org/guide/essentials/template-syntax.html)。

冒号后面的部分 (`:id`) 是指令的“参数”。此处，元素的 `id` attribute 将与组件状态里的 `dynamicId` 属性保持同步。

由于 `v-bind` 使用地非常频繁，它有一个专门的简写语法：

```vue
<div :id="dynamicId"></div>
```

## 参考代码

现在，试着把一个动态的 `class` 绑定添加到这个 `<h1>` 上，并使用 `titleClass` 的 ref 作为它的值。如果绑定正确，文字将会变为红色。

```vue
<script setup>
import { ref } from 'vue'

const titleClass = ref('title')
</script>

<template>
  <h1 v-bind:class="titleClass">Make me red</h1> <!-- 此处添加一个动态 class 绑定 -->
</template>

<style>
.title {
  color: red;
}
</style>
```

