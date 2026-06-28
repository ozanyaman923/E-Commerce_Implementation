using Business.Abstract;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        public async Task AddAsync(User user)
        {
            await _userDal.AddAsync(user);
        }

        public async Task<User> GetByMailAsync(string email)
        {
            return await _userDal.GetAsync(u => u.Email == email);
        }
    }
}
