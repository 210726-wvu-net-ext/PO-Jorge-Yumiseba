using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using DL.Entities;
using BL;
using DL;
using UI;
using System.IO;


            var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

string connectionString = configuration.GetConnectionString("resdb");

DbContextOptions<retdbContext> options = new DbContextOptionsBuilder<retdbContext>()
    .UseSqlServer(connectionString)
    .Options;

var context = new retdbContext(options);

IMenu menu = new Menu(new Bl(new Dl(context)));
menu.Start();
