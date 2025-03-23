import { createRouter, createWebHistory } from 'vue-router'
import HomePage from '../pages/HomePage.vue'
import { useAuthStore } from '@/stores/auth'


const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: HomePage,
      meta: {
        auth: true
      },
      children: []
    },
    {
      path: '/login',
      name: 'login',
      component: () => import('../pages/LoginPage.vue'),
    },
    {
      path: '/register',
      name: 'register',
      component: () => import('../pages/RegisterPage.vue'),
    }
  ],
})
router.beforeEach((to, from, next) => {
  const authStore = useAuthStore()
  const auth = authStore.isAuth()

  if (to.meta.auth && !auth) {
    next('/login')

  }  else {
    next()
  }
})

export default router
