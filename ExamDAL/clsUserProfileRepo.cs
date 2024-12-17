using ExamModel;

namespace ExamDAL
{
    public class clsUserProfileRepo : clsRepository<tblUserProfile>, IUserProfileRepo
    {
        public clsUserProfileRepo(UserDBContext dbContext) : base(dbContext)
        {
        }
    }
}
