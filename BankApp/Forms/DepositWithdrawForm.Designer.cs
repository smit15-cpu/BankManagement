namespace BankApp.Forms
{
    partial class DepositWithdrawForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblHeader;
        
        private System.Windows.Forms.Label lblAccInfo;
        private System.Windows.Forms.Label lblCurrentBalance;
        private System.Windows.Forms.Label lblAvailable;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Button btnSubmit;

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
            panelTop = new System.Windows.Forms.Panel();
            lblHeader = new System.Windows.Forms.Label();
            lblAccInfo = new System.Windows.Forms.Label();
            lblCurrentBalance = new System.Windows.Forms.Label();
            lblAvailable = new System.Windows.Forms.Label();
            lblAmount = new System.Windows.Forms.Label();
            txtAmount = new System.Windows.Forms.TextBox();
            btnSubmit = new System.Windows.Forms.Button();
            panelTop.SuspendLayout();
            SuspendLayout();
            
          
            
            panelTop.BackColor = System.Drawing.Color.Navy;
            panelTop.Controls.Add(lblHeader);
            panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            panelTop.Location = new System.Drawing.Point(0, 0);
            panelTop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panelTop.Name = "panelTop";
            panelTop.Size = new System.Drawing.Size(457, 93);
            panelTop.TabIndex = 0;
            
            
            lblHeader.AutoSize = true;
            lblHeader.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            lblHeader.ForeColor = System.Drawing.Color.White;
            lblHeader.Location = new System.Drawing.Point(23, 27);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new System.Drawing.Size(117, 37);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "Deposit";
           
           
            lblAccInfo.AutoSize = true;
            lblAccInfo.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            lblAccInfo.Location = new System.Drawing.Point(46, 133);
            lblAccInfo.Name = "lblAccInfo";
            lblAccInfo.Size = new System.Drawing.Size(91, 28);
            lblAccInfo.TabIndex = 1;
            lblAccInfo.Text = "Account:";
            

            lblCurrentBalance.AutoSize = true;
            lblCurrentBalance.Font = new System.Drawing.Font("Segoe UI", 11F);
            lblCurrentBalance.Location = new System.Drawing.Point(46, 187);
            lblCurrentBalance.Name = "lblCurrentBalance";
            lblCurrentBalance.Size = new System.Drawing.Size(151, 25);
            lblCurrentBalance.TabIndex = 2;
            lblCurrentBalance.Text = "Current Balance:";
            
            
            lblAvailable.AutoSize = true;
            lblAvailable.Font = new System.Drawing.Font("Segoe UI", 11F);
            lblAvailable.ForeColor = System.Drawing.Color.DarkGreen;
            lblAvailable.Location = new System.Drawing.Point(46, 227);
            lblAvailable.Name = "lblAvailable";
            lblAvailable.Size = new System.Drawing.Size(198, 25);
            lblAvailable.TabIndex = 3;
            lblAvailable.Text = "Available to withdraw:";
            lblAvailable.Visible = false;
            

            lblAmount.AutoSize = true;
            lblAmount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            lblAmount.Location = new System.Drawing.Point(46, 293);
            lblAmount.Name = "lblAmount";
            lblAmount.Size = new System.Drawing.Size(93, 28);
            lblAmount.TabIndex = 4;
            lblAmount.Text = "Amount:";
            

            txtAmount.Font = new System.Drawing.Font("Segoe UI", 14F);
            txtAmount.Location = new System.Drawing.Point(171, 287);
            txtAmount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new System.Drawing.Size(228, 39);
            txtAmount.TabIndex = 5;
             
            btnSubmit.BackColor = System.Drawing.Color.Navy;
            btnSubmit.Cursor = System.Windows.Forms.Cursors.Hand;
            btnSubmit.FlatAppearance.BorderSize = 0;
            btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnSubmit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            btnSubmit.ForeColor = System.Drawing.Color.White;
            btnSubmit.Location = new System.Drawing.Point(46, 373);
            btnSubmit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new System.Drawing.Size(354, 60);
            btnSubmit.TabIndex = 6;
            btnSubmit.Text = "SUBMIT";
            btnSubmit.UseVisualStyleBackColor = false;
            btnSubmit.Click += btnSubmit_Click;
            

            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.WhiteSmoke;
            ClientSize = new System.Drawing.Size(457, 480);
            Controls.Add(btnSubmit);
            Controls.Add(txtAmount);
            Controls.Add(lblAmount);
            Controls.Add(lblAvailable);
            Controls.Add(lblCurrentBalance);
            Controls.Add(lblAccInfo);
            Controls.Add(panelTop);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DepositWithdrawForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Transaction Details";
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
