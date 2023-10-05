<script setup>
defineProps(['placeholder'])
</script>
<template>
  <div class="wrapper-dropdown">
    <div class="position-relative">
      <div class="square-24-24-left">
        <!-- <span class="sprite-filter sprite-center"></span> -->
        <slot name="icon-name"> </slot>
      </div>
      <input type="text" class="filter margin__asided--input" :placeholder="placeholder" />
      <div class="square-24-24-right">
        <span class="sprite-dropdown sprite-center"></span>
      </div>
    </div>
  </div>
</template>

<style>
@import '@/css/components/input.css';
</style>
