using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspectExample.ApplicationBuilder;

namespace AspectExample.Aspect.Attributes
{
    public class LogAttribute : AspectBase, IAspect
    {
        public int DurationInMinute { get; set; }

        public void OnBefore(InvokeContext context)
        {
            Console.WriteLine("LogAttribute.OnBefore() invoked...");
        }

        public void OnAfter(InvokeContext context)
        {
            Console.WriteLine("LogAttribute.OnAfter() invoked...");
        }
    }
}