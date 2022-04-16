using CRUDSuperHeroisAPI.Domain.Models;
using DomainValidationCore.Validation;
using System.Collections.Generic;

namespace CRUDSuperHeroisAPI.Domain.Services
{
    public class NotificationService
    {
        public List<DomainNotification> DomainNotifications { get; set; }

        public NotificationService()
        {
            DomainNotifications = new List<DomainNotification>();
        }

        public void AdicionarNotificacao(string notificacao)
        {
            DomainNotifications.Add(new DomainNotification(notificacao));
        }

        public void AdicionarNotificacoes(ValidationResult validationResult)
        {
            foreach (var erro in validationResult.Errors)
            {
                AdicionarNotificacao(erro.Message);
            }
        }
    }
}
