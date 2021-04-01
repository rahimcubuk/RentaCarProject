﻿using Business.Abstract.Services;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstract.Dals;
using Entities.Concrete.DTOs;
using System.Collections.Generic;

namespace Business.Concrete.Managers
{
    public class UserManager : IUserService
    {
        #region Kurucu Metot
        private IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        #endregion

        #region Metotlar
        public IResult Add(User entity)
        {
            _userDal.Add(entity);
            return new SuccessResult(Messages.SuccessAdded);
        }

        public IDataResult<User> GetByMail(string email)
        {
            var data = _userDal.Get(u => u.Email == email);
            return new SuccessDataResult<User>(data, Messages.SuccessListed);
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            var data = _userDal.GetClaims(user);
            if (data.Count == 0)
            {
                return new ErrorDataResult<List<OperationClaim>>(Messages.ClaimsNotFound);
            }
            return new SuccessDataResult<List<OperationClaim>>(data, Messages.SuccessListed);
        }

        public IResult Delete(User entity)
        {
            _userDal.Delete(entity);
            return new SuccessResult(Messages.SuccessDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            var data = _userDal.GetAll();
            if (data == null)
            {
                return new ErrorDataResult<List<User>>(data, Messages.ErrorListed);
            }
            return new SuccessDataResult<List<User>>(data, Messages.SuccessListed);
        }

        public IDataResult<User> GetById(int id)
        {
            var data = _userDal.Get(x => x.UserId == id);
            if (data == null)
            {
                return new ErrorDataResult<User>(data, Messages.ErrorListed);
            }
            return new SuccessDataResult<User>(data, Messages.SuccessListed);
        }

        public IResult UpdateUser(UserForUpdateDto entity)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(entity.Password, out passwordHash, out passwordSalt);
            var user = new User
            {
                UserId = entity.UserId,
                Email = entity.Email,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userDal.Update(user);
            return new SuccessDataResult<User>(user, Messages.UserRegistered);
        }

        public IResult AddUserClaim(UserOperationClaim userOperationClaim)
        {
            _userDal.AddUserClaim(userOperationClaim);
            return new SuccessResult();
        }

        public IResult Update(User entity)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
