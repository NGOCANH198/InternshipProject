import axios from "axios";
import useLoading from "./loading";
const loading = useLoading()
const axiosInstance = axios.create({
  baseURL: "https://cukcuk.manhnv.net/api/",
  // headers: {
  //   "Content-Type": "application/json",
  // },
});

axiosInstance.interceptors.request.use(config => {
  // Show loading overlay
  console.log('chay donng 15')
  loading.showLoading()
  console.log(loading.isLoading.value);

  return config
})

axiosInstance.interceptors.response.use(response => {
  // Hide loading overlay
  loading.hideLoading()

  return response
})
export { axiosInstance };
