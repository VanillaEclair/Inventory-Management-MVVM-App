using Mei.Models;
using Mei.ViewModels;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Mei.Services
{
    public class SQLfunctions
    {
        private string connStr = "server=localhost;user=root;database=requiem;port=3306;password=root;";



        public List<MainWindowModel> DataQuery(string query)
        {
            var items = new List<MainWindowModel>();
            try
            {
                using(MySqlConnection conn = new MySqlConnection(connStr))
                {
                    string Query = query;
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand(Query, conn);

                    MySqlDataReader rdr = cmd.ExecuteReader();
                    

                    while (rdr.Read())
                    {
                        items.Add(new MainWindowModel
                        {
                            ItemID = rdr.IsDBNull("idItem") ? 0 : rdr.GetInt32("idItem"),
                            ItemName = rdr.IsDBNull("itemName") ? "" : rdr.GetString("itemName"),
                            ItemDescription = rdr.IsDBNull("ItemDesc") ? "" : rdr.GetString("ItemDesc"),
                            ItemCategory = rdr.IsDBNull("itemType") ? "" : rdr.GetString("itemType"),
                            ItemImg = rdr.IsDBNull("itemImg") ? "" : rdr.GetString("itemImg"),
                            ItemQty = rdr.IsDBNull("itemQty") ? 0 : rdr.GetInt32("itemQty")
                        });
                    }
                    rdr.Close();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            return items;

        }

        public void AddQuery(AddItem item)
        {
            try
            {
                using (MySqlConnection conn = new(connStr))
                {
                    string query = "INSERT INTO item (itemName, itemDesc, itemType, itemImg, itemQty) " +
                                   "VALUES (@itemName, @itemDesc, @itemType, 'Murder' , @itemQty)";

                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@itemName", item.ItemName);
                        cmd.Parameters.AddWithValue("@itemDesc", item.ItemDescription);
                        cmd.Parameters.AddWithValue("@itemType", item.ItemCategory);
                        cmd.Parameters.AddWithValue("@itemQty", item.ItemQuantity);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        //public void AddQuery(string itemName, string itemDesc, string itemType, string itemImg, string itemQty)
        //{
        //    try
        //    {
        //        using (MySqlConnection conn = new(connStr))
        //        {
        //            string query = "INSERT INTO item (itemName, itemDesc, itemType, itemImg, itemQty) " +
        //                           "VALUES (@itemName, @itemDesc, @itemType, @itemImg , @itemQty)";

        //            conn.Open();

        //            using (MySqlCommand cmd = new MySqlCommand(query, conn))
        //            {
        //                cmd.Parameters.AddWithValue("@itemName", itemName);
        //                cmd.Parameters.AddWithValue("@itemDesc", itemDesc);
        //                cmd.Parameters.AddWithValue("@itemType", itemType);
        //                cmd.Parameters.AddWithValue("@itemImg", itemImg);
        //                cmd.Parameters.AddWithValue("@itemQty", itemQty);

        //                cmd.ExecuteNonQuery();
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        public void DeleteQuery(int Id)
        {
            try
            {


                using (MySqlConnection conn = new(connStr))
                {
                    string query = $"DELETE FROM item WHERE idItem=@Id";

                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", Id);

                        cmd.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        public void UpdateQuery(AddItem item)
        {
            try
            {
                using (MySqlConnection conn = new(connStr))
                {
                    string query = @"
                                    UPDATE item
                                    SET itemName = @itemName,
                                        itemDesc = @itemDesc,
                                        itemType = @itemType,
                                        itemImg = 'Sample',
                                        itemQty = @itemQty
                                    WHERE idItem = @id;
                                ";


                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        MessageBox.Show(item.ItemCategory);

                        cmd.Parameters.AddWithValue("@itemName", item.ItemName);
                        cmd.Parameters.AddWithValue("@itemDesc", item.ItemDescription);
                        cmd.Parameters.AddWithValue("@itemType", item.ItemCategory);
                        //cmd.Parameters.AddWithValue("@itemImg", );
                        cmd.Parameters.AddWithValue("@itemQty", item.ItemQuantity);
                        cmd.Parameters.AddWithValue("@id", item.Id); 

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
