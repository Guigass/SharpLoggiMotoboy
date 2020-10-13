using System;
using System.Collections.Generic;
using System.Text;

namespace LoggiMotoboy.API.Models
{
    public class CreateOrderInquiryClass
    {
        public CreateOrderInquiry createOrderInquiry { get; set; }
    }

    public class Inquiry
    {
        public string pk { get; set; }
        public Pricing pricing { get; set; }
        public int numWaypoints { get; set; }
        public string productDescription { get; set; }
        public object paymentMethod { get; set; }
    }

    public class CreateOrderInquiry
    {
        public bool success { get; set; }
        public Inquiry inquiry { get; set; }
        public List<object> errors { get; set; }
    }
}
