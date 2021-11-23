<template>
<div >
   <v-btn text style="cursor: pointer" @click="Volver()">
                <v-icon>mdi-arrow-left-bold</v-icon>
                <span>Volver</span>
    </v-btn>
  <div class="submit-form mt-6 mx-auto">
    <p class="headline">Nuevo usuario</p>
    
    <div v-if="!submitted">
      
      <v-form ref="form" >
        <v-text-field
          v-model="user.name"
          :rules="[(v) => !!v || 'El nombre es requerido']"
          label="Nombre"
          required
        ></v-text-field>

        <v-text-field
          v-model="user.email"
          :rules="[(v) => v.length > 0 && /^\w+([.-]?\w+)*@\w+([.-]?\w+)*(\.\w{2,3})+$/.test(v) || 'el email debe ser válido']"
          label="Email"
          required
        ></v-text-field>

        <v-text-field
          v-model="user.password"
          type="password"
          :rules="[(v) => !!v || 'La contraseña es requerida']"
          label="Password"
          required
        ></v-text-field>

        <v-text-field
          v-model="user.phoneNumber"
          :rules="[(v) => !!v || 'El teléfono es requerido']"
          label="Número de teléfono"
          required
        ></v-text-field>
        <v-select :items="roles" item-text="nombre" item-value="id" 
        single-line auto v-model="user.idRol" label="Seleccionar rol"></v-select>
      </v-form>

      <v-btn color="primary" class="mt-3" @click="saveUser">Submit</v-btn>
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
</div>
</template>

<script>
import UserDAS from "../../services/UserDAS";
import RolDAS from "../../services/RolDAS";
import user from "../../Entity/User.js"

export default {
  name: "add-user",
  data() {
    return {
      user: {
        user
      },  
      roles: [],
      select: null,
      submitted: false,
    };
  },
  mounted(){
    this.getRoles();   
  },
  methods: {
    saveUser() {
      var data = {
        name: this.user.name,
        email: this.user.email,
        password: this.user.password,
        phoneNumber: this.user.phoneNumber,
        idRol: this.user.idRol,
      };
      
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
     Volver(){
      return this.$router.push("/Users");
    },
    getRoles(){
      RolDAS.getAll()
        .then((response) => {
          this.roles = response.data;
        })
        .catch((e) => {
          console.log(e);
        });
    }
  },
};
</script>

<style>
.submit-form {
  max-width: 300px;
}
</style>
