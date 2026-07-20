<script setup>
import {ref} from 'vue' 
const count=ref(0)
</script>

<template>
  <div>
    <button @click="count++">點了 {{ count }} 次</button>
  </div>
</template>

<style scoped></style>
