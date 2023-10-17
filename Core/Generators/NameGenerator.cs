using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Generators
{
    public static class NameGenerator
    {
        public static string Generate()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }
    }
}
