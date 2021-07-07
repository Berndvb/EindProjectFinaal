using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectOefening.Domain.Identity;
using ProjectOefening.Repository;

[assembly: HostingStartup(typeof(ProjectOefening_1_Web___Media_Collection.Areas.Identity.IdentityHostingStartup))]
namespace ProjectOefening_1_Web___Media_Collection.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}