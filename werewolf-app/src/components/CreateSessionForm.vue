<template>
    <n-form class="form" ref="formRef" :model="model" :rules="rules" :show-label="false">
        <n-form-item path="name" label="Name">
            <n-input v-model:value="model.name" @keydown.enter.prevent placeholder="Name"/>
        </n-form-item>
        <n-row :gutter="[0, 24]">
            <n-col :span="24">
                <div style="display: flex; justify-content: flex-end">
                    <n-button :disabled="!model.name"
                              round
                              type="info"
                              strong
                              secondary
                              @click="handleValidateButtonClick">
                        Create a session
                    </n-button>
                </div>
            </n-col>
        </n-row>
    </n-form>
</template>

<script lang="ts">
    import { defineComponent, ref } from 'vue'
    import {
        FormInst,
        FormValidationError,
        useMessage,
        FormRules
    } from 'naive-ui'
    import api from '@/services/api'
    import { useRouter } from 'vue-router';
    import { useUserStore } from '@/stores/UserStore'

    interface ModelType {
        name: string
    }

    export default defineComponent({
        setup() {
            const formRef = ref<FormInst | null>(null)
            const message = useMessage()
            const modelRef = ref<ModelType>({
                name: '',
            })

            const rules: FormRules = {
                name: [
                    {
                        required: true,
                        trigger: ['blur'],
                        min: 2,
                        message: 'Please enter your name.'
                    }
                ]
            } 

            const userStore = useUserStore()

            const router = useRouter()
            const handleValidateButtonClick = async (e: MouseEvent) => {
                e.preventDefault()
                formRef.value?.validate(
                    async (errors: Array<FormValidationError> | undefined) => {
                        if (!errors) {
                            //modelRef.value.sessionId = modelRef.value.sessionId?.toUpperCase()
                            await api.createSession(modelRef.value.name).then((value) => {
                                if (value != false) {
                                    userStore.setName(modelRef.value.name)
                                    userStore.setSessionId(value)
                                    userStore.setIsHost(true)
                                    router.push({ name: 'GameAsPlayer' })
                                    message.success(`Create session ${value}`)
                                }
                                else message.warning('Failed to create session')
                            })
                            
                        } else {
                            console.log(errors)
                            message.error('Enter a valid name')
                        }
                    }
                )
            }
            return {
                formRef,
                model: modelRef,
                modelRef,
                rules,
                handleValidateButtonClick
            }
        },
    })
</script>

<style>
.form {
    padding-right: 40px;
    padding-left: 40px;
}

</style>