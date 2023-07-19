using MimeKit;
using MailKit.Net.Smtp;
using Domain;
using Service.IService;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace Service.Service.Correo
{
    public class CorreoService: ICorreo
    {
        private readonly IAsset _assetService;
        private readonly IEmploye _employeService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CorreoService(IAsset asset, IEmploye employe, IHttpContextAccessor httpContextAccessor)
        {
            _assetService = asset;
            _employeService = employe;
            _httpContextAccessor = httpContextAccessor;

        }
        public void SendEmail(Activo_Empleado activoEmpleado, ClaimsIdentity claimsIdentity)
        {
            Empleado empleado = _employeService.GetEmploye(activoEmpleado.Id_Empleado);
            Activo activo = _assetService.GetAsset(activoEmpleado.Id_Activo);
            var nombreUsuario = _httpContextAccessor.HttpContext?.User?.Identity?.Name;
            var passwordClaim = claimsIdentity?.FindFirst("Password");
            var clave = passwordClaim?.Value ?? "YourSecurePassword";

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(nombreUsuario, nombreUsuario));
            message.To.Add(new MailboxAddress(empleado.Email, empleado.Email));
            message.Subject = "Asset Assignment Notification";

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = $"<p>Hello {empleado.Nombre},</p>" +
                                   $"<p>You have been assigned the following asset:</p>" +
                                   $"<ul>" +
                                   $"<li>Asset ID: {activo.Id}</li>" +
                                   $"<li>Asset Name: {activo.Nombre}</li>" +
                                   $"<li>Asset Description: {activo.Descripcion}</li>" +
                                   $"</ul>" +
                                   $"<p>Thank you!</p>";

            message.Body = bodyBuilder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                // Configure your SMTP server details here
                client.Connect("smtp-mail.outlook.com", 587, false);
                client.Authenticate(nombreUsuario, clave);
                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}