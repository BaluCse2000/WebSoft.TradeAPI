using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WebSoft.TradeAPI.Data;
using WebSoft.TradeAPI.Helpers;

namespace WebSoft.TradeAPI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            var inMemoryDb = new InMemoryDb((IConfiguration)host.Services.GetService(typeof(IConfiguration)));
            var cache = host.Services.GetRequiredService<IMemoryCache>();

            var accounts = inMemoryDb.Accounts;
            cache.Set(Constants.AccountsCacheKey, accounts);
            var institutions = inMemoryDb.Institutions;
            cache.Set(Constants.InstitutionsCacheKey, institutions);
            var investments = inMemoryDb.Investments;
            cache.Set(Constants.InvestmentsCacheKey, investments);

            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
