using Project.Business.Abstract.Services;
using Project.Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Project.DataAccess.Abstract.Dals;
using Project.Entities.Concrete.Models;
using System.Collections.Generic;
using Project.Entities.Concrete.DTOs;

namespace Project.Business.Concrete.Managers
{
    public class CustomerManager : ICustomerService
    {
        #region Kurucu Metot
        private ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }
        #endregion

        #region Metotlar
        public IResult Add(Customer entity)
        {
            _customerDal.Add(entity);
            return new SuccessResult(Messages.SuccessAdded);
        }

        public IResult Delete(Customer entity)
        {
            _customerDal.Delete(entity);
            return new SuccessResult(Messages.SuccessDeleted);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            var data = _customerDal.GetAll();
            if (data == null)
            {
                return new ErrorDataResult<List<Customer>>(data, Messages.ErrorListed);
            }
            return new SuccessDataResult<List<Customer>>(data, Messages.SuccessListed);
        }

        public IDataResult<Customer> GetById(int id)
        {
            var data = _customerDal.GetById(x => x.CustomerId == id);
            if (data == null)
            {
                return new ErrorDataResult<Customer>(data, Messages.ErrorListed);
            }
            return new SuccessDataResult<Customer>(data, Messages.SuccessListed);
        }

        public IDataResult<CustomerDetailsDto> GetCustomerDetailById(int id)
        {
            var data = _customerDal.GetCustomerDetailsById(c => c.CustomerId == id);
            if (data == null)
            {
                return new ErrorDataResult<CustomerDetailsDto>(data, Messages.ErrorListed);
            }
            return new SuccessDataResult<CustomerDetailsDto>(data, Messages.SuccessListed);
        }

        public IDataResult<List<CustomerDetailsDto>> GetCustomersDetails()
        {
            var data = _customerDal.GetAllCustomerDetails();
            if (data == null)
            {
                return new ErrorDataResult<List<CustomerDetailsDto>>(data, Messages.ErrorListed);
            }
            return new SuccessDataResult<List<CustomerDetailsDto>>(data, Messages.SuccessListed);
        }

        public IResult Update(Customer entity)
        {
            _customerDal.Update(entity);
            return new SuccessResult(Messages.SuccessUpdated);
        }

        #endregion
    }
}
