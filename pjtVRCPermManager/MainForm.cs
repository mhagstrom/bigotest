namespace pjtVRCPermManager;

public partial class MainForm : Form
{
    private HashSet<string> whitelist = new HashSet<string>();
    private Dictionary<string, HashSet<string>> permissions = new Dictionary<string, HashSet<string>>
    {
        {"NoPerms", new HashSet<string>()}
    };

	private readonly Random random = new Random();

    public MainForm()
    {
        InitializeComponent();
        RefreshRolesList();
    }

    private void addPermissionButton_Click(object sender, EventArgs e)
    {
        string newPermission = txbNewPermission.Text.Trim();
        
        if (string.IsNullOrEmpty(newPermission))
        {
            MessageBox.Show("Permission name cannot be empty.");
            return;
        }

        if (newPermission.Equals("NoPerms", StringComparison.OrdinalIgnoreCase))
        {
            MessageBox.Show("Cannot add 'NoPerms' as it is a reserved permission type.");
            return;
        }

        if (permissions.ContainsKey(newPermission))
        {
            MessageBox.Show("This permission already exists.");
            return;
        }

        permissions.Add(newPermission, new HashSet<string>());
        RefreshRolesList();
        MessageBox.Show($"Added new permission type: {newPermission}");
    }

    private void removePermissionButton_Click(object sender, EventArgs e)
    {
        string selectedPermission = cmbRoles.SelectedItem?.ToString();

        if (string.IsNullOrEmpty(selectedPermission))
        {
            MessageBox.Show("Please select a permission to remove.");
            return;
        }

        if (selectedPermission.Equals("NoPerms", StringComparison.OrdinalIgnoreCase))
        {
            MessageBox.Show("Cannot remove 'NoPerms' as it is a required permission type.");
            return;
        }
        
        var affectedUsers = permissions[selectedPermission]
            .Where(user => permissions
                .Where(p => p.Key != "NoPerms" && p.Key != selectedPermission)
                .All(p => !p.Value.Contains(user)))
            .ToList();
        
        foreach (var user in affectedUsers)
        {
            permissions["NoPerms"].Add(user);
        }
        
        permissions.Remove(selectedPermission);
        
        RefreshRolesList();
        MessageBox.Show($"Removed permission type: {selectedPermission}\n" +
                       $"Users affected: {affectedUsers.Count}");
    }

    private void RefreshRolesList()
    {
        var selectedRole = cmbRoles.SelectedItem?.ToString();
        cmbRoles.Items.Clear();
        cmbRoles.Items.AddRange(permissions.Keys.ToArray());
        
        if (!string.IsNullOrEmpty(selectedRole) && permissions.ContainsKey(selectedRole))
        {
            cmbRoles.SelectedItem = selectedRole;
        }
        else
        {
            cmbRoles.SelectedIndex = 0;
        }
    }

    private void addUserButton_Click(object sender, EventArgs e)
    {
        string username = txbUsername.Text.Trim();
        if (!string.IsNullOrEmpty(username) && whitelist.Add(username))
        {
            permissions["NoPerms"].Add(username);
            MessageBox.Show($"Added {username} to whitelist with NoPerms role.");
            RefreshPermsList();
        }
    }

    private void assignRoleButton_Click(object sender, EventArgs e)
    {
        string username = txbUsername.Text.Trim();
        string role = cmbRoles.SelectedItem?.ToString();

        if (!string.IsNullOrEmpty(username) && permissions.ContainsKey(role))
        {
            if (role != "NoPerms")
            {
                permissions["NoPerms"].Remove(username);
            }
        
            permissions[role].Add(username);
            MessageBox.Show($"Assigned role {role} to {username}.");
            RefreshPermsList();
        }
    }

    private void removeRoleButton_Click(object sender, EventArgs e)
    {
        string username = txbUsername.Text.Trim();
        string role = cmbRoles.SelectedItem?.ToString();

        if (!string.IsNullOrEmpty(username) && permissions.ContainsKey(role))
        {
            if (permissions[role].Remove(username))
            {
                bool hasOtherRoles = permissions
                    .Where(p => p.Key != "NoPerms")
                    .Any(p => p.Value.Contains(username));
                
                if (!hasOtherRoles)
                {
                    permissions["NoPerms"].Add(username);
                    MessageBox.Show($"Removed role {role} from {username}. User now has NoPerms role.");
                }
                else
                {
                    MessageBox.Show($"Removed role {role} from {username}.");
                }
            
                RefreshPermsList();
            }
        }
    }

private void searchButton_Click(object sender, EventArgs e)
{
    string searchUsername = txbUsername.Text.Trim();
    string searchPermission = cmbRoles.SelectedItem?.ToString();
    lsbResults.Items.Clear();
    
    if (string.IsNullOrEmpty(searchUsername) && string.IsNullOrEmpty(searchPermission))
    {
        MessageBox.Show("Please enter a username or select a permission to search.");
        return;
    }
    
    if (!string.IsNullOrEmpty(searchUsername))
    {
        var userPermissions = new List<string>();
        foreach (var permission in permissions)
        {
            if (permission.Value.Contains(searchUsername))
            {
                userPermissions.Add(permission.Key);
            }
        }

        if (userPermissions.Count > 0)
        {
            lsbResults.Items.Add($"Permissions for user '{searchUsername}':");
            foreach (var permission in userPermissions)
            {
                lsbResults.Items.Add($"- {permission}");
            }
        }
        else
        {
            lsbResults.Items.Add($"No permissions found for user '{searchUsername}'");
        }
    }
    
    else if (!string.IsNullOrEmpty(searchPermission))
    {
        if (permissions.TryGetValue(searchPermission, out var users))
        {
            if (users.Count > 0)
            {
                lsbResults.Items.Add($"Users with permission '{searchPermission}':");
                foreach (var user in users)
                {
                    lsbResults.Items.Add($"- {user}");
                }
            }
            else
            {
                lsbResults.Items.Add($"No users found with permission '{searchPermission}'");
            }
        }
        else
        {
            lsbResults.Items.Add($"Permission '{searchPermission}' not found");
        }
    }
}

    private void BtnUserRolesClick(object sender, EventArgs e)
    {
        string username = txbUsername.Text.Trim();
        if (string.IsNullOrEmpty(username)) return;

        var userRoles = new List<string>();
        
        foreach (var role in permissions)
        {
            if (role.Value.Contains(username))
            {
                userRoles.Add(role.Key);
            }
        }

        lsbResults.Items.Clear();
        if (userRoles.Count > 0)
        {
            foreach (var role in userRoles)
            {
                lsbResults.Items.Add(role);
            }
        }
        else
        {
            lsbResults.Items.Add("User has no roles");
        }
    }

    private void BtnSortClick(object sender, EventArgs e)
    {
        var items = new List<string>();
        foreach (var item in lsbResults.Items)
        {
            items.Add(item.ToString());
        }

        switch (cmbSortMethod.SelectedItem.ToString())
        {
            case "Bubble Sort":
                BubbleSort(items);
                break;
            case "Quick Sort":
                QuickSort(items, 0, items.Count - 1);
                break;
            case "Merge Sort":
                items = MergeSort(items);
                break;
        }

        lsbResults.Items.Clear();
        lsbResults.Items.AddRange(items.ToArray());
    }
    
    private void BubbleSort(List<string> items)
    {
        int n = items.Count;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (string.Compare(items[j], items[j + 1]) > 0)
                {
                    var temp = items[j];
                    items[j] = items[j + 1];
                    items[j + 1] = temp;
                }
            }
        }
    }
    
    private void QuickSort(List<string> items, int low, int high)
    {
        if (low < high)
        {
            int partitionIndex = Partition(items, low, high);
            QuickSort(items, low, partitionIndex - 1);
            QuickSort(items, partitionIndex + 1, high);
        }
    }

    private int Partition(List<string> items, int low, int high)
    {
        string pivot = items[high];
        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            if (string.Compare(items[j], pivot) <= 0)
            {
                i++;
                var temp = items[i];
                items[i] = items[j];
                items[j] = temp;
            }
        }

        var temp1 = items[i + 1];
        items[i + 1] = items[high];
        items[high] = temp1;

        return i + 1;
    }
    
    private List<string> MergeSort(List<string> items)
    {
        if (items.Count <= 1) return items;

        int mid = items.Count / 2;
        var left = items.GetRange(0, mid);
        var right = items.GetRange(mid, items.Count - mid);

        left = MergeSort(left);
        right = MergeSort(right);

        return Merge(left, right);
    }

    private List<string> Merge(List<string> left, List<string> right)
    {
        var result = new List<string>();
        int leftIndex = 0, rightIndex = 0;

        while (leftIndex < left.Count && rightIndex < right.Count)
        {
            if (string.Compare(left[leftIndex], right[rightIndex]) <= 0)
            {
                result.Add(left[leftIndex]);
                leftIndex++;
            }
            else
            {
                result.Add(right[rightIndex]);
                rightIndex++;
            }
        }

        while (leftIndex < left.Count)
        {
            result.Add(left[leftIndex]);
            leftIndex++;
        }

        while (rightIndex < right.Count)
        {
            result.Add(right[rightIndex]);
            rightIndex++;
        }

        return result;
    }

    private void RefreshPermsList()
    {
        string selectedRole = cmbRoles.SelectedItem?.ToString();
        lsbUsers.Items.Clear();

        if (!string.IsNullOrEmpty(selectedRole) && permissions.ContainsKey(selectedRole))
        {
            foreach (var user in permissions[selectedRole])
            {
                lsbUsers.Items.Add(user);
            }
        }
    }

    private void permissionListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (lsbUsers.SelectedItem != null)
        {
            txbUsername.Text = lsbUsers.SelectedItem.ToString();
        }
    }
    
    private int BinarySearch(List<string> sortedItems, string target)
    {
        int left = 0;
        int right = sortedItems.Count - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            int comparison = string.Compare(sortedItems[mid], target);

            if (comparison == 0)
                return mid;
            
            if (comparison < 0)
                left = mid + 1;
            else
                right = mid - 1;
        }

        return -1;
    }

	private void generateUsersButton_Click(object sender, EventArgs e)
	{
		int userCount = (int)nudUserCount.Value;
		int existingUsers = whitelist.Count;

		for (int i = 0; i < userCount; i++)
		{
			string newUser = $"User_{existingUsers + i}";
			whitelist.Add(newUser);
			permissions["NoPerms"].Add(newUser);
		}

		RefreshPermsList();
		MessageBox.Show($"Generated {userCount} new users.\nTotal users: {whitelist.Count}");
	}

	private void randomizePermsButton_Click(object sender, EventArgs e)
	{
		if (whitelist.Count == 0)
		{
			MessageBox.Show("No users to assign permissions to.");
			return;
		}
        
		var availablePerms = permissions.Keys
			.Where(p => p != "NoPerms")
			.ToList();

		if (availablePerms.Count == 0)
		{
			MessageBox.Show("No permissions available to assign (other than NoPerms).");
			return;
		}
        
		foreach (var perm in permissions.Values)
		{
			perm.Clear();
		}

		var users = whitelist.ToList();
        
		foreach (var user in users)
		{
			double randomValue = random.NextDouble();
			int numPermsToAssign = (int)(Math.Log(1 - randomValue) * -3.0);
			numPermsToAssign = Math.Min(numPermsToAssign, availablePerms.Count);

			if (numPermsToAssign == 0)
			{
				permissions["NoPerms"].Add(user);
				continue;
			}
            
			var shuffledPerms = availablePerms.OrderBy(x => random.Next()).Take(numPermsToAssign);
			foreach (var perm in shuffledPerms)
			{
				permissions[perm].Add(user);
			}
		}

		RefreshPermsList();
        
		var stats = whitelist
			.Select(user => permissions
				.Count(p => p.Value.Contains(user) && p.Key != "NoPerms"))
			.GroupBy(count => count)
			.OrderBy(g => g.Key)
			.Select(g => $"\n{g.Count()} users have {g.Key} permission(s)")
			.ToList();

		MessageBox.Show($"Randomized permissions for all users." +
					   $"\n\nDistribution:{string.Join("", stats)}");
	}

private void generatePermissionsButton_Click(object sender, EventArgs e)
{
    int permCount = (int)nudPermCount.Value;
    int existingPerms = permissions.Count;
    
    int startNumber = permissions.Keys
        .Where(p => p.StartsWith("Perm_"))
        .Select(p => 
        {
            if (int.TryParse(p.Substring(5), out int num))
                return num;
            return -1;
        })
        .DefaultIfEmpty(-1)
        .Max() + 1;

    for (int i = 0; i < permCount; i++)
    {
        string newPerm = $"Perm_{startNumber + i}";
        if (!permissions.ContainsKey(newPerm))
        {
            permissions.Add(newPerm, new HashSet<string>());
        }
    }

    RefreshRolesList();
    MessageBox.Show($"Generated {permCount} new permissions.\n" +
                   $"Total permissions: {permissions.Count}\n" +
                   $"(excluding NoPerms: {permissions.Count - 1})");
}

public void ClearUsers()
{
    whitelist.Clear();
    foreach (var perm in permissions.Values)
    {
        perm.Clear();
    }
}

public void TestGenerateUser(string username)
{
    whitelist.Add(username);
    permissions["NoPerms"].Add(username);
}

public List<string> TestSearchUser(string username, string searchMethod)
{
    var results = new List<string>();
    if (searchMethod == "Linear Search")
    {
        foreach (var user in whitelist)
        {
            if (user.Contains(username))
            {
                results.Add(user);
            }
        }
    }
    else if (searchMethod == "Binary Search")
    {
        var sortedList = whitelist.OrderBy(x => x).ToList();
        int index = sortedList.BinarySearch(username);
        if (index >= 0)
        {
            results.Add(sortedList[index]);
        }
    }
    return results;
}

public void TestSortUsers(string sortMethod)
{
    var users = whitelist.ToList();
    switch (sortMethod)
    {
        case "Bubble Sort":
            BubbleSort(users);
            break;
        case "Quick Sort":
            QuickSort(users, 0, users.Count - 1);
            break;
        case "Merge Sort":
            MergeSort(users);
            break;
    }
}
}