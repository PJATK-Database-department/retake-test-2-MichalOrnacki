﻿using ApbdTest2.Dtos;
using ApbdTest2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApbdTest2.Services
{
    public class DbService : IDbService
    {
        public s22378Context _dbContext;

        public DbService(s22378Context dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Firefighter> GetFirefighter()
        {
            return await _dbContext.Firefighters.FirstOrDefaultAsync();
        }

        public async Task<GetFiretruckResponse> GetFiretruckDetails(int idFiretruck)
        {
            GetFiretruckResponse gfr = new GetFiretruckResponse();

            var truck = await _dbContext.Firetrucks.FirstOrDefaultAsync(t => t.IdFireTruck == idFiretruck);
            gfr.truck = new Truck 
            {
                IdFireTruck = truck.IdFireTruck,
                OperationalNumber = truck.OperationalNumber,
                SpecialEquipment =  truck.SpecialEquipment
            };
            gfr.actionsList = await GetActionList(idFiretruck);
            return gfr;
        }

        public async Task<List<FireAction>> GetActionList(int idFiretruck)
        {
            List<FireAction> actionList = await _dbContext.FiretruckActions
                .Include(fa => fa.IdActionNavigation)
                .ThenInclude(a => a.FirefighterActions)
                .Where(fa => fa.IdFireTruck == idFiretruck)
                .OrderByDescending(x => x.IdActionNavigation.EndTime)
                .Select(X => new FireAction
                {
                    IdAction = X.IdAction,
                    StartTime = X.IdActionNavigation.StartTime,
                    EndTime = X.IdActionNavigation.EndTime,
                    NeedSpecialEquipment = X.IdActionNavigation.NeedSpecialEquipment,
                    Firefighters = X.IdActionNavigation.FirefighterActions.Count,
                    FiretruckAssignedDate = X.AssignmentDate
                })
                .ToListAsync();

            return actionList;

        }

        public async Task UpdateEndTime(int idAction, DateTime date)
        {
            var action = await _dbContext.Actions.FirstOrDefaultAsync(a => a.IdAction == idAction);
            action.EndTime = date;
            await _dbContext.SaveChangesAsync();
        }
        public async Task<bool> DoesActionExist(int idAction)
        {
            return await _dbContext.Actions.AnyAsync(a => a.IdAction == idAction);
        }
        public async Task<bool> CheckDates(int idAction, DateTime date)
        {
            return true;
        }
        public async Task<bool> CheckIfDateAssigned(int idAction)
        {
            var a = await _dbContext.Actions.FirstAsync(a => a.IdAction == idAction);
            if(a.EndTime == null)
            {
                return false;
            } else
            {
                return true;
            }
        }
        public async Task<bool> DoesFiretruckExist(int idFiretruck)
        {
            return await _dbContext.Firetrucks.AnyAsync(f => f.IdFireTruck == idFiretruck);
        }
    }
}
