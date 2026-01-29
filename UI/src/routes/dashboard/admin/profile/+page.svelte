<!-- src/routes/dashboard/admin-profile/+page.svelte -->
<script lang="ts">
  import {
  	Activity,
  	Bell,
  	Camera,
  	Eye,
  	EyeOff,
  	Film,
  	Globe,
  	Key,
  	Lock,
  	Mail,
  	Save,
  	Shield,
  	User
  } from '@lucide/svelte';
  
  import { Badge } from '$lib/components/ui/badge';
  import { Button } from '$lib/components/ui/button';
  import { Card, CardContent, CardDescription, CardHeader, CardTitle } from '$lib/components/ui/card';
  import { Input } from '$lib/components/ui/input';
  import { Label } from '$lib/components/ui/label';
  import { Separator } from '$lib/components/ui/separator';
  import { Switch } from '$lib/components/ui/switch';

  // Admin profile data
  let profile = {
    name: 'Admin User',
    email: 'admin@moviemanager.com',
    role: 'Administrator',
    joinDate: 'January 1, 2024',
    lastLogin: 'Today at 2:30 PM',
    bio: 'System administrator with full access to all features.',
    location: 'New York, NY',
    timezone: 'Eastern Time (ET)'
  };

  // Password change
  let password = {
    current: '',
    new: '',
    confirm: '',
    showCurrent: false,
    showNew: false,
    showConfirm: false
  };

  // Preferences
  let preferences = {
    emailNotifications: true,
    systemAlerts: true,
    weeklyReports: true,
    darkMode: true,
    twoFactorAuth: false
  };

  // Stats
  let stats = {
    moviesReviewed: 124,
    usersManaged: 156,
    systemUptime: '99.9%',
    activeSessions: 42
  };

  // UI State
  let isSaving = false;
  let showChangeAvatar = false;

  const saveProfile = () => {
    isSaving = true;
    setTimeout(() => {
      isSaving = false;
      alert('Profile updated successfully');
    }, 1000);
  };

  const changePassword = () => {
    if (password.new !== password.confirm) {
      alert('New passwords do not match');
      return;
    }

    if (password.new.length < 8) {
      alert('Password must be at least 8 characters');
      return;
    }

    alert('Password changed successfully');
    password = {
      current: '',
      new: '',
      confirm: '',
      showCurrent: false,
      showNew: false,
      showConfirm: false
    };
  };

  const updateAvatar = () => {
    alert('Avatar update would open file picker');
    showChangeAvatar = false;
  };

  const generateApiKey = () => {
    alert('New API key generated: sk_live_' + Math.random().toString(36).substring(2, 15));
  };

  const viewActivityLog = () => {
    alert('Would open admin activity log');
  };
</script>

<svelte:head>
  <title>Admin Profile</title>
</svelte:head>

<div class="space-y-6">
  <!-- Header -->
  <div>
    <h1 class="text-2xl font-bold">Admin Profile</h1>
    <p class="text-muted-foreground">Manage your administrator account</p>
  </div>

  <!-- Profile Overview -->
  <div class="grid md:grid-cols-3 gap-6">
    <!-- Profile Card -->
    <Card class="md:col-span-2">
      <CardHeader>
        <CardTitle class="flex items-center gap-2">
          <User class="h-5 w-5" />
          Profile Information
        </CardTitle>
        <CardDescription>Update your personal information</CardDescription>
      </CardHeader>
      <CardContent class="space-y-6">
        <!-- Avatar & Basic Info -->
        <div class="flex items-center gap-6">
          <div class="relative">
            <div class="h-24 w-24 rounded-full bg-primary/10 flex items-center justify-center">
              <User class="h-12 w-12 text-primary" />
            </div>
            <Button 
              variant="outline" 
              size="sm" 
              class="absolute -bottom-2 -right-2 rounded-full h-8 w-8 p-0"
              onclick={() => showChangeAvatar = true}
            >
              <Camera class="h-4 w-4" />
            </Button>
          </div>
          
          <div>
            <h2 class="text-xl font-bold">{profile.name}</h2>
            <div class="flex items-center gap-2 mt-1">
              <Badge variant="default" class="gap-1">
                <Shield class="h-3 w-3" />
                {profile.role}
              </Badge>
              <div class="text-sm text-muted-foreground">
                Joined {profile.joinDate}
              </div>
            </div>
            <div class="text-sm text-muted-foreground mt-2">
              Last login: {profile.lastLogin}
            </div>
          </div>
        </div>

        <!-- Edit Form -->
        <div class="grid md:grid-cols-2 gap-6">
          <div class="space-y-4">
            <div class="space-y-2">
              <Label for="name">Full Name</Label>
              <Input 
                id="name" 
                bind:value={profile.name}
                placeholder="Your name"
              />
            </div>
            
            <div class="space-y-2">
              <Label for="email">Email Address</Label>
              <div class="flex gap-2">
                <Input 
                  id="email" 
                  bind:value={profile.email}
                  type="email"
                  class="flex-1"
                />
                <Button variant="outline" size="sm">
                  <Mail class="h-4 w-4 mr-2" />
                  Verify
                </Button>
              </div>
            </div>
            
            <div class="space-y-2">
              <Label for="location">Location</Label>
              <Input 
                id="location" 
                bind:value={profile.location}
                placeholder="City, Country"
              />
            </div>
          </div>
          
          <div class="space-y-4">
            <div class="space-y-2">
              <Label for="timezone">Timezone</Label>
              <Input 
                id="timezone" 
                bind:value={profile.timezone}
                placeholder="Your timezone"
              />
            </div>
            
            <div class="space-y-2">
              <Label for="bio">Bio</Label>
              <textarea 
                id="bio" 
                bind:value={profile.bio}
                placeholder="Tell us about yourself..."
                rows={3}
                class="w-full p-2 border rounded-md"
              />
            </div>
          </div>
        </div>
      </CardContent>
    </Card>

    <!-- Quick Stats -->
    <Card>
      <CardHeader>
        <CardTitle>Admin Stats</CardTitle>
      </CardHeader>
      <CardContent class="space-y-4">
        <div class="space-y-3">
          <div class="flex items-center justify-between">
            <div class="flex items-center gap-2">
              <Film class="h-4 w-4 text-blue-500" />
              <span class="text-sm">Movies Reviewed</span>
            </div>
            <div class="font-bold">{stats.moviesReviewed}</div>
          </div>
          
          <div class="flex items-center justify-between">
            <div class="flex items-center gap-2">
              <User class="h-4 w-4 text-green-500" />
              <span class="text-sm">Users Managed</span>
            </div>
            <div class="font-bold">{stats.usersManaged}</div>
          </div>
          
          <div class="flex items-center justify-between">
            <div class="flex items-center gap-2">
              <Activity class="h-4 w-4 text-purple-500" />
              <span class="text-sm">System Uptime</span>
            </div>
            <div class="font-bold">{stats.systemUptime}</div>
          </div>
          
          <div class="flex items-center justify-between">
            <div class="flex items-center gap-2">
              <Globe class="h-4 w-4 text-yellow-500" />
              <span class="text-sm">Active Sessions</span>
            </div>
            <div class="font-bold">{stats.activeSessions}</div>
          </div>
        </div>
        
        <Separator />
        
        <Button 
          variant="outline" 
          class="w-full"
          onclick={viewActivityLog}
        >
          <Activity class="h-4 w-4 mr-2" />
          View Activity Log
        </Button>
      </CardContent>
    </Card>
  </div>

  <!-- Security & Preferences -->
  <div class="grid md:grid-cols-2 gap-6">
    <!-- Security -->
    <Card>
      <CardHeader>
        <CardTitle class="flex items-center gap-2">
          <Lock class="h-5 w-5" />
          Security
        </CardTitle>
      </CardHeader>
      <CardContent class="space-y-6">
        <!-- Two-Factor Auth -->
        <div class="flex items-center justify-between">
          <div class="space-y-0.5">
            <Label>Two-Factor Authentication</Label>
            <p class="text-sm text-muted-foreground">Add an extra layer of security</p>
          </div>
          <Switch bind:checked={preferences.twoFactorAuth} />
        </div>
        
        <!-- API Key -->
        <div class="space-y-2">
          <Label>API Key Management</Label>
          <div class="text-sm text-muted-foreground mb-2">
            Generate or revoke API keys for system access
          </div>
          <Button variant="outline" class="w-full" onclick={generateApiKey}>
            <Key class="h-4 w-4 mr-2" />
            Generate New API Key
          </Button>
        </div>
        
        <!-- Change Password -->
        <Separator />
        
        <div class="space-y-4">
          <h3 class="font-medium">Change Password</h3>
          
          <div class="space-y-2">
            <Label for="current-password">Current Password</Label>
            <div class="relative">
              <Input 
                id="current-password" 
                bind:value={password.current}
                type={password.showCurrent ? 'text' : 'password'}
                placeholder="Current password"
              />
              <button 
                type="button"
                class="absolute right-3 top-1/2 transform -translate-y-1/2"
                onclick={() => password.showCurrent = !password.showCurrent}
              >
                {#if password.showCurrent }
                <EyeOff class="h-4 w-4 text-muted-foreground" />
                {:else}
                <Eye class="h-4 w-4 text-muted-foreground" />
                {/if}
              </button>
            </div>
          </div>
          
          <div class="space-y-2">
            <Label for="new-password">New Password</Label>
            <div class="relative">
              <Input 
                id="new-password" 
                bind:value={password.new}
                type={password.showNew ? 'text' : 'password'}
                placeholder="New password (min. 8 characters)"
              />
              <button 
                type="button"
                class="absolute right-3 top-1/2 transform -translate-y-1/2"
                onclick={() => password.showNew = !password.showNew}
              >
              {#if password.showNew }
               <EyeOff class="h-4 w-4 text-muted-foreground" /> 
              {:else}
              <Eye class="h-4 w-4 text-muted-foreground" />
              {/if}
              
              </button>
            </div>
          </div>
          
          <div class="space-y-2">
            <Label for="confirm-password">Confirm Password</Label>
            <div class="relative">
              <Input 
                id="confirm-password" 
                bind:value={password.confirm}
                type={password.showConfirm ? 'text' : 'password'}
                placeholder="Confirm new password"
              />
              <button 
                type="button"
                class="absolute right-3 top-1/2 transform -translate-y-1/2"
                onclick={() => password.showConfirm = !password.showConfirm}
              >
              {#if  password.showConfirm }
               <EyeOff class="h-4 w-4 text-muted-foreground" />
                {:else}
                 <Eye class="h-4 w-4 text-muted-foreground" />
              {/if}
             
              </button>
            </div>
          </div>
          
          <Button 
            class="w-full" 
            onclick={changePassword}
            disabled={!password.current || !password.new || !password.confirm}
          >
            <Lock class="h-4 w-4 mr-2" />
            Update Password
          </Button>
        </div>
      </CardContent>
    </Card>

    <!-- Preferences -->
    <Card>
      <CardHeader>
        <CardTitle class="flex items-center gap-2">
          <Bell class="h-5 w-5" />
          Preferences
        </CardTitle>
      </CardHeader>
      <CardContent class="space-y-6">
        <div class="space-y-4">
          <div class="flex items-center justify-between">
            <div class="space-y-0.5">
              <Label>Email Notifications</Label>
              <p class="text-sm text-muted-foreground">Receive email updates</p>
            </div>
            <Switch bind:checked={preferences.emailNotifications} />
          </div>
          
          <div class="flex items-center justify-between">
            <div class="space-y-0.5">
              <Label>System Alerts</Label>
              <p class="text-sm text-muted-foreground">Critical system notifications</p>
            </div>
            <Switch bind:checked={preferences.systemAlerts} />
          </div>
          
          <div class="flex items-center justify-between">
            <div class="space-y-0.5">
              <Label>Weekly Reports</Label>
              <p class="text-sm text-muted-foreground">Weekly system performance reports</p>
            </div>
            <Switch bind:checked={preferences.weeklyReports} />
          </div>
          
          <div class="flex items-center justify-between">
            <div class="space-y-0.5">
              <Label>Dark Mode</Label>
              <p class="text-sm text-muted-foreground">Use dark theme interface</p>
            </div>
            <Switch bind:checked={preferences.darkMode} />
          </div>
        </div>
        
        <Separator />
        
        <!-- Admin Tools -->
        <div class="space-y-3">
          <h3 class="font-medium">Quick Access</h3>
          <div class="grid grid-cols-2 gap-2">
            <Button variant="outline" size="sm">
              System Logs
            </Button>
            <Button variant="outline" size="sm">
              Audit Trail
            </Button>
            <Button variant="outline" size="sm">
              Backup Settings
            </Button>
            <Button variant="outline" size="sm">
              API Docs
            </Button>
          </div>
        </div>
      </CardContent>
    </Card>
  </div>

  <!-- Save Button -->
  <div class="flex justify-end">
            <Button onclick={saveProfile} disabled={isSaving}  size="lg">
        {#if isSaving}
            <div>Saving...</div>
        {:else}
            <div class="flex items-center">
            <Save class="h-4 w-4 mr-2" />
            Save Changes
            </div>
        {/if}
        </Button>
  </div>
</div>

<!-- Change Avatar Modal -->
{#if showChangeAvatar}
  <div class="fixed inset-0 bg-black/50 flex items-center justify-center z-50 p-4">
    <Card class="max-w-md w-full">
      <CardHeader>
        <CardTitle>Change Profile Picture</CardTitle>
      </CardHeader>
      <CardContent class="space-y-4">
        <div class="text-center">
          <div class="h-32 w-32 rounded-full bg-primary/10 flex items-center justify-center mx-auto mb-4">
            <User class="h-16 w-16 text-primary" />
          </div>
          <p class="text-sm text-muted-foreground">
            Upload a new profile picture (max 5MB, JPG or PNG)
          </p>
        </div>
        
        <div class="space-y-2">
          <Button 
            variant="outline" 
            class="w-full"
            onclick={updateAvatar}
          >
            <Camera class="h-4 w-4 mr-2" />
            Upload Image
          </Button>
          <Button 
            variant="ghost" 
            class="w-full"
            onclick={() => showChangeAvatar = false}
          >
            Cancel
          </Button>
        </div>
      </CardContent>
    </Card>
  </div>
{/if}