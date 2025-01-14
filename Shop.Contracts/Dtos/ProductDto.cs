using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Contracts.Dtos
{
    public record ProductDto(int Id, string Name,string Description, DateTime CreationDate, DateTime ModificationDate,
        decimal Price, int Quantity , int CategoryId , string CategoryName);
    
}
