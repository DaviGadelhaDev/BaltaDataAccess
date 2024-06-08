using System;
using System.Collections.Generic;

namespace BaltaDataAccess.Models
{
    public class Career
    {
        public Career()
        {
            //Iniciar para não ter risco de vir nulo
            CareerItems = new List<CareerItem>();
        }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public IList<CareerItem> CareerItems { get; set; }
    }
}