using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWebAppForTheJob.Data.Models;

namespace TestWebAppForTheJob.Data
{
    public class DBObjects
    {
        public static void Initial(AppDBContext context)
        {
            if (!context.Founders.Any())
            {
                context.Founders.AddRange(Founders.Select(c => c.Value));
            }
            if (!context.Clients.Any())
            {
                context.AddRange(
                new Client(inn: "123456789000", name: "ФондИвест", isEntrepreneur: false, founder: new List<Founder>() { Founders["1"], Founders["2"]}),
                new Client(inn: "123456789033", name: "Моэстро", isEntrepreneur: false, founder: new List<Founder>() { Founders["0"], Founders["3"] }),
                new Client(inn: "123456789056", name: "ГолдБест", isEntrepreneur: true, founder: new List<Founder>() { Founders["4"]})
                );
            }
            context.SaveChanges();
        }

        private static Dictionary<string, Founder> _founders;
        public static Dictionary<string, Founder> Founders
        {
            get
            {
                if (_founders == null)
                {
                    var list = new Founder[]
                    {
                        new Founder(clientId: "0", inn: "000004400401", fullName: "Александров Александр Александрович"),
                        new Founder(clientId: "1", inn: "000000000001", fullName: "Иванов Иван Иванович"),
                        new Founder(clientId: "2", inn: "000000000002", fullName: "Петров Петр Петрович"),
                        new Founder(clientId: "3", inn: "000000300001", fullName: "Сидоров Сидор Сидорович"),
                        new Founder(clientId: "4", inn: "060000304001", fullName: "Артёмов Артём Артёмович"),
                    };
                    _founders = new Dictionary<string, Founder>();
                    foreach (var el in list)
                    {
                        _founders.Add(el.ClientId, el);
                    }

                }
                return _founders;
            }
        }
    }
}
