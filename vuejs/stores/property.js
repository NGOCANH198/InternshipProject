import { ref, computed } from 'vue'
import { defineStore } from 'pinia'
export const usePropertyStore = defineStore('property', {
  id: 'propertyStateController',

  // state của store
  state: () => {
    return {
      name: 'Le Huy Hai Anh',
      propertyInforList: [
        {
          checked: false,
          stt: 1,
          maTaiSan: 'MXT88618',
          tenTaiSan: 'Máy tính xách tay Fujitsu',
          loaiTaiSan: 'Máy vi tính xách tay',
          donViSuDung: 'Phòng Hành chính Kế toán',
          soLuong: 1,
          nguyenGia: 10000000,
          haoMon: 1225000,
          giaTriConLai: 8775000
        },
        {
          checked: false,
          stt: 2,
          maTaiSan: '37H7WN72/2022',
          tenTaiSan: 'Dell Inspiron 3467',
          loaiTaiSan: 'Máy vi tính xách tay',
          donViSuDung: 'Phòng Hành chính Kế toán',
          soLuong: 1,
          nguyenGia: 40000000,
          haoMon: 1730000,
          giaTriConLai: 38270000
        },
        {
          checked: false,
          stt: 3,
          maTaiSan: 'MXT8866',
          tenTaiSan: 'Máy tính xách tay Fujitsu',
          loaiTaiSan: 'Máy vi tính xách tay',
          donViSuDung: 'Phòng Hành chính Kế toán',
          soLuong: 1,
          nguyenGia: 5000000,
          haoMon: 1646000,
          giaTriConLai: 3354000
        }
      ]
    }
  },

  // các actions có thể thay đổi state
  actions: {
    callApi() {

    },
    addProperty(property) {
      this.propertyInforList.push(property)
    },
    deleteProperty(stt) {
      this.propertyInforList = this.propertyInforList.filter(p => {
        return p.stt != stt
      })

    },
  }
})
