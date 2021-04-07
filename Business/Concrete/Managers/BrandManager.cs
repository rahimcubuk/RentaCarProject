using Business.Abstract.Services;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract.Dals;
using Entities.Concrete.Models;
using System.Collections.Generic;

namespace Business.Concrete.Managers
{
    public class BrandManager : IBrandService
    {
        #region Kurucu Metotlar
        private IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        #endregion

        #region Metotlar
        [SecuredOperation("admin")]
        [CacheRemoveAspect("BrandManager.Get")]
        public IResult Add(Brand entity)
        {
            _brandDal.Add(entity);
            return new SuccessResult(Messages.SuccessAdded);
        }

        [SecuredOperation("admin")]
        [CacheRemoveAspect("BrandManager.Get")]
        public IResult Delete(Brand entity)
        {
            _brandDal.Delete(entity);
            return new SuccessResult(Messages.SuccessDeleted);
        }

        [SecuredOperation("admin")]
        [CacheRemoveAspect("BrandManager.Get")]
        public IResult Update(Brand entity)
        {
            _brandDal.Update(entity);
            return new SuccessResult(Messages.SuccessUpdated);
        }

        [CacheAspect(duration: 10)]
        public IDataResult<List<Brand>> GetAll()
        {
            var data = _brandDal.GetAll();
            if (data == null)
            {
                return new ErrorDataResult<List<Brand>>(data, Messages.ErrorListed);
            }
            return new SuccessDataResult<List<Brand>>(data, Messages.SuccessListed);
        }

        public IDataResult<Brand> GetById(int id)
        {
            var data = _brandDal.Get(x => x.BrandId == id);
            if (data == null)
            {
                return new ErrorDataResult<Brand>(data, Messages.ErrorListed);
            }
            return new SuccessDataResult<Brand>(data, Messages.SuccessListed);
        }
        #endregion
    }
}
