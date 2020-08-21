using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SchoolBook.Data;
using SchoolBook.Models;

namespace SchoolBook.Utils
{
    public class LoggerDatabaseProvider : ILoggerProvider
    {
        private readonly IConfiguration _configuration;
        private readonly IActionContextAccessor _httpContextAccessor;

        public LoggerDatabaseProvider(IConfiguration configuration, IActionContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new Logger(categoryName, _configuration, _httpContextAccessor);
        }

        public void Dispose()
        {
        }

        public class Logger : ILogger
        {
            private readonly string _categoryName;
            private readonly IActionContextAccessor _httpContextAccessor;
            private readonly DbContextOptionsBuilder<ApplicationDbContext> _optionsBuilder;
            private string UserName => _httpContextAccessor?.ActionContext != null ? _httpContextAccessor.ActionContext.HttpContext.User.FindFirstValue(ClaimTypes.Email) : "Anonymous";

            public Logger(string categoryName, IConfiguration configuration, IActionContextAccessor httpContextAccessor)
            {
                _categoryName = categoryName;
                _httpContextAccessor = httpContextAccessor;

                _optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
                _optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            }

            public bool IsEnabled(LogLevel logLevel)
            {
                return true;
            }

            public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
            {
                RecordMsg(logLevel, eventId, state, exception, formatter);
            }

            private void RecordMsg<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
            {
                using var dbContext = new ApplicationDbContext(_optionsBuilder.Options);
                dbContext.Logs.Add(new Log
                {
                    LogLevel = logLevel.ToString(),
                    CategoryName = _categoryName,
                    Msg = formatter(state, exception),
                    User = UserName,
                    Timestamp = DateTime.Now
                });

                dbContext.SaveChanges();
            }

            public IDisposable BeginScope<TState>(TState state)
            {
                return new NoopDisposable();
            }

            private class NoopDisposable : IDisposable
            {
                public void Dispose()
                {
                }
            }
        }
    }

}
