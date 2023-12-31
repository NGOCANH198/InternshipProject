const MISAresource = {
    notification_class: {
        success: {
            iconClass1: 'success',
            iconClass2: 'fa-check'
        },
        info: {
            iconClass1: 'info',
            iconClass2: 'fa-info'
        },
        warning: {
            iconClass1: 'warning',
            iconClass2: 'fa-exclamation'
        },
        danger: {
            iconClass1: 'danger',
            iconClass2: 'fa-exclamation'
        }
    },

    warning_content: {
        popup_form: {
            click_destroy: "Bạn có muốn hủy bỏ khai báo tài sản này?",
            warning_unproper_input: "Hao mòn năm phải nhỏ hơn hoặc bằng nguyên giá",
            warning_down_percentage: "Tỷ lệ hao mòn phải bằng 1 /Số năm sử dụng"
        },
        main_content_delete_record: {
            delete_one: 'Bạn có muốn xóa tài sản <<Mã - Tên tài sản>> ?',
            delete_multiple: 'tài sản đã được chọn. Bạn có muốn xóa các tài sản này khỏi danh sách?',
            delete_one_exception: 'Không thể xóa tài sản này vì đã có chứng từ phát sinh',
            delete_multiple_exception: '02 tài sản đã chọn không thể xóa. Vui lòng kiểm tra lại tài sản trước khi xóa',
        },
    },



    notification_content: {
        popup_form: {
            error_noti: "Có lỗi này",
            success_noti: "Lưu dữ liệu thành công",
        },
        error_status_code: {
            code_200: 'Lấy dữ liệu thành công',
            code_201: 'Post dữ liệu thành công',
            code_400: 'Lỗi từ client – dữ liệu đầu vào không hợp lệ.',
            code_401: 'Lỗi từ client - hông tin xác thực không hợp lệ',
            code_403: 'Không tin xác thực không hợp lệ',
            code_404: 'Không tìm thấy địa chỉ hoặc tài nguyên ',
            code_500: 'Lỗi từ back-end.',
            network_error: 'Lỗi mạng không gửi được',
            server_error: 'Lỗi server rồi'
        }
    }
}

export default MISAresource
