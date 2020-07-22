using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Options.Pages
{
    public class IndexModel : PageModel
    {
        public IOptions<HomePageOptions> Options { get; }
        public IOptionsSnapshot<HomePageOptions> Snapshot { get; }
        public IOptionsMonitor<HomePageOptions> Monitor { get; }

        public IndexModel(
            IOptions<HomePageOptions> options, 
            IOptionsSnapshot<HomePageOptions> snapshot,
            IOptionsMonitor<HomePageOptions> monitor)
        {
            Options = options;
            Snapshot = snapshot;
            Monitor = monitor;
        }

        public void OnGet()
        {
        }
    }
}
