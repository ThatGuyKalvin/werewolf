<template>
    <n-form ref="formRef" :model="model" :rules="rules" :show-label="false">
        <n-form-item path="name" label="Name">
            <n-input v-model:value="model.name" @keydown.enter.prevent placeholder="Name"/>
        </n-form-item>
        <n-form-item path="sessionId" label="SessionId">
            <n-input v-model:value="model.sessionId"
                     @keydown.enter.prevent placeholder="SessionId"/>
        </n-form-item>
        <n-row :gutter="[0, 24]">
            <n-col :span="24">
                <div style="display: flex; justify-content: flex-end">
                    <n-button :disabled="model.name === null || model.sessionId === null"
                              round
                              type="primary"
                              strong
                              secondary
                              @click="handleValidateButtonClick">
                        Join a session
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
        FormItemInst,
        FormValidationError,
        useMessage,
        FormRules
    } from 'naive-ui'

    interface ModelType {
        name: string | null
        sessionId: string | undefined
    }

    export default defineComponent({
        setup() {
            const formRef = ref<FormInst | null>(null)
            const rPasswordFormItemRef = ref<FormItemInst | null>(null)
            const message = useMessage()
            const modelRef = ref<ModelType>({
                name: null,
                sessionId: undefined
            })
            function capitalizeSessionId(): boolean {
                modelRef.value.sessionId = modelRef.value.sessionId?.toUpperCase()
                return true
            }

            const rules: FormRules = {
                name: [
                    {
                        required: true,
                        trigger: ['blur'],
                        min: 2,
                        message: 'Please enter your name.'
                    }
                ],
                sessionId: [
                    {
                        required: true,
                        message: 'Please enter a valid 4 character session ID.',
                        trigger: 'blur',
                        len: 4
                    },
                    {
                        validator: capitalizeSessionId,
                        trigger: 'input'
                    },
                ]
            }
            return {
                formRef,
                rPasswordFormItemRef,
                model: modelRef,
                modelRef,
                rules,
                handleValidateButtonClick(e: MouseEvent) {
                    e.preventDefault()
                    formRef.value?.validate(
                        (errors: Array<FormValidationError> | undefined) => {
                            if (!errors) {
                                //modelRef.value.sessionId = modelRef.value.sessionId?.toUpperCase()
                                message.success(`Joining session ${modelRef.value.sessionId}`)
                            } else {
                                console.log(errors)
                                message.error('Enter a valid 4 character session ID')
                            }
                        }
                    )
                }
            }
        },
    })
</script>