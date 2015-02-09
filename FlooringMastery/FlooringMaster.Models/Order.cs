using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Models
{
    public class Order
    {
        public Order()
        {
            State myState = new State();
            OrderState = myState;

            Product myProduct = new Product();
            OrderProduct = myProduct;
        }

        public int OrderNumber { get; set; }
        public string CustomerName { get; set; }
        public Product OrderProduct { get; set; }
        public State OrderState { get; set; }
        public decimal Area { get; set; }
        public decimal TotalLaborCost { get; set; }
        public decimal TotalMaterialCost { get; set; }
        public decimal TotalTax { get; set; }
        public decimal TotalCost { get; set; }
    }
}
