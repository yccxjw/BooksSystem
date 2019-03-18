using System;
using System.Drawing;
using System.Windows.Forms;
using UI.UI;

namespace UI
{
    public partial class LoginForm : Form
    {


        public LoginForm()
        {
            InitializeComponent();
            CodeImage(CheckCode());
        }
        string checkCode = String.Empty;
        

        public string CheckCode()
        {
            int number;
            char code;
            Random random = new Random();
        
            for (int i = 0; i < 4; i++)
            {
                number = random.Next();

                if (number % 2 == 0)
                    code = (char)('0' + (char)(number % 10));
                else
                    code = (char)('A' + (char)(number % 26));

                checkCode += " " + code.ToString();
             
            }
            return checkCode;

           
        }
        private void CodeImage(string checkCode)
        {
            if (checkCode == null || checkCode.Trim() == String.Empty)
                return;

            System.Drawing.Bitmap image = new System.Drawing.Bitmap((int)Math.Ceiling((checkCode.Length * 14.0)), 35);
            Graphics g = Graphics.FromImage(image);

            try
            {
                //生成随机生成器
                Random random = new Random();
                //清空图片背景色
                g.Clear(Color.White);
                //画图片的背景噪音线
                for (int i = 0; i < 3; i++)
                {
                    int x1 = 30;
                    int x2 = 10;
                    int y1 = 10;
                    int y2 = 10;
                    g.DrawLine(new Pen(Color.Black), x1, y1, x2, y2);
                }
                Font font = new System.Drawing.Font("Arial", 20, (System.Drawing.FontStyle.Bold));
                g.DrawString(checkCode, font, new SolidBrush(Color.Red), 2, 2);

                //画图片的前景噪音点
                for (int i = 0; i < 2000; i++)
                {
                    int x = random.Next(image.Width);
                    int y = random.Next(image.Height);

                    image.SetPixel(x, y, Color.FromArgb(random.Next()));
                }
                //画图片的边框线
                g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);
                this.pictureBox1.Width = image.Width;
                this.pictureBox1.Height = image.Height;
                this.pictureBox1.BackgroundImage = image;
                this.pictureBox2.BackgroundImage = image;
            }
            catch
            { }


        }

        private void LoginForm_Load(object sender, EventArgs e)
        {


        }

        private void toolStripContainer1_TopToolStripPanel_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            CodeImage(CheckCode());
        }

        

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            CodeImage(CheckCode());
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {


        }
        public int countlogin = 0;
        BLL.Login_BLL bll = new BLL.Login_BLL();
        private void button1_Click(object sender, EventArgs e)
        {
                //从键盘获取用户名和密码
                string username = textBox1.Text.TrimEnd();
                string userpassword = textBox2.Text.TrimEnd();
                string Code = textBox8.Text.TrimEnd();
                checkCode = checkCode.Replace(" ", "");
            //对查询的记录进行判断TT

            Model.Login_MODEL loginuser = bll.getlogin(username);
            if (username != "")
            {
                if (userpassword != "")
                {
                    if (Code != "")
                    {
                        if (loginuser.Username.TrimEnd() == username)
                        {
                            string dbpassword = loginuser.dbpassword;
                            if (userpassword.Equals(dbpassword.TrimEnd()))
                            {
                                MessageBox.Show("登陆成功");
                                this.Hide();
                                MainForm f = new MainForm();
                                f.Show();
                            }
                            else
                            {
                                MessageBox.Show("密码错误，登录失败");
                                countlogin++;
                            }
                        }
                        else
                        {
                            MessageBox.Show("查无此人！");
                        }
                    }
                    else
                    {
                        MessageBox.Show("请输入验证码");
                    }
                }
                else
                {
                    MessageBox.Show("请输入密码");
                }
            }
            else
            {
                MessageBox.Show("请输入用户名");
            }


        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            button3.Enabled = checkBox1.Checked;
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {
            MainForm f = new MainForm();
            f.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

    }
}
