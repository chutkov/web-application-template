<script setup>
import { ref } from 'vue'
import { RouterLink, useRouter } from 'vue-router'
import '../style.css'

import Card from 'primevue/card'
import Button from 'primevue/button'
import InputGroup from 'primevue/inputgroup'
import InputGroupAddon from 'primevue/inputgroupaddon'
import InputText from 'primevue/inputtext'
import Message from 'primevue/message'

import { useAuthStore } from '@/stores/auth'
import api from '@/api'

const authStore = useAuthStore()
const router = useRouter()

const userName = ref(null)
const password = ref(null)
const error = ref(false)

async function login() {
  if (!userName.value || !password.value) {
    error.value = true
    return
  }

  try {
    const token = await api.login(
      userName.value, password.value)

    authStore.setToken(token)
    error.value = false

    router.push('/')
  } catch (err) {
    console.log(err)
    error.value = true
  }
}

function noerr() {
  error.value = false
}
</script>

<template>
    <div style="display: flex; justify-content: center; height: 100vh;">

        <div style="max-width: 600px; margin: auto; ">
          <div>
            <Card class="w-30rem">
              <template #title>Вход в личный кабинет</template>
              <template #content class="content">
                  <InputGroup class="mb-2">
                    <InputGroupAddon>
                      <i class="pi pi-user"></i>
                    </InputGroupAddon>
                    <InputText placeholder="Имя пользователя" v-model="userName" @input="noerr" />
                  </InputGroup>
                  <InputGroup>
                    <InputGroupAddon>
                      <i class="pi pi-key"></i>
                    </InputGroupAddon>
                    <InputText type="password" placeholder="Пароль" v-model="password" @input="noerr" />
                  </InputGroup>
              </template>
              <template #footer>
                <Button style="color: black;" class="w-full" label="Вход" @click="login"></Button>
                <Message v-if="error" class="m-0 mt-3 p-2" severity="error" :closable="false">Ошибка входа</Message>
              </template>
            </Card>
            <RouterLink :to="{path: '/register'}">
              <Button label="Регистрация" link></Button>
            </RouterLink>
          </div>
        </div>
    </div>
</template>
