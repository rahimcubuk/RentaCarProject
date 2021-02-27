using Core.Utilities.Results.Abstract;

namespace Core.Utilities.Results.Concrete
{
    public class DataResult<TData> : Result, Abstract.IDataResult<TData>
    {
        #region KurucuMetotlar
        public DataResult(TData data, bool success, string message) : base(success, message)
        {
            Data = data;
        }

        public DataResult(TData data, bool success) : base(success)
        {
            Data = data;
        }
        #endregion

        #region Imp
        public TData Data { get; }
        #endregion
    }
}
