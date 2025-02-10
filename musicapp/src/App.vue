<template>
  <img alt="Vue logo" src="./assets/logo.png">
  <SongRecommendation :songs="myList" @add-song="addSongToList" />

</template>

<script>
import SongRecommendation from './components/SongRecommendation.vue'

export default {
  name: 'App',
  data() {
    return {
      myList: [
        {
          Title: "Song 1",
          Artist: "Me",
          Favourite: undefined,
        },
        {
          Title: "Song 2",
          Artist: "You",
          Favourite: undefined,
        }
      ]
    };
  },
  methods: {
    addSongToList(newSong) {
      this.myList.push(newSong);  // Add the new song to the list
    }
  },
  components: {
    SongRecommendation
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
