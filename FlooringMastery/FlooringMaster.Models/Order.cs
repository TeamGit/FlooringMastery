using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Models
{
    [Serializable()]
    public class Order : ISerializable
    {
        public int OrderNumber { get; set; }
        public string CustomerName { get; set; }
        public string ProductType { get; set; }
        public string StateAbbreviation { get; set; }
        public decimal TaxRate { get; set; }
        public decimal CostPerSquareFoot { get; set; }
        public decimal LaborCostPerSquareFoot { get; set; }
        public decimal Area { get; set; }
        public decimal TotalLaborCost { get; set; }
        public decimal TotalMaterialCost { get; set; }
        public decimal TotalTax { get; set; }
        public decimal TotalCost { get; set; }

        public Order()
        {
            
        }

        public Order(SerializationInfo info, StreamingContext ctxt)
        {
            CustomerName = (string)info.GetValue("CustomerName", typeof(string));
            ProductType = (string)info.GetValue("ProductType", typeof(string));
            OrderNumber = (int)info.GetValue("OrderNumber", typeof(int));
            StateAbbreviation = (string)info.GetValue("StateAbbreviation", typeof(string));
            TaxRate = (decimal)info.GetValue("TaxRate", typeof(decimal));
            CostPerSquareFoot = (decimal)info.GetValue("CostPerSquareFoot", typeof(decimal));
            LaborCostPerSquareFoot = (decimal)info.GetValue("LaborCostPerSquareFoot", typeof(decimal));
            Area = (decimal)info.GetValue("Area", typeof(decimal));
            TotalLaborCost = (decimal)info.GetValue("TotalLaborCost", typeof(decimal));
            TotalMaterialCost = (decimal)info.GetValue("TotalMaterialCost", typeof(decimal));
            TotalTax = (decimal)info.GetValue("TotalTax", typeof(decimal));
            TotalCost = (decimal)info.GetValue("TotalCost", typeof(decimal));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("CustomerName", CustomerName);
            info.AddValue("ProductType", ProductType);
            info.AddValue("OrderNumber", OrderNumber);
            info.AddValue("StateAbbreviation", StateAbbreviation);
            info.AddValue("TaxRate", TaxRate);
            info.AddValue("CostPerSquareFoot", CostPerSquareFoot);
            info.AddValue("LaborCostPerSquareFoot", LaborCostPerSquareFoot);
            info.AddValue("Area", Area);
            info.AddValue("TotalLaborCost", TotalLaborCost);
            info.AddValue("TotalMaterialCost", TotalMaterialCost);
            info.AddValue("TotalTax", TotalTax);
            info.AddValue("TotalCost", TotalCost);
        }
    }
}
