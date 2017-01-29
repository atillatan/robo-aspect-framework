using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspectExample.ApplicationBuilder;

namespace AspectExample.Aspect.Attributes
{
    public class CacheAttribute : AspectBase, IAspect
    {
        public int DurationInMinute { get; set; }

        public void OnBefore(InvokeContext context)
        {
            Console.WriteLine("CacheAttrubute.OnBefore() invoked...");
        }

        public void OnAfter(InvokeContext context)
        {
            Console.WriteLine("CacheAttrubute.OnAfter() invoked...");
        }
    }
}