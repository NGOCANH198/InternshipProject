<script setup>
import { computed, ref, watch, inject, nextTick } from 'vue';
const $MISAenum = inject('$MISAenum');
const props = defineProps({
    label: String,
    value: String,
    placeholder: String,
    disabled: {
        type: Boolean,
    },
    modelValue: String,
});
const emit = defineEmits(['update:modelValue']);

const show = ref(false);
const search = ref('');
const checks = ref([]);
const selected = ref('');
const products = ref(['Áo phông', 'Quần jean', 'Điện thoại', 'Máy tính']);
const followCheck = ref([]);
const state = ref($MISAenum.combo_box.all_selection);
const hoveredIndex = ref(0);
const hoveredIndexSub = ref(0);

const inputRef = ref(null);
const inputRefSub = ref(null);

let isDisplayErrorMessage = ref(false);
const onKeyPressAll = (e) => {
    console.log('all');
    if (e.key === 'ArrowDown') {
        hoveredIndex.value++;
        if (hoveredIndex.value > products.value.length - 1) {
            hoveredIndex.value = 0;
        }
    } else if (e.key === 'ArrowUp') {
        hoveredIndex.value--;
        if (hoveredIndex.value < 0) {
            hoveredIndex.value = products.value.length - 1;
        }
    } else if (e.key === 'Enter') {
        selected.value = products.value[hoveredIndex.value];
        console.log(selected.value);
        show.value = false;
        if (!checks.value.includes(selected.value)) {
            checks.value.push(selected.value);
        }
        handleChange();
    }
};

const onKeyPressSub = async (e) => {
    console.log('sub');
    if (e.key === 'ArrowDown') {
        hoveredIndexSub.value++;
        if (hoveredIndexSub.value > subdFilteredProperties.value.length - 1) {
            hoveredIndexSub.value = 0;
        }
    } else if (e.key === 'ArrowUp') {
        hoveredIndexSub.value--;
        if (hoveredIndexSub.value < 0) {
            hoveredIndexSub.value = subdFilteredProperties.value.length - 1;
        }
    } else if (e.key === 'Enter') {
        selected.value = subdFilteredProperties.value[hoveredIndexSub.value];
        console.log(selected.value);
        show.value = false;
        if (!checks.value.includes(selected.value)) {
            checks.value.push(selected.value);
        }
        handleChange();
        state.value = $MISAenum.combo_box.all_selection;
        await nextTick();
        inputRef.value.focus();
    }
};
const valueLocal = computed({
    get() {
        return props.modelValue;
    },
    set(val) {
        emit('update:modelValue', val);
    },
});
const checkedValues = computed({
    get() {
        return checks.value;
    },
    set(newValue) {
        checks.value = newValue;
    },
});
let subdFilteredProperties = computed(() => {
    return products.value.filter((p) => p.includes(search.value));
});
/**
 *
 */
let properties = computed(() => {
    return products.value;
});

/**
 * Chức năng: Mở đóng phần lựa chọn của combobox
 * @param {*} number
 * @returns không
 * Author: lhhanh (27/08/2023)
 */
function toggle() {
    console.log(show.value);
    show.value = !show.value;
}

/**
 * Chức năng: Cập nhật giá trị ô input sau khi select, binding 2 chiều valueLocal
 * @param {*} number
 * @returns không
 * Author: lhhanh (27/08/2023)
 */
function handleChange(el) {
    let inputVal = '';
    checks.value.forEach((val) => {
        inputVal += val + ', ';
    });
    valueLocal.value = inputVal;
}

/**
 * Chức năng: Chuyển đổi trạng thái selection box, cập nhật trạng thái input cha binding 2 chiều, update selection state 1 từ state 2
 * @param {*} number
 * @returns không
 * Author: lhhanh (27/08/2023)
 */
function resetSearchValue(item) {
    let inputVal = '';
    if (!checks.value.includes(item)) {
        checks.value.push(item);
    }
    checks.value.forEach((val) => {
        inputVal += val + ', ';
    });

    valueLocal.value = inputVal;
    search.value = '';
    state.value = $MISAenum.combo_box.all_selection;
}

async function handleChangeInputFather(el) {
    const result = el.target.value.split(', ');
    search.value = result[result.length - 1];
    state.value = $MISAenum.combo_box.auto_fill;
    show.value = true;
    isDisplayErrorMessage.value = false;
    await nextTick();
    inputRefSub.value.focus();
}

const onBlur = (event) => {
    console.log('im blured');
    isDisplayErrorMessage.value = true;
    show.value = false;
};
</script>
<template>
    <div class="wrapper">
        <label>
            <div class="wrapper-dropdown">
                {{ label }}
            </div>
            <span class="red-text"> *</span>
        </label>
        <div class="form-control toggle-next ellipsis form-input-name-row" @click="toggle">
            <div class="">
                <div class="position-relative">
                    <input
                        type="text"
                        class="filter italic-font"
                        :placeholder="placeholder"
                        v-model="valueLocal"
                        @input="handleChangeInputFather"
                        v-show="state == $MISAenum.combo_box.all_selection"
                        @keydown="onKeyPressAll"
                        ref="inputRef"
                        @blur="onBlur"
                    />

                    <input
                        type="text"
                        class="filter italic-font"
                        :placeholder="placeholder"
                        v-model="valueLocal"
                        @input="handleChangeInputFather"
                        v-show="state == $MISAenum.combo_box.auto_fill"
                        @keydown="onKeyPressSub"
                        ref="inputRefSub"
                        @blur="onBlur"
                    />
                    <div class="square-24-24-right input__transform--dropdown">
                        <span class="sprite-dropdown sprite-center"> </span>
                    </div>
                    <span v-if="valueLocal == '' && isDisplayErrorMessage == true" class="error-message"
                        >Vui lòng nhập thông tin</span
                    >
                </div>
            </div>
        </div>

        <transition name="slide" v-if="state === $MISAenum.combo_box.all_selection">
            <div v-if="show" class="content">
                <div class="checkboxes" id="Lorems">
                    <div class="inner-wrap">
                        <label
                            v-for="(item, index) in properties"
                            :class="{ 'background-option': item == products[hoveredIndex] }"
                        >
                            <input
                                type="checkbox"
                                :value="item"
                                class="ckkBox val"
                                @change="handleChange"
                                v-model="checks"
                            />
                            <span>{{ item }} </span>
                        </label>
                    </div>
                </div>
            </div>
        </transition>

        <transition name="slide" v-if="state === $MISAenum.combo_box.auto_fill">
            <div v-if="show" class="content">
                <div class="checkboxes" id="Lorems">
                    <div class="inner-wrap">
                        <label
                            v-for="(item, index) in subdFilteredProperties"
                            :class="{
                                'background-option': item == subdFilteredProperties[hoveredIndexSub],
                            }"
                        >
                            <input
                                type="checkbox"
                                :value="item"
                                class="ckkBox val"
                                @change="handleChange"
                                v-model="checks"
                            />
                            <span @click="resetSearchValue(item)">{{ item }} </span>
                        </label>
                    </div>
                </div>
            </div>
        </transition>
    </div>
</template>
<style >
@import url('@/css/components/popup.css');
@import url('@/css/main.css');
.toggle-next {
    border-radius: 0;
}

.checkboxes label {
    cursor: pointer;
    width: 100%;
    display: flex;
    align-items: center;
    background-color: #f9fafc;
}

.inner-wrap label:hover {
    background-color: #c7e0f5;
}
.background-option {
    background-color: #c7e0f5 !important;
}
.ellipsis {
    text-overflow: ellipsis;
    width: 100%;
    white-space: nowrap;
}

.apply-selection {
    display: none;
    width: 100%;
    margin: 0;
    padding: 5px 10px;
    border-bottom: 1px solid #ccc;
}

.apply-selection .ajax-link {
    display: none;
}

.checkboxes {
    /* margin: 0;
  display: block;
  border: 1px solid #ccc;
  border-top: 0; */

    margin: 0;
    display: block;
    border: 1px solid #ccc;
    border-top: 0;
    position: absolute;
    z-index: 10;
    width: 100%;
}

.checkboxes .inner-wrap {
    padding: 5px 10px;
    max-height: 140px;
    overflow: auto;
}

/* width */
::-webkit-scrollbar {
    width: 4px;
    height: 2px;
}

/* Track */
::-webkit-scrollbar-track {
    background: #fff;
    border-radius: 1px;
}

/* Handle */
::-webkit-scrollbar-thumb {
    background: #cdd3d6;
    border-radius: 2px;
}

::-webkit-scrollbar-thumb:hover {
    background: #555;
}

.slide-enter-active,
.slide-leave-active {
    transition: 400 3s ease;
    overflow: hidden;
}

.slide-enter-from,
.slide-leave-to {
    max-height: 0 !important;
}
.ckkBox.val {
    margin: 0px 0.5rem 0px 0px;
    width: 1rem !important;
    height: 1rem;
}
.inner-wrap {
    background-color: white;
}
.inner-wrap label {
    display: flex;
    align-items: center;
    margin-bottom: 0.5rem;
}
.wrapper {
    position: relative;
}
</style>
