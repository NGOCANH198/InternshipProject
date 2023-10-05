<script setup>
import { ref, inject, watch } from 'vue';
import { useNotificationStore } from '../../stores/notification';
import MISAInputVue from '../base/input/MISAInput.vue';
import MISAComboBoxVue from '../base/MISAComboBox.vue';
import MISAWarningAlertVue from '../base/MISAWarningAlert.vue';
import MISAStandardButtonVue from '../base/button/MISAStandardButton.vue';
import TheFormInputStandardVue from '../form/TheFormInputStandard.vue';
import TheFormInputNumberAdjustVue from '../form/TheFormInputNumberAdjust.vue';
import TheFormInputNumberVue from '../form/TheFormInputNumber.vue';
import TheFormInputDateVue from '../form/TheFormInputDate.vue';
import FormFunVue from '../form/FormFun.vue';
import MISANotificationVue from '../notification/MISANotification.vue';
import MISAFadeVue from '../base/MISAFade.vue';
import $MISAcommon from '../../helper/MISAcommon';
const notificationStore = useNotificationStore();

const props = defineProps(['isShowPopup', 'notification']);
const emit = defineEmits(['closeForm', 'update:notification']);

/**
 * Binding 2 chiều input
 */
const codeProperty = ref('TS00001');
const codeTypeDeputy = ref('');
const codeTypeProperty = ref('');
const quantityProperty = ref(0);
const buyDateProperty = ref('');
const nameProperty = ref('');
const priceValueProperty = ref(0);
const dateStartUsingProperty = ref('');
const yearUsedProperty = ref(1);
const yearFollow = ref('');
const percentageDownProperty = ref(parseFloat(1 / yearUsedProperty.value));
const downValueProperty = ref(percentageDownProperty.value * priceValueProperty.value);
let valueAddForCodeProperty = 1;

/**
 * Quản lý waring popup
 */
const isShowWarning = ref(false);
const typeWarning = ref('');

watch(codeProperty.value, () => {
    valueAddForCodeProperty++;
    codeProperty.value = 'TS' + String(valueAddForCodeProperty).padStart(5, '0');
});

watch(
    [percentageDownProperty, priceValueProperty],
    ([newpercentageDownProperty, newpriceValueProperty], [oldpercentageDownProperty, oldpriceValueProperty]) => {
        caculateDownValueProperty();
    },
);

/**
 * Chức năng: Tính toán giá trị của giá trị hao mòn dựa trên tỉ lệ hao mòn vào nguyên giá
 * @param {*}
 * @returns không
 * Author: lhhanh (24/08/2023)
 */
function caculateDownValueProperty() {
    downValueProperty.value = percentageDownProperty.value * priceValueProperty.value;
}
/**
 * Chức năng: Mở warning
 * @param {*}
 * @returns không
 * Author: lhhanh (24/08/2023)
 */
function showWarning(type) {
    isShowWarning.value = true;
    typeWarning.value = type;
}

/**
 * Chức năng: Đóng warning
 * @param {*}
 * @returns không
 * Author: lhhanh (24/08/2023)
 */
function closeWarning() {
    isShowWarning.value = false;
}

/**
 * Chức năng: Thông báo thành công khi lưu thông tin
 * @param {*}
 * @returns không
 * Author: lhhanh (24/08/2023)
 */
async function createSuccessNoti() {
    await caculateDownValueProperty();
    if (downValueProperty.value > priceValueProperty.value) {
        showWarning('warning_unproper_input');
        return;
    }

    if (1 / yearUsedProperty.value != percentageDownProperty.value) {
        showWarning('warning_down_percentage');
        return;
    }

    await notificationStore.displaySuccessNoti($MISAcommon.MISAresource.notification_content.popup_form.success_noti);
    isShowWarning.value = false;
    emit('closeForm');
}

/**
 * Chức năng: Dừng submit form, chuyển hướng hành động
 * @param {*}
 * @returns không
 * Author: lhhanh (24/08/2023)
 */
function onSubmit(e) {
    e.preventDefault();
}
</script>
<template >
    <div id="myPopup" class="popup" :class="{ show: isShowPopup }">
        <div class="popup-content">
            <div class="popup__div--form-header">
                <h2 class="inline--block">Thêm tài sản</h2>
                <div class="wrapper-dropdown">
                    <div class="position-relative">
                        <div
                            class="square-36-36 button-one-icon wrap-close-form remove-box-shadow"
                            @click="$emit('closeForm')"
                        >
                            <span class="sprite-excel sprite-form-close sprite-center"></span>
                        </div>
                    </div>
                </div>
            </div>

            <form class="form-validation" @submit.prevent="onSubmit">
                <div class="sub-entry">
                    <div class="form-row form-input-name-row">
                        <TheFormInputStandardVue
                            label="Mã tài sản"
                            placeholder="Nhập mã tài sản"
                            v-model="codeProperty"
                        />
                    </div>

                    <div class="form-row form-input-name-row">
                        <MISAComboBoxVue
                            label="Mã bộ phận sử dụng"
                            placeholder="Chọn mã bộ phận sử dụng"
                            v-model="codeTypeDeputy"
                        />
                    </div>
                    <div class="form-row form-input-name-row">
                        <MISAComboBoxVue
                            label="Mã loại tài sản"
                            placeholder="Chọn mã loại tài sản"
                            v-model="codeTypeProperty"
                        />
                    </div>

                    <div class="form-row form-input-name-row">
                        <TheFormInputNumberAdjustVue label="Số lượng" v-model="quantityProperty" />
                    </div>

                    <div class="form-row form-input-name-row">
                        <TheFormInputNumberAdjustVue label="Tỷ lệ hao mòn (%)" v-model="percentageDownProperty" />
                    </div>

                    <div class="form-row form-input-name-row">
                        <TheFormInputDateVue label="Ngày mua" v-model="buyDateProperty" />
                    </div>
                </div>
                <div class="clearfix">
                    <div class="sub-entry-2 margin-left">
                        <div class="main-content">
                            <div class="form-row form-input-name-row special-margin-top">
                                <TheFormInputStandardVue
                                    label="Tên tài sản"
                                    placeholder="Nhập tên tài sản"
                                    v-model="nameProperty"
                                />
                            </div>
                            <div class="form-row form-input-name-row">
                                <TheFormInputStandardVue label="Tên bộ phận sử dụng" disabled :forceInput="false" />
                            </div>
                            <div class="form-row form-input-name-row">
                                <TheFormInputStandardVue label="Tên loại tài sản" disabled :forceInput="false" />
                            </div>

                            <div class="clearfix">
                                <div class="sub-entry-3">
                                    <div class="main-content">
                                        <div class="form-row form-input-name-row">
                                            <TheFormInputNumberVue label="Nguyên giá" v-model="priceValueProperty" />
                                        </div>
                                        <div class="form-row form-input-name-row">
                                            <TheFormInputNumberVue
                                                label="Giá trị hao mòn năm"
                                                v-model="downValueProperty"
                                            />
                                        </div>
                                    </div>
                                    <div class="form-row form-input-name-row">
                                        <TheFormInputDateVue
                                            label="Ngày bắt đầu sử dụng"
                                            v-model="dateStartUsingProperty"
                                        />
                                    </div>
                                </div>
                                <div class="clearfix">
                                    <div class="sub-entry-4 margin-left">
                                        <div class="main-content">
                                            <div class="form-row form-input-name-row">
                                                <TheFormInputNumberVue
                                                    label="Số năm sử dụng"
                                                    v-model="yearUsedProperty"
                                                />
                                            </div>
                                            <div class="form-row form-input-name-row">
                                                <TheFormInputNumberVue
                                                    label="Năm theo dõi"
                                                    disabled
                                                    :forceInput="false"
                                                    v-model="yearFollow"
                                                />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="form__div--button">
                    <button type="button" class="button__background--cancel button" @click="showWarning('destroy')">
                        Hủy
                    </button>
                    <button type="button" class="button__background--save button" @click="createSuccessNoti">
                        Lưu
                    </button>
                </div>
            </form>
            <MISAWarningAlertVue v-if="typeWarning === 'destroy' && isShowWarning">
                <template v-slot:content-alert>{{
                    $MISAcommon.MISAresource.warning_content.popup_form.click_destroy
                }}</template>

                <template v-slot:outline-button>
                    <MISAStandardButtonVue class="button__background--outline" content="Không" @click="closeWarning" />
                </template>
                <template v-slot:save-button>
                    <MISAStandardButtonVue
                        class="button__background--save"
                        content="Hủy bỏ"
                        @click="
                            notificationStore.displayErrNoti(
                                $MISAcommon.MISAresource.notification_content.popup_form.error_noti,
                            )
                        "
                    />
                </template>
            </MISAWarningAlertVue>

            <MISAWarningAlertVue v-if="typeWarning === 'warning_unproper_input' && isShowWarning">
                <template v-slot:content-alert>{{
                    $MISAcommon.MISAresource.warning_content.popup_form.warning_unproper_input
                }}</template>

                <template v-slot:outline-button>
                    <MISAStandardButtonVue class="button__background--outline" content="Đóng" @click="closeWarning" />
                </template>
            </MISAWarningAlertVue>

            <MISAWarningAlertVue v-if="typeWarning === 'warning_down_percentage' && isShowWarning">
                <template v-slot:content-alert>{{
                    $MISAcommon.MISAresource.warning_content.popup_form.warning_down_percentage
                }}</template>

                <template v-slot:outline-button>
                    <MISAStandardButtonVue class="button__background--outline" content="Đóng" @click="closeWarning" />
                </template>
            </MISAWarningAlertVue>
        </div>
    </div>
</template>
<style>
@import url('@/css/main.css');
.form-input-name-row {
    position: relative;
}
</style>
