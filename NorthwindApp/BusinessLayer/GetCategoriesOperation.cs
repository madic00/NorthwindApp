using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindApp.BusinessLayer
{
    public class GetCategoriesOperation : Operation
    {
        public override OperationResult Execute()
        {
            var result = Context.Categories.Select(x => new CategoryDto
            {
                Id = x.CategoryID,
                Name = x.CategoryName
            }).ToList();

            return new OperationResult
            {
                Data = result
            };
        }
    }
}
