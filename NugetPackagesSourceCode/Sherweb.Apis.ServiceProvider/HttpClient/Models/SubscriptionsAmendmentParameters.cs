// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Sherweb.Apis.ServiceProvider.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// List of subscription IDs to amend, paired with their intended new
    /// quantity.
    /// </summary>
    public partial class SubscriptionsAmendmentParameters
    {
        /// <summary>
        /// Initializes a new instance of the SubscriptionsAmendmentParameters
        /// class.
        /// </summary>
        public SubscriptionsAmendmentParameters()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the SubscriptionsAmendmentParameters
        /// class.
        /// </summary>
        public SubscriptionsAmendmentParameters(System.Guid subscriptionId, int newQuantity)
        {
            SubscriptionId = subscriptionId;
            NewQuantity = newQuantity;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "subscriptionId")]
        public System.Guid SubscriptionId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "newQuantity")]
        public int NewQuantity { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            //Nothing to validate
        }
    }
}
