using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_framwork.Infrastructure
{
    public interface IPermissionsExposer
    {
        Dictionary<string, List<PermissionsDTO>> Expos();
    }
}