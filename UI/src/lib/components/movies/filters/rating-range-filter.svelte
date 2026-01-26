<script lang="ts">
	import { Slider } from '@/components/ui/slider';
	import Star from '@lucide/svelte/icons/star';

	export interface RatingRangeFilterProps {
		ratingRange: [number, number];
		updateFilters: () => void;
	}
	let { ratingRange, updateFilters }: RatingRangeFilterProps = $props();
</script>

<div class="space-y-3">
	<div class="flex items-center justify-between">
		<label class="text-sm font-medium">
			<Star size={14} class="mr-2 inline" />
			Rating
		</label>
		<span class="text-xs text-muted-foreground">
			{ratingRange[0].toFixed(1)} - {ratingRange[1].toFixed(1)}
		</span>
	</div>
	<Slider
		min={0}
		max={10}
		step={0.5}
		type="multiple"
		bind:value={ratingRange}
		onchange={updateFilters}
		class="py-4"
	/>
	<div class="flex justify-between text-sm text-muted-foreground">
		<span>{ratingRange[0].toFixed(1)}</span>
		<span>{ratingRange[1].toFixed(1)}</span>
	</div>
</div>
