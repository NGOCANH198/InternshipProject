<script setup>
import { computed, ref } from 'vue';
const props = defineProps({
    label: String,
    placeholder: String,
    forceInput: {
        type: Boolean,
        default: true,
    },
    modelValue: String,
    disabled: {
        type: Boolean,
    },
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
    <div>{{ label }} <span class="red-text" v-if="forceInput">*</span></div>
    <label>
        <input
            name="field1"
            type="text"
            :placeholder="placeholder"
            :disabled="disabled"
            v-model="valueLocal"
            required
            title="Please enter your name"
            :class="{ 'error-input': valueLocal == '' && isDisplayErrorMessage == true }"
            @input="onInputChange"
            @blur="onBlur"
        />
        <span v-if="valueLocal == '' && isDisplayErrorMessage == true" class="error-message"
            >Vui lòng nhập thông tin</span
        >
    </label>
</template>
<style>
@import url('@/css/main.css');
</style>
