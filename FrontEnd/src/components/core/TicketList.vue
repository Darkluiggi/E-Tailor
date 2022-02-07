<template> 
<div class="containter container-center" >
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
            <v-icon small class="mr-2" @click="viewTicket(item.id)">mdi-magnify</v-icon>           
          </template>



        <template v-slot:[`item.tasks`]="{ item }">
           <div class="row">
           <div style="margin:3px" v-for="task in item.tasks" :key="task.id">             
                 <span class="post-tag">
                  <i style="color: white; font-size:15px"  :class="'v-icon notranslate v-icon--left mdi '+ task.icon +' theme--light'"></i> 
                  <label>{{task.name}}</label>
               </span>
              </div>
                       
            </div>
         
          </template>

        </v-data-table>
      </v-card>
      </v-col>

    </v-row>
    </div>
 
</template>

<script>
import TicketDAS from "../../services/TicketDAS";
export default {
   data(){
     
   return {
   user: JSON.parse(localStorage.getItem('user')),
   todos:[],
   tasks:[],
    headers: [
       
        {text:  "Clothing", value: "clotheType" , sortable: false},
        {text:  "Tailor", value: "tailor", width: "10%"},
        { text: "Tasks", value: "tasks", width: "30%" },
        { text: "Precio", value: "servicePrice",width: "10%" },
        { text: "Status", value: "status" },
        { text: "Actions", value: "actions" },
       
      ],
     }
   },
   mounted(){
     this.user= JSON.parse(localStorage.getItem('user'))
     this.getList(this.user.user.id)
  
   },
   methods: {
     getList(id){    
      TicketDAS.GetTicketsByCustomer(id)
        .then((response) => {
          this.todos =  response.data.map(this.getTickets);
           console.log(this.todos);
          this.submitted = true
            })
       .catch((e) => {
          console.log(e)
        });
       return this.todos
     },
    getTickets(ticket) {
      console.log(ticket);
      return {
        id: ticket.id,
        tailor: ticket.tailor.user.name,
        deliveryDate:ticket.deliveryDate.split('T')[0],
        servicePrice:ticket.servicePrice,
        clotheType: ticket.clotheType,
        tasks: ticket.tasks,
        status: ticket.status,
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

.post-tag{
 
border-radius: 20px;
background-color:cadetblue;
padding:5px;
margin-right:3px;
margin-top:50px;
color:white;

}
.container-center{
  margin-left: 150px;
  margin-right: auto;
  width:80%;
  position:flex;
  display: inline-block;
  
}

</style>