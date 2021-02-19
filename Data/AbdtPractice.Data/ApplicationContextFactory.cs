using System;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Logging;

namespace AbdtPractice.Data
{
    [UsedImplicitly]
    public class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddProvider(new MyLoggerProvider());
        });
        
        public static void SetOptions(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder
                .UseLoggerFactory(MyLoggerFactory)
                .UseLazyLoadingProxies()
                .UseSqlite("Data Source=Application.db;Cache=Shared");
        }

        public static DbContextOptions GetOptions()
        {
            var optionsBuilder = new DbContextOptionsBuilder();
            SetOptions(optionsBuilder);
            return optionsBuilder.Options;
        }

        public ApplicationDbContext CreateDbContext(string[] args)
        {
            return new ApplicationDbContext(GetOptions(), new OperationalStoreOptionsMigrations());
        }
        
        public class MyLoggerProvider : ILoggerProvider
        {
            public ILogger CreateLogger(string categoryName)
            {
                return new MyLogger();
            }
 
            public void Dispose() { }
 
            private class MyLogger : ILogger
            {
                public IDisposable BeginScope<TState>(TState state)
                {
                    return null;
                }
 
                public bool IsEnabled(LogLevel logLevel)
                {
                    return true;
                }
 
                public void Log<TState>(LogLevel logLevel, EventId eventId, 
                    TState state, Exception exception, Func<TState, Exception, string> formatter)
                {
                    Console.WriteLine(formatter(state, exception));
                }
            }
        }
    }
}