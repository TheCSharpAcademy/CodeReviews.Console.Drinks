using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace drinks_info.Models
{
    internal class Inventory
    {
        public int InventoryId { get; set; }
        public string InventoryName { get; set; }

        internal static bool InInventory(string strIngredient1)
        {
            bool inInventory = false;

            List<Inventory> Inventories = Data.GetInventory();

            inInventory = Inventories.Any(inventory => inventory.InventoryName == strIngredient1);
            
            return inInventory;
        }
    }
}
