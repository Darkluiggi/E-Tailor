<template>

    <v-container class = "schedule">
        <p class="headline">Agendar Cita</p>

    <ul>
      <li v-for="error in errors" :key="error" style="color:red;text-decoration: underline">{{ error }}</li>
    </ul>
    <v-spacer></v-spacer>
    
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
                max="2025-02-01"
                :min="(new Date(Date.now() - (new Date()).getTimezoneOffset() * 60000)).toISOString().substr(0, 10)"
                @change="save"
            ></v-date-picker>
        </v-menu>


        <v-row>

    <v-divider></v-divider>

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
          <ul>
            <li v-if="disponibilidad" style="font-size:15px;color:green">
                  Horario disponible  
            </li>
          </ul>
         
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
            @click="saveHour(time)"
          >
            OK
          </v-btn>
        </v-time-picker>
      </v-dialog>
    </v-col>
  </v-row>

        
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
        outlined auto v-model="tailorId" label="Seleccionar tailor"
        @change="checkTailorAvailability()">
        </v-select>
        
         <v-col>        
        <v-btn color="success" class="mt-3" align = "center"  @click="checkTailorAvailability()">Verifica disponibilidad</v-btn>
        </v-col>
        <v-col >
        <v-btn color="primary" class="mt-3" align = "center"  @click="saveSchedule()">Agendar</v-btn>
        </v-col>
    </v-container>
</template>

<script>

import ScheduleDAS from "../../services/ScheduleDAS";
    export default {
        data: () => ({
            errors:[],
            disponibilidad: false,
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
                this.$refs.menu.save(date);
                this.checkTailorAvailability();
            },
            saveHour(time){
              this.$refs.dialog.save(time);
              this.checkTailorAvailability();
            },
            getTailors(){
                ScheduleDAS.getAll()
                     .then((response) => {
                        
                    this.Tailor = response.data;
        })
        .catch((e) => {
          console.log(e);
        });
            },
            saveSchedule(){
                 this.checkTailorAvailability();

                 if(this.disponibilidad==true){
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
              else
              {
                 this.errors.push("Horario no disponible");
              }
            },
             checkTailorAvailability(){
                this.errors=[];
                 var data={
                    date: this.date,
                    hour: this.date+'T'+this.time+':00', 
                    serviceType: this.serviceType,
                    gender: this.gender,
                    idTailor: this.tailorId
                }
                 if(data.date==""){
                   this.errors.push("Selecciona la fecha");
                }
                 if(data.hour.includes("null")){
                   this.errors.push("Selecciona la hora");
                }
                if(data.tailorId==null){
                   this.errors.push("Selecciona el tailor");
                }
                ScheduleDAS.getTailorAvailability(data)
                .then((response) => {
                        this.errors=[];
                         console.log(response.data);
                        if(response.data=="Horario disponible"){
                          this.disponibilidad=true;
                        }
                        else{
                          this.errors.push(response.data);
                          this.disponibilidad=false;
                        }
                      })
                                   }
        },
    }
</script>

<style>
    .schedule {
    max-width: 500px;
    }
</style>
