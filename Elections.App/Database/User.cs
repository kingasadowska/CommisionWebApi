using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Elections.App.Database
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserPesel { get; set; }
        public int CandidatesId { get; set; }
        public Candidates Candidates { get; set; }
    }
}