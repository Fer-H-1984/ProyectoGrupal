<template>
  <table>
    <thead>
      <tr>
        <th>Fecha</th>
        <th>Descripción</th>
        <th>Monto</th>
        <th>Comercio</th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="gasto in gastos" :key="gasto.id">
        <td>{{ gasto.fecha }}</td>
        <td>{{ gasto.descripcion }}</td>
        <td>${{ gasto.monto }}</td>
        <td>{{ gasto.comercio }}</td>
      </tr>
    </tbody>
  </table>
</template>

<script setup>
import { ref, onMounted } from "vue";

const gastos = ref([]);

onMounted(async () => {
  try {
    const response = await fetch("http://localhost:5000/api/gastos");
    gastos.value = await response.json();
  } catch (error) {
    console.error("Error al obtener gastos:", error);
  }
});
</script>