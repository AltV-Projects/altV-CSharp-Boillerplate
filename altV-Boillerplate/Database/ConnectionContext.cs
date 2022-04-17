﻿using Microsoft.EntityFrameworkCore;

namespace Database
{
    class ConnectionContext : DbContext
    {
        private string GetConnectionString()
        {
            Config SQLConfig = new Config();
            return $"server={SQLConfig.Host};" +
                $"port={SQLConfig.Port};" +
                $"database={SQLConfig.Database};" +
                $"user={SQLConfig.Username};" +
                $"password={SQLConfig.Password}";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ServerVersion sv = ServerVersion.AutoDetect(GetConnectionString());
            optionsBuilder.UseMySql(GetConnectionString(), sv);
        }
    }
}