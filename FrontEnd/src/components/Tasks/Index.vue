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
    <v-btn text style="cursor: pointer" @click="AddTask()">
                <v-icon>mdi-plus</v-icon>
                <span>Agregar tarea</span>
    </v-btn>
        
            
        
    <v-col cols="12" sm="12">
      <v-card class="mx-auto" tile>
        <v-card-title>Tareas</v-card-title>
        <v-spacer></v-spacer>
        
        <v-data-table
          :headers="headers"
          :items="tasks"
          disable-pagination
          :hide-default-footer="true"
        >
          <template v-slot:[`item.actions`]="{ item }">
            <v-icon small class="mr-2" @click="editTask(item.id)">mdi-pencil</v-icon>
            <v-icon small @click="deleteTask(item.id)">mdi-delete</v-icon>
          </template>
        </v-data-table>

      
      </v-card>
    </v-col>
  </v-row>
</template>

<script>
import TaskDAS from "../../services/TaskDAS";
export default {
  name: "TaskIndex",
  data() {
    return {
      tasks: [],
      title: "",
      headers: [
        { text: "Nombre", align: "start", sortable: false, value: "nombre" },
        { text: "Precio", value: "price", sortable: false },
        { text: "Status", value: "status", sortable: false },
        { text: "Actions", value: "actions", sortable: false },
      ],
    };
  },
  methods: {
    retrieveList() {
      TaskDAS.getAll()
        .then((response) => {
          console.log(response.data);
          this.tasks = response.data.map(this.getTasks);
          console.log(response.data);
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
      TaskDAS.findByName(this.title)
        .then((response) => {
         this.tasks = response.data.map(this.getTasks);
          console.log(response.data);
        })
        .catch((e) => {
          console.log(e);
        });
    },

    editTask(id) {
      this.$router.push({ name: "userDetails", params: { id: id } });
    },

    deleteTask(id) {
      TaskDAS.delete(id)
        .then(() => {
          this.refreshList();
        })
        .catch((e) => {
          console.log(e);
        });
    },
    AddTask(){
      return this.$router.push("/AddTask");
    },

    getTasks(task) {
      return {
        id: task.id,
        nombre: task.name, 
        price:task.price,
        status: task.estado ? "Activo" : "Inactivo", 
      };
    },
  },
  mounted() {
    this.retrieveList();
  },
};
</script>

<style>
.list {
  max-width: 750px;
}
</style>
