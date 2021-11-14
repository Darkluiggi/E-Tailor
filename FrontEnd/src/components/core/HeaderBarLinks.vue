<template>
  <div class="container-fluid">
    <div class="row">
      <v-container>
        <div>
          <v-btn
            x-small   
            target="_blank"
            rel="noopener noreferrer"
            text
            @click="goToLog()"
          >
            <span>Ingresar</span>
          </v-btn>
          <v-btn
            x-small   
            target="_blank"
            rel="noopener noreferrer"
            text
            @click="goToRegistration()"
          >
            <span>Registrarse</span>
          </v-btn>
          
        </div>
      </v-container>
    </div>
  </div>
</template>




<script>


export default {
    name: "HeaderBarLinks",
    methods:{
        signIn(){},
        goToRegistration(){
        return this.$router.push("/Registration");
    },
        goToLog(){
        return this.$router.push("/Login");
    },

        signOut(){}
    },
  data: () => ({
    //
  }), 
     
};
</script>
