using Business.Abstract.Services;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract.Dals;
using Entities.Concrete.DTOs;
using Entities.Concrete.Models;
using System;
using System.Collections.Generic;

namespace Business.Concrete.Managers
{
    public class CarManager : ICarService
    {
        #region Kurucu Metotlar
        private ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        #endregion

        #region Business Rule
        #endregion

        #region Metotlar

        [ValidationAspect(typeof(CarValidator))]
        [SecuredOperation("admin")]
        public IResult Add(Car entity)
        {
            _carDal.Add(entity);
            return new SuccessResult(Messages.SuccessAdded);
        }

        public IResult Delete(Car entity)
        {
            _carDal.Delete(entity);
            return new SuccessResult(Messages.SuccessDeleted);
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car entity)
        {
            _carDal.Update(entity);
            return new SuccessResult(Messages.SuccessUpdated);
        }

        public IDataResult<Car> GetById(int id)
        {
            var data = _carDal.Get(x => x.CarId == id);
            if (data == null)
                return new ErrorDataResult<Car>(data, Messages.ErrorListed);
            return new SuccessDataResult<Car>(data, Messages.SuccessListed);
        }

        //[SecuredOperation("Car.List,admin")]
        [PerformanceAspect(5)]
        [CacheAspect(duration: 10)]
        public IDataResult<List<Car>> GetAll()
        {
            var data = _carDal.GetAll();
            if (data == null)
            {
                return new ErrorDataResult<List<Car>>(data, Messages.ErrorListed);
            }
            return new SuccessDataResult<List<Car>>(data, Messages.SuccessListed);
        }

        public IDataResult<List<CarDetailsDto>> GetCarsByBrand(string brand)
        {
            var data = _carDal.GetAllCarDetails(x => x.BrandName == brand);
            if (data == null)
            {
                return new ErrorDataResult<List<CarDetailsDto>>(data, Messages.ErrorListed);
            }
            return new SuccessDataResult<List<CarDetailsDto>>(data, Messages.SuccessListed);
        }

        public IDataResult<List<CarDetailsDto>> GetCarsByColor(string color)
        {
            var data = _carDal.GetAllCarDetails(x => x.ColorName == color);
            if (data == null)
            {
                return new ErrorDataResult<List<CarDetailsDto>>(data, Messages.ErrorListed);
            }
            return new SuccessDataResult<List<CarDetailsDto>>(data, Messages.SuccessListed);
        }

        //[SecuredOperation("Car.List,admin")]
        [PerformanceAspect(5)]
        [CacheAspect(duration: 10)]
        public IDataResult<List<CarDetailsDto>> GetCarsDetails()
        {
            var data = _carDal.GetAllCarDetails();
            if (data == null)
            {
                return new ErrorDataResult<List<CarDetailsDto>>(data, Messages.ErrorListed);
            }
            return new SuccessDataResult<List<CarDetailsDto>>(data, Messages.SuccessListed);
        }

        public IDataResult<CarDetailsDto> GetCarDetailById(int id)
        {
            var data = _carDal.GetCarDetailsById(x => x.CarId == id);
            if (data == null)
            {
                return new ErrorDataResult<CarDetailsDto>(data, Messages.ErrorListed);
            }
            return new SuccessDataResult<CarDetailsDto>(data, Messages.SuccessListed);
        }

        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Car car)
        {
            Add(car);
            if (car.DailyPrice < 75)
            {
                throw new Exception("");
            }
            Add(car);
            return null;
        }
        #endregion
    }
}
