using System;
using System.Collections.Generic;
using System.Text;

namespace callcenter.modal
{
    public class ResponseInfo
    {
        public bool IsError
        {
            get;
            set;
        }

        public string Message
        {
            get; set;
        }

        public ResponseInfo()
        {
            this.IsError = false;
            this.Message = null;
        }

        public ResponseInfo(bool isError, string message)
        {
            this.IsError = isError;
            this.Message = message;
        }
    }
}
