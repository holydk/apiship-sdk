﻿using System;

namespace Bambins.ApiShip.Models
{
    /// <summary>
    /// Represents the place model for the tariffs calculation.
    /// </summary>
    public class CalculatorPlace
    {
        #region Properties

        /// <summary>
        /// Gets or sets the unit height in centimeters.
        /// </summary>
        public decimal? Height { get; set; }

        /// <summary>
        /// Gets or sets the unit length in centimeters.
        /// </summary>
        public decimal? Length { get; set; }

        /// <summary>
        /// Gets or sets the unit weight in grams.
        /// </summary>
        public decimal? Weight { get; set; }

        /// <summary>
        /// Gets or sets the width of a unit of goods in centimeters.
        /// </summary>
        public decimal? Width { get; set; }

        #endregion Properties
    }
}