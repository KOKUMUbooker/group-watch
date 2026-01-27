<script lang="ts">
	import * as Sidebar from '$lib/components/ui/sidebar/index.js';
	import type { ComponentProps } from 'svelte';
	import { type NavItem } from './dashboard-routes';
	import NavMain from './nav-main.svelte';
	import NavUser from './nav-user.svelte';

	// interface NavItem {
	// 	title: string;
	// 	url: string;
	// 	icon: Component<IconProps, {}, "">,
	// 	isActive: boolean,
	// }
	interface AppSidebarProps extends ComponentProps<typeof Sidebar.Root> {
		navItems: NavItem[];
	}

	let { navItems, ref = $bindable(null), ...restProps }: AppSidebarProps = $props();
	const data = {
		user: {
			name: 'shadcn',
			email: 'm@example.com',
			avatar: '/avatars/shadcn.jpg'
		}
	};
</script>

<Sidebar.Root bind:ref variant="inset" {...restProps} class="mt-16 max-h-[92vh]">
	<Sidebar.Content>
		<NavMain items={navItems} />
	</Sidebar.Content>
	<Sidebar.Footer>
		<NavUser user={data.user} />
	</Sidebar.Footer>
</Sidebar.Root>
