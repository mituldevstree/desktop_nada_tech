using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using NadaTech_EncodingStation.View;

namespace NadaTech_EncodingStation
{
    public partial class MasterForm : Form
    {
        object openform;
        public MasterForm()
        {
            InitializeComponent();

            FLPanelMenu.AutoScroll = false;
            FLPanelMenu.HorizontalScroll.Enabled = false;
            FLPanelMenu.HorizontalScroll.Visible = false;
            FLPanelMenu.HorizontalScroll.Maximum = 0;
            FLPanelMenu.AutoScroll = true;
            SetColor(MbtnDashbord);
            hideSubMenu();
            openform = new WriteRFID(this);
            AbrirFormEnPanel(openform, "Printer RFID Encoding Station");
            this.MaximumSize = Screen.PrimaryScreen.WorkingArea.Size;
        }
        private void btnMenu_Click(object sender, EventArgs e)
        {
            if (MenuVertical.Width == 250)
            {
                MenuVertical.Width = 70;
            }
            else
                MenuVertical.Width = 250;
        }
        List<CompanyReader> _listCompanyReader = new List<CompanyReader>();


        private void iconcerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void iconmaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

        }

        private void iconrestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;

        }

        private void iconminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void AbrirFormEnPanel(object Formhijo, string Title)
        {
            this.Cursor = Cursors.WaitCursor;
            if (this.tableLayoutPanel1.Controls.Count > 0)
                this.tableLayoutPanel1.Controls.RemoveAt(0);
            tableLayoutPanel1.Controls.Clear();
            UserControl fh = Formhijo as UserControl;
            fh.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(fh);
            //fh.TopLevel = false;
            //fh.Dock = DockStyle.Fill;
            //this.tableLayoutPanel1.Controls.Add(fh);
            //this.tableLayoutPanel1.Tag = fh;
            //fh.Show();
            labTitle.Text = Title;
            this.Cursor = Cursors.Default;


        }
        private void hideSubMenu()
        {
            labTitle.Text = "";
            //panelMediaSubMenu.Visible = false;

        }
        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        private void btnlogoInicio_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnlogoInicio_Click(null, e);
        }

        

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FormWindowState _FormWindowState = this.WindowState;
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                this.WindowState = FormWindowState.Normal;

            }
        }

        private void pictureBox1_Click(object sender, MouseEventArgs e)
        {
            FormWindowState _FormWindowState = this.WindowState;
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                this.WindowState = FormWindowState.Normal;

            }
        }
        void ClearColor()
        {
            MbtnDashbord.BackColor = Color.Transparent;
            MbtnReaderEncoding.BackColor = Color.Transparent;

        }

        void SetColor(object btnonject)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (labTitle.Text == "Printer RFID Encoding Station")
                {
                    WriteRFID _WriteRFID = openform as WriteRFID;
                    if (_WriteRFID != null)
                    {
                        _WriteRFID.DisconnectPrinter();
                    }
                }
                else if (labTitle.Text == "Reader RFID Encoding Station")
                {
                    ReaderToWriteRFID _WriteRFID = openform as ReaderToWriteRFID;
                    if (_WriteRFID != null)
                    {
                        _WriteRFID.DisconnectReader();
                    }
                }
                ClearColor();
                Button _Button = btnonject as Button;
                _Button.BackColor = Color.FromArgb(8, 143, 250);
            }
            catch (Exception)
            {
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }


        private void rjButton1_Click(object sender, EventArgs e)
        {
            SetColor(sender);
            openform = new WriteRFID(this);
            AbrirFormEnPanel(openform, "Printer RFID Encoding Station");
        }

        private void MbtnReaderEncoding_Click(object sender, EventArgs e)
        {
            SetColor(sender);
            openform = new ReaderToWriteRFID(this);
            AbrirFormEnPanel(openform, "Reader RFID Encoding Station");
        }
        private void btnlogout_Click(object sender, EventArgs e)
        {
            var msgresult = RJMessageBox.Show("Are you sure you want to log out?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (msgresult == DialogResult.Yes)
            {

            }
        }

        private void MasterForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void MbtnHelp_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://nada-tech.com/");

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

public class CompanyReader
{
    public int id { get; set; }
    public string Name { get; set; }
}