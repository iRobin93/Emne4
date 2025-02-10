<template>
  <img alt="Vue logo" src="./assets/logo.png">
  <SongRecommendation :songs="myList" @add-song="addSongToList" @delete-Song="deleteSong" />

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
          Recomend: "Recomend",
        },
        {
          Title: "Song 2",
          Artist: "You",
          Favourite: undefined,
          Recomend: "Recomend",
        }
      ]
    };
  },
  methods: {
    addSongToList(newSong) {
      this.myList.push(newSong);  // Add the new song to the list
    },
    deleteSong(index){
      this.myList.splice(index, 1)
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
