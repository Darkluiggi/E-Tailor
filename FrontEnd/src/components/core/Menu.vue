<template>
  <div>
    <v-app-bar color="#191919" dark x-small>
      <v-app-bar-nav-icon
        @click.stop="drawer = !drawer"
      
      ></v-app-bar-nav-icon>
      <div class="d-flex align-center" style="cursor: pointer"> 
      <label class="text-h5">
                E-Tailor
             </label>
      </div>
      <v-spacer></v-spacer>
      
      
      <HeaderBarLinks></HeaderBarLinks>
    </v-app-bar>

    <v-navigation-drawer
     
      v-model="drawer"
      absolute
      top
      temporary
      src="https://i.pinimg.com/originals/2a/c5/8c/2ac58ca3c5e1d553148f12ba1d7a38e8.jpg"
    >
    <v-list>
        <v-list-item class="px-2">
          
        </v-list-item>

        <v-list-item link  >
          <v-list-item-content>
            <v-list-item-title class="text-h5" style="color:#fff">
                E-Tailor
             </v-list-item-title
            >
            <v-list-item-title class="text-h6" style="color:#fff" >
              </v-list-item-title
            >
            <v-list-item-subtitle >
              </v-list-item-subtitle
            >
          </v-list-item-content>
        </v-list-item>
      </v-list>

      <v-divider></v-divider>
      <v-list nav dense>
        <v-list-item-group
          v-model="group"
          active-class="deep-purple--text text--accent-4" 
        >
          <v-list-item v-for="item in items" :key="item.title" @click="item.action"  link>
            <v-list-item-icon >
              <v-icon style="color:#fff">{{ item.icon }}</v-icon>
            </v-list-item-icon>

            <v-list-item-content>
              <v-list-item-title style="color:#fff">{{ item.title }}</v-list-item-title>
            </v-list-item-content>
          </v-list-item>
        </v-list-item-group>
      </v-list>
      <template v-slot:append>
        <div class="pa-2">
          <v-btn class="mx-2" fab dark small color="red">
            <v-icon dark> mdi-power </v-icon>
          </v-btn>
          <v-btn class="mx-2" fab dark small color="orange">
            <v-icon dark> mdi-cog-outline </v-icon>
          </v-btn>
        </div>
      </template>
     
    </v-navigation-drawer>
  </div>
</template>

<script>
import HeaderBarLinks from "./HeaderBarLinks";

export default {
    
    name:'Menu',
    components: {
        HeaderBarLinks,
  },
     data() {
    return {
      drawer: false,
      group: null,
      items: [
        {
          title: "Dashboard",
          icon: "mdi-home",
          action: this.goToDashboard,
        },
        {
          title: "Usuarios",
          icon: "mdi-office-building",
          action: this.goToUser,
        },
        // {
        //   title: "Catalogo",
        //   icon: "mdi-office-building",
        //   action: this.goToCatalogo,
        // },
        // {
        //   title: "Inventario",
        //   icon: "mdi-office-building",
        //   action: this.goToInventario,
        // },
        { title: "Photos", icon: "mdi-image", action: "adsasdasdb" },
        { title: "About", icon: "mdi-help-box", action: "casdasdasdas" },
      ],
      messages: 1,
    };
  },
  methods:{
      goToDashboard(){
        return this.$router.push("/");
      },
      goToUser(){
        return this.$router.push("/Users");
      },
      
  }


}
</script>