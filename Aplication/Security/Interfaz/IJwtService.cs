using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Security.Interfaz
{
    public interface IJwtService
    {
        string GenerateToken();
    }
}
