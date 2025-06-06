<template>
  <main class="container">
    <RouterLink to="/">Inicio</RouterLink>
    <br>
    <RouterLink to="/ListadoGastos">Listado de Gastos</RouterLink>
    <br>
    <RouterLink to="/AltaGastos">Alta de Gastos</RouterLink>

    <RouterView />
  </main>
</template>

<style scoped>
.container {
  max-width: 700px;
  margin: 2rem auto;
  padding: 1.5rem;
  background: #f7f7f7;
  border-radius: 12px;
  box-shadow: 0 4px 8px rgba(0,0,0,0.1);
  font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
}
</style>
