using NorthwindApp.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindApp.BusinessLayer
{
    public class OpProductBase : Operation
    {
        protected ProductSearchCriteria criteria;

        public OpProductBase(ProductSearchCriteria criteria = null)
        {
            this.criteria = criteria;
        }

        public override OperationResult Execute()
        {
            var query = Context.Products.AsQueryable();

            if(criteria != null && criteria.ProductName != null)
            {
                query = query.Where(x => x.ProductName.ToLower().Contains(criteria.ProductName));
            }

            var result = query.Select(x => new ProductDto
            {
                Id = x.ProductID,
                Name = x.ProductName,
                Price = x.UnitPrice ?? 0,
                CategoryName = x.Category.CategoryName,
                OriginCountry = x.Supplier.Country,
                Vendor = x.Supplier.CompanyName,
                TimesBeingSold = x.Order_Details.Count,
                TotalMoneyMade = x.Order_Details.Any() ? x.Order_Details.Sum(od => od.UnitPrice * od.Quantity) : 0
            }).ToList();

            return new OperationResult
            {
                Data = result
            };
        }
    }

    public class OpProductSelect : OpProductBase
    {
        public OpProductSelect(ProductSearchCriteria criteria = null) : base(criteria)
        {

        }
    }

    public class OpProductSingle : OpProductBase
    {
        private int productId;

        public OpProductSingle(int id)
        {
            if(id == 0)
            {
                throw new ArgumentException("Morate proslediti productid");
            }

            this.productId = id;
        }

        public override OperationResult Execute()
        {
            var productSingle = Context.Products.Find(productId);

            return new OperationResult
            {
                Data = new List<AddProductDto>
                {
                    new AddProductDto
                    {
                        CategoryId = productSingle.CategoryID ?? 0,
                        SupplierId = productSingle.SupplierID.Value,
                        Name = productSingle.ProductName,
                        Price = productSingle.UnitPrice ?? 0,
                        Quantity = productSingle.UnitsInStock ?? 0
                    }
                }
            };
        }

    }

    public class OpProductEdit : OpProductBase
    {
        public AddProductDto Dto;

        public OpProductEdit(AddProductDto dto)
        {
            if(dto == null)
            {
                throw new ArgumentException("Dto je obavezan parametar");
            }

            this.Dto = dto;
        }



        public override OperationResult Execute()
        {
            if(this.RezultatSaSelect)
            {
                return base.Execute();
            } else
            {
                return new OperationResult();
            }
        }
    }

    public class OpProductUpdate : OpProductEdit
    {
        public OpProductUpdate(AddProductDto dto) : base(dto)
        {
        }

        public override OperationResult Execute()
        {
            var productZaIzmenu = Context.Products.Find(Dto.Id);

            var promenjenProduct = new Product
            {
                ProductID = Dto.Id,
                CategoryID = Dto.CategoryId,
                SupplierID = Dto.SupplierId,
                UnitPrice = Dto.Price,
                //QuantityPerUnit = Dto.Quantity
            };

            productZaIzmenu.ProductID = Dto.Id;
            productZaIzmenu.ProductName = Dto.Name;
            productZaIzmenu.CategoryID = Dto.CategoryId;
            productZaIzmenu.SupplierID = Dto.SupplierId;
            productZaIzmenu.UnitPrice = Dto.Price;
            productZaIzmenu.UnitsInStock = (short)Dto.Quantity;

            Context.SaveChanges();

            return base.Execute();


        }
    }

    public class OpProductInert : OpProductEdit
    {
        public OpProductInert(AddProductDto dto) : base(dto)
        {

        }

        public override OperationResult Execute()
        {
            var noviProduct = new Product
            {
                ProductName = Dto.Name,
                UnitPrice = Dto.Price,
                UnitsInStock = (short)Dto.Quantity,
                CategoryID = Dto.CategoryId,
                SupplierID = Dto.SupplierId
            };

            Context.Products.Add(noviProduct);
            Context.SaveChanges();

            return base.Execute(); 
        }
    }

    public class DeleteProductBatch : Operation
    {
        private readonly IEnumerable<int> idsToDelete;

        public DeleteProductBatch(IEnumerable<int> idsToDelete) 
        {
            if(idsToDelete == null)
            {
                throw new ArgumentException("Kolekcija ne sme biti null.");
            }

            if(!idsToDelete.Any())
            {
                throw new ArgumentException("Prazna kolekcija");
            }

            this.idsToDelete = idsToDelete;
        }

        public override OperationResult Execute()
        {
            var opResult = new OperationResult();

            foreach(var id in idsToDelete)
            {
                var product = Context.Products.Find(id);
                if(product == null)
                {
                    opResult.Errors.Add($"Proizvod sa id-em {id} ne postoji");
                }

                Context.Products.Remove(product);
            }

            if(opResult.Success)
            {
                Context.SaveChanges();
            }

            return opResult;
        }
    }

    public class ProductSearchCriteria
    {
        public string ProductName { get; set; }

    }
}
