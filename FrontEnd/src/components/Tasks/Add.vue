<template>
  <div class="submit-form mt-3 mx-auto">
    <p class="headline">Nueva tarea</p>

    <div v-if="!submitted">
      <v-form ref="form" >
        <v-text-field
          v-model="task.nombre"
          :rules="[(v) => !!v || 'Nombre is required']"
          label="Title"
          required
        ></v-text-field>
        <v-text-field
          v-model="task.precio"
          :rules="[(v) => !!v || 'Nombre is required']"
          label="Title"
          required
        ></v-text-field>
       
      </v-form>

      <v-btn color="primary" class="mt-3" @click="saveTask">Submit</v-btn>
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
</template>

<script>
import TaskDAS from "../../services/TaskDAS";

export default {
  name: "add-task",
  data() {
    return {
      task:{
        nombre:'',
        precio:'',
      },      
      submitted: false,
    };
  },

  methods: {
    saveTask() {
      var data = {
        nombre: this.rol.nombre,
      };
      console.log(data)
      TaskDAS.create(data)
        .then((response) => {
          this.user.id = response.data.id;
          console.log(response.data);
          this.submitted = true;
        })
        .catch((e) => {
          console.log(e);
        });
    },

  
  },
};
</script>

<style>
.submit-form {
  max-width: 300px;
}
</style>
