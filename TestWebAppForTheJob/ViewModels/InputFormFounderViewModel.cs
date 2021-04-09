using System.Collections.Generic;
using TestWebAppForTheJob.Data.Models;

namespace TestWebAppForTheJob.ViewModels
{
    public class InputFormFounderViewModel
    {
        public IEnumerable<Client> AllClient { get; set; }
        public string ClientFounder { get; set; }
    }
}
