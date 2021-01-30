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
using FontAwesome.Sharp;
using System.Data.SQLite;
using Autodealer.Classes;

namespace Autodealer
{
    public partial class Clients : Form
    {
        private bool mouseDown;
        private Point lastLocation;
        private IconButton currentBtn;
        private Panel leftBorderBtn;

        private int clientId;
       

        List<Cars> cars = new List<Cars>();
        List<Orders> orders = new List<Orders>();
        List<ClientsAuth> client = new List<ClientsAuth>();
        List<AOD> allOrdersData = new List<AOD>();
        List<AOToClient> AOToClient = new List<AOToClient>();

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
        public Clients()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            managementTC.Appearance = TabAppearance.FlatButtons;
            managementTC.ItemSize = new Size(0, 1);
            managementTC.SizeMode = TabSizeMode.Fixed;
            //LeftBtnColors
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(206, 3);
            sidePan.Controls.Add(leftBorderBtn);
            managementTC.SelectedIndex = 2;

            loadCarList();
            loadAODList();
            /*authorizeClient();*/
        }

        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(227, 102, 134);
        }
        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();

                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(0, 166, 222);
                currentBtn.ForeColor = color;
                currentBtn.IconColor = color;
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y + currentBtn.Size.Height);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
            }
        }
        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.DeepSkyBlue;
                currentBtn.ForeColor = Color.White;
                currentBtn.IconColor = Color.White;
            }
        }
        public void authorizeClient(string login, string password)
        {
            var authClient = SQLiteDataAccess.loadAuthClientList(login, password);

            label3.Text = authClient.clientName;
            clientId = authClient.id;
        }
        
        private void wireUpCarList()
        {
            
            clientDG.DataSource = null;
            clientDG.DataSource = cars;
            clientDG.Columns["id"].Visible = false;
            clientDG.Columns["carArchieved"].Visible = false;
        }
        private void loadAODList()
        {
            AOToClient = SQLiteDataAccess.loadCarsFromOrders(clientId);
            wireUpAODList();
        }
        private void wireUpAODList()
        {

            ordersDG.DataSource = null;
            ordersDG.DataSource = AOToClient;
            ordersDG.Columns["id"].Visible = false;
        }
        private void loadCarList()
        {
            cars = SQLiteDataAccess.loadCars();
            wireUpCarList();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void catalogBtn_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            managementTC.SelectedIndex = 0;
        }

        private void myOrdersBtn_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            managementTC.SelectedIndex = 1;
            loadAODList();
        }

        private void controlPan_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void controlPan_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void controlPan_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            Authorization auth = new Authorization();
            this.Hide();
            auth.Show();
        }

        private void addToOrdersBtn_Click(object sender, EventArgs e)
        {
            if (clientDG.SelectedRows.Count != 0)
            {
                if(clientDG.SelectedRows.Count != 0)
                {
                    DataGridViewRow row = clientDG.SelectedRows[0];
                    Orders c = new Orders();
                    c.car_id = Int32.Parse(row.Cells[0].Value.ToString());
                    c.client_id = clientId;
                    
                    SQLiteDataAccess.saveOrder(c);
                    loadCarList();
                    MessageBox.Show("Товар успешно добавлен в заказ");
                }
                else
                {
                    MessageBox.Show("Выберите товар");
                }
                
            }
        }

        private void clientDG_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            clientDG.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

       

        private void orderDeleteBtn_Click(object sender, EventArgs e)
        {
           if (ordersDG.SelectedRows.Count != 0)
           {       
                DataGridViewRow row = ordersDG.SelectedRows[0];
                SQLiteDataAccess.addOrdersToArchive(Int32.Parse(row.Cells[0].Value.ToString()));
           }
           else
           {
                MessageBox.Show("Выберите запись");
           }
            loadAODList();
            MessageBox.Show("Товар успешно убран из заказа");

        }

        private void SearchTb_TextChanged(object sender, EventArgs e)
        {
            if(SearchTb.Text != "")
            {
                clientDG.ClearSelection();
            }
            foreach (DataGridViewRow row in clientDG.Rows)
            {
                for(int i = 0; i<clientDG.ColumnCount; i++)
                if (row.Cells[i].Value.ToString().ToLower().Equals(SearchTb.Text.ToLower()))
                {
                    int rowIndex = row.Index;
                    clientDG.Rows[rowIndex].Selected = true;
                    break;
                }
            }
        }

        private void SearchTb_Click(object sender, EventArgs e)
        {
            clientDG.ClearSelection();
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            for (int i = 0; i < cars.Count; i++)
            {
                collection.Add(cars[i].carMark);
                collection.Add(cars[i].carModel);
                collection.Add(cars[i].carColor);
                collection.Add(cars[i].carPrice.ToString());
                collection.Add(cars[i].carReleaseDate.ToString());
            }
            SearchTb.AutoCompleteCustomSource = collection;
        }

        private void orderSearchTB_TextChanged(object sender, EventArgs e)
        {
            if (orderSearchTB.Text != "")
            {
                ordersDG.ClearSelection();
            }
            foreach (DataGridViewRow row in ordersDG.Rows)
            {
                string[] arr = new string[] {ordersDG.Columns[2].Name, ordersDG.Columns[3].Name, ordersDG.Columns[4].Name,
                                ordersDG.Columns[5].Name, ordersDG.Columns[6].Name};

                for(int i = 0; i<arr.Length; i++)
                
                if (row.Cells[i].Value.ToString().ToLower().Equals(orderSearchTB.Text.ToLower()))
                {
                    int rowIndex = row.Index;
                    ordersDG.Rows[rowIndex].Selected = true;
                    break;
                }
            }
        }

        private void orderSearchTB_Click(object sender, EventArgs e)
        {
            ordersDG.ClearSelection();
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            for (int i = 0; i < AOToClient.Count; i++)
            {
                collection.Add(AOToClient[i].carMark);
                collection.Add(AOToClient[i].carModel);
                collection.Add(AOToClient[i].carColor);
                collection.Add(AOToClient[i].carPrice.ToString());
                collection.Add(AOToClient[i].carReleaseDate.ToString());
            }
            orderSearchTB.AutoCompleteCustomSource = collection;
        }
    }
}
