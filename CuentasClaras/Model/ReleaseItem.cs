﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CuentasClaras.Model
{
    public class ReleaseItem
    {
        [Key]
        public int ReleaseItemId { get; set; }

        public string ExternalId { get; set; }
        public int UnitId { get; set; }
        public decimal UnitValueAmount { get; set; }
        public decimal UnitValueAmountUYU { get; set; }
        public decimal TotalAmountUYU { get; set; }
        public string UnitName { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        //FK
        public int? ReleaseItemClassificationId { get; set; }
        public ReleaseItemClassification ReleaseItemClassification { get; set; }
        public int ReleaseId { get; set; }
        public Release Release { get; set; }
        public string CurrencyCode { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
    }
}
