using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AspectExample.Services
{
    public static class ServiceExtension
    {
        public static Task<TResult> InvokeAsync<TResult>(this BaseService instance, Expression<Func<object>> function) where TResult : class
        {
            return Task.Run(() => Application.Invoke<TResult>(function, instance));
        }

        public static TResult Invoke<TResult>(this BaseService instance, Expression<Func<object>> function) where TResult : class
        {
            return Application.Invoke<TResult>(function, instance);
        }

        public static object Invoke(this BaseService instance, Expression<Func<object>> function)
        {
            return Application.Invoke<object>(function, instance);
        }
    }
}