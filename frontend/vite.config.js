import { fileURLToPath, URL } from 'node:url'

import { defineConfig } from 'vite'
import vue from '@vitejs/plugin-vue'

import { env } from 'process'
const target = env.CORP_API_URI ?? 'http://localhost:5002'

export default defineConfig({
  plugins: [
    vue()
  ],
  resolve: {
    alias: {
      '@': fileURLToPath(new URL('./src', import.meta.url))
    },
  },
  server: {
    open: '/',
    proxy: {
      '/api': {
          target: target,
          changeOrigin: true,
          rewrite: (path) => path.replace(/^\/api/, ''),
          secure: false
      }
  }
  }
})
