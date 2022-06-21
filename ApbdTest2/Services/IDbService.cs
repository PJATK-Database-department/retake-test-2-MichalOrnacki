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
        Task UpdateEndTime(int idAction, DateTime date);

        Task<bool> DoesFiretruckExist(int idFiretruck);

        Task<bool> CheckIfDateAssigned(int idAction);
        Task<bool> CheckDates(int idAction, DateTime date);
        Task<bool> DoesActionExist(int idAction);
    }
}
