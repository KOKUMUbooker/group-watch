<script lang="ts">
	import { Button } from '@/components/ui/button';
	import { CardHeader, CardTitle } from '@/components/ui/card';
	import X from '@lucide/svelte/icons/x';
	interface FilterHeaderProps {
		activeFilterCount: number;
		clearFilters: () => void;
	}
	const { activeFilterCount, clearFilters }: FilterHeaderProps = $props();
</script>

<CardHeader class="pb-3">
	<div class="flex items-center justify-between">
		<CardTitle class="text-lg">Filters</CardTitle>
		{#if activeFilterCount > 0}
			<Button variant="ghost" size="sm" onclick={clearFilters} class="gap-1">
				<X size={14} />
				Clear All
			</Button>
		{/if}
	</div>
	{#if activeFilterCount > 0}
		<p class="text-sm text-muted-foreground">
			{activeFilterCount} active filter{activeFilterCount !== 1 ? 's' : ''}
		</p>
	{/if}
</CardHeader>
