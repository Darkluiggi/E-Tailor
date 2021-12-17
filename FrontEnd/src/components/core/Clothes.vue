<template>
    <v-container class = "clothe">

        <p class="headline">Gestion de Citas</p>

        <v-text-field
        outlined
        label = "Cliente"
        >    
        </v-text-field>

        <v-text-field
        outlined
        label = "Taylor"
        >    
        </v-text-field>

        <v-select
          :items="Tipo"
          label="Tipo de Prenda"
          item-text="name"
          auto 
          v-model="clotheType"
          outlined
        ></v-select>

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
                label="Fecha de Entrega"
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

        <p>Selecciona una o mas tareas</p>

        <v-text-field
            ref="search"
            v-model="search"
            full-width
            hide-details
            label="Buscar Tarea"
            single-line
            outlined
        ></v-text-field>

        <v-row>
            <v-col
            v-for="(selection, i) in selections"
            :key="selection.text"
            class="shrink"
            >
                <v-chip
                    :disabled="loading"
                    close
                    @click:close="selected.splice(i, 1)"
                >
                    <v-icon
                    left
                    v-text="selection.icon"
                    ></v-icon>
                    {{ selection.text }}
                </v-chip>
            </v-col>
        </v-row>

        <v-row>
            <v-col>
                <v-list>
                    <template v-for="item in categories">
                        <v-list-item
                        v-if="!selected.includes(item)"
                        :key="item.text"
                        :disabled="loading"
                        @click="selected.push(item)"
                        >
                        <v-list-item-avatar>
                            <v-icon
                            :disabled="loading"
                            v-text="item.icon"
                            ></v-icon>
                        </v-list-item-avatar>
                        <v-list-item-title v-text="item.text"></v-list-item-title>
                        </v-list-item>
                    </template>
                </v-list>
            </v-col>
        </v-row>

        <v-col align = "center">
            <v-btn color="primary" class="mt-3" align = "center" >Guardar</v-btn>
        </v-col>

    </v-container>
</template>

<script>
    export default ({
        data: () => ({
            date:"",
            clotheType:"",
            Tipo:[
                {
                    name:"",
                }
            ],
            items: [
                {
                text: 'Extender manga',
                icon: 'mdi-tshirt-crew-outline',
                },
                {
                text: 'Recortar manga',
                icon: 'mdi-content-cut',
                },
                {
                text: 'Colocar boton',
                icon: 'mdi-radiobox-marked',
                },
                {
                text: 'Colocar cremallera',
                icon: 'mdi-ladder',
                },
                {
                text: 'Extender cintura',
                icon: 'mdi-iron-outline',
                },
                {
                text: 'Recortar cintura',
                icon: 'mdi-content-cut',
                },
                {
                text: 'Extender ruedo',
                icon: 'mdi-human-male-height',
                },
                {
                text: 'Recortar ruedo',
                icon: 'mdi-content-cut',
                },
                {
                text: 'Ajustar hombros',
                icon: 'mdi-tshirt-v',
                },
                {
                text: 'Ajustar cintura',
                icon: 'mdi-iron-board',
                },   
            ],
            loading: false,
            search: '',
            selected: [],
        }),

        computed: {
            allSelected () {
                return this.selected.length === this.items.length
            },
            categories () {
                const search = this.search.toLowerCase()
                if (!search) return this.items
                return this.items.filter(item => {
                const text = item.text.toLowerCase()
                return text.indexOf(search) > -1
                })
            },
            selections () {
                const selections = []
                for (const selection of this.selected) {
                selections.push(selection)
                }
                return selections
            },
        },

        //Lista Iconos
        watch: {
            selected () {
                this.search = ''
            },
        },
 
        //Fecha
        watch_date:{
            menu (val) {
                val && setTimeout(() => (this.activePicker = 'YEAR'))
            },
        },

        methods: {
           /* getTypes(){
                .getAll()
                .then((response) => {
                    console.log(response.data);
                    this.Tipo = response.data;
                })
            .catch((e) => {
                console.log(e);
            });*/

            //Guarda los items de la lista
            guardar () {
                this.loading = true
                setTimeout(() => {
                this.search = ''
                this.selected = []
                this.loading = false
                }, 2000)
            },

            save (date) {
                this.$refs.menu.save(date)
            },

        },
       
    })
</script>

<style>
    .clothe {
    max-width: 500px;
    }
</style>
