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
          <v-list-item v-for="item in items" :key="item.title" @click="item.action"  link >
            
            <v-list-item-icon   >
              <v-icon style="color:#fff">{{ item.icon }}</v-icon>
            </v-list-item-icon>

            <v-list-item-content  v-if="CompareRol(item.rol)">
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
      user: JSON.parse(localStorage.getItem('user')),
      drawer: false,
      group: null,
      items: [
        {
          title: "Dashboard",
          icon: "mdi-home",
          rol: ["Administrador", "Cliente", "Tailor"],
          action: this.goToDashboard,
        },
        {
          title: "Usuarios",
          icon: "mdi-office-building",
          rol: ["Administrador" ],
          action: this.goToUser,
        },        
        {
          title: "Citas",
          icon: "mdi-office-building",
          rol: ["Administrador" ,"Cliente", "Tailor"],
          action: this.goToSchedule,
        },
    
        { title: "Photos",
         icon: "mdi-image",
         rol: [ "Administrador","Cliente"],
         action: "adsasdasdb" 
         },
        { title: "About",
         icon: "mdi-help-box",
          action: "casdasdasdas", 
         rol: [ "Administrador","Cliente"],
         },
      ],
      messages: 1,
    };
  },
  methods:{
    
      filterMenu(){
        var items_ = Array();
        
        if(!this.user.authorized){
          this.items=items_;
        }else{
          this.items.forEach(element => {
          console.log(element);
            element.rol.forEach(x=>{
              if(x==this.user.user.rol.nombre){
               items_.push(element);
            }

            })

        })

        }
        
        console.log(items_);
        this.items=items_;
       return items_;
       
      },
      
      goToDashboard(){
        return this.$router.push("/");
      },
      goToUser(){
        return this.$router.push("/Users");
      },
      goToSchedule(){
        return this.$router.push("/Schedule");
      },
      CompareRol(data= Array){
        var authorized=new Boolean(false);
         authorized=false;
        if(this.user.user.rol == null){
            authorized=false;
        }else{
          data.forEach(element => {
            if(this.user.rol!==null){
            if(element==this.user.user.rol.nombre){
               authorized=true;
            }
            }
          });
        }
        return authorized;

      },
  },
   mounted() {
    this.user= JSON.parse(localStorage.getItem('user'));
    console.log(this.user);
    this.filterMenu();
  },
  created() {
    this.user= JSON.parse(localStorage.getItem('user'));
  }


}
</script>