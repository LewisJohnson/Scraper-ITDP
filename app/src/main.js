import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import axios from 'axios'
import VueAxios from 'vue-axios'

createApp(App)
	.use(router) // VueJS Router
	.use(VueAxios,
		axios.create(
			{
				baseURL: 'http://localhost:3000/api/'
			}
		)
	) // Ajax request to .NET API
	.mount('#app')