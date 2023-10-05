// import { callAPI, axiosInstance}from "./api";
// import TokenService from "./token.service";

// const setup = (store) => {
//     // @ts-ignore
//     axiosInstance.interceptors.request.use((request) => {
//     //    const propertyStore = usePropertyStore()
//     //   request.headers.Authorization = propertyStore.token
//     //   console.log('Adding token to header', propertyStore.token)
//     })
//     axiosInstance.interceptors.response.use(null, error => {
//         // Xử lý lỗi global
//         return Promise.reject(error)
//       })

//     let requests = 0
//     axiosInstance.interceptors.request.use(config => {
//       requests++
//       // Hiển thị loading

//       return config
//     })

//     axiosInstance.interceptors.response.use(res => {
//       requests--
//       // Ẩn loading khi request xong

//       return res
//     })

// };

// export default setup;
