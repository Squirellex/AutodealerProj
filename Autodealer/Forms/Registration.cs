using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Autodealer
{
    public partial class Registration : Form
    {
        private bool mouseDown;
        private Point lastLocation;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );
        public Registration()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            Authorization auth = new Authorization();
            this.Hide();
            auth.Show();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void Registration_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void Registration_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void Registration_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            var loginCheck = SQLiteDataAccess.clientLoginCheck(clientLoginTB.Text);
            ClientsAuth cl = new ClientsAuth();
            if (string.IsNullOrWhiteSpace(clientNameTB.Text) || string.IsNullOrWhiteSpace(clientSurnameTB.Text) || string.IsNullOrWhiteSpace(clientMiddlenameTB.Text) ||
                    string.IsNullOrWhiteSpace(clientEmailTB.Text) || string.IsNullOrWhiteSpace(clientLoginTB.Text) ||
                        string.IsNullOrWhiteSpace(clientPasswordTB.Text))
            {
                MessageBox.Show("Поля не могут быть пустыми");
            }
            else
            {
                
                if(loginCheck.Count() == 0)
                {
                    cl.clientName = clientNameTB.Text;
                    cl.clientSurname = clientSurnameTB.Text;
                    cl.clientMiddlename = clientMiddlenameTB.Text;
                    cl.clientMobileNumber = clientMobileNumberTB.Text.ToString();
                    cl.clientEmail = clientEmailTB.Text;
                    cl.clientLogin = clientLoginTB.Text;
                    cl.clientPassword = clientPasswordTB.Text;

                    SQLiteDataAccess.saveClient(cl);

                    Authorization auth = new Authorization();
                    this.Hide();
                    auth.Show();
                }
                else
                {
                    MessageBox.Show("Пользователь с таким логином уже существует");
                }
            }
            /*carMarkTB.Text = "";
            carModelTB.Text = "";
            carColorTB.Text = "";
            carPriceTB.Text = "";*/
        }
    }
}
