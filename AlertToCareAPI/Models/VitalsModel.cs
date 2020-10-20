﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlertToCareAPI.Models
{
    [Owned]
    public class VitalsModel
    {
        public string Name { get; set; }
        public float Value { get; set; }
        public float LowerLimit { get; set; }
        public float UpperLimit { get; set; }
    }
}
