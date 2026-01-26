<script lang="ts">
	import { Input } from '@/components/ui/input';
	import { Label } from '@/components/ui/label';
	import Search from '@lucide/svelte/icons/search';
	import X from '@lucide/svelte/icons/x';

	interface SearchFilterProps {
		searchQuery: string;
		handleSearch: () => void;
	}
	let { handleSearch, searchQuery }: SearchFilterProps = $props();
</script>

<div class="space-y-2">
	<Label class="text-sm font-medium">Search</Label>
	<div class="relative">
		<Input
			bind:value={searchQuery}
			placeholder="Search movies..."
			oninput={handleSearch}
			class="pl-10"
		/>
		<Search
			class="absolute top-1/2 left-3 h-4 w-4 -translate-y-1/2 transform text-muted-foreground"
		/>
		{#if searchQuery}
			<button
				onclick={() => {
					searchQuery = '';
					handleSearch();
				}}
				class="absolute top-1/2 right-3 -translate-y-1/2 transform"
			>
				<X size={16} class="text-muted-foreground hover:text-foreground" />
			</button>
		{/if}
	</div>
</div>
