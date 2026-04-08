namespace BankApp.Forms
{
    partial class TransferForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblHeader;

        private System.Windows.Forms.Label lblSourceAcc;
        private System.Windows.Forms.Label lblBalance;
        
        private System.Windows.Forms.CheckBox chkInternal;
        private System.Windows.Forms.Label lblNotice;

        private System.Windows.Forms.Label lblDestSortCode;
        private System.Windows.Forms.TextBox txtDestSortCode;
        private System.Windows.Forms.Label lblDestAccNum;
        private System.Windows.Forms.TextBox txtDestAccNum;
        
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
            lblSourceAcc = new System.Windows.Forms.Label();
            lblBalance = new System.Windows.Forms.Label();
            chkInternal = new System.Windows.Forms.CheckBox();
            lblNotice = new System.Windows.Forms.Label();
            lblDestSortCode = new System.Windows.Forms.Label();
            txtDestSortCode = new System.Windows.Forms.TextBox();
            lblDestAccNum = new System.Windows.Forms.Label();
            txtDestAccNum = new System.Windows.Forms.TextBox();
            lblAmount = new System.Windows.Forms.Label();
            txtAmount = new System.Windows.Forms.TextBox();
            btnSubmit = new System.Windows.Forms.Button();
            panelTop.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = System.Drawing.Color.Navy;
            panelTop.Controls.Add(lblHeader);
            panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            panelTop.Location = new System.Drawing.Point(0, 0);
            panelTop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            panelTop.Name = "panelTop";
            panelTop.Size = new System.Drawing.Size(480, 93);
            panelTop.TabIndex = 0;
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            lblHeader.ForeColor = System.Drawing.Color.White;
            lblHeader.Location = new System.Drawing.Point(23, 27);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new System.Drawing.Size(203, 37);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "Transfer Funds";
            // 
            // lblSourceAcc
            // 
            lblSourceAcc.AutoSize = true;
            lblSourceAcc.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            lblSourceAcc.Location = new System.Drawing.Point(34, 120);
            lblSourceAcc.Name = "lblSourceAcc";
            lblSourceAcc.Size = new System.Drawing.Size(134, 23);
            lblSourceAcc.TabIndex = 1;
            lblSourceAcc.Text = "Source Account:";
            // 
            // lblBalance
            // 
            lblBalance.AutoSize = true;
            lblBalance.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblBalance.ForeColor = System.Drawing.Color.DarkGreen;
            lblBalance.Location = new System.Drawing.Point(34, 160);
            lblBalance.Name = "lblBalance";
            lblBalance.Size = new System.Drawing.Size(146, 23);
            lblBalance.TabIndex = 2;
            lblBalance.Text = "Available Balance:";
            // 
            // chkInternal
            // 
            chkInternal.AutoSize = true;
            chkInternal.Font = new System.Drawing.Font("Segoe UI", 10F);
            chkInternal.Location = new System.Drawing.Point(34, 213);
            chkInternal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            chkInternal.Name = "chkInternal";
            chkInternal.Size = new System.Drawing.Size(164, 27);
            chkInternal.TabIndex = 3;
            chkInternal.Text = "Internal Transfer?";
            chkInternal.UseVisualStyleBackColor = true;
            chkInternal.CheckedChanged += chkInternal_CheckedChanged;
            // 
            // lblNotice
            // 
            lblNotice.AutoSize = true;
            lblNotice.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            lblNotice.ForeColor = System.Drawing.Color.DarkOrange;
            lblNotice.Location = new System.Drawing.Point(194, 219);
            lblNotice.Name = "lblNotice";
            lblNotice.Size = new System.Drawing.Size(270, 20);
            lblNotice.TabIndex = 4;
            lblNotice.Text = "(Savings Accounts must transfer internal)";
            lblNotice.Visible = false;
            // 
            // lblDestSortCode
            // 
            lblDestSortCode.AutoSize = true;
            lblDestSortCode.Location = new System.Drawing.Point(34, 280);
            lblDestSortCode.Name = "lblDestSortCode";
            lblDestSortCode.Size = new System.Drawing.Size(158, 20);
            lblDestSortCode.TabIndex = 5;
            lblDestSortCode.Text = "Destination Sort Code:";
            // 
            // txtDestSortCode
            // 
            txtDestSortCode.Location = new System.Drawing.Point(194, 276);
            txtDestSortCode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            txtDestSortCode.Name = "txtDestSortCode";
            txtDestSortCode.Size = new System.Drawing.Size(228, 27);
            txtDestSortCode.TabIndex = 6;
            // 
            // lblDestAccNum
            // 
            lblDestAccNum.AutoSize = true;
            lblDestAccNum.Location = new System.Drawing.Point(34, 333);
            lblDestAccNum.Name = "lblDestAccNum";
            lblDestAccNum.Size = new System.Drawing.Size(152, 20);
            lblDestAccNum.TabIndex = 7;
            lblDestAccNum.Text = "Destination Acc Num:";
            // 
            // txtDestAccNum
            // 
            txtDestAccNum.Location = new System.Drawing.Point(194, 329);
            txtDestAccNum.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            txtDestAccNum.Name = "txtDestAccNum";
            txtDestAccNum.Size = new System.Drawing.Size(228, 27);
            txtDestAccNum.TabIndex = 8;
            // 
            // lblAmount
            // 
            lblAmount.AutoSize = true;
            lblAmount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            lblAmount.Location = new System.Drawing.Point(34, 407);
            lblAmount.Name = "lblAmount";
            lblAmount.Size = new System.Drawing.Size(93, 28);
            lblAmount.TabIndex = 9;
            lblAmount.Text = "Amount:";
            lblAmount.Click += lblAmount_Click;
            // 
            // txtAmount
            // 
            txtAmount.Font = new System.Drawing.Font("Segoe UI", 14F);
            txtAmount.Location = new System.Drawing.Point(194, 400);
            txtAmount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new System.Drawing.Size(228, 39);
            txtAmount.TabIndex = 10;
            // 
            // btnSubmit
            // 
            btnSubmit.BackColor = System.Drawing.Color.Navy;
            btnSubmit.Cursor = System.Windows.Forms.Cursors.Hand;
            btnSubmit.FlatAppearance.BorderSize = 0;
            btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnSubmit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            btnSubmit.ForeColor = System.Drawing.Color.White;
            btnSubmit.Location = new System.Drawing.Point(34, 480);
            btnSubmit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new System.Drawing.Size(389, 60);
            btnSubmit.TabIndex = 11;
            btnSubmit.Text = "TRANSFER FUNDS";
            btnSubmit.UseVisualStyleBackColor = false;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // TransferForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.WhiteSmoke;
            ClientSize = new System.Drawing.Size(480, 573);
            Controls.Add(btnSubmit);
            Controls.Add(txtAmount);
            Controls.Add(lblAmount);
            Controls.Add(txtDestAccNum);
            Controls.Add(lblDestAccNum);
            Controls.Add(txtDestSortCode);
            Controls.Add(lblDestSortCode);
            Controls.Add(lblNotice);
            Controls.Add(chkInternal);
            Controls.Add(lblBalance);
            Controls.Add(lblSourceAcc);
            Controls.Add(panelTop);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TransferForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Transfer Funds";
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
