<template>
  <div class="container-fluid">
    <div class="row">
      <v-container>
        <div>
           <v-btn
            x-small              
            v-if="!this.user.authorized"
            text
            @click="goToSchedule()"
          >
            <span>Citas</span>
          </v-btn>
          <v-btn
            x-small
            v-if="!this.user.authorized"
            @click="goToLog()"
            text
          >
            <span>Ingresar</span>
          </v-btn>
           <v-btn
            x-small              
            v-if="!this.user.authorized"
            text
            @click="goToRegistration()"
          >
            <span>Registrarse</span>
          </v-btn>

          <v-card-actions v-if="this.user.authorized">
            <v-menu auto offset-y>
              <template v-slot:activator="{ on }">
                <v-btn
                  color="blue"
                  x-small
                  dark
                  fab
                  v-on="on"
                  v-on:click.prevent
                >
                  <v-icon dark> mdi-account-circle </v-icon>
                </v-btn>
              </template>
              <v-list>
                <v-list-item>
                  <v-list-item-icon>
                    <v-icon> mdi-account </v-icon>
                  </v-list-item-icon>
                  <v-list-item-content>
                    <v-list-item-title>{{ this.user.user.name }}</v-list-item-title>
                  </v-list-item-content>
                </v-list-item>
                <v-list-item>
                  <v-list-item-icon>
                    <button @click="signOut()">
                      <v-icon> mdi-logout </v-icon>
                    </button>
                  </v-list-item-icon>
                  <v-list-item-content>
                    <button @click="signOut()">Cerrar sesión</button>
                  </v-list-item-content>
                </v-list-item>
              </v-list>
            </v-menu>
          </v-card-actions>

        </div>
      </v-container>
    </div>
  </div>
</template>












<script>

import router from '../../router';
import User from "../../Entity/Auth.js"

export default {
    name: "HeaderBarLinks",
    methods:{
        goToRegistration(){
        return router.push("/Registration");
    },
        goToLog(){
        return router.push("/Login");
    }, 
        goToSchedule(){
        return this.$router.push("/Schedule");
      },


        signOut(){
        var user = new User();
         localStorage.user=JSON.stringify(user);
         router.go();
         router.push({ name: "Home2", params: { reload: true } });
        
        }
    },
   mounted() {
    this.user= JSON.parse(localStorage.getItem('user'));
    
  },

  data() {
    return {
      user: JSON.parse(localStorage.getItem('user')),  
    };
  },
     
};
</script>
