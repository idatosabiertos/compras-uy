﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CuentasClaras.Model
{
    public class Currency
    {
        public string CurrencyCode { get; set; }
        public int Year { get; set; }
        public decimal ConversionFactorUYU { get; set; }
    }
}
