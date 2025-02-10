<template>
    <div class="test">
        <ul>
            <!-- Loop through the list and display each item -->
            <li v-for="(song, index) in songs" :key="index">
                {{ song.Title }} - {{ song.Artist }} {{ song.Favourite ? "This is recomended" : "This is not recomended" }}
                <button @click="markAsRecommended(song)">{{ song.Recomend }}</button>
                <button @click="deleteSongClicked(index)">Delete</button>
            </li>
            <input v-model="newSong" placeholder="Add a new song">
            <input v-model="newArtist" placeholder="Add a new artist">
            <button @click="addSong">Add</button>
        </ul>
    </div>
</template>

<script>
export default {
    name: 'SongRecommendation',
    props: {
        // Define the 'songs' prop to receive data from the parent
        songs: {
            type: Array,
            required: true
        },

    },
    data() {
        return {
            newSong: '',    // For inputting a new song title
            newArtist: '',  // For inputting the new artist name
        };
    },
    methods: {
        markAsRecommended(song) {
            song.Favourite = !song.Favourite;
            song.Recomend = song.Favourite ? "Unrecomend" : "Recomend";
        },
        deleteSongClicked(index){
            this.$emit('delete-Song', index)
        },
        addSong() {
            if (this.newSong && this.newArtist) {
                // Emit an event to add the new song to the parent component
                this.$emit('add-song', {
                    Title: this.newSong,
                    Artist: this.newArtist,
                    Favourite: undefined,
                    Recomend: "Recomend",
                });

                // Clear the input fields after adding
                this.newSong = '';
                this.newArtist = '';
            } else {
                alert('Please enter both a song title and artist.');
            }
        }
    }
};
</script>

<style scoped>
.my-component {
    text-align: center;
    padding: 20px;
    border: 1px solid #ccc;
}
</style>