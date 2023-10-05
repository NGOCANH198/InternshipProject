import {
    useNotificationStore
} from '@/stores/notification'
import {
    ref,
    computed
} from 'vue'
import {
    defineStore
} from 'pinia'
import {
    axiosInstance,
} from '@/services/api.js'
import $MISAcommon from '../helper/MISAcommon'
export const useApiCallStore = defineStore('api', {
    //state của store
    state: () => ({
        notification: useNotificationStore(),
    }),
    computed: () => {

    },
    // các actions có thể thay đổi state
    actions: {
        async callAPI(endpoint) {
            try {
                const response = await axiosInstance.get(endpoint)
                this.handleAPISuccess(response)
            } catch (error) {
                this.handleAPIError(error)
                throw error
            }
        },
        handleAPISuccess(res) {
            if (res.status === 200) {

                // Lấy dữ liệu thành công
                this.notification.displaySuccessNoti($MISAcommon.MISAresource.notification_content.error_status_code.code_200)
                return res.data
            } else if (res.status === 201) {
                // Post dữ liệu thành công
                this.notification.displaySuccessNoti($MISAcommon.MISAresource.notification_content.error_status_code.code_201)
                return res.data
            }
        },
        handleAPIError(error) {
            // Handle error
            if (error.response) {
                // Lỗi từ API
                handleServerError(error.response)
            } else {
                // Lỗi mạng, request không gửi được
                this.notification.displayErrNoti($MISAcommon.MISAresource.notification_content.error_status_code.network_error)

            }
        },
        handleServerError(error) {
            if (error.status === 400) {

                // Lỗi từ client – dữ liệu đầu vào không hợp lệ.
                this.notificationStore.displayErrNoti($MISAcommon.MISAresource.notification_content.error_status_code.code_400)
            } else if (error.status === 401) {

                //Lỗi từ client - hông tin xác thực không hợp lệ
                this.notificationStore.displayErrNoti($MISAcommon.MISAresource.notification_content.error_status_code.code_401)
            } else if (error.status === 403) {

                //Không tin xác thực không hợp lệ
                this.notificationStore.displayErrNoti($MISAcommon.MISAresource.notification_content.error_status_code.code_403)
            }
            else if (error.status === 404) {

                //Không tìm thấy địa chỉ hoặc tài nguyên
                this.notificationStore.displayErrNoti($MISAcommon.MISAresource.notification_content.error_status_code.code_404)
            }
            else if (error.status === 500) {

                //Lỗi từ back-end.
                this.notificationStore.displayErrNoti($MISAcommon.MISAresource.notification_content.error_status_code.code_500)
            } else {

                //Có lỗi từ máy chủ!'
                this.notificationStore.displayErrNoti($MISAcommon.MISAresource.notification_content.error_status_code.server_error)
            }
        }
    }
})
