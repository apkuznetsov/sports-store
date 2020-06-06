using SportsStore.Domain.Entities;

namespace SportsStore.Webapp.Models
{
    public class CardIndexViewModel
    {
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}