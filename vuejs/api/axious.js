// @ts-check
import axios from 'axios'

// @ts-ignore
axios.interceptors.request.use((request) => {
  //    const propertyStore = usePropertyStore()
  //   request.headers.Authorization = propertyStore.token
  //   console.log('Adding token to header', propertyStore.token)
})
axios.interceptors.response.use(null, error => {
  // Xử lý lỗi global
  return Promise.reject(error)
})

let requests = 0
axios.interceptors.request.use(config => {
  requests++
  // Hiển thị loading

  return config
})

axios.interceptors.response.use(res => {
  requests--
  // Ẩn loading khi request xong

  return res
})


axios.interceptors.response.use(
  res => res,
  err => {
    if (err.response.status === 401) {
      // Refresh token
    }
    return Promise.reject(err)
  }
)
