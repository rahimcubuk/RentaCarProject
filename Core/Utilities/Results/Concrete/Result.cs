using Core.Utilities.Results.Abstract;

namespace Core.Utilities.Results.Concrete
{
    public class Result : IResult
    {
        #region KurucuMetotlar
        public Result(bool success, string message) : this(success)
        {
            Message = message;
        }

        public Result(bool success)
        {
            Success = success;
        }
        #endregion

        #region Imp
        public string Message { get; }
        public bool Success { get; }
        #endregion
    }
}
