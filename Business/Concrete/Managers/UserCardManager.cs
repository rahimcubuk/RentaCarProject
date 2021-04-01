using Business.Abstract.Services;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract.Dals;
using Entities.Concrete.DTOs;
using Entities.Concrete.Models;
using System.Collections.Generic;

namespace Business.Concrete.Managers
{
    public class UserCardManager : IUserCardService
    {
        private IUserCardDal _userCardDal;
        public UserCardManager(IUserCardDal userCardDal)
        {
            _userCardDal = userCardDal;
        }

        [ValidationAspect(typeof(UserCardValidator))]
        public IResult Add(UserCard entity)
        {
            _userCardDal.Add(entity);
            return new SuccessResult(Messages.SuccessAdded);
        }

        public IResult Delete(UserCard entity)
        {
            _userCardDal.Delete(entity);
            return new SuccessResult(Messages.SuccessDeleted);
        }

        public IDataResult<List<UserCard>> GetAll()
        {
            var data = _userCardDal.GetAll();
            if (data is null) return new ErrorDataResult<List<UserCard>>(data, Messages.ErrorListed);
            return new SuccessDataResult<List<UserCard>>(data, Messages.SuccessListed);
        }

        public IDataResult<UserCard> GetById(int id)
        {
            var data = _userCardDal.Get(uc => uc.Id == id);
            if (data is null) return new ErrorDataResult<UserCard>(data, Messages.NotFoundCreditCard);
            return new SuccessDataResult<UserCard>(data, Messages.SuccessListed);
        }

        public IDataResult<UserCardDetailsDto> GetUserCardById(int id)
        {
            var data = _userCardDal.GetUserCardById(ucd => ucd.Id == id);
            if (data is null) return new ErrorDataResult<UserCardDetailsDto>(data, Messages.NotFoundCreditCard);
            return new SuccessDataResult<UserCardDetailsDto>(data, Messages.SuccessListed);
        }

        public IDataResult<List<UserCardDetailsDto>> GetUserCardByUserId(int userId)
        {
            var data = _userCardDal.GetUserCardsByUserId(ucd => ucd.UserId == userId);
            if (data is null) return new ErrorDataResult<List<UserCardDetailsDto>>(data, Messages.ErrorListed);
            return new SuccessDataResult<List<UserCardDetailsDto>>(data, Messages.SuccessListed);
        }

        public IResult Update(UserCard entity)
        {
            _userCardDal.Update(entity);
            return new SuccessResult(Messages.SuccessUpdated);
        }
    }
}
