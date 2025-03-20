using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Validation
{ 
    public class DomainExceptionValidation : Exception  //essa classe vai herdar de Exception  através do :Exception
    {
        public DomainExceptionValidation(string error) : base(error)
        {
            
        }

        public static void When ( bool hasError, string error){  // metodo When
            if (hasError)
            {
                throw new DomainExceptionValidation(error); // através do metodo When posso validar os atributos nas entities, tanto Categories quanto Products
            }
        }
    }
}  