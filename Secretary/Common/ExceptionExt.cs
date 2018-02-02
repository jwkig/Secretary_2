using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Secretary.Common
{
    public static class ExceptionExt
    {
        public static string GetSourceMessage(this Exception e)
        {
            if (e == null)
                return string.Empty;
            return e.InnerException != null ? e.InnerException.GetSourceMessage() : e.Message;
        }
    }
}
