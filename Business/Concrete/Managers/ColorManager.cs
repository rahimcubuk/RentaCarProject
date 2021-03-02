using Business.Abstract.Services;
using Business.Constants;
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
        public IResult Add(Color entity)
        {
            _colorDal.Add(entity);
            return new SuccessResult(Messages.SuccessAdded);
        }

        public IResult Delete(Color entity)
        {
            _colorDal.Delete(entity);
            return new SuccessResult(Messages.SuccessDeleted);
        }

        public IResult Update(Color entity)
        {
            _colorDal.Update(entity);
            return new SuccessResult(Messages.SuccessUpdated);
        }

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
