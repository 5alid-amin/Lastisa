namespace last
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnrestore = new Button();
            btnreload = new Button();
            btnfromexcel = new Button();
            btnexcel = new Button();
            btnbackup = new Button();
            btndelete = new Button();
            btnadd = new Button();
            dataGridView1 = new DataGridView();
            txtname = new TextBox();
            txtpur = new TextBox();
            txtsell = new TextBox();
            txtquanitiy = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btnrestore
            // 
            btnrestore.Location = new Point(16, 392);
            btnrestore.Name = "btnrestore";
            btnrestore.Size = new Size(136, 41);
            btnrestore.TabIndex = 9;
            btnrestore.Text = "RestoreBackup";
            btnrestore.UseVisualStyleBackColor = true;
            btnrestore.Click += btnrestore_Click;
            // 
            // btnreload
            // 
            btnreload.Location = new Point(19, 266);
            btnreload.Name = "btnreload";
            btnreload.Size = new Size(86, 41);
            btnreload.TabIndex = 10;
            btnreload.Text = "reload";
            btnreload.UseVisualStyleBackColor = true;
            btnreload.Click += relod;
            // 
            // btnfromexcel
            // 
            btnfromexcel.Location = new Point(175, 392);
            btnfromexcel.Name = "btnfromexcel";
            btnfromexcel.Size = new Size(136, 41);
            btnfromexcel.TabIndex = 11;
            btnfromexcel.Text = "FromExcel";
            btnfromexcel.UseVisualStyleBackColor = true;
            btnfromexcel.Click += btnfromexcel_Click;
            // 
            // btnexcel
            // 
            btnexcel.Location = new Point(175, 345);
            btnexcel.Name = "btnexcel";
            btnexcel.Size = new Size(136, 41);
            btnexcel.TabIndex = 12;
            btnexcel.Text = "ToExcel";
            btnexcel.UseVisualStyleBackColor = true;
            btnexcel.Click += btnexcel_Click;
            // 
            // btnbackup
            // 
            btnbackup.Location = new Point(16, 345);
            btnbackup.Name = "btnbackup";
            btnbackup.Size = new Size(136, 41);
            btnbackup.TabIndex = 13;
            btnbackup.Text = "Backup";
            btnbackup.UseVisualStyleBackColor = true;
            btnbackup.Click += btnbackup_Click;
            // 
            // btndelete
            // 
            btndelete.Location = new Point(122, 266);
            btndelete.Name = "btndelete";
            btndelete.Size = new Size(86, 41);
            btndelete.TabIndex = 14;
            btndelete.Text = "delete";
            btndelete.UseVisualStyleBackColor = true;
            btndelete.Click += btndelete_Click;
            // 
            // btnadd
            // 
            btnadd.Location = new Point(228, 266);
            btnadd.Name = "btnadd";
            btnadd.Size = new Size(86, 41);
            btnadd.TabIndex = 17;
            btnadd.Text = "Add";
            btnadd.UseVisualStyleBackColor = true;
            btnadd.Click += btnadd_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(354, 7);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(681, 426);
            dataGridView1.TabIndex = 18;
            // 
            // txtname
            // 
            txtname.Location = new Point(16, 28);
            txtname.Multiline = true;
            txtname.Name = "txtname";
            txtname.Size = new Size(236, 37);
            txtname.TabIndex = 19;
            // 
            // txtpur
            // 
            txtpur.Location = new Point(16, 79);
            txtpur.Multiline = true;
            txtpur.Name = "txtpur";
            txtpur.Size = new Size(236, 37);
            txtpur.TabIndex = 20;
            // 
            // txtsell
            // 
            txtsell.Location = new Point(16, 129);
            txtsell.Multiline = true;
            txtsell.Name = "txtsell";
            txtsell.Size = new Size(236, 37);
            txtsell.TabIndex = 21;
            // 
            // txtquanitiy
            // 
            txtquanitiy.Location = new Point(16, 182);
            txtquanitiy.Multiline = true;
            txtquanitiy.Name = "txtquanitiy";
            txtquanitiy.Size = new Size(236, 37);
            txtquanitiy.TabIndex = 21;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(274, 36);
            label1.Name = "label1";
            label1.Size = new Size(55, 25);
            label1.TabIndex = 22;
            label1.Text = "الاسم";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(259, 87);
            label2.Name = "label2";
            label2.Size = new Size(96, 25);
            label2.TabIndex = 22;
            label2.Text = "سعر الشراء";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(262, 137);
            label3.Name = "label3";
            label3.Size = new Size(86, 25);
            label3.TabIndex = 22;
            label3.Text = "سعر البيع";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(269, 190);
            label4.Name = "label4";
            label4.Size = new Size(60, 25);
            label4.TabIndex = 22;
            label4.Text = "الكميه";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1047, 450);
            Controls.Add(label4);
            Controls.Add(label1);
            Controls.Add(txtquanitiy);
            Controls.Add(txtsell);
            Controls.Add(txtpur);
            Controls.Add(txtname);
            Controls.Add(dataGridView1);
            Controls.Add(btnrestore);
            Controls.Add(btnreload);
            Controls.Add(btnfromexcel);
            Controls.Add(btnexcel);
            Controls.Add(btnbackup);
            Controls.Add(btndelete);
            Controls.Add(btnadd);
            Controls.Add(label3);
            Controls.Add(label2);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnrestore;
        private Button btnreload;
        private Button btnfromexcel;
        private Button btnexcel;
        private Button btnbackup;
        private Button btndelete;
        private Button btnadd;
        private DataGridView dataGridView1;
        private TextBox txtname;
        private TextBox txtpur;
        private TextBox txtsell;
        private TextBox txtquanitiy;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}
