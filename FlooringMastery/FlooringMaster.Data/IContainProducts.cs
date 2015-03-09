using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models;

namespace FlooringMaster.Data
{
    /// <summary>
    /// interface for the product containing data objects
    /// </summary>
    public interface IContainProducts
    {
        List<Product> GetProducts();
    }
}
