<script setup>
</script>
<template>
  <div class="table-footer">
    <nav class="data-pagination">
      <span>Tổng số: <span class="bold">200</span> bản ghi </span>
      <div class="wrapper-dropdown pagination__margin--30px">
        <div class="position-relative">
          <div class="rectangle-25-59 center-items">
            <span class="">20</span>
            <span class="sprite-down-arrow"></span>
          </div>
        </div>
      </div>
      <a href="#" class="wrapper-dropdown pagination__margin--20px">
        <span class="sprite-left-arrow"></span>
      </a>
      <ul class="">
        <li class="current"><a href="#1">1</a></li>
        <li><a href="#2">2</a></li>
        <li><a href="#10">…</a></li>
        <li><a href="#10">10</a></li>
      </ul>

      <a href="#" class="wrapper-dropdown">
        <span class="sprite-right-arrow"></span>
      </a>
    </nav>
  </div>
</template>
<style>
@import url('@/css/layout/pagination.css');
</style>
