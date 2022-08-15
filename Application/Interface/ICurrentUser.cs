using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface ICurrentUser
    {
        string UserId { get; }
        string FullName { get; } 
    }
}
