using Innovative_Hospital_BLL.ViewModels.Discharge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovative_Hospital_BLL.Services
{

    /// <summary>
    /// Сервис отправки Email сообщений
    /// </summary>
    public interface IMessageService
    {
        /// <summary>
        /// Метод отправки сообщения на Email
        /// </summary>
        /// <param name="recipient">Получатель</param>
        /// <param name="subject">Тема сообщения</param>
        /// <param name="body">Тело письма</param>
        public Task SendAsync(string recipient, string subject, string body);

        /// <summary>
        /// Метод отправки сообщения приветствия при создании пациента
        /// </summary>
        /// <param name="recipient">Получатель</param>
        /// <param name="fullName">Имя получателя</param>
        public Task SendWelcomeAsync(string recipient, string fullName,string password);

        public Task SendDischarge(PatientDischargeVM model);
    }
}
