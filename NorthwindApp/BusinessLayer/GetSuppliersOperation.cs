using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindApp.BusinessLayer
{
    public class GetSuppliersOperation : Operation
    {
        public override OperationResult Execute()
        {
            var result = Context.Suppliers.Select(x => new SupplierDto
            {
                Id = x.SupplierID,
                Name = x.CompanyName
            }).ToList();

            return new OperationResult
            {
                Data = result
            };
        }
    }
}
