using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataTable = System.Data.DataTable;

namespace CompanyMailingList
{
    public partial class Form1 : Form
    {
        UserInformDBContext db;
        public Form1()
        {
            InitializeComponent();
            db = new UserInformDBContext();

            db.Informations.Load();
            dataGridView1.DataSource = db.Informations.Local.ToBindingList();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            // Добавление данных
            var useInform = new UserInformation();

            var result = useInform.ShowDialog(this);

            if (result == DialogResult.Cancel) return;
            var inform = new Informations();

            inform.Login = useInform.textBox1.Text;
            inform.Profile = useInform.textBox2.Text;

            if (inform.Dynamic == useInform.checkBox1.Checked)
                MessageBox.Show("Да");
            else
                MessageBox.Show("Heт");

            inform.Email = useInform.textBox4.Text;
            inform.TypeInformation = useInform.textBox3.Text;
            db.Informations.Add(inform);
            db.SaveChanges();
            MessageBox.Show("Новый обьект добавлен в базу");
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            //ShowBD();
          // Так как БД загружается программно, данный код можно не использовать.
          // Данный код, предназначен для выгрузки данных из таблиц. Подход DataBaseFirst

        }
        //async void ShowBD()
        //{
        //    await Task.Run((() =>
        //    {
        //        using (SqlConnection data = new SqlConnection("Server = (localdb)\\mssqllocaldb; Database = UserInformDB; Trusted_Connection = true;"))
        //        {
        //            data.Open();
        //            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Informations", data);
        //            DataTable table = new DataTable();
        //            adapter.Fill(table);
        //            dataGridView1.DataSource = table;
        //        }
        //    }));
        //}
        private void Search(object sender, EventArgs e)
        {
           SearchInformation();
           
        }

       async  void SearchInformation()
       {
           dataGridView1.DataSource = db.Informations.Where(t => t.Login.Contains(textBox1.Text)).ToList();
           dataGridView1.DefaultCellStyle.SelectionBackColor = Color.CadetBlue;
           await Task.Delay(100);
       }
        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var index = dataGridView1.SelectedRows[0].Index;
                var convert = int.TryParse(dataGridView1[0, index].Value.ToString(), out var id);
                if (convert == false) return;
                Informations inform = db.Informations.Find(id); // Класс с сущьностями

                UserInformation useForm = new UserInformation(); // Экземпляр


                useForm.textBox1.Text = inform.Login;
                useForm.textBox2.Text = inform.Profile;
                useForm.checkBox1.AutoCheck = inform.Dynamic = true;
                useForm.checkBox2.AutoCheck = inform.Dynamic = false;
                useForm.textBox4.Text = inform.Email;
                useForm.textBox3.Text = inform.TypeInformation;

                DialogResult result = useForm.ShowDialog(this);
                if (result == DialogResult.Cancel)
                    return;
                inform.Login = useForm.textBox1.Text;
                inform.Profile = useForm.textBox2.Text;
                if (inform.Dynamic == (useForm.checkBox1.Checked == true))
                {
                    MessageBox.Show("Да");
                }
                else
                {
                    MessageBox.Show("Нет");
                }

                inform.Email = useForm.textBox4.Text;
                inform.TypeInformation = useForm.textBox3.Text;
                db.SaveChanges();
                dataGridView1.Refresh();
                MessageBox.Show("Объект добавлен в таблицу базы");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = 0;
                var index = dataGridView1.SelectedRows[0].Index;
                var convert = int.TryParse(dataGridView1[0, index].Value.ToString(), out id);
                if (convert == false) return;
                var inform = db.Informations.Find(id);
                if (MessageBox.Show("Будте внимательны !!,", "Вы хотите удалить запись из БД ?  !",
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Information) == DialogResult.Cancel)
                    db.Informations.Remove(inform);
                db.SaveChanges();
                MessageBox.Show("Обьект удален из базы");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ShowExcel();
        }
        async void ShowExcel()
        {
            await Task.Run((() =>
            {
                if (dataGridView1.Columns.Count <= 0) return;
                var xmlExcel = new Microsoft.Office.Interop.Excel.Application();
                xmlExcel.Application.Workbooks.Add(Type.Missing);
                for (var i = 1; i < dataGridView1.Columns.Count - 1; i++)
                {
                    xmlExcel.Cells[1, i] = dataGridView1.Columns[i + 1].HeaderText;
                }

                for (var i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    for (var j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        xmlExcel.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                    }
                }

                xmlExcel.Columns.AutoFit();
                xmlExcel.Visible = true;
            }));
        }

       
    }
}
