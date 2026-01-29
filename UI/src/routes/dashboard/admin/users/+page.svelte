<!-- src/routes/dashboard/admin-users/+page.svelte -->
<script lang="ts">
  import { 
    Users,
    Mail,
    Calendar,
    Shield,
    Search,
    Filter,
    Eye,
    Edit,
    Ban,
    CheckCircle,
    XCircle,
    MoreVertical,
    Clock,
    Activity,
    User,

	Film

  } from '@lucide/svelte';
  
  import { Button } from '$lib/components/ui/button';
  import { Card, CardContent, CardHeader, CardTitle } from '$lib/components/ui/card';
  import { Input } from '$lib/components/ui/input';
  import { Badge } from '$lib/components/ui/badge';
  import { Separator } from '$lib/components/ui/separator';
	import { RoleEnum, type Role, type User as UserModel } from '../../../../types';

  // Sample users data
  let users:UserModel[] = [
    { id: 1, name: 'John Doe', email: 'john@example.com', role: RoleEnum.User, status: 'active', joinDate: '2024-01-15', movies: 24, lastActive: '2 hours ago' },
    { id: 2, name: 'Sarah Chen', email: 'sarah@example.com', role: RoleEnum.User, status: 'active', joinDate: '2024-01-10', movies: 18, lastActive: '5 hours ago' },
    { id: 3, name: 'Mike Ross', email: 'mike@example.com', role: RoleEnum.User, status: 'active', joinDate: '2024-01-05', movies: 12, lastActive: '1 day ago' },
    { id: 4, name: 'Admin User', email: 'admin@example.com', role: RoleEnum.Admin, status: 'active', joinDate: '2024-01-01', movies: 42, lastActive: '30 min ago' },
    { id: 5, name: 'Emma Wilson', email: 'emma@example.com', role: RoleEnum.User, status: 'suspended', joinDate: '2023-12-20', movies: 8, lastActive: '3 days ago' },
    { id: 6, name: 'David Lee', email: 'david@example.com', role: RoleEnum.User, status: 'active', joinDate: '2023-12-15', movies: 31, lastActive: 'Just now' },
    { id: 7, name: 'Lisa Brown', email: 'lisa@example.com', role: RoleEnum.User, status: 'inactive', joinDate: '2023-12-10', movies: 5, lastActive: '1 week ago' },
    { id: 8, name: 'Alex Garcia', email: 'alex@example.com', role: RoleEnum.User, status: 'active', joinDate: '2023-12-01', movies: 16, lastActive: '12 hours ago' }
  ];

  // State
  let searchQuery = '';
  let filterRole = 'all'; // all, user, admin
  let filterStatus = 'all'; // all, active, suspended, inactive
  let selectedUser:UserModel | null ;

  // Filtered users
  $: filteredUsers = users.filter(user => {
    const matchesSearch = !searchQuery || 
      user.name.toLowerCase().includes(searchQuery.toLowerCase()) ||
      user.email.toLowerCase().includes(searchQuery.toLowerCase());
    
    const matchesRole = filterRole === 'all' || user.role === filterRole;
    const matchesStatus = filterStatus === 'all' || user.status === filterStatus;
    
    return matchesSearch && matchesRole && matchesStatus;
  });

  // Stats
  $: stats = {
    total: users.length,
    active: users.filter(u => u.status === 'active').length,
    suspended: users.filter(u => u.status === 'suspended').length,
    inactive: users.filter(u => u.status === 'inactive').length,
    admins: users.filter(u => u.role === 'admin').length,
    users: users.filter(u => u.role === 'user').length
  };

  // Helper functions
  const getStatusColor = (status: string) => {
    switch(status) {
      case 'active': return 'bg-green-500';
      case 'suspended': return 'bg-yellow-500';
      case 'inactive': return 'bg-gray-500';
      default: return 'bg-gray-500';
    }
  };

  const getStatusText = (status: string) => {
    switch(status) {
      case 'active': return 'Active';
      case 'suspended': return 'Suspended';
      case 'inactive': return 'Inactive';
      default: return 'Unknown';
    }
  };

  const getRoleColor = (role: string) => {
    return role === 'admin' ? 'bg-purple-500' : 'bg-blue-500';
  };

  const toggleUserStatus = (user:UserModel | null) => {
      if (!user) return
     const userId = user.id
     const currentStatus = user.status
    users = users.map(user => 
      user.id === userId 
        ? { 
            ...user, 
            status: currentStatus === 'active' ? 'suspended' : 'active',
            lastActive: currentStatus === 'active' ? 'Just now (suspended)' : 'Just now (activated)'
          } 
        : user
    );
  };

  const toggleUserRole = (user :UserModel | null) => {
    if (!user) return
     const userId = user.id
     const currentRole = user.role
    users = users.map(user => 
      user.id === userId 
        ? { 
            ...user, 
            role: currentRole === 'admin' ? 'user' : 'admin',
            lastActive: 'Just now (role changed)'
          } 
        : user
    );
  };

  const deleteUser = (userId: number) => {
    if (confirm('Are you sure you want to delete this user? This cannot be undone.')) {
      users = users.filter(user => user.id !== userId);
      selectedUser = null;
    }
  };

  const viewUserDetails = (user: any) => {
    selectedUser = user;
  };

  const closeDetails = () => {
    selectedUser = null;
  };
</script>

<svelte:head>
  <title>Admin - User Management</title>
</svelte:head>

<div class="space-y-6">
  <!-- Header -->
  <div class="flex items-center justify-between">
    <div>
      <h1 class="text-2xl font-bold">User Management</h1>
      <p class="text-muted-foreground">Manage user accounts and permissions</p>
    </div>
    <Button>
      <User class="h-4 w-4 mr-2" />
      Add User
    </Button>
  </div>

  <!-- Stats -->
  <div class="grid grid-cols-2 md:grid-cols-6 gap-4">
    <Card>
      <CardContent class="pt-6 text-center">
        <div class="text-2xl font-bold">{stats.total}</div>
        <p class="text-sm text-muted-foreground">Total Users</p>
      </CardContent>
    </Card>
    <Card>
      <CardContent class="pt-6 text-center">
        <div class="text-2xl font-bold text-green-500">{stats.active}</div>
        <p class="text-sm text-muted-foreground">Active</p>
      </CardContent>
    </Card>
    <Card>
      <CardContent class="pt-6 text-center">
        <div class="text-2xl font-bold text-yellow-500">{stats.suspended}</div>
        <p class="text-sm text-muted-foreground">Suspended</p>
      </CardContent>
    </Card>
    <Card>
      <CardContent class="pt-6 text-center">
        <div class="text-2xl font-bold text-gray-500">{stats.inactive}</div>
        <p class="text-sm text-muted-foreground">Inactive</p>
      </CardContent>
    </Card>
    <Card>
      <CardContent class="pt-6 text-center">
        <div class="text-2xl font-bold text-purple-500">{stats.admins}</div>
        <p class="text-sm text-muted-foreground">Admins</p>
      </CardContent>
    </Card>
    <Card>
      <CardContent class="pt-6 text-center">
        <div class="text-2xl font-bold text-blue-500">{stats.users}</div>
        <p class="text-sm text-muted-foreground">Regular Users</p>
      </CardContent>
    </Card>
  </div>

  <!-- Search and Filter -->
  <Card>
    <CardContent class="pt-6">
      <div class="space-y-4">
        <div class="relative">
          <Search class="absolute left-3 top-1/2 transform -translate-y-1/2 h-4 w-4 text-muted-foreground" />
          <Input 
            bind:value={searchQuery}
            placeholder="Search users by name or email..."
            class="pl-10"
          />
        </div>
        
        <div class="flex flex-wrap gap-2">
          <!-- Role Filters -->
          <div class="flex gap-2">
            <span class="text-sm text-muted-foreground self-center">Role:</span>
            <Button 
              variant={filterRole === 'all' ? 'default' : 'outline'} 
              size="sm"
              onclick={() => filterRole = 'all'}
            >
              All
            </Button>
            <Button 
              variant={filterRole === 'user' ? 'default' : 'outline'} 
              size="sm"
              onclick={() => filterRole = 'user'}
            >
              Users ({stats.users})
            </Button>
            <Button 
              variant={filterRole === 'admin' ? 'default' : 'outline'} 
              size="sm"
              onclick={() => filterRole = 'admin'}
            >
              Admins ({stats.admins})
            </Button>
          </div>
          
          <!-- Status Filters -->
          <div class="flex gap-2">
            <span class="text-sm text-muted-foreground self-center ml-4">Status:</span>
            <Button 
              variant={filterStatus === 'all' ? 'default' : 'outline'} 
              size="sm"
              onclick={() => filterStatus = 'all'}
            >
              All
            </Button>
            <Button 
              variant={filterStatus === 'active' ? 'default' : 'outline'} 
              size="sm"
              onclick={() => filterStatus = 'active'}
            >
              Active ({stats.active})
            </Button>
            <Button 
              variant={filterStatus === 'suspended' ? 'default' : 'outline'} 
              size="sm"
              onclick={() => filterStatus = 'suspended'}
            >
              Suspended ({stats.suspended})
            </Button>
            <Button 
              variant={filterStatus === 'inactive' ? 'default' : 'outline'} 
              size="sm"
              onclick={() => filterStatus = 'inactive'}
            >
              Inactive ({stats.inactive})
            </Button>
          </div>
        </div>
      </div>
    </CardContent>
  </Card>

  <!-- Users List -->
  <div class="space-y-4">
    {#if filteredUsers.length === 0}
      <Card>
        <CardContent class="py-12 text-center">
          <Users class="h-12 w-12 text-muted-foreground mx-auto mb-4 opacity-50" />
          <h3 class="text-lg font-semibold mb-2">No users found</h3>
          <p class="text-muted-foreground">
            {searchQuery ? 'Try a different search' : 'No users match the current filters'}
          </p>
        </CardContent>
      </Card>
    {:else}
      {#each filteredUsers as user}
        <Card class="hover:bg-accent/50 transition-colors">
          <CardContent class="p-6">
            <div class="flex items-center gap-4">
              <!-- User Avatar -->
              <div class="h-12 w-12 rounded-full bg-primary/10 flex items-center justify-center">
                <User class="h-6 w-6 text-primary" />
              </div>
              
              <!-- User Info -->
              <div class="flex-1">
                <div class="flex items-start justify-between mb-2">
                  <div>
                    <div class="flex items-center gap-2 mb-1">
                      <h3 class="font-semibold">{user.name}</h3>
                      <Badge variant={user.role === 'admin' ? 'default' : 'outline'} class={user.role === 'admin' ? 'bg-purple-500' : ''}>
                        {user.role === 'admin' ? 'Admin' : 'User'}
                      </Badge>
                      <div class="flex items-center gap-1">
                        <div class={`h-2 w-2 rounded-full ${getStatusColor(user.status)}`} />
                        <span class="text-sm text-muted-foreground">{getStatusText(user.status)}</span>
                      </div>
                    </div>
                    
                    <div class="flex items-center gap-3 text-sm text-muted-foreground">
                      <div class="flex items-center gap-1">
                        <Mail class="h-3 w-3" />
                        <span>{user.email}</span>
                      </div>
                      <div class="flex items-center gap-1">
                        <Calendar class="h-3 w-3" />
                        <span>Joined {user.joinDate}</span>
                      </div>
                    </div>
                  </div>
                  
                  <div class="flex items-center gap-1">
                    <Button variant="ghost" size="sm" onclick={() => viewUserDetails(user)}>
                      <Eye class="h-4 w-4" />
                    </Button>
                    <Button variant="ghost" size="sm">
                      <MoreVertical class="h-4 w-4" />
                    </Button>
                  </div>
                </div>
                
                <!-- User Stats -->
                <div class="flex items-center gap-4 text-sm">
                  <div class="flex items-center gap-1">
                    <Film class="h-4 w-4 text-blue-500" />
                    <span>{user.movies} movies</span>
                  </div>
                  <div class="flex items-center gap-1">
                    <Activity class="h-4 w-4 text-green-500" />
                    <span>Last active: {user.lastActive}</span>
                  </div>
                </div>
                
                <!-- Actions -->
                <div class="flex gap-2 mt-4">
                  {#if user.status === 'active'}
                    <Button 
                      variant="outline" 
                      size="sm"
                      class="gap-2"
                      onclick={() => toggleUserStatus(user)}
                    >
                      <Ban class="h-4 w-4" />
                      Suspend
                    </Button>
                  {:else}
                    <Button 
                      size="sm"
                      class="gap-2"
                      onclick={() => toggleUserStatus(user)}
                    >
                      <CheckCircle class="h-4 w-4" />
                      {user.status === 'suspended' ? 'Unsuspend' : 'Activate'}
                    </Button>
                  {/if}
                  
                  {#if user.role === 'admin'}
                    <Button 
                      variant="outline" 
                      size="sm"
                      class="gap-2"
                      onclick={() => toggleUserRole(user)}
                    >
                      <Shield class="h-4 w-4" />
                      Remove Admin
                    </Button>
                  {:else}
                    <Button 
                      variant="outline" 
                      size="sm"
                      class="gap-2"
                      onclick={() => toggleUserRole(user)}
                    >
                      <Shield class="h-4 w-4" />
                      Make Admin
                    </Button>
                  {/if}
                  
                  <Button 
                    variant="destructive" 
                    size="sm"
                    class="gap-2"
                    onclick={() => deleteUser(user.id)}
                  >
                    <XCircle class="h-4 w-4" />
                    Delete
                  </Button>
                </div>
              </div>
            </div>
          </CardContent>
        </Card>
      {/each}
    {/if}
  </div>
</div>

<!-- User Details Modal -->
{#if selectedUser}
  <div class="fixed inset-0 bg-black/50 flex items-center justify-center z-50 p-4">
    <Card class="max-w-md w-full">
      <CardHeader>
        <div class="flex items-start justify-between">
          <CardTitle>User Details</CardTitle>
          <Button variant="ghost" size="sm" onclick={closeDetails}>
            Close
          </Button>
        </div>
      </CardHeader>
      <CardContent class="space-y-6">
        <!-- User Info -->
        <div class="flex items-center gap-4">
          <div class="h-16 w-16 rounded-full bg-primary/10 flex items-center justify-center">
            <User class="h-8 w-8 text-primary" />
          </div>
          <div>
            <h3 class="font-semibold text-lg">{selectedUser.name}</h3>
            <p class="text-muted-foreground">{selectedUser.email}</p>
          </div>
        </div>
        
        <!-- Details Grid -->
        <div class="grid grid-cols-2 gap-4">
          <div>
            <h4 class="font-medium text-sm text-muted-foreground">Role</h4>
            <Badge variant={selectedUser.role === 'admin' ? 'default' : 'outline'} class="mt-1">
              {selectedUser.role === 'admin' ? 'Administrator' : 'Regular User'}
            </Badge>
          </div>
          <div>
            <h4 class="font-medium text-sm text-muted-foreground">Status</h4>
            <div class="flex items-center gap-2 mt-1">
              <div class={`h-2 w-2 rounded-full ${getStatusColor(selectedUser.status)}`} />
              <span>{getStatusText(selectedUser.status)}</span>
            </div>
          </div>
          <div>
            <h4 class="font-medium text-sm text-muted-foreground">Join Date</h4>
            <p class="mt-1">{selectedUser.joinDate}</p>
          </div>
          <div>
            <h4 class="font-medium text-sm text-muted-foreground">Movies Added</h4>
            <p class="mt-1">{selectedUser.movies} movies</p>
          </div>
          <div class="col-span-2">
            <h4 class="font-medium text-sm text-muted-foreground">Last Active</h4>
            <p class="mt-1">{selectedUser.lastActive}</p>
          </div>
        </div>
        
        <!-- Quick Actions -->
        <Separator />
        
        <div class="space-y-3">
          <h4 class="font-medium">Quick Actions</h4>
          
          <div class="grid grid-cols-2 gap-2">
            {#if selectedUser.status === 'active'}
              <Button 
                variant="outline"
                onclick={() => {
                  toggleUserStatus(selectedUser);
                  closeDetails();
                }}
              >
                <Ban class="h-4 w-4 mr-2" />
                Suspend User
              </Button>
            {:else}
              <Button 
                onclick={() => {
                  toggleUserStatus(selectedUser);
                  closeDetails();
                }}
              >
                <CheckCircle class="h-4 w-4 mr-2" />
                Activate User
              </Button>
            {/if}
            
            {#if selectedUser.role === 'admin'}
              <Button 
                variant="outline"
                onclick={() => {
                  toggleUserRole(selectedUser);
                  closeDetails();
                }}
              >
                <Shield class="h-4 w-4 mr-2" />
                Remove Admin
              </Button>
            {:else}
              <Button 
                variant="outline"
                onclick={() => {
                    if (selectedUser) return;
                  toggleUserRole(selectedUser);
                  closeDetails();
                }}
              >
                <Shield class="h-4 w-4 mr-2" />
                Make Admin
              </Button>
            {/if}
          </div>
          
          <Button 
            variant="destructive"
            class="w-full"
            onclick={() => {
              deleteUser(selectedUser?.id || -1);
              closeDetails();
            }}
          >
            <XCircle class="h-4 w-4 mr-2" />
            Delete User Account
          </Button>
        </div>
      </CardContent>
    </Card>
  </div>
{/if}