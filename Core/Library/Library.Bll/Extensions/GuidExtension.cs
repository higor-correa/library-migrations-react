using System;

namespace Library.Bll.Extensions
{
    public static class GuidExtension
    {
        public static bool IsEmpty(this Guid? guid)
        {
            return guid == null || guid.Value == Guid.Empty;
        }
    }
}
