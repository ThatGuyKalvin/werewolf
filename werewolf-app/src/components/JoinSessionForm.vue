<template>
    <n-space vertical>
        <n-form ref="formRef"
                inline
                :label-width="80"
                :model="formValue"
                :rules="rules"
                :size="size">
            <n-form-item label="Name" path="user.name">
                <n-input v-model:value="formValue.user.name" placeholder="Input Name" />
            </n-form-item>
            <n-form-item label="Session Code" path="user.sessioncode">
                <n-input v-model:value="formValue.user.sessioncode" placeholder="Input Session Code" />
            </n-form-item>

            <n-form-item>
                <n-button strong secondary type="primary" @click="handleJoinClick">
                    Join the session
                </n-button>
            </n-form-item>
        </n-form>

        <pre>{{ JSON.stringify(formValue, null, 2) }}</pre>
        </n-space>
</template>

<script lang="ts">
import { defineComponent, ref } from 'vue'
import { FormInst, useMessage } from 'naive-ui'

export default defineComponent({
  setup () {
    const formRef = ref<FormInst | null>(null)
    const message = useMessage()
    return {
      formRef,
      formValue: ref({
        user: {
          name: '',
          sessioncode: ''
        },
      }),
      rules: {
        user: {
          name: {
            required: true,
            message: 'Please enter your name.',
            trigger: 'blur'
          },
          sessioncode: {
            required: true,
            message: 'Please enter your game session code. If unsure please ask your host.',
            trigger: ['input', 'blur']
          }
        },
      },
      handleJoinClick (e: MouseEvent) {
        e.preventDefault()
        formRef.value?.validate((errors) => {
            if (!errors) {
                message.success('Joining session...')
            } else {
              console.log(errors)
              message.error('Please enter a valid session')
          }
        })
      }
    }
  }
})
</script>