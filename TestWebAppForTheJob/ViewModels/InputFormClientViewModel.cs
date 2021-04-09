using System.Collections.Generic;
using TestWebAppForTheJob.Data.Models;

namespace TestWebAppForTheJob.ViewModels
{
    public class InputFormClientViewModel
    {
        public IEnumerable<Client> AllClient { get; set; }
        public string ClientFounder { get; set; }
    }
}
