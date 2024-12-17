using ExamModel;

namespace ExamDAL
{
    public class clsGenderRepo : clsRepository<tblGender>, IGenderRepo
    {
        public clsGenderRepo(UserDBContext dbContext) : base(dbContext)
        {
        }
    }
}
