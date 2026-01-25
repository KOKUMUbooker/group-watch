<!-- src/lib/components/ui/LoadingSpinner.svelte -->
<script lang="ts">
	type Size = 'sm' | 'md' | 'lg';
	export let size = 'md';
	export let text = 'Loading...';

	const sizeClasses = {
		sm: 'w-6 h-6',
		md: 'w-8 h-8',
		lg: 'w-12 h-12'
	};
</script>

<div class="flex flex-col items-center justify-center gap-4">
	<svg
		class={`animate-spin ${sizeClasses[size as Size] || sizeClasses.md} text-primary`}
		xmlns="http://www.w3.org/2000/svg"
		fill="none"
		viewBox="0 0 24 24"
	>
		<circle class="opacity-25" cx="12" cy="12" r="10" stroke="currentColor" stroke-width="4" />
		<path
			class="opacity-75"
			fill="currentColor"
			d="M4 12a8 8 0 018-8V0C5.373 0 0 5.373 0 12h4zm2 5.291A7.962 7.962 0 014 12H0c0 3.042 1.135 5.824 3 7.938l3-2.647z"
		/>
	</svg>
	{#if text}
		<p class="text-muted-foreground">{text}</p>
	{/if}
</div>
