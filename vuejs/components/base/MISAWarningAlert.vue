<script setup>
import { computed } from 'vue';

/**
 * Chức năng: Đóng warning
 * @param {*}
 * @returns không
 * Author: lhhanh (24/08/2023)
 */
function closeWarning() {
    valueLocal.value = true;
    console.log('hhaha');
}
</script>
<template>
    <div class="wrapper-whole">
        <div class="wrapper__warning">
            <div class="wrapper__warning--content">
                <div class="position-relative center-horizontal">
                    <div class="rectangle-40-40--nothover center-horizontal">
                        <span class="sprite-warning"> </span>
                    </div>
                    <div>
                        <!-- <span> Tổng quan</span> -->
                        <slot name="content-alert"> </slot>
                    </div>
                </div>
            </div>
            <div class="wrapper__warning--controller">
                <!-- <button class="button button__background--save">Button</button>
        <button class="button button__background--sub">Button</button>
        <button class="button button__background--outline">Button</button> -->

                <slot name="sub-button"> </slot>
                <slot name="outline-button"> </slot>
                <slot name="save-button"> </slot>
            </div>
        </div>
    </div>
</template>
<style >
@import url('@/css/main.css');
.wrapper-whole {
    position: fixed;
    z-index: 1;
    left: 0;
    top: 0;
    width: 100%;
    height: 100%;
    overflow: auto;
    background-color: transparent;
    display: block;
}

.wrapper__warning {
    position: relative;
    background-color: white;
    padding: 2rem 1rem 1rem 1.5rem;
    border: 1px solid #888888;
    width: 35%;
    font-weight: bolder;
    border-radius: var(--button-border-radius);
    box-shadow: var(--box-shadow-form);
    border-color: transparent;
    top: 50%;
    left: 50%;
    transform: translateY(-50%) translateX(-50%);
}

.wrapper__warning--content {
    font-size: 1rem;
    margin-bottom: 2rem;
}

.wrapper__warning--controller {
    display: flex;
    justify-content: flex-end;
}

/* .wrapper__warning--controller button:nth-child(2),
.wrapper__warning--controller button:nth-child(3) {
    margin-left: 10px;
} */

.wrapper__warning--controller .button {
    margin-left: 10px;
}
</style>
