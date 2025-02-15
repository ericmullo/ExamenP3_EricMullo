﻿using ExamenP3_EricMullo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenP3_EricMullo.Interfaces
{
    internal interface IAeropuertoRepository
    {
        public Task<bool> SaveInSQLite(AeropuertoModel airport);
        public Task<IEnumerable<AeropuertoModel>> GetAllAirports(AeropuertoModel airport);
    }
}
