using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspectExample.ApplicationBuilder
{
    public class InvokeResult
    {
        private object resultValue;

        public Type ResultType { get; private set; }

        public object Value { get; set; }

        public InvokeResult(Type resultType)
        {
            this.ResultType = resultType;
        }

        public InvokeResult(Type resultType, object resultValue)
        {
            this.ResultType = resultType;
            this.resultValue = resultValue;
        }
    }
}