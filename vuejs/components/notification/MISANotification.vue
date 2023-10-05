<script setup>
import { ref, inject } from 'vue'

const $MISAresource = inject('$MISAresource')

const props = defineProps({
  content: String,
  type: {
    type: String,
    required: true
  }
})
const iconClass1 = ref('')
const iconClass2 = ref('')

//notification_class.
function checkTypeNotification() {
  switch (props.type) {
    case 'danger':
      iconClass1.value = $MISAresource.notification_class.danger.iconClass1
      iconClass2.value = $MISAresource.notification_class.danger.iconClass2
      break
    case 'success':
      iconClass1.value = $MISAresource.notification_class.success.iconClass1
      iconClass2.value = $MISAresource.notification_class.success.iconClass2
      break
    case 'warning':
      iconClass1.value = $MISAresource.notification_class.warning.iconClass1
      iconClass2.value = $MISAresource.notification_class.warning.iconClass2
      break
    case 'info':
      iconClass1.value = $MISAresource.notification_class.info.iconClass1
      iconClass2.value = $MISAresource.notification_class.info.iconClass2
      break
    default:
    // code block
  }
}
checkTypeNotification()
</script>
<template>
  <link
    rel="stylesheet"
    href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"
  />
  <div class="container">
    <div class="notification" :class="iconClass1">
      <i class="fa-solid" :class="iconClass2"></i>
      <slot> {{ content }} </slot>
    </div>
  </div>
</template>
<style scoped>
.container {
  padding: 10px;
  border-radius: 10px;
  width: 280px;
  gap: 30px;
  position: fixed;
  z-index: 1;
  right: 3rem;
  top: 0;
  font-family: 'FontAwesome', sans-serif !important;
  left: 50%;
  transform: translateX(-50%);
}

.notification {
  background-color: #fff;
  padding: 15px;
  width: 100%;
  border-radius: 20px;
  box-shadow: 0 2px 5px #00000033;
  cursor: pointer;
  font-weight: 500;
  display: flex;
  align-items: center;
  gap: 15px;
  position: relative;
  overflow: hidden;
}

i {
  color: #fff;
  border-radius: 50%;
  font-size: 20px;
  width: 37px;
  height: 37px;
  display: flex !important;
  justify-content: center;
  align-items: center;
}

.notification span {
  font-size: 18px;
  color: #5d6672 !important;
  line-height: 1.6;
  white-space: nowrap;
}

.notification.success {
  border: 1px solid var(--success-md);
  background-color: var(--success-l);
}

.notification.success i {
  background-color: var(--success);
}

/*******/
.notification.info {
  border: 1px solid var(--info-md);
  background-color: var(--info-l);
}

.notification.info i {
  background-color: var(--info);
}

/*******/
.notification.warning {
  border: 1px solid var(--warning-md);
  background-color: var(--warning-l);
}

.notification.warning i {
  background-color: var(--warning);
}

.notification.warning .icon {
  background-color: var(--warning);
}

/********/
.notification.danger {
  border: 1px solid var(--danger-md);
  background-color: var(--danger-l);
}

.notification.danger i {
  background-color: var(--danger);
}

.fa-times {
  position: absolute;
  right: 15px;
  color: #777;
  background-color: transparent !important;
}
</style>
