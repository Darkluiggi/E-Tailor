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
          >
            <span>Ingresar</span>
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

        signOut(){}
    },
  data: () => ({
    //
  }),
};
</script>
