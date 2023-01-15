<template>
    <div class="characters">
        <div v-if="loading" class="loading">
            Loading... Please refresh once the ASP.NET backend has started. See <a href="https://aka.ms/jspsintegrationvue">https://aka.ms/jspsintegrationvue</a> for more details.
        </div>

        <div v-if="characters" class="content">
            <table>
                <thead>
                    <tr>
                        <th>Characters</th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="x in characters" v-bind:key="name">
                        <td>{{ x.name }}</td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</template>

<script lang="ts">
    import { defineComponent } from 'vue';

    type Characters = {
        name: string
    }[];

    interface Data {
        loading: boolean,
        characters: null | Characters
    }

    export default defineComponent({
        data(): Data {
            return {
                loading: false,
                characters: null
            };
        },
        created() {
            // fetch the data when the view is created and the data is
            // already being observed
            this.fetchData();
        },
        watch: {
            // call again the method if the route changes
            '$route': 'fetchData'
        },
        methods: {
            fetchData(): void {
                this.characters = null;
                this.loading = true;

                fetch('game/getcharacters')
                    .then(r => r.json())
                    .then(json => {
                        this.characters = json as Characters;
                        this.loading = false;
                        return;
                    });
            }
        },
    });
</script>