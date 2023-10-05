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
    modelValue: String,
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
    <input name="field3" type="date" class="date-input" v-model="valueLocal" @input="onInputChange" @blur="onBlur" />
    <span v-if="valueLocal == '' && isDisplayErrorMessage == true" class="error-message">Vui lòng nhập thông tin</span>
</template>
<style>
@import url('@/css/main.css');
</style>
