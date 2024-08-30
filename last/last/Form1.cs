using ClosedXML.Excel;
using last.Db;
using Microsoft.Data.Sqlite;
using System.Data;
using System.Data.SQLite;

namespace last
{
    public partial class Form1 : Form
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public Form1()
        {
            InitializeComponent();
            dataGridView1.DataSource = db.Tables.ToList();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        //add
        private void btnadd_Click(object sender, EventArgs e)
        {
            var temp = new Tabel
            {
                Name = txtname.Text,
                PurchasingPrice =(txtpur.Text),
                SellingPrice =(txtsell.Text),
                Quantity = (txtquanitiy.Text)
            };
            db.Add(temp);
            db.SaveChanges();
            relod(sender, e);
        }
        //delete
        private void btndelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            var rec = db.Tables.Find(id);
            db.Remove(rec);
            db.SaveChanges();
            relod(sender, e);
        }

        private void relod(object sender, EventArgs e)
        {
            db = new ApplicationDbContext();
            dataGridView1.DataSource = db.Tables.ToList();
        }

        //backup
        string appFolder = AppDomain.CurrentDomain.BaseDirectory;

        private void btnbackup_Click(object sender, EventArgs e)
        {
            try
            {
                string backupFolder = Path.Combine(appFolder, "Backups");
                Directory.CreateDirectory(backupFolder);

                string sourcePath = Path.Combine(appFolder, "thedatabase.db");
                string destinationPath = Path.Combine(backupFolder, "Backup.db");

                using (var connection = new SQLiteConnection($"Data Source={sourcePath};"))
                {
                    connection.Open();
                    using (var command = new SQLiteCommand("PRAGMA wal_checkpoint;", connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }

                if (File.Exists(destinationPath))
                {
                    File.Delete(destinationPath);
                }

                File.Copy(sourcePath, destinationPath);

                MessageBox.Show("Backup created successfully with updated data.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during backup: {ex.Message}");
            }
        }

        //restorebackup
        private void btnrestore_Click(object sender, EventArgs e)
        {
            try
            {
                string backupFolder = Path.Combine(appFolder, "Backups");
                string backupDatabasePath = Path.Combine(backupFolder, "Backup.db");
                string currentDatabasePath = Path.Combine(appFolder, "thedatabase.db");

                using (var currentConnection = new SQLiteConnection($"Data Source={currentDatabasePath};"))
                {
                    currentConnection.Open();
                    string deleteQuery = "DELETE FROM Tabel";
                    using (var deleteCommand = new SQLiteCommand(deleteQuery, currentConnection))
                    {
                        deleteCommand.ExecuteNonQuery();
                    }

                    using (var backupConnection = new SQLiteConnection($"Data Source={backupDatabasePath};"))
                    {
                        backupConnection.Open();
                        string selectQuery = "SELECT * FROM Tabel";
                        using (var command = new SQLiteCommand(selectQuery, backupConnection))
                        {
                            using (SQLiteDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    int id = reader.GetInt32(reader.GetOrdinal("Id"));
                                    string name = reader.GetString(reader.GetOrdinal("Name"));
                                    decimal? purchasingPrice = reader.IsDBNull(reader.GetOrdinal("PurchasingPrice")) ? (decimal?)null : reader.GetDecimal(reader.GetOrdinal("PurchasingPrice"));
                                    decimal? sellingPrice = reader.IsDBNull(reader.GetOrdinal("SellingPrice")) ? (decimal?)null : reader.GetDecimal(reader.GetOrdinal("SellingPrice"));
                                    decimal? profit = reader.IsDBNull(reader.GetOrdinal("Profit")) ? (decimal?)null : reader.GetDecimal(reader.GetOrdinal("Profit"));
                                    decimal? quantity = reader.IsDBNull(reader.GetOrdinal("Quantity")) ? (decimal?)null : reader.GetDecimal(reader.GetOrdinal("Quantity"));

                                    string insertQuery = "INSERT INTO Tabel (Id, Name, PurchasingPrice, SellingPrice, Profit, Quantity) VALUES (@Id, @Name, @PurchasingPrice, @SellingPrice, @Profit, @Quantity)";
                                    using (var insertCommand = new SQLiteCommand(insertQuery, currentConnection))
                                    {
                                        insertCommand.Parameters.AddWithValue("@Id", id);
                                        insertCommand.Parameters.AddWithValue("@Name", name);
                                        insertCommand.Parameters.AddWithValue("@PurchasingPrice", purchasingPrice);
                                        insertCommand.Parameters.AddWithValue("@SellingPrice", sellingPrice);
                                        insertCommand.Parameters.AddWithValue("@Profit", profit);
                                        insertCommand.Parameters.AddWithValue("@Quantity", quantity);
                                        insertCommand.ExecuteNonQuery();
                                    }
                                }
                            }
                        }
                    }
                }

                MessageBox.Show("Data restored and replaced successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during restore: {ex.Message}");
            }
        }

        //toexcel
        private void btnexcel_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = Path.Combine(appFolder, "Backups", "Backup.xlsx");

                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("Data");

                    var dataTable = GetDataFromDatabase();

                    worksheet.Cell(1, 1).InsertTable(dataTable);

                    workbook.SaveAs(filePath);
                }

                MessageBox.Show("Data exported to Excel successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during export: {ex.Message}");
            }
        }

        //export to excel
        private DataTable GetDataFromDatabase()
        {
            string appFolder = AppDomain.CurrentDomain.BaseDirectory;
            string sourcePath = Path.Combine(appFolder, "BUDataBase.db");

            var dataTable = new DataTable();
            using (var connection = new SQLiteConnection($"Data Source={sourcePath};"))
            {
                connection.Open();
                using (var command = new SQLiteCommand("SELECT * FROM TbKhaloods;", connection))
                {
                    using (var adapter = new SQLiteDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }
            return dataTable;
        }

        //import from excel
        private void btnfromexcel_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = Path.Combine(appFolder, "Backups", "Import.xlsx");
                string dbPath = Path.Combine(appFolder, "thedatabase.db");

                using (var workbook = new XLWorkbook(filePath))
                {
                    using (var connection = new SQLiteConnection($"Data Source={dbPath};"))
                    {
                        connection.Open();

                        foreach (var worksheet in workbook.Worksheets)
                        {
                            string tableName = worksheet.Name;
                            var dataTable = worksheet.RangeUsed().AsTable().AsNativeDataTable();

                            using (var deleteCommand = new SQLiteCommand($"DELETE FROM {tableName};", connection))
                            {
                                deleteCommand.ExecuteNonQuery();
                            }

                            using (var transaction = connection.BeginTransaction())
                            {
                                foreach (DataRow row in dataTable.Rows)
                                {
                                    var columns = string.Join(", ", dataTable.Columns.Cast<DataColumn>().Select(c => c.ColumnName));
                                    var values = string.Join(", ", dataTable.Columns.Cast<DataColumn>().Select(c => $"@{c.ColumnName}"));

                                    var insertCommand = new SQLiteCommand($"INSERT INTO {tableName} ({columns}) VALUES ({values});", connection);
                                    foreach (DataColumn column in dataTable.Columns)
                                    {
                                        insertCommand.Parameters.AddWithValue($"@{column.ColumnName}", row[column]);
                                    }
                                    insertCommand.ExecuteNonQuery();
                                }
                                transaction.Commit();
                            }
                        }
                    }
                }

                MessageBox.Show("Data restored from Excel successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during restore: {ex.Message}");
            }
        }

    }
}
