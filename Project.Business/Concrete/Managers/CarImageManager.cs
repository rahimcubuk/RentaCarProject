﻿using Project.Business.Abstract.Services;
using System.Collections.Generic;
using Project.Entities.Concrete.Models;
using Project.DataAccess.Abstract.Dals;
using Core.Utilities.Results.Abstract;
using Project.Business.Constants;
using Core.Utilities.Results.Concrete;
using System;
using Microsoft.AspNetCore.Http;
using Core.Utilities.Helpers;
using Core.Aspects.Autofac.Validation;
using Project.Business.ValidationRules.FluentValidation;
using System.IO;
using System.Linq;
using Core.Utilities.Business;

namespace Project.Business.Concrete.Managers
{
    public class CarImageManager : ICarImageService
    {
        #region Kurucu Metotlar
        private ICarImageDal _imageDal;
        private ICarService _carService;
        public CarImageManager(ICarImageDal carImageDal, ICarService carService)
        {
            _imageDal = carImageDal;
            _carService = carService;
        }
        #endregion

        #region Business Rules
        private IResult CheckCountOfImageByCar(int carId)
        {
            int count = _imageDal.GetAll(i => i.CarId == carId).Count;
            return count > 5 ? new ErrorResult(Messages.CarImageLimitExceded) : (IResult)new SuccessResult();
        }
        private IResult CheckIfCarExists(int carId)
        {
            var result = _carService.GetById(carId).Data;
            return result == null ? new ErrorResult(Messages.CarIsNotFound) : (IResult)new SuccessResult();
        }
        private IResult CheckIfCarImageExists(int carId)
        {
            var result = BusinessRules.Run(CheckIfCarExists(carId));
            if (!result.Success) return new ErrorResult(Messages.CarIsNotFound);
            
            var data = _imageDal.GetAll(i => i.CarId == carId).Count;
            if (data == 0)
            {
                AddImageToCar(carId);
                return new ErrorResult(Messages.ImageIsNotFound);
            }
            
            return new SuccessResult();
        }
        private IResult CheckIfCarImageExistsById(int id)
        {
            var result = _imageDal.GetAll(i => i.Id == id).Count;
            if (result == 0)
            {
                return new ErrorResult(Messages.ImageIsNotFound);
            }
            return new SuccessResult();
        }
        private IResult AddImageToCar(int carId)
        {
            string path = FileHelper.NewPath();
            _imageDal.Add(new CarImage()
            {
                CarId = carId,
                ImagePath = path,
                Date = DateTime.Now
            });
            return new SuccessResult(Messages.SuccessAdded);
        }
        #endregion

        #region Metotlar

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile image, CarImage entity)
        {
            IResult result = BusinessRules.Run(CheckCountOfImageByCar(entity.CarId), CheckIfCarExists(entity.CarId));

            if (!(result is null)) return result;

            entity.ImagePath = FileHelper.Add(image);
            entity.Date = DateTime.Now;
            _imageDal.Add(entity);
            return new SuccessResult(Messages.SuccessAdded);
        }

        public IResult Delete(CarImage entity)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageExistsById(entity.Id));

            if (!(result is null)) return result;

            FileHelper.Delete(GetById(entity.Id).Data.ImagePath);
            _imageDal.Delete(entity);
            return new SuccessResult(Messages.SuccessDeleted);
        }

        public IResult Update(IFormFile image, CarImage entity)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageExistsById(entity.Id));

            if (!(result is null)) return result;

            entity.ImagePath = FileHelper.Update(_imageDal.GetById(p => p.Id == entity.Id).ImagePath, image);
            entity.Date = DateTime.Now;
            _imageDal.Update(entity);
            return new SuccessResult(Messages.SuccessUpdated);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            var data = _imageDal.GetAll();
            if (data == null)
            {
                return new ErrorDataResult<List<CarImage>>(data, Messages.ErrorListed);
            }
            return new SuccessDataResult<List<CarImage>>(data, Messages.SuccessListed);
        }

        public IDataResult<CarImage> GetById(int id)
        {
            var data = _imageDal.GetById(x => x.Id == id);
            if (data == null)
            {
                return new ErrorDataResult<CarImage>(data, Messages.ErrorListed);
            }
            return new SuccessDataResult<CarImage>(data, Messages.SuccessListed);
        }

        public IDataResult<List<CarImage>> GetByCarId(int id)
        {
            var result = BusinessRules.Run(CheckIfCarImageExists(id));

            var data = _imageDal.GetAll(i => i.CarId == id);
            if (data.Count == 0) return new ErrorDataResult<List<CarImage>>(data, Messages.ErrorListed);
            return new SuccessDataResult<List<CarImage>>(data, Messages.SuccessListed);
        }

        #endregion
    }
}
