using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindApp.BusinessLayer
{
    public abstract class Dto
    {
        public int Id { get; set; }
    }

    public class ProductDto : Dto
    {
        public string Name { get; set; }

        public string CategoryName { get; set; }

        public string Vendor { get; set; }

        public string OriginCountry { get; set; }

        public decimal TotalMoneyMade { get; set; }

        public decimal Price { get; set; }

        public int TimesBeingSold { get; set; }
    }

    public class AddProductDto : Dto
    {
        public int CategoryId { get; set; }

        public int SupplierId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }
    }
}
