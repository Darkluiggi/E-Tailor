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
      path: "/Roles",
      name: "roles",
      component: () => import("./components/Rols/Index")
    },
    {
      path: "/AddRol",
      name: "addRol",
      component: () => import("./components/Rols/Add")
    },
    
    {
      path: "/Clothes",
      name: "clothes",
      component: () => import("./components/Clothes/Index")
    },
    
    {
      path: "/Tasks",
      name: "tasks",
      component: () => import("./components/Tasks/Index")
    },
    {
      path: "/AddTask",
      name: "addTask",
      component: () => import("./components/Tasks/Add")
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
      path: "/WorkSchedule",
      alias: "/WorkSchedule",
      name: "WorkSchedule",
      component: () => import("./components/core/WorkSchedule")
    },  
    
    {
      path: "/Login",
      alias: "/Login",
      name: "Login",
      component: () => import("./components/core/Login")
    }, 
    {
      path: "/AddSchedule",
      name: "Schedule",
      component: () => import("./components/core/Schedule")
    },
  ]
});
