using NadaTech.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NadaTech.View
{
    public partial class NonMoveable : Form
    {
        NadaTechEntities _Entities = new NadaTechEntities();
        public List<TagReader> _ListOfTagReader;
        FormMode formMode;
        public System.Windows.Forms.Timer _Timer;
        public System.Windows.Forms.Timer _textTimer;
        public NonMoveable()
        {
            InitializeComponent();
            Console.Beep(2800, 500);
            _Timer = new System.Windows.Forms.Timer();
            _Timer.Tick += new EventHandler(count_down);
            _Timer.Interval = 600;
            _Timer.Start();

            _textTimer = new System.Windows.Forms.Timer();
            _textTimer.Tick += new EventHandler(titleText_down);
            _textTimer.Interval = 300;
            _textTimer.Start();
        }

        internal enum FormMode
        {
            Add, Edit, View
        }

        internal DialogResult Show(FormMode formMode, List<TagReader> listtagReaders)
        {

            _ListOfTagReader = listtagReaders;
            FillGridData();

            if (formMode == FormMode.Add)
            {
                this.formMode = formMode;
                return base.ShowDialog();
            }
            else if (formMode == FormMode.Edit)
            {
                this.formMode = formMode;
                return base.ShowDialog();
            }
            return DialogResult.Cancel;

        }
        private void count_down(object sender, EventArgs e)
        {
            Console.Beep(2800, 500);
        }
        int Colorindex = 0;
        private void titleText_down(object sender, EventArgs e)
        {
            if (Colorindex==0)
            {
                Colorindex = 1;
                labTiteltext.BackColor = Color.Transparent;
            }
            else
            {
                Colorindex = 0;
                labTiteltext.BackColor = Color.Yellow;
            }
        }

        void FillGridData()
        {
            GrinEditDeleteDetailView.DataSource = _ListOfTagReader;
            GrinEditDeleteDetailView.Columns["AssetTagId"].Visible = false;
            GrinEditDeleteDetailView.Columns["ToStatus"].Visible = false;
            GrinEditDeleteDetailView.Columns["FromLocationId"].Visible = false;
            GrinEditDeleteDetailView.Columns["ToLocationId"].Visible = false;
            GrinEditDeleteDetailView.Columns["IsMoveable"].Visible = false;
            GrinEditDeleteDetailView.Columns["TraStatus"].Visible = false;
            GrinEditDeleteDetailView.Columns["Person"].Visible = false;
            GrinEditDeleteDetailView.Columns["Note"].Visible = false;
           
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAssetNote.Texts.Trim()))
            {
                RJMessageBox.Show("Enter Note.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                _Timer.Stop();
                _ListOfTagReader.ToList().ForEach(item =>
                {
                    item.Note = txtAssetNote.Texts.Trim();
                    item.Person = txtPerson.Texts.Trim();
                    item.TraStatus = "A";
                });

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnReject_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtAssetNote.Texts.Trim()))
            {
                RJMessageBox.Show("Enter Note.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                _Timer.Stop();
                _ListOfTagReader.ToList().ForEach(item =>
                {
                    item.Note = txtAssetNote.Texts.Trim();
                    item.Person = txtPerson.Texts.Trim();
                    item.TraStatus = "R";
                });
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void linklblstopsound_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _Timer.Stop();
        }
    }
}
