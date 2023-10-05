<script setup>
</script>
<template>
  <a href="#">
    <div class="position-relative center-horizontal menu__li--item-padding">
      <div class="rectangle-40-40 center-horizontal">
        <slot name="icon-name"></slot>
      </div>
      <div class="menu__hidden--wrapper">
        <span class="sidebar__icon--description"><slot name="icon-description"></slot></span>
      </div>
    </div>
  </a>
</template>
<style scoped>
@import url('@/css/main.css');
</style>
