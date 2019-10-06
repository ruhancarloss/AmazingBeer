﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Cerveja.Domain.Interface.Service
{
    public interface ICervejaQueryService
    {
        IEnumerable<CervejaAggregate.Cerveja> GetAll();
        CervejaAggregate.Cerveja Get(Guid id);
    }
}