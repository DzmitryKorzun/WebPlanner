﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebPlanner.Domain.Entity.GeneralModels;

namespace WebPlanner.Domain.Entity.ItemModels
{
    public class Tablet
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        [ForeignKey("IdManufactorer")]
        public int IdManufactorer { get; set; }
        public DateTime MarketDate { get; set; }
        public int Diagonal { get; set; }
        public string? Resolurion { get; set; }
        public int RAM { get; set; }
        public int Built_in_memory { get; set; }
        [ForeignKey("Id_OS")]
        public int Id_OS { get; set; }
        public int BatteryCapacity { get; set; }
        public int SIM_Card_amount { get; set; }
        [ForeignKey("Id_ScreenType")]
        public int Id_ScreenType { get; set; }
        [ForeignKey("Id_Color")]
        public int Id_Color { get; set; }
        [ForeignKey("Id_Material")]
        public int Id_Material { get; set; }
        public Manufacturer? Manufacturer { get; set;}
        public GeneralModels.OperatingSystem? OperatingSystem { get; set; }
        public ScreenType? ScreenType { get; set; }
        public Color? Color { get; set; }
        public Materials? Materials { get; set; }
    }
}
