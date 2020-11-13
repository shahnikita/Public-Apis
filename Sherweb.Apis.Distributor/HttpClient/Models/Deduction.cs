// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Sherweb.Apis.Distributor.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Deduction applied to a charge.
    /// </summary>
    public partial class Deduction
    {
        /// <summary>
        /// Initializes a new instance of the Deduction class.
        /// </summary>
        public Deduction()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the Deduction class.
        /// </summary>
        /// <param name="deductionType">Possible values include:
        /// 'PromotionalMoney', 'PromotionalPercentage',
        /// 'PerformancePercentage'</param>
        /// <param name="unitValue">Deduction value prorated per unit.</param>
        /// <param name="totalValue">Deduction value for line (unitValue *
        /// quantity).</param>
        public Deduction(string code = default(string), string name = default(string), string deductionType = default(string), double? value = default(double?), double? unitValue = default(double?), double? totalValue = default(double?))
        {
            Code = code;
            Name = name;
            DeductionType = deductionType;
            Value = value;
            UnitValue = unitValue;
            TotalValue = totalValue;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "code")]
        public string Code { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets possible values include: 'PromotionalMoney',
        /// 'PromotionalPercentage', 'PerformancePercentage'
        /// </summary>
        [JsonProperty(PropertyName = "deductionType")]
        public string DeductionType { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public double? Value { get; set; }

        /// <summary>
        /// Gets or sets deduction value prorated per unit.
        /// </summary>
        [JsonProperty(PropertyName = "unitValue")]
        public double? UnitValue { get; set; }

        /// <summary>
        /// Gets or sets deduction value for line (unitValue * quantity).
        /// </summary>
        [JsonProperty(PropertyName = "totalValue")]
        public double? TotalValue { get; set; }

    }
}
