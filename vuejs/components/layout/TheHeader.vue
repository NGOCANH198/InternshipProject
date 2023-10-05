<script setup>
import { computed, ref } from 'vue'
const inputVal = ref(0)

/**
 * Chức năng: Tăng giá trị input
 * @param {*} number
 * @returns không
 * Author: lhhanh (21/08/2023)
 */
function increaseValue() {
  inputVal.value = inputVal.value + 1
}

/**
 * Chức năng: Giảm giá trị input
 * @param {*} number
 * @returns không
 * Author: lhhanh (21/08/2023)
 */
function decreaseValue() {
  inputVal.value = inputVal.value - 1
}
</script>
<template>
  <header>
    <span class="header__span--title bold">Danh sách tài sản</span>
    <div class="header__right header__div--center">
      <div class="wrapper-faculty">
        <span class="header__span--faculty">Sở tài chính</span>
      </div>
      <div class="header__right--year header__div--center custom-nums" id="">
        <span>Năm</span>
        <input
          type="number"
          class="header__input--year"
          :value="inputVal"
          placeholder="Chọn mã loại tài sản"
        />
        <div class="square-24-24-right square-24-24-right--modified">
          <span class="sprite-updown-arrow sprite-center"></span>
          <div class="div__uparrow-wrapper" @click="increaseValue"></div>
          <div class="div__downarrow-wrapper" @click="decreaseValue"></div>
        </div>
      </div>
      <div class="header__right--icon header__div--center">
        <div class="position-relative header__icon--margin">
          <div class="square-24-24">
            <span class="sprite-bell sprite-center"></span>
          </div>
        </div>
        <div class="position-relative header__icon--margin">
          <div class="square-24-24">
            <span class="sprite-grid sprite-center"></span>
          </div>
        </div>
        <div class="position-relative header__icon--margin">
          <div class="square-24-24">
            <span class="sprite-question sprite-center"></span>
          </div>
        </div>
        <div class="header__right--subicon header__icon--margin header__div--center">
          <div class="position-relative">
            <div class="square-24-24">
              <span class="sprite-avatar sprite-center"></span>
            </div>
          </div>
          <span class="sprite-down-arrow headeRightr__arrow--marginl"></span>
        </div>
      </div>
    </div>
  </header>
</template>
<style >
@import url('@/css/layout/header.css');
</style>
