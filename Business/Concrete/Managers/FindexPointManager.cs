using Business.Abstract.Services;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract.Dals;
using Entities.Concrete.Models;
using System.Collections.Generic;

namespace Business.Concrete.Managers
{
    public class FindexPointManager : IFindexPointService
    {
        private IFindexPointDal _findexPointDal;
        public FindexPointManager(IFindexPointDal findexPointDal)
        {
            _findexPointDal = findexPointDal;
        }

        public IResult Add(UserFindexPoint entity)
        {
            _findexPointDal.Add(entity);
            return new SuccessResult(Messages.SuccessAdded);
        }

        public IResult Delete(UserFindexPoint entity)
        {
            _findexPointDal.Delete(entity);
            return new SuccessResult(Messages.SuccessDeleted);
        }

        public IDataResult<List<UserFindexPoint>> GetAll()
        {
            var data = _findexPointDal.GetAll();
            if (data is null) return new ErrorDataResult<List<UserFindexPoint>>(data, Messages.ErrorListed);
            return new SuccessDataResult<List<UserFindexPoint>>(data, Messages.SuccessListed);
        }

        public IDataResult<UserFindexPoint> GetById(int id)
        {
            var data = _findexPointDal.Get(x => x.CardId == id);
            if (data is null) return new ErrorDataResult<UserFindexPoint>(data, Messages.NotFoundCreditCard);
            return new SuccessDataResult<UserFindexPoint>(data, Messages.SuccessPay);
        }

        public IResult Update(UserFindexPoint entity)
        {
            _findexPointDal.Update(entity);
            return new SuccessResult(Messages.SuccessUpdated);
        }
    }
}
