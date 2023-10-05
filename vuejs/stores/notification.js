import { ref, computed } from 'vue'
import { defineStore } from 'pinia'

export const useNotificationStore = defineStore('notification', {

  // state của store
  state: () => {
    return {
      showNotificationError: false,
      showNotificationSuccess: false,
      showNotificationWarning: false,
      showNotificationInfo: false,
      message: ''
    }
  },

  // các actions có thể thay đổi state
  actions: {
    displayErrNoti(message) {
      this.showNotificationError = true
      this.message = message
      setTimeout(() => {
        this.showNotificationError = false
      }, 3000)
    },

    displaySuccessNoti(message) {
      this.showNotificationSuccess = true
      this.message = message
      setTimeout(() => {
        this.showNotificationSuccess = false
      }, 3000)

    },

    displayWarningNoti(message) {
      this.showNotificationWarning = true
      this.message = message
      setTimeout(() => {
        this.showNotificationWarning = false
      }, 3000)
    },

    displayInfoNoti(message) {
      this.showNotificationInfo = true
      this.message = message
      setTimeout(() => {
        this.showNotificationInfo = false
      }, 3000)
    }
  }

})
