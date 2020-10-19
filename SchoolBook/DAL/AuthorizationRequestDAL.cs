using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using SchoolBook.Data;
using SchoolBook.Models;
using Microsoft.EntityFrameworkCore;
using SchoolBook.Utils;

namespace SchoolBook.DAL
{
    public class AuthorizationRequestDAL : BaseDAL, IAuthorizationRequestDAL
    {
        public UserManager<User> UserManager { get; }
        public ClaimsPrincipal User { get; }
        public IUsersDAL UserDAL { get; }

        public AuthorizationRequestDAL(IUsersDAL userDAL, ApplicationDbContext dbContext, ILogger<MenuOptionsDAL> logger) : base(dbContext, logger)
        {
            UserDAL = userDAL;
        }

        public AuthorizationRequest GetNewAuthorization(int registerId, AuthorizationType type)
        {
            var authorization = new AuthorizationRequest
            {
                Date = DateTime.Now,
                RegisterId = registerId,
                Approvers = UserDAL.GetSuperiors(),
                Status = AuthorizationStatus.Pending,
                Type = type
            };

            return authorization;
        }

        public void RequestCancelAuthorization(int registerId, AuthorizationType type, string comment)
        {
            var authorization = new AuthorizationRequest
            {
                Date = DateTime.Now,
                Status = AuthorizationStatus.Pending,
                Type = type,
                Observation = comment
            };

            if (type == AuthorizationType.CancelObservation)
            {
                var observation = _dbContext.Observations.FirstOrDefault(o => o.Id == registerId);
                observation.AuthorizationRequest = authorization;
            }
            else if (type == AuthorizationType.CancelAnnotation)
            {
                var annotation = _dbContext.Anotations.FirstOrDefault(o => o.Id == registerId);
                annotation.AuthorizationRequest = authorization;
            }

            _dbContext.SaveChanges();
        }
    }

    public interface IAuthorizationRequestDAL
    {
        AuthorizationRequest GetNewAuthorization(int registerId, AuthorizationType type);
        void RequestCancelAuthorization(int registerId, AuthorizationType type, string comment);
    }
}