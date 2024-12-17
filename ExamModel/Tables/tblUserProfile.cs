using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamModel
{
    public class tblUserProfile
    {
        [Key]
        public int UserProfileId { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public int GenderId { get; set; }
        public DateTime BirthDate { get; set; }
        [NotMapped]
        public int Age
        {
            get
            {
                var today = DateTime.Today;
                var age = today.Year - BirthDate.Year;
                return age;
            }
        }

        public virtual tblGender Gender { get; set; }


    }
}
