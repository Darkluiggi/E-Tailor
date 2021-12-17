<template> 
    <div> 
    <p class="headline">Mis Citas</p>
    <table>
      
      </table>
   <tbody>
     <tr v-for="todo in todos" :key="todo.id">
     <td>{{todo.date}}</td>
     <td>{{todo.tailorId}}</td>
     <td>{{todo.Tipos}}</td>
     <td>{{todo.Genero}}</td>
     </tr>
   </tbody>


    </div>
    
 
</template>

<script>

import ScheduleDAS from "../../services/ScheduleDAS";
export default {
   data(){
     
   return {
   user: JSON.parse(localStorage.getItem('user')),
   todos:null,
     }
   },
   mounted(){
     this.user= JSON.parse(localStorage.getItem('user'));
     this.getList(this.user.user.id);
   },

   methods: {
     getList(id){
     
      console.log(this.user.id);
      console.log(this.user.name);
      ScheduleDAS.GetAppointmentByCustomer(id)
        .then((response) => {
                         console.log(response.data);
                         this.todos = response.data;
            })
       .catch((e) => {
          console.log(e);
        });
       return this.todos;
     },

   }

   }
   

</script>

<style>

</style>