using System.ComponentModel.DataAnnotations;

namespace EshopApi.Data
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImgUri { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
    public class UpdateDescriptionDto
    {
        [MaxLength(10000, ErrorMessage = "Popis nesmí překročit 10000 znaků!")]
        public string Description { get; set; }
    }
}
