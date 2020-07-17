using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using CommanLayer;
using CommanLayer.Model;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interface;

namespace RepositoryLayer.Services
{

    public class QuantityMeasurementRepository : QuantityMeasurementInterfaceRepository
    {


        private ApplicationDbContext dBContext;

        public QuantityMeasurementRepository(ApplicationDbContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public Quantity Add(Quantity quantity)
        {
            try
            { 
                if (quantity == null )
                {
                    return quantity;
                }

                var result = dBContext.Quantities.FirstOrDefault(Data =>((Data.ConversionType == quantity.ConversionType) && (Data.Value == quantity.Value)));
                if (result == null)
                {
                    dBContext.Quantities.Add(quantity);
                    dBContext.SaveChanges();
                }
                else
                {
                    throw new Exception("Duplication Not Allow");
                }
                return quantity;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IEnumerable<Quantity> GetAllQuantity()
        {
            try
            {
                return dBContext.Quantities;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Quantity GetQuantityById(int Id)
        {
            try
            {
                Quantity quantity = dBContext.Quantities.Find(Id);
                return quantity;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Quantity DeleteQuntityById(int Id)
        {
            try
            {
                Quantity quantity = dBContext.Quantities.Single(data => data.Id == Id);

                if (quantity != null)
                {
                    dBContext.Remove(quantity);
                    dBContext.SaveChanges();
                }

                
                return quantity;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Compare AddComparedValue(Compare compare)
        {
            try
            {
                dBContext.Comparisons.Add(compare);

                dBContext.SaveChanges();
                return compare;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IEnumerable<Compare> GetAllComparison()
        {
            try
            {
                return dBContext.Comparisons;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Compare GetComparisonById(int Id)
        {
            try
            {
                return dBContext.Comparisons.Find(Id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Compare DeleteComparisonById(int Id)
        {
            try
            {
                Compare compare = dBContext.Comparisons.FirstOrDefault(data => data.Id == Id);
                if (compare != null)
                {
                    dBContext.Comparisons.Remove(compare);
                    dBContext.SaveChanges();
                }
                return compare;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
