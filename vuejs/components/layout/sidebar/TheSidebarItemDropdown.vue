<script setup>
const props = defineProps(['tooltip', 'isShowSidebar'])
</script>

<template>
  <a href="#">
    <div class="position-relative center-horizontal menu__li--item-padding">
      <div class="rectangle-40-40 center-horizontal">
        <slot name="icon-name"></slot>
      </div>
      <div class="menu__hidden--wrapper">
        <span
          class="sidebar__icon--description"
          v-if="tooltip"
          :title="tooltip"
          key="menu-icon-tooltip"
          ><slot name="icon-description"></slot
        ></span>

        <span class="sidebar__icon--description" v-else><slot name="icon-description"></slot></span>
        <div class="square-24-24 center-horizontal" v-if="isShowSidebar" key="menu-icon-downarrow">
          <span class="sprite-down-arrow--white"> </span>
        </div>
      </div>
    </div>
  </a>
</template>
<style scoped>
@import url('@/css/main.css');
</style>
