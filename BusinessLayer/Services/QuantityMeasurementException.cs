using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class QuantityMeasurementException : Exception
    {
        public QuantityMeasurementException()
        {
        }

        public QuantityMeasurementException(ExceptionType type, string message) : base(message)
        {
            this.Type = type;
        }

        public enum ExceptionType
        {
            INVALIDDATA
        }

        public ExceptionType Type { get; set; }
    }
}
