using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindApp.BusinessLayer
{
    public class OperationManager
    {
        private static OperationManager instance;

        private OperationManager()
        {
        }

        public static OperationManager Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new OperationManager();
                }

                return instance;
            }
        }

        public OperationResult ExecuteOp(Operation op)
        {
            var result = new OperationResult();
            try
            {
                return op.Execute();
            } catch(Exception ex)
            {
                result.Errors.Add("Desila se greska");

                var stringErr = ex.Message.ToString();

                return result;
            }
        }
    }
}
