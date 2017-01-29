using AspectExample.ApplicationBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AspectExample.Aspect;

namespace AspectExample
{
    public class Application
    {
        #region Singleton Implementation

        private static Application _application = null;
        private static readonly object SyncRoot = new Object();

        private Application()
        {
        }

        public static Application Current
        {
            get
            {
                if (_application == null)
                {
                    lock (SyncRoot)
                    {
                        if (_application == null)
                            _application = new Application();
                    }
                }
                return _application;
            }
        }

        #endregion Singleton Implementation

        public static TResult Invoke<TResult>(Expression<Func<object>> function, object instance) where TResult : class
        {
            InvokeContext context = new InvokeContext(function, instance, typeof(TResult));
            var result = Invoker.Invoke(context);

            if (context?.Result?.Value.GetType() != typeof(TResult))
            {
                throw new ArgumentException("Given type mismatch with result type");
            }
            return context.Result.Value as TResult;
        }

        public static Task<TResult> InvokeAsync<TResult>(Expression<Func<object>> function, object instance) where TResult : class
        {
            return Task.Run(() => Application.Invoke<TResult>(function, instance));
        }
    }
}