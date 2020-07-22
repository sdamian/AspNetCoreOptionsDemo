using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;

namespace Options
{
    public interface IConfigDb
    {
        Task<string> GetTitle();
    }

    public class FakeDb : IConfigDb, IOptionsChangeTokenSource<HomePageOptions>
    {
        private static int _counter;

        public Task<string> GetTitle()
        {
            return Task.FromResult($"You have {_counter++} friends");
        }

        public string Name { get; }

        public IChangeToken GetChangeToken()
        {
            // every 2 seconds - notify everyone that's monitoring option changes that something changed
            var changeInterval = TimeSpan.FromSeconds(2);
            var tokenSource = new CancellationTokenSource(changeInterval);
            return new CancellationChangeToken(tokenSource.Token);
        }
    }
}