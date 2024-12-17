using System.ComponentModel.DataAnnotations;

namespace ExamModel
{
    public class UserProfileDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public string emailAddress { get; set; }
        public string gender { get; set; }
        public string birthDate { get; set; }
        public int age { get; set; }
    }

    public class UserProfileDTOAddUpdate
    {
        [Required]
        public string name { get; set; }
        [Required]
        public string emailAddress { get; set; }
        [Required]
        public string gender { get; set; }
        [Required]
        public string birthDate { get; set; }
    }


}
