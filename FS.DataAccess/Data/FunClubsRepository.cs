﻿using System;
using System.Collections.Generic;
using System.Linq;
using FS.Core.Enums;
using FS.Core.Interfaces.Repositories;
using FS.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace FS.DataAccess.Data
{
    public class FunClubsRepository : IFunClubsRepository
    {
        private readonly UsersContext context;

        public FunClubsRepository(UsersContext context)
        {
            this.context = context;
        }

        public IReadOnlyList<FunClub> Get()
        {
            return context.FunClubs
                .Include(fc => fc.Team)
                .Include(fc => fc.UsersFunClub)
                    .ThenInclude(ufc => ufc.User)
                .Include(fc => fc.UsersFunClub)
                    .ThenInclude(ufc => ufc.FunClub)
                .ToList();
        }

        public void Add(FunClub item)
        {
            context.FunClubs.Add(item);
            context.SaveChanges();
        }

        public void Remove(FunClub item)
        {
            context.FunClubs.Remove(item);
            context.SaveChanges();
        }

        public FunClub FindById(int id)
        {
            return Get().FirstOrDefault(funClub => funClub.Id == id);
        }
    }
}