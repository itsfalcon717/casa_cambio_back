using System.Net;
using System.Net.Mail;

namespace GestionProvedores.Services.Impl
{
    public class CorreoService:ICorreoService
    {
        public async Task<bool> enviar(List<string> correos, string titulo, string htmlTemplate, List<(string archivo, string archivo64, string tipo)> archivos)
        {
            // Configuración del cliente SMTP

            var smtpClient = new SmtpClient("smtp.office365.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("cespinoza@grupoebim.com", "Y!901879999467oy"),
                EnableSsl = true,
            };

            // Crear el mensaje de correo
            var mailMessage = new MailMessage
            {
                From = new MailAddress("cespinoza@grupoebim.com"),
                Subject = titulo,
                Body = htmlTemplate,
                IsBodyHtml = true // Habilitar HTML en el cuerpo del correo
            };

            foreach (var correo in correos)
            {
                mailMessage.To.Add(correo);
            }
            if (archivos != null) 
            foreach (var archivo in archivos)
            {
                try
                {
                    byte[] fileBytes = Convert.FromBase64String(archivo.archivo64);
                    MemoryStream stream = new MemoryStream(fileBytes);

                    var mailAttachment = new Attachment(stream, archivo.archivo, archivo.tipo);
                    mailMessage.Attachments.Add(mailAttachment);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"Error al decodificar el archivo {archivo.archivo}: {ex.Message}");
                }
            }
            try
            {
                // Enviar el correo de forma asíncrona
                await smtpClient.SendMailAsync(mailMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al enviar el correo: {ex.Message}");
                return false;
            }
            return true;
        }
    }
}
