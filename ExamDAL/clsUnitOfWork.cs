namespace ExamDAL
{
    public class clsUnitOfWork : IUnitOfWork
    {
        UserDBContext _db;
        public clsUnitOfWork(UserDBContext userDBContext)
        {
            _db = userDBContext;
            GenderRepo = new clsGenderRepo(userDBContext);
            UserProfileRepo = new clsUserProfileRepo(userDBContext);
        }

        public IGenderRepo GenderRepo { get; private set; }

        public IUserProfileRepo UserProfileRepo { get; private set; }

        public void Complete() => _db.SaveChanges();
    }
}
