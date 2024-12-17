namespace ExamDAL
{
    public interface IUnitOfWork
    {
        IGenderRepo GenderRepo { get; }
        IUserProfileRepo UserProfileRepo { get; }
        void Complete();
    }
}