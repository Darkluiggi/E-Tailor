<template>
  <div class="submit-form mt-3 mx-auto">

    <p class="headline">Inicia sesión</p>

    <div>
      <v-form ref="login_form" >
        <v-text-field
          label="Correo Electronico"
          v-model="user.email"
          required
        ></v-text-field>

        <v-text-field
          label="Password"
          v-model="user.password"
          required
        ></v-text-field>
      </v-form>

      <v-btn color="primary" class="mt-3" @click="login">Entrar</v-btn>
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
    };
  },
    methods: {
      login(){
        var data = {
        password: this.user.password,
        email: this.user.email,
      };
       AuthDAS.login(data)
        .then((response) => {
          localStorage.user=JSON.stringify(response.data);
                
          router.push({ name: "Home2", params: { reload: true } });
          
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


