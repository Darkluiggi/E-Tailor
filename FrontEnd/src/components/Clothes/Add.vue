<template>
  <div class="submit-form mt-3 mx-auto">
    <p class="headline">Nuevo rol</p>

    <div v-if="!submitted">
      <v-form ref="form" >
        <v-text-field
          v-model="rol.nombre"
          :rules="[(v) => !!v || 'Nombre is required']"
          label="Title"
          required
        ></v-text-field>

       
      </v-form>

      <v-btn color="primary" class="mt-3" @click="saveRol">Submit</v-btn>
    </div>

    <div v-else>
      <v-card class="mx-auto">
        <v-card-title>
          Submitted successfully!
        </v-card-title>

        <v-card-subtitle>
          Click the button to add new USer.
        </v-card-subtitle>

        <v-card-actions>
          <v-btn color="success" @click="newUser">Add</v-btn>
        </v-card-actions>
      </v-card>
    </div>
  </div>
</template>

<script>
import UserDAS from "../../services/UserDAS";

export default {
  name: "add-user",
  data() {
    return {
      rol:{
        nomre:'',
      },      
      submitted: false,
    };
  },

  methods: {
    saveRol() {
      var data = {
        nombre: this.rol.nombre,
      };
      console.log(data)
      UserDAS.create(data)
        .then((response) => {
          this.user.id = response.data.id;
          console.log(response.data);
          this.submitted = true;
        })
        .catch((e) => {
          console.log(e);
        });
    },

    newUser() {
      this.submitted = false;
      this.user = {};
    },
  },
};
</script>

<style>
.submit-form {
  max-width: 300px;
}
</style>
