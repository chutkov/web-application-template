import { createApp } from 'vue';
import PrimeVue from 'primevue/config';
import Aura from '@primeuix/themes/aura';                 
import { createPinia } from 'pinia'
import router from './router';
import  App from './App.vue';

import './style.css'
import 'primeicons/primeicons.css'
import 'primeflex/primeflex.css'

const app = createApp(App);
app.use(PrimeVue, {
    theme: {
        preset: Aura,
        options: {
            prefix: 'p',
            darkModeSelector: '.my-app-dark',
            cssLayer: false
        }
    }
}); 
app.use(router)
app.use(createPinia())
app.mount("#app")