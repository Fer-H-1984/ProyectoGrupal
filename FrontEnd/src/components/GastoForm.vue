<template>
  <form @submit.prevent="enviarGasto">
    <label>Monto:</label>
    <input type="number" v-model="gasto.monto" required min="0" />

    <label>Descripción:</label>
    <input type="text" v-model="gasto.descripcion" required minlength="3" maxlength="250" />

    <label>Fecha:</label>
    <input type="date" v-model="gasto.fecha" required :max="fechaMaxima" />

    <label>Nombre de comercio:</label>
    <input type="text" v-model="gasto.comercio" required maxlength="250" />

    <button type="submit">Registrar Gasto</button>
    <p v-if="mensaje">{{ mensaje }}</p>
  </form>
</template>

<script setup>
import { ref } from "vue";

const gasto = ref({ monto: "", descripcion: "", fecha: "", comercio: "" });
const mensaje = ref("");
const fechaMaxima = new Date().toISOString().split("T")[0];

const enviarGasto = async () => {
  try {
    const response = await fetch("http://localhost:5000/api/gastos", {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(gasto.value),
    });
    if (response.ok) {
      mensaje.value = "Gasto registrado con éxito";
      gasto.value = { monto: "", descripcion: "", fecha: "", comercio: "" };
    } else {
      mensaje.value = "Error al registrar el gasto";
    }
  } catch (error) {
    mensaje.value = "Fallo en la comunicación con el servidor";
  }
};
</script>