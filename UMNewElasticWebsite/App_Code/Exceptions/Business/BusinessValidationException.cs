using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UMNewElasticWebsite.Exceptions.Business
{
    public class BusinessValidationException : Exception
    {
        public BusinessValidationException(String message) 
            : base(message)
        {
        }
    }
}
