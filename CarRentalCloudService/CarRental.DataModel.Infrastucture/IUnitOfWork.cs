﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.DataModel.Infrastucture
{
    public interface IUnitOfWork : IDisposable
    {
        void SaveChanges();
    }
}
