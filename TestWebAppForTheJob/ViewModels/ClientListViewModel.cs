﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWebAppForTheJob.Data.Models;

namespace TestWebAppForTheJob.ViewModels
{
    public class ClientListViewModel
    {
        public IEnumerable<Client> AllClient { get; set; }
        public Client Client { get; set; }
    }
}
