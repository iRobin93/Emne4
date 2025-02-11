<template>
    <div class="test p-4 border rounded-lg bg-gray-100">
        <ul class="space-y-4">
            <!-- Loop through the list and display each item -->
            <li v-for="(song, index) in songs" :key="index" class="flex justify-between items-center p-2 bg-white shadow-md rounded-lg">
                <span class="text-lg font-medium">
                    {{ song.Title }} - {{ song.Artist }} 
                    <span :class="{'text-green-500': song.Favourite, 'text-red-500': !song.Favourite}">
                        {{ song.Favourite ? "This is recommended" : "This is not recommended" }}
                    </span>
                </span>
                <div class="flex space-x-2">
                    <button 
                        @click="markAsRecommended(song)" 
                        class="px-4 py-2 bg-blue-500 text-black rounded-md hover:bg-blue-600 focus:outline-none">
                        {{ song.Recomend }}
                    </button>
                    <button 
                        @click="deleteSongClicked(index)" 
                        class="px-4 py-2 bg-red-500 text-black rounded-md hover:bg-red-600 focus:outline-none">
                        Delete
                    </button>
                </div>
            </li>
        </ul>

        <div class="mt-4 flex space-x-2">
            <input 
                v-model="newSong" 
                placeholder="Add a new song" 
                class="p-2 border border-gray-300 rounded-md w-1/2 focus:outline-none focus:ring-2 focus:ring-blue-500" 
            />
            <input 
                v-model="newArtist" 
                placeholder="Add a new artist" 
                class="p-2 border border-gray-300 rounded-md w-1/2 focus:outline-none focus:ring-2 focus:ring-blue-500"
            />
            <button 
                @click="addSong" 
                class="px-4 py-2 bg-green-500 text-black rounded-md hover:bg-green-600 focus:outline-none">
                Add
            </button>
        </div>
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
            song.Recomend = song.Favourite ? "Unrecommend" : "Recommend";
        },
        deleteSongClicked(index) {
            this.$emit('delete-Song', index)
        },
        addSong() {
            if (this.newSong && this.newArtist) {
                // Emit an event to add the new song to the parent component
                this.$emit('add-song', {
                    Title: this.newSong,
                    Artist: this.newArtist,
                    Favourite: undefined,
                    Recomend: "Recommend",
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
/* You can add custom styles here if needed, but Tailwind should handle most styling */
</style>
