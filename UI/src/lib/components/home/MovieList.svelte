<script lang="ts">
    import MovieCard from "./MovieCard.svelte"
    import { movies } from "../../../data/movies"
</script>

<div class="grid grid-cols-3 space-y-4">
    {#each movies as movie (movie.id)}
        <MovieCard {...movie}/>
    {/each}
</div>