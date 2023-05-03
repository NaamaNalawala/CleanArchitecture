using RentalQuotationModule.Core.Entities;
using RentalQuotationModule.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalQuotationModule.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IAsyncRepository<User> _repository;
        public UserService(IAsyncRepository<User> repository)
        {
            _repository = repository;
        }
        public async Task<User> AuthenticateUserAsync(User user)
        {
            var result = await _repository.GetAllAsync();
            if (result!=null)
            {
                return result.First(x => x.Email == user.Email && x.Password == user.Password);
            }
            return null;
            
        }
    }
}
