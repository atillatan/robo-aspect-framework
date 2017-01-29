using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspectExample.ApplicationBuilder;

namespace AspectExample.Aspect
{
    public interface IAspect
    {
        void OnBefore(InvokeContext context);

        void OnAfter(InvokeContext context);
    }
}