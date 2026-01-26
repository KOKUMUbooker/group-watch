<script lang="ts">
	import { Badge } from '@/components/ui/badge';
	import { Label } from '@/components/ui/label';
	import { ALL_GENRES, type Genre } from '../../../../types';

	interface GenreFiltersProps {
		selectedGenres: Genre[];
		toggleGenre: (genre: Genre) => void;
	}
	const { selectedGenres, toggleGenre }: GenreFiltersProps = $props();
</script>

<div class="space-y-3">
	<div class="flex items-center justify-between">
		<Label class="text-sm font-medium">Genres</Label>
		<span class="text-xs text-muted-foreground">
			{selectedGenres.length} selected
		</span>
	</div>
	<div class="flex flex-wrap gap-2">
		{#each ALL_GENRES as genre}
			<Badge
				variant={selectedGenres.includes(genre) ? 'default' : 'outline'}
				class="cursor-pointer transition-colors hover:bg-accent"
				onclick={() => toggleGenre(genre)}
			>
				{genre}
			</Badge>
		{/each}
	</div>
</div>
