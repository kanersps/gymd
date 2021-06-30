<template>
  <span :class="selected ? 'text-blue-700' : 'text-gray-600'" class="font-semibold pr-4 cursor-pointer"> <slot /> </span>
</template>

<script>
export default {
  props: ["selected"],
};
</script>