﻿using Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Data
{
    public interface IAdminRepository
    {
        Task<Admin> GetAdminAsync(Guid id);
    }
}
