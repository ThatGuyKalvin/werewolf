<template>
    <n-space vertical>
      <n-button strong secondary :loading="loading" icon-placement="left" @click="handleCreateClick" type="info">
        Start a new session
      </n-button>

      <n-button strong secondary type="primary" @click="handleJoinClick" >
        Join an existing session
      </n-button>
    </n-space>
</template>

<script lang="ts">
    import { defineComponent, ref } from 'vue';

    export default defineComponent({
        setup () {
          const loadingRef = ref(false)
          return {
            handleClick () {
              loadingRef.value = true
              setTimeout(() => {
                loadingRef.value = false
              }, 2000)
            },
            loading: loadingRef,
          }
        },
        created() {
        },
        watch: {
        },
        methods: {
          handleJoinClick() {
            this.$router.push({ name: 'JoinSession'})
          },
          handleCreateClick() {
            this.$router.push({ name: 'CreateSession'})
          }
        },
    });
</script>