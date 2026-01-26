<script lang="ts">
	import { Tabs, TabsList, TabsTrigger } from '@/components/ui/tabs';
	import Clock from '@lucide/svelte/icons/clock';
	import type { Movie } from '../../../../types';

	export interface DurationFiltersProps {
		filteredMovies: Movie[];
		updateFilters: () => void;
	}
	let { filteredMovies, updateFilters }: DurationFiltersProps = $props();
</script>

<div class="space-y-2">
	<label class="flex items-center gap-2 text-sm font-medium">
		<Clock size={14} />
		Duration
	</label>
	<Tabs class="w-full">
		<TabsList class="grid grid-cols-4">
			<TabsTrigger value="all" onclick={() => updateFilters()}>All</TabsTrigger>
			<TabsTrigger
				value="short"
				onclick={() => {
					// Filter short movies (< 90 min)
					const filtered = filteredMovies.filter((m) => m.Minutes < 90);
					filteredMovies = filtered;
				}}>Short</TabsTrigger
			>
			<TabsTrigger
				value="medium"
				onclick={() => {
					// Filter medium movies (90-150 min)
					const filtered = filteredMovies.filter((m) => m.Minutes >= 90 && m.Minutes <= 150);
					filteredMovies = filtered;
				}}>Medium</TabsTrigger
			>
			<TabsTrigger
				value="long"
				onclick={() => {
					// Filter long movies (> 150 min)
					const filtered = filteredMovies.filter((m) => m.Minutes > 150);
					filteredMovies = filtered;
				}}>Long</TabsTrigger
			>
		</TabsList>
	</Tabs>
</div>
