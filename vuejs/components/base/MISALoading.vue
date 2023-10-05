<script setup>
import { computed, ref, watch, inject, nextTick } from 'vue';
import useLoading from '@/services/loading.js';
import Loading from 'vue-loading-overlay';
import 'vue-loading-overlay/dist/css/index.css';
const loading = useLoading();
const fullPage = ref(true);
</script>
<template>
    <div class="vld-parent">
        <Loading
            :active.sync="loading.isLoading"
            :can-cancel="true"
            :on-cancel="onCancel"
            :is-full-page="fullPage"
        ></Loading>
    </div>
</template>
<style>
</style>
