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

        private void roleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshPermsList();
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

