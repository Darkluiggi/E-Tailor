
<template>
<body>

  <div class="container">
    
    <div class="section content-title-group">
      <h2 class="title" v-if="!this.user.authorized">Bienvenido a su plataforma E-Tailor</h2>
      <h2 class="title" v-else>Bienvenido {{this.user.user.name}}</h2>
      <p> Aquí puedes gestionar todas tus citas</p>
    </div>
    <div >
      <div class="level">
        <div class="level-item title">
        
        </div>
      </div>
      <div class="level">
        <div class="level-item">
          <ul>
           
          </ul>
        </div>
      </div>
    </div>
   
  </div>
  </body>

</template>

<script>


export default {
    name: "Home",
    
   mounted() {
    this.user= JSON.parse(localStorage.getItem('user'));
     
    if(this.$route.params.reload){
      this.$router.go();
    }
  },

  data() {
    return {
      user: JSON.parse(localStorage.getItem('user')),  
    };
  },
     
};
</script>
<style>
body {
    height: 800px;
  background-image: url("https://i.ibb.co/5MStcBH/frente-azul-largo.jpg");
  background-size: cover;

  background-repeat: no-repeat;
  background-position: center center;
  background-attachment: fixed;

}
</style>