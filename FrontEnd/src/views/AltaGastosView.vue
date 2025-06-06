<script setup>
import { ref } from 'vue'

const nuevoGasto = ref({
  monto: 0,
  descripcion: '',
  fecha: '',
  nombreComercio: ''
})

const enviarGasto = async () => {
  console.log("Enviando gasto:", JSON.stringify(nuevoGasto.value))
  await fetch('http://localhost:5297/api/Gastos', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(nuevoGasto.value)
  })
  nuevoGasto.value = { monto: 0, descripcion: '', fecha: '', nombreComercio: '' }

  window.location.href = "/ListadoGastos"
}
</script>

<template>
   <div>
     <h1>Registro de Gastos</h1>

    <form @submit.prevent="enviarGasto" class="formulario">
      <input v-model="nuevoGasto.monto" placeholder="Monto" type="number" step="0.01" required />
      <input v-model="nuevoGasto.descripcion" placeholder="Descripción" required />
      <input v-model="nuevoGasto.fecha" type="date" required />
      <input v-model="nuevoGasto.nombreComercio" placeholder="Nombre del comercio" required />
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
</style>