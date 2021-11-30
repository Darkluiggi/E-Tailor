import Vue from 'vue'
import App from './App.vue'
import vuetify from './plugins/vuetify'
import router from './router'
import Auth from './Entity/Auth'

Vue.config.productionTip = false;

Vue.prototype.$userLogged = Auth;

new Vue({
  router,
  vuetify,
  render: h => h(App)
}).$mount('#app')
