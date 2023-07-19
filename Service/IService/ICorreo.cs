using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Service.IService
{
    public interface ICorreo
    {
        void SendEmail(Activo_Empleado activo_Empleado, ClaimsIdentity claimsIdentity);

    }
}
