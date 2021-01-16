using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace lab2_iz
{
    public partial class Form1 : Form
    {
       
        List<Button> vars = new List<Button>();
        List<bool> btn = new List<bool>();
        List<string> rules = new List<string>();
        List<string> questions = new List<string>();
        public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|/lab2.accdb";
        private OleDbConnection myConnection;
        OleDbCommand command;
        string query;
        int ans = 1;
        public Form1()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);

            // открываем соединение с БД
            myConnection.Open();
        }
    

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            vars.AddRange(new Button[] { YesButton, NoButton, button1, button2,
                                        button3, button4, button5, button6 });
            btn.AddRange(new bool[] { false, false, false, false, false, false, false, false });
            Quiz();
        }

        private void restartbutton_Click(object sender, EventArgs e)
        {
            YesButton.Visible = true;
            NoButton.Visible = true;
            pictureBox1.Visible = false;
            label2.Visible = false;
            ans = 1;
            Quiz();
        }
        public void Quiz()
        {
            for(int i = 2; i < 8; i++)
            {
                vars[i].Visible = false;
            }
             query= "SELECT вопрос FROM Вопросы WHERE код_вопроса = 1";
            // создаем объект OleDbCommand для выполнения запроса к БД MS Access
            command = new OleDbCommand(query, myConnection);

            // выполняем запрос и выводим результат в textBox1
            label1.Text = command.ExecuteScalar().ToString();
            
           
        }

        private void YesButton_Click(object sender, EventArgs e)
        {
            
            btn[0] = true;
            int ans1 = ans;
            

            query = String.Format("select в_да from варианты WHERE id_вопр = {0}", ans);
            command = new OleDbCommand(query, myConnection);
            ans = int.Parse(command.ExecuteScalar().ToString());
            if (ans > 0)
            {
                query = String.Format("SELECT вопрос FROM Вопросы WHERE код_вопроса = {0}", ans);
                command = new OleDbCommand(query, myConnection);
                label1.Text = command.ExecuteScalar().ToString();
                if (ans == 12)
                {
                    YesButton.Visible = false;
                    NoButton.Visible = false;
                    for (int i = 2; i < 8; i++)
                    {
                        vars[i].Visible = true;
                    }
                }
                
                    
            }
            else
            {
                query = String.Format("select от_да from варианты WHERE id_вопр = {0}", ans1);
                command = new OleDbCommand(query, myConnection);
                ans1 = int.Parse(command.ExecuteScalar().ToString());
                query = String.Format("SELECT ответ FROM Ответы WHERE код_ответа = {0}", ans1);
                command = new OleDbCommand(query, myConnection);
                label1.Text = command.ExecuteScalar().ToString();
                YesButton.Visible = false;
                NoButton.Visible = false;
                query = String.Format("SELECT img FROM Ответы WHERE код_ответа = {0}", ans1);
                command = new OleDbCommand(query, myConnection);
                pictureBox1.Image = (Image)new Bitmap(command.ExecuteScalar().ToString());
                query = String.Format("SELECT info FROM Ответы WHERE код_ответа = {0}", ans1);
                command = new OleDbCommand(query, myConnection);
                label2.Text = command.ExecuteScalar().ToString();
                pictureBox1.Visible = true;
                label2.Visible = true;
            }
        }

        private void NoButton_Click(object sender, EventArgs e)
        {
            btn[1] = true;
            int ans1 = ans;
           


            query = String.Format("select в_нет from варианты WHERE id_вопр = {0}", ans);
            command = new OleDbCommand(query, myConnection);
            ans = int.Parse(command.ExecuteScalar().ToString());
            if (ans > 0)
            {                
                query = String.Format("SELECT вопрос FROM Вопросы WHERE код_вопроса = {0}", ans);
            command = new OleDbCommand(query, myConnection);
            label1.Text = command.ExecuteScalar().ToString();
                if (ans == 12)
                {
                    YesButton.Visible = false;
                    NoButton.Visible = false;
                    for (int i = 2; i < 8; i++)
                    {
                        vars[i].Visible = true;
                    }
                }
                
            }
            else
            {
                query = String.Format("select от_нет from варианты WHERE id_вопр = {0}", ans1);
                command = new OleDbCommand(query, myConnection);
                ans1 = int.Parse(command.ExecuteScalar().ToString());
                query = String.Format("SELECT ответ FROM Ответы WHERE код_ответа = {0}", ans1);
                command = new OleDbCommand(query, myConnection);
                label1.Text = command.ExecuteScalar().ToString();
                YesButton.Visible = false;
                NoButton.Visible = false;
                query = String.Format("SELECT img FROM Ответы WHERE код_ответа = {0}", ans1);
                command = new OleDbCommand(query, myConnection);
                pictureBox1.Image =(Image) new Bitmap(command.ExecuteScalar().ToString());
                query = String.Format("SELECT info FROM Ответы WHERE код_ответа = {0}", ans1);
                command = new OleDbCommand(query, myConnection);
                label2.Text= command.ExecuteScalar().ToString();
                pictureBox1.Visible = true;
                label2.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            YesButton.Visible = true;
            NoButton.Visible = true;
            btn[2] = true;
            for (int i = 2; i < 8; i++)
            {
                vars[i].Visible = false;
            }
            query = String.Format("select в_корни from варианты WHERE id_вопр = {0}", ans);
            command = new OleDbCommand(query, myConnection);
            ans = int.Parse(command.ExecuteScalar().ToString());

            query = String.Format("SELECT вопрос FROM Вопросы WHERE код_вопроса = {0}", ans);
            command = new OleDbCommand(query, myConnection);
            label1.Text = command.ExecuteScalar().ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            YesButton.Visible = true;
            NoButton.Visible = true;
            btn[3] = true;
            for (int i = 2; i < 8; i++)
            {
                vars[i].Visible = false;
            }
            query = String.Format("select в_листья from варианты WHERE id_вопр = {0}", ans);
            command = new OleDbCommand(query, myConnection);
            ans = int.Parse(command.ExecuteScalar().ToString());

            query = String.Format("SELECT вопрос FROM Вопросы WHERE код_вопроса = {0}", ans);
            command = new OleDbCommand(query, myConnection);
            label1.Text = command.ExecuteScalar().ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            YesButton.Visible = true;
            NoButton.Visible = true;
            btn[4] = true;
            for (int i = 2; i < 8; i++)
            {
                vars[i].Visible = false;
            }
            query = String.Format("select в_семена from варианты WHERE id_вопр = {0}", ans);
            command = new OleDbCommand(query, myConnection);
            ans = int.Parse(command.ExecuteScalar().ToString());

            query = String.Format("SELECT вопрос FROM Вопросы WHERE код_вопроса = {0}", ans);
            command = new OleDbCommand(query, myConnection);
            label1.Text = command.ExecuteScalar().ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            YesButton.Visible = true;
            NoButton.Visible = true;
            btn[5] = true;
            for (int i = 2; i < 8; i++)
            {
                vars[i].Visible = false;
            }
            query = String.Format("select в_плоды from варианты WHERE id_вопр = {0}", ans);
            command = new OleDbCommand(query, myConnection);
            ans = int.Parse(command.ExecuteScalar().ToString());

            query = String.Format("SELECT вопрос FROM Вопросы WHERE код_вопроса = {0}", ans);
            command = new OleDbCommand(query, myConnection);
            label1.Text = command.ExecuteScalar().ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            YesButton.Visible = true;
            NoButton.Visible = true;
            btn[6] = true;
            for (int i = 2; i < 8; i++)
            {
                vars[i].Visible = false;
            }
            query = String.Format("select в_цветы from варианты WHERE id_вопр = {0}", ans);
            command = new OleDbCommand(query, myConnection);
            ans = int.Parse(command.ExecuteScalar().ToString());

            query = String.Format("SELECT вопрос FROM Вопросы WHERE код_вопроса = {0}", ans);
            command = new OleDbCommand(query, myConnection);
            label1.Text = command.ExecuteScalar().ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            YesButton.Visible = true;
            NoButton.Visible = true;
            btn[7] = true;
            for (int i = 2; i < 8; i++)
            {
                vars[i].Visible = false;
            }
            query = String.Format("select в_др from варианты WHERE id_вопр = {0}", ans);
            command = new OleDbCommand(query, myConnection);
            ans = int.Parse(command.ExecuteScalar().ToString());

            query = String.Format("SELECT вопрос FROM Вопросы WHERE код_вопроса = {0}", ans);
            command = new OleDbCommand(query, myConnection);
            label1.Text = command.ExecuteScalar().ToString();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            myConnection.Close();
        }
    }

    
}
