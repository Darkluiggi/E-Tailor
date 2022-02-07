<template>
  <v-row align="center" class="list px-3 mx-auto">
    <v-col cols="12" md="8">
      <v-text-field v-model="userName" label="Buscar por nombre"></v-text-field>
    </v-col>

    <v-col cols="12" md="4">
      <v-btn small @click="searchTitle">
        Search
      </v-btn>
    </v-col>
    <v-btn text style="cursor: pointer" @click="AddUser()">
                <v-icon>mdi-plus</v-icon>
                <span>Agregar usuario</span>
    </v-btn>
        
            
        
    <v-col cols="12" sm="12">
      <v-card class="mx-auto" tile>
        <v-card-title>Usuarios</v-card-title>
        <v-spacer></v-spacer>
        
        <v-data-table
          :headers="headers"
          :items="users"
          disable-pagination
          :hide-default-footer="true"
        >
          <template v-slot:[`item.actions`]="{ item }">
            <v-icon small class="mr-2" @click="editUser(item.id)">mdi-pencil</v-icon>
            <v-icon small @click="deleteUser(item.id)">mdi-delete</v-icon>
          </template>
        </v-data-table>

        
      </v-card>
    </v-col>
  </v-row>
</template>

<script>
import UserDAS from "../../services/UserDAS";
export default {
  name: "UserIndex",
  data() {
    return {
      users: [],
      userName: "",
      headers: [
        { text: "Nombre", align: "start", sortable: false, value: "nombre" },
        { text: "Email", value: "email", sortable: false },
        { text: "Teléfono", value: "phoneNumber", sortable: false },
        { text: "Status", value: "status", sortable: false },
        { text: "Actions", value: "actions", sortable: false },
      ],
    };
  },
  methods: {
    retrieveList() {
      UserDAS.getAll()
        .then((response) => {
          this.users = response.data.map(this.getUser);
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
      UserDAS.findByName(this.userName)
        .then((response) => {
          this.users = response.data.map(this.getUser);
        })
        .catch((e) => {
          console.log(e);
        });
    },

    editUser(id) {
      this.$router.push({ name: "userDetails", params: { id: id } });
    },

    deleteUser(id) {
      UserDAS.delete(id)
        .then(() => {
          this.refreshList();
        })
        .catch((e) => {
          console.log(e);
        });
    },
    AddUser(){
      return this.$router.push("/AddUsers");
    },

    getUser(user) {
      console.log(user);
      return {
        id: user.id,
        nombre:  user.name,
        email: user.email,
        phoneNumber: user.phoneNumber,
        status: user.estado ? "Activo" : "Inactivo",
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
  margin: 3rem auto;
  display: flex;
  flex-direction: column;
  background: white;
  padding: 40px;
  box-shadow: 0 4px 10px 4px rgba(0, 0, 0, 0.3);
}
</style>
