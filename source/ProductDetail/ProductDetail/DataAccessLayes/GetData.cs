using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ProductDetail.Models;

namespace ProductDetail.DataAccessLayes
{
    public class GetData
    {
        public List<Productmodel> InsertRecord(Productmodel MODEL)
        {
            var result = new List<Productmodel>();
            if (MODEL == null)
            {
                return result;
            }
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(Startup.ConnectionString))
                {
                    string insertdata = string.Format("Insert Into Product (productID, ProductName, Price) Values('{0}', '{1}', '{2}')",MODEL.productID, MODEL.ProductName, MODEL.Price);
                    using (SqlCommand cmd = new SqlCommand(insertdata, sqlCon))
                    {
                        sqlCon.Open();
                        cmd.ExecuteNonQuery();
                        sqlCon.Close();
                    }

                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Product", sqlCon))
                    {
                        SqlDataAdapter da = new SqlDataAdapter();
                        DataSet ds = new DataSet();



                        sqlCon.Open();
                        DataTable dt = new DataTable();
                        dt.Load(cmd.ExecuteReader());
                        //da = new SqlDataAdapter(cmd);

                        //da.Fill(ds);

                      
                        result = FillModel(dt);
                        sqlCon.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return result;
        }

        List<Productmodel> FillModel(DataTable table)
        {
            try
            {
                List<Productmodel> modelobj = new List<Productmodel>();
               // foreach (DataTable table in ds.Tables)
                {
                    if (table.Rows.Count > 0)
                    {
                        foreach (DataRow Row in table.Rows)
                        {
                            modelobj.Add(ProductDetailsMapper(Row));
                        }
                    }
                }
                return modelobj;
            }
            catch (Exception ex)
            {
                return null;

            }

        }


         Productmodel ProductDetailsMapper(DataRow Row)
        {
            var ProductDetail = new Productmodel()
            {
                productID = Row.ItemArray[0].ToString(),
                ProductName = Row.ItemArray[1].ToString(),
                Price = Row.ItemArray[2].ToString(),

            };
            return ProductDetail;
        }
    }
}
