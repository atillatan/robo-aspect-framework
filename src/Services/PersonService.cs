using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AspectExample.Aspect.Attributes;

namespace AspectExample.Services
{
    public class PersonService : BaseService, IPersonService
    {
        [Cache]
        [Log]
        public virtual string Method1(int x)
        {
            return $"input is {x}";
        }
    }
}