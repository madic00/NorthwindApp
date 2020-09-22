using NorthwindApp.BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NorthwindApp
{
    public partial class InsertProductForm : Form
    {
        public InsertProductForm()
        {
            InitializeComponent();

            InitializeFormItems();
        }

        private void InitializeFormItems()
        {
            var opSuppliers = new GetSuppliersOperation();
            var suppliers = OperationManager.Instance.ExecuteOp(opSuppliers).Data as List<SupplierDto>;

            ddlSupplier.ValueMember = "Id";
            ddlSupplier.DisplayMember = "Name";
            ddlSupplier.DataSource = suppliers;

            var categoriesOp = new GetCategoriesOperation();
            var categories = OperationManager.Instance.ExecuteOp(categoriesOp).Data as List<CategoryDto>;

            ddlCategory.ValueMember = "Id";
            ddlCategory.DisplayMember = "Name";
            ddlCategory.DataSource = categories;

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            var productNovi = new AddProductDto
            {
                Name = name.Text,
                Price = price.Value,
                Quantity = (int)quantity.Value,
                CategoryId = (ddlCategory.SelectedItem as CategoryDto).Id,
                SupplierId = (ddlSupplier.SelectedItem as SupplierDto).Id
            };

            var insertOp = new OpProductInert(productNovi);

            var rezInsert = OperationManager.Instance.ExecuteOp(insertOp);

            if(rezInsert.Success)
            {
                MessageBox.Show("Uspesno uneseno");
            } else
            {
                MessageBox.Show(rezInsert.Errors.FirstOrDefault());
            }
        }
    }
}
