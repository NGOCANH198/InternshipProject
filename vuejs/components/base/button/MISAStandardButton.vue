<script setup>
const props = defineProps({
  content: String
})
</script>
<template>
  <button class="button">{{ content }}</button>
</template>
<style >
@import '@/css/components/button.css';
</style>
