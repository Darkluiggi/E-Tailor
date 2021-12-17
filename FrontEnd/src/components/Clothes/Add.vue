<template>
  <div class="submit-form mt-3 mx-auto">
    <p class="headline">Nueva prenda</p>

    <div v-if="!submitted">
      <v-form ref="form" >
        <v-text-field
          v-model="cloth.name"
          :rules="[(v) => !!v || 'Nombre is required']"
          label="Nombre"
          required
        ></v-text-field>
        <v-text-field
          v-model="cloth.gender"
          :rules="[(v) => !!v || 'Género is required']"
          label="Género"
          required
        ></v-text-field>

       
      </v-form>

      <v-btn color="primary" class="mt-3" @click="saveCloth">Submit</v-btn>
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
          <v-btn color="success" @click="newCloth">Add</v-btn>
        </v-card-actions>
      </v-card>
    </div>
  </div>
</template>

<script>
import ClothDAS from "../../services/ClothDAS";

export default {
  name: "add-user",
  data() {
    return {
      cloth:{
        name:'',
        gender:''
      },      
      submitted: false,
    };
  },

  methods: {
    saveCloth() {
      var data = {
        name: this.cloth.name,
        gender: this.cloth.gender,
      };
      console.log(data)
      ClothDAS.create(data)
        .then((response) => {
          this.user.id = response.data.id;
          console.log(response.data);
          this.submitted = true;
        })
        .catch((e) => {
          console.log(e);
        });
        this.$router.push("/Clothes");
    },

    newCloth() {
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
