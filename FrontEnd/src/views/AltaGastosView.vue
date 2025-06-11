<script setup>
import { ref } from 'vue'
import { useForm, useField } from 'vee-validate'
import * as yup from 'yup'

const schema = yup.object({
  monto: yup.number()
    .required('El monto es requerido')
    .min(0.01, 'El monto debe ser mayor a 0'),

  descripcion: yup.string()
    .trim()
    .required('La descripción es requerida')
    .max(250, 'La descripción no puede exceder los 250 caracteres')
    .min(3, 'La descripción no puede ser menor de 3 caracteres'),

  fecha: yup.date()
    .required('La fecha es requerida')
    .max(new Date(), 'La fecha no puede ser futura'),

  nombreComercio: yup.string()
    .trim()
    .required('El nombre del comercio es requerido')
    .max(250, 'El nombre no puede exceder los 250 caracteres')
})


const { handleSubmit, errors } = useForm({
  validationSchema: schema
})

const { value: monto } = useField('monto')
const { value: descripcion } = useField('descripcion')
const { value: fecha } = useField('fecha')
const { value: nombreComercio } = useField('nombreComercio')

const enviarGasto = handleSubmit(async (values) => {
  console.log("Enviando gasto:", JSON.stringify(values))
  await fetch('http://localhost:5297/api/Gastos', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(values)
  })
  
  monto.value = 0
  descripcion.value = ''
  fecha.value = ''
  nombreComercio.value = ''

  window.location.href = "/ListadoGastos"
})
</script>

<template>
  <div>
    <h1>Registro de Gastos</h1>

    <form @submit="enviarGasto" class="formulario">
      <div>
        <input v-model="monto" placeholder="Monto" type="number" step="0.01" />
        <span class="error-message">{{ errors.monto }}</span>
      </div>
      
      <div>
        <input v-model="descripcion" placeholder="Descripción" />
        <span class="error-message">{{ errors.descripcion }}</span>
      </div>
      
      <div>
        <input v-model="fecha" type="date" />
        <span class="error-message">{{ errors.fecha }}</span>
      </div>
      
      <div>
        <input v-model="nombreComercio" placeholder="Nombre del comercio" />
        <span class="error-message">{{ errors.nombreComercio }}</span>
      </div>
      
      <button type="submit">Agregar Gasto</button>
    </form>
  </div>
</template>

<style>
.formulario {
  display: flex;
  flex-direction: column;
  gap: 1rem;
  margin-bottom: 2rem;
}

.formulario input {
  padding: 0.7rem;
  border: 1px solid #ccc;
  border-radius: 8px;
  font-size: 1rem;
  width: 100%;
}

.formulario button {
  padding: 0.7rem;
  background-color: #0077cc;
  color: white;
  border: none;
  border-radius: 8px;
  font-size: 1rem;
  cursor: pointer;
  transition: background-color 0.3s ease;
}

.formulario button:hover {
  background-color: #005fa3;
}

.error-message {
  color: red;
  font-size: 0.8rem;
  margin-top: 0.2rem;
  display: block;
}
</style>