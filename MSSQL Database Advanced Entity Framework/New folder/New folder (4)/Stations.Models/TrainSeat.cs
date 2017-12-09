﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Stations.Models
{
    public class TrainSeat
    {
        public int Id { get; set; }
        public int TrainId { get; set; }
        public Train Train { get; set; }
        public int SeatingClassId { get; set; }
        public SeatingClass SeatingClass { get; set; }
        [Range(1,int.MaxValue)]
        public int Quantity { get; set; }
    }
}
