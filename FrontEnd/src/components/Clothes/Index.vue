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
    <v-btn text style="cursor: pointer" @click="AddRol()">
                <v-icon>mdi-plus</v-icon>
                <span>Agregar Rol</span>
    </v-btn>
        
            
        
    <v-col cols="12" sm="12">
      <v-card class="mx-auto" tile>
        <v-card-title>Roles</v-card-title>
        <v-spacer></v-spacer>
        
        <v-data-table
          :headers="headers"
          :items="roles"
          disable-pagination
          :hide-default-footer="true"
        >
          <template v-slot:[`item.actions`]="{ item }">
            <v-icon small class="mr-2" @click="editRol(item.id)">mdi-pencil</v-icon>
            <v-icon small @click="deleteRol(item.id)">mdi-delete</v-icon>
          </template>
        </v-data-table>

      
      </v-card>
    </v-col>
  </v-row>
</template>

<script>
import RolDAS from "../../services/RolDAS";
export default {
  name: "UserIndex",
  data() {
    return {
      roles: [],
      title: "",
      headers: [
        { text: "Nombre", align: "start", sortable: false, value: "nombre" },
        { text: "Status", value: "status", sortable: false },
        { text: "Actions", value: "actions", sortable: false },
      ],
    };
  },
  methods: {
    retrieveList() {
      RolDAS.getAll()
        .then((response) => {
          console.log(response.data);
          this.roles = response.data.map(this.getRoles);
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
      RolDAS.findByTitle(this.title)
        .then((response) => {
          this.tutorials = response.data.map(this.getRoles);
          console.log(response.data);
        })
        .catch((e) => {
          console.log(e);
        });
    },

    editRol(id) {
      this.$router.push({ name: "userDetails", params: { id: id } });
    },

    deleteRol(id) {
      RolDAS.delete(id)
        .then(() => {
          this.refreshList();
        })
        .catch((e) => {
          console.log(e);
        });
    },
    AddRol(){
      return this.$router.push("/AddRol");
    },

    getRoles(rol) {
      return {
        id: rol.id,
        nombre: rol.nombre, 
        status: rol.estado ? "Activo" : "Inactivo", 
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
