using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Elections.App.Database
{
    public class Candidates
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string CandidateFirstName { get; set; }
        public string CandidateLastName { get; set; }
        public ICollection<User> Users { get; set; } = new List<User>();
    }
}