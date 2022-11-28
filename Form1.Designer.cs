namespace rebarApplication
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
            this.btnMesh = new System.Windows.Forms.Button();
            this.btnRebars = new System.Windows.Forms.Button();
            this.cc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Radius = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnMesh
            // 
            this.btnMesh.Location = new System.Drawing.Point(411, 415);
            this.btnMesh.Name = "btnMesh";
            this.btnMesh.Size = new System.Drawing.Size(75, 23);
            this.btnMesh.TabIndex = 0;
            this.btnMesh.Text = "Insert Mesh";
            this.btnMesh.UseVisualStyleBackColor = true;
            this.btnMesh.Click += new System.EventHandler(this.btnMesh_Click);
            // 
            // btnRebars
            // 
            this.btnRebars.Location = new System.Drawing.Point(326, 415);
            this.btnRebars.Name = "btnRebars";
            this.btnRebars.Size = new System.Drawing.Size(79, 23);
            this.btnRebars.TabIndex = 1;
            this.btnRebars.Text = "Insert Rebars";
            this.btnRebars.UseVisualStyleBackColor = true;
            this.btnRebars.Click += new System.EventHandler(this.btnRebars_Click);
            // 
            // cc
            // 
            this.cc.Location = new System.Drawing.Point(105, 66);
            this.cc.Name = "cc";
            this.cc.Size = new System.Drawing.Size(111, 20);
            this.cc.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "CC-Avstånd";
            // 
            // Radius
            // 
            this.Radius.FormattingEnabled = true;
            this.Radius.Items.AddRange(new object[] {
            "8mm",
            "10mm",
            "12mm",
            "16mm",
            "20mm",
            "25mm"});
            this.Radius.Location = new System.Drawing.Point(105, 92);
            this.Radius.Name = "Radius";
            this.Radius.Size = new System.Drawing.Size(111, 21);
            this.Radius.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Radien";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Radius);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cc);
            this.Controls.Add(this.btnRebars);
            this.Controls.Add(this.btnMesh);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnMesh;
        private System.Windows.Forms.Button btnRebars;
        private System.Windows.Forms.TextBox cc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Radius;
        private System.Windows.Forms.Label label2;
    }
}

