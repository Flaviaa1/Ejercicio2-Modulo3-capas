﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace EjercicioModulo3Clase2.Domain.Entity
{
    public partial class Tasks
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string DueDate { get; set; }
        public bool? IsCompleted { get; set; }
        public bool? IsActive { get; set; }
    }
}