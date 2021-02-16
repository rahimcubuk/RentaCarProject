﻿using Project.Business.Abstract.Services;
using System.Collections.Generic;
using Project.Core.Utilities.Results.Abstract;
using Project.Entities.Concrete.Models;
using Project.DataAccess.Abstract.Dals;
using Project.Core.Utilities.Results.Concrete;
using Project.Business.Constants;
using Project.Entities.Concrete.DTOs;
using System;

namespace Project.Business.Concrete.Managers
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
            var data = _rentalDal.GetById(x => x.Id == id);
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
