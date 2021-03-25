using Business.Abstract.Services;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract.Dals;
using Entities.Concrete.Models;
using System;
using System.Collections.Generic;

namespace Business.Concrete.Managers
{
    public class FakeCreditCardManager : IFakeCardService
    {
        private IFakeCreditCardDal _cardDal;
        public FakeCreditCardManager(IFakeCreditCardDal cardDal)
        {
            _cardDal = cardDal;
        }

        [ValidationAspect(typeof(CardValidator))]
        public IResult Add(FakeCreditCard entity)
        {
            _cardDal.Add(entity);
            return new SuccessResult(Messages.SuccessAdded);
        }

        public IResult Delete(FakeCreditCard entity)
        {
            _cardDal.Delete(entity);
            return new SuccessResult(Messages.SuccessDeleted);
        }

        public IDataResult<List<FakeCreditCard>> GetAll()
        {
            var data = _cardDal.GetAll();
            if (data == null)
            {
                return new ErrorDataResult<List<FakeCreditCard>>(data, Messages.ErrorListed);
            }
            return new SuccessDataResult<List<FakeCreditCard>>(data, Messages.SuccessListed);
        }

        public IDataResult<FakeCreditCard> GetById(int id)
        {
            var data = _cardDal.Get(x => x.Id == id);
            if (data == null)
            {
                return new ErrorDataResult<FakeCreditCard>(data, Messages.ErrorListed);
            }
            return new SuccessDataResult<FakeCreditCard>(data, Messages.SuccessListed);
        }

        public IDataResult<FakeCreditCard> GetCardByCardNumber(string cardNumber)
        {
            var data = _cardDal.Get(x => x.CardNumber == cardNumber);
            if (data == null)
            {
                return new ErrorDataResult<FakeCreditCard>(data, Messages.NotFoundCreditCard);
            }
            return new SuccessDataResult<FakeCreditCard>(data, Messages.SuccessListed);
        }

        [ValidationAspect(typeof(CardValidator))]
        public IResult Update(FakeCreditCard entity)
        {
            _cardDal.Update(entity);
            return new SuccessResult(Messages.SuccessUpdated);
        }
    }
}
