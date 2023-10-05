<script setup>
import { computed } from 'vue'
const props = defineProps({
  value: String
})
</script>
<template>
  <div>{{ value }} <span class="red-text">*</span></div>
</template>
<style>
@import url('@/css/main.css');
</style>
