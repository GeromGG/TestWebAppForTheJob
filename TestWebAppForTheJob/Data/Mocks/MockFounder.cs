﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWebAppForTheJob.Data.Interfaces;
using TestWebAppForTheJob.Data.Models;

namespace TestWebAppForTheJob.Data.Mocks
{
    public class MockFounder : IClientFounders
    {
        public IEnumerable<Founder> AllFounders 
        {
            get {
                return new List<Founder>
                {
                    new Founder(clientId:"0", inn:"000004400401", fullName:"Александров Александр Александрович"),
                    new Founder(clientId:"1", inn:"000000000001", fullName:"Иванов Иван Иванович"),
                    new Founder(clientId:"2", inn:"000000000002", fullName:"Петров Петр Петрович"),
                    new Founder(clientId:"3", inn:"000000300001", fullName:"Сидоров Сидор Сидорович"),
                    new Founder(clientId:"4", inn:"060000304001", fullName:"Артёмов Артём Артёмович"),
                };
            } 
        }
    }
}
