using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindApp.BusinessLayer
{
    public class OperationResult
    {
        public IEnumerable<Dto> Data { get; set; }

        public List<string> Errors { get; set; } = new List<string>();

        public bool Success => !Errors.Any();
    }
}
