<template>

    <v-container class = "schedule">
        <p class="headline">Agendar Cita</p>

        <v-menu
            ref="menu"
            v-model="menu"
            :close-on-content-click="false"
            transition="scale-transition"
            offset-y
            min-width="auto"
        >
            <template v-slot:activator="{ on, attrs }">
                <v-text-field
                v-model="date"
                label="Fecha"
                prepend-icon="mdi-calendar"
                readonly
                v-bind="attrs"
                v-on="on"
                outlined
                ></v-text-field>
            </template>
            <v-date-picker
                v-model="date"
                :active-picker.sync="activePicker"
                max="2025-02-01"
                :min="(new Date(Date.now() - (new Date()).getTimezoneOffset() * 60000)).toISOString().substr(0, 10)"

                @change="save"
            ></v-date-picker>
        </v-menu>


        <v-row>

    <v-spacer></v-spacer>

    <v-col
      cols="12"
      sm="12"

    >
      <v-dialog
        ref="dialog"
        v-model="modal2"
        :return-value.sync="time"
        persistent
        width="290px"
      >
        <template v-slot:activator="{ on, attrs }">
          <v-text-field
            v-model="time"
            label="Hora"
            prepend-icon="mdi-clock-time-four-outline"
            readonly
            outlined
            v-bind="attrs"
            v-on="on"
          ></v-text-field>
        </template>
        <v-time-picker
          v-if="modal2"
          v-model="time"
          full-width
        >
          <v-spacer></v-spacer>
          <v-btn
            text
            color="primary"
            @click="modal2 = false"
          >
            Cancel
          </v-btn>
          <v-btn
            text
            color="primary"
            @click="$refs.dialog.save(time)"
          >
            OK
          </v-btn>
        </v-time-picker>
      </v-dialog>
    </v-col>
  </v-row>

          <!-- <v-text-field
            v-model="time"
            label="Hora"
            prepend-icon="mdi-clock-time-four-outline"
            v-bind="attrs"
            v-on="on"
            outlined
          >
          <input type="time" id="appt" name="appt"
       min="09:00" max="18:00" required v-model="time">
       </v-text-field> -->



        <v-select
          :items="Tipos"
          label="Tipo de Servicio"
          v-model="serviceType"
          outlined
        ></v-select>

        <v-select
          :items="Genero"
          label="Genero"
          v-model="gender"
          outlined
        ></v-select>


        <v-select :items="Tailor" item-text="name" item-value="id"
        outlined auto v-model="tailorId" label="Seleccionar tailor"></v-select>
        <v-col align = "center">
        <v-btn color="primary" class="mt-3" align = "center"  @click="saveSchedule()">Agendar</v-btn>
        </v-col>
    </v-container>
</template>

<script>

import ScheduleDAS from "../../services/ScheduleDAS";
    export default {
        data: () => ({
            date:"",
            tailorId:"",
            Tipos: ['Regular', 'Especial vestido de Novia'],
            Genero: ['Masculino', 'Femenino'],
            gender:"",
            serviceType:"",
            time: null,
                menu2: false,
                modal2: false,
            Tailor: [
                {
                    name:"",
                    id:0
                }
            ],
             }),

     

       

        watch: {
            menu (val) {
                val && setTimeout(() => (this.activePicker = 'YEAR'))
            },
        },
  mounted(){
    this.getTailors();
  },
        methods: {
            save (date) {
                this.$refs.menu.save(date)
            },
            getTailors(){
                ScheduleDAS.getAll()
                     .then((response) => {
                         console.log(response.data);
                    this.Tailor = response.data;
        })
        .catch((e) => {
          console.log(e);
        });
            },
            saveSchedule(){
                var user=JSON.parse(localStorage.getItem('user'));
                var id= user.user.id;
                var data={
                    date: this.date,
                    hour: this.date+'T'+this.time+':00',
                    serviceType: this.serviceType,
                    gender: this.gender,
                    idTailor: this.tailorId
                }
                console.log(data);

                ScheduleDAS.saveAppointment(id,data);
                this.$router.push("Home");
            }


        },
    }
</script>

<style>
    .schedule {
    max-width: 500px;
    }
</style>
