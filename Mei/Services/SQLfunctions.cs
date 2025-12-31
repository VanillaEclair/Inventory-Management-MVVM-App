using Mei.Interfaces;
using Mei.Models;
using MySql.Data.MySqlClient;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Shapes;

namespace Mei.Services
{
    public class SQLfunctions: IItemRepository
    {
        //Secure Connection String Later
        private string connStr = "server=localhost;user=root;database=requiem;port=3306;password=root;";
        private const string categoryQry = "SELECT * FROM category";
        private const string tableQry = "SELECT * FROM item";

        public async Task<IEnumerable<string>> GetCategoryAsync()
        {

            var items = new List<string>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    const string Query = categoryQry;
                    await conn.OpenAsync();

                    MySqlCommand cmd = new MySqlCommand(Query, conn);

                    using var rdr = await cmd.ExecuteReaderAsync();


                    while (await rdr.ReadAsync())
                    {

                        //MessageBox.Show(rdr.GetString("item_category"))
                        items.Add(rdr.GetString("item_category"));
                                            
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

        public async Task<IEnumerable<MainWindowModel>> AsyncDataQuery()
        {
            var items = new List<MainWindowModel>();
            try
            {
                using(MySqlConnection conn = new MySqlConnection(connStr))
                {
                    await conn.OpenAsync();

                    MySqlCommand cmd = new MySqlCommand(tableQry, conn);

                    using var rdr = await cmd.ExecuteReaderAsync();
                    

                    while (await rdr.ReadAsync())
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

        public async Task AddQueryAsync(AddItem item)
        {
            try
            {
                using (MySqlConnection conn = new(connStr))
                {
                    string query = "INSERT INTO item (itemName, itemDesc, itemType, itemImg, itemQty) " +
                                   "VALUES (@itemName, @itemDesc, @itemType, 'Murder' , @itemQty)";

                    await conn.OpenAsync();

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@itemName", item.ItemName);
                        cmd.Parameters.AddWithValue("@itemDesc", item.ItemDescription);
                        cmd.Parameters.AddWithValue("@itemType", item.ItemCategory);
                        cmd.Parameters.AddWithValue("@itemQty", item.ItemQuantity);

                        await cmd.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task DeleteQueryAsync(int Id)
        {
            try
            {


                using (MySqlConnection conn = new(connStr))
                {
                    string query = $"DELETE FROM item WHERE idItem=@Id";

                    await conn.OpenAsync();

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", Id);

                        await cmd.ExecuteNonQueryAsync();
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task UpdateQueryAsync(AddItem item)
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


                    await conn.OpenAsync();

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {

                        cmd.Parameters.AddWithValue("@itemName", item.ItemName);
                        cmd.Parameters.AddWithValue("@itemDesc", item.ItemDescription);
                        cmd.Parameters.AddWithValue("@itemType", item.ItemCategory);
                        //cmd.Parameters.AddWithValue("@itemImg", );
                        cmd.Parameters.AddWithValue("@itemQty", item.ItemQuantity);
                        cmd.Parameters.AddWithValue("@id", item.Id); 

                        await cmd.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<MainWindowModel>> SearchQuery(string term)
        {
            var items = new List<MainWindowModel>();

            using var conn = new MySqlConnection(connStr);
            using var cmd = conn.CreateCommand();

            cmd.CommandText = "SELECT * FROM item WHERE itemName LIKE @term";
            cmd.Parameters.AddWithValue("@term", $"%{term}%");

            await conn.OpenAsync();
            using var rdr = await cmd.ExecuteReaderAsync();

            while (await rdr.ReadAsync())
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

            return items;
        }


    }
}





//Backup

//public async IAsyncEnumerable<MainWindowModel> AsyncDataQuery()
//{
//    var items = new List<MainWindowModel>();
//    try
//    {
//        using (MySqlConnection conn = new MySqlConnection(connStr))
//        {
//            const string Query = tableQry;
//            await conn.OpenAsync();

//            MySqlCommand cmd = new MySqlCommand(Query, conn);

//            using var rdr = await cmd.ExecuteReaderAsync();


//            while (await rdr.ReadAsync())
//            {
//                items.Add(new MainWindowModel
//                {
//                    ItemID = rdr.IsDBNull("idItem") ? 0 : rdr.GetInt32("idItem"),
//                    ItemName = rdr.IsDBNull("itemName") ? "" : rdr.GetString("itemName"),
//                    ItemDescription = rdr.IsDBNull("ItemDesc") ? "" : rdr.GetString("ItemDesc"),
//                    ItemCategory = rdr.IsDBNull("itemType") ? "" : rdr.GetString("itemType"),
//                    ItemImg = rdr.IsDBNull("itemImg") ? "" : rdr.GetString("itemImg"),
//                    ItemQty = rdr.IsDBNull("itemQty") ? 0 : rdr.GetInt32("itemQty")
//                });
//            }
//            rdr.Close();
//        }
//    }
//    catch (MySqlException ex)
//    {
//        MessageBox.Show(ex.Message);
//    }

//    return items;

//}




//BackUP code
//public MainWindowModel GetCategory(string query)
//{
//    var model = new MainWindowModel();

//    try
//    {
//        using (MySqlConnection conn = new MySqlConnection(connStr))
//        {
//            string Query = query;
//            conn.Open();

//            MySqlCommand cmd = new MySqlCommand(Query, conn);

//            MySqlDataReader rdr = cmd.ExecuteReader();


//            while (rdr.Read())
//            {
//                if (!rdr.IsDBNull(rdr.GetOrdinal("item_category")))
//                {
//                    model.Category.Add(rdr.GetString("item_category"));
//                }
//            }
//            rdr.Close();
//        }
//    }
//    catch (Exception ex)
//    {

//        MessageBox.Show(ex.Message);
//    }

//    return model;
//}

//public List<string> GetCategories()
//{
//    var categories = new List<string>();

//    using var conn = new MySqlConnection(connStr);
//    using var cmd = new MySqlCommand(
//        "SELECT DISTINCT item_category FROM item",
//        conn
//    );

//    conn.Open();
//    using var rdr = cmd.ExecuteReader();

//    while (rdr.Read())
//    {
//        categories.Add(rdr.GetString("item_category"));
//    }

//    return categories;
//}