﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebAppForTheJob.Data.Models
{
    public class Founder
    {
        public Founder(int id, string inn, string fullName)
        {
            Id = id;
            Inn = inn;
            FullName = fullName;
            DateAdded = DateTime.Now;
            DateOfUpdate = DateTime.Now;
        }

        public int Id { get; set; }
        public string Inn { get; set; }
        public string FullName { get; set; } //создать свой класс?!
        public DateTime DateAdded { get; private set; }
        public DateTime DateOfUpdate { get; set; } 
        public virtual Client Client { get; set; }
    }
}
