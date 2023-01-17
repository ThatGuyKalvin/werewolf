<template>
    <div class="app" id="app">
        <img alt="Logo" src="logo.png">
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
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
