using ApbdTest2.Dtos;
using ApbdTest2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApbdTest2.Services
{
    public interface IDbService
    {
        Task<Firefighter> GetFirefighter();

        Task<GetFiretruckResponse> GetFiretruckDetails(int idFiretruck);

        Task<bool> DoesFiretruckExist(int idFiretruck);
    }
}
