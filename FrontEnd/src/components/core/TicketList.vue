<template> 
    <v-row align="center" class="list px-3 mx-auto">

     
        
      <v-col cols="12" sm="12">
      <v-card class="mx-auto" tile>
        <v-card-title>Mis Tickets</v-card-title>
        
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
import TicketDAS from "../../services/TicketDAS";
export default {
   data(){
     
   return {
   user: JSON.parse(localStorage.getItem('user')),
   todos:[],
    headers: [
       
        { text: "Precio", value: "servicePrice", sortable: false },
        { text: "Customer", value: "customerName" },
        {text:  "Tailor", value: "tailor" },
        { text: "Status", value: "status" },
        { text: "Actions", value: "actions" },
        { text: "Tasks", value: "tasks" },
        { text: "estado", value: "estado" },
       
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
      TicketDAS.GetTicketsByCostumer(id)
        .then((response) => {
          console.log(response.data)
          this.todos =  response.data.map(this.getTickets);
          this.submitted = true
            })
       .catch((e) => {
          console.log(e)
        });
       return this.todos
     },
    getTickets(ticket) {
      return {
        id: ticket.id,
        customer: ticket.customer.user.name, 
        tailor: ticket.tailor.user.name,
        deliveryDate:ticket.deliveryDate.split('T')[0],
        servicePrice:ticket.servicePrice,
        tasks: ticket.tasks,
        status: ticket.estado ? "Activo" : "Inactivo", 
      }
    },
    AddAppointment(){
       return this.$router.push("/AddSchedule");
    },
    
    deleteSchedule(id)
    {
      console.log(id);
      TicketDAS.delete(id)
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