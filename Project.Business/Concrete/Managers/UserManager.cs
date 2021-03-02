using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Project.Business.Abstract.Services;
using Project.Business.Constants;
using Project.DataAccess.Abstract.Dals;
using System.Collections.Generic;
using Core.Entities.Concrete;

namespace Project.Business.Concrete.Managers
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

        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
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

        public IResult Update(User entity)
        {
            _userDal.Update(entity);
            return new SuccessResult(Messages.SuccessUpdated);
        }

        #endregion
    }
}
