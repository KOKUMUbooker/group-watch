<script lang="ts">
	import { Badge } from '$lib/components/ui/badge';
	import { Button } from '$lib/components/ui/button';
	import { Card, CardContent, CardHeader, CardTitle } from '$lib/components/ui/card';
	import { Progress } from '$lib/components/ui/progress';
	import Footer from '@/components/common/Footer.svelte';
	import {
		ArrowRight,
		Calendar,
		CalendarDays,
		CheckCircle,
		Film,
		Globe,
		Link,
		Mail,
		MessageSquare,
		Play,
		Share2,
		Smartphone,
		Sparkles,
		ThumbsDown,
		ThumbsUp,
		Users,
		Vote,
		XCircle,
		Zap
	} from '@lucide/svelte';

	// Active step state
	let activeStep = 0;

	const steps = [
		{
			id: 'create',
			title: 'Create & Invite',
			description: 'Start a group and invite friends',
			icon: Users,
			color: 'from-blue-500/20 to-blue-500/5',
			details: [
				'Create a group with a custom name and description',
				'Set group preferences and rules',
				'Invite friends via link, email, or social media',
				'Friends join instantly—no account required to vote'
			]
		},
		{
			id: 'suggest',
			title: 'Suggest Movies',
			description: 'Add movies to your watchlist',
			icon: Film,
			color: 'from-purple-500/20 to-purple-500/5',
			details: [
				'Search from millions of movies in our database',
				'Add movies with posters and streaming info',
				'Include trailers and ratings',
				'Add notes about why you want to watch'
			]
		},
		{
			id: 'vote',
			title: 'Vote Together',
			description: 'Vote and discuss options',
			icon: Vote,
			color: 'from-primary/20 to-primary/5',
			details: [
				'Real-time voting with live updates',
				'Thumbs up/down voting system',
				'One veto power per member',
				'See voting results instantly'
			]
		},
		{
			id: 'schedule',
			title: 'Find Time',
			description: 'Schedule your movie night',
			icon: Calendar,
			color: 'from-green-500/20 to-green-500/5',
			details: [
				'Check member availability with timezone support',
				'Calendar integration (Google, Outlook, Apple)',
				'Auto-suggest optimal times',
				'Set reminders and notifications'
			]
		},
		{
			id: 'watch',
			title: 'Watch Together',
			description: 'Sync up and enjoy',
			icon: Play,
			color: 'from-orange-500/20 to-orange-500/5',
			details: [
				'Get streaming links for everyone',
				'Sync playback across services',
				'In-watch chat and reactions',
				'Post-watch discussions and ratings'
			]
		}
	];

	const votingSystem = {
		upvote: {
			icon: ThumbsUp,
			title: 'Thumbs Up',
			description: 'Show you want to watch it',
			color: 'text-green-500 bg-green-500/10'
		},
		downvote: {
			icon: ThumbsDown,
			title: 'Thumbs Down',
			description: 'Prefer other options',
			color: 'text-red-500 bg-red-500/10'
		},
		veto: {
			icon: XCircle,
			title: 'Veto Power',
			description: 'Absolute no for one movie',
			color: 'text-orange-500 bg-orange-500/10'
		}
	};

	const faqs = [
		{
			question: 'Do friends need an account to vote?',
			answer:
				'No! Friends can vote via invite link without creating an account. Only group creators need accounts.'
		},
		{
			question: 'How many people can join a group?',
			answer: 'Free groups support up to 10 members. Pro plans allow unlimited members.'
		},
		{
			question: 'Does it work with all streaming services?',
			answer: 'Yes! We support Netflix, Hulu, Amazon Prime, Disney+, HBO Max, Apple TV+, and more.'
		},
		{
			question: 'Can I use it for virtual watch parties?',
			answer: 'Absolutely! We integrate with Teleparty and Scener for synchronized viewing.'
		},
		{
			question: 'Is there a mobile app?',
			answer: 'Our web app works great on mobile browsers. Native apps are coming soon!'
		}
	];

	function nextStep() {
		activeStep = (activeStep + 1) % steps.length;
	}

	function prevStep() {
		activeStep = (activeStep - 1 + steps.length) % steps.length;
	}
</script>

<div class="min-h-screen bg-background">
	<!-- Hero Section -->
	<section class="relative px-4 pt-16 pb-24">
		<div class="absolute inset-0 -z-10 overflow-hidden">
			<div class="absolute -top-40 right-1/4 h-64 w-64 rounded-full bg-primary/10 blur-3xl" />
			<div class="absolute -bottom-40 left-1/4 h-64 w-64 rounded-full bg-secondary/10 blur-3xl" />
		</div>

		<div class="container mx-auto max-w-6xl text-center">
			<Badge class="mb-6 border-primary/20 bg-primary/10 px-4 py-1.5 text-sm text-primary">
				<Sparkles class="mr-1.5 h-3.5 w-3.5" />
				How It Works
			</Badge>

			<h1 class="mb-6 text-4xl font-bold tracking-tight sm:text-5xl md:text-6xl">
				From "What should we watch?" <br />
				<span class="text-primary">to "Let's press play!"</span>
			</h1>

			<p class="mx-auto mb-10 max-w-3xl text-xl text-muted-foreground">
				Planning group movie nights doesn't have to be painful. Here's how GroupWatch makes it easy,
				fair, and fun for everyone.
			</p>

			<div class="flex justify-center gap-4">
				<Button size="lg" class="rounded-full">
					Start Your First Group
					<ArrowRight class="ml-2 h-5 w-5" />
				</Button>
			</div>
		</div>
	</section>

	<!-- Interactive Steps -->
	<section class="px-4 py-12">
		<div class="container mx-auto max-w-6xl">
			<div class="mb-12 text-center">
				<h2 class="mb-4 text-3xl font-bold">The 5-Step Process</h2>
				<p class="mx-auto max-w-2xl text-lg text-muted-foreground">
					Follow these simple steps to go from planning to watching
				</p>
			</div>

			<!-- Step Navigation -->
			<div class="mb-12">
				<div class="flex flex-wrap justify-center gap-4">
					{#each steps as step, i}
						<button
							onclick={() => (activeStep = i)}
							class={`flex items-center gap-3 rounded-xl px-6 py-4 transition-all duration-300 ${activeStep === i ? 'bg-primary text-primary-foreground shadow-lg' : 'bg-card hover:bg-muted'}`}
						>
							<step.icon class="h-5 w-5" />
							<div class="text-left">
								<div class="text-sm font-medium">Step {i + 1}</div>
								<div class="font-semibold">{step.title}</div>
							</div>
						</button>
					{/each}
				</div>
			</div>

			<!-- Active Step Content -->
			<div class="grid items-center gap-8 lg:grid-cols-2">
				<div class="space-y-6">
					<div class="inline-flex items-center gap-2 rounded-full bg-primary/10 px-4 py-2">
						<div
							class="flex h-8 w-8 items-center justify-center rounded-full bg-primary text-primary-foreground"
						>
							{activeStep + 1}
						</div>
						<span class="font-semibold text-primary">{steps[activeStep].title}</span>
					</div>

					<h3 class="text-3xl font-bold">{steps[activeStep].description}</h3>

					<ul class="space-y-4">
						{#each steps[activeStep].details as detail}
							<li class="flex items-start gap-3">
								<CheckCircle class="mt-0.5 h-5 w-5 flex-shrink-0 text-primary" />
								<span>{detail}</span>
							</li>
						{/each}
					</ul>

					<div class="flex gap-4 pt-4">
						<Button onclick={prevStep} variant="outline">Previous Step</Button>
						<Button onclick={nextStep}>
							Next: {steps[(activeStep + 1) % steps.length].title}
							<ArrowRight class="ml-2 h-4 w-4" />
						</Button>
					</div>
				</div>

				<div class="relative">
					<div
						class={`absolute inset-0 rounded-3xl ${steps[activeStep].color} opacity-50 blur-2xl`}
					/>
					<div class="relative rounded-2xl border border-border bg-card p-8 shadow-xl">
						{#if activeStep === 0}
							<!-- Create Group Mockup -->
							<div class="space-y-6">
								<div class="rounded-lg border border-border p-6">
									<div class="mb-4">
										<div class="mb-1 text-sm text-muted-foreground">Group Name</div>
										<div class="text-xl font-bold">Friday Film Club</div>
									</div>
									<div class="flex gap-4">
										<div class="flex-1">
											<div class="mb-1 text-sm text-muted-foreground">Invite Link</div>
											<div
												class="flex items-center gap-2 rounded-lg border border-border bg-muted px-4 py-2"
											>
												<Link class="h-4 w-4" />
												<span class="font-mono text-sm">groupwatch.app/fridayclub</span>
											</div>
										</div>
										<Button size="sm">
											<Share2 class="mr-2 h-4 w-4" />
											Share
										</Button>
									</div>
								</div>
								<div class="grid grid-cols-2 gap-4">
									<Button variant="outline" class="h-auto py-4">
										<Mail class="mr-2 h-5 w-5" />
										Invite via Email
									</Button>
									<Button variant="outline" class="h-auto py-4">
										<Smartphone class="mr-2 h-5 w-5" />
										Share to Group Chat
									</Button>
								</div>
							</div>
						{:else if activeStep === 1}
							<!-- Suggest Movies Mockup -->
							<div class="space-y-4">
								<div class="rounded-lg border border-border p-4">
									<div class="flex items-center gap-4">
										<div
											class="h-16 w-12 rounded bg-gradient-to-b from-primary/20 to-secondary/20"
										/>
										<div class="flex-1">
											<div class="font-semibold">Dune: Part Two</div>
											<div class="text-sm text-muted-foreground">2024 • Sci-Fi • 2h 46m</div>
											<div class="mt-2 flex gap-2">
												<Badge class="text-xs">Netflix</Badge>
												<Badge class="text-xs">Prime</Badge>
											</div>
										</div>
										<Button size="sm">Add</Button>
									</div>
								</div>
								<div class="rounded-lg border border-border p-4 opacity-60">
									<div class="flex items-center gap-4">
										<div
											class="h-16 w-12 rounded bg-gradient-to-b from-primary/20 to-secondary/20"
										/>
										<div class="flex-1">
											<div class="font-semibold">Poor Things</div>
											<div class="text-sm text-muted-foreground">2023 • Comedy • 2h 21m</div>
											<div class="mt-2 flex gap-2">
												<Badge class="text-xs">Hulu</Badge>
											</div>
										</div>
										<Button size="sm" variant="outline">Added</Button>
									</div>
								</div>
							</div>
						{:else if activeStep === 2}
							<!-- Voting Mockup -->
							{#each [{ title: 'Dune: Part Two', votes: 5, userVote: 'up' }, { title: 'Poor Things', votes: 3, userVote: null }, { title: 'The Holdovers', votes: 2, userVote: 'down' }, { title: 'Past Lives', votes: 0, userVote: null, vetoed: true }] as movie}
								<div
									class={`rounded-lg border p-4 ${movie.vetoed ? 'border-destructive/30 bg-destructive/5' : 'border-border'}`}
								>
									<div class="mb-3 flex items-center justify-between">
										<span class="font-medium">{movie.title}</span>
										<div class="flex items-center gap-2">
											{#if movie.vetoed}
												<Badge variant="destructive">Vetoed</Badge>
											{:else}
												<div class="flex items-center gap-1">
													<ThumbsUp class="h-4 w-4 text-green-500" />
													<span class="font-semibold">{movie.votes}</span>
												</div>
											{/if}
										</div>
									</div>
									<div class="flex gap-2">
										<Button
											size="sm"
											variant={movie.userVote === 'up' ? 'default' : 'outline'}
											class="flex-1"
										>
											<ThumbsUp class="mr-2 h-4 w-4" />
											Up
										</Button>
										<Button
											size="sm"
											variant={movie.userVote === 'down' ? 'default' : 'outline'}
											class="flex-1"
										>
											<ThumbsDown class="mr-2 h-4 w-4" />
											Down
										</Button>
										<Button
											size="sm"
											variant={movie.vetoed ? 'destructive' : 'outline'}
											class="flex-1"
										>
											<XCircle class="mr-2 h-4 w-4" />
											Veto
										</Button>
									</div>
								</div>
							{/each}
						{:else if activeStep === 3}
							<!-- Scheduling Mockup -->
							<div class="space-y-6">
								<div class="flex items-center justify-between">
									<div>
										<div class="font-semibold">This Week</div>
										<div class="text-sm text-muted-foreground">Feb 12 - 18</div>
									</div>
									<div class="flex items-center gap-2">
										<CalendarDays class="h-4 w-4" />
										<span class="text-sm font-medium">Time Zones: EST, PST, GMT</span>
									</div>
								</div>
								<div class="grid grid-cols-3 gap-2">
									{#each ['Wed', 'Thu', 'Fri', 'Sat', 'Sun', 'Mon'] as day, i}
										<div class="text-center">
											<div class="mb-2 text-sm font-medium">{day}</div>
											<div class="space-y-1">
												{#each ['6pm', '8pm', '9:30pm'] as time}
													<div
														class={`rounded-lg border px-3 py-2 text-xs ${i === 3 && time === '8pm' ? 'border-primary bg-primary/10' : 'border-border'}`}
													>
														{time}
													</div>
												{/each}
											</div>
										</div>
									{/each}
								</div>
							</div>
						{:else}
							<!-- Watch Together Mockup -->
							<div class="space-y-6">
								<div
									class="rounded-lg bg-gradient-to-r from-primary/20 to-secondary/20 p-6 text-center"
								>
									<div class="mb-2 text-3xl font-bold">8:00 PM</div>
									<div class="text-muted-foreground">Tonight's Movie Time</div>
								</div>
								<div class="grid grid-cols-2 gap-4">
									<div class="rounded-lg border border-border p-4">
										<div class="flex items-center gap-3">
											<Globe class="h-5 w-5 text-primary" />
											<div>
												<div class="font-semibold">Streaming On</div>
												<div class="text-sm text-muted-foreground">Netflix, Prime</div>
											</div>
										</div>
									</div>
									<div class="rounded-lg border border-border p-4">
										<div class="flex items-center gap-3">
											<MessageSquare class="h-5 w-5 text-primary" />
											<div>
												<div class="font-semibold">Live Chat</div>
												<div class="text-sm text-muted-foreground">Ready to go</div>
											</div>
										</div>
									</div>
								</div>
								<Button class="w-full" size="lg">
									<Play class="mr-2 h-5 w-5" />
									Start Watch Party
								</Button>
							</div>
						{/if}
					</div>
				</div>
			</div>
		</div>
	</section>

	<!-- Voting System Deep Dive -->
	<section id="voting" class="bg-muted/30 px-4 py-20">
		<div class="container mx-auto max-w-6xl">
			<div class="mb-12 text-center">
				<h2 class="mb-4 text-3xl font-bold">Fair Voting System</h2>
				<p class="mx-auto max-w-2xl text-lg text-muted-foreground">
					Designed to respect everyone's opinion while making decisions easy
				</p>
			</div>

			<div class="mb-12 grid gap-6 md:grid-cols-3">
				{#each Object.entries(votingSystem) as [key, system]}
					<Card class="text-center">
						<CardHeader>
							<div
								class={`mx-auto mb-4 inline-flex h-12 w-12 items-center justify-center rounded-full ${system.color}`}
							>
								<system.icon class="h-6 w-6" />
							</div>
							<CardTitle>{system.title}</CardTitle>
						</CardHeader>
						<CardContent>
							<p class="text-sm text-muted-foreground">{system.description}</p>
						</CardContent>
					</Card>
				{/each}
			</div>

			<div class="rounded-2xl border border-border bg-card p-8">
				<div class="grid items-center gap-8 lg:grid-cols-2">
					<div>
						<h3 class="mb-4 text-2xl font-bold">How We Calculate Winners</h3>
						<p class="mb-6 text-muted-foreground">
							Our algorithm balances majority preference with individual veto power to ensure nobody
							has to watch something they hate.
						</p>
						<ul class="space-y-3">
							{#each ['Movies with vetoes are automatically removed', 'Movies sorted by net votes (upvotes - downvotes)', 'Ties broken by number of upvotes', 'If no consensus, we suggest top 3 for group chat discussion'] as item}
								<li class="flex items-center gap-3">
									<CheckCircle class="h-5 w-5 text-primary" />
									<span>{item}</span>
								</li>
							{/each}
						</ul>
					</div>
					<div class="rounded-lg bg-muted p-6">
						<div class="mb-4 font-semibold">Live Voting Results</div>
						<div class="space-y-4">
							{#each [{ movie: 'Dune: Part Two', up: 5, down: 1, veto: false, percent: 85 }, { movie: 'Poor Things', up: 3, down: 0, veto: false, percent: 60 }, { movie: 'The Holdovers', up: 2, down: 2, veto: false, percent: 40 }, { movie: 'Past Lives', up: 1, down: 0, veto: true, percent: 0 }] as result}
								<div>
									<div class="mb-1 flex justify-between">
										<span
											class={`text-sm ${result.veto ? 'text-muted-foreground line-through' : ''}`}
										>
											{result.movie}
										</span>
										<span class="text-sm font-medium">{result.percent}%</span>
									</div>
									<Progress value={result.percent} class="h-2" />
									<div class="mt-1 flex justify-between text-xs text-muted-foreground">
										<span>↑ {result.up} • ↓ {result.down}</span>
										{#if result.veto}
											<span class="text-destructive">Vetoed</span>
										{/if}
									</div>
								</div>
							{/each}
						</div>
					</div>
				</div>
			</div>
		</div>
	</section>

	<!-- FAQ Section -->
	<section id="faq" class="px-4 py-20">
		<div class="container mx-auto max-w-4xl">
			<div class="mb-12 text-center">
				<h2 class="mb-4 text-3xl font-bold">Frequently Asked Questions</h2>
				<p class="mx-auto max-w-2xl text-lg text-muted-foreground">
					Everything you need to know about GroupWatch
				</p>
			</div>

			<div class="space-y-4">
				{#each faqs as faq}
					<Card>
						<CardContent class="p-6">
							<div class="flex items-start gap-4">
								<div
									class="mt-1 flex h-6 w-6 items-center justify-center rounded-full bg-primary/10"
								>
									<Zap class="h-3 w-3 text-primary" />
								</div>
								<div class="flex-1">
									<h3 class="mb-2 text-lg font-semibold">{faq.question}</h3>
									<p class="text-muted-foreground">{faq.answer}</p>
								</div>
							</div>
						</CardContent>
					</Card>
				{/each}
			</div>
		</div>
	</section>

	<!-- Final CTA -->
	<section class="px-4 py-20">
		<div class="container mx-auto max-w-4xl text-center">
			<Card class="border-primary/20 bg-gradient-to-b from-background to-primary/5">
				<CardContent class="p-12">
					<div
						class="mx-auto mb-6 inline-flex h-16 w-16 items-center justify-center rounded-full bg-primary"
					>
						<Play class="h-8 w-8 text-primary-foreground" />
					</div>
					<h2 class="mb-4 text-3xl font-bold">Ready to simplify your movie nights?</h2>
					<p class="mx-auto mb-8 max-w-2xl text-lg text-muted-foreground">
						Join thousands of groups using GroupWatch to plan perfect movie nights.
					</p>
					<div class="flex flex-col justify-center gap-4 sm:flex-row">
						<Button size="lg" class="h-14 px-8 text-base">
							Create Your First Group
							<ArrowRight class="ml-2 h-5 w-5" />
						</Button>
						<Button size="lg" variant="outline" class="h-14 px-8">Contact Sales (Teams)</Button>
					</div>
					<p class="mt-6 text-sm text-muted-foreground">
						No credit card required • Free forever for personal use
					</p>
				</CardContent>
			</Card>
		</div>
	</section>

	<Footer />
</div>

<style>
	/* Smooth scrolling for anchor links */
	html {
		scroll-behavior: smooth;
	}

	/* Step transition animation */
	.step-transition {
		transition: all 0.3s ease;
	}

	/* Pulse animation for active step */
	@keyframes pulse-glow {
		0%,
		100% {
			box-shadow: 0 0 0 0 rgba(var(--primary), 0.4);
		}
		50% {
			box-shadow: 0 0 0 10px rgba(var(--primary), 0);
		}
	}

	.pulse-glow {
		animation: pulse-glow 2s infinite;
	}
</style>
