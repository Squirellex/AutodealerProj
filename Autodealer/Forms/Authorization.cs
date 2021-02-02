using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Data.SQLite;


namespace Autodealer
{
    public partial class Authorization : Form
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
        public Authorization()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }


        private void loginBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var result = SQLiteDataAccess.loadUser(authLoginTB.Text, authPasswordTB.Text);
                if (result.Count() != 0)
                {
                    string userRole = result[0].role;
                    if (userRole == "Administrator")
                    {
                        Form1 form = new Form1();
                        this.Hide();
                        form.Show();
                    }
                    else
                    {
                        if (userRole == "Manager")
                        {
                            Form1 form = new Form1();
                            this.Hide();
                            form.Show();
                            form.StaffBtn = false;
                        }

                    }
                }
                else
                {
                    var clientResult = SQLiteDataAccess.loadClient(authLoginTB.Text, authPasswordTB.Text);
                    if (clientResult.Count() != 0)
                    {
                        Clients clients = new Clients();
                        this.Hide();
                        clients.Show();
                        clients.authorizeClient(authLoginTB.Text, authPasswordTB.Text);
                    }
                    else
                    {
                        MessageBox.Show("Данные введены неверно или пользователь удалён");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Данные введены неверно или пользователь удалён");
            }
        }
        /*ДВИГАТЬ ОКОШКО */
        private void Authorization_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void Authorization_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void Authorization_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
        /*КОНЕЦ ДВИГАНЬЯ ОКОШКА*/

        private void RegisterBtn_Click(object sender, EventArgs e)
        {
            Registration reg = new Registration();
            this.Hide();
            reg.Show();
        }
    }
}
