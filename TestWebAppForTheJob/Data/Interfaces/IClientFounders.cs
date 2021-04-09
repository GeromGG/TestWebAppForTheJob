﻿using System.Collections.Generic;
using System.Threading.Tasks;
using TestWebAppForTheJob.Data.Models;

namespace TestWebAppForTheJob.Data.Interfaces
{
    public interface IClientFounders
    {
        Task<IReadOnlyList<Founder>> AllFounders();
        Task<IReadOnlyList<Founder>> GetClientFounders(int clientID);
    }
}
