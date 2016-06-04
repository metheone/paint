using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint.Data.Common
{
    public static partial class ExtensionMethods
    {
        /// <summary>
        /// This method extends the GetBoolean method of the data reader to allow calling by the field name
        /// </summary>
        /// <param name="dataReader">The datareader object we are extending</param>
        /// <param name="fieldName">The field name that we are getting the Boolean value for</param>
        /// <returns></returns>
        public static bool GetBoolean(this IDataReader dataReader, string fieldName)
        {
            var fieldOrdinal = dataReader.GetOrdinal(fieldName);
            var retVal = false;

            if (!dataReader.IsDBNull(fieldOrdinal))
            {
                try
                {
                    retVal = dataReader.GetBoolean(fieldOrdinal);
                }
                catch (InvalidCastException)
                {
                    //We will swallow this exception as it's expected if our value has a dataType of bit. 
                    //We will try and handle that by casting to an Int16.
                    //If it fails here, we will allow the exception to get thrown
                    return (dataReader.GetInt16(fieldOrdinal) == 1);
                }

            }

            return retVal;
        }

        /// <summary>
        /// This method extends the GetBoolean method of the data reader to allow calling by the field name
        /// </summary>
        /// <param name="dataReader">The datareader object we are extending</param>
        /// <param name="fieldName">The field name that we are getting the Int64 value for</param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static bool? GetNullableBoolean(this IDataReader dataReader, string fieldName)
        {
            var fieldOrdinal = dataReader.GetOrdinal(fieldName);
            return dataReader.IsDBNull(fieldOrdinal) ? new Nullable<bool>() : dataReader.GetBoolean(fieldOrdinal);
        }

        /// <summary>
        /// This method extends the GetDateTime method of the data reader to allow calling by the field name
        /// </summary>
        /// <param name="dataReader">The datareader object we are extending</param>
        /// <param name="fieldName">The field name that we are getting the DateTime value for</param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static DateTime GetDateTime(this IDataReader dataReader, string fieldName, DateTime defaultValue = default(DateTime))
        {
            var fieldOrdinal = dataReader.GetOrdinal(fieldName);
            return dataReader.IsDBNull(fieldOrdinal) ? defaultValue : dataReader.GetDateTime(fieldOrdinal);
        }

        /// <summary>
        /// This method extends the GetDateTime method of the data reader to allow calling by the field name
        /// </summary>
        /// <param name="dataReader">The datareader object we are extending</param>
        /// <param name="fieldName">The field name that we are getting the DateTime value for</param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static DateTime? GetNullableDateTime(this IDataReader dataReader, string fieldName)
        {
            var fieldOrdinal = dataReader.GetOrdinal(fieldName);
            return dataReader.IsDBNull(fieldOrdinal) ? new Nullable<DateTime>() : dataReader.GetDateTime(fieldOrdinal);
        }

        /// <summary>
        /// This method extends the GetDecimal method of the data reader to allow calling by the field name
        /// </summary>
        /// <param name="dataReader">The datareader object we are extending</param>
        /// <param name="fieldName">The field name that we are getting the Decimal value for</param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static Decimal GetDecimal(this IDataReader dataReader, string fieldName, Decimal defaultValue = 0m)
        {
            var fieldOrdinal = dataReader.GetOrdinal(fieldName);
            return dataReader.IsDBNull(fieldOrdinal) ? defaultValue : Convert.ToDecimal(dataReader.GetValue(fieldOrdinal));
        }

        /// <summary>
        /// This method extends the GetDouble method of the data reader to allow calling by the field name
        /// </summary>
        /// <param name="dataReader">The datareader object we are extending</param>
        /// <param name="fieldName">The field name that we are getting the Double value for</param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static double GetDouble(this IDataReader dataReader, string fieldName, double defaultValue = 0d)
        {
            var fieldOrdinal = dataReader.GetOrdinal(fieldName);
            return dataReader.IsDBNull(fieldOrdinal) ? defaultValue : dataReader.GetDouble(fieldOrdinal);
        }

        /// <summary>
        /// This method extends the GetFloat method of the data reader to allow calling by the field name
        /// </summary>
        /// <param name="dataReader">The datareader object we are extending</param>
        /// <param name="fieldName">The field name that we are getting the Float value for</param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static float GetFloat(this IDataReader dataReader, string fieldName, float defaultValue = 0f)
        {
            var fieldOrdinal = dataReader.GetOrdinal(fieldName);
            return dataReader.IsDBNull(fieldOrdinal) ? defaultValue : dataReader.GetFloat(fieldOrdinal);
        }

        /// <summary>
        /// This method extends the GetGuid method of the data reader to allow calling by the field name
        /// </summary>
        /// <param name="dataReader">The datareader object we are extending</param>
        /// <param name="fieldName">The field name that we are getting the Guid value for</param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static Guid GetGuid(this IDataReader dataReader, string fieldName, Guid defaultValue = default(Guid))
        {
            var fieldOrdinal = dataReader.GetOrdinal(fieldName);
            return dataReader.IsDBNull(fieldOrdinal) ? defaultValue : dataReader.GetGuid(fieldOrdinal);
        }

        /// <summary>
        /// This method extends the GetInt16 method of the data reader to allow calling by the field name
        /// </summary>
        /// <param name="dataReader">The datareader object we are extending</param>
        /// <param name="fieldName">The field name that we are getting the Int16 value for</param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static Int16 GetInt16(this IDataReader dataReader, string fieldName, Int16 defaultValue)
        {
            var fieldOrdinal = dataReader.GetOrdinal(fieldName);
            return dataReader.IsDBNull(fieldOrdinal) ? defaultValue : dataReader.GetInt16(fieldOrdinal);
        }

        /// <summary>
        /// This method extends the GetInt32 method of the data reader to allow calling by the field name
        /// </summary>
        /// <param name="dataReader">The datareader object we are extending</param>
        /// <param name="fieldName">The field name that we are getting the Int32 value for</param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static Int32 GetInt32(this IDataReader dataReader, string fieldName, Int32 defaultValue = 0)
        {
            var fieldOrdinal = dataReader.GetOrdinal(fieldName);
            return dataReader.IsDBNull(fieldOrdinal) ? defaultValue : dataReader.GetInt32(fieldOrdinal);
        }

        /// <summary>
        /// This method extends the GetInt32 method of the data reader to allow calling by the field name
        /// </summary>
        /// <param name="dataReader">The datareader object we are extending</param>
        /// <param name="fieldName">The field name that we are getting the Int32 value for</param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static Int32? GetNullableInt32(this IDataReader dataReader, string fieldName)
        {
            var fieldOrdinal = dataReader.GetOrdinal(fieldName);
            return dataReader.IsDBNull(fieldOrdinal) ? new Nullable<Int32>() : dataReader.GetInt32(fieldOrdinal);
        }

        /// <summary>
        /// This method extends the GetInt64 method of the data reader to allow calling by the field name
        /// </summary>
        /// <param name="dataReader">The datareader object we are extending</param>
        /// <param name="fieldName">The field name that we are getting the Int64 value for</param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static Int64 GetInt64(this IDataReader dataReader, string fieldName, Int64 defaultValue = 0)
        {
            var fieldOrdinal = dataReader.GetOrdinal(fieldName);
            return dataReader.IsDBNull(fieldOrdinal) ? defaultValue : dataReader.GetInt64(fieldOrdinal);
        }

        /// <summary>
        /// This method extends the GetInt64 method of the data reader to allow calling by the field name
        /// </summary>
        /// <param name="dataReader">The datareader object we are extending</param>
        /// <param name="fieldName">The field name that we are getting the Int64 value for</param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static Int64? GetNullableInt64(this IDataReader dataReader, string fieldName)
        {
            var fieldOrdinal = dataReader.GetOrdinal(fieldName);
            return dataReader.IsDBNull(fieldOrdinal) ? new Nullable<Int64>() : dataReader.GetInt64(fieldOrdinal);
        }

        /// <summary>
        /// This method extends the GetString method of the data reader to allow calling by the field name
        /// </summary>
        /// <param name="dataReader">The datareader object we are extending</param>
        /// <param name="fieldName">The field name that we are getting the string value for</param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static string GetString(this IDataReader dataReader, string fieldName, string defaultValue = "")
        {
            var fieldOrdinal = dataReader.GetOrdinal(fieldName);
            return dataReader.IsDBNull(fieldOrdinal) ? defaultValue : dataReader.GetString(fieldOrdinal);
        }

        public static T GetValue<T>(this IDataReader dataReader, string fieldName)
        {
            var fieldOrdinal = dataReader.GetOrdinal(fieldName);
            var value = dataReader.GetValue(fieldOrdinal);

            if (value == DBNull.Value)
                return default(T);

            return (T)value;
        }

        public static void Assign(this DataRow dr, string fieldName, object value)
        {
            dr[fieldName] = (value == null || (value is string && string.IsNullOrEmpty((string)value))) ? DBNull.Value : value;
        }

        public static bool HasColumn(this IDataReader dr, string columnName)
        {
            for (int i = 0; i < dr.FieldCount; i++)
            {
                if (dr.GetName(i).Equals(columnName, StringComparison.InvariantCultureIgnoreCase))
                    return true;
            }
            return false;
        }

        public static TimeSpan? GetTimeSpan(this IDataReader dataReader, string fieldName, TimeSpan? defaultValue = null)
        {
            var fieldOrdinal = dataReader.GetOrdinal(fieldName);
            return dataReader.IsDBNull(fieldOrdinal) ? defaultValue : (TimeSpan)dataReader[fieldOrdinal];
        }
    }

}
