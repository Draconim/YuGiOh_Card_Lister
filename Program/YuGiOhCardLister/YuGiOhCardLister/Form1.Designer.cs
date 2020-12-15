namespace YuGiOhCardLister
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
            this.dgv_cards = new System.Windows.Forms.DataGridView();
            this.txb_keres = new System.Windows.Forms.TextBox();
            this.btn_kereses = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btn_modositas = new System.Windows.Forms.Button();
            this.btn_Torles = new System.Windows.Forms.Button();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.cb_CardType = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_cards)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_cards
            // 
            this.dgv_cards.AllowUserToAddRows = false;
            this.dgv_cards.AllowUserToDeleteRows = false;
            this.dgv_cards.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_cards.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv_cards.Location = new System.Drawing.Point(12, 12);
            this.dgv_cards.Name = "dgv_cards";
            this.dgv_cards.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_cards.Size = new System.Drawing.Size(776, 249);
            this.dgv_cards.TabIndex = 0;
            // 
            // txb_keres
            // 
            this.txb_keres.Location = new System.Drawing.Point(12, 268);
            this.txb_keres.Name = "txb_keres";
            this.txb_keres.Size = new System.Drawing.Size(444, 20);
            this.txb_keres.TabIndex = 1;
            this.txb_keres.Text = "Név";
            // 
            // btn_kereses
            // 
            this.btn_kereses.Location = new System.Drawing.Point(589, 266);
            this.btn_kereses.Name = "btn_kereses";
            this.btn_kereses.Size = new System.Drawing.Size(199, 23);
            this.btn_kereses.TabIndex = 2;
            this.btn_kereses.Text = "Keresés";
            this.btn_kereses.UseVisualStyleBackColor = true;
            this.btn_kereses.Click += new System.EventHandler(this.Btn_kereses_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 294);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(180, 40);
            this.button2.TabIndex = 3;
            this.button2.Text = "Új hozzáadása";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // btn_modositas
            // 
            this.btn_modositas.Location = new System.Drawing.Point(198, 294);
            this.btn_modositas.Name = "btn_modositas";
            this.btn_modositas.Size = new System.Drawing.Size(194, 40);
            this.btn_modositas.TabIndex = 4;
            this.btn_modositas.Text = "Módosítás";
            this.btn_modositas.UseVisualStyleBackColor = true;
            // 
            // btn_Torles
            // 
            this.btn_Torles.Location = new System.Drawing.Point(398, 294);
            this.btn_Torles.Name = "btn_Torles";
            this.btn_Torles.Size = new System.Drawing.Size(185, 40);
            this.btn_Torles.TabIndex = 5;
            this.btn_Torles.Text = "Törlés";
            this.btn_Torles.UseVisualStyleBackColor = true;
            this.btn_Torles.Click += new System.EventHandler(this.Btn_Torles_Click);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.Location = new System.Drawing.Point(0, 0);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(120, 94);
            this.checkedListBox1.TabIndex = 0;
            // 
            // cb_CardType
            // 
            this.cb_CardType.FormattingEnabled = true;
            this.cb_CardType.Location = new System.Drawing.Point(462, 268);
            this.cb_CardType.Name = "cb_CardType";
            this.cb_CardType.Size = new System.Drawing.Size(121, 21);
            this.cb_CardType.TabIndex = 7;
            this.cb_CardType.SelectedIndexChanged += new System.EventHandler(this.Cb_CardType_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 342);
            this.Controls.Add(this.cb_CardType);
            this.Controls.Add(this.btn_Torles);
            this.Controls.Add(this.btn_modositas);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btn_kereses);
            this.Controls.Add(this.txb_keres);
            this.Controls.Add(this.dgv_cards);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_cards)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void BgWorker_DoWork1(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_cards;
        private System.Windows.Forms.TextBox txb_keres;
        private System.Windows.Forms.Button btn_kereses;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btn_modositas;
        private System.Windows.Forms.Button btn_Torles;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.ComboBox cb_CardType;
    }
}

