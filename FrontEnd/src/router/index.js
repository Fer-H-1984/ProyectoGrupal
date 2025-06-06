import { createRouter, createWebHistory } from 'vue-router';
import HomeView from '../views/HomeView.vue';
import AltaGastosView from '../views/AltaGastosView.vue';
import ListadoGastosView from '../views/ListadoGastosView.vue';

const routes = [
  { path: '/', component: HomeView },
  { path: '/AltaGastos', component: AltaGastosView },
  { path: '/ListadoGastos', component: ListadoGastosView },
];

const router = createRouter({
  history: createWebHistory(),
  routes
});

export default router;