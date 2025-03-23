<script setup>
import { ref } from 'vue'
import { useRouter } from 'vue-router'

import Card from 'primevue/card'
import Button from 'primevue/button'
import InputGroup from 'primevue/inputgroup'
import InputGroupAddon from 'primevue/inputgroupaddon'
import InputText from 'primevue/inputtext'
import Password from 'primevue/password'
import Message from 'primevue/message'

import api from '@/api'

const login = ref('')
const password = ref('')

const error = ref(false)
const errorMessage = ref('')

const router = useRouter()

function noerr() {
  error.value = false
  errorMessage.value = ''
}

async function register() {
  if (!login.value || !password.value) {
    error.value = true
    errorMessage.value = 'Заполните все обязательные поля'
    return
  }

  try {
    await api.postNewUser(login.value, password.value)
    router.push('/login')
  } catch (err) {
    console.error('Ошибка регистрации:', err)
    error.value = true
    errorMessage.value = 'Ошибка при регистрации'
  }
}
</script>

<template>
  <div class="flex justify-content-center pt-7">
    <div>
      <Card class="w-30rem">
        <template #title>Регистрация пользователя</template>
        
        <template #content>
          <InputGroup class="mb-2">
            <InputGroupAddon>
              <i class="pi pi-user-edit"></i>
            </InputGroupAddon>
            <InputText
              v-model="login"
              placeholder="Логин"
              @input="noerr"
            />
          </InputGroup>
          <InputGroup>
            <InputGroupAddon>
              <i class="pi pi-key"></i>
            </InputGroupAddon>
            <Password
              v-model="password"
              placeholder="Пароль"
              @input="noerr"
              toggleMask
            />
          </InputGroup>
        </template>

        <template #footer>
          <Button
            style="color: black;"
            class="w-full"
            label="Регистрация"
            @click="register"
          />
          <Message
            v-if="error"
            class="m-0 mt-3 p-2"
            severity="error"
            :closable="false"
          >
            {{ errorMessage }}
          </Message>
        </template>
      </Card>
    </div>
  </div>
</template>

<style scoped>
.w-30rem {
  width: 30rem;
}
</style>
