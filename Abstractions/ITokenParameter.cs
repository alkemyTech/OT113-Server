using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstractions
{
    public interface ITokenParameter
    {
        string Email { get; set; }
        string Password { get; set; }
        string Role { get; set; }
    }
}
