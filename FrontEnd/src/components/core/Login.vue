<template>
  <div class="submit-form mt-3 mx-auto">

    <p class="headline">Inicia sesión</p>

    <div>
      <v-form ref="login_form" >
        <v-text-field
          label="Correo Electronico"
          required
        ></v-text-field>

        <v-text-field
          label="Password"
          required
        ></v-text-field>
      </v-form>

      <v-btn color="primary" class="mt-3" >Entrar</v-btn>
      <div>
        ¿Aún no tienes una cuenta?
        <router-link :to="'Registration'">Regístrate aquí</router-link>
      </div>
    </div>

  </div>
 
  
</template>


<script>

export default ({
    name: "Login"
})

</script>

<style>
.submit-form {
  max-width: 300px;
}
</style>


