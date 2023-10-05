<script setup>
import { computed, ref } from 'vue';
const props = defineProps({
    label: String,

    placeholder: String,
    disabled: {
        type: Boolean,
    },
    modelValue: Number,
});
const emit = defineEmits(['update:modelValue']);
let isDisplayErrorMessage = ref(false);
const valueLocal = computed({
    get() {
        return props.modelValue;
    },
    set(val) {
        emit('update:modelValue', val);
    },
});

function increaseValue() {
    emit('update:modelValue', props.modelValue + 1);
}

function decreaseValue() {
    emit('update:modelValue', props.modelValue - 1);
}

const onInputChange = (e) => {
    console.log(e.target.value);
    isDisplayErrorMessage.value = false;
};
const onBlur = (event) => {
    console.log('im blured');
    isDisplayErrorMessage.value = true;
};
</script>
<template>
    <label>
        <div>{{ label }} <span class="red-text">*</span></div>
    </label>
    <div class="custom-nums">
        <div class="position-relative">
            <input
                type="number"
                class="number"
                id="input--quantity"
                v-model="valueLocal"
                @input="onInputChange"
                @blur="onBlur"
            />
            <span v-if="valueLocal == '' && isDisplayErrorMessage == true" class="error-message"
                >Vui lòng nhập thông tin</span
            >
            <div class="square-24-24-right input__transform--dropdown">
                <span class="sprite-updown-arrow sprite-center"></span>
                <div class="div__uparrow-wrapper" @click="increaseValue"></div>
                <div class="div__downarrow-wrapper" @click="decreaseValue"></div>
            </div>
        </div>
    </div>
</template>
<style>
@import url('@/css/main.css');
</style>
