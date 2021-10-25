using System;
using TransportCompanyLib.Models.Products;

namespace TransportCompanyLib.Models.Semitrailers
{
    public abstract class SemitrailerBase
    {
        private ProductBase _semitrailerProduct;
        private int _carryingCapacity;

        public int CarryingCapacity;

        public SemitrailerBase(int carryingCapacity, ProductBase semitrailerProduct)
        {
            if (carryingCapacity <= 0)
            {
                throw new ArgumentException(nameof(carryingCapacity));
            }

            _carryingCapacity = carryingCapacity;
        }
    }
}
