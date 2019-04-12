using System.Data;
using System.Diagnostics.CodeAnalysis;

namespace petclinicmicroservice.Helper
{
    public class DBTypeReaderFactory
    {
	    [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Straight forward mapping routine.")]
	    public static DbType GetDbType(string dataTypeName)
	    {
		    
		    switch (dataTypeName.ToLowerInvariant())
		    {
			    case "bit":
				    return DbType.Boolean;
			    case "tinyint":
				    return DbType.Byte;
			    case "date":
				    return DbType.Date;
			    case "datetime":
			    case "smalldatetime":
				    return DbType.DateTime;
			    case "datetime2":
				    return DbType.DateTime2;
			    case "time":
				    return DbType.Time;
			    case "decimal":
			    case "money":
			    case "numeric":
			    case "smallmoney":
				    return DbType.Decimal;
			    case "float":
				    return DbType.Double;
			    case "real":
				    return DbType.Single;
			    case "uniqueidentifier":
				    return DbType.Guid;
			    case "smallint":
				    return DbType.Int16;
			    case "int":
				    return DbType.Int32;
			    case "bigint":
				    return DbType.Int64;
			    case "char":
			    case "nchar":
			    case "ntext":
			    case "nvarchar":
			    case "text":
			    case "varchar":
				    return DbType.String;
			    default:
				    return DbType.Object;
		    }
	    }
	}
}
