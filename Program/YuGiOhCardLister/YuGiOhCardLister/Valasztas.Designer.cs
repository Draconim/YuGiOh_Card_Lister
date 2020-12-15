namespace YuGiOhCardLister
{
    partial class Valasztas
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
            this.V_lbl1 = new System.Windows.Forms.Label();
            this.V_btn_Szorny = new System.Windows.Forms.Button();
            this.V_btn_Varazs = new System.Windows.Forms.Button();
            this.V_btn_Csapda = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // V_lbl1
            // 
            this.V_lbl1.AutoSize = true;
            this.V_lbl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.V_lbl1.Location = new System.Drawing.Point(60, 25);
            this.V_lbl1.Name = "V_lbl1";
            this.V_lbl1.Size = new System.Drawing.Size(244, 20);
            this.V_lbl1.TabIndex = 0;
            this.V_lbl1.Text = "Milyen lapot szeretne hozzáadni?";
            // 
            // V_btn_Szorny
            // 
            this.V_btn_Szorny.Location = new System.Drawing.Point(13, 88);
            this.V_btn_Szorny.Name = "V_btn_Szorny";
            this.V_btn_Szorny.Size = new System.Drawing.Size(75, 23);
            this.V_btn_Szorny.TabIndex = 1;
            this.V_btn_Szorny.Text = "Szörny";
            this.V_btn_Szorny.UseVisualStyleBackColor = true;
            this.V_btn_Szorny.Click += new System.EventHandler(this.V_btn_Szorny_Click);
            // 
            // V_btn_Varazs
            // 
            this.V_btn_Varazs.Location = new System.Drawing.Point(160, 88);
            this.V_btn_Varazs.Name = "V_btn_Varazs";
            this.V_btn_Varazs.Size = new System.Drawing.Size(75, 23);
            this.V_btn_Varazs.TabIndex = 2;
            this.V_btn_Varazs.Text = "Varázslap";
            this.V_btn_Varazs.UseVisualStyleBackColor = true;
            this.V_btn_Varazs.Click += new System.EventHandler(this.V_btn_Varazs_Click);
            // 
            // V_btn_Csapda
            // 
            this.V_btn_Csapda.Location = new System.Drawing.Point(307, 88);
            this.V_btn_Csapda.Name = "V_btn_Csapda";
            this.V_btn_Csapda.Size = new System.Drawing.Size(75, 23);
            this.V_btn_Csapda.TabIndex = 3;
            this.V_btn_Csapda.Text = "Csapdalap";
            this.V_btn_Csapda.UseVisualStyleBackColor = true;
            this.V_btn_Csapda.Click += new System.EventHandler(this.V_btn_Csapda_Click);
            // 
            // Valasztas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 123);
            this.Controls.Add(this.V_btn_Csapda);
            this.Controls.Add(this.V_btn_Varazs);
            this.Controls.Add(this.V_btn_Szorny);
            this.Controls.Add(this.V_lbl1);
            this.Name = "Valasztas";
            this.Text = "Valasztas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label V_lbl1;
        private System.Windows.Forms.Button V_btn_Szorny;
        private System.Windows.Forms.Button V_btn_Varazs;
        private System.Windows.Forms.Button V_btn_Csapda;
    }
}