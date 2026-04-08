namespace BankApp.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        // Sidebar and Header
        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.DataGridView dgvAccounts;

        // Sidebar Buttons
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnNewAccount;
        private System.Windows.Forms.Button btnEditAccount;
        private System.Windows.Forms.Button btnDeposit;
        private System.Windows.Forms.Button btnWithdraw;
        private System.Windows.Forms.Button btnTransfer;
        private System.Windows.Forms.Button btnTransactions;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.PictureBox pictureBoxLogo;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            panelSidebar = new System.Windows.Forms.Panel();
            btnLogout = new System.Windows.Forms.Button();
            btnTransactions = new System.Windows.Forms.Button();
            btnTransfer = new System.Windows.Forms.Button();
            btnWithdraw = new System.Windows.Forms.Button();
            btnDeposit = new System.Windows.Forms.Button();
            btnEditAccount = new System.Windows.Forms.Button();
            btnNewAccount = new System.Windows.Forms.Button();
            btnDashboard = new System.Windows.Forms.Button();
            pictureBoxLogo = new System.Windows.Forms.PictureBox();
            panelHeader = new System.Windows.Forms.Panel();
            lblHeaderTitle = new System.Windows.Forms.Label();
            dgvAccounts = new System.Windows.Forms.DataGridView();
            panelSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAccounts).BeginInit();
            SuspendLayout();
            // 
            // panelSidebar
            // 
            panelSidebar.BackColor = System.Drawing.Color.FromArgb(20, 25, 50);
            panelSidebar.Controls.Add(btnLogout);
            panelSidebar.Controls.Add(btnTransactions);
            panelSidebar.Controls.Add(btnTransfer);
            panelSidebar.Controls.Add(btnWithdraw);
            panelSidebar.Controls.Add(btnDeposit);
            panelSidebar.Controls.Add(btnEditAccount);
            panelSidebar.Controls.Add(btnNewAccount);
            panelSidebar.Controls.Add(btnDashboard);
            panelSidebar.Controls.Add(pictureBoxLogo);
            panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            panelSidebar.Location = new System.Drawing.Point(0, 0);
            panelSidebar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Size = new System.Drawing.Size(286, 933);
            panelSidebar.TabIndex = 1;
            // 
            // btnLogout
            // 
            btnLogout.Dock = System.Windows.Forms.DockStyle.Bottom;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnLogout.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            btnLogout.ForeColor = System.Drawing.Color.DarkOrange;
            btnLogout.Location = new System.Drawing.Point(0, 853);
            btnLogout.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnLogout.Name = "btnLogout";
            btnLogout.Padding = new System.Windows.Forms.Padding(23, 0, 0, 0);
            btnLogout.Size = new System.Drawing.Size(286, 80);
            btnLogout.TabIndex = 7;
            btnLogout.Text = " Close App";
            btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnTransactions
            // 
            btnTransactions.Dock = System.Windows.Forms.DockStyle.Top;
            btnTransactions.FlatAppearance.BorderSize = 0;
            btnTransactions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnTransactions.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            btnTransactions.ForeColor = System.Drawing.Color.Gainsboro;
            btnTransactions.Location = new System.Drawing.Point(0, 602);
            btnTransactions.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnTransactions.Name = "btnTransactions";
            btnTransactions.Padding = new System.Windows.Forms.Padding(23, 0, 0, 0);
            btnTransactions.Size = new System.Drawing.Size(286, 67);
            btnTransactions.TabIndex = 6;
            btnTransactions.Text = " Audit Logs";
            btnTransactions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnTransactions.UseVisualStyleBackColor = true;
            btnTransactions.Click += btnTransactions_Click;
            // 
            // btnTransfer
            // 
            btnTransfer.Dock = System.Windows.Forms.DockStyle.Top;
            btnTransfer.FlatAppearance.BorderSize = 0;
            btnTransfer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnTransfer.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            btnTransfer.ForeColor = System.Drawing.Color.Gainsboro;
            btnTransfer.Location = new System.Drawing.Point(0, 535);
            btnTransfer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnTransfer.Name = "btnTransfer";
            btnTransfer.Padding = new System.Windows.Forms.Padding(23, 0, 0, 0);
            btnTransfer.Size = new System.Drawing.Size(286, 67);
            btnTransfer.TabIndex = 5;
            btnTransfer.Text = " Transfer Funds";
            btnTransfer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnTransfer.UseVisualStyleBackColor = true;
            btnTransfer.Click += btnTransfer_Click;
            // 
            // btnWithdraw
            // 
            btnWithdraw.Dock = System.Windows.Forms.DockStyle.Top;
            btnWithdraw.FlatAppearance.BorderSize = 0;
            btnWithdraw.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnWithdraw.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            btnWithdraw.ForeColor = System.Drawing.Color.Gainsboro;
            btnWithdraw.Location = new System.Drawing.Point(0, 468);
            btnWithdraw.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnWithdraw.Name = "btnWithdraw";
            btnWithdraw.Padding = new System.Windows.Forms.Padding(23, 0, 0, 0);
            btnWithdraw.Size = new System.Drawing.Size(286, 67);
            btnWithdraw.TabIndex = 4;
            btnWithdraw.Text = " Withdraw Funds";
            btnWithdraw.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnWithdraw.UseVisualStyleBackColor = true;
            btnWithdraw.Click += btnWithdraw_Click;
            // 
            // btnDeposit
            // 
            btnDeposit.Dock = System.Windows.Forms.DockStyle.Top;
            btnDeposit.FlatAppearance.BorderSize = 0;
            btnDeposit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnDeposit.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            btnDeposit.ForeColor = System.Drawing.Color.Gainsboro;
            btnDeposit.Location = new System.Drawing.Point(0, 401);
            btnDeposit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnDeposit.Name = "btnDeposit";
            btnDeposit.Padding = new System.Windows.Forms.Padding(23, 0, 0, 0);
            btnDeposit.Size = new System.Drawing.Size(286, 67);
            btnDeposit.TabIndex = 3;
            btnDeposit.Text = " Deposit Funds";
            btnDeposit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnDeposit.UseVisualStyleBackColor = true;
            btnDeposit.Click += btnDeposit_Click;
            // 
            // btnEditAccount
            // 
            btnEditAccount.Dock = System.Windows.Forms.DockStyle.Top;
            btnEditAccount.FlatAppearance.BorderSize = 0;
            btnEditAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnEditAccount.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            btnEditAccount.ForeColor = System.Drawing.Color.Gainsboro;
            btnEditAccount.Location = new System.Drawing.Point(0, 334);
            btnEditAccount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnEditAccount.Name = "btnEditAccount";
            btnEditAccount.Padding = new System.Windows.Forms.Padding(23, 0, 0, 0);
            btnEditAccount.Size = new System.Drawing.Size(286, 67);
            btnEditAccount.TabIndex = 8;
            btnEditAccount.Text = " Edit Account";
            btnEditAccount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnEditAccount.UseVisualStyleBackColor = true;
            btnEditAccount.Click += btnEditAccount_Click;
            // 
            // btnNewAccount
            // 
            btnNewAccount.Dock = System.Windows.Forms.DockStyle.Top;
            btnNewAccount.FlatAppearance.BorderSize = 0;
            btnNewAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnNewAccount.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            btnNewAccount.ForeColor = System.Drawing.Color.Gainsboro;
            btnNewAccount.Location = new System.Drawing.Point(0, 267);
            btnNewAccount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnNewAccount.Name = "btnNewAccount";
            btnNewAccount.Padding = new System.Windows.Forms.Padding(23, 0, 0, 0);
            btnNewAccount.Size = new System.Drawing.Size(286, 67);
            btnNewAccount.TabIndex = 2;
            btnNewAccount.Text = " Create Account";
            btnNewAccount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnNewAccount.UseVisualStyleBackColor = true;
            btnNewAccount.Click += btnNewAccount_Click;
            // 
            // btnDashboard
            // 
            btnDashboard.Dock = System.Windows.Forms.DockStyle.Top;
            btnDashboard.FlatAppearance.BorderSize = 0;
            btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnDashboard.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            btnDashboard.ForeColor = System.Drawing.Color.Gainsboro;
            btnDashboard.Location = new System.Drawing.Point(0, 200);
            btnDashboard.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Padding = new System.Windows.Forms.Padding(23, 0, 0, 0);
            btnDashboard.Size = new System.Drawing.Size(286, 67);
            btnDashboard.TabIndex = 1;
            btnDashboard.Text = " Dashboard Overview";
            btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnDashboard.UseVisualStyleBackColor = true;
            btnDashboard.Click += btnDashboard_Click;
            // 
            // pictureBoxLogo
            // 
            pictureBoxLogo.Dock = System.Windows.Forms.DockStyle.Top;
            pictureBoxLogo.Image = (System.Drawing.Image)resources.GetObject("pictureBoxLogo.Image");
            pictureBoxLogo.Location = new System.Drawing.Point(0, 0);
            pictureBoxLogo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            pictureBoxLogo.Name = "pictureBoxLogo";
            pictureBoxLogo.Size = new System.Drawing.Size(286, 200);
            pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            pictureBoxLogo.TabIndex = 0;
            pictureBoxLogo.TabStop = false;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = System.Drawing.Color.White;
            panelHeader.Controls.Add(lblHeaderTitle);
            panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            panelHeader.Location = new System.Drawing.Point(286, 0);
            panelHeader.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new System.Drawing.Size(971, 107);
            panelHeader.TabIndex = 2;
            // 
            // lblHeaderTitle
            // 
            lblHeaderTitle.AutoSize = true;
            lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            lblHeaderTitle.ForeColor = System.Drawing.Color.FromArgb(20, 25, 50);
            lblHeaderTitle.Location = new System.Drawing.Point(34, 33);
            lblHeaderTitle.Name = "lblHeaderTitle";
            lblHeaderTitle.Size = new System.Drawing.Size(405, 41);
            lblHeaderTitle.TabIndex = 0;
            lblHeaderTitle.Text = "DBS Centralized Dashboard";
            // 
            // dgvAccounts
            // 
            dgvAccounts.AllowUserToAddRows = false;
            dgvAccounts.AllowUserToDeleteRows = false;
            dgvAccounts.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgvAccounts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvAccounts.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            dgvAccounts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dgvAccounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAccounts.Location = new System.Drawing.Point(320, 147);
            dgvAccounts.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            dgvAccounts.Name = "dgvAccounts";
            dgvAccounts.ReadOnly = true;
            dgvAccounts.RowHeadersWidth = 51;
            dgvAccounts.RowTemplate.Height = 35;
            dgvAccounts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvAccounts.Size = new System.Drawing.Size(903, 747);
            dgvAccounts.TabIndex = 3;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.WhiteSmoke;
            ClientSize = new System.Drawing.Size(1257, 933);
            Controls.Add(dgvAccounts);
            Controls.Add(panelHeader);
            Controls.Add(panelSidebar);
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            MinimumSize = new System.Drawing.Size(1140, 851);
            Name = "MainForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Bank Application Dashboard";
            Load += MainForm_Load;
            panelSidebar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAccounts).EndInit();
            ResumeLayout(false);
        }
    }
}
