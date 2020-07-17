using System;
using System.Collections.Generic;
using System.Text;
using BusinessLayer.Interface;
using CommanLayer.Model;
using RepositoryLayer.Interface;

namespace BusinessLayer.Services
{
    public class QuantityMeasurementBusiness : QuantityMeasurementInterfaceBusiness
    {
        private QuantityMeasurementInterfaceRepository quantityMeasurementRepository;

        public QuantityMeasurementBusiness(QuantityMeasurementInterfaceRepository quantityMeasurementRepository)
        {
            this.quantityMeasurementRepository = quantityMeasurementRepository;
        }

        public Quantity Convert(Quantity quantity)
        {
            try
            {
                if (quantity.MeasurementType == "")
                {
                    return null;
                }
                quantity.Result = UnitConversion(quantity);

                if (quantity.Result > 0)
                {
                    return quantityMeasurementRepository.Add(quantity);
                }
                else
                {
                    return null;
                }

                return quantity;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
        private double UnitConversion(Quantity quantity)
        {
            try
            {

                string MeasurementType = quantity.MeasurementType;
                string conversionType = quantity.ConversionType;
                double value = quantity.Value;
                return Conversion(MeasurementType, conversionType, value);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private double Conversion(string MeasurementType, string conversionType, double value)
        {
            Length length = new Length();
            Weight weight = new Weight();
            Volume volume = new Volume();
            double result = 0.0;

            if (MeasurementType == "length")
            {
                Length.Unit unit = length.SetUnitAndConvertLength(conversionType);

                if (unit == Length.Unit.FeetToInch || unit == Length.Unit.YardToInch || unit == Length.Unit.CentimeterToInch || unit.Equals(Length.Unit.Inch))
                {
                    return length.ConvertLength(unit, value);
                }
                    return result;
            }
            else if (MeasurementType == "weight")
            {
                Weight.Unit unit = weight.SetUnitAndConvertWeights(conversionType);

                if (unit.Equals(Weight.Unit.GramsToKilogram) || unit.Equals(Weight.Unit.TonneToKilograms) || unit.Equals(Weight.Unit.kilogram))
                {
                    return weight.ConvertWeigths(unit, value);
                }
                return result;
            }
            else if (MeasurementType == "volume")
            {
                Volume.Unit unit = volume.SetUnitAndConvertVolume(conversionType);
                if (unit.Equals(Volume.Unit.GallonToLitre) || unit.Equals(Volume.Unit.MiliLitreToLitre) || unit.Equals(Volume.Unit.Litre))
                {
                    return volume.ConvertValue(unit, value);
                }
                    return result;
            }
            else if (MeasurementType == "temperature")
            {
                Temperature temperature = new Temperature();
                Temperature.Unit unit = temperature.SetUnitAndConvertTemperature(conversionType);
                if (unit.Equals(Temperature.Unit.FahrenheitToCelsius))
                {
                    return temperature.ConvertTemperature(unit, value);
                }
                    return result;
                
            }

            return value;
        }

        public IEnumerable<Quantity> GetAllQuantity()
        {
            try
            {
                return quantityMeasurementRepository.GetAllQuantity();
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
                return quantityMeasurementRepository.GetQuantityById(Id);
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
                return quantityMeasurementRepository.DeleteQuntityById(Id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Compare CompareAndAdd(Compare compare)
        {
            try
            {
                compare.Result = UnitComparision(compare);
                if (compare.Result != null)
                {
                    return quantityMeasurementRepository.AddComparedValue(compare);

                }
                return compare;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private string UnitComparision(Compare compare)
        {
            try
            {
                string measurmentType = compare.MeasurementType;
                string firstValueUnit = compare.FirstValueUnit;
                double firstValue = compare.FirstValue;
                string secondValueUnit = compare.SecondValueUnit;
                double secondValue = compare.SecondValue;

                double firstResult = this.Conversion(measurmentType, firstValueUnit, firstValue);
                double secondResult = this.Conversion(measurmentType, secondValueUnit, secondValue);

                if (firstResult == secondResult)
                {
                    return "Both values are equal";
                }

                else if (firstResult > secondResult)
                {
                    return firstValueUnit + " " + firstValue + " Is Greater Than " + secondValueUnit + " " + secondValue;
                }

                else if (firstResult < secondResult)
                {
                    return firstValueUnit + " " + firstValue + " Is Less Than " + secondValueUnit + " " + secondValue;
                }

                return null;
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
                return quantityMeasurementRepository.GetAllComparison();
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
                return quantityMeasurementRepository.GetComparisonById(Id);
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
                return quantityMeasurementRepository.DeleteComparisonById(Id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
