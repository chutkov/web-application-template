import axios from 'axios'
import { useRouter } from 'vue-router'
import { useAuthStore } from "@/stores/auth"

const axiosClient = axios.create({
  baseURL: '/api',
  timeout: 100000,
  headers: {
    'Accept': 'application/json',
    'Content-Type': 'application/json'
  }
})

axiosClient.interceptors.request.use((config) => {
  const headers = config.headers
  const token = useAuthStore().getToken()

  headers.Authorization = token ? `Bearer ${token}` : ''
  return config
})

axiosClient.interceptors.response.use((response) =>
  response, (error) => {
    if (error.response && error.response.status === 401) {
      useAuthStore().clear()
      useRouter().push('/login')
    } else {
      return Promise.reject(error);
    }
  })

export default {

  getInfo: async () => {
    const response = await axiosClient.get('/')
    return String(response.data)
  },

  login: async (userName, password) => {
    const response = await axiosClient.post(
      `/login/${userName}`, JSON.stringify(password))
    return response.data
  },

  register: async (login, password) => {
    const response = await axiosClient.post("/register",
      {
        params:
        {
          login: login,
          password: password
        }
      }
    )
    return response.data
  },

}
