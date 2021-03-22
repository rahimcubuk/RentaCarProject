using Business.Abstract.Services;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract.Dals;
using Entities.Concrete.Models;
using System;
using System.Collections.Generic;

namespace Business.Concrete.Managers
{
    public class PaymentManager : IPaymentService
    {
        #region Kurucu Metotlar
        private IPaymentDal _paymentDal;
        private IRentalService _rentalService;
        private ICustomerService _customerService;
        public PaymentManager(IPaymentDal paymentDal, IRentalService rentalService, ICustomerService customerService)
        {
            _paymentDal = paymentDal;
            _rentalService = rentalService;
            _customerService = customerService;
        }
        #endregion

        #region Business Rules
        private IResult CheckIfCustomerExists(int customer)
        {
            var result = _customerService.GetById(customer).Data;
            return result == null ? new ErrorResult(Messages.CarIsNotFound) : (IResult)new SuccessResult();
        }
        private IResult CheckIfRentExists(int rent)
        {
            var result = _rentalService.GetById(rent).Data;
            return result == null ? new ErrorResult(Messages.CarIsNotFound) : (IResult)new SuccessResult();
        }

        #endregion

        [ValidationAspect(typeof(PaymentValidator))]
        public IResult Add(Payment entity)
        {
            var result = BusinessRules.Run(CheckIfCustomerExists(entity.CustomerId), CheckIfRentExists(entity.RentalId));
            if (!(result is null)) return result;

            _paymentDal.Add(entity);
            return new SuccessResult(Messages.SuccessAdded);
        }

        public IResult Delete(Payment entity)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Payment>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Payment> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Payment entity)
        {
            throw new NotImplementedException();
        }
    }
}
