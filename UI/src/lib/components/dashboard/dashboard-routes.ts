// data/dashboardRoutes.ts
import {
	BarChart3,
	Film,
	LayoutDashboard,
	MessageSquare,
	Settings,
	Shield,
	User,
	Users,
} from '@lucide/svelte';
import type { Component } from 'svelte';

export interface NavItem {
	title: string;
	url: string;
	icon: Component;
}

// ============================================================================
// ADMIN DASHBOARD - 8 Single Tabs with Comprehensive Content
// ============================================================================

export const adminDashboardRoutes: NavItem[] = [
	// 1. DASHBOARD & ANALYTICS TAB
	// Single page containing: Overview stats, Quick Actions panel, System Health monitor, Active Alerts
	{
		title: 'Admin Dashboard',
		url: '/dashboard/admin/home',
		icon: Shield,
	},

	// 2. MOVIE MANAGEMENT TAB
	// Single page containing: All movies table, Pending approvals, Moderation queue, Media library
	{
		title: 'Movie Management',
		url: '/dashboard/admin/movies',
		icon: Film,
	},

	// 3. USER & ROLE MANAGEMENT TAB
	// Single page containing: User list, Role management, User activity logs
	{
		title: 'User Management',
		url: '/dashboard/admin/users',
		icon: Users,
	},

	// 4. ANALYTICS & REPORTS TAB
	// Single page containing: System analytics, Performance metrics, Reports generator, Audit log
	{
		title: 'Analytics & Reports',
		url: '/dashboard/admin/analytics',
		icon: BarChart3,
	},

	// 5. SYSTEM SETTINGS TAB
	// Single page containing: General settings, Content settings, User settings, Database tools, Backup, Advanced config
	{
		title: 'System Settings',
		url: '/dashboard/admin/settings',
		icon: Settings,
	},

	// 6. ADMIN PROFILE TAB
	// Single page containing: Personal profile, Admin settings, Personal activity log
	{
		title: 'My Admin Profile',
		url: '/dashboard/admin/profile',
		icon: User,
	},
];

// ============================================================================
// USER DASHBOARD - 5 Single Tabs with Comprehensive Content
// ============================================================================

export const userDashboardRoutes: NavItem[] = [
	// 1. USER DASHBOARD TAB
	// Single page containing: Overview, Personal stats, Recent activity, Notifications
	{
		title: 'My Dashboard',
		url: '/dashboard/home',
		icon: LayoutDashboard,

	},

	// 2. MOVIES COLLECTION TAB
	// Single page containing: Add movie form, My collection, Watchlist, Custom lists
	{
		title: 'My Movies',
		url: '/dashboard/movies',
		icon: Film,

	},

	// 3. REVIEWS & RATINGS TAB
	// Single page containing: My reviews, My ratings, Drafts, Liked reviews
	{
		title: 'My Reviews',
		url: '/dashboard/reviews',
		icon: MessageSquare,

	},

	// // 4. SOCIAL & COMMUNITY TAB
	// // Single page containing: Following, Followers, Community feed, Messages
	// {
	// 	title: 'Social',
	// 	url: '/dashboard/social',
	// 	icon: Users,
	// },

	// 5. ACCOUNT SETTINGS TAB
	// Single page containing: Profile, Account settings, Notifications, Privacy, Preferences
	{
		title: 'Settings',
		url: '/dashboard/settings',
		icon: Settings,
	},
];

export const getIsActive = (url: string, currentPath: string): boolean => {
	if (url === '/dashboard') {
		return currentPath === '/dashboard' || currentPath === '/dashboard/';
	}
	return currentPath.startsWith(url);
};

/**
 * Get all routes for a specific role with active state
 */
export function getUserRoutes(currentPath: string = ''): NavItem[] {
	return userDashboardRoutes.map(r => ({
		...r,
		isActive: currentPath === r.url || currentPath.startsWith(r.url + '/')
	}));
}

export function getAdminRoutes(currentPath: string = ''): NavItem[] {
	return adminDashboardRoutes.map(r => ({
		...r,
		isActive: currentPath === r.url || currentPath.startsWith(r.url + '/')
	}));
}

/**
 * Get the page title for the current route
 */
export function getPageTitle(path: string, isAdmin: boolean): string {
	const routes = isAdmin ? adminDashboardRoutes : userDashboardRoutes;
	const route = routes.find(r => path === r.url || path.startsWith(r.url + '/'));
	return route?.title || 'Dashboard';
}

/**
 * Check if a route requires admin privileges
 */
export function isAdminRoute(path: string): boolean {
	return adminDashboardRoutes.some(r => path === r.url || path.startsWith(r.url + '/'));
}

/**
 * Get the breadcrumb trail for current path
 */
export function getBreadcrumbs(path: string, isAdmin: boolean): Array<{ title: string; url: string }> {
	const routes = isAdmin ? adminDashboardRoutes : userDashboardRoutes;
	const breadcrumbs = [{ title: 'Dashboard', url: '/dashboard' }];

	// Find matching route
	const route = routes.find(r => path === r.url || path.startsWith(r.url + '/'));
	if (route && route.url !== '/dashboard') {
		breadcrumbs.push({ title: route.title, url: route.url });
	}

	return breadcrumbs;
}