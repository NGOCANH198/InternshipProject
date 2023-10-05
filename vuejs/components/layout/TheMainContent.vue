<script setup>
import MISASInputStandardVue from '../base/input/MISAInputStandard.vue';
import MISAInputWithIconVue from '../base/input/MISAInputWithIcon.vue';
import MISAWarningAlertVue from '../base/MISAWarningAlert.vue';
import MISAStandardButtonVue from '../base/button/MISAStandardButton.vue';
import { ref, watch, onMounted, onUpdated, computed } from 'vue';
import { usePropertyStore } from '../../stores/property.js';
import { useApiCallStore } from '../../stores/error-handling.js';
import $MISAcommon from '../../helper/MISAcommon';
const apiCallStore = useApiCallStore();
const propertyStore = usePropertyStore();

const props = defineProps(['isShowPopup']);
const emits = defineEmits(['update:isShowPopup']);
const checkAll = ref(false);
const keyRefs = ref([]);
const focusRow = ref(1);
const countDeleteRecord = ref(0);
/**
 * Quản lý waring popup
 */
const isShowWarning = ref(false);
const typeWarning = ref('');
const dataLocal = computed({
    get() {
        return propertyStore.propertyInforList;
    },
    set(val) {},
});
/**
 * Chức năng: Test call api của anh Mạnh
 * @param {*} number
 * @returns không
 * Author: lhhanh (21/08/2023)
 */
apiCallStore.callAPI('v1/CustomerGroupss');

/**
 * Chức năng: Select và deselect bản ghi
 * @param {*} number
 * @returns không
 * Author: lhhanh (21/08/2023)
 */
function toggleCheckAll() {
    dataLocal.value.forEach((item) => {
        item.checked = checkAll.value;
    });
}

/**
 * Chức năng: Tham chiếu đến đối tượng bản ghi và xác bản ghi nào đang được focus
 * @param {*} number
 * @returns không
 * Author: lhhanh (21/08/2023)
 */
const setKeyRef = (el) => {
    keyRefs.value.push(el);
};

function checkKey(index, stt) {
    const key = keyRefs.value[index].__vnode.key;
    focusRow.value = key;
}
// Hết chức năng trên

watch(checkAll, () => {
    toggleCheckAll();
});

/**
 * Chức năng: Xóa các bản ghi được lựa chọn
 * @param {*} number
 * @returns không
 * Author: lhhanh (21/08/2023)
 */
function deleteSelectedItem() {
    dataLocal.value.forEach((item) => {
        if (item.checked == true) {
            propertyStore.deleteProperty(item.stt);
        }
    });
    isShowWarning.value = false;
}

/**
 * Chức năng: Hiển thị
 * @param {*} number
 * @returns không
 * Author: lhhanh (21/08/2023)
 */
function onHover(stt) {
    focusRow.value = stt;
}

/**
 * Chức năng: Xóa các bản ghi được lựa chọn
 * @param {*} number
 * @returns không
 * Author: lhhanh (21/08/2023)
 */
function onLeave(stt) {
    focusRow.value = 0;
}

/**
 * Chức năng: Mở warning
 * @param {*}
 * @returns không
 * Author: lhhanh (24/08/2023)
 */
function showWarning(type) {
    isShowWarning.value = true;

    dataLocal.value.forEach((item) => {
        if (item.checked == true) {
            countDeleteRecord.value++;
        }
    });
    if (countDeleteRecord.value == 1) {
        typeWarning.value = 'delete_one';
    } else if (countDeleteRecord.value > 1) {
        typeWarning.value = 'delete_multiple';
    }
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
                    <div class="square-36-36 button-one-icon" @click="showWarning">
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
    <div class="container">
        <table id="demo" class="table table-bordered table-striped">
            <thead>
                <tr>
                    <th>
                        <input type="checkbox" class="checkbox" v-model="checkAll" @change="toggleCheckAll" />
                    </th>
                    <th title="Số thứ tự">STT</th>
                    <th>Mã tài sản</th>
                    <th>Tên tài sản</th>
                    <th>Loại tài sản</th>
                    <th>Bộ phận sử dụng</th>
                    <th>Số lượng</th>
                    <th>Nguyên giá</th>
                    <th title="Hao mòn / Khấu hao lũy kế">HM/KH lũy kế</th>
                    <th>Giá trị còn lại</th>
                    <th>Chức năng</th>
                </tr>
            </thead>
            <tbody>
                <tr
                    v-for="(item, index) in dataLocal"
                    :ref="setKeyRef"
                    @click="checkKey(index, item.stt)"
                    :key="item.stt"
                    @mouseover="onHover(item.stt)"
                    @mouseleave="onLeave(item.stt)"
                >
                    <td><input type="checkbox" class="checkbox" v-model="item.checked" /></td>
                    <td>{{ item.stt }}</td>
                    <td>{{ item.maTaiSan }}</td>
                    <td>{{ item.tenTaiSan }}</td>
                    <td>{{ item.loaiTaiSan }}</td>
                    <td>{{ item.donViSuDung }}</td>
                    <td>{{ item.soLuong }}</td>
                    <td>{{ item.nguyenGia }}</td>
                    <td>{{ item.haoMon }}</td>
                    <td>{{ item.giaTriConLai }}</td>
                    <td>
                        <div class="center-all-items" v-if="focusRow === item.stt">
                            <div class="wrapper-dropdown">
                                <div class="position-relative">
                                    <div class="square-24-24" id="myButton" @click="$emit('update:isShowPopup', true)">
                                        <span class="sprite-edit sprite-center"></span>
                                    </div>
                                </div>
                            </div>
                            <div class="wrapper-dropdown">
                                <div class="position-relative">
                                    <div class="square-24-24">
                                        <span class="sprite-copy sprite-center"></span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                        <div class="table-footer">
                            <nav class="data-pagination">
                                <span>Tổng số: <span class="bold">200</span> bản ghi </span>
                                <div class="wrapper-dropdown pagination__margin--30px">
                                    <div class="position-relative">
                                        <div class="rectangle-25-59 center-2-items">
                                            <span class="">20</span>
                                            <span class="sprite-down-arrow"></span>
                                        </div>
                                    </div>
                                </div>
                                <a href="#" class="wrapper-dropdown pagination__margin--20px">
                                    <span class="sprite-left-arrow"></span>
                                </a>
                                <ul class="">
                                    <li class="current"><a href="#1">1</a></li>
                                    <li><a href="#2">2</a></li>
                                    <li><a href="#10">…</a></li>
                                    <li><a href="#10">10</a></li>
                                </ul>

                                <a href="#" class="wrapper-dropdown">
                                    <span class="sprite-right-arrow"></span>
                                </a>
                            </nav>
                        </div>
                    </td>
                    <td class="bold text__align--right">13</td>
                    <td class="bold text__align--right">249.000.000</td>
                    <td class="bold text__align--right">19.716.000</td>
                    <td class="bold text__align--right">229.284.000</td>
                    <td></td>
                </tr>
            </tbody>
        </table>
        <MISAWarningAlertVue v-if="typeWarning === 'delete_one' && isShowWarning">
            <template v-slot:content-alert>{{
                $MISAcommon.MISAresource.warning_content.main_content_delete_record.delete_one
            }}</template>

            <template v-slot:outline-button>
                <MISAStandardButtonVue class="button__background--outline" content="Không" @click="closeWarning" />
            </template>
            <template v-slot:save-button>
                <MISAStandardButtonVue class="button__background--save" content="Xóa" @click="deleteSelectedItem" />
            </template>
        </MISAWarningAlertVue>

        <MISAWarningAlertVue v-if="typeWarning === 'delete_multiple' && isShowWarning">
            <template v-slot:content-alert>
                {{ countDeleteRecord < 10 ? '0' + countDeleteRecord : countDeleteRecord }}
                {{ $MISAcommon.MISAresource.warning_content.main_content_delete_record.delete_multiple }}</template
            >

            <template v-slot:outline-button>
                <MISAStandardButtonVue class="button__background--outline" content="Không" @click="closeWarning" />
            </template>
            <template v-slot:save-button>
                <MISAStandardButtonVue class="button__background--save" content="Xóa" @click="deleteSelectedItem" />
            </template>
        </MISAWarningAlertVue>

        <MISAWarningAlertVue v-if="typeWarning === 'delete_one_exception' && isShowWarning">
            <template v-slot:content-alert>{{
                $MISAcommon.MISAresource.warning_content.main_content_delete_record.delete_one_exception
            }}</template>

            <template v-slot:outline-button>
                <MISAStandardButtonVue class="button__background--outline" content="Đóng" @click="closeWarning" />
            </template>
        </MISAWarningAlertVue>
        <MISAWarningAlertVue v-if="typeWarning === 'delete_multiple_exception' && isShowWarning">
            <template v-slot:content-alert>{{
                $MISAcommon.MISAresource.warning_content.main_content_delete_record.delete_multiple_exception
            }}</template>

            <template v-slot:outline-button>
                <MISAStandardButtonVue class="button__background--outline" content="Đóng" @click="closeWarning" />
            </template>
        </MISAWarningAlertVue>
    </div>
</template>
<style>
@import url('@/css/main.css');
</style>
