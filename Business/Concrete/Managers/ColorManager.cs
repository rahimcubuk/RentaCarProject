using Business.Abstract.Services;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract.Dals;
using Entities.Concrete.Models;
using System.Collections.Generic;

namespace Business.Concrete.Managers
{
    public class ColorManager : IColorService
    {
        #region Kurucu Metotlar
        private IColorDal _colorDal;
        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }
        #endregion

        #region Metotlar
        [SecuredOperation("admin")]
        [CacheRemoveAspect("ColorManager.Get")]
        public IResult Add(Color entity)
        {
            _colorDal.Add(entity);
            return new SuccessResult(Messages.SuccessAdded);
        }

        [SecuredOperation("admin")]
        [CacheRemoveAspect("ColorManager.Get")]
        public IResult Delete(Color entity)
        {
            _colorDal.Delete(entity);
            return new SuccessResult(Messages.SuccessDeleted);
        }

        [SecuredOperation("admin")]
        [CacheRemoveAspect("ColorManager.Get")]
        public IResult Update(Color entity)
        {
            _colorDal.Update(entity);
            return new SuccessResult(Messages.SuccessUpdated);
        }

        [CacheAspect(duration: 10)]
        public IDataResult<List<Color>> GetAll()
        {
            var data = _colorDal.GetAll();
            if (data == null)
            {
                return new ErrorDataResult<List<Color>>(data, Messages.ErrorListed);
            }
            return new SuccessDataResult<List<Color>>(data, Messages.SuccessListed);
        }

        public IDataResult<Color> GetById(int id)
        {
            var data = _colorDal.Get(x => x.ColorId == id);
            if (data == null)
            {
                return new ErrorDataResult<Color>(data, Messages.ErrorListed);
            }
            return new SuccessDataResult<Color>(data, Messages.SuccessListed);
        }
        #endregion
    }
}
