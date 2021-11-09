import Vue from "vue";
import Router from "vue-router";
import Home from "./components/core/Home"

Vue.use(Router);

export default new Router({
  mode: "history",
  routes: [
    {
      path: "/",
      alias: "/home",
      name: "home",
      component: Home
    },
    {
      path: "/Users",
      alias: "/users",
      name: "users",
      component: () => import("./components/Users/Index")
    },
    {
      path: "/AddUser",
      alias: "/addUsers",
      name: "AddUsers",
      component: () => import("./components/Users/Add")
    },   
  ]
});
