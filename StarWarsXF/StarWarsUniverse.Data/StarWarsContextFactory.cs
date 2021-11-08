﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarWarsUniverse.Data
{
    public class StarWarsContextFactory
    {
        public static string ConnectionString;

        public static StarWarsContext Create()
        {
            var options = new DbContextOptionsBuilder<StarWarsContext>()
                .UseSqlite(ConnectionString).Options;
            return new StarWarsContext(options);
        }
    }
}
