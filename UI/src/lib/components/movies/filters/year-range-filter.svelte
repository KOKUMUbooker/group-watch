<script lang="ts">
	import { Slider } from '@/components/ui/slider';
	import Calendar from '@lucide/svelte/icons/calendar';
	interface YearRangeFilterProps {
		yearRange: [number, number];
		updateFilters: () => void;
	}

	let { updateFilters, yearRange }: YearRangeFilterProps = $props();
</script>

<div class="space-y-3">
	<div class="flex items-center justify-between">
		<label class="text-sm font-medium">
			<Calendar size={14} class="mr-2 inline" />
			Year Range
		</label>
		<span class="text-xs text-muted-foreground">
			{yearRange[0]} - {yearRange[1]}
		</span>
	</div>
	<Slider
		min={1980}
		max={2025}
		step={1}
		type="multiple"
		bind:value={yearRange}
		onchange={updateFilters}
		class="py-4"
	/>
	<div class="flex justify-between text-sm text-muted-foreground">
		<span>{yearRange[0]}</span>
		<span>{yearRange[1]}</span>
	</div>
</div>
