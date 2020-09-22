namespace NorthwindApp
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
            this.lvProducts = new System.Windows.Forms.ListView();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.categoriesCheckBox = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // lvProducts
            // 
            this.lvProducts.HideSelection = false;
            this.lvProducts.Location = new System.Drawing.Point(13, 62);
            this.lvProducts.Name = "lvProducts";
            this.lvProducts.Size = new System.Drawing.Size(505, 152);
            this.lvProducts.TabIndex = 0;
            this.lvProducts.UseCompatibleStateImageBehavior = false;
            this.lvProducts.View = System.Windows.Forms.View.Details;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(13, 245);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(13, 29);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(100, 20);
            this.tbSearch.TabIndex = 2;
            this.tbSearch.Leave += new System.EventHandler(this.tbSearch_Leave);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(116, 245);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(217, 245);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(75, 23);
            this.btnInsert.TabIndex = 4;
            this.btnInsert.Text = "insert";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // categoriesCheckBox
            // 
            this.categoriesCheckBox.FormattingEnabled = true;
            this.categoriesCheckBox.Location = new System.Drawing.Point(539, 29);
            this.categoriesCheckBox.Name = "categoriesCheckBox";
            this.categoriesCheckBox.Size = new System.Drawing.Size(120, 94);
            this.categoriesCheckBox.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 334);
            this.Controls.Add(this.categoriesCheckBox);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.lvProducts);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvProducts;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.CheckedListBox categoriesCheckBox;
    }
}

