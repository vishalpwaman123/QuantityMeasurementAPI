using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class Volume
    {
        private double gallonToLitreValue = 3.78;

        private double miliLitreToLitreValue = 1000;

        public enum Unit
        {
            Null,
            Gallon,
            Litre,
            GallonToLitre,
            MiliLitreToLitre
        }

        public Unit SetUnitAndConvertVolume(string operation)
        {
            if (operation == "GallonToLitre")
            {
                return Unit.GallonToLitre;
            }
            else
            if (operation == "MiliLitreToLitre")
            {
                return Unit.MiliLitreToLitre;
            }
            else
            if (operation == "Litre")
            {
                return Unit.Litre;
            }
            return Unit.Null;
        }

        public double ConvertValue(Unit unit, double value)
        {
            try
            {
                if (unit.Equals(Unit.GallonToLitre))
                {
                    return value * this.gallonToLitreValue;
                }
                else if (unit.Equals(Unit.MiliLitreToLitre))
                {
                    return value / this.miliLitreToLitreValue;
                }

                return value;
            }
            catch (Exception e)
            {
                throw new QuantityMeasurementException(QuantityMeasurementException.ExceptionType.INVALIDDATA, e.Message);
            }
        }
    }
}