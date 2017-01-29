using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AspectExample.ApplicationBuilder
{
    public class InvokeRequest
    {
        public readonly Expression<Func<object>> Function;
        public readonly object Instance;

        public InvokeRequest(Expression<Func<object>> function, object instance)
        {
            this.Function = function;
            this.Instance = instance;
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