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
    <v-btn text style="cursor: pointer" @click="AddCloth()">
                <v-icon>mdi-plus</v-icon>
                <span>Agregar prenda</span>
    </v-btn>
        
            
        
    <v-col cols="12" sm="12">
      <v-card class="mx-auto" tile>
        <v-card-title>Prendas</v-card-title>
        <v-spacer></v-spacer>
        
        <v-data-table
          :headers="headers"
          :items="clothes"
          disable-pagination
          :hide-default-footer="true"
        >
          <template v-slot:[`item.actions`]="{ item }">
            <v-icon small class="mr-2" @click="editCloth(item.id)">mdi-pencil</v-icon>
            <v-icon small @click="deleteCloth(item.id)">mdi-delete</v-icon>
          </template>
        </v-data-table>

      
      </v-card>
    </v-col>
  </v-row>
</template>

<script>
import ClothDAS from "../../services/ClothDAS";
export default {
  name: "ClothesIndex",
  data() {
    return {
      clothes: [],
      title: "",
      headers: [
        { text: "Nombre", align: "start", sortable: false, value: "nombre" },
        { text: "Género", value: "genero", sortable: false },
        { text: "Status", value: "status", sortable: false },
        { text: "Actions", value: "actions", sortable: false },
      ],
    };
  },
  methods: {
    retrieveList() {
      ClothDAS.getAll()
        .then((response) => {
          console.log(response.data);
          this.clothes = response.data.map(this.getClothes);
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
      ClothDAS.findByName(this.title)
        .then((response) => {
          this.clothes = response.data.map(this.getClothes);
          console.log(response.data);
        })
        .catch((e) => {
          console.log(e);
        });
    },

    editCloth(id) {
      this.$router.push({ name: "userDetails", params: { id: id } });
    },

    deleteCloth(id) {
      ClothDAS.delete(id)
        .then(() => {
          this.refreshList();
        })
        .catch((e) => {
          console.log(e);
        });
    },
    AddCloth(){
      return this.$router.push("/AddCloth");
    },

    getClothes(cloth) {
      return {
        id: cloth.id,
        nombre: cloth.name, 
        genero: cloth.gender,
        status: cloth.estado ? "Activo" : "Inactivo", 
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
  border-radius: 10px;
  padding: 40px;
  box-shadow: 0 4px 10px 4px rgba(0, 0, 0, 0.3);
}
</style>
