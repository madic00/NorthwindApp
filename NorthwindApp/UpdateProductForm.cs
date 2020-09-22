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
    public partial class UpdateProductForm : Form
    {
        private AddProductDto dto;
        public UpdateProductForm(AddProductDto dto)
        {
            InitializeComponent();

            if(dto == null)
            {
                throw new ArgumentException("Morate izabrati proizvod za update");
            }

            this.dto = dto;

            InitializeFormItems();
        }

        private void InitializeFormItems()
        {
            name.Text = dto.Name;
            price.Value = dto.Price;
            quantity.Value = dto.Quantity;

            var opSuppliers = new GetSuppliersOperation();
            var suppliers = OperationManager.Instance.ExecuteOp(opSuppliers).Data as List<SupplierDto>;

            ddlSupplier.ValueMember = "Id";
            ddlSupplier.DisplayMember = "Name";
            ddlSupplier.DataSource = suppliers;

            ddlSupplier.SelectedValue = dto.SupplierId;

            var categoriesOp = new GetCategoriesOperation();
            var categories = OperationManager.Instance.ExecuteOp(categoriesOp).Data as List<CategoryDto>;

            ddlCategory.ValueMember = "Id";
            ddlCategory.DisplayMember = "Name";
            ddlCategory.DataSource = categories;

            ddlSupplier.SelectedValue = dto.CategoryId;

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            var productZaUpdate = new AddProductDto
            {
                Id = dto.Id,
                Name = name.Text,
                SupplierId = (ddlSupplier.SelectedItem as SupplierDto).Id,
                CategoryId = (ddlCategory.SelectedItem as CategoryDto).Id,
                Price = price.Value,
                Quantity = (int)quantity.Value
            };

            var updateOp = new OpProductUpdate(productZaUpdate);

            var rezOp = OperationManager.Instance.ExecuteOp(updateOp);

            if(rezOp.Success)
            {
                MessageBox.Show("Uspesno izmenjeno");

                this.Dispose();
            } else
            {
                MessageBox.Show(rezOp.Errors.FirstOrDefault().ToString());
            }
        }
    }
}
