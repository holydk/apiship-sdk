using System;
using System.Collections.Generic;

namespace Bambins.ApiShip.Models
{
    /// <summary>
    /// Represents a model for the tariffs calculation.
    /// </summary>
    public class CalculatorRequest
    {
        #region Properties

        /// <summary>
        /// Gets or sets the estimated cost (in rubles).
        /// </summary>
        public decimal AssessedCost { get; set; }

        /// <summary>
        /// Gets or sets the cash on delivery amount (in rubles).
        /// </summary>
        public decimal? CodCost { get; set; }

        /// <summary>
        /// Gets or sets the custom field. In this field, you can pass, for example, the name of the site and use it to build rules in the site editor.
        /// </summary>
        public string CustomCode { get; set; }

        /// <summary>
        /// Gets or sets the delivery types.
        /// </summary>
        public int[] DeliveryTypes { get; set; }

        /// <summary>
        /// Gets or sets the extra params.
        /// </summary>
        public Dictionary<string, string> ExtraParams { get; set; }

        /// <summary>
        /// Gets or sets the sender.
        /// </summary>
        public CalculatorDirection From { get; set; }

        /// <summary>
        /// Gets or sets the value indicating whether to add to the total cost all the fees of the delivery service (insurance and commission for cash on delivery).
        /// </summary>
        public bool? IncludeFees { get; set; }

        /// <summary>
        /// Gets or sets the date of receipt of the cargo (optional, by default the current date is taken)
        /// </summary>
        public DateTime? PickupDate { get; set; }

        /// <summary>
        /// Gets or sets the pickup types.
        /// </summary>
        public int[] PickupTypes { get; set; }

        /// <summary>
        /// Gets or sets the places.
        /// </summary>
        public CalculatorPlace[] Places { get; set; }

        /// <summary>
        /// Gets or sets the promo code. In the rate editor, you can specify a promotional code by which you can change rates, for example, a discount on shipping costs.
        /// </summary>
        public string PromoCode { get; set; }

        /// <summary>
        /// Gets or sets the provider keys.
        /// </summary>
        public string[] ProviderKeys { get; set; }

        /// <summary>
        /// Gets or sets the value indicating whether to skips application of rate editor rules. Useful if you need to check the correctness of applying the rules.
        /// </summary>
        public bool? SkipTariffRules { get; set; }

        /// <summary>
        /// Gets or sets the waiting time for a response (in milliseconds) from the provider, the results for providers that did not have time at the specified time will not be issued.
        /// </summary>
        public int? Timeout { get; set; }

        /// <summary>
        /// Gets or sets the recipient.
        /// </summary>
        public CalculatorDirection To { get; set; }

        #endregion Properties
    }
}