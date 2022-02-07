<template> 
<div class="container-center">
    <v-row align="center" class="list px-3 mx-auto">

       <v-btn text style="cursor: pointer" @click="AddAppointment()">
                <v-icon>mdi-plus</v-icon>
                <span>Agregar cita</span>
    </v-btn>
        
      <v-col cols="12" sm="12">
      <v-card class="mx-auto" tile>
        <v-card-title>Mis Citas</v-card-title>
        
    <v-data-table
          :headers="headers"
          :items="todos"
          disable-pagination
          :hide-default-footer="true"
        >
          <template v-slot:[`item.actions`]="{ item }">
            <v-icon small class="mr-2" @click="editUser(item.id)">mdi-pencil</v-icon>
            <v-icon small @click="deleteSchedule(item.id)">mdi-delete</v-icon>
          </template>
        </v-data-table>
      </v-card>
      </v-col>

    </v-row>
    </div>
 
</template>

<script>

import ScheduleDAS from "../../services/ScheduleDAS";
export default {
   data(){
     
   return {
   user: JSON.parse(localStorage.getItem('user')),
   todos:[],
    headers: [
        { text: "Fecha", align: "start", sortable: false, value: "date" },
        { text: "Hora", value: "hour", sortable: false },
        { text: "Tipo", value: "Tipos", sortable: false },
        { text: "Genero", value: "Genero", sortable: false },
        { text: "Actions", value: "actions", sortable: false },
      ],
     }
   },
   mounted(){
     console.log(this.user.id)
     console.log(this.user.name)
     this.user= JSON.parse(localStorage.getItem('user'))
     this.getList(this.user.user.id)
   },

   methods: {
     getList(id){    
      ScheduleDAS.getAppointmentsByCustomer(id)
        .then((response) => {
          console.log(response.data)
          this.todos =  response.data.map(this.getAppointment);
          this.submitted = true
            })
       .catch((e) => {
          console.log(e)
        });
       return this.todos
     },
      getAppointment(appointment) {
      return {
        id: appointment.id,
        date:  appointment.date.split('T')[0],        
        hour: appointment.hour.split('T')[1],
        tailorId: appointment.tailorId,
        Tipos: appointment.serviceType,
        Genero: appointment.gender,

      };
    },
    AddAppointment(){
       return this.$router.push("/AddSchedule");
    },
    
    deleteSchedule(id)
    {
      console.log(id);
      ScheduleDAS.delete(id)
      .then((response) => {
          console.log(response.data)
         this.getList();
            })
       .catch((e) => {
          console.log(e)
        });
    }

   }

   }
   

</script>

<style>
table {
  font-family: arial, sans-serif;
  border-collapse: collapse;
  width: 100%;
}

td, th {
  border: 1px solid #dddddd;
  text-align: left;
  padding: 8px;
}

tr:nth-child(even) {
  background-color: #dddddd;
}

.container-center{
  margin-left: 150px;
  margin-right: auto;
  width:80%;
  position:flex;
  display: inline-block;
  
}

</style>