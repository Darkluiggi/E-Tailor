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
                :max="(new Date(Date.now() - (new Date()).getTimezoneOffset() * 60000)).toISOString().substr(0, 10)"
                min="1950-01-01"
                @change="save"
            ></v-date-picker>
        </v-menu>

          <v-text-field
            v-model="time"
            label="Hora"
            prepend-icon="mdi-clock-time-four-outline"
            v-bind="attrs"
            v-on="on"
            outlined
          ></v-text-field>
      
       

        <v-select
          :items="Tipos"
          label="Tipo de Servicio"
          outlined
        ></v-select>

        <v-select
          :items="Genero"
          label="Genero"
          outlined
        ></v-select>

        <v-select
          :items="Taylor"
          label="Taylor"
          outlined
        ></v-select>
        <v-col align = "center">
        <v-btn color="primary" class="mt-3" align = "center">Agendar</v-btn>
        </v-col>
    </v-container>
</template>

<script>
    export default {
        data: () => ({
        Tipos: ['Regular', 'Especial vestido de Novia'],
        Genero: ['Masculino', 'Femenino'],
        Taylor: ['Andres', 'Pedro', 'Camilo'],
        }),

        data_date: () => ({
            activePicker: null,
            date: null,
            menu: false,
        }),

        data_time () {
            return {
                time: null,
                menu2: false,
                modal2: false,
            }
        },

        watch: {
            menu (val) {
                val && setTimeout(() => (this.activePicker = 'YEAR'))
            },
        },

        methods: {
            save (date) {
                this.$refs.menu.save(date)
            },
        },
    }
</script>

<style>
    .schedule {
    max-width: 500px;
    }
</style>
