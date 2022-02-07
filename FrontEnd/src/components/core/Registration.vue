<template>
<body>
  <div class="submit-form mt-3 mx-auto">
    <p class="headline">Nuevo usuario</p>

    <div v-if="!submitted">
      <v-form ref="form" >
        <p v-if="errors.length">
    <b>Por favor, corrija el(los) siguiente(s) error(es):</b>
    <ul>
      <li v-for="error in errors" :key="error" style="color:red;text-decoration: underline">{{ error }}</li>
    </ul>
  </p>
        
        <v-text-field
          v-model="user.name"
          :rules="[(v) => !!v || 'Nombre is required']"
          label="Nombre"
          required
        ></v-text-field>

        <v-text-field
          v-model="user.email"
          :rules="[(v) =>  /^\w+([.-]?\w+)*@\w+([.-]?\w+)*(\.\w{2,3})+$/.test(v) || 'Email must be valid']"
          label="Correo Electronico"
          required
        ></v-text-field>

        <v-text-field
          v-model="user.password"
          :rules="[(v) => !!v || 'password is required']"
          label="Password"
          required
        ></v-text-field>

        <v-text-field
          v-model="user.phoneNumber"
          :rules="[(v) => !!v || 'phone is required']"
          label="Telefono Celular"
         
        ></v-text-field>
      </v-form>

      <v-btn color="primary" class="mt-3" @click="checkForm">Submit</v-btn>
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
</body>
</template>

<script>
import UserDAS from "../../services/UserDAS";
import RolDAS from "../../services/RolDAS";
import user from "../../Entity/User.js"

export default {
  name: "add-user",
  data() {
    return {
      user:{
        user
      },   
      errors:[],   
      submitted: false,
    };
  },

  methods: {
    checkForm() {
      if (this.user.email && this.user.password && this.user.name ) {
        this.saveUser();
      }

      this.errors = [];
       if (!this.user.name) {
        this.errors.push('El nombre es obligatorio.');
      }

      if (!this.user.email) {
        this.errors.push('El correo es obligatorio.');
      }
      if (!this.user.password) {
        this.errors.push('La contraseña es obligatoria.');
      }

      
    },
    saveUser() {
      var Rol = "Cliente";
     
        RolDAS.GetByName(Rol).then((response) => {
        console.log(response);
          var data = {
        name: this.user.name,
        email: this.user.email,
        password: this.user.password,
        phoneNumber: this.user.phoneNumber,
        idRol: response.data.id ,
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
        })
        .catch((e) => {
          console.log(e);
        });
      this.$router.push({ name: "Home2", params: { reload: true } });
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
  margin: 3rem auto;
  display: flex;
  flex-direction: column;
  background:white;
  padding: 40px;
  box-shadow: 0 4px 10px 4px rgba(0, 0, 0, 0.3);
}

</style>
