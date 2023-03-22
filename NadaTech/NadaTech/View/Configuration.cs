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
    public partial class Configuration : UserControl
    {
        MasterForm _Mainform;
        NadaTechEntities _Entities = new NadaTechEntities();
        public Configuration(object _mainform)
        {
            InitializeComponent();
            _Mainform = _mainform as MasterForm;
            FillRecord();
        }


        private void rjButton2_Click(object sender, EventArgs e)
        {
            _Mainform.MasterFormclick("PartViewUC");
        }


        private void FillRecord()
        {
            try
            {
                #region TAGPREFIX
                ConfigMaster _PrefixCon = _Entities.ConfigMasters.FirstOrDefault(f => f.ConfigKey == "TAGPREFIX");
                if (_PrefixCon != null)
                {
                    txtTagPrefix.Texts = _PrefixCon.ConfigValues;
                    txtPrefixHex.Texts = Common.ConvertASCIItoHex(txtTagPrefix.Texts);
                }
                else
                {
                    txtTagPrefix.Texts = "";
                }
                #endregion

                #region SYSIOTFIXEDRE
                ConfigMaster _SYSIOTFIXEDREIP = _Entities.ConfigMasters.FirstOrDefault(f => f.ConfigKey == "SYSIOTFIXEDREIP");
                if (_SYSIOTFIXEDREIP != null)
                {
                    txtSYSOTReaderIP.Texts = _SYSIOTFIXEDREIP.ConfigValues;
                }
                else
                {
                    txtSYSOTReaderIP.Texts = "";
                }
                ConfigMaster _SYSIOTFIXEDREPORT = _Entities.ConfigMasters.FirstOrDefault(f => f.ConfigKey == "SYSIOTFIXEDREPORT");
                if (_SYSIOTFIXEDREPORT != null)
                {
                    txtSYSOTReaderPort.Texts = _SYSIOTFIXEDREPORT.ConfigValues;
                }
                else
                {
                    txtSYSOTReaderPort.Texts = "";
                }
                #endregion

                #region CIRFID FIXED READER
                ConfigMaster _CIRFIDFIXEDREIP = _Entities.ConfigMasters.FirstOrDefault(f => f.ConfigKey == "CIRFIDFIXEDREIP");
                if (_CIRFIDFIXEDREIP != null)
                {
                    txtCirfidIP.Texts = _CIRFIDFIXEDREIP.ConfigValues;
                }
                else
                {
                    txtCirfidIP.Texts = "";
                }
                ConfigMaster _CIRFIDFIXEDREPORT = _Entities.ConfigMasters.FirstOrDefault(f => f.ConfigKey == "CIRFIDFIXEDREPORT");
                if (_CIRFIDFIXEDREPORT != null)
                {
                    txtCirfidPort.Texts = _CIRFIDFIXEDREPORT.ConfigValues;
                }
                else
                {
                    txtCirfidPort.Texts = "";
                }
                #endregion

                #region ReaderAntennaPower
                ConfigMaster _ReaderAntennaPower = _Entities.ConfigMasters.FirstOrDefault(f => f.ConfigKey == "ReaderAntennaPower");
                if (_ReaderAntennaPower != null)
                {
                    cbmPower.SelectedItem = _ReaderAntennaPower.ConfigValues;
                }
                else
                {
                    cbmPower.SelectedItem = "25";
                }
                #endregion

            }
            catch (Exception _Exception)
            {
                RJMessageBox.Show(_Exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Application.ExitThread();
            }
        }
        private bool Cansave()
        {
            if (String.IsNullOrEmpty(cbmPower.SelectedItem.ToString()))
            {
                RJMessageBox.Show("Select  Antenna Power.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
                return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                if (Cansave())
                {
                    #region TAGPREFIX
                    ConfigMaster _PrefixConf = _Entities.ConfigMasters.FirstOrDefault(f => f.ConfigKey == "TAGPREFIX");
                    if (_PrefixConf == null)
                    {
                        _PrefixConf = new ConfigMaster();
                        _PrefixConf.ConfigKey = "TAGPREFIX";
                        _PrefixConf.ConfigValues = txtTagPrefix.Texts.Trim();
                        _PrefixConf.IsShow = true;
                        _Entities.ConfigMasters.Add(_PrefixConf);
                    }
                    else
                    {
                        _PrefixConf.ConfigValues = txtTagPrefix.Texts.Trim();
                    }
                    #endregion

                    #region SYSIOTFIXEDRE
                    ConfigMaster _SYSIOTFIXEDREIP = _Entities.ConfigMasters.FirstOrDefault(f => f.ConfigKey == "SYSIOTFIXEDREIP");
                    if (_SYSIOTFIXEDREIP == null)
                    {
                        _SYSIOTFIXEDREIP = new ConfigMaster();
                        _SYSIOTFIXEDREIP.ConfigKey = "SYSIOTFIXEDREIP";
                        _SYSIOTFIXEDREIP.ConfigValues = txtSYSOTReaderIP.Texts.Trim();
                        _SYSIOTFIXEDREIP.IsShow = true;
                        _Entities.ConfigMasters.Add(_SYSIOTFIXEDREIP);
                    }
                    else
                    {
                        _SYSIOTFIXEDREIP.ConfigValues = txtSYSOTReaderIP.Texts.Trim();
                    }
                    ConfigMaster _SYSIOTFIXEDREPORT = _Entities.ConfigMasters.FirstOrDefault(f => f.ConfigKey == "SYSIOTFIXEDREPORT");
                    if (_SYSIOTFIXEDREPORT == null)
                    {
                        _SYSIOTFIXEDREPORT = new ConfigMaster();
                        _SYSIOTFIXEDREPORT.ConfigKey = "SYSIOTFIXEDREPORT";
                        _SYSIOTFIXEDREPORT.ConfigValues = txtSYSOTReaderPort.Texts.Trim();
                        _SYSIOTFIXEDREPORT.IsShow = true;
                        _Entities.ConfigMasters.Add(_SYSIOTFIXEDREPORT);
                    }
                    else
                    {
                        _SYSIOTFIXEDREPORT.ConfigValues = txtSYSOTReaderPort.Texts.Trim();
                    }
                    #endregion


                    #region CIRFID FIXED READER
                    ConfigMaster _CIRFIDFIXEDREIP = _Entities.ConfigMasters.FirstOrDefault(f => f.ConfigKey == "CIRFIDFIXEDREIP");
                    if (_CIRFIDFIXEDREIP == null)
                    {
                        _CIRFIDFIXEDREIP = new ConfigMaster();
                        _CIRFIDFIXEDREIP.ConfigKey = "CIRFIDFIXEDREIP";
                        _CIRFIDFIXEDREIP.ConfigValues = txtCirfidIP.Texts.Trim();
                        _CIRFIDFIXEDREIP.IsShow = true;
                        _Entities.ConfigMasters.Add(_CIRFIDFIXEDREIP);
                    }
                    else
                    {
                        _SYSIOTFIXEDREIP.ConfigValues = txtCirfidIP.Texts.Trim();
                    }
                    ConfigMaster _CIRFIDFIXEDREPORT = _Entities.ConfigMasters.FirstOrDefault(f => f.ConfigKey == "CIRFIDFIXEDREPORT");
                    if (_CIRFIDFIXEDREPORT == null)
                    {
                        _CIRFIDFIXEDREPORT = new ConfigMaster();
                        _CIRFIDFIXEDREPORT.ConfigKey = "CIRFIDFIXEDREPORT";
                        _CIRFIDFIXEDREPORT.ConfigValues = txtCirfidPort.Texts.Trim();
                        _CIRFIDFIXEDREPORT.IsShow = true;
                        _Entities.ConfigMasters.Add(_CIRFIDFIXEDREPORT);
                    }
                    else
                    {
                        _CIRFIDFIXEDREPORT.ConfigValues = txtCirfidPort.Texts.Trim();
                    }
                    #endregion

                    #region ReaderAntennaPower

                    ConfigMaster _ReaderAntennaPower = _Entities.ConfigMasters.FirstOrDefault(f => f.ConfigKey == "ReaderAntennaPower");
                    if (_ReaderAntennaPower == null)
                    {
                        _ReaderAntennaPower = new ConfigMaster();
                        _ReaderAntennaPower.ConfigKey = "ReaderAntennaPower";
                        _ReaderAntennaPower.ConfigValues = String.IsNullOrEmpty(cbmPower.SelectedItem.ToString()) ? "" : cbmPower.SelectedItem.ToString();
                        _ReaderAntennaPower.IsShow = true;
                        _Entities.ConfigMasters.Add(_ReaderAntennaPower);
                    }
                    else
                    {
                        _ReaderAntennaPower.ConfigValues = String.IsNullOrEmpty(cbmPower.SelectedItem.ToString()) ? "" : cbmPower.SelectedItem.ToString();
                    }

                    #endregion

                    _Entities.SaveChanges();
                    var msgresult = RJMessageBox.Show("Configuration saved successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (msgresult == DialogResult.OK || msgresult == DialogResult.Cancel)
                    {

                    }

                }
            }
            catch (Exception ex)
            {
                string ErrorMsg = Common.GetString(ex);
                RJMessageBox.Show(ErrorMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void txtTagPrefix__TextChanged(object sender, EventArgs e)
        {
            txtPrefixHex.Texts = Common.ConvertASCIItoHex(txtTagPrefix.Texts);
        }

        private void txtSYSOTReaderIP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtCirfidPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
