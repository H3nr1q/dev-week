using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.Models
{
    public class Contract
    {
        public Contract()
        {
            this.dateCreation = DateTime.Now;
            this.value = 0;
            this.tokenId = "000000";
            this.pay = false;
        }

        public Contract(string tokenId, double value)
        {
         this.dateCreation = DateTime.Now;
         this.tokenId = tokenId;
         this.value = value;
         this.pay = false;
        }

        public int id { get; set; }
        public DateTime dateCreation { get; set; }       
        public string tokenId { get; set; }
        public double value { get; set; }
        public bool pay { get; set; }
        public int idPerson { get; set; }
    }
}