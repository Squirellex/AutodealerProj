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
using System.Reflection;
using Autodealer.Classes;

namespace Autodealer
{
    public partial class Form1 : Form
    {
        private bool mouseDown;
        private Point lastLocation;
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private bool isClicked = true;
        private bool cellClicked = false;

        public int staffId;

        List<Cars> cars = new List<Cars>();
        List<Staff> staff = new List<Staff>();
        List<ClientsAuth> client = new List<ClientsAuth>();

        List<AOD> allOrdersData = new List<AOD>();
        List<AOToWorkers> allOrdersToS = new List<AOToWorkers>();
        public bool StaffBtn
        {
            get { return this.staffBtn.Visible; }
            set { this.staffBtn.Visible = value; }
        }

        

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
        public Form1()
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
            managementTC.SelectedIndex = 4;
            loadCarList();
            loadStaffList();
            loadClientList();
            loadAODList();
        }
        //......Задать цвета кнопкам управления..........................................................................
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

        private void button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
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

        private void carsBtn_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            managementTC.SelectedIndex = 0;

        }

        private void clientsBtn_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            managementTC.SelectedIndex = 1;

        }

        private void ordersBtn_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            managementTC.SelectedIndex = 2;
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            Authorization authPage = new Authorization();
            this.Hide();
            authPage.Show();
        }

        private void wireUpCarList()
        {
            carsDG.DataSource = null;
            carsDG.DataSource = cars;
            carsDG.Columns["id"].Visible = false;
            carsDG.Columns["carArchieved"].Visible = false;
        }
        private void loadCarList()
        {
            cars = SQLiteDataAccess.loadCars();
            wireUpCarList();
        }
        private void addCarButton_Click(object sender, EventArgs e)
        {
            Cars c = new Cars();
            if (carMarkTB.Text != "" && carModelTB.Text != "" && carReleaseDateDP.Value.ToString() != "" &&
                    carColorTB.Text != "" && carPriceTB.Text != "")
            {
                c.carMark = carMarkTB.Text;
                c.carModel = carModelTB.Text;
                c.carReleaseDate = carReleaseDateDP.Value.ToShortDateString();
                c.carColor = carColorTB.Text;
                c.carPrice = Int32.Parse(carPriceTB.Value.ToString());

                SQLiteDataAccess.saveCar(c);
                loadCarList();

                carMarkTB.Text = "";
                carModelTB.Text = "";
                carColorTB.Text = "";
                carPriceTB.Text = "";
            }
            else
            {
                MessageBox.Show("Поля не могут быть пустыми");
            }
        }

        private void staffBtn_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            managementTC.SelectedIndex = 3;
        }
        private void wireUpStaffList()
        {
            staffDG.DataSource = null;
            staffDG.DataSource = staff;
            staffDG.Columns["id"].Visible = false;
            staffDG.Columns["Archived"].Visible = false;
        }
        private void loadStaffList()
        {
            staff = SQLiteDataAccess.loadStaff();
            wireUpStaffList();
            addStaffInCBs();
        }
        private void wireUpClientList()
        {
            clientDG.DataSource = null;
            clientDG.DataSource = client;
            clientDG.Columns["id"].Visible = false;
            clientDG.Columns["clientArchived"].Visible = false;
        }
        private void loadClientList()
        {
            client = SQLiteDataAccess.loadClientList();
            wireUpClientList();
        }

        private void wireUpAODList()
        {
            ordersDG.DataSource = null;
            ordersDG.DataSource = allOrdersToS;
            ordersDG.Columns["id"].Visible = false;
            ordersDG.Columns["worker_id"].Visible = false;
        }
        private void loadAODList()
        {
            allOrdersToS = SQLiteDataAccess.loadOrders(staffId);
            wireUpAODList();
        }
        private void addStaffBtn_Click(object sender, EventArgs e)
        {
            var loginCheck = SQLiteDataAccess.staffLoginCheck(staffLoginTB.Text);
            Staff s = new Staff();
            if (staffNameTB.Text != "" && staffSurnameTB.Text != "" && staffMiddlenameTB.Text != ""
                    && staffMiddlenameTB.Text != "" && staffMobileNumberTB.Text != "" && staffEmailTB.Text != ""
                    && staffLoginTB.Text != "" && staffPasswordTB.Text != "" && staffRoleCB.Text != "")
            {
                if (loginCheck.Count() == 0) {
                    s.name = staffNameTB.Text;
                    s.surname = staffSurnameTB.Text;
                    s.middlename = staffMiddlenameTB.Text;
                    s.mobileNumber = staffMobileNumberTB.Text.ToString();
                    s.email = staffEmailTB.Text;
                    s.login = staffLoginTB.Text;
                    s.password = staffPasswordTB.Text;
                    s.role = staffRoleCB.Text;

                    SQLiteDataAccess.saveStaff(s);
                    loadStaffList();

                    staffNameTB.Text = "";
                    staffSurnameTB.Text = "";
                    staffMiddlenameTB.Text = "";
                    staffMiddlenameTB.Text = "";
                    staffMobileNumberTB.Text = "";
                    staffEmailTB.Text = "";
                    staffLoginTB.Text = "";
                    staffPasswordTB.Text = "";
                    staffRoleCB.Text = "";
                }
                else
                {
                    MessageBox.Show("Пользователь с таким логином уже существует");
                }
                
            }
            else
            {
                MessageBox.Show("Поля не могут быть пустыми");
            }
        }
        private void addStaffInCBs()
        {
            List<string> workerName = new List<string>();
            List<string> workerSurname = new List<string>();
            for (int i=0; i < staff.Count; i++)
            {
                workerName.Add(staff[i].name);
                
            }
            for (int i = 0; i < staff.Count; i++)
            {
                workerSurname.Add(staff[i].surname);
            }
            workerNameCB.DataSource = workerName;
            workerSurnameCB.DataSource = workerSurname;
        }

        private void addClientBtn_Click(object sender, EventArgs e)
        {
            ClientsAuth cl = new ClientsAuth();
            if (clientNameTB.Text != "" && clientSurnameTB.Text != "" && clientMiddlenameTB.Text != "" &&
                    clientMobileNumberTB.Text != "" && clientEmailTB.Text != "" && clientLoginTB.Text != "" && clientPasswordTB.Text != "")
            {
                cl.clientName = clientNameTB.Text;
                cl.clientSurname = clientSurnameTB.Text;
                cl.clientMiddlename = clientMiddlenameTB.Text;
                cl.clientMobileNumber = clientMobileNumberTB.Text.ToString();
                cl.clientEmail = clientEmailTB.Text;
                cl.clientLogin = clientLoginTB.Text;
                cl.clientPassword = clientPasswordTB.Text;

                SQLiteDataAccess.saveClient(cl);
                loadClientList();

                clientNameTB.Text = "";
                clientSurnameTB.Text = "";
                clientMiddlenameTB.Text = "";
                clientMobileNumberTB.Text = "";
                clientEmailTB.Text = "";
                clientLoginTB.Text = "";
                clientPasswordTB.Text = "";
            }
            else
            {
                MessageBox.Show("Поля не могут быть пустыми");
            }
        }

        private void carsDG_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (carsDG.SelectedRows.Count != 0)
            {
                DataGridViewRow row = carsDG.SelectedRows[0];
                carMarkTB.Text = row.Cells[1].Value.ToString();
                carModelTB.Text = row.Cells[2].Value.ToString();
                carColorTB.Text = row.Cells[3].Value.ToString();
                carReleaseDateDP.Value = DateTime.Parse(row.Cells[4].Value.ToString());
                carPriceTB.Text = row.Cells[5].Value.ToString();
            }
                

        }
        public void addCarToArchive()
        {
            if (carsDG.SelectedRows.Count != 0)
            {
                DataGridViewRow row = carsDG.SelectedRows[0];
                SQLiteDataAccess.addCarToArchive(Int32.Parse(row.Cells[0].Value.ToString()));
                Cars c = new Cars();
                if (carMarkTB.Text != "" && carModelTB.Text != "" && carReleaseDateDP.Value.ToString() != "" &&
                        carColorTB.Text != "" && carPriceTB.Text != "")
                {
                    c.carMark = carMarkTB.Text;
                    c.carModel = carModelTB.Text;
                    c.carReleaseDate = carReleaseDateDP.Value.ToShortDateString();
                    c.carColor = carColorTB.Text;
                    c.carPrice = Int32.Parse(carPriceTB.Value.ToString());
                    SQLiteDataAccess.saveCar(c);
                    loadCarList();
                }
                else
                {
                    MessageBox.Show("Поля не могут быть пустыми");
                }
            }
            else 
            {
                MessageBox.Show("Выберите запись");
            }
            
            carMarkTB.Text = "";
            carModelTB.Text = "";
            carColorTB.Text = "";
            carPriceTB.Text = "";
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            if (isClicked)
            {
                //1 najatie
                editBtn.BackColor = Color.LightGreen;
                carsDG.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                addCarButton.Enabled = false;
                cellClicked = !cellClicked;
            }
            else
            {
                // 2 najatie
                editBtn.BackColor = Color.DeepSkyBlue;
                addCarToArchive();
                carsDG.SelectionMode = DataGridViewSelectionMode.CellSelect;
                addCarButton.Enabled = true;
                loadCarList();
            }
            isClicked = !isClicked;
        }

        private void archieveCar_Click(object sender, EventArgs e)
        {
            if (isClicked)
            {
                archieveCar.BackColor = Color.LightGreen;
                carsDG.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                hideTB.Visible = false;
                addCarButton.Enabled = false;
                editBtn.Enabled = false;
            }
            else
            {
                archieveCar.BackColor = Color.DeepSkyBlue;
                if(carsDG.SelectedRows.Count != 0)
                {
                    DataGridViewRow row = carsDG.SelectedRows[0];
                    SQLiteDataAccess.addCarToArchive(Int32.Parse(row.Cells[0].Value.ToString()));
                }
                else
                {
                    MessageBox.Show("Выберите запись");
                }
                
                carsDG.SelectionMode = DataGridViewSelectionMode.CellSelect;
                
                loadCarList();
                MessageBox.Show("Товар успешно убран из заказа");
                addCarButton.Enabled = true;
                editBtn.Enabled = true;
                hideTB.Visible = true;
            }
            isClicked = !isClicked;
            
        }
        public void addClientToArchive()
        {
            if(clientDG.SelectedRows.Count != 0)
            {
                DataGridViewRow row = clientDG.SelectedRows[0];
                SQLiteDataAccess.addClientToArchive(Int32.Parse(row.Cells[0].Value.ToString()));
                ClientsAuth cl = new ClientsAuth();
                if (clientNameTB.Text != "" && clientSurnameTB.Text != "" && clientMiddlenameTB.Text != "" &&
                        clientMobileNumberTB.Text != "" && clientEmailTB.Text != "" && clientLoginTB.Text != "" && clientPasswordTB.Text != "")
                {
                    cl.clientName = clientNameTB.Text;
                    cl.clientSurname = clientSurnameTB.Text;
                    cl.clientMiddlename = clientMiddlenameTB.Text;
                    cl.clientMobileNumber = clientMobileNumberTB.Text;
                    cl.clientEmail = clientEmailTB.Text;
                    cl.clientLogin = clientLoginTB.Text;
                    cl.clientPassword = clientPasswordTB.Text;
                    SQLiteDataAccess.saveClient(cl);
                    loadClientList();

                    clientNameTB.Text = "";
                    clientSurnameTB.Text = "";
                    clientMiddlenameTB.Text = "";
                    clientMobileNumberTB.Text = "";
                    clientEmailTB.Text = "";
                    clientLoginTB.Text = "";
                    clientPasswordTB.Text = "";
                }
                else
                {
                    MessageBox.Show("Поля не могут быть пустыми");
                }
            }
            else
            {
                MessageBox.Show("Выберите запись");
            }
        }
        private void clientEditBtn_Click(object sender, EventArgs e)
        {
            if (isClicked)
            {
                clientEditBtn.BackColor = Color.LightGreen;
                clientDG.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                addClientBtn.Enabled = false;
                cellClicked = !cellClicked;
            }
            else
            {
                clientEditBtn.BackColor = Color.DeepSkyBlue;
                addClientToArchive();
                clientDG.SelectionMode = DataGridViewSelectionMode.CellSelect;
                addClientBtn.Enabled = true;
                loadClientList();
            }
            isClicked = !isClicked;
        }

        private void clientDG_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (clientDG.SelectedRows.Count != 0)
            {
                DataGridViewRow row = clientDG.SelectedRows[0];
                clientNameTB.Text = row.Cells[1].Value.ToString();
                clientSurnameTB.Text = row.Cells[2].Value.ToString();
                clientMiddlenameTB.Text = row.Cells[3].Value.ToString();
                clientMobileNumberTB.Text = row.Cells[4].Value.ToString();
                clientEmailTB.Text = row.Cells[5].Value.ToString();
                clientLoginTB.Text = row.Cells[6].Value.ToString();
                clientPasswordTB.Text = row.Cells[7].Value.ToString();
            }
        }

        private void clientAddToArchiveBtn_Click(object sender, EventArgs e)
        {
            if (isClicked)
            {
                clientAddToArchiveBtn.BackColor = Color.LightGreen;
                clientDG.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                hideClientTBs.Visible = false;
                addClientBtn.Enabled = false;
                clientEditBtn.Enabled = false;
            }
            else
            {
                clientAddToArchiveBtn.BackColor = Color.DeepSkyBlue;
                if(clientDG.SelectedRows.Count != 0)
                {
                    DataGridViewRow row = clientDG.SelectedRows[0];
                    SQLiteDataAccess.addClientToArchive(Int32.Parse(row.Cells[0].Value.ToString()));
                }
                else
                {
                    MessageBox.Show("Выберите запись");
                }
                
                clientDG.SelectionMode = DataGridViewSelectionMode.CellSelect;

                loadClientList();

                clientEditBtn.Enabled = true;
                addClientBtn.Enabled = true;
                editBtn.Enabled = true;
                hideClientTBs.Visible = true;
                MessageBox.Show("Клиент успешно убран из заказа");
            }
            isClicked = !isClicked;
        }
        public void addStaffToArchive()
        {
            if(staffDG.SelectedRows.Count != 0)
            {
                DataGridViewRow row = staffDG.SelectedRows[0];
                SQLiteDataAccess.addStaffToArchive(Int32.Parse(row.Cells[0].Value.ToString()));
                Staff s = new Staff();
                if (staffNameTB.Text != "" && staffSurnameTB.Text != "" && staffMiddlenameTB.Text != "" &&
                        staffMobileNumberTB.Text != "" && staffEmailTB.Text != "" && staffLoginTB.Text != "" && staffPasswordTB.Text != "" && staffRoleCB.Text != "")
                {
                    s.name = staffNameTB.Text;
                    s.surname = staffSurnameTB.Text;
                    s.middlename = staffMiddlenameTB.Text;
                    s.mobileNumber = staffMobileNumberTB.Text;
                    s.email = staffEmailTB.Text;
                    s.login = staffLoginTB.Text;
                    s.password = staffPasswordTB.Text;
                    s.role = staffRoleCB.Text;
                    SQLiteDataAccess.saveStaff(s);
                    loadStaffList();
                    staffNameTB.Text = "";
                    staffSurnameTB.Text = "";
                    staffMiddlenameTB.Text = "";
                    staffMobileNumberTB.Text = "";
                    staffEmailTB.Text = "";
                    staffLoginTB.Text = "";
                    staffPasswordTB.Text = "";
                    staffRoleCB.Text = "";
                }
                else
                {
                    MessageBox.Show("Поля не могут быть пустыми");
                }
            }
            else
            {
                MessageBox.Show("Выберите запись");
            } 
        }
        private void editStaffBtn_Click(object sender, EventArgs e)
        {
            if (isClicked)
            {
                editStaffBtn.BackColor = Color.LightGreen;
                staffDG.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                addStaffBtn.Enabled = false;
                cellClicked = !cellClicked;
            }
            else
            {
                editStaffBtn.BackColor = Color.DeepSkyBlue;
                addStaffToArchive();
                staffDG.SelectionMode = DataGridViewSelectionMode.CellSelect;
                addStaffBtn.Enabled = true;
                loadStaffList();
            }
            isClicked = !isClicked;
        }

        private void archiveStaffBtn_Click(object sender, EventArgs e)
        {
            if (isClicked)
            {
                archiveStaffBtn.BackColor = Color.LightGreen;
                staffDG.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                hideStaffTBs.Visible = false;
                addStaffBtn.Enabled = false;
                editStaffBtn.Enabled = false;
            }
            else
            {
                archiveStaffBtn.BackColor = Color.DeepSkyBlue;
                if(staffDG.SelectedRows.Count != 0)
                {
                    DataGridViewRow row = staffDG.SelectedRows[0];
                    SQLiteDataAccess.addStaffToArchive(Int32.Parse(row.Cells[0].Value.ToString()));
                }
                else
                {
                    MessageBox.Show("Выберите запись");
                }
                staffDG.SelectionMode = DataGridViewSelectionMode.CellSelect;

                loadStaffList();

                addStaffBtn.Enabled = true;
                editStaffBtn.Enabled = true;
                hideStaffTBs.Visible = true;
            }
            isClicked = !isClicked;
        }

        private void staffDG_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (staffDG.SelectedRows.Count != 0)
            {
                DataGridViewRow row = staffDG.SelectedRows[0];
                staffNameTB.Text = row.Cells[1].Value.ToString();
                staffSurnameTB.Text = row.Cells[2].Value.ToString();
                staffMiddlenameTB.Text = row.Cells[3].Value.ToString();
                staffMobileNumberTB.Text = row.Cells[4].Value.ToString();
                staffEmailTB.Text = row.Cells[5].Value.ToString();
                staffLoginTB.Text = row.Cells[6].Value.ToString();
                staffPasswordTB.Text = row.Cells[7].Value.ToString();
                staffRoleCB.Text = row.Cells[8].Value.ToString();
            }
        }
        

        private void addManagerBtn_Click(object sender, EventArgs e)
        {
            if (ordersDG.SelectedRows.Count != 0)
            {
                var getStaff = SQLiteDataAccess.findStaff(workerNameCB.Text, workerSurnameCB.Text);
                if(getStaff != null)
                {
                    staffId = getStaff.id;
                    Orders s = new Orders();
                    DataGridViewRow row = ordersDG.SelectedRows[0];
                    if (workerNameCB.Text != "" && workerSurnameCB.Text != "")
                    {

                        s.id = Int32.Parse(row.Cells[0].Value.ToString());
                        s.worker_id = staffId;
                    }
                    else
                    {
                        MessageBox.Show("Выберите сотрудника");
                    }
                    SQLiteDataAccess.addStaffToOrder(s);
                    loadAODList();
                }
                else
                {
                    MessageBox.Show("Указанный сотрудник не найден");
                }
            }
        }

        private void ordersDG_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ordersDG.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void SearchTb_TextChanged(object sender, EventArgs e)
        {

                if (SearchTb.Text != "")
                {
                    carsDG.ClearSelection();
                }
                foreach (DataGridViewRow row in carsDG.Rows)
                {
                    for (int i = 0; i < carsDG.ColumnCount; i++)
                        if (row.Cells[i].Value.ToString().ToLower().Equals(SearchTb.Text.ToLower()))
                        {
                            int rowIndex = row.Index;
                            carsDG.Rows[rowIndex].Selected = true;
                            isClicked = !isClicked;
                            break;
                        }
                }
            
        }

        private void SearchTb_Click(object sender, EventArgs e)
        {
            carsDG.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            carsDG.ClearSelection();
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

        private void clientSearchTb_TextChanged(object sender, EventArgs e)
        {
            if (clientSearchTb.Text != "")
            {
                clientDG.ClearSelection();
            }
            foreach (DataGridViewRow row in clientDG.Rows)
            {
                string[] arr = new string[] {clientDG.Columns[1].Name, clientDG.Columns[2].Name, clientDG.Columns[3].Name,
                                clientDG.Columns[4].Name, clientDG.Columns[5].Name, clientDG.Columns[6].Name, clientDG.Columns[7].Name};

                for (int i = 0; i < arr.Length; i++)
                    if (row.Cells[i].Value.ToString().ToLower().Equals(clientSearchTb.Text.ToLower()))
                    {
                        int rowIndex = row.Index;
                        clientDG.Rows[rowIndex].Selected = true;
                        break;
                    }
            }
        }

        private void clientSearchTb_Click(object sender, EventArgs e)
        {
            clientDG.ClearSelection();
            clientDG.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            for (int i = 0; i < client.Count; i++)
            {
                collection.Add(client[i].clientName);
                collection.Add(client[i].clientSurname);
                collection.Add(client[i].clientMiddlename);
                collection.Add(client[i].clientMobileNumber.ToString());
                collection.Add(client[i].clientEmail);
                collection.Add(client[i].clientLogin);
                collection.Add(client[i].clientPassword);
            }
            clientSearchTb.AutoCompleteCustomSource = collection;
        }

        private void orderSearchTb_TextChanged(object sender, EventArgs e)
        {
            if (orderSearchTb.Text != "")
            {
                ordersDG.ClearSelection();
            }
            foreach (DataGridViewRow row in ordersDG.Rows)
            {
                /*string[] arr = new string[] {ordersDG.Columns[0].Name, ordersDG.Columns[3].Name, ordersDG.Columns[4].Name,
                                ordersDG.Columns[5].Name, ordersDG.Columns[7].Name, ordersDG.Columns[9].Name, ordersDG.Columns[10].Name};*/

                for (int i = 0; i < ordersDG.ColumnCount; i++)

                    if (row.Cells[i].Value.ToString().ToLower().Equals(orderSearchTb.Text.ToLower()))
                    {
                        int rowIndex = row.Index;
                        ordersDG.Rows[rowIndex].Selected = true;
                        break;
                    }
            }
        }

        private void orderSearchTb_Click(object sender, EventArgs e)
        {
            ordersDG.ClearSelection();
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            for (int i = 0; i < allOrdersToS.Count; i++)
            {
                collection.Add(allOrdersToS[i].carMark);
                collection.Add(allOrdersToS[i].carModel);
                collection.Add(allOrdersToS[i].carColor);
                collection.Add(allOrdersToS[i].carPrice.ToString());
                collection.Add(allOrdersToS[i].carReleaseDate.ToString());
                collection.Add(allOrdersToS[i].clientName);
                collection.Add(allOrdersToS[i].clientSurname);
                collection.Add(allOrdersToS[i].clientMiddlename);
                collection.Add(allOrdersToS[i].clientMobileNumber);
                collection.Add(allOrdersToS[i].clientEmail);
                collection.Add(allOrdersToS[i].name);
                collection.Add(allOrdersToS[i].surname);
                collection.Add(allOrdersToS[i].middlename);
            }
            orderSearchTb.AutoCompleteCustomSource = collection;
        }

        private void staffSearchTb_TextChanged(object sender, EventArgs e)
        {
            if (staffSearchTb.Text != "")
            {
                staffDG.ClearSelection();
            }
            foreach (DataGridViewRow row in staffDG.Rows)
            {
                string[] arr = new string[] {staffDG.Columns[1].Name, staffDG.Columns[2].Name, staffDG.Columns[3].Name,
                                staffDG.Columns[4].Name, staffDG.Columns[5].Name, staffDG.Columns[6].Name, staffDG.Columns[7].Name, staffDG.Columns[8].Name};

                for (int i = 0; i < arr.Length; i++)
                    if (row.Cells[i].Value.ToString().ToLower().Equals(staffSearchTb.Text.ToLower()))
                    {
                        int rowIndex = row.Index;
                        staffDG.Rows[rowIndex].Selected = true;
                        break;
                    }
            }
        }

        private void staffSearchTb_Click(object sender, EventArgs e)
        {
            staffDG.ClearSelection();
            staffDG.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            for (int i = 0; i < staff.Count; i++)
            {
                collection.Add(staff[i].name);
                collection.Add(staff[i].surname);
                collection.Add(staff[i].middlename);
                collection.Add(staff[i].mobileNumber.ToString());
                collection.Add(staff[i].email);
                collection.Add(staff[i].login);
                collection.Add(staff[i].password);
                collection.Add(staff[i].role);
            }
            staffSearchTb.AutoCompleteCustomSource = collection;
        }

        private void archiveOrderBtn_Click(object sender, EventArgs e)
        {
            if (isClicked)
            {
                archiveOrderBtn.BackColor = Color.LightGreen;
                ordersDG.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                hideResponsibleP.Visible = false;
            }
            else
            {
                if (ordersDG.SelectedRows.Count != 0)
                {
                    DataGridViewRow row = ordersDG.SelectedRows[0];
                    SQLiteDataAccess.addAllOrdersToArchive(Int32.Parse(row.Cells[0].Value.ToString()));
                }
                else
                {
                    MessageBox.Show("Выберите запись");
                }
                loadAODList();
                ordersDG.SelectionMode = DataGridViewSelectionMode.CellSelect;
                archiveOrderBtn.BackColor = Color.DeepSkyBlue;
                hideResponsibleP.Visible = true;
                MessageBox.Show("Заказ успешно перемещен в архив");
            }
            isClicked = !isClicked;
        }

        private void createReport_Click(object sender, EventArgs e)
        {
            Documents.createСonsentProcessingOfPersonalData();
        }
    }
}
