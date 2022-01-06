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
      name: "users",
      component: () => import("./components/Users/Index")
    },
    {
      path: "/AddUser",
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
    },{
      path: "/AddCloth",
      name: "addCloth",
      component: () => import("./components/Clothes/Add")
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
      name: "Registration",
      component: () => import("./components/core/Registration")
    }, 
    {
      path: "/ScheduleList",
      name: "ScheduleList",
      component: () => import("./components/core/ScheduleList")
    },  
    {
      path: "/WorkSchedule",
      name: "WorkSchedule",
      component: () => import("./components/core/WorkSchedule")
    },  
    
    {
      path: "/Login",
      name: "Login",
      component: () => import("./components/core/Login")
    }, 
    {
      path: "/AddSchedule",
      name: "Schedule",
      component: () => import("./components/core/Schedule")
    },
    {
      path: "/Appointment",
      name: "Appointment",
      component: () => import("./components/core/Appointment")
    },
    {
      path: "/WorkerTickets",
      name: "WorkerTickets",
      component: () => import("./components/Tickets/Index")
    },
  ]
});
