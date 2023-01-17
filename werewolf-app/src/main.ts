import { createApp } from 'vue'
import naive from "naive-ui"
import router from "./router"
import { createPinia } from 'pinia'
import App from './App.vue'

const app = createApp(App)
const pinia = createPinia()

app.use(pinia)
app.use(naive)
app.use(router)

app.mount("#app")
