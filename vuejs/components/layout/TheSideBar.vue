<script setup>
import { ref } from 'vue'
import TheSidebarItemVue from './sidebar/TheSidebarItem.vue'
import TheSidebarItemDropdownVue from './sidebar/TheSidebarItemDropdown.vue'

const isShowSidebar = ref(false)
const activeEl = ref(0)

/**
 * Chức năng: Đóng sidebar
 * @param {*} number
 * @returns không
 * Author: lhhanh (21/08/2023)
 */
function closeSideBar() {
  isShowSidebar.value = false
}

/**
 * Chức năng: Đóng sidebar
 * @param {*} number
 * @returns không
 * Author: lhhanh (21/08/2023)
 */
function openSidebar() {
  isShowSidebar.value = true
}

/**
 * Chức năng: Thêm
 * @param {*} number
 * @returns không
 * Author: lhhanh (21/08/2023)
 */
function activate(el) {
  activeEl.value = el
}
</script>
<template>
  <nav
    class="nav-leftside"
    :class="{ 'nav--open': isShowSidebar === true, 'nav--close': isShowSidebar === false }"
  >
    <div>
      <span class="logo">
        <a href="#">
          <div class="position-relative">
            <div class="center-horizontal">
              <span class="sprite-logo margin__nav--logo"></span>
              <div class="menu__hidden--wrapper" :class="{ hide: isShowSidebar == false }">
                <span class="sidebar__icon--description">
                  <h2>MISA QLTS</h2>
                </span>
              </div>
            </div>
          </div>
        </a>
      </span>
    </div>
    <ul class="menu" @click="openSidebar">
      <li class="opacity__sprite--50" @click="activate(1)" :class="{ active: activeEl == 1 }">
        <TheSidebarItemVue>
          <template v-slot:icon-name>
            <span class="sprite-tivi"> </span>
          </template>
          <template v-if="isShowSidebar" v-slot:icon-description> Tổng quan </template>
        </TheSidebarItemVue>
      </li>
      <li class="opacity__sprite--50" @click="activate(2)" :class="{ active: activeEl == 2 }">
        <TheSidebarItemDropdownVue :isShowSidebar="isShowSidebar">
          <template v-slot:icon-name>
            <span class="sprite-car"> </span>
          </template>
          <template v-if="isShowSidebar" v-slot:icon-description>Tài sản</template>
        </TheSidebarItemDropdownVue>
      </li>
      <li class="opacity__sprite--50" @click="activate(3)" :class="{ active: activeEl == 3 }">
        <TheSidebarItemDropdownVue
          :isShowSidebar="isShowSidebar"
          title="Tài sản hình thành trong tương lai - Đơn vị bảo lãnh"
        >
          <template v-slot:icon-name>
            <span class="sprite-road"> </span>
          </template>
          <template v-if="isShowSidebar" v-slot:icon-description>Tài sản HT-ĐB</template>
        </TheSidebarItemDropdownVue>
      </li>
      <li class="opacity__sprite--50" @click="activate(4)" :class="{ active: activeEl == 4 }">
        <TheSidebarItemDropdownVue :isShowSidebar="isShowSidebar">
          <template v-slot:icon-name>
            <span class="sprite-paint"> </span>
          </template>
          <template v-if="isShowSidebar" v-slot:icon-description>Công cụ dụng cụ</template>
        </TheSidebarItemDropdownVue>
      </li>
      <li class="opacity__sprite--50" @click="activate(5)" :class="{ active: activeEl == 5 }">
        <TheSidebarItemVue>
          <template v-slot:icon-name>
            <span class="sprite-task-list"> </span>
          </template>
          <template v-if="isShowSidebar" v-slot:icon-description>Danh mục</template>
        </TheSidebarItemVue>
      </li>
      <li class="opacity__sprite--50" @click="activate(6)" :class="{ active: activeEl == 6 }">
        <TheSidebarItemDropdownVue :isShowSidebar="isShowSidebar">
          <template v-slot:icon-name>
            <span class="sprite-search-bg-dark"> </span>
          </template>
          <template v-if="isShowSidebar" v-slot:icon-description>Tra cứuụ</template>
        </TheSidebarItemDropdownVue>
      </li>
      <li class="opacity__sprite--50" @click="activate(7)" :class="{ active: activeEl == 7 }">
        <TheSidebarItemDropdownVue :isShowSidebar="isShowSidebar">
          <template v-slot:icon-name>
            <span class="sprite-rating"> </span>
          </template>
          <template v-if="isShowSidebar" v-slot:icon-description>Báo cáo</template>
        </TheSidebarItemDropdownVue>
      </li>
    </ul>
    <footer :class="{ hide: isShowSidebar === false }">
      <div class="position-relative center-horizontal menu__li--item-padding">
        <div class="rectangle-40-40 center-horizontal" @click="closeSideBar">
          <span class="sprite-square-arrow-left"> </span>
        </div>
      </div>
    </footer>
  </nav>
</template>
<style>
@import url('@/css/main.css');
</style>
