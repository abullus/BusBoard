using System;

namespace BusBoard.Web.ViewModels
{ 
    public class Error
    {
        public Error(Exception ex)
        {
            Exception = ex;
            Message = ex.Message;
        }
        public Exception Exception;
        public string Message;
    }
}