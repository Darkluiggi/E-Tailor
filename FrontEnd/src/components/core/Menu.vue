<template>
<div>
  <div>
    <v-app-bar color="#191919" dark x-small>
      <v-app-bar-nav-icon
        @click.stop="drawer = !drawer"
      
      ></v-app-bar-nav-icon>
      <div class="d-flex align-center" style="cursor: pointer"> 
      <label class="text-h5">
                E-Tailor
             </label>
      </div>
      <v-spacer></v-spacer>
       
      
      <HeaderBarLinks></HeaderBarLinks>
    </v-app-bar>

    <v-navigation-drawer
     
      v-model="drawer"
      absolute
      top
      temporary
      src="https://i.pinimg.com/originals/2a/c5/8c/2ac58ca3c5e1d553148f12ba1d7a38e8.jpg"
    >
    <v-list>
        <v-list-item class="px-2">
          
        </v-list-item>

        <v-list-item link  >
          <v-list-item-content>
            <v-list-item-title class="text-h5" style="color:#fff">
                E-Tailor
             </v-list-item-title
            >
            <v-list-item-title class="text-h6" style="color:#fff" >
              </v-list-item-title
            >
            <v-list-item-subtitle >
              </v-list-item-subtitle
            >
          </v-list-item-content>
        </v-list-item>
      </v-list>

      <v-divider></v-divider>
      <v-list nav dense>
        <v-list-item-group
          v-model="group"
          active-class="deep-purple--text text--accent-4" 
        >
          <v-list-item v-for="item in items" :key="item.title" @click="item.action"  link >
            
            <v-list-item-icon   >
              <v-icon style="color:#fff">{{ item.icon }}</v-icon>
            </v-list-item-icon>

            <v-list-item-content  v-if="CompareRol(item.rol)">
              <v-list-item-title style="color:#fff">{{ item.title }}</v-list-item-title>
              
            </v-list-item-content>
          </v-list-item>
        </v-list-item-group>
      </v-list>
      <template v-slot:append>
        <div class="pa-2">
          <v-btn class="mx-2" fab dark small color="red">
            <v-icon dark> mdi-power </v-icon>
          </v-btn>
          <v-btn class="mx-2" fab dark small color="orange">
            <v-icon dark> mdi-cog-outline </v-icon>
          </v-btn>
        </div>
      </template>
     
    </v-navigation-drawer>

  </div>
    
<div class="modal-backdrop" v-show="modal">
    <div class="modal">
      <header class="modal-header">
        <slot name="header">
          La siguiente cita está por comenzar
        </slot>
        <button
          type="button"
          class="btn-close"
          @click="close"
        >
          x
        </button>
      </header>

      <section class="modal-body">
        <slot name="body">
         <v-data-table
          :headers="headers"
          :items="todos"
          disable-pagination
          :hide-default-footer="true"
        >
          <template v-slot:[`item.actions`]="{ item }">
            <v-icon small class="mr-2" @click="attendSchedule(item.id)">mdi-calendar-arrow-right</v-icon>
            <v-icon small @click="deleteUser(item.id)">mdi-delete</v-icon>
          </template>
        </v-data-table>
        </slot>
       </section>

      
    </div>
  </div>

</div>









</template>

<script>
import HeaderBarLinks from "./HeaderBarLinks";
import ScheduleDAS from "../../services/ScheduleDAS";
export default {
    
    name:'Menu',
    components: {
        HeaderBarLinks,
  },
     data() {
    return {
      user: JSON.parse(localStorage.getItem('user')),
      drawer: false,
      group: null,
      modal:false, 
      inProcess:false, 
      appointmentList:[],
      todos:[],
      headers: [
        { text: "Fecha", align: "start", sortable: false, value: "date" },
        { text: "Hora", value: "hour", sortable: false },
        { text: "Tipo", value: "Tipos", sortable: false },
        { text: "Genero", value: "Genero", sortable: false },
        { text: "Actions", value: "actions", sortable: false },
      ],
      items: [
        {
          title: "Dashboard",
          icon: "mdi-home",
          rol: ["Administrador", "Cliente", "Tailor"],
          action: this.goToDashboard,
        },
        {
          title: "Usuarios",
          icon: "mdi-office-building",
          rol: ["Administrador" ],
          action: this.goToUsers,
        },  
        {
          title: "Roles",
          icon: "mdi-office-building",
          rol: ["Administrador" ],
          action: this.goToRoles,
        },  
        {
          title: "Prendas",
          icon: "mdi-office-building",
          rol: ["Administrador" ],
          action: this.goToClothes,
        },  
        {
          title: "Tareas",
          icon: "mdi-office-building",
          rol: ["Administrador" ],
          action: this.goToTasks,
        },        
        {
          title: "Citas",
          icon: "mdi-office-building",
          rol: ["Cliente"],
          action: this.goToSchedule,
        },
        {
          title: "Horario de trabajo",
          icon: "mdi-office-building",
          rol: [ "Tailor"],
          action: this.goToWorkerSchedule,
        },
        {
          title: "Tickets",
          icon: "mdi-office-building",
          rol: [ "Tailor"],
          action: this.goToWorkerTickets,
        },
    
        { title: "Photos",
         icon: "mdi-image",
         rol: [ "Administrador","Cliente"],
         action: "adsasdasdb" 
         },
        { title: "About",
         icon: "mdi-help-box",
          action: "casdasdasdas", 
         rol: [ "Administrador","Cliente"],
         },
      ],
      messages: 1,
    };
  },
  methods:{
    close() {
        this.modal = false;
      },
      showModal() {
        this.modal = true;
      },
      closeModal() {
        this.modal = false;
      },
    
      filterMenu(){
        var items_ = Array();
        
        if(!this.user.authorized){
          this.items=items_;
        }else{
          this.items.forEach(element => {
         
            element.rol.forEach(x=>{
              if(x==this.user.user.rol.nombre){
               items_.push(element);
            }

            })

        })

        }
        this.items=items_;
       return items_;
       
      },
      getAppointment(appointment) {
      return {
        id: appointment.id,
        date:  appointment.date.split('T')[0],        
        hour: appointment.hour.split('T')[1],
        tailorId: appointment.tailorId,
        Tipos: appointment.serviceType,
        Genero: appointment.gender,
              }
      },
      goToDashboard(){
        return this.$router.push("/");
      },
      goToRoles(){
        return this.$router.push("/Roles");
      },
      goToUsers(){
        return this.$router.push("/Users");
      },
      goToClothes(){
        return this.$router.push("/Clothes");
      },
      goToTasks(){
        return this.$router.push("/Tasks");
      },
      goToSchedule(){
        return this.$router.push("/ScheduleList");
      },      
      goToWorkerSchedule(){
        return this.$router.push("/WorkSchedule");
      },
      goToWorkerTickets(){
        return this.$router.push("/WorkerTickets");
      },
      getList(id){    
      ScheduleDAS.getAppointmentsByTailor(id)
        .then((response) => {
          this.appointmentList =  response.data.map(this.getAppointment);
          this.submitted = true
            })
       .catch((e) => {
          console.log(e)
        });
       return this.appointmentList
     },
     attendSchedule(id){
        ScheduleDAS.getAppointmentById(id).then((response) => {
          console.log(response);
          this.inProcess=true;
          this.$router.push({ name: "Appointment", params: { data: response.data } });
          this.modal=false;
            })
       .catch((e) => {
          console.log(e)
        });
      },
      CompareRol(data= Array){
        var authorized=new Boolean(false);
         authorized=false;
        if(this.user.user.rol == null){
            authorized=false;
        }else{
          data.forEach(element => {
            if(this.user.rol!==null){
            if(element==this.user.user.rol.nombre){
               authorized=true;
            }
            }
          });
        }
        return authorized;

      },
  },
   mounted() {
   
    this.user= JSON.parse(localStorage.getItem('user'));
   console.log(this.user.user);
    this.filterMenu();
    window.setInterval(() => {
      if(this.user.user.rol.nombre=="Tailor"){
      this.appointmentList = this.getList(this.user.user.id);
       
      }
      }, 300000);
   
    window.setInterval(() => {
     
       if(this.user.user.rol.nombre=="Tailor"){    
        if(!this.inProcess)
        {
var today = new Date();
         
          this.appointmentList.forEach(element => {   
              var fechaCita= element.date.split('-');
              var horaCita =element.hour.split(':');
             
              if(fechaCita[0]==today.getFullYear())
              {
                   if(fechaCita[1]==today.getMonth()+1)
                   {
                       if(fechaCita[2]==today.getDate())
                          {
                            if((horaCita[0]-today.getHours())<=1 && (horaCita[0]-today.getHours())>0)                              
                            {                

                              if((today.getMinutes()-horaCita[1])>=30 && (today.getMinutes()-horaCita[1])<= 60)
                              {
                               if(this.todos.length==0)
                                 {
                                   this.todos.push(element);
                                   this.modal=true;
                                   
                               
                                  }
                              }
                            }
                            
                            if((horaCita[0]-today.getHours())==0)                              
                            {
                            
                             if((horaCita[1]-today.getMinutes())<=30 && (horaCita[1]-today.getMinutes())>=0 )
                              {
                                 this.modal=true;
                               if(this.todos.length==0)
                                 {
                                  this.todos.push(element);
                           
                               
                                  }
                              }
                            }
                            
                          }
                    }
              }
          
         
          });
        }
          
       }
      }, 3000);
     
  },
  created() {
    this.user= JSON.parse(localStorage.getItem('user'));
    
    if(this.user.user.rol.nombre=="Tailor"){
     this.appointmentList = this.getList(this.user.user.id);
    }
    
  }

}
</script>

<style>
  .modal-backdrop {
    position: fixed;
    top: 0;
    bottom: 0;
    left: 0;
    right: 0;
    background-color: rgba(0, 0, 0, 0.3);
    display: flex;
    justify-content: center;
    align-items: center;
    
  }

  .modal {
    background: #FFFFFF;
    width: 500px;
    height: 250px;
    box-shadow: 2px 2px 20px 1px;
    overflow-x: auto;
  }

  .modal-header,
  .modal-footer {
    padding: 15px;
    display: flex;
  }

  .modal-header {
    position: relative;
    border-bottom: 1px solid #eeeeee;
    color: #4AAE9B;
    justify-content: space-between;
  }

  .modal-footer {
    border-top: 1px solid #eeeeee;
    flex-direction: column;
    justify-content: flex-end;
  }

  .modal-body {
    position: relative;
    padding: 20px 10px;
  }

  .btn-close {
    position: absolute;
    top: 0;
    right: 0;
    border: none;
    font-size: 20px;
    padding: 10px;
    cursor: pointer;
    font-weight: bold;
    color: #4AAE9B;
    background: transparent;
  }

  .btn-green {
    color: white;
    background: #4AAE9B;
    border: 1px solid #4AAE9B;
    border-radius: 2px;
  }
</style>