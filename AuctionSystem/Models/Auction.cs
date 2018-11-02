using System;
using System.ComponentModel.DataAnnotations;

namespace AuctionSystem.Models
{
    public class Auction
    {
        public int AuctionID { get; set; }
        public int CategoryID { get; set; }
        public int AuctionOwnerID { get; set; }

        [Required(ErrorMessage ="Wprowadź nazwę aukcji")]
        [StringLength(100)]
        public string AuctionTitle { get; set; }
        public string AuctionDescription { get; set; }
        public DateTime AuctionDateAdd { get; set; }
        public decimal AuctionPrice { get; set; }
        public bool Hidden { get; set; }
        public string AuctionShortDesc { get; set; }

        public virtual Category Category { get; set; }
    }
}