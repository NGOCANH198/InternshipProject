import { ref, computed } from 'vue'
import { defineStore } from 'pinia'

export const useCounterStore = defineStore('counter',  {
  id: 'main',

  // state của store
  state: () => {
    return {
      counter: 0
    }
  },

  // các actions có thể thay đổi state
  actions: {
    increment() {
      this.counter++
    }
  }

})
