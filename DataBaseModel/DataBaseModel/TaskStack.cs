//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataBaseModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class TaskStack
    {
        public decimal SolderID { get; set; }
        public int DateID { get; set; }
        public System.Data.Entity.Spatial.DbGeography Location { get; set; }
        public int Pulse { get; set; }
        public int BulletProofVestState { get; set; }
        public int FlickerEyes { get; set; }
        public int Ammunittions { get; set; }
        public double TemperatureBarell { get; set; }
        public int WeatherID { get; set; }
    
        public virtual TaskStack TaskStack1 { get; set; }
        public virtual TaskStack TaskStack2 { get; set; }
        public virtual Weather Weather { get; set; }
    }
}
