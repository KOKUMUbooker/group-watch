<script lang="ts">
	import SunIcon from '@lucide/svelte/icons/sun';
	import MoonIcon from '@lucide/svelte/icons/moon';

	import { toggleMode } from 'mode-watcher';
	import { Button } from '$lib/components/ui/button/index.js';
	import Film from '@lucide/svelte/icons/film';
</script>

<div class="fixed top-0 z-10 flex h-18 w-full items-center bg-background/80">
	<div class="flex w-full flex-row items-center justify-between px-6">
		<div class="flex flex-row items-center justify-between gap-2">
			<div class="rounded-md bg-primary/80 p-2">
				<Film />
			</div>
			<div class="text-lg font-bold">Movie manager</div>
		</div>

		<div>
			<Button onclick={toggleMode} variant="outline" size="icon">
				<SunIcon class="scale-100 rotate-0 !transition-all dark:scale-0 dark:-rotate-90" />
				<MoonIcon class="absolute scale-0 rotate-90 !transition-all dark:scale-100 dark:rotate-0" />
				<span class="sr-only">Toggle theme</span>
			</Button>
		</div>
	</div>
</div>
