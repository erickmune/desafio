using DesafioMinhaVida.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioMinhaVida.Helpers
{
    public static class SKUGenerator
    {                
        public static string GenerateSKU(ElectricGuitar eGuitar)
        {
            string sku = eGuitar.Id + "_" + eGuitar.Name.Replace(" ", "_");

            return sku.ToLower();
        }
    }
}
