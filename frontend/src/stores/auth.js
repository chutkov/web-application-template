import { ref } from 'vue'
import { defineStore } from 'pinia'

const localStoreKey = 'authToken'

export const useAuthStore = defineStore('auth', () => {
  const token = ref({
    jwt: '',
    userId: '',
    userName: ''
  })

  const localStoreLoad = () => {
    const json = localStorage.getItem(localStoreKey)
    if (json) {
      token.value = JSON.parse(json)
    }
  }
  localStoreLoad()

  const localStoreSave = () => {
    localStorage.setItem(localStoreKey, JSON.stringify(token.value))
  }

  const isAuth = () => token.value.jwt !== ''

  const getToken = () => isAuth() ? token.value.jwt : null

  const setToken = (value) => {
    if (value) {
      token.value = value
      localStoreSave()
    } else {
      clear()
    }
  }

  const clear = () => {
    token.value = { jwt: '', userId: '', userName: '' }
    localStorage.removeItem(localStoreKey)
  }

  return {
    token,
    isAuth,
    getToken,
    setToken,
    clear
  }
})
