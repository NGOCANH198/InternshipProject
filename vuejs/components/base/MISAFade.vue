<script setup>
import { onUpdated, onMounted } from 'vue'
const props = defineProps({
  show: Boolean
})
</script>
<template>
  <transition name="fade">
    <div v-if="show">
      <slot></slot>
    </div>
  </transition>
</template>
<style scoped>
.fade-enter-active,
.fade-leave-active {
  transition: opacity 5s ease-out;
}

.fade-enter-from,
.fade-leave-to {
  opacity: 0;
}
</style>
