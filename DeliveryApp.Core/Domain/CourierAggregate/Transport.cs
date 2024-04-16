using DeliveryApp.Core.Domain.OrderAggregate;
using DeliveryApp.Core.Domain.SharedKernel;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryApp.Core.Domain.CourierAggregate
{
    public class Transport
    {
        /// <summary>
        /// название транспорта
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// скорость
        /// </summary>
        public int Speed { get; private set; }

        /// <summary>
        /// грузоподъемность
        /// </summary>
        public decimal Capacity { get; private set; }
              
        /// <summary>
        /// Ctr
        /// </summary>
        [ExcludeFromCodeCoverage]
        private Transport()
        {
        }
    }
}
