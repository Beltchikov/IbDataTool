﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IbDataTool.Model
{
    public class Batch
    {
        [Key]
        public Guid Id { get; set; }
        public Guid DataTransferId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string StartSymbol { get; set; }
        public string EndSymbol { get; set; }
    }
}
