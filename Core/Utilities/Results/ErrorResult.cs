using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorResult : Result
    {
        public ErrorResult(string message = null) : base(false, message)
        {
        }
        public ErrorResult() : base(false)
        {

        }
    }
}
