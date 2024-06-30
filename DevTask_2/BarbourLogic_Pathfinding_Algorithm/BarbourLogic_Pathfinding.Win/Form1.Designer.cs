namespace BarbourLogic_Pathfinding.Win
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnSetStart;
        private System.Windows.Forms.Button btnSetEnd;
        private System.Windows.Forms.Button btnRunPathfinding;
        private System.Windows.Forms.Button btnClear;

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
            dataGridView1 = new System.Windows.Forms.DataGridView();
            btnSetStart = new System.Windows.Forms.Button();
            btnSetEnd = new System.Windows.Forms.Button();
            btnRunPathfinding = new System.Windows.Forms.Button();
            btnClear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();

            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new System.Drawing.Point(35, 29);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new System.Drawing.Size(635, 618);
            dataGridView1.TabIndex = 0;

            // 
            // btnSetStart
            // 
            btnSetStart.Location = new System.Drawing.Point(700, 29);
            btnSetStart.Name = "btnSetStart";
            btnSetStart.Size = new System.Drawing.Size(100, 30);
            btnSetStart.TabIndex = 1;
            btnSetStart.Text = "Set Start";
            btnSetStart.UseVisualStyleBackColor = true;
            btnSetStart.Click += new System.EventHandler(BtnSetStart_Click);

            // 
            // btnSetEnd
            // 
            btnSetEnd.Location = new System.Drawing.Point(700, 65);
            btnSetEnd.Name = "btnSetEnd";
            btnSetEnd.Size = new System.Drawing.Size(100, 30);
            btnSetEnd.TabIndex = 2;
            btnSetEnd.Text = "Set End";
            btnSetEnd.UseVisualStyleBackColor = true;
            btnSetEnd.Click += new System.EventHandler(BtnSetEnd_Click);

            // 
            // btnRunPathfinding
            // 
            btnRunPathfinding.Location = new System.Drawing.Point(700, 101);
            btnRunPathfinding.Name = "btnRunPathfinding";
            btnRunPathfinding.Size = new System.Drawing.Size(150, 30);
            btnRunPathfinding.TabIndex = 3;
            btnRunPathfinding.Text = "Run Pathfinding";
            btnRunPathfinding.UseVisualStyleBackColor = true;
            btnRunPathfinding.Click += new System.EventHandler(BtnRunPathfinding_Click);

            // 
            // btnClear
            // 
            btnClear.Location = new System.Drawing.Point(700, 137);
            btnClear.Name = "btnClear";
            btnClear.Size = new System.Drawing.Size(100, 30);
            btnClear.TabIndex = 4;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += new System.EventHandler(BtnClear_Click);

            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1668, 1054);
            Controls.Add(dataGridView1);
            Controls.Add(btnSetStart);
            Controls.Add(btnSetEnd);
            Controls.Add(btnRunPathfinding);
            Controls.Add(btnClear);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion
    }
}
