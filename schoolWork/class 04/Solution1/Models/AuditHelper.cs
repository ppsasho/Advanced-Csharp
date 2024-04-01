namespace Models
{
    public class AuditHelper<T> where T : BaseClass
    {
        public static T SetCreateParams(T obj, string employeeName)
        {
            obj.CreatedBy = employeeName;
            obj.CreatedAt = DateTime.Now;

            return obj;
        }
        public static T SetUpdateParams(T obj, string employeeName)
        {
            obj.UpdatedBy = employeeName;
            obj.CreatedAt = DateTime.Now;

            return obj;
        }

    }
}
