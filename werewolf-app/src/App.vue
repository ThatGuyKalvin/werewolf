<template>
    <div class="app" id="app">
        <div class="logo" id="logo">
            <a href="/" alt="Go to home page"><img class="logo" alt="Logo" src="logo.png"></a>
        </div>
        <div class="main" id="main">
            <n-loading-bar-provider>
                <n-message-provider>
                    <n-notification-provider>
                        <n-dialog-provider>
                            <p>name: {{name}}</p>
                            <p>sessionId: {{sessionId}}</p>
                            <p>isHost: {{isHost}}</p>
                            <router-view></router-view>
                        </n-dialog-provider>
                    </n-notification-provider>
                </n-message-provider>
            </n-loading-bar-provider>
        </div>
    </div>
</template>

<script lang="ts">
    import { defineComponent } from 'vue';
    import { storeToRefs } from 'pinia'
    import { useUserStore } from '@/stores/UserStore'


export default defineComponent({
  name: 'App',
  setup() {
      const store = useUserStore()

      const { name, sessionId, isHost } = storeToRefs(store)

      return { name, sessionId, isHost }
    },
  components: {
  }
});
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  color: #2c3e50;
}

#logo {
    -moz-transform: scale(0.5);
    -webkit-transform: scale(0.5);
    transform: scale(0.5);
    border: 5px solid green;
    margin-top: -75px;
    text-align: center;
}

#main {
    text-align: center;
}
</style>
