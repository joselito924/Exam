using System.ComponentModel.DataAnnotations;

namespace ExamModel
{
    public class tblGender
    {
        [Key]
        public int GenderId { get; set; }
        public string Gender { get; set; }
        public virtual ICollection<tblUserProfile> UserProfiles { get; set; }

    }
}
