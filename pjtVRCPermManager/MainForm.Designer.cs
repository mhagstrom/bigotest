namespace pjtVRCPermManager;

partial class MainForm
{
    private System.ComponentModel.IContainer components = null;
    
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code
    
    private void InitializeComponent()
    {
        txbUsername = new TextBox();
        cmbRoles = new ComboBox();
        lsbPerms = new ListBox();
        addUserButton = new Button();
        assignRoleButton = new Button();
        removeRoleButton = new Button();
        usernameLabel = new Label();
        roleLabel = new Label();
        permissionsLabel = new Label();
        searchButton = new Button();
        userRolesButton = new Button();
        sortButton = new Button();
        searchResultsLabel = new Label();
        lsbResults = new ListBox();
        cmbSortMethod = new ComboBox();

        // Label for username entry
        usernameLabel.AutoSize = true;
        usernameLabel.Location = new Point(12, 15);
        usernameLabel.Name = "usernameLabel";
        usernameLabel.Size = new Size(75, 20);
        usernameLabel.Text = "Username:";

        // Text field for username entry
        txbUsername.AutoSize = true;
        txbUsername.Location = new Point(93, 12);
        txbUsername.Name = "txbUsername";
        txbUsername.Size = new Size(200, 27);
        txbUsername.MinimumSize = new Size(200, 27);

        // Label for roles dropdown
        roleLabel.AutoSize = true;
        roleLabel.Location = new Point(12, 52);
        roleLabel.Name = "roleLabel";
        roleLabel.Size = new Size(42, 20);
        roleLabel.Text = "Role:";

        // Dropdown for role
        cmbRoles.AutoSize = true;
        cmbRoles.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbRoles.Location = new Point(93, 49);
        cmbRoles.Name = "cmbRoles";
        cmbRoles.Size = new Size(200, 28);
        cmbRoles.MinimumSize = new Size(200, 28);

        // Label for perms ListBox
        permissionsLabel.AutoSize = true;
        permissionsLabel.Location = new Point(12, 92);
        permissionsLabel.Name = "permissionsLabel";
        permissionsLabel.Size = new Size(89, 20);
        permissionsLabel.Text = "Permissions:";

        // ListBox of perms
        lsbPerms.Location = new Point(12, 115);
        lsbPerms.Name = "lsbPerms";
        lsbPerms.Size = new Size(281, 244);
        lsbPerms.MinimumSize = new Size(281, 244);

        // Button to add user to whitelist
        addUserButton.AutoSize = true;
        addUserButton.Location = new Point(309, 11);
        addUserButton.Name = "addUserButton";
        addUserButton.Size = new Size(94, 29);
        addUserButton.MinimumSize = new Size(94, 29);
        addUserButton.Text = "Add User";

        // Button to assign role to user
        assignRoleButton.AutoSize = true;
        assignRoleButton.Location = new Point(309, 48);
        assignRoleButton.Name = "assignRoleButton";
        assignRoleButton.Size = new Size(104, 29);
        assignRoleButton.MinimumSize = new Size(104, 29);
        assignRoleButton.Text = "Assign Role";

        // Button to remove role from user
        removeRoleButton.AutoSize = true;
        removeRoleButton.Location = new Point(309, 85);
        removeRoleButton.Name = "removeRoleButton";
        removeRoleButton.Size = new Size(114, 29);
        removeRoleButton.MinimumSize = new Size(114, 29);
        removeRoleButton.Text = "Remove Role";

        // Search button
        searchButton.AutoSize = true;
        searchButton.Location = new Point(309, 122);
        searchButton.Name = "searchButton";
        searchButton.Size = new Size(114, 29);
        searchButton.MinimumSize = new Size(114, 29);
        searchButton.Text = "Search User";
        searchButton.Click += searchButton_Click;

        // User roles button
        userRolesButton.AutoSize = true;
        userRolesButton.Location = new Point(309, 159);
        userRolesButton.Name = "userRolesButton";
        userRolesButton.Size = new Size(114, 29);
        userRolesButton.MinimumSize = new Size(114, 29);
        userRolesButton.Text = "Show User Roles";
        userRolesButton.Click += userRolesButton_Click;

        // Sort method combo box
        cmbSortMethod.AutoSize = true;
        cmbSortMethod.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbSortMethod.Location = new Point(309, 196);
        cmbSortMethod.Name = "cmbSortMethod";
        cmbSortMethod.Size = new Size(114, 28);
        cmbSortMethod.MinimumSize = new Size(114, 28);
        cmbSortMethod.Items.AddRange(new object[] { "Bubble Sort", "Quick Sort", "Merge Sort" });

        // Sort button
        sortButton.AutoSize = true;
        sortButton.Location = new Point(309, 233);
        sortButton.Name = "sortButton";
        sortButton.Size = new Size(114, 29);
        sortButton.MinimumSize = new Size(114, 29);
        sortButton.Text = "Sort Results";
        sortButton.Click += sortButton_Click;

        // Search results label
        searchResultsLabel.AutoSize = true;
        searchResultsLabel.Location = new Point(436, 15);
        searchResultsLabel.Name = "searchResultsLabel";
        searchResultsLabel.Size = new Size(89, 20);
        searchResultsLabel.Text = "Results:";

        // Results ListBox
        lsbResults.Location = new Point(436, 38);
        lsbResults.Name = "lsbResults";
        lsbResults.Size = new Size(281, 321);
        lsbResults.MinimumSize = new Size(281, 321);

        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(734, 371);
        MinimumSize = new Size(750, 410);
        Controls.AddRange(new Control[] {
            usernameLabel,
            txbUsername,
            roleLabel,
            cmbRoles,
            permissionsLabel,
            lsbPerms,
            addUserButton,
            assignRoleButton,
            removeRoleButton,
            searchButton,
            userRolesButton,
            cmbSortMethod,
            sortButton,
            searchResultsLabel,
            lsbResults
        });
        Name = "MainForm";
        Text = "VRC Permission Manager";
    }

    #endregion

    private TextBox txbUsername;
    private ComboBox cmbRoles;
    private ListBox lsbPerms;
    private Button addUserButton;
    private Button assignRoleButton;
    private Button removeRoleButton;
    private Button searchButton;
    private Button userRolesButton;
    private Button sortButton;
    private ComboBox cmbSortMethod;
    private Label usernameLabel;
    private Label roleLabel;
    private Label permissionsLabel;
    private Label searchResultsLabel;
    private ListBox lsbResults;
}