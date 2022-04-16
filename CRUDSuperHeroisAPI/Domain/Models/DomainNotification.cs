namespace CRUDSuperHeroisAPI.Domain.Models
{
    public class DomainNotification
    {
        public string ErrorMessage { get; set; }

        public DomainNotification(string erro)
        {
            ErrorMessage = erro;
        }
    }
}
