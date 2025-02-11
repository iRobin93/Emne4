<template>
    <div class="min-h-screen bg-gradient-to-r from-purple-500 to-indigo-500 flex items-center justify-center">
      <div class="grid grid-cols-1 md:grid-cols-3 gap-8 p-4">
        <!-- Card 1 -->
        <div class="max-w-sm rounded-lg overflow-hidden shadow-lg transform transition-all hover:scale-105 hover:shadow-2xl">
          <img class="w-full h-56 object-cover" src="https://via.placeholder.com/400x300" alt="Image">
          <div class="px-6 py-4 bg-white">
            <h3 class="text-xl font-semibold text-gray-800">Beautiful Sunset</h3>
            <p class="text-gray-600 mt-2">Experience the vibrant colors of the setting sun. Perfect for your wall decor.</p>
          </div>
          <div class="px-6 py-4 bg-gray-100">
            <a href="#" class="text-indigo-600 hover:text-indigo-800 font-semibold">View More</a>
          </div>
        </div>
  
        <!-- Card 2 -->
        <div class="max-w-sm rounded-lg overflow-hidden shadow-lg transform transition-all hover:scale-105 hover:shadow-2xl">
          <img class="w-full h-56 object-cover" src="https://via.placeholder.com/400x300" alt="Image">
          <div class="px-6 py-4 bg-white">
            <h3 class="text-xl font-semibold text-gray-800">Mountain Adventure</h3>
            <p class="text-gray-600 mt-2">The majestic mountains, capturing the essence of adventure and serenity.</p>
          </div>
          <div class="px-6 py-4 bg-gray-100">
            <a href="#" class="text-indigo-600 hover:text-indigo-800 font-semibold">View More</a>
          </div>
        </div>
  
        <!-- Card 3 -->
        <div class="max-w-sm rounded-lg overflow-hidden shadow-lg transform transition-all hover:scale-105 hover:shadow-2xl">
          <img class="w-full h-56 object-cover" src="https://via.placeholder.com/400x300" alt="Image">
          <div class="px-6 py-4 bg-white">
            <h3 class="text-xl font-semibold text-gray-800">Cityscape Lights</h3>
            <p class="text-gray-600 mt-2">Bright lights and towering buildings—bring the energy of the city into your home.</p>
          </div>
          <div class="px-6 py-4 bg-gray-100">
            <a href="#" class="text-indigo-600 hover:text-indigo-800 font-semibold">View More</a>
          </div>
        </div>
      </div>
    </div>
  </template>
  
  <script>
  export default {
    name: 'CardComponent',
  }
  </script>
  
  <style scoped>
  /* You can add additional custom styles if needed */
  </style>