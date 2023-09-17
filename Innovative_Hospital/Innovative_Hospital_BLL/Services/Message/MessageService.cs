using Innovative_Hospital_BLL.ViewModels.Discharge;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Innovative_Hospital_BLL.Services.Message
{
    /// <summary>
    /// Сервис Email рассылки
    /// </summary>
    public class MessageService : IMessageService
    {
        private readonly string _email;
        private readonly SmtpClient _client;

        public MessageService()
        {
            _email = "innovative.hospital.it.academy@gmail.com";
            _client = new SmtpClient("smtp.gmail.com")
            {
                Credentials = new NetworkCredential(_email, "edbugeszbqxzxvdf"),          //"dfqywudchtbhpyxw"
                EnableSsl = true,
                Port = 587
            };
        }

        /// <summary>
        /// Метод отправки сообщения на Email
        /// </summary>
        /// <param name="recipient">Получатель</param>
        /// <param name="subject">Тема сообщения</param>
        /// <param name="body">Тело письма</param>
        public async Task SendAsync(string recipient, string subject, string body)
        {
            await _client.SendMailAsync(_email, recipient, subject, body);
        }

        public async Task SendDischarge(PatientDischargeVM model)
        {
            var message = new MailMessage
            {
                From = new MailAddress(_email),
                Subject = $"Уважаемый-{model.FullNamePatient} успешным вас выздоровлением,никогда не болейте(хотя не болейте,тогда мы хоть что то будем зарабатывать) ",
                Body = $"Справка на работу\nПациент:{model.FullNamePatient} находился в больнице п период с {model.ArrivalDate} по {model.DateOfDischarge}.\nДоктор - {model.FullNameDoctor}.Официальная справка от InnovativeHospital"
            };
            message.To.Add(model.PatietEmail);
            await _client.SendMailAsync(message);
        }

        /// <summary>
        /// Метод отправки сообщения приветствия при создании клиента
        /// </summary>
        /// <param name="recipient">Получатель</param>
        /// <param name="fullName">Имя получателя</param>
        public async Task SendWelcomeAsync(string recipient, string fullName,string password)
        {
            string subject = $"Добро пожаловать, {fullName}!";
            var message = new MailMessage
            {
                From = new MailAddress(_email),
                Subject = subject,
                Body = $"Поздравляем вас с тем что вы стали частью нашей больницы,мы рады вас приветсвовать.Готовьтесь получать много классных уведомлений. \nВас приветсвует больница IHospital.\nВаш пароль-{password},входите с почтой:{recipient}",               
             };
            message.To.Add(recipient);

            await _client.SendMailAsync(message);
        }
       
    }
}
