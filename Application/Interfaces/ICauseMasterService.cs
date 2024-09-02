﻿using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICauseMasterService
    {
        IQueryable<CauseMasterList> GetAllCauseMastersAsync();
        // Add additional methods related to CauseMaster if needed
    }
}