using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication20201025.Models
{
    [MetadataType(typeof(CustomerMetadata))]
    public partial class Customer
    {
        private class CustomerMetadata
        {
            [JsonIgnore]
            public virtual ICollection<Order> Orders { get; set; }

            [JsonIgnore]
            public virtual ICollection<CustomerDemographic> CustomerDemographics { get; set; }
        }
    }

    [MetadataType(typeof(OrderMetadata))]
    public partial class Order
    {
        private class OrderMetadata
        {
            [JsonIgnore]
            public virtual Customer Customer { get; set; }

            [JsonIgnore]
            public virtual CustomerDemographic CustomerDemographics { get; set; }

            [JsonIgnore]
            public virtual Employee Employee { get; set; }

            [JsonIgnore]
            public virtual ICollection<Order_Detail> Order_Details { get; set; }

            [JsonIgnore]
            public virtual Shipper Shipper { get; set; }
        }
    }

    [MetadataType(typeof(CustomerDemographicMetadata))]
    public partial class CustomerDemographic
    {
        private class CustomerDemographicMetadata
        {
            [JsonIgnore]
            public virtual ICollection<Customer> Customers { get; set; }
        }
    }
}