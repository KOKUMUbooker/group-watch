<script lang="ts">
	import './layout.css';
	import favicon from '$lib/assets/favicon.svg';
  	import { ModeWatcher } from "mode-watcher";
	import Header from '@/components/common/Header.svelte';

	let { children } = $props();
</script>

<svelte:head><link rel="icon" href={favicon} /></svelte:head>
<!-- <div class="mb-4"> -->
	<Header/>
<!-- </div> -->
<ModeWatcher />
{@render children()}
