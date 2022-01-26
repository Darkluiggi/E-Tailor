<template> 
    <v-row align="center" class="list px-3 mx-auto">
        
        <v-col cols="12" sm="12">
        <v-card class="mx-auto" tile>
        <v-card-title>Citas</v-card-title>
        
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
    
</template>

<script>

import ScheduleDAS from "../../services/ScheduleDAS";
export default {
   data(){
     
   return {
   user: JSON.parse(localStorage.getItem('user')),
   todos:[],
    headers: [
        { text: "Cliente", value: "Customer", sortable: false },
        { text: "Tailor", value: "Tailor", sortable: false },
        { text: "Fecha", align: "start", sortable: false, value: "date" },
        { text: "Hora", value: "hour", sortable: false },
        { text: "Tipo", value: "Tipos", sortable: false },
        { text: "Genero", value: "Genero", sortable: false },
        { text: "Actions", value: "actions", sortable: false },
      ],
     }
   },
   mounted(){
     this.user= JSON.parse(localStorage.getItem('user'))
     this.getList()
   },

   methods: {
     getList(){  
      ScheduleDAS.GetStoreSchedule()
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
        
        console.log(appointment);
      return {
        id: appointment.id,
        date:  appointment.date.split('T')[0],        
        hour: appointment.hour.split('T')[1],
        tailorId: appointment.tailorId,
        Tailor: appointment.tailor.user.name,
        Tipos: appointment.serviceType,
        Genero: appointment.gender,
        Customer: appointment.customer.user.name,

      };
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


</style>