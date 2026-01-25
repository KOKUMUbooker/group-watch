<!-- src/lib/components/home/StatsOverview.svelte -->
<script lang="ts">
	export let stats = {
		totalMovies: 0,
		avgRating: 0,
		recentAdditions: 0
	};

	// Format duration from minutes to hours
	const formatDuration = (minutes: number) => {
		const hours = Math.floor(minutes / 60);
		const mins = minutes % 60;
		return `${hours}h ${mins}m`;
	};
</script>

<div class="grid w-full grid-cols-2 gap-6 md:grid-cols-3">
	<!-- Total Movies -->
	<div
		class="bg-card text-card-foreground rounded-xl border border-border p-6 transition-colors hover:border-primary"
	>
		<div class="mb-4 flex items-center justify-between">
			<h3 class="text-sm tracking-wider text-muted-foreground uppercase">Total Movies</h3>
			<svg class="h-5 w-5 text-primary" fill="currentColor" viewBox="0 0 20 20">
				<path d="M10 12a2 2 0 100-4 2 2 0 000 4z" />
				<path
					fill-rule="evenodd"
					d="M.458 10C1.732 5.943 5.522 3 10 3s8.268 2.943 9.542 7c-1.274 4.057-5.064 7-9.542 7S1.732 14.057.458 10zM14 10a4 4 0 11-8 0 4 4 0 018 0z"
					clip-rule="evenodd"
				/>
			</svg>
		</div>
		<p class="text-3xl font-bold">{stats.totalMovies}</p>
		<p class="mt-2 text-sm text-muted-foreground">films in your collection</p>
	</div>

	<!-- Average Rating -->
	<div
		class="bg-card text-card-foreground rounded-xl border border-border p-6 transition-colors hover:border-primary"
	>
		<div class="mb-4 flex items-center justify-between">
			<h3 class="text-sm tracking-wider text-muted-foreground uppercase">Avg Rating</h3>
			<svg class="h-5 w-5 text-primary" fill="currentColor" viewBox="0 0 20 20">
				<path
					d="M9.049 2.927c.3-.921 1.603-.921 1.902 0l1.07 3.292a1 1 0 00.95.69h3.462c.969 0 1.371 1.24.588 1.81l-2.8 2.034a1 1 0 00-.364 1.118l1.07 3.292c.3.921-.755 1.688-1.54 1.118l-2.8-2.034a1 1 0 00-1.175 0l-2.8 2.034c-.784.57-1.838-.197-1.539-1.118l1.07-3.292a1 1 0 00-.364-1.118L2.98 8.72c-.783-.57-.38-1.81.588-1.81h3.461a1 1 0 00.951-.69l1.07-3.292z"
				/>
			</svg>
		</div>
		<p class="text-3xl font-bold">{stats.avgRating.toFixed(1)}/10</p>
		<p class="mt-2 text-sm text-muted-foreground">across all movies</p>
	</div>

	<!-- Recent Additions -->
	<div
		class="bg-card text-card-foreground rounded-xl border border-border p-6 transition-colors hover:border-primary"
	>
		<div class="mb-4 flex items-center justify-between">
			<h3 class="text-sm tracking-wider text-muted-foreground uppercase">Recently Added</h3>
			<svg class="h-5 w-5 text-primary" fill="none" stroke="currentColor" viewBox="0 0 24 24">
				<path
					stroke-linecap="round"
					stroke-linejoin="round"
					stroke-width="2"
					d="M12 8v4l3 3m6-3a9 9 0 11-18 0 9 9 0 0118 0z"
				/>
			</svg>
		</div>
		<p class="text-3xl font-bold">+{stats.recentAdditions}</p>
		<p class="mt-2 text-sm text-muted-foreground">in the last 30 days</p>
	</div>
</div>
