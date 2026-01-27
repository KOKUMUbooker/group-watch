<!-- src/routes/dashboard/admin/home/+page.svelte -->
<script lang="ts">
	import { onMount } from 'svelte';
	import { Button } from '$lib/components/ui/button';
	import {
		Card,
		CardContent,
		CardDescription,
		CardHeader,
		CardTitle
	} from '$lib/components/ui/card';
	import { Badge } from '$lib/components/ui/badge';
	import { Separator } from '$lib/components/ui/separator';
	import { Tabs, TabsContent, TabsList, TabsTrigger } from '$lib/components/ui/tabs';
	import { Alert, AlertDescription, AlertTitle } from '$lib/components/ui/alert';
	import { Progress } from '$lib/components/ui/progress';
	import {
		Shield,
		CheckCircle,
		AlertCircle,
		Cpu,
		Database,
		Users,
		Film,
		BarChart3,
		TrendingUp,
		Clock,
		Activity,
		Zap,
		RefreshCw,
		Bell,
		Download,
		Send,
		Settings,
		Eye,
		Server,
		HardDrive,
		Network
	} from '@lucide/svelte';

	// State
	let isLoading = true;
	let stats = {
		totalMovies: 0,
		totalUsers: 0,
		pendingApprovals: 0,
		systemUptime: '99.9%',
		avgResponseTime: '124ms',
		storageUsed: '2.4GB',
		dailyActiveUsers: 0,
		newRegistrations: 0
	};

	let systemHealth = {
		api: { status: 'healthy', latency: '45ms' },
		database: { status: 'healthy', connections: 42 },
		cache: { status: 'warning', hitRate: '78%' },
		storage: { status: 'healthy', freeSpace: '85%' }
	};

	let activeAlerts = [
		{
			id: 1,
			severity: 'critical',
			title: 'Database backup failed',
			timestamp: '10 min ago',
			description: 'Scheduled backup could not complete due to disk space'
		},
		{
			id: 2,
			severity: 'warning',
			title: 'High memory usage',
			timestamp: '30 min ago',
			description: 'Server memory usage at 85%'
		},
		{
			id: 3,
			severity: 'info',
			title: 'New user registration spike',
			timestamp: '2 hours ago',
			description: '50+ new users in the last hour'
		}
	];

	let recentActivity = [
		{ id: 1, user: 'admin', action: 'approved movie', target: 'Inception', time: '5 min ago' },
		{
			id: 2,
			user: 'moderator',
			action: 'rejected review',
			target: 'Offensive content',
			time: '15 min ago'
		},
		{ id: 3, user: 'system', action: 'performed backup', target: 'Database', time: '1 hour ago' },
		{
			id: 4,
			user: 'admin',
			action: 'updated settings',
			target: 'Site configuration',
			time: '2 hours ago'
		}
	];

	let performanceMetrics = {
		cpuUsage: 45,
		memoryUsage: 78,
		diskUsage: 62,
		networkIn: '1.2 MB/s',
		networkOut: '0.8 MB/s'
	};

	onMount(async () => {
		// Simulate API call
		await new Promise((resolve) => setTimeout(resolve, 800));

		// Load mock data
		stats = {
			totalMovies: 1247,
			totalUsers: 5423,
			pendingApprovals: 12,
			systemUptime: '99.9%',
			avgResponseTime: '124ms',
			storageUsed: '2.4GB',
			dailyActiveUsers: 342,
			newRegistrations: 28
		};

		isLoading = false;
	});

	// Quick Actions
	const quickActions = [
		{
			id: 1,
			title: 'Approve All Pending',
			icon: CheckCircle,
			action: approveAllPending,
			color: 'bg-green-500'
		},
		{
			id: 2,
			title: 'Run System Cleanup',
			icon: RefreshCw,
			action: runCleanup,
			color: 'bg-blue-500'
		},
		{
			id: 3,
			title: 'Send Announcement',
			icon: Send,
			action: sendAnnouncement,
			color: 'bg-purple-500'
		},
		{
			id: 4,
			title: 'Generate Report',
			icon: Download,
			action: generateReport,
			color: 'bg-orange-500'
		},
		{ id: 5, title: 'Backup Now', icon: Database, action: backupNow, color: 'bg-indigo-500' },
		{ id: 6, title: 'View All Logs', icon: Eye, action: viewLogs, color: 'bg-gray-500' }
	];

	function approveAllPending() {
		alert('Approving all pending items...');
		stats.pendingApprovals = 0;
	}

	function runCleanup() {
		alert('Running system cleanup...');
	}

	function sendAnnouncement() {
		alert('Opening announcement composer...');
	}

	function generateReport() {
		alert('Generating weekly report...');
	}

	function backupNow() {
		alert('Starting database backup...');
	}

	function viewLogs() {
		alert('Opening system logs...');
	}

	function markAlertResolved(alertId: number) {
		activeAlerts = activeAlerts.filter((alert) => alert.id !== alertId);
	}

	function getSeverityColor(severity: string): string {
		switch (severity) {
			case 'critical':
				return 'bg-red-500';
			case 'warning':
				return 'bg-yellow-500';
			case 'info':
				return 'bg-blue-500';
			default:
				return 'bg-gray-500';
		}
	}

	function getSeverityTextColor(severity: string): string {
		switch (severity) {
			case 'critical':
				return 'text-red-500';
			case 'warning':
				return 'text-yellow-500';
			case 'info':
				return 'text-blue-500';
			default:
				return 'text-gray-500';
		}
	}
</script>

<svelte:head>
	<title>Admin Dashboard - System Overview</title>
</svelte:head>

<div class="min-h-screen bg-background">
	{#if isLoading}
		<!-- Loading State -->
		<div class="mb-8 grid grid-cols-1 gap-6 md:grid-cols-2 lg:grid-cols-4">
			{#each Array(8) as _}
				<div class="h-32 animate-pulse rounded-lg bg-muted"></div>
			{/each}
		</div>
	{:else}
		<!-- =========================================== -->
		<!-- SECTION 1: QUICK STATS & METRICS -->
		<!-- =========================================== -->
		<div class="mb-8 grid grid-cols-1 gap-6 md:grid-cols-2 lg:grid-cols-4">
			<!-- Total Movies -->
			<Card>
				<CardContent class="pt-6">
					<div class="mb-4 flex items-center justify-between">
						<div class="rounded-lg bg-blue-100 p-2 dark:bg-blue-900">
							<Film class="h-5 w-5 text-blue-600 dark:text-blue-400" />
						</div>
						<Badge variant="outline">+12%</Badge>
					</div>
					<div class="text-3xl font-bold">{stats.totalMovies.toLocaleString()}</div>
					<p class="text-sm text-muted-foreground">Total Movies</p>
					<div class="mt-2 flex items-center gap-1 text-xs text-green-500">
						<TrendingUp size={12} />
						<span>24 added this week</span>
					</div>
				</CardContent>
			</Card>

			<!-- Total Users -->
			<Card>
				<CardContent class="pt-6">
					<div class="mb-4 flex items-center justify-between">
						<div class="rounded-lg bg-green-100 p-2 dark:bg-green-900">
							<Users class="h-5 w-5 text-green-600 dark:text-green-400" />
						</div>
						<Badge variant="outline" class="bg-green-500/20 text-green-600"
							>+{stats.newRegistrations} today</Badge
						>
					</div>
					<div class="text-3xl font-bold">{stats.totalUsers.toLocaleString()}</div>
					<p class="text-sm text-muted-foreground">Total Users</p>
					<div class="mt-2 text-xs text-blue-500">
						{stats.dailyActiveUsers} active today
					</div>
				</CardContent>
			</Card>

			<!-- Pending Approvals -->
			<Card>
				<CardContent class="pt-6">
					<div class="mb-4 flex items-center justify-between">
						<div class="rounded-lg bg-orange-100 p-2 dark:bg-orange-900">
							<AlertCircle class="h-5 w-5 text-orange-600 dark:text-orange-400" />
						</div>
						<Badge variant="destructive">{stats.pendingApprovals}</Badge>
					</div>
					<div class="text-3xl font-bold">{stats.pendingApprovals}</div>
					<p class="text-sm text-muted-foreground">Pending Approvals</p>
					<Button variant="link" size="sm" class="mt-2 h-auto p-0 text-xs">Review now →</Button>
				</CardContent>
			</Card>

			<!-- System Uptime -->
			<Card>
				<CardContent class="pt-6">
					<div class="mb-4 flex items-center justify-between">
						<div class="rounded-lg bg-purple-100 p-2 dark:bg-purple-900">
							<Shield class="h-5 w-5 text-purple-600 dark:text-purple-400" />
						</div>
						<Badge variant="outline" class="bg-green-500/20 text-green-600">Healthy</Badge>
					</div>
					<div class="text-3xl font-bold">{stats.systemUptime}</div>
					<p class="text-sm text-muted-foreground">System Uptime</p>
					<div class="mt-2 flex items-center gap-1 text-xs text-muted-foreground">
						<Clock size={12} />
						<span>Avg response: {stats.avgResponseTime}</span>
					</div>
				</CardContent>
			</Card>
		</div>

		<div class="mb-8 grid grid-cols-1 gap-6 lg:grid-cols-3">
			<!-- =========================================== -->
			<!-- LEFT COLUMN: QUICK ACTIONS PANEL -->
			<!-- =========================================== -->
			<div class="lg:col-span-1">
				<Card class="h-full">
					<CardHeader>
						<CardTitle class="flex items-center gap-2">
							<Zap size={18} />
							Quick Actions
						</CardTitle>
						<CardDescription>One-click administrative tasks</CardDescription>
					</CardHeader>
					<CardContent>
						<div class="grid grid-cols-2 gap-4">
							{#each quickActions as action}
								<Button
									variant="outline"
									class="flex h-auto flex-col items-center justify-center gap-2 py-4 transition-colors hover:bg-accent"
									onclick={action.action}
								>
									<div class={`${action.color} rounded-lg p-2`}>
										<action.icon class="h-5 w-5 text-white" />
									</div>
									<span class="text-center text-sm font-medium">{action.title}</span>
								</Button>
							{/each}
						</div>

						<Separator class="my-6" />

						<!-- Storage Usage -->
						<div class="space-y-3">
							<div class="flex items-center justify-between">
								<span class="text-sm font-medium">Storage Usage</span>
								<span class="text-sm text-muted-foreground">{stats.storageUsed}</span>
							</div>
							<Progress value={65} class="h-2" />
							<div class="flex justify-between text-xs text-muted-foreground">
								<span>Movies & Media</span>
								<span>65% used</span>
							</div>
						</div>

						<!-- Recent Backups -->
						<div class="mt-6">
							<h4 class="mb-3 text-sm font-medium">Recent Backups</h4>
							<div class="space-y-2">
								<div class="flex items-center justify-between rounded p-2 text-sm hover:bg-accent">
									<span>Today, 02:00 AM</span>
									<Badge variant="outline" class="text-green-600">Successful</Badge>
								</div>
								<div class="flex items-center justify-between rounded p-2 text-sm hover:bg-accent">
									<span>Yesterday, 02:00 AM</span>
									<Badge variant="outline" class="text-green-600">Successful</Badge>
								</div>
							</div>
						</div>
					</CardContent>
				</Card>
			</div>

			<!-- =========================================== -->
			<!-- CENTER: SYSTEM HEALTH DASHBOARD -->
			<!-- =========================================== -->
			<div class="lg:col-span-2">
				<Card class="h-full">
					<CardHeader>
						<CardTitle class="flex items-center gap-2">
							<Cpu size={18} />
							System Health Monitor
						</CardTitle>
						<CardDescription>Real-time system performance and status</CardDescription>
					</CardHeader>
					<CardContent>
						<Tabs class="w-full">
							<TabsList class="mb-6 grid grid-cols-4">
								<TabsTrigger value="overview">Overview</TabsTrigger>
								<TabsTrigger value="performance">Performance</TabsTrigger>
								<TabsTrigger value="services">Services</TabsTrigger>
								<TabsTrigger value="logs">Live Logs</TabsTrigger>
							</TabsList>

							<TabsContent value="overview" class="space-y-6">
								<!-- Service Status Grid -->
								<div class="grid grid-cols-2 gap-4 md:grid-cols-4">
									{#each Object.entries(systemHealth) as [service, data]}
										<div class="rounded-lg border p-4 transition-colors hover:bg-accent">
											<div class="mb-2 flex items-center justify-between">
												{#if service === 'api'}
													<Network class="h-5 w-5 text-muted-foreground" />
												{:else if service === 'database'}
													<Database class="h-5 w-5 text-muted-foreground" />
												{:else if service === 'cache'}
													<HardDrive class="h-5 w-5 text-muted-foreground" />
												{:else}
													<Server class="h-5 w-5 text-muted-foreground" />
												{/if}
												<Badge
													variant={data.status === 'healthy'
														? 'default'
														: data.status === 'warning'
															? 'outline'
															: 'destructive'}
													class={`${
														data.status === 'healthy'
															? 'bg-green-500'
															: data.status === 'warning'
																? 'bg-yellow-500'
																: 'bg-red-500'
													}`}
												>
													{data.status}
												</Badge>
											</div>
											<h3 class="font-medium capitalize">{service}</h3>
											<!-- {#if service === 'api' }
												<p class="text-sm text-muted-foreground">Latency: {data?.latency || ''}</p>
											{:else if service === 'database'}
												<p class="text-sm text-muted-foreground">{data?.connections} connections</p>
											{:else if service === 'cache'}
												<p class="text-sm text-muted-foreground">Hit rate: {data?.hitRate}</p>
											{:else}
												<p class="text-sm text-muted-foreground">Free: {data?.freeSpace}</p>
											{/if} -->
										</div>
									{/each}
								</div>

								<!-- Performance Metrics -->
								<div class="space-y-4">
									<h4 class="font-medium">Performance Metrics</h4>
									<div class="grid grid-cols-2 gap-4 md:grid-cols-5">
										<div class="rounded-lg border p-3 text-center">
											<div class="text-2xl font-bold">{performanceMetrics.cpuUsage}%</div>
											<p class="text-xs text-muted-foreground">CPU</p>
										</div>
										<div class="rounded-lg border p-3 text-center">
											<div class="text-2xl font-bold">{performanceMetrics.memoryUsage}%</div>
											<p class="text-xs text-muted-foreground">Memory</p>
										</div>
										<div class="rounded-lg border p-3 text-center">
											<div class="text-2xl font-bold">{performanceMetrics.diskUsage}%</div>
											<p class="text-xs text-muted-foreground">Disk</p>
										</div>
										<div class="rounded-lg border p-3 text-center">
											<div class="text-lg font-bold">{performanceMetrics.networkIn}</div>
											<p class="text-xs text-muted-foreground">Network In</p>
										</div>
										<div class="rounded-lg border p-3 text-center">
											<div class="text-lg font-bold">{performanceMetrics.networkOut}</div>
											<p class="text-xs text-muted-foreground">Network Out</p>
										</div>
									</div>
								</div>
							</TabsContent>

							<TabsContent value="performance">
								<!-- Performance Charts Placeholder -->
								<div class="flex h-64 items-center justify-center rounded-lg bg-muted">
									<div class="text-center">
										<BarChart3 class="mx-auto mb-2 h-12 w-12 text-muted-foreground" />
										<p class="text-muted-foreground">Performance charts would appear here</p>
										<p class="text-sm text-muted-foreground">CPU, Memory, Disk I/O over time</p>
									</div>
								</div>
							</TabsContent>

							<TabsContent value="services">
								<!-- Services Management -->
								<div class="space-y-3">
									{#each ['Web Server', 'Database', 'Cache', 'API Gateway', 'Job Queue', 'Search Index'] as service}
										<div
											class="flex items-center justify-between rounded-lg border p-3 hover:bg-accent"
										>
											<div class="flex items-center gap-3">
												<div class="h-2 w-2 rounded-full bg-green-500"></div>
												<span>{service}</span>
											</div>
											<div class="flex items-center gap-3">
												<Badge variant="outline" class="text-green-600">Running</Badge>
												<Button variant="ghost" size="sm">Restart</Button>
											</div>
										</div>
									{/each}
								</div>
							</TabsContent>

							<TabsContent value="logs">
								<!-- Live Logs -->
								<div class="h-64 overflow-y-auto rounded-lg bg-black p-4 font-mono text-sm">
									<div class="text-green-400">[INFO] System started successfully</div>
									<div class="text-blue-400">[DEBUG] Database connection established</div>
									<div class="text-yellow-400">[WARN] Cache hit rate below threshold</div>
									<div class="text-green-400">[INFO] 5 new movies added</div>
									<div class="text-green-400">[INFO] User session created</div>
									<div class="text-blue-400">[DEBUG] API request processed in 45ms</div>
									<div class="text-green-400">[INFO] Backup scheduled for 02:00 AM</div>
									<div class="text-yellow-400">[WARN] Memory usage at 85%</div>
									<div class="text-green-400">[INFO] 28 new user registrations today</div>
								</div>
							</TabsContent>
						</Tabs>
					</CardContent>
				</Card>
			</div>
		</div>

		<div class="grid grid-cols-1 gap-6 lg:grid-cols-3">
			<!-- =========================================== -->
			<!-- RIGHT COLUMN: ACTIVE ALERTS & NOTIFICATIONS -->
			<!-- =========================================== -->
			<div class="lg:col-span-2">
				<Card>
					<CardHeader>
						<div class="flex items-center justify-between">
							<CardTitle class="flex items-center gap-2">
								<Bell size={18} />
								Active Alerts
								{#if activeAlerts.length > 0}
									<Badge variant="destructive" class="ml-2">{activeAlerts.length}</Badge>
								{/if}
							</CardTitle>
							<Button variant="ghost" size="sm">View All</Button>
						</div>
						<CardDescription>Critical system notifications requiring attention</CardDescription>
					</CardHeader>
					<CardContent>
						{#if activeAlerts.length === 0}
							<div class="py-8 text-center">
								<CheckCircle class="mx-auto mb-3 h-12 w-12 text-green-500" />
								<h3 class="font-medium">No Active Alerts</h3>
								<p class="text-sm text-muted-foreground">All systems are functioning normally</p>
							</div>
						{:else}
							<div class="space-y-4">
								{#each activeAlerts as alert}
									<Alert
										variant={alert.severity === 'critical'
											? 'destructive'
											: alert.severity === 'warning'
												? 'default'
												: 'default'}
									>
										<AlertCircle class="h-4 w-4" />
										<AlertTitle class="flex items-start justify-between">
											<span>{alert.title}</span>
											<span class="text-xs font-normal text-muted-foreground"
												>{alert.timestamp}</span
											>
										</AlertTitle>
										<AlertDescription class="mt-2">
											<p>{alert.description}</p>
											<div class="mt-3 flex gap-2">
												<Button
													variant={alert.severity === 'critical' ? 'destructive' : 'outline'}
													size="sm"
													onclick={() => markAlertResolved(alert.id)}
												>
													Mark Resolved
												</Button>
												<Button variant="ghost" size="sm">View Details</Button>
											</div>
										</AlertDescription>
									</Alert>
								{/each}
							</div>
						{/if}

						<!-- Alert History -->
						<Separator class="my-6" />
						<div>
							<h4 class="mb-3 font-medium">Recent Resolved Alerts</h4>
							<div class="space-y-2">
								{#each [{ title: 'API rate limit warning', time: '3 hours ago', status: 'resolved' }, { title: 'Database optimization needed', time: '5 hours ago', status: 'resolved' }, { title: 'SSL certificate expiring', time: '1 day ago', status: 'resolved' }] as alert}
									<div
										class="flex items-center justify-between rounded p-2 text-sm hover:bg-accent"
									>
										<span class="truncate">{alert.title}</span>
										<div class="flex items-center gap-2">
											<span class="text-xs text-muted-foreground">{alert.time}</span>
											<Badge variant="outline" class="text-green-600">Resolved</Badge>
										</div>
									</div>
								{/each}
							</div>
						</div>
					</CardContent>
				</Card>
			</div>

			<!-- =========================================== -->
			<!-- BOTTOM RIGHT: RECENT ACTIVITY -->
			<!-- =========================================== -->
			<div class="lg:col-span-1">
				<Card class="h-full">
					<CardHeader>
						<CardTitle class="flex items-center gap-2">
							<Activity size={18} />
							Recent Activity
						</CardTitle>
						<CardDescription>Latest system and admin actions</CardDescription>
					</CardHeader>
					<CardContent>
						<div class="space-y-4">
							{#each recentActivity as activity}
								<div class="flex items-start gap-3">
									<div class="mt-1">
										{#if activity.action.includes('approved')}
											<CheckCircle class="h-4 w-4 text-green-500" />
										{:else if activity.action.includes('rejected')}
											<AlertCircle class="h-4 w-4 text-red-500" />
										{:else}
											<Settings class="h-4 w-4 text-blue-500" />
										{/if}
									</div>
									<div class="min-w-0 flex-1">
										<div class="flex justify-between">
											<span class="truncate text-sm font-medium">{activity.user}</span>
											<span class="text-xs text-muted-foreground">{activity.time}</span>
										</div>
										<p class="text-sm text-muted-foreground">
											{activity.action}
											<span class="font-medium text-foreground">{activity.target}</span>
										</p>
									</div>
								</div>
							{/each}
						</div>

						<Separator class="my-6" />

						<!-- Quick Stats -->
						<div class="space-y-4">
							<div class="flex items-center justify-between">
								<span class="text-sm font-medium">Today's Overview</span>
								<Badge variant="outline">{new Date().toLocaleDateString()}</Badge>
							</div>

							<div class="grid grid-cols-2 gap-3">
								<div class="rounded-lg border p-3 text-center">
									<div class="text-xl font-bold">42</div>
									<p class="text-xs text-muted-foreground">Movies Added</p>
								</div>
								<div class="rounded-lg border p-3 text-center">
									<div class="text-xl font-bold">156</div>
									<p class="text-xs text-muted-foreground">Reviews Written</p>
								</div>
								<div class="rounded-lg border p-3 text-center">
									<div class="text-xl font-bold">892</div>
									<p class="text-xs text-muted-foreground">Page Views</p>
								</div>
								<div class="rounded-lg border p-3 text-center">
									<div class="text-xl font-bold">78%</div>
									<p class="text-xs text-muted-foreground">User Engagement</p>
								</div>
							</div>
						</div>

						<Button variant="outline" class="mt-6 w-full">
							<Activity class="mr-2" size={16} />
							View Full Activity Log
						</Button>
					</CardContent>
				</Card>
			</div>
		</div>
	{/if}
</div>
