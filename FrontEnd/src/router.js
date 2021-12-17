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
      path: "/",
      alias: "/home",
      name: "Home2",
      props: {reload: false},
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
    {
      path: "/Registration",
      alias: "/Registration",
      name: "Registration",
      component: () => import("./components/core/Registration")
    }, 
    {
      path: "/ScheduleList",
      alias: "/ScheduleList",
      name: "ScheduleList",
      component: () => import("./components/core/ScheduleList")
    },  
    
    {
      path: "/Login",
      alias: "/Login",
      name: "Login",
      component: () => import("./components/core/Login")
    }, 
    {
      path: "/Schedule",
      alias: "/Schedule",
      name: "Schedule",
      component: () => import("./components/core/Schedule")
    },
  ]
});
