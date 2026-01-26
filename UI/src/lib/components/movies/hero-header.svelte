<script lang="ts">
	import Button from '../ui/button/button.svelte';
	const { movieLength }: { movieLength: number } = $props();
</script>

<div class="border-b border-border bg-linear-to-r from-primary/10 to-secondary/10">
	<div class="mx-auto max-w-7xl px-4 py-8 sm:px-6 lg:px-8">
		<div class="flex flex-col items-start justify-between gap-6 md:flex-row md:items-center">
			<div>
				<h1 class="text-4xl font-bold tracking-tight">Movie Collection</h1>
				<p class="mt-2 text-muted-foreground">
					Browse our curated collection of {movieLength} movies
				</p>
			</div>
			<div class="flex items-center gap-4">
				<Button size="lg" class="gap-2">
					<svg class="h-5 w-5" fill="none" stroke="currentColor" viewBox="0 0 24 24">
						<path
							stroke-linecap="round"
							stroke-linejoin="round"
							stroke-width="2"
							d="M12 4v16m8-8H4"
						/>
					</svg>
					Add Movie
				</Button>
			</div>
		</div>
	</div>
</div>
