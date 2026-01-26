<script lang="ts">
	import { Button } from '@/components/ui/button';
	import { CardContent } from '@/components/ui/card';
	import RefreshCw from '@lucide/svelte/icons/refresh-cw';
	import DurationFilter, { type DurationFiltersProps } from './duration-filter.svelte';
	import GenreFilter, { type GenreFiltersProps } from './genre-filter.svelte';
	import RatingRangeFilter, { type RatingRangeFilterProps } from './rating-range-filter.svelte';
	import SearchFilter, { type SearchFilterProps } from './search-filter.svelte';
	import SortByFilter, { type SortByFiltersProps } from './sort-by-filter.svelte';
	import YearRangeFilter, { type YearRangeFilterProps } from './year-range-filter.svelte';
	interface FilterContentProps
		extends
			GenreFiltersProps,
			DurationFiltersProps,
			RatingRangeFilterProps,
			SearchFilterProps,
			SortByFiltersProps,
			YearRangeFilterProps {
		clearFilters: () => void;
		isFilterOpen: boolean;
	}

	let cmpProps: FilterContentProps = $props();
	let { filteredMovies, handleSearch, ratingRange, searchQuery } = cmpProps;
	let { toggleGenre, toggleSortOrder, updateFilters, yearRange } = cmpProps;
	let { selectedGenres, sortBy, sortOrder, clearFilters, isFilterOpen } = cmpProps;
</script>

<CardContent class="space-y-6">
	<!-- Search -->
	<SearchFilter {handleSearch} {searchQuery} />

	<!-- Sort -->
	<SortByFilter {sortBy} {sortOrder} {toggleSortOrder} />

	<!-- Genres -->
	<GenreFilter {selectedGenres} {toggleGenre} />

	<!-- Year Range -->
	<YearRangeFilter {updateFilters} {yearRange} />

	<!-- Rating Range -->
	<RatingRangeFilter {ratingRange} {updateFilters} />

	<!-- Duration Filter -->
	<DurationFilter {filteredMovies} {updateFilters} />

	<!-- Action Buttons -->
	<div class="space-y-2 border-t border-border pt-4">
		<Button variant="outline" class="w-full gap-2" onclick={clearFilters}>
			<RefreshCw size={16} />
			Reset Filters
		</Button>
		<Button class="w-full" onclick={() => (isFilterOpen = false)}>Apply Filters</Button>
	</div>
</CardContent>
