using Business.Abstract.Services;
using Business.Constants;
using Core.Aspects.Autofac.Transaction;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract.Dals;
using Entities.Concrete.DTOs;
using Entities.Concrete.Models;
using System.Collections.Generic;

namespace Business.Concrete.Managers
{
    public class RentalManager : IRentalService
    {
        #region Kurucu Metot
        private IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        #endregion

        #region Metotlar
        public IResult Add(Rental entity)
        {
            _rentalDal.Add(entity);
            return new SuccessResult(Messages.SuccessAdded);
        }

        public IResult Delete(Rental entity)
        {
            _rentalDal.Delete(entity);
            return new SuccessResult(Messages.SuccessDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            var data = _rentalDal.GetAll();
            if (data == null)
            {
                return new ErrorDataResult<List<Rental>>(data, Messages.ErrorListed);
            }
            return new SuccessDataResult<List<Rental>>(data, Messages.SuccessListed);
        }

        public IDataResult<Rental> GetById(int id)
        {
            var data = _rentalDal.Get(x => x.Id == id);
            if (data == null)
            {
                return new ErrorDataResult<Rental>(data, Messages.ErrorListed);
            }
            return new SuccessDataResult<Rental>(data, Messages.SuccessListed);
        }

        public IDataResult<Rental> GetByCarId(int carId)
        {
            var data = _rentalDal.GetByCarId(x => x.CarId == carId);
            if (data == null)
            {
                return new ErrorDataResult<Rental>(data, Messages.ErrorListed);
            }
            return new SuccessDataResult<Rental>(data, Messages.SuccessListed);
        }

        public IDataResult<RentalDetailsDto> GetRentalDetailById(int id)
        {
            var data = _rentalDal.GetRentDetailsById(r => r.Id == id);
            if (data == null)
            {
                return new ErrorDataResult<RentalDetailsDto>(data, Messages.ErrorListed);
            }
            return new SuccessDataResult<RentalDetailsDto>(data, Messages.SuccessListed);
        }

        public IDataResult<List<RentalDetailsDto>> GetRentalDetails()
        {
            var data = _rentalDal.GetAllRentDetails();
            if (data == null)
            {
                return new ErrorDataResult<List<RentalDetailsDto>>(data, Messages.ErrorListed);
            }
            return new SuccessDataResult<List<RentalDetailsDto>>(data, Messages.SuccessListed);
        }

        public IResult Update(Rental entity)
        {
            _rentalDal.Update(entity);
            return new SuccessResult(Messages.SuccessUpdated);
        }

        #endregion
    }
}
