<script setup >
import { ref, inject } from 'vue'
import TheFormPopupVue from '../components/layout/TheFormPopup.vue'
import TheHeaderVue from '../components/layout/TheHeader.vue'
import TheMainContentVue from '../components/layout/TheMainContent.vue'
import TheMainContentHeaderVue from '../components/layout/TheMainContentHeader.vue'
import TheSideBarVue from '../components/layout/TheSideBar.vue'

const $MISAresource = inject('$MISAresource')
const isShowPopup = ref(false)
const isShowSidebar = ref(false)
const notification = ref({
  type: '',
  content: ''
})

/**
 * Chức năng: Đóng form
 * @param {*} number
 * @returns không
 * Author: lhhanh (21/08/2023)
 */
function closeForm() {
  isShowPopup.value = false
}
</script>
<template>
  <body>
    <div class="box">
      <TheSideBarVue></TheSideBarVue>
      <aside class="blue">
        <TheHeaderVue> </TheHeaderVue>
        <div class="aside__main aside__main--padding">
          <TheMainContentVue v-model:isShowPopup="isShowPopup"> </TheMainContentVue>
        </div>
      </aside>
    </div>
    <TheFormPopupVue
      @close-form="closeForm"
      :isShowPopup="isShowPopup"
      v-model:notification="notification"
    >
    </TheFormPopupVue>
  </body>
</template>
<style>
@import url('@/css/main.css');
</style>
