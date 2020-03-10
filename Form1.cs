using Microsoft.EntityFrameworkCore;
using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.ToolTips;
using GMap.NET.WindowsForms.Markers;
using Application = Microsoft.Office.Interop.Excel.Application;

namespace CompanyMailingList
{
    public partial class Form1 : Form
    {
        //public static bool selected;

        public const string Connection =
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog = UserInformDB; Integrated Security = True";

        //SqlCommand cmd;
        //SqlConnection con;

        // SqlDataAdapter da;
        //SqlCeDataAdapter da;

        UserInformDBContext db;

        public Form1()
        {
            InitializeComponent();
            db = new UserInformDBContext();
            db.Informations.Load();
            db.Documents.Load();
            dataGridView1.DataSource = db.Informations.Local.ToBindingList();
            dataGridView3.DataSource = db.Documents.Local.ToBindingList();
        }

        #region  Добавление данных в БД  во второй вкладке формы при помощи sql запросов
        // Данный код отключен 

        //private void button20_Click(object sender, EventArgs e)
        //{
        //    // Добавление данных в БД  во второй вкладке формы
        //    //dataGridView3.Refresh();
        //    con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=UserInformDB;Integrated Security=True");
        //    con.Open();
        //    cmd = new SqlCommand("INSERT INTO Documents (Addressees) VALUES (@Addressees)", con);
        //    cmd.Parameters.Add("@Addressees", textBox8.Text);
        //    //if (textBox4.Text != null)
        //    //    textBox4.Text = " ";
        //    //button5.Refresh();
        //    dataGridView3.Refresh();
        //    cmd.ExecuteNonQuery();
        //    con.Close();
        //}
        #endregion

        private void AddData(object sender, EventArgs e)
        {
            var useInform = new UserInformation();
            var result = useInform.ShowDialog(this);
            if (result == DialogResult.Cancel) return;
            var inform = new Informations();
            inform.Login = useInform.textBox1.Text;
            inform.Profile = useInform.textBox2.Text;
            inform.Dynamic = useInform.checkBox1.Checked == true;
            inform.Dynamic = useInform.checkBox2.Checked == true;
            inform.Email = useInform.textBox4.Text;
            inform.TypeInformation = useInform.textBox3.Text;
            db.Informations.Add(inform);
            db.SaveChanges();
            dataGridView1.Refresh();
            MessageBox.Show("Новый обьект добавлен в базу");// Добавление данных 1 вкладка формы
        }


        private void ImportExcelTable(object sender, EventArgs e)
        {
            ShowExcel(); // Импорт данных в XL
        }

        private async void ShowExcel()
        {
            await Task.Run(() =>
            {
                if (dataGridView1.Columns.Count <= 0) return;
                var xmlExcel = new Application();
                xmlExcel.Application.Workbooks.Add(Type.Missing);
                for (var i = 1; i < dataGridView1.Columns.Count - 1; i++)
                    xmlExcel.Cells[1, i] = dataGridView1.Columns[i + 1].HeaderText;
                for (var i = 0; i < dataGridView1.Rows.Count - 1; i++)
                    for (var j = 0; j < dataGridView1.Columns.Count; j++)
                        xmlExcel.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                xmlExcel.Columns.AutoFit();
                xmlExcel.Visible = true;
            }).ConfigureAwait(false);
        }


        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            SearchInformation();
            // Поиск по базе
        }

        public void SearchInformation()
        {
            // Поиск в базе
            dataGridView1.DataSource = db.Informations.Where(t => t.Login.Contains(textBox7.Text)).ToList();
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.CadetBlue;

        }

        #region Даный код, позволяет работать с БД при помощи sql запросов. Но в данный момент он не используется 
        // Но его можно сконфигурировать для работы с БД

        //private void Button5_Click(object sender, EventArgs e)
        //{
        //    using (SqlConnection sql = new SqlConnection(Connection))
        //    {
        //        // Показывает данные из таблицы
        //        sql.Open();
        //        SqlDataAdapter sqlData = new SqlDataAdapter("SELECT Addressees FROM Documents", sql);
        //        DataTable table = new DataTable();
        //        int v = sqlData.Fill(table);
        //        dataGridView3.DataSource = table;
        //        dataGridView3.Refresh();
        //        sql.Close();
        //    }
        //}

        //private void Button19_Click(object sender, EventArgs e) // Удаление данных из таблицы
        //{
        //    var index = dataGridView3.CurrentCell.RowIndex;
        //    dataGridView3.Rows.RemoveAt(index);
        //    dataGridView3.Refresh();
        //    MessageBox.Show("Обьект из базы удален");
        //}

        //[Obsolete]
        //private void button22_Click(object sender, EventArgs e)
        //{
        //    using (var sql = new SqlConnection(Connection))
        //    {
        //        sql.Open();
        //        cmd = new SqlCommand("insert into Documents(RecipientsNNN) values(@RecipientsNNN)", sql);
        //        cmd.Parameters.Add(@"RecipientsNNN", textBox5.Text);
        //        if (textBox5.Text != null)
        //            textBox5.Text = " ";
        //        button22.Refresh();
        //        dataGridView4.Refresh();
        //        MessageBox.Show("Объект добавлен");
        //        cmd.ExecuteNonQuery();
        //        sql.Close();
        //    }
        //}

        //private void Button23_Click(object sender, EventArgs e)
        //{
        //    using (var sqlConnection = new SqlConnection(Connection))
        //    {
        //        sqlConnection.Open();
        //        var sqlData = new SqlDataAdapter("select RecipientsNNN from Documents", sqlConnection);
        //        var table = new DataTable();
        //        sqlData.Fill(table);
        //        dataGridView4.DataSource = table;
        //        dataGridView4.Refresh();
        //        sqlConnection.Close();
        //    }
        //}

        //private void Button21_Click(object sender, EventArgs e)
        //{
        //    int index = dataGridView4.CurrentCell.RowIndex;
        //    dataGridView4.Rows.RemoveAt(index);
        //    dataGridView4.Refresh();
        //    MessageBox.Show("Объект из базы удален");
        //}

        //public void textBox8_TextChanged(object sender, EventArgs e)
        //{
        //    ShowAdressInform();
        //}

        //public void ShowAdressInform()
        //{
        //    dataGridView6.DataSource = db.Documents.Where(p => p.Addressees.Contains(textBox8.Text));
        //}

        //[Obsolete]
        //private void button17_Click_1(object sender, EventArgs e)
        //{
        //    using (var sql = new SqlConnection(Connection))
        //    {
        //        sql.Open();


        //        cmd = new SqlCommand("insert into Documents(CustomsPost)values(@CustomsPost)", sql);
        //        cmd.Parameters.Add(@"CustomsPost", textBox10.Text);
        //        MessageBox.Show("Done");
        //        if (textBox10.Text != null)
        //            textBox10.Text = " ";
        //        button18.Refresh();
        //        dataGridView5.Refresh();
        //        cmd.ExecuteNonQuery();
        //        sql.Close();

        //    }
        //}

        //private void Button18_Click(object sender, EventArgs e)
        //{
        //    using (var sq = new SqlConnection(Connection))
        //    {
        //        sq.Open();
        //        dataGridView5.Refresh();
        //        var data = new SqlDataAdapter("SELECT  CustomsPost FROM Documents", sq);
        //        var dt = new DataTable();
        //        data.Fill(dt);
        //        dataGridView5.Width = 200;
        //        dataGridView5.DataSource = dt;
        //        sq.Close();
        //    }

        //}

        //private void button24_Click(object sender, EventArgs e)
        //{
        //    var index = dataGridView5.CurrentCell.RowIndex;
        //    dataGridView5.Rows.RemoveAt(index);
        //    dataGridView5.Refresh();
        //    MessageBox.Show("Объект из базы удален");

        //}

        //[Obsolete]
        //private void button25_Click(object sender, EventArgs e)
        //{
        //    //using (SqlConnection sqll = new SqlConnection(Connection))
        //   // {

        //        //sqll.Open();
        //        //cmd = new SqlCommand("insert into Documents(NotificationType)values(@NotificationType)", sqll);
        //        //cmd.Parameters.Add(@"NotificationType", textBox8.Text);
        //        //if (textBox8.Text != null)
        //        //    MessageBox.Show("Done");
        //        //cmd.ExecuteNonQuery();
        //        //sqll.Close();


        //    //}
        //}

        #endregion

        private void Button26_Click(object sender, EventArgs e)
        {
            var FulForm = new FullInformation();
            var result = FulForm.ShowDialog(this);
            if (result == DialogResult.Cancel) return;
            var documents = new Documents();
            documents.Entry = FulForm.checkBox1.Checked;
            documents.Exit = FulForm.checkBox2.Checked;
            documents.CargoPlacement = FulForm.checkBox3.Checked;
            documents.Sacrifieces = FulForm.checkBox4.Checked;
            documents.ThemachineTP = FulForm.checkBox5.Checked;
            documents.NumberTC = FulForm.textBox1.Text;
            documents.Tyre = FulForm.checkBox6.Checked;
            documents.TimeEvents = FulForm.checkBox7.Checked;
            documents.DescriptionCargo = FulForm.textBox2.Text;
            documents.Recipient = FulForm.textBox3.Text;
            documents.TheconditionSeals = FulForm.checkBox8.Checked;
            documents.ContentState = FulForm.checkBox9.Checked;
            documents.RadiationControl = FulForm.checkBox10.Checked;
            documents.PhoneNumberDrive = FulForm.textBox4.Text;
            documents.Addressees = FulForm.textBox8.Text;
            documents.RecipientsNNN = FulForm.textBox5.Text;
            documents.CustomsPost = FulForm.textBox10.Text;
            documents.TimeTransmissionDocumentsDriver = FulForm.dateTimePicker1.Value.Date;
            documents.NotificationType = FulForm.textBox6.Text;
            db.Documents.Add(documents);
            db.SaveChanges();
            MessageBox.Show("Done");
        }


        private void Button25_Click(object sender, EventArgs e) // Удалить данные из таблицы
        {
            int index = dataGridView3.CurrentCell.RowIndex;
            dataGridView3.Rows.RemoveAt(index);
            dataGridView3.Refresh();
            MessageBox.Show("Объект из базы удален");
        }



        private void button3_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var index = dataGridView1.SelectedRows[0].Index;
                var id = 0;
                var converted = int.TryParse(dataGridView1[0, index].Value.ToString(), out id);
                if (converted == false) return;
                var inform = db.Informations.Find(id);
                var useInform = new UserInformation
                {
                    textBox1 = { Text = inform.Login },
                    textBox2 = { Text = inform.Profile },
                    checkBox1 = { Checked = inform.Dynamic = true },
                    checkBox2 = { Checked = inform.Dynamic = false },
                    textBox4 = { Text = inform.Email },

                    textBox3 = { Text = inform.TypeInformation }


                };
                var result = useInform.ShowDialog(this);
                if (result == DialogResult.Cancel) return;
                inform.Login = useInform.textBox1.Text;
                inform.Profile = useInform.textBox2.Text;
                inform.Dynamic = useInform.checkBox1.Checked = true;
                MessageBox.Show(inform.Dynamic == (useInform.checkBox1.Checked = true) ? "Да" : "Нет");


                inform.Email = useInform.textBox4.Text;
                inform.TypeInformation = useInform.textBox3.Text;
                db.SaveChanges();
                dataGridView1.Refresh();
                MessageBox.Show("Объект обнавлен");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Удаление объекта из таблицы
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int index = dataGridView1.SelectedRows[0].Index;
                int id = 0;
                bool converted = int.TryParse(dataGridView1[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;
                Informations inform = db.Informations.Find(id);
                if (MessageBox.Show("Будте внимательны !!,", "Вы хотите удалить запись из БД ?  !",
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Information) == DialogResult.Cancel)
                    MessageBox.Show("Обьект удален");
                db.Informations.Remove(inform);
                db.SaveChanges();
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            if (dataGridView3.SelectedRows.Count > 0)
            {
                var index = dataGridView3.SelectedRows[0].Index;
                var converted = int.TryParse(dataGridView3[0, index].Value.ToString(), out var id);
                if (converted == false) return;
                var documents = db.Documents.Find(id);
                var useInform = new FullInformation();
                useInform.textBox10.Text = documents.CustomsPost;
                useInform.textBox5.Text = documents.RecipientsNNN;
                useInform.textBox5.Text = documents.Addressees;
                useInform.checkBox1.Checked = documents.Entry;
                useInform.checkBox2.Checked = documents.Exit;
                useInform.checkBox3.Checked = documents.CargoPlacement;
                useInform.checkBox4.Checked = documents.Sacrifieces;
                useInform.checkBox5.Checked = documents.ThemachineTP;
                useInform.textBox1.Text = documents.NumberTC;
                useInform.checkBox6.Checked = documents.Tyre;
                useInform.checkBox7.Checked = documents.TimeEvents;
                useInform.textBox2.Text = documents.DescriptionCargo;
                useInform.textBox3.Text = documents.Recipient;
                useInform.textBox6.Text = documents.NotificationType;
                useInform.checkBox8.Checked = documents.TheconditionSeals;
                useInform.checkBox9.Checked = documents.RadiationControl;
                useInform.textBox4.Text = documents.PhoneNumberDrive;
                useInform.dateTimePicker1.Format = DateTimePickerFormat.Custom;
                documents.TimeTransmissionDocumentsDriver.ToLongDateString();
                var result = useInform.ShowDialog(this);
                if (result == DialogResult.Cancel) return;
                documents.CustomsPost = useInform.textBox10.Text;
                documents.RecipientsNNN = useInform.textBox5.Text;
                documents.Addressees = useInform.textBox5.Text;
                documents.Entry = useInform.checkBox1.Checked;
                documents.Exit = useInform.checkBox2.Checked;
                documents.CargoPlacement = useInform.checkBox3.Checked;
                documents.Sacrifieces = useInform.checkBox4.Checked;
                documents.ThemachineTP = useInform.checkBox5.Checked;
                documents.NumberTC = useInform.textBox1.Text;
                documents.Tyre = useInform.checkBox6.Checked;
                documents.TimeEvents = useInform.checkBox7.Checked;
                documents.DescriptionCargo = useInform.textBox2.Text;
                documents.Recipient = useInform.textBox3.Text;
                documents.NotificationType = useInform.textBox6.Text;
                documents.TheconditionSeals = useInform.checkBox8.Checked;
                documents.RadiationControl = useInform.checkBox9.Checked;
                documents.PhoneNumberDrive = useInform.textBox4.Text;
                documents.TimeTransmissionDocumentsDriver = useInform.dateTimePicker1.Value.Date;
                db.SaveChanges();
                dataGridView3.Refresh();
                MessageBox.Show("Данные обновленны");
            }
        }

        private void Search(object sender, EventArgs e)
        {
            dataGridView3.DataSource = db.Documents.Where(t => t.Addressees.Contains(textBox4.Text)).ToList();
            dataGridView3.DefaultCellStyle.SelectionBackColor = Color.DarkCyan;
            dataGridView3.Refresh();
        }

       
    }
}

