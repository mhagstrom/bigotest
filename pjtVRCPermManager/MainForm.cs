namespace pjtVRCPermManager;

public partial class MainForm : Form
{
    private HashSet<string> whitelist = new HashSet<string>();
    private Dictionary<string, HashSet<string>> permissions = new Dictionary<string, HashSet<string>>
    {
        {"NoPerms", new HashSet<string>()},
        {"DJ", new HashSet<string>()},
        {"Moderator", new HashSet<string>()},
        {"Bouncer", new HashSet<string>()},
        {"Media Team", new HashSet<string>()},
        {"GoH", new HashSet<string>()}
    };

    public MainForm()
    {
        InitializeComponent();
        cmbRoles.Items.AddRange(permissions.Keys.ToArray());
        cmbSortMethod.SelectedIndex = 0;
    }

    private void addUserButton_Click(object sender, EventArgs e)
    {
        string username = txbUsername.Text.Trim();
        if (!string.IsNullOrEmpty(username) && whitelist.Add(username))
        {
            MessageBox.Show($"Added {username} to whitelist.");
            RefreshPermsList();
        }
    }

    private void assignRoleButton_Click(object sender, EventArgs e)
    {
        string username = txbUsername.Text.Trim();
        string role = cmbRoles.SelectedItem?.ToString();

        if (!string.IsNullOrEmpty(username) && permissions.ContainsKey(role))
        {
            permissions[role].Add(username);
            MessageBox.Show($"Assigned role {role} to {username}.");
            RefreshPermsList();
        }
    }

    private void removeRoleButton_Click(object sender, EventArgs e)
    {
        string username = txbUsername.Text.Trim();
        string role = cmbRoles.SelectedItem?.ToString();

        if (!string.IsNullOrEmpty(username) && permissions.ContainsKey(role) && permissions[role].Remove(username))
        {
            MessageBox.Show($"Removed role {role} from {username}.");
            RefreshPermsList();
        }
    }

    private void searchButton_Click(object sender, EventArgs e)
    {
        string searchUsername = txbUsername.Text.Trim();
        if (string.IsNullOrEmpty(searchUsername)) return;

        lsbResults.Items.Clear();
        // Linear Search - O(n) time complexity
        foreach (var role in permissions.Keys)
        {
            if (permissions[role].Contains(searchUsername))
            {
                lsbResults.Items.Add($"Found in role: {role}");
            }
        }

        if (lsbResults.Items.Count == 0)
        {
            lsbResults.Items.Add("User not found in any role");
        }
    }

    private void userRolesButton_Click(object sender, EventArgs e)
    {
        string username = txbUsername.Text.Trim();
        if (string.IsNullOrEmpty(username)) return;

        var userRoles = new List<string>();
        
        // O(n) time complexity where n is the number of roles
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

    private void sortButton_Click(object sender, EventArgs e)
    {
        var items = new List<string>();
        foreach (var item in lsbResults.Items)
        {
            items.Add(item.ToString());
        }

        switch (cmbSortMethod.SelectedItem.ToString())
        {
            case "Bubble Sort":
                BubbleSort(items); // O(n²)
                break;
            case "Quick Sort":
                QuickSort(items, 0, items.Count - 1); // O(n log n)
                break;
            case "Merge Sort":
                items = MergeSort(items); // O(n log n)
                break;
        }

        lsbResults.Items.Clear();
        lsbResults.Items.AddRange(items.ToArray());
    }

    // Bubble Sort - O(n²)
    private void BubbleSort(List<string> items)
    {
        int n = items.Count;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (string.Compare(items[j], items[j + 1]) > 0)
                {
                    // Swap
                    var temp = items[j];
                    items[j] = items[j + 1];
                    items[j + 1] = temp;
                }
            }
        }
    }

    // Quick Sort - O(n log n) average case
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

    // Merge Sort - O(n log n)
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
        lsbPerms.Items.Clear();

        if (!string.IsNullOrEmpty(selectedRole) && permissions.ContainsKey(selectedRole))
        {
            foreach (var user in permissions[selectedRole])
            {
                lsbPerms.Items.Add(user);
            }
        }
    }

    private void permissionListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (lsbPerms.SelectedItem != null)
        {
            txbUsername.Text = lsbPerms.SelectedItem.ToString();
        }
    }
}