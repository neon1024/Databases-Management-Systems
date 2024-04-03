namespace s2_926
{
    partial class Form1
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
            this.dataGridViewBoards = new System.Windows.Forms.DataGridView();
            this.dataGridViewTasks = new System.Windows.Forms.DataGridView();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.taskNameTextBox = new System.Windows.Forms.TextBox();
            this.nextButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBoards)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTasks)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewBoards
            // 
            this.dataGridViewBoards.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBoards.Location = new System.Drawing.Point(83, 81);
            this.dataGridViewBoards.Name = "dataGridViewBoards";
            this.dataGridViewBoards.RowHeadersWidth = 82;
            this.dataGridViewBoards.RowTemplate.Height = 33;
            this.dataGridViewBoards.Size = new System.Drawing.Size(559, 461);
            this.dataGridViewBoards.TabIndex = 0;
            this.dataGridViewBoards.CursorChanged += new System.EventHandler(this.dataGridViewBoards_CursorChanged);
            // 
            // dataGridViewTasks
            // 
            this.dataGridViewTasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTasks.Location = new System.Drawing.Point(741, 81);
            this.dataGridViewTasks.Name = "dataGridViewTasks";
            this.dataGridViewTasks.RowHeadersWidth = 82;
            this.dataGridViewTasks.RowTemplate.Height = 33;
            this.dataGridViewTasks.Size = new System.Drawing.Size(645, 461);
            this.dataGridViewTasks.TabIndex = 0;
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(267, 577);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(126, 61);
            this.buttonConnect.TabIndex = 1;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(1148, 577);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(103, 93);
            this.buttonUpdate.TabIndex = 1;
            this.buttonUpdate.Text = "Update";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // taskNameTextBox
            // 
            this.taskNameTextBox.Location = new System.Drawing.Point(886, 606);
            this.taskNameTextBox.Name = "taskNameTextBox";
            this.taskNameTextBox.Size = new System.Drawing.Size(100, 31);
            this.taskNameTextBox.TabIndex = 2;
            // 
            // nextButton
            // 
            this.nextButton.Location = new System.Drawing.Point(1043, 606);
            this.nextButton.Name = "nextButton";
            this.nextButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.nextButton.Size = new System.Drawing.Size(82, 47);
            this.nextButton.TabIndex = 3;
            this.nextButton.Text = "next";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1435, 748);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.taskNameTextBox);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.dataGridViewTasks);
            this.Controls.Add(this.dataGridViewBoards);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBoards)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTasks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewBoards;
        private System.Windows.Forms.DataGridView dataGridViewTasks;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.TextBox taskNameTextBox;
        private System.Windows.Forms.Button nextButton;
    }
}

