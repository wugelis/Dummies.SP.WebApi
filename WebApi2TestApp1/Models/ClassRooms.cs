namespace WebApi2TestApp1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ClassRooms
    {
        public int id { get; set; }

        [Required]
        [StringLength(10)]
        public string ClassRoomId { get; set; }

        [Required]
        [StringLength(200)]
        public string ClassRoomName { get; set; }

        public int ClassFloor { get; set; }

        public int NumOfPeoples { get; set; }

        public int BuildingId { get; set; }
    }
}
