<template>
  <div class="tooltip">
    <svg xmlns="http://www.w3.org/2000/svg" class="h-5 w-5 hover:text-gray-500" viewBox="0 0 20 20" fill="currentColor">
      <path
        fill-rule="evenodd"
        d="M18 10a8 8 0 11-16 0 8 8 0 0116 0zm-8-3a1 1 0 00-.867.5 1 1 0 11-1.731-1A3 3 0 0113 8a3.001 3.001 0 01-2 2.83V11a1 1 0 11-2 0v-1a1 1 0 011-1 1 1 0 100-2zm0 8a1 1 0 100-2 1 1 0 000 2z"
        clip-rule="evenodd"
      />
    </svg>

    <span class="tooltip-value w-56 bg-gray-700 text-white rounded px-2 py-1 shadow-lg">
      <slot></slot>
    </span>
  </div>
</template>

<style scoped>
.tooltip .tooltip-value {
  visibility: hidden;
  text-align: center;

  position: absolute;
  transform: translateX(calc(-50% + 8px));
  z-index: 1;
}

.tooltip:hover .tooltip-value {
  visibility: visible;
}
</style>

<script>
export default {};
</script>