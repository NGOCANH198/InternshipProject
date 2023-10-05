<script setup>
import MISASInputStandardVue from '../base/input/MISAInputStandard.vue'
import MISAInputWithIconVue from '../base/input/MISAInputWithIcon.vue'
</script>
<template>
  <div class="aside__main--top">
    <div class="aside__main--left">
      <MISASInputStandardVue placeholder="Tìm kiếm tài sản">
        <template v-slot:icon-name> <span class="sprite-search sprite-center"> </span> </template>
      </MISASInputStandardVue>
      <MISAInputWithIconVue placeholder="Loại tài sản">
        <template v-slot:icon-name> <span class="sprite-filter sprite-center"> </span> </template>
      </MISAInputWithIconVue>
      <MISAInputWithIconVue placeholder="Bộ phận sử dụng">
        <template v-slot:icon-name> <span class="sprite-filter sprite-center"> </span> </template>
      </MISAInputWithIconVue>
    </div>
    <div class="aside__main--right">
      <button class="button-with-icon"><span class="sprite-plus"></span>Thêm tài sản</button>
      <div class="wrapper-dropdown">
        <div class="position-relative">
          <div class="square-36-36 button-one-icon">
            <span class="sprite-delete sprite-center"></span>
          </div>
        </div>
      </div>
      <!-- </button> -->
      <div class="wrapper-dropdown">
        <div class="position-relative">
          <div class="square-36-36 button-one-icon">
            <span class="sprite-excel sprite-center"></span>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
<style>
</style>
