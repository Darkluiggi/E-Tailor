<template>
  <div class="submit-form mt-3 mx-auto">

    <p class="headline">Inicia sesión</p>

    <p v-if="errors.length">
    <b>Por favor, corrija el(los) siguiente(s) error(es):</b>
    <ul>
      <li v-for="error in errors" :key="error" style="color:red;text-decoration: underline">{{ error }}</li>
    </ul>
    
    
  </p>
    <div>
      <v-form ref="form" >
        <v-text-field
          label="Correo Electronico"
          :rules="[(v) =>  /^\w+([.-]?\w+)*@\w+([.-]?\w+)*(\.\w{2,3})+$/.test(v) || 'Email must be valid']"
          v-model="user.email"
          required
        ></v-text-field>

        <v-text-field
          label="Password"
          :rules="[(v) => !!v || 'password is required']"
          v-model="user.password"
          required
        ></v-text-field>
      </v-form>

      <v-btn color="primary" class="mt-3" @click="checkForm">Entrar</v-btn>
      <div>
        ¿Aún no tienes una cuenta?
        <router-link :to="'Registration'">Regístrate aquí</router-link>
      </div>
    </div>

  </div>
 
  
</template>


<script>
import router from '../../router';
import AuthDAS from'../../services/AuthDAS';

export default ({
    name: "Login",
     data() {
    return {
      user: {
       email:"",
       password:""
      },
       errors:[]  
    };
  },
    methods: {
      
    checkForm() {
      if (this.user.email && this.user.password  ) {
        this.login();
      }

      this.errors = [];
      

      if (!this.user.email) {
        this.errors.push('El correo es obligatorio.');
      }
      if (!/^\w+([.-]?\w+)*@\w+([.-]?\w+)*(\.\w{2,3})+$/.test(this.user.email)) {
        this.errors.push('El correo debe ser válido.');
      }
      
      if (!this.user.password) {
        this.errors.push('La contraseña es obligatoria.');
      }

      
    },
      login(){
        var data = {
        password: this.user.password,
        email: this.user.email,
      };
       AuthDAS.login(data)
        .then((response) => {
          localStorage.user=JSON.stringify(response.data);
          var user_= JSON.parse(localStorage.getItem('user'));
          if(user_.message=="success"){
            router.push({ name: "Home2", params: { reload: true } });
          }
          else{        
             this.errors.push(user_.message);  
          }
                
          
          
        })
        .catch((e) => {
          console.log(e);
        });
      }
    },
})

</script>

<style>
.submit-form {
  max-width: 300px;
}
</style>


