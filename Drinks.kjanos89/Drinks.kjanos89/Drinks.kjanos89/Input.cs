using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drinks.kjanos89
{
    public class Input
    {
        ApiController controller=new ApiController();
        public void GetCategories()
        {
            controller.GetCategories();
        }
    }
}
