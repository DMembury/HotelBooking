using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waracle.HotelBooking.Domain
{
    public interface IHotelRepository
    {
        /// <summary>
        /// Gets a <see cref="Hotel"/> by partial match upon its name.
        /// </summary>
        /// <param name="searchTerm"></param>
        /// <returns></returns>
        Hotel GetHotelByName(string searchTerm);
    }
}
