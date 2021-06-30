<template>
  <router-link :to="to" :class="selected ? 'text-blue-700' : 'text-gray-600'" class="font-semibold pr-4 cursor-pointer"> <slot /> </router-link>
</template>

<script>
export default {
  props: ["selected", "to"],
};
</script>