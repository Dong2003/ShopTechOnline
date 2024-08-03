using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace ShopTechOnline.Models.Common
{
    public class ThongKeTruyCap
    {
        public static string Connection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();

        public static ThongKeViewModel ThongKe()
        {
            using ( var connect = new SqlConnection(Connection))
            {
                var item = connect.QueryFirstOrDefault<ThongKeViewModel>("ThongKe", commandType: CommandType.StoredProcedure);
                return item;
            }
        }
    }
}