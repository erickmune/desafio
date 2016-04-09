using DesafioMinhaVida.Entities;
using DesafioMinhaVida.Helpers;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioMinhaVida.DAO
{
    public class ElectricGuitarDAO
    {
        private EntitiesContext context;

        public ElectricGuitarDAO(EntitiesContext context)
        {
            this.context = context;
        }

        public bool Add(ElectricGuitar guitar)
        {
            try
            {
                this.context.ElectricGuitars.Add(guitar);
                this.context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }            
        }

        public IList<ElectricGuitar> List()
        {
            return this.context.ElectricGuitars.ToList();
        }

        public ElectricGuitar SearchById(int id)
        {
            return this.context.ElectricGuitars.Find(id);
        }        

        public bool Update(ElectricGuitar guitar)
        {            
            try
            {
                var Original = this.context.ElectricGuitars.Find(guitar.Id);

                if (Original != null)
                {
                    Original.Name = guitar.Name;
                    Original.Price = guitar.Price;
                    Original.Description = guitar.Description;
                    Original.ImageUrl = guitar.ImageUrl;
                    Original.SKU = SKUGenerator.GenerateSKU(guitar);

                    context.Entry(Original).State = System.Data.Entity.EntityState.Modified;                    
                    this.context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }                
        }

        public bool Delete(int id)
        {
            try
            {
                ElectricGuitar guitar = this.context.ElectricGuitars.Find(id);
                this.context.ElectricGuitars.Remove(guitar);
                this.context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }            
        }
    }
}
