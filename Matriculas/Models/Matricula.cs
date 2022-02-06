using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Matriculas.Models
{
    public class Matricula
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal NumMatricula { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data atual ")]
        public DateTime Data { get; set; }

    }
}
