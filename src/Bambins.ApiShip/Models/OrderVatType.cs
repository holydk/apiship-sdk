namespace Bambins.ApiShip.Models
{
    /// <summary>
    /// Represents a order VAT type.
    /// </summary>
    public enum OrderVatType
    {
        /// <summary>
        /// Without VAT
        /// </summary>
        None = -1,

        /// <summary>
        /// VAT = 0%
        /// </summary>
        VAT0 = 0,

        /// <summary>
        /// VAT = 10%
        /// </summary>
        VAT10 = 10,

        /// <summary>
        /// VAT = 20%
        /// </summary>
        VAT20 = 20
    }
}