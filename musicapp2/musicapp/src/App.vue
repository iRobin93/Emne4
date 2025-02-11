<template>
  <div class="flex justify-center items-center h-screen bg-gray-200">
    <div class="perspective-1000">
      <div class="w-64 h-96 transform-style-preserve-3d transition-transform duration-500 hover:rotate-y-180">
        <div class="w-full h-full bg-white shadow-xl rounded-lg p-6 front-side">
          <h2 class="text-xl font-semibold text-gray-800">Front of the Card</h2>
          <p class="text-gray-600">Hover to flip me!</p>
        </div>
        <div class="w-full h-full bg-blue-500 text-white shadow-xl rounded-lg p-6 back-side transform rotate-y-180">
          <h2 class="text-xl font-semibold">Back of the Card</h2>
          <p>This is the flipped side, with some more info!</p>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  mounted() {
    const toggle = document.getElementById("toggle");
    const circle = toggle.nextElementSibling.nextElementSibling;

    toggle.addEventListener("change", () => {
      if (toggle.checked) {
        circle.classList.add("translate-x-6");
      } else {
        circle.classList.remove("translate-x-6");
      }
    });
  }
};
</script>

<style scoped>
/* For 3D perspective */
.perspective-1000 {
  perspective: 1000px;
}
.transform-style-preserve-3d {
  transform-style: preserve-3d;
}
.front-side,
.back-side {
  position: absolute;
  backface-visibility: hidden;
  width: 100%;
  height: 100%;
}
</style>