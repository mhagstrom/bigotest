﻿namespace pjtVRCPermManager;

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
        txbUsername = new System.Windows.Forms.TextBox();
        cmbRoles = new System.Windows.Forms.ComboBox();
        lsbUsers = new System.Windows.Forms.ListBox();
        addUserButton = new System.Windows.Forms.Button();
        assignRoleButton = new System.Windows.Forms.Button();
        removeRoleButton = new System.Windows.Forms.Button();
        usernameLabel = new System.Windows.Forms.Label();
        roleLabel = new System.Windows.Forms.Label();
        lsbUsernames = new System.Windows.Forms.Label();
        btnSearch = new System.Windows.Forms.Button();
        btnUserRoles = new System.Windows.Forms.Button();
        btnSort = new System.Windows.Forms.Button();
        lblSearchResults = new System.Windows.Forms.Label();
        lsbResults = new System.Windows.Forms.ListBox();
        cmbSortMethod = new System.Windows.Forms.ComboBox();
        cmbSearchMethod = new System.Windows.Forms.ComboBox();
        lblSearchType = new System.Windows.Forms.Label();
        lblNewPermission = new System.Windows.Forms.Label();
        txbNewPermission = new System.Windows.Forms.TextBox();
        btnAddPermission = new System.Windows.Forms.Button();
        btnRemovePermission = new System.Windows.Forms.Button();
        nudUserCount = new System.Windows.Forms.NumericUpDown();
        btnGenerateUsers = new System.Windows.Forms.Button();
        btnRandomizePerms = new System.Windows.Forms.Button();
        lblUserCount = new System.Windows.Forms.Label();
        nudPermCount = new System.Windows.Forms.NumericUpDown();
        btnGeneratePerms = new System.Windows.Forms.Button();
        lblPermCount = new System.Windows.Forms.Label();
        ((System.ComponentModel.ISupportInitialize)nudUserCount).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudPermCount).BeginInit();
        SuspendLayout();
        
        txbUsername.Location = new System.Drawing.Point(93, 12);
        txbUsername.MinimumSize = new System.Drawing.Size(200, 27);
        txbUsername.Name = "txbUsername";
        txbUsername.Size = new System.Drawing.Size(200, 27);
        txbUsername.TabIndex = 12;
       
        cmbRoles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        cmbRoles.Location = new System.Drawing.Point(93, 49);
        cmbRoles.MinimumSize = new System.Drawing.Size(200, 0);
        cmbRoles.Name = "cmbRoles";
        cmbRoles.Size = new System.Drawing.Size(200, 28);
        cmbRoles.TabIndex = 14;
      
        lsbUsers.Location = new System.Drawing.Point(12, 108);
        lsbUsers.MinimumSize = new System.Drawing.Size(281, 244);
        lsbUsers.Name = "lsbUsers";
        lsbUsers.Size = new System.Drawing.Size(281, 244);
        lsbUsers.TabIndex = 16;
        
        addUserButton.AutoSize = true;
        addUserButton.Location = new System.Drawing.Point(309, 11);
        addUserButton.MinimumSize = new System.Drawing.Size(94, 29);
        addUserButton.Name = "addUserButton";
        addUserButton.Size = new System.Drawing.Size(94, 30);
        addUserButton.TabIndex = 17;
        addUserButton.Text = "Add User";
        addUserButton.Click += addUserButton_Click;
        
        assignRoleButton.AutoSize = true;
        assignRoleButton.Location = new System.Drawing.Point(309, 48);
        assignRoleButton.MinimumSize = new System.Drawing.Size(104, 29);
        assignRoleButton.Name = "assignRoleButton";
        assignRoleButton.Size = new System.Drawing.Size(104, 30);
        assignRoleButton.TabIndex = 18;
        assignRoleButton.Text = "Assign Role";
        
        removeRoleButton.AutoSize = true;
        removeRoleButton.Location = new System.Drawing.Point(309, 85);
        removeRoleButton.MinimumSize = new System.Drawing.Size(114, 29);
        removeRoleButton.Name = "removeRoleButton";
        removeRoleButton.Size = new System.Drawing.Size(114, 30);
        removeRoleButton.TabIndex = 19;
        removeRoleButton.Text = "Remove Role";
        
        usernameLabel.AutoSize = true;
        usernameLabel.Location = new System.Drawing.Point(12, 15);
        usernameLabel.Name = "usernameLabel";
        usernameLabel.Size = new System.Drawing.Size(78, 20);
        usernameLabel.TabIndex = 11;
        usernameLabel.Text = "Username:";
        
        roleLabel.AutoSize = true;
        roleLabel.Location = new System.Drawing.Point(12, 52);
        roleLabel.Name = "roleLabel";
        roleLabel.Size = new System.Drawing.Size(82, 20);
        roleLabel.TabIndex = 13;
        roleLabel.Text = "Permission:";
        
        lsbUsernames.AutoSize = true;
        lsbUsernames.Location = new System.Drawing.Point(12, 85);
        lsbUsernames.Name = "lsbUsernames";
        lsbUsernames.Size = new System.Drawing.Size(47, 20);
        lsbUsernames.TabIndex = 15;
        lsbUsernames.Text = "Users:";
        
        btnSearch.AutoSize = true;
        btnSearch.Location = new System.Drawing.Point(309, 122);
        btnSearch.MinimumSize = new System.Drawing.Size(114, 29);
        btnSearch.Name = "btnSearch";
        btnSearch.Size = new System.Drawing.Size(114, 30);
        btnSearch.TabIndex = 20;
        btnSearch.Text = "Search";
        btnSearch.Click += searchButton_Click;
        
        btnUserRoles.AutoSize = true;
        btnUserRoles.Location = new System.Drawing.Point(309, 159);
        btnUserRoles.MinimumSize = new System.Drawing.Size(114, 29);
        btnUserRoles.Name = "btnUserRoles";
        btnUserRoles.Size = new System.Drawing.Size(128, 30);
        btnUserRoles.TabIndex = 21;
        btnUserRoles.Text = "Show User Roles";
        btnUserRoles.Click += BtnUserRolesClick;
         
        btnSort.AutoSize = true;
        btnSort.Location = new System.Drawing.Point(309, 233);
        btnSort.MinimumSize = new System.Drawing.Size(114, 29);
        btnSort.Name = "btnSort";
        btnSort.Size = new System.Drawing.Size(114, 30);
        btnSort.TabIndex = 23;
        btnSort.Text = "Sort Results";
        btnSort.Click += BtnSortClick;
         
        lblSearchResults.AutoSize = true;
        lblSearchResults.Location = new System.Drawing.Point(436, 15);
        lblSearchResults.Name = "lblSearchResults";
        lblSearchResults.Size = new System.Drawing.Size(58, 20);
        lblSearchResults.TabIndex = 24;
        lblSearchResults.Text = "Results:";
         
        lsbResults.Location = new System.Drawing.Point(436, 38);
        lsbResults.MinimumSize = new System.Drawing.Size(281, 321);
        lsbResults.Name = "lsbResults";
        lsbResults.Size = new System.Drawing.Size(281, 304);
        lsbResults.TabIndex = 25;
         
        cmbSortMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        cmbSortMethod.Items.AddRange(new object[] { "Bubble Sort", "Quick Sort", "Merge Sort" });
        cmbSortMethod.Location = new System.Drawing.Point(309, 196);
        cmbSortMethod.MinimumSize = new System.Drawing.Size(114, 0);
        cmbSortMethod.Name = "cmbSortMethod";
        cmbSortMethod.Size = new System.Drawing.Size(114, 28);
        cmbSortMethod.TabIndex = 22;
         
        cmbSearchMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        cmbSearchMethod.Items.AddRange(new object[] { "Linear Search", "Binary Search" });
        cmbSearchMethod.Location = new System.Drawing.Point(309, 293);
        cmbSearchMethod.MinimumSize = new System.Drawing.Size(114, 0);
        cmbSearchMethod.Name = "cmbSearchMethod";
        cmbSearchMethod.Size = new System.Drawing.Size(114, 28);
        cmbSearchMethod.TabIndex = 27;
         
        lblSearchType.AutoSize = true;
        lblSearchType.Location = new System.Drawing.Point(309, 270);
        lblSearchType.Name = "lblSearchType";
        lblSearchType.Size = new System.Drawing.Size(112, 20);
        lblSearchType.TabIndex = 26;
        lblSearchType.Text = "Search Method:";
         
        lblNewPermission.AutoSize = true;
        lblNewPermission.Location = new System.Drawing.Point(12, 362);
        lblNewPermission.Name = "lblNewPermission";
        lblNewPermission.Size = new System.Drawing.Size(116, 20);
        lblNewPermission.TabIndex = 3;
        lblNewPermission.Text = "New Permission:";
         
        txbNewPermission.Location = new System.Drawing.Point(127, 359);
        txbNewPermission.Name = "txbNewPermission";
        txbNewPermission.Size = new System.Drawing.Size(150, 27);
        txbNewPermission.TabIndex = 4;
         
        btnAddPermission.Location = new System.Drawing.Point(283, 359);
        btnAddPermission.Name = "btnAddPermission";
        btnAddPermission.Size = new System.Drawing.Size(94, 29);
        btnAddPermission.TabIndex = 5;
        btnAddPermission.Text = "Add";
        btnAddPermission.UseVisualStyleBackColor = true;
        btnAddPermission.Click += addPermissionButton_Click;
         
        btnRemovePermission.Location = new System.Drawing.Point(383, 359);
        btnRemovePermission.Name = "btnRemovePermission";
        btnRemovePermission.Size = new System.Drawing.Size(94, 29);
        btnRemovePermission.TabIndex = 6;
        btnRemovePermission.Text = "Remove";
        btnRemovePermission.UseVisualStyleBackColor = true;
        btnRemovePermission.Click += removePermissionButton_Click;
         
        nudUserCount.Location = new System.Drawing.Point(127, 388);
        nudUserCount.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
        nudUserCount.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        nudUserCount.Name = "nudUserCount";
        nudUserCount.Size = new System.Drawing.Size(150, 27);
        nudUserCount.TabIndex = 8;
        nudUserCount.Value = new decimal(new int[] { 100, 0, 0, 0 });
         
        btnGenerateUsers.Location = new System.Drawing.Point(283, 387);
        btnGenerateUsers.Name = "btnGenerateUsers";
        btnGenerateUsers.Size = new System.Drawing.Size(94, 29);
        btnGenerateUsers.TabIndex = 9;
        btnGenerateUsers.Text = "Generate";
        btnGenerateUsers.UseVisualStyleBackColor = true;
        btnGenerateUsers.Click += generateUsersButton_Click;
         
        btnRandomizePerms.Location = new System.Drawing.Point(383, 387);
        btnRandomizePerms.Name = "btnRandomizePerms";
        btnRandomizePerms.Size = new System.Drawing.Size(94, 29);
        btnRandomizePerms.TabIndex = 10;
        btnRandomizePerms.Text = "Randomize";
        btnRandomizePerms.UseVisualStyleBackColor = true;
        btnRandomizePerms.Click += randomizePermsButton_Click;
         
        lblUserCount.AutoSize = true;
        lblUserCount.Location = new System.Drawing.Point(12, 390);
        lblUserCount.Name = "lblUserCount";
        lblUserCount.Size = new System.Drawing.Size(123, 20);
        lblUserCount.TabIndex = 7;
        lblUserCount.Text = "Number of Users:";
        
        nudPermCount.Location = new System.Drawing.Point(127, 428);
        nudPermCount.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
        nudPermCount.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        nudPermCount.Name = "nudPermCount";
        nudPermCount.Size = new System.Drawing.Size(150, 27);
        nudPermCount.TabIndex = 1;
        nudPermCount.Value = new decimal(new int[] { 10, 0, 0, 0 });
         
        btnGeneratePerms.Location = new System.Drawing.Point(283, 427);
        btnGeneratePerms.Name = "btnGeneratePerms";
        btnGeneratePerms.Size = new System.Drawing.Size(194, 29);
        btnGeneratePerms.TabIndex = 2;
        btnGeneratePerms.Text = "Generate Permissions";
        btnGeneratePerms.UseVisualStyleBackColor = true;
        btnGeneratePerms.Click += generatePermissionsButton_Click;
         
        lblPermCount.AutoSize = true;
        lblPermCount.Location = new System.Drawing.Point(12, 430);
        lblPermCount.Name = "lblPermCount";
        lblPermCount.Size = new System.Drawing.Size(122, 20);
        lblPermCount.TabIndex = 0;
        lblPermCount.Text = "New Permissions:";
         
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(734, 391);
        Controls.Add(lblPermCount);
        Controls.Add(nudPermCount);
        Controls.Add(btnGeneratePerms);
        Controls.Add(lblNewPermission);
        Controls.Add(txbNewPermission);
        Controls.Add(btnAddPermission);
        Controls.Add(btnRemovePermission);
        Controls.Add(lblUserCount);
        Controls.Add(nudUserCount);
        Controls.Add(btnGenerateUsers);
        Controls.Add(btnRandomizePerms);
        Controls.Add(usernameLabel);
        Controls.Add(txbUsername);
        Controls.Add(roleLabel);
        Controls.Add(cmbRoles);
        Controls.Add(lsbUsernames);
        Controls.Add(lsbUsers);
        Controls.Add(addUserButton);
        Controls.Add(assignRoleButton);
        Controls.Add(removeRoleButton);
        Controls.Add(btnSearch);
        Controls.Add(btnUserRoles);
        Controls.Add(cmbSortMethod);
        Controls.Add(btnSort);
        Controls.Add(lblSearchResults);
        Controls.Add(lsbResults);
        Controls.Add(lblSearchType);
        Controls.Add(cmbSearchMethod);
        MinimumSize = new System.Drawing.Size(750, 410);
        Text = "User Perms Manager";
        ((System.ComponentModel.ISupportInitialize)nudUserCount).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudPermCount).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private TextBox txbUsername;
    private ComboBox cmbRoles;
    private System.Windows.Forms.ListBox lsbUsers;
    private Button addUserButton;
    private Button assignRoleButton;
    private Button removeRoleButton;
    private Button btnSearch;
    private Button btnUserRoles;
    private Button btnSort;
    private ComboBox cmbSortMethod;
    private Label usernameLabel;
    private System.Windows.Forms.Label roleLabel;
    private System.Windows.Forms.Label lsbUsernames;
    private Label lblSearchResults;
    private ListBox lsbResults;
    private ComboBox cmbSearchMethod;
    private Label lblSearchType;
    private System.Windows.Forms.TextBox txbNewPermission;
    private System.Windows.Forms.Button btnAddPermission;
    private System.Windows.Forms.Button btnRemovePermission;
    private System.Windows.Forms.Label lblNewPermission;
    private NumericUpDown nudUserCount;
    private Button btnGenerateUsers;
    private Button btnRandomizePerms;
    private Label lblUserCount;
    private NumericUpDown nudPermCount;
    private Button btnGeneratePerms;
    private Label lblPermCount;
}