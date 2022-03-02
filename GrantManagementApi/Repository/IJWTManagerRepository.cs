using GrantManagementApi.DtoRequest;
using GrantManagementApi.DtoResponse;
using GrantManagementApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrantManagementApi.Repository
{
    public interface IJWTManagerRepository
    {
        Tokens Authenticate(UserRequest users);
    }
}
