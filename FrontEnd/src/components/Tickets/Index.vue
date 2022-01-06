<template>
<v-row align="center" class="list px-3 mx-auto">
    <v-col cols="12" md="8">
      <v-text-field v-model="title" label="Search by Title"></v-text-field>
    </v-col>

    <v-col cols="12" md="4">
      <v-btn small @click="searchTitle">
        Search
      </v-btn>
    </v-col>
       
    <v-col cols="12" sm="12">
      <v-card class="mx-auto" tile>
        <v-card-title>Tickets</v-card-title>
        <v-spacer></v-spacer>
  
    <v-data-table
      :headers="headers"
      :items="tickets"
      :expanded.sync="expanded"
      item-key="id"
      show-expand
    >
      
      <template #expanded-item="{headers, item}"  > 
        <td :colspan="headers.length" >
          <v-simple-table >
           
                <thead>
                  <tr>
                    <th>Nombre</th>
                    <th>Icono</th>
                    <th>Precio</th>
                  </tr>
                </thead>
                <tbody>
                  <tr v-for="task in item.tasks" :key="task.id">
                    <td>{{ task.name }}</td>
                    <td><v-icon   v-text="task.icon"     ></v-icon></td>
                    <td>{{ task.price }}</td>
                  </tr>
                </tbody>
              </v-simple-table>
          </td>     
             
        
      </template>
       <template v-slot:[`item.actions`]="{ item }">
            <v-icon small class="mr-2" @click="editTicket(item.id)">mdi-clipboard-arrow-right-outline</v-icon>
            <v-icon small @click="deleteTicket(item.id)">mdi-delete</v-icon>
          </template>
    </v-data-table>
 </v-card>
    </v-col>
  </v-row>
</template>

<script>
import TicketDAS from "../../services/TicketDAS";
export default {
  name: "TicketsIndex",
  data () {
    return {
      expanded: [],
      singleExpand: false,
      title: "",
      user:{},
      tasks:[],
      headers: [
        { text: "Cliente", align: "start", sortable: false, value: "customer" },
        { text: "Tailor", value: "tailor" },
        {text: " Fecha de entrega", value: "deliveryDate" },
        { text: "Precio", value: "servicePrice"},
        { text: "Status", value: "status" },
        { text: "Actions", value: "actions" },
      ],
      tickets: [
      ],
    }
  },
  
  methods: {
    retrieveList() {
      TicketDAS.GetTicketsByTailor(this.user.user.id)
        .then((response) => {
          this.tickets = response.data.map(this.getTickets);
          console.log(this.tickets);
        })
        .catch((e) => {
          console.log(e);
        });
    },

    refreshList() {
      this.retrieveList();
    },

    
    searchTitle() {
      if(this.title==null){
        this.title=" ";
      }
      TicketDAS.findByName(this.title)
        .then((response) => {
         this.tickets = response.data.map(this.getTickets);
          console.log(response.data);
        })
        .catch((e) => {
          console.log(e);
        });
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
      };
    },
  },
  mounted() {
    this.retrieveList();
    this.user= JSON.parse(localStorage.getItem('user'));
    
  },
  created(){
    this.user= JSON.parse(localStorage.getItem('user'));
  }

}
</script>

<style>
.list {
  max-width: 750px;
}
</style>
