﻿using SparrowManagementSystem.Core.Entities;
using SparrowManagementSystem.Core.Interfaces.IRepository;
using SparrowManagementSystem.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisitsManagementSystem.BussinessLogic.Logic;

namespace SparrowManagementSystem.BusinessLogic.Logic.Repositories
{
    public class MaterialRepository : GenericRepository<Material>, IMaterialRepository
    {
        public MaterialRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
