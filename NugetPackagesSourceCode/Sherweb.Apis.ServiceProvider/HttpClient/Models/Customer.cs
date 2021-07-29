// <auto-generated>
// This file was auto-generated
// </auto-generated>

namespace Sherweb.Apis.ServiceProvider.Models
{
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public partial class Customer
    {
        /// <summary>
        /// Initializes a new instance of the Customer class.
        /// </summary>
        public Customer()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the Customer class.
        /// </summary>
        /// <param name="suspendedOn">Format: yyyy-MM-ddTHH:mm:ss.fffffffK
        /// (UTC). Example : 2021-01-13T20:30:05.7613888</param>
        public Customer(System.Guid? id = default(System.Guid?), string displayName = default(string), IList<string> path = default(IList<string>), System.DateTime? suspendedOn = default(System.DateTime?))
        {
            Id = id;
            DisplayName = displayName;
            Path = path;
            SuspendedOn = suspendedOn;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public System.Guid? Id { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "displayName")]
        public string DisplayName { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "path")]
        public IList<string> Path { get; set; }

        /// <summary>
        /// Gets or sets format: yyyy-MM-ddTHH:mm:ss.fffffffK (UTC). Example :
        /// 2021-01-13T20:30:05.7613888
        /// </summary>
        [JsonProperty(PropertyName = "suspendedOn")]
        public System.DateTime? SuspendedOn { get; set; }

    }
}
