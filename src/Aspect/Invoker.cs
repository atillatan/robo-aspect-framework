﻿using AspectExample.ApplicationBuilder;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

using AspectExample.Aspect;

namespace AspectExample.Aspect
{
    public static class Invoker
    {
        public static object Invoke(InvokeContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            Expression<Func<object>> _function = context.Request.Function;
            object _instance = context.Request.Instance;

            var timer = Stopwatch.StartNew();
            if (_instance == null) throw new Exception("Service is null!");
            var fbody = _function.Body as MethodCallExpression;
            if (fbody == null || fbody.Method == null) throw new Exception("Expression must be a method call.");
            string methodName = fbody.Method.Name;
            dynamic result = null;

            List<object> args = new List<object>();

            foreach (var argument in fbody.Arguments)
            {
                var constant = argument as ConstantExpression;
                if (constant != null)
                {
                    args.Add(constant.Value);
                }
            }

            object[] aspects = _instance.GetType().GetMethod(methodName).GetCustomAttributes(true);
        
            RunBeforeAspects(context, aspects);

            //if cache aspect or other aspects, returns response.
            if (context?.Result?.Value != null)
            {
                return context.Result.Value;
            }

            try
            {
                result = fbody.Method.Invoke(_instance, args.ToArray<object>());
                Type t = context.Result.ResultType;
                context.Result.Value = result;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                timer.Stop();
                Console.WriteLine($"{methodName}() method invoked in :{Convert.ToDouble(timer.ElapsedMilliseconds)}ms ");
            }

            RunAfterAspects(context, aspects);

            return result;
        }

        private static void RunBeforeAspects(InvokeContext context, object[] aspects)
        {
            foreach (var aspect in aspects)
            {
                if (aspect.GetType().GetTypeInfo().BaseType == typeof(AspectBase))
                {
                    ((IAspect)aspect).OnBefore(context);
                }
            }
        }

        private static void RunAfterAspects(InvokeContext context, object[] aspects)
        {
            foreach (var aspect in aspects)
            {
                if (aspect.GetType().GetTypeInfo().BaseType == typeof(AspectBase))
                {
                    ((IAspect)aspect).OnAfter(context);
                }
            }
        }
    }
}