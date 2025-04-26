namespace pk3DS
{
    partial class TMHMEditor6
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvTM = new System.Windows.Forms.DataGridView();
            L_TM = new System.Windows.Forms.Label();
            dgvHM = new System.Windows.Forms.DataGridView();
            L_HM = new System.Windows.Forms.Label();
            B_RTM = new System.Windows.Forms.Button();
            B_Export_TMHM = new System.Windows.Forms.Button();
            CHK_RandomizeHM = new System.Windows.Forms.CheckBox();
            CHK_RandomizeField = new System.Windows.Forms.CheckBox();
            groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)dgvTM).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvHM).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvTM
            // 
            dgvTM.AllowUserToAddRows = false;
            dgvTM.AllowUserToDeleteRows = false;
            dgvTM.AllowUserToResizeColumns = false;
            dgvTM.AllowUserToResizeRows = false;
            dgvTM.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            dgvTM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTM.Location = new System.Drawing.Point(10, 29);
            dgvTM.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            dgvTM.Name = "dgvTM";
            dgvTM.Size = new System.Drawing.Size(280, 346);
            dgvTM.TabIndex = 1;
            // 
            // L_TM
            // 
            L_TM.AutoSize = true;
            L_TM.Location = new System.Drawing.Point(10, 10);
            L_TM.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            L_TM.Name = "L_TM";
            L_TM.Size = new System.Drawing.Size(27, 15);
            L_TM.TabIndex = 2;
            L_TM.Text = "TM:";
            // 
            // dgvHM
            // 
            dgvHM.AllowUserToAddRows = false;
            dgvHM.AllowUserToDeleteRows = false;
            dgvHM.AllowUserToResizeColumns = false;
            dgvHM.AllowUserToResizeRows = false;
            dgvHM.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            dgvHM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHM.Location = new System.Drawing.Point(299, 29);
            dgvHM.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            dgvHM.Name = "dgvHM";
            dgvHM.Size = new System.Drawing.Size(280, 267);
            dgvHM.TabIndex = 3;
            // 
            // L_HM
            // 
            L_HM.AutoSize = true;
            L_HM.Location = new System.Drawing.Point(295, 10);
            L_HM.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            L_HM.Name = "L_HM";
            L_HM.Size = new System.Drawing.Size(30, 15);
            L_HM.TabIndex = 4;
            L_HM.Text = "HM:";
            // 
            // B_RTM
            // 
            B_RTM.Location = new System.Drawing.Point(48, 1);
            B_RTM.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            B_RTM.Name = "B_RTM";
            B_RTM.Size = new System.Drawing.Size(88, 27);
            B_RTM.TabIndex = 5;
            B_RTM.Text = "Randomize";
            B_RTM.UseVisualStyleBackColor = true;
            B_RTM.Click += B_RandomTM_Click;
            // 
            // B_Export_TMHM
            // 
            B_Export_TMHM.Location = new System.Drawing.Point(144, 1);
            B_Export_TMHM.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            B_Export_TMHM.Name = "B_Export_TMHM";
            B_Export_TMHM.Size = new System.Drawing.Size(88, 27);
            B_Export_TMHM.TabIndex = 5;
            B_Export_TMHM.Text = "Export Site";
            B_Export_TMHM.UseVisualStyleBackColor = true;
            B_Export_TMHM.Click += B_Export_TMHM_Click;
            // 
            // CHK_RandomizeHM
            // 
            CHK_RandomizeHM.AutoSize = true;
            CHK_RandomizeHM.Location = new System.Drawing.Point(15, 22);
            CHK_RandomizeHM.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            CHK_RandomizeHM.Name = "CHK_RandomizeHM";
            CHK_RandomizeHM.Size = new System.Drawing.Size(113, 19);
            CHK_RandomizeHM.TabIndex = 280;
            CHK_RandomizeHM.Text = "Randomize HMs";
            CHK_RandomizeHM.UseVisualStyleBackColor = true;
            // 
            // CHK_RandomizeField
            // 
            CHK_RandomizeField.AutoSize = true;
            CHK_RandomizeField.Location = new System.Drawing.Point(15, 42);
            CHK_RandomizeField.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            CHK_RandomizeField.Name = "CHK_RandomizeField";
            CHK_RandomizeField.Size = new System.Drawing.Size(151, 19);
            CHK_RandomizeField.TabIndex = 281;
            CHK_RandomizeField.Text = "Randomize Field Moves";
            CHK_RandomizeField.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(CHK_RandomizeHM);
            groupBox1.Controls.Add(CHK_RandomizeField);
            groupBox1.Location = new System.Drawing.Point(299, 302);
            groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox1.Size = new System.Drawing.Size(280, 73);
            groupBox1.TabIndex = 282;
            groupBox1.TabStop = false;
            groupBox1.Text = "Randomization Settings";
            // 
            // TMHMEditor6
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(597, 391);
            Controls.Add(groupBox1);
            Controls.Add(B_RTM);
            Controls.Add(B_Export_TMHM);
            Controls.Add(L_HM);
            Controls.Add(dgvHM);
            Controls.Add(L_TM);
            Controls.Add(dgvTM);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MaximumSize = new System.Drawing.Size(605, 768);
            MinimumSize = new System.Drawing.Size(605, 422);
            Name = "TMHMEditor6";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "TM / HM Editor";
            FormClosing += Form_Closing;
            ((System.ComponentModel.ISupportInitialize)dgvTM).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvHM).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTM;
        private System.Windows.Forms.Label L_TM;
        private System.Windows.Forms.DataGridView dgvHM;
        private System.Windows.Forms.Label L_HM;
        private System.Windows.Forms.Button B_RTM;
        private System.Windows.Forms.Button B_Export_TMHM;
        private System.Windows.Forms.CheckBox CHK_RandomizeHM;
        private System.Windows.Forms.CheckBox CHK_RandomizeField;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}