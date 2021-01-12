using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IbDataTool.Model
{
    public class NotUnique
    {
        [Key]
        public int Id { get; set; }

        public string Symbol { get; set; }

        public string Company { get; set; }
    }
}
