namespace CGB004.Data.Code.Infra
{
    public interface IOraAccess
    {
        void BeginTransaction();
        void Commit();
        void Dispose();
        void Rollback();
    }
}
