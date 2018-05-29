using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class TramLocation : IBaseEntity
    {
        [Key]
        [Column(Order = 0)]
        public int Id { get; set; }

        [Column(Order = 1)]
        public string Status { get; set; }

        [Column(Order = 2)]
        public string FirstLine { get; set; }

        [Column(Order = 3)]
        public double Lon { get; set; }

        [Column(Order = 4)]
        public string Lines { get; set; }

        [Column(Order = 5)]
        public DateTime? Time { get; set; }

        [Column(Order = 6)]
        public double Lat { get; set; }

        [Column(Order = 7)]
        public bool LowFloor { get; set; }

        [Column(Order = 8)]
        public string Brigade { get; set; }
    }
}
