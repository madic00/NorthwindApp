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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            lvProducts.Columns.Add("Id");
            lvProducts.Columns.Add("Name");
            lvProducts.Columns.Add("Price");
            lvProducts.Columns.Add("Total Money");
            lvProducts.Columns.Add("Vendor");
            lvProducts.Columns.Add("Origin");

            lvProducts.FullRowSelect = true;

            PopulateLvProducts();

            InitializeCategories();
        }

        private void PopulateLvProducts(string searchKey = null)
        {
            var products = GetProducts(searchKey);

            lvProducts.Items.Clear();
            lvProducts.BeginUpdate();

            foreach(var product in products)
            {
                var item = new ListViewItem();
                item.Tag = product.Id;
                item.Text = product.Id.ToString();
                item.SubItems.Add(product.Name);
                item.SubItems.Add(product.Price.ToString());
                item.SubItems.Add(product.TotalMoneyMade.ToString());
                item.SubItems.Add(product.Vendor);
                item.SubItems.Add(product.OriginCountry);

                lvProducts.Items.Add(item);
            }

            lvProducts.EndUpdate();

        }

        private IEnumerable<ProductDto> GetProducts(string searchKey = null)
        {
            var productSearch = new ProductSearchCriteria();

            if(searchKey != null)
            {
                productSearch.ProductName = searchKey;
            }

            var opSelectProduct = new OpProductSelect(productSearch);

            return OperationManager.Instance.ExecuteOp(opSelectProduct).Data as List<ProductDto>;

            //return new List<ProductDto>
            //{
            //    new ProductDto
            //    {
            //        Id = 1,
            //        CategoryName = "Sneakers",
            //        Vendor = "Adidas",
            //        Price = 60,
            //        Name  = "Adidas stan smith",
            //        TotalMoneyMade = 123232,
            //        OriginCountry = "Serbia",
            //        TimesBeingSold = 3132
            //    }
            //};
        }

        private void InitializeCategories()
        {
            var getCategories = new GetCategoriesOperation();

            var categories = OperationManager.Instance.ExecuteOp(getCategories).Data as List<CategoryDto>;

            foreach(var cat in categories)
            {
                this.categoriesCheckBox.Items.Add(cat);
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(this.lvProducts.SelectedItems.Count != 1)
            {
                MessageBox.Show("Morate odabrati tacno jedan red");
                return;
            }

            var redId = (int)lvProducts.SelectedItems[0].Tag;

            var getSingle = new OpProductSingle(redId);

            var productDto = OperationManager.Instance.ExecuteOp(getSingle).Data.FirstOrDefault() as AddProductDto;

            productDto.Id = redId;

            var updateForm = new UpdateProductForm(productDto);

            updateForm.Show();

            updateForm.Disposed += new System.EventHandler(this.updateForm_Disposed);
        }

        private void updateForm_Disposed(object sender, EventArgs e)
        {
            PopulateLvProducts();
        }

        private void tbSearch_Leave(object sender, EventArgs e)
        {
            var key = tbSearch.Text.Trim().ToLower();

            PopulateLvProducts(key);

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var items = lvProducts.SelectedItems;

            if(items.Count == 0)
            {
                MessageBox.Show("Niste odabrali stavu za brisanje");
                return;
            }

            var idsToDelete = new List<int>();

            foreach(var item in items)
            {
                if(item is ListViewItem itemTmp)
                {
                    var id = (int)itemTmp.Tag;
                    idsToDelete.Add(id);
                }
            }

            var delOp = new DeleteProductBatch(idsToDelete);

            var rezDel = OperationManager.Instance.ExecuteOp(delOp);

            if(rezDel.Success)
            {
                MessageBox.Show("Uspesno obrisano");
            } else
            {
                MessageBox.Show(rezDel.Errors.FirstOrDefault());
            }

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            var insertForm = new InsertProductForm();

            insertForm.Show();
        }
    }
}
