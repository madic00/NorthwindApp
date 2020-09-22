namespace NorthwindApp
{
    partial class UpdateProductForm
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
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.name = new System.Windows.Forms.TextBox();
            this.quantity = new System.Windows.Forms.NumericUpDown();
            this.price = new System.Windows.Forms.NumericUpDown();
            this.ddlCategory = new System.Windows.Forms.ComboBox();
            this.ddlSupplier = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.quantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.price)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(77, 194);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(2);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(61, 30);
            this.btnSubmit.TabIndex = 13;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(11, 194);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(52, 30);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(11, 155);
            this.name.Margin = new System.Windows.Forms.Padding(2);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(110, 20);
            this.name.TabIndex = 11;
            // 
            // quantity
            // 
            this.quantity.Location = new System.Drawing.Point(11, 125);
            this.quantity.Margin = new System.Windows.Forms.Padding(2);
            this.quantity.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.quantity.Name = "quantity";
            this.quantity.Size = new System.Drawing.Size(109, 20);
            this.quantity.TabIndex = 10;
            // 
            // price
            // 
            this.price.Location = new System.Drawing.Point(11, 89);
            this.price.Margin = new System.Windows.Forms.Padding(2);
            this.price.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.price.Name = "price";
            this.price.Size = new System.Drawing.Size(109, 20);
            this.price.TabIndex = 9;
            // 
            // ddlCategory
            // 
            this.ddlCategory.FormattingEnabled = true;
            this.ddlCategory.Location = new System.Drawing.Point(11, 54);
            this.ddlCategory.Margin = new System.Windows.Forms.Padding(2);
            this.ddlCategory.Name = "ddlCategory";
            this.ddlCategory.Size = new System.Drawing.Size(110, 21);
            this.ddlCategory.TabIndex = 8;
            // 
            // ddlSupplier
            // 
            this.ddlSupplier.FormattingEnabled = true;
            this.ddlSupplier.Location = new System.Drawing.Point(11, 24);
            this.ddlSupplier.Margin = new System.Windows.Forms.Padding(2);
            this.ddlSupplier.Name = "ddlSupplier";
            this.ddlSupplier.Size = new System.Drawing.Size(110, 21);
            this.ddlSupplier.TabIndex = 7;
            // 
            // UpdateProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 307);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.name);
            this.Controls.Add(this.quantity);
            this.Controls.Add(this.price);
            this.Controls.Add(this.ddlCategory);
            this.Controls.Add(this.ddlSupplier);
            this.Name = "UpdateProductForm";
            this.Text = "UpdateProductForm";
            ((System.ComponentModel.ISupportInitialize)(this.quantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.price)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.NumericUpDown quantity;
        private System.Windows.Forms.NumericUpDown price;
        private System.Windows.Forms.ComboBox ddlCategory;
        private System.Windows.Forms.ComboBox ddlSupplier;
    }
}