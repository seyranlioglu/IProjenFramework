using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IProjenFramework.Core.ExpressionBuilder.Helpers
{
    public class TypeofReferences<T> where T : class
    {
        public static Dictionary<string, string> GetAllTypeofReference()
        {
            Dictionary<string, string>  keys = new Dictionary<string, string>();
            foreach (var item in typeof(T).GetProperties().Where(k => k.PropertyType.Name == "String"))
            {
                keys.Add(item.Name, item.GetType().Name);
            }
            return keys;
        }

        public static Type GetType(string name)
        {
            var model = typeof(T).GetProperties().Where(k => k.Name == name).FirstOrDefault();
            var nullableType = Nullable.GetUnderlyingType(model.PropertyType);

            bool isNullableType = nullableType != null;

            if (isNullableType)
                return nullableType;
            else
                return model.PropertyType;
        }
    }
}