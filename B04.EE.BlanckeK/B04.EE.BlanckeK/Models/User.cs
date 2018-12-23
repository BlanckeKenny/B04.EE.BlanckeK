using System;
using SQLite;

namespace B04.EE.BlanckeK.Models
{
    public class User
    {
        [PrimaryKey]
        public Guid UserId { get; set; }

        public int Score { get; set; }
        public int Level { get; set; }

        [NotNull, MaxLength(50)]
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
