<script lang="ts">
	import { Button } from '@/components/ui/button';
	import { Label } from '@/components/ui/label';
	import { Select, SelectTrigger, SelectContent, SelectItem } from '@/components/ui/select';
	import SortDesc from '@lucide/svelte/icons/arrow-down-1-0';
	import SortAsc from '@lucide/svelte/icons/arrow-up-1-0';
	import type { SortBy } from '../../../../types';
	import type { SortOrder } from '../../../../types';
	export interface SortByFiltersProps {
		sortBy: SortBy;
		sortOrder: SortOrder;
		toggleSortOrder: () => void;
	}

	const { sortBy, sortOrder, toggleSortOrder }: SortByFiltersProps = $props();
</script>

<div class="space-y-2">
	<Label class="text-sm font-medium">Sort By</Label>
	<div class="flex gap-2">
		<Select type="single">
			<SelectTrigger class="flex-1">
				{sortBy}
			</SelectTrigger>
			<SelectContent>
				<SelectItem value="rating">Rating</SelectItem>
				<SelectItem value="title">Title</SelectItem>
				<SelectItem value="releaseDate">Release Date</SelectItem>
				<SelectItem value="duration">Duration</SelectItem>
			</SelectContent>
		</Select>
		<Button
			variant="outline"
			size="icon"
			onclick={toggleSortOrder}
			title={sortOrder === 'asc' ? 'Ascending' : 'Descending'}
		>
			{#if sortOrder === 'asc'}
				<SortAsc size={16} />
			{:else}
				<SortDesc size={16} />
			{/if}
		</Button>
	</div>
</div>
