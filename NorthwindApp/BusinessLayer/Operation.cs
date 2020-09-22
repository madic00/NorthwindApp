using NorthwindApp.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindApp.BusinessLayer
{
    public abstract class Operation
    {
        private NorthwindEntities context;

        public Operation()
        {
            context = new NorthwindEntities();
        }

        protected NorthwindEntities Context => context;

        public bool RezultatSaSelect { get; set; } = true;
        public abstract OperationResult Execute();
    }
}
