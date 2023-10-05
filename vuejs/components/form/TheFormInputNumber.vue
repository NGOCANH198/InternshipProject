<script setup>
import { computed, ref } from 'vue';
const props = defineProps({
    label: String,
    forceInput: {
        type: Boolean,
        default: true,
    },
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
        <div>{{ label }} <span class="red-text" v-if="forceInput">*</span></div>
    </label>
    <div class="custom-nums">
        <div class="position-relative">
            <input
                type="number"
                class="number-without-icon"
                :placeholder="placeholder"
                :disabled="disabled"
                v-model="valueLocal"
                @input="onInputChange"
                @blur="onBlur"
            />
            <span v-if="valueLocal == '' && isDisplayErrorMessage == true" class="error-message"
                >Vui lòng nhập thông tin</span
            >
        </div>
    </div>
</template>
<style>
@import url('@/css/main.css');
</style>
