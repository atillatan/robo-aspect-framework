using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AspectExample.ApplicationBuilder
{
    public class InvokeContext
    {
        public InvokeRequest Request { get; }
        public InvokeResult Result { get; }

        public InvokeContext(Expression<Func<object>> function, object instance, Type TResult)
        {
            this.Request = new InvokeRequest(function, instance);
            this.Result = new InvokeResult(TResult);
        }

        public InvokeContext(Expression<Func<object>> function, object instance, Type TResult, object resultValue)
        {
            this.Request = new InvokeRequest(function, instance);
            this.Result = new InvokeResult(TResult, resultValue);
            Properties = new Dictionary<string, object>();
        }

        public InvokeContext()
        {
            Properties = new Dictionary<string, object>();
        }

        public IDictionary<string, object> Properties { get; }

        private T GetProperty<T>(string key)
        {
            object value;
            return Properties.TryGetValue(key, out value) ? (T)value : default(T);
        }

        private void SetProperty<T>(string key, T value)
        {
            Properties[key] = value;
        }
    }
}