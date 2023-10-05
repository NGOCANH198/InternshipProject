<script setup>
import { RouterLink, RouterView } from 'vue-router';
import { useNotificationStore } from './stores/notification';
import { ref, inject, onMounted, onUpdated, watch } from 'vue';
import MISAFadeVue from '@/components/base/MISAFade.vue';
import MISALoading from '@/components/base/MISALoading.vue';
import MISANotificationVue from '@/components/notification/MISANOtification.vue';
import useLoading from '@/services/loading.js';
const notificationStore = useNotificationStore();
const $MISAresource = inject('$MISAresource');
const loading = useLoading();
// onMounted(() => {
//     loading.showLoading();
//     setTimeout(() => {
//         loading.hideLoading();
//     }, 3000);
// });

watch(loading.isLoading, () => {
    console.log('dong 20');
    console.log(loading.isLoading);
});
</script>

<template>
    <!-- <header>
    <div class="wrapper">
      <nav>
        <RouterLink to="/">Home</RouterLink>
        <RouterLink to="/about">About</RouterLink>
      </nav>
    </div>
  </header> -->
    <MISAFadeVue :show="notificationStore.showNotificationError" v-if="notificationStore.showNotificationError">
        <MISANotificationVue type="danger" :content="notificationStore.message" />
    </MISAFadeVue>
    <MISAFadeVue :show="notificationStore.showNotificationSuccess" v-if="notificationStore.showNotificationSuccess">
        <MISANotificationVue type="success" :content="notificationStore.message" />
    </MISAFadeVue>
    <MISALoading> </MISALoading>
    <RouterView />
</template>

<style >
</style>
