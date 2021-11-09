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

        <v-card-actions v-if="users.length > 0">
          <v-btn small color="error" @click="removeAllTutorials">
            Remove All
          </v-btn>
        </v-card-actions>
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
      users: [],
      title: "",
      headers: [
        { text: "Title", align: "start", sortable: false, value: "title" },
        { text: "Description", value: "description", sortable: false },
        { text: "Status", value: "status", sortable: false },
        { text: "Actions", value: "actions", sortable: false },
      ],
    };
  },
  methods: {
    retrieveList() {
      RolDAS.getAll()
        .then((response) => {
          this.tutorials = response.data.map(this.getDisplayTutorial);
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
          this.tutorials = response.data.map(this.getDisplayTutorial);
          console.log(response.data);
        })
        .catch((e) => {
          console.log(e);
        });
    },

    editUser(id) {
      this.$router.push({ name: "userDetails", params: { id: id } });
    },

    deleteUser(id) {
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

    getUser(user) {
      return {
        id: user.id,
        title: user.title.length > 30 ? user.title.substr(0, 30) + "..." : user.title,
        description: user.description.length > 30 ? user.description.substr(0, 30) + "..." : user.description,
        status: user.published ? "Published" : "Pending",
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
