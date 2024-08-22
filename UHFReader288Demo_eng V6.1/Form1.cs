using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Resources;
using System.Reflection;
using System.Net;
using System.Threading;
using System.Diagnostics;
using UHF;
using System.IO;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Net.NetworkInformation;
using System.Data.SqlClient;
using System.Threading.Tasks;

using System.Data.OleDb;
using System.Transactions;
using System.Net.Http;
using System.IO.Ports;
using Microsoft.AspNetCore.SignalR.Client;
using System.Xml.Linq;
using Newtonsoft.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using System.Management;
using System.Security.Cryptography;
using System.Windows.Forms.DataVisualization.Charting;
using System.Configuration;


namespace UHFReader288Demo
{
    public partial class Form1 : Form
    {
        private ManagementEventWatcher arrival;
        private ManagementEventWatcher removal;

        [DllImport("User32.dll", EntryPoint = "PostMessage")]
        private static extern int PostMessage(
        IntPtr hWnd, // handle to destination window 
        uint Msg, // message 
        uint wParam, // first message parameter 
        uint lParam // second message parameter 
        );

        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, string lParam);

        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        public const int USER = 0x0400;
        public const int WM_SENDTAG = USER + 101;
        public const int WM_SENDTAGSTAT = USER + 102;
        public const int WM_SENDSTATU = USER + 103;
        public const int WM_SENDBUFF = USER + 104;
        public const int WM_MIXTAG = USER + 105;
        public const int WM_SHOWNUM = USER + 106;
        public const int WM_FASTID = USER + 107;
        public const int WM_JB_MIX = USER + 108;
        public const int WM_JB_TAG = USER + 109;
        public const int WM_GB_MIX = USER + 110;
        public const int WM_GB_TAG = USER + 111;
        public static byte fComAdr = 0xff;
        private int ferrorcode;
        private byte fBaud;
        private double fdminfre;
        private double fdmaxfre;
        private int fCmdRet = 30;
        private bool fisinventoryscan_6B;
        private byte[] fOperEPC = new byte[100];
        private byte[] fPassWord = new byte[4];
        private byte[] fOperID_6B = new byte[10];
        ArrayList list = new ArrayList();
        private List<string> epclist = new List<string>();
        private List<string> tidlist = new List<string>();
        private int CardNum1 = 0;
        private string fInventory_EPC_List;
        public static int frmcomportindex;
        //private bool SeriaATflag = false;
        private byte Target = 0;
        private byte InAnt = 0;
        private byte Scantime = 0;
        private byte FastFlag = 0;
        private byte Qvalue = 0;
        private byte Session = 0;

        private int total_tagnum = 0;
        private int CardNum = 0;
        private int NewCardNum = 0;
        private int total_time = 0;
        private int targettimes = 0;
        private byte TIDFlag = 0;
        private byte tidLen = 0;
        private byte tidAddr = 0;
        public static byte antinfo = 0;
        private int AA_times = 0;
        private int CommunicationTime = 0;
        public DeviceClass SelectedDevice;
        private static List<DeviceClass> DevList;
        private static SearchCallBack searchCallBack = new SearchCallBack(searchCB);
        private string ReadTypes = "";


        dataEPC listataEPC;

        private static object LockFlag = new object();

      
        private static void searchCB(IntPtr dev, IntPtr data)
        {
            uint ipAddr = 0;
            StringBuilder devname = new StringBuilder(100);
            StringBuilder macAdd = new StringBuilder(100);
            DevControl.tagErrorCode eCode = DevControl.DM_GetDeviceInfo(dev, ref ipAddr, macAdd, devname);
            if (eCode == DevControl.tagErrorCode.DM_ERR_OK)
            {
                DeviceClass device = new DeviceClass(dev, ipAddr, macAdd.ToString(), devname.ToString());
                DevList.Add(device);
            }
            else
            {
                string errMsg = ErrorHandling.GetErrorMsg(eCode);
                Log.WriteError(errMsg);
            }

        }
       
        RFIDCallBack elegateRFIDCallBack;

        RfidTagCallBack myCallBack;

        private NamedPipeServer pipeServer;
        public Form1()
        {
            InitializeComponent();
            //UpdateSerialPortList();
            //StartListeningForSerialPortChanges();
            ComboBox_COM.SelectedIndex = 10;
            ComboBox_baud2.SelectedIndex = 4;

            comboBoxPort.SelectedIndex = 9;
            comboBoxBaud.SelectedIndex = 4;
            ComboBox_PowerDbm.SelectedIndex = 26;
            //timer1.Interval = 300;
            timer2.Interval = 5000;


            DevControl.tagErrorCode eCode = DevControl.DM_Init(searchCallBack, IntPtr.Zero);
            if (eCode != DevControl.tagErrorCode.DM_ERR_OK)
            {
                string errMsg = ErrorHandling.HandleError(eCode);
                throw new Exception(errMsg);
            }
            elegateRFIDCallBack = new RFIDCallBack(GetUid);
            myCallBack = new RfidTagCallBack(GetEPC);
            InitializeDataTable();

            //LoadBaudRates();
            LoadSavedSettings();
            ConnectToPortsMCU();
            ConnectToPortsReader();

            serialPort2.DataReceived += new SerialDataReceivedEventHandler(serialPort2_DataReceived);

        }
        private async void ConnectToPortsReader()
        {
           
                int portNum = ComboBox_COM.SelectedIndex + 1;
                int FrmPortIndex = 0;
                string strException = string.Empty;
                fBaud = Convert.ToByte(ComboBox_baud2.SelectedIndex);
                if (fBaud > 2)
                    fBaud = Convert.ToByte(fBaud + 2);
                fComAdr = 255;
                fCmdRet = RWDev.OpenComPort(portNum, ref fComAdr, fBaud, ref FrmPortIndex);
                if (fCmdRet != 0)
                {
                    string strLog = "Connect reader failed: " + GetReturnCodeDesc(fCmdRet);
                    WriteLog(lrtxtLog, strLog, 1);
                    return;
                }
                else
                {
                    frmcomportindex = FrmPortIndex;
                    string strLog = "Connected: " + ComboBox_COM.Text + "@" + ComboBox_baud2.Text;
                    WriteLog(lrtxtLog, strLog, 0);
                    
                    btConnect232.Enabled = false;
                    btDisConnect232.Enabled = true;

                    btConnect232.ForeColor = Color.Black;
                    btDisConnect232.ForeColor = Color.Indigo;
                    SetButtonBold(btConnect232);
                    SetButtonBold(btDisConnect232);
                    if (FrmPortIndex > 0)
                        RWDev.InitRFIDCallBack(elegateRFIDCallBack, true, FrmPortIndex);
                await Task.Delay(1000);
                EnabledForm();
                }
 
        }
        private void ConnectToPortsMCU()
        {
            try
            {
                serialPort2 = new SerialPort(comboBoxPort.SelectedItem?.ToString(),
                                             int.Parse(comboBoxBaud.SelectedItem?.ToString()));
                serialPort2.Open();
                if (serialPort2.IsOpen)
                {
                    try
                    {
                        Control.CheckForIllegalCrossThreadCalls = false;
                   
                        btConnectMCU.Enabled = false;
                        btDisConnectMCU.Enabled = true;
                        comboBoxPort.Enabled = false;
                        comboBoxBaud.Enabled = false;
                        btConnectMCU.ForeColor = Color.Black;
                        btDisConnectMCU.ForeColor = Color.Indigo;
                    }
                    catch (UnauthorizedAccessException)
                    {
                        MessageBox.Show("Access to the port is denied. Please check if the port is already in use or you do not have the necessary permissions.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                WriteLog(lrtxtLog, "Successfully connected to " + comboBoxPort.SelectedItem?.ToString(), 1);
            }
            catch (Exception ex)
            {
                WriteLog(lrtxtLog, "Failed to connect to Box: " + ex.Message,1);
            }
        }


        static string ExtractPortName(string fullName)
        {
            int startIndex = fullName.IndexOf('(');

            if (startIndex >= 0)
            {
                return fullName.Substring(startIndex + 1, fullName.Length - startIndex - 2);
            }
            return string.Empty;
        }


        private void LoadBaudRates()
        {
          
            string[] baudRates = { "9600", "19200", "38400", "57600", "115200" };
            ComboBox_baud2.Items.AddRange(baudRates);
            comboBoxBaud.Items.AddRange(baudRates);
        }

        private void LoadSavedSettings()
        {
         
            ComboBox_COM.SelectedItem = ConfigurationManager.AppSettings["SelectedCOMPort"];
            ComboBox_baud2.SelectedItem = ConfigurationManager.AppSettings["SelectedBaudRate1"];
            comboBoxPort.SelectedItem = ConfigurationManager.AppSettings["SelectedPort"];
            comboBoxBaud.SelectedItem = ConfigurationManager.AppSettings["SelectedBaudRate2"];
            ComboBox_PowerDbm.SelectedItem = ConfigurationManager.AppSettings["SelectedPower"];
        }

        private void SaveSettings()
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        
            config.AppSettings.Settings.Remove("SelectedCOMPort");
            config.AppSettings.Settings.Add("SelectedCOMPort", ComboBox_COM.SelectedItem?.ToString());

            config.AppSettings.Settings.Remove("SelectedBaudRate1");
            config.AppSettings.Settings.Add("SelectedBaudRate1", ComboBox_baud2.SelectedItem?.ToString());

            config.AppSettings.Settings.Remove("SelectedPort");
            config.AppSettings.Settings.Add("SelectedPort", comboBoxPort.SelectedItem?.ToString());

            config.AppSettings.Settings.Remove("SelectedBaudRate2");
            config.AppSettings.Settings.Add("SelectedBaudRate2", comboBoxBaud.SelectedItem?.ToString());

            config.AppSettings.Settings.Remove("SelectedPower");
            config.AppSettings.Settings.Add("SelectedPower", ComboBox_PowerDbm.SelectedItem?.ToString());

            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }
        static string ExtractDeviceDescription(string fullName)
        {
            int startIndex = fullName.IndexOf('(');

            if (startIndex >= 0)
            {
                return fullName.Substring(0, startIndex - 1).Trim();
            }
            return fullName;
        }
        private void StartListeningForSerialPortChanges()
        {
            try
            {

                using (var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity WHERE Caption LIKE '%(COM%'"))
                {
                    foreach (var device in searcher.Get())
                    {

                        string deviceName = device["Caption"].ToString();

                        string portName = ExtractPortName(deviceName);
                        string deviceDescription = ExtractDeviceDescription(deviceName);
                        if(deviceDescription == "USB-SERIAL CH340")
                        {
                            comboBoxPort.Items.Add(portName);
                        }
                        else if (deviceDescription == "USB Serial Port")
                        {
                            ComboBox_COM.Items.Add(portName);
                        }

                    }
                }

                    comboBoxPort.SelectedIndex = 0;
                    ComboBox_COM.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting COM port information: " + ex.Message);
            }
        }
        private void StopListeningForSerialPortChanges()
        {
            if (arrival != null)
            {
                arrival.Stop();
                removal.Stop();
            }
        }
        private void UpdateSerialPortList()
        {
            //if (comboBoxPort.InvokeRequired || ComboBox_COM.InvokeRequired)
            //{
            //    comboBoxPort.Invoke(new MethodInvoker(UpdateSerialPortList));
            //    return;
            //}

            //string[] ports = SerialPort.GetPortNames();
            //comboBoxPort.Items.Clear();
            //comboBoxPort.Items.AddRange(ports);

        }
        private void InitializeDataTable()
        {

            dataTable_RSSI.Columns.Add("sEPC", typeof(string));  // Cột cho sEPC
            dataTable_Phase_begin.Columns.Add("sEPC", typeof(string));  // Cột cho sEPC
            dataTable_Phase_end.Columns.Add("sEPC", typeof(string));  // Cột cho sEPC
            dataTable_Antenna.Columns.Add("sEPC", typeof(string));  // Cột cho sEPC
            dataTable_time.Columns.Add("sEPC", typeof(string));  // Cột cho sEPC

        }
        List<RFIDTag> curList = new List<RFIDTag>();

        string epcandtid = "";
        int lastnum = 0;

        public void GetUid(IntPtr p, Int32 nEvt)
        {

            RFIDTag ce = (RFIDTag)Marshal.PtrToStructure(p, typeof(RFIDTag));
            lock (LockFlag)
            {
                curList.Add(ce);
                total_tagnum++;
                CardNum++;
            }
        }


        public void GetEPC(RFIDTag mtag)
        {
            lock (LockFlag)
            {
                curList.Add(mtag);
                total_tagnum++;
            }
        }

        private void SendTagMessage(IntPtr ptrWnd, RFIDTag ce)
        {
            //if (mythread != null)
            //{

            //    int Antnum = ce.ANT;
            //    string str_ant = GetAntennaNumber(Antnum).ToString();// Convert.ToString(Antnum, 2).PadLeft(4, '0');
            //    string epclen = ce.LEN.ToString();// Convert.ToString(ce.LEN, 16);
            //    string para = str_ant + "," + epclen + "," + ce.UID + "," + ce.RSSI.ToString() + "," + ce.phase_begin + "," + ce.phase_end + "," + ce.Freqkhz;
            //    SendMessage(ptrWnd, WM_SENDTAG, IntPtr.Zero, para);

            //}

            if (mythread != null)
            {
                
                    int Antnum = ce.ANT;
                    string str_ant = GetAntennaNumber(Antnum).ToString();// Convert.ToString(Antnum, 2).PadLeft(4, '0');
                    string epclen = ce.LEN.ToString();// Convert.ToString(ce.LEN, 16);
                    string para = str_ant + "," + epclen + "," + ce.UID + "," + ce.RSSI.ToString() + "," + ce.phase_begin + "," + ce.phase_end + "," + ce.Freqkhz;
                    SendMessage(ptrWnd, WM_SENDTAG, IntPtr.Zero, para);
                
            }
            else if (jbthread != null)
            {
               
                    int Antnum = ce.ANT;
                    string str_ant = GetAntennaNumber(Antnum).ToString();
                    string epclen = ce.LEN.ToString();
                    string para = str_ant + "," + epclen + "," + ce.UID + "," + ce.RSSI.ToString();
                    SendMessage(ptrWnd, WM_JB_TAG, IntPtr.Zero, para);
                
            }
            else if (gbthread != null)
            {
               
                    int Antnum = ce.ANT;
                    string str_ant = GetAntennaNumber(Antnum).ToString();
                    string epclen = ce.LEN.ToString();
                    string para = str_ant + "," + epclen + "," + ce.UID + "," + ce.RSSI.ToString() + " ";
                    SendMessage(ptrWnd, WM_GB_TAG, IntPtr.Zero, para);
                
            }

        }
        private int GetAntennaNumber(int ant)
        {
            int Antenna = 1;
            if (AntennaNum > 8)
            {
                return ant + 1;
            }
            else
            {
                switch (ant)
                {
                    case 0x01:
                        Antenna = 1;
                        break;
                    case 0x02:
                        Antenna = 2;
                        break;
                    case 0x04:
                        Antenna = 3;
                        break;
                    case 0x08:
                        Antenna = 4;
                        break;
                    case 0x10:
                        Antenna = 5;
                        break;
                    case 0x20:
                        Antenna = 6;
                        break;
                    case 0x40:
                        Antenna = 7;
                        break;
                    case 0x80:
                        Antenna = 8;
                        break;
                }
            }
            return Antenna;
        }
        DataTable dt = null;
        int scanType = 0;
        protected override void DefWndProc(ref Message m)
        {
            if (m.Msg == WM_SENDTAG) //--------------------------------------here----------------------------------
            {

                string tagInfo = Marshal.PtrToStringAnsi(m.LParam);
                string[] btArr = tagInfo.Split(',');
                string sEPC;
                string str_ant = btArr[0];
                sEPC = btArr[2];
                string str_epclen = btArr[1]; ;
                byte epclen = Convert.ToByte(str_epclen, 10);
                string RSSI = btArr[3];
                int phase_begin = Convert.ToInt32(btArr[4], 10);
                int phase_end = Convert.ToInt32(btArr[5], 10);
                int freqkhz = Convert.ToInt32(btArr[6], 10);
                if (scanType == 0)
                {
                   updateEPC(sEPC, RSSI, str_ant, phase_begin, phase_end, freqkhz); 
                }
                   

                bool flagset = false;
                flagset = (dataGridView1.DataSource == null) ? true : false;
                dataGridView1.DataSource = dt;

                if (flagset)
                {
                    dataGridView1.Columns["Column1"].HeaderText = "No.";
                    dataGridView1.Columns["Column1"].Width = 60;
                    dataGridView1.Columns["Column2"].HeaderText = "EPC";
                    dataGridView1.Columns["Column2"].Width = 170;
                    dataGridView1.Columns["Column3"].HeaderText = "Count";
                    dataGridView1.Columns["Column3"].Width = 60;
                    dataGridView1.Columns["Column4"].HeaderText = "RSSI";
                    dataGridView1.Columns["Column4"].Width = 60;
                    dataGridView1.Columns["Column5"].HeaderText = "Phase_begin";
                    dataGridView1.Columns["Column5"].Width = 80;
                    dataGridView1.Columns["Column6"].HeaderText = "Phase_end";
                    dataGridView1.Columns["Column6"].Width = 80;
                    dataGridView1.Columns["Column7"].HeaderText = "Antenna";
                    dataGridView1.Columns["Column7"].Width = 80;
                    dataGridView1.Columns["Column8"].HeaderText = "Freq(khz)";
                    dataGridView1.Columns["Column8"].Width = 90;
                }
                //Console.WriteLine("WM_SENDTAG");
            } else if (m.Msg == WM_SENDTAGSTAT)
            {
                string tagInfo = Marshal.PtrToStringAnsi(m.LParam);
                int index = tagInfo.IndexOf(',');
                string tagRate = tagInfo.Substring(0, index);
                index++;
                string str = tagInfo.Substring(index);
                index = str.IndexOf(',');
                string tagNum = str.Substring(0, index);
                index++;
                string cmdTime = str.Substring(index);

                lxLedControl2.Text = tagRate;
                lxLedControl3.Text = cmdTime;
                lxLedControl4.Text = tagNum;
            }
            else if (m.Msg == WM_SENDSTATU)
            {
                string Info = Marshal.PtrToStringAnsi(m.LParam);
                fCmdRet = Convert.ToInt32(Info);
                string strLog = "Inventory: " + GetReturnCodeDesc(fCmdRet);
            }
            else if (m.Msg == WM_SENDBUFF)
            {
                string tagInfo = Marshal.PtrToStringAnsi(m.LParam);
                int index = tagInfo.IndexOf(',');
                string tagNum = tagInfo.Substring(0, index);
                index++;

                string str = tagInfo.Substring(index);
                index = str.IndexOf(',');
                string cmdTime = str.Substring(0, index);
                index++;

                str = str.Substring(index);
                index = str.IndexOf(',');
                string tagRate = str.Substring(0, index);
                index++;

                str = str.Substring(index);
                string total_tagnum = str;

                WriteLog(lrtxtLog, "Inventory_Buffer:Success", 1);
            }
            else if (m.Msg == WM_SHOWNUM)
            {
                if (mythread != null)
                    lxLedControl5.Text = (System.Environment.TickCount - total_time).ToString();


            }
            else
                base.DefWndProc(ref m);
        }

        int ctnNumberEPC = 0;
        DataTable dataTable_RSSI = new DataTable();
        DataTable dataTable_Phase_begin = new DataTable();
        DataTable dataTable_Phase_end = new DataTable();
        DataTable dataTable_Antenna = new DataTable();
        DataTable dataTable_time = new DataTable();
        private void updateEPC(string sEPC, string RSSI, string str_ant, int phase_begin, int phase_end, int freqkhz)
        {
            //Console.WriteLine(dt.Rows.Count);

            if (epclist.Count == 0) //có EPC đầu tiên
            {
               
                epclist.Add(sEPC);
                NewCardNum++;
                ctnNumberEPC++;
                dt = dataGridView1.DataSource as DataTable;

                if (dt == null)
                {
                    dt = new DataTable();
                    dt.Columns.Add("Column1", Type.GetType("System.String"));
                    dt.Columns.Add("Column2", Type.GetType("System.String"));
                    dt.Columns.Add("Column3", Type.GetType("System.String"));
                    dt.Columns.Add("Column4", Type.GetType("System.String"));
                    dt.Columns.Add("Column5", Type.GetType("System.String"));
                    dt.Columns.Add("Column6", Type.GetType("System.String"));
                    dt.Columns.Add("Column7", Type.GetType("System.String"));
                    dt.Columns.Add("Column8", Type.GetType("System.String"));
                    DataRow dr = dt.NewRow();
                    dr["Column1"] = (dt.Rows.Count + 1).ToString();
                    dr["Column2"] = sEPC;
                    dr["Column3"] = "1";
                    dr["Column4"] = RSSI;
                    dr["Column5"] = String.Format("{0:N3}", phase_begin * 0.087f % 180);
                    dr["Column6"] = String.Format("{0:N3}", phase_end * 0.087f % 180);
                    dr["Column7"] = str_ant;
                    dr["Column8"] = freqkhz + "";
                    dt.Rows.Add(dr);
                }

            }
            else
            {
                int index = epclist.IndexOf(sEPC);
                if (index == -1)// có EPC mới thứ 2 trở đi
                {


                    NewCardNum++;
                    ctnNumberEPC++;
                    epclist.Add(sEPC);

                    DataRow dr2 = dt.NewRow();
                    dr2["Column1"] = (dt.Rows.Count + 1).ToString();
                    dr2["Column2"] = sEPC;
                    dr2["Column3"] = "1";
                    dr2["Column4"] = RSSI;
                    dr2["Column5"] = String.Format("{0:N3}", phase_begin * 0.087f % 180);
                    dr2["Column6"] = String.Format("{0:N3}", phase_end * 0.087f % 180);
                    dr2["Column7"] = str_ant;
                    dr2["Column8"] = freqkhz + "";
                    dt.Rows.Add(dr2);

                }
                else
                {

                    DataRow dr = dt.Rows[index];
                    int cnt = int.Parse(dr["Column3"].ToString());
                    cnt++;
                    dt.Rows[index]["Column3"] = cnt.ToString();
                    dt.Rows[index]["Column4"] = RSSI;
                    dt.Rows[index]["Column5"] = String.Format("{0:N3}", phase_begin * 0.087f % 180);
                    dt.Rows[index]["Column6"] = String.Format("{0:N3}", phase_end * 0.087f % 180);
                    dt.Rows[index]["Column7"] = str_ant;
                    dt.Rows[index]["Column8"] = freqkhz + "";
                    

                }
            }

            //Console.WriteLine(str_ant);
            //UpdateDataEPCApi();
        }
        private async void RemoveDataEpc(string targetEPC)
        {
            bool found = false;
            //timer1.Enabled = false;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    if (row.Cells[1].Value != null && row.Cells[1].Value.ToString() == targetEPC)
                    {
                        row.Cells[1].Value = null;
                        epclist.Remove(targetEPC);

                        dataGridView1.Rows.Remove(row);
                        UpdateDataEPCApi();

                        found = true;
                        break;
                        
                    }
                }
            }

            if (found)
            {

                pipeServer.SetMessage("ok");
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (!dataGridView1.Rows[i].IsNewRow)
                    {
                        dataGridView1.Rows[i].Cells[0].Value = (i + 1).ToString();
                    }
                }
            }
            else
            {
                pipeServer.SetMessage("notexist");
            }

            
  

            //timer1.Enabled = true;
        }


       

        private void UpdateDataEPCApi()
        {
            //StopscanData();
            pipeServer.ClearAllData();

            if (dataGridView1.DataSource is DataTable dt)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        if (row.Cells[1].Value != null && !string.IsNullOrEmpty(row.Cells[1].Value.ToString()))
                        {
                            string epc = row.Cells[1].Value.ToString();
                            int ctn = 0;
                            if (int.TryParse(row.Cells[2].Value?.ToString(), out ctn))
                            {
                                dataEPC bufferEPC = new dataEPC(epc, ctn, DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"));
                                pipeServer.AddData(bufferEPC);

                            }
                            else
                            {
                                Console.WriteLine($"Invalid count value for EPC: {epc}");
                            }
                        }
                    }
                }
            }
        }

        private void AddOrUpdateData(DataTable dataTable, string sEPC, int index, string RSSI, int cnt)
        {
            DataRow row = dataTable.AsEnumerable().FirstOrDefault(r => r["sEPC"].ToString() == sEPC);
            if (row == null)
            {
                row = dataTable.NewRow();
                row["sEPC"] = sEPC;
                dataTable.Rows.Add(row);
            }
            string columnName = $"{cnt}";
            if (!dataTable.Columns.Contains(columnName))
            {
                dataTable.Columns.Add(columnName, typeof(string));
            }
            row[columnName] = RSSI;
        }

        private int GetNextRSSIColumnIndex(DataRow row)
        {
            int index = 1;
            while (row.Table.Columns.Contains($"RSSI{index}"))
            {
                index++;
            }
            return index;
        }

      
      


        private delegate void WriteLogUnSafe(CustomControl.LogRichTextBox logRichTxt, string strLog, int nType);
        private void WriteLog(CustomControl.LogRichTextBox logRichTxt, string strLog, int nType)
        {
            if (this.InvokeRequired)
            {
                WriteLogUnSafe InvokeWriteLog = new WriteLogUnSafe(WriteLog);
                this.Invoke(InvokeWriteLog, new object[] { logRichTxt, strLog, nType }); ;

            }
            else
            {

                if ((ckClearOperationRec.Checked) && (lrtxtLog.Lines.Length > 20))
                    lrtxtLog.Clear();
                if ((nType == 0) || (nType == 0x26) || (nType == 0x01) || (nType == 0x02) || (nType == 0xFB))
                {
                    logRichTxt.AppendTextEx(strLog, Color.Indigo);
                }
                else
                {
                    logRichTxt.AppendTextEx(strLog, Color.Red);
                }

                logRichTxt.Select(logRichTxt.TextLength, 0);
                logRichTxt.ScrollToCaret();
            }
        }

        #region
        public static byte[] HexStringToByteArray(string s)
        {
            s = s.Replace(" ", "");
            byte[] buffer = new byte[s.Length / 2];
            for (int i = 0; i < s.Length; i += 2)
                buffer[i / 2] = (byte)Convert.ToByte(s.Substring(i, 2), 16);
            return buffer;
        }

        public static string ByteArrayToHexString(byte[] data)
        {
            StringBuilder sb = new StringBuilder(data.Length * 3);
            foreach (byte b in data)
                sb.Append(Convert.ToString(b, 16).PadLeft(2, '0'));
            return sb.ToString().ToUpper();

        }
        #endregion

        #region 
        private string GetReturnCodeDesc(int cmdRet)
        {
            switch (cmdRet)
            {
                case 0x00:
                case 0x26:
                    return "success";
                case 0x01:
                    return "Return before Inventory finished";
                case 0x02:
                    return "the Inventory-scan-time overflow";
                case 0x03:
                    return "More Data";
                case 0x04:
                    return "Reader module MCU is Full";
                case 0x05:
                    return "Access Password Error";
                case 0x09:
                    return "Destroy Password Error";
                case 0x0a:
                    return "Destroy Password Error Cannot be Zero";
                case 0x0b:
                    return "Tag Not Support the command";
                case 0x0c:
                    return "Use the commmand,Access Password Cannot be Zero";
                case 0x0d:
                    return "Tag is protected,cannot set it again";
                case 0x0e:
                    return "Tag is unprotected,no need to reset it";
                case 0x10:
                    return "There is some locked bytes,write fail";
                case 0x11:
                    return "can not lock it";
                case 0x12:
                    return "is locked,cannot lock it again";
                case 0x13:
                    return "Parameter Save Fail,Can Use Before Power";
                case 0x14:
                    return "Cannot adjust";
                case 0x15:
                    return "Return before Inventory finished";
                case 0x16:
                    return "Inventory-Scan-Time overflow";
                case 0x17:
                    return "More Data";
                case 0x18:
                    return "Reader module MCU is full";
                case 0x19:
                    return "'Not Support Command Or AccessPassword Cannot be Zero";
                case 0x1A:
                    return "Tag custom function error";
                case 0xF8:
                    return "Check antenna error";
                case 0xF9:
                    return "Command execute error";
                case 0xFA:
                    return "Get Tag,Poor Communication,Inoperable";
                case 0xFB:
                    return "No Tag Operable";
                case 0xFC:
                    return "Tag Return ErrorCode";
                case 0xFD:
                    return "Command length wrong";
                case 0xFE:
                    return "Illegal command";
                case 0xFF:
                    return "Parameter Error";
                case 0x30:
                    return "Communication error";
                case 0x31:
                    return "CRC checksummat error";
                case 0x32:
                    return "Return data length error";
                case 0x33:
                    return "Communication busy";
                case 0x34:
                    return "Busy,command is being executed";
                case 0x35:
                    return "ComPort Opened";
                case 0x36:
                    return "ComPort Closed";
                case 0x37:
                    return "Invalid Handle";
                case 0x38:
                    return "Invalid Port";
                case 0xEE:
                    return "Return Command Error";
                default:
                    return Convert.ToString(cmdRet, 16);
            }
        }
        private string GetErrorCodeDesc(int cmdRet)
        {
            switch (cmdRet)
            {
                case 0x00:
                    return "Other error";
                case 0x03:
                    return "Memory out or pc not support";
                case 0x04:
                    return "Memory Locked and unwritable";
                case 0x0b:
                    return "No Power,memory write operation cannot be executed";
                case 0x0f:
                    return "Not Special Error,tag not support special errorcode";
                default:
                    return "";
            }
        }
        #endregion
        private void DisabledForm()
        {
            lxLedControl1.Text = "0";
            lxLedControl2.Text = "0";
            lxLedControl3.Text = "0";
            lxLedControl4.Text = "0";
            lxLedControl5.Text = "0";
            // dataGridView1.DataSource = null;
            //text_RDVersion.Text = "";
            text_MDVersion.Text = "";
            text_Serial.Text = "";
            timer_answer.Enabled = false;
            btIventoryG2.Text = "Start";
            chk_phase.Enabled = false;
            gpb_address.Enabled = false;
            gpb_antconfig.Enabled = false;
            gpb_baud.Enabled = false;
            gpb_GPIO.Enabled = false;
            gpb_beep.Enabled = false;
            gpb_MDVersion.Enabled = false;
            //gpb_RDVersion.Enabled = false;
            gpb_checkant.Enabled = false;
            gpb_DBM.Enabled = false;
            gpb_Serial.Enabled = false;
            gpb_Relay.Enabled = false;
            gpb_OutputRep.Enabled = false;
            gpb_Freq.Enabled = false;
            gbp_buff.Enabled = false;
            btDefault.Enabled = false;
            //btGetInformation.Enabled = false;
            btFlashROM.Enabled = false;
            group_maxtime.Enabled = false;
            gbp_wpower.Enabled = false;
            gbp_Retry.Enabled = false;
            gbp_DRM.Enabled = false;
            gbCmdTemperature.Enabled = false;
            gbReturnLoss.Enabled = false;
            groupBox45.Enabled = false;
            panel11.Enabled = false;

        }
        private void EnabledForm()
        {
            chk_phase.Enabled = true;
            gpb_address.Enabled = true;
            gpb_antconfig.Enabled = true;
            gpb_baud.Enabled = true;
            gpb_GPIO.Enabled = true;
            gpb_beep.Enabled = true;
            gpb_MDVersion.Enabled = true;
            //gpb_RDVersion.Enabled = true;
            gpb_checkant.Enabled = true;
            gpb_DBM.Enabled = true;
            gpb_Serial.Enabled = true;
            gpb_Relay.Enabled = true;
            gpb_OutputRep.Enabled = true;
            gpb_Freq.Enabled = true;
            gbp_buff.Enabled = true;
            btDefault.Enabled = true;
            //btGetInformation.Enabled = true;
            btFlashROM.Enabled = true;
            group_maxtime.Enabled = true;
            gbp_wpower.Enabled = true;
            gbp_Retry.Enabled = true;
            gbp_DRM.Enabled = true;
            gbCmdTemperature.Enabled = true;
            gbReturnLoss.Enabled = true;
            groupBox45.Enabled = true;
            panel11.Enabled = true;
        }
        private void rb_rs232_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_rs232.Checked)
            {
                if ((frmcomportindex > 0) && (frmcomportindex < 256))
                {
                    if (frmcomportindex > 0)
                        fCmdRet = RWDev.CloseNetPort(frmcomportindex);
                    if (fCmdRet == 0)
                    {
                        frmcomportindex = -1;
                        DisabledForm();
                    }
                    if (fCmdRet != 0)
                    {
                        string strLog = "TCP close failed: " + GetReturnCodeDesc(fCmdRet);
                        WriteLog(lrtxtLog, strLog, 1);

                        return;
                    }
                    else
                    {
                        string strLog = "TCP close success";
                        WriteLog(lrtxtLog, strLog, 0);
                    }


                }

                gpb_rs232.Enabled = true;
                btDisConnect232.Enabled = false;
                btConnect232.ForeColor = Color.Indigo;
                SetButtonBold(btConnect232);


            }
        }
        private void SetButtonBold(Button btnBold)
        {
            Font oldFont = btnBold.Font;
            Font newFont = new Font(oldFont, oldFont.Style ^ FontStyle.Bold);
            btnBold.Font = newFont;
        }

        private void SetRadioButtonBold(CheckBox ckBold)
        {
            Font oldFont = ckBold.Font;
            Font newFont = new Font(oldFont, oldFont.Style ^ FontStyle.Bold);
            ckBold.Font = newFont;
        }

        public static string[] GetNetWorkInfo()
        {
            List<string> netWorkList = new List<string>();
            NetworkInterface[] NetworkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface NetworkIntf in NetworkInterfaces)
            {
                IPInterfaceProperties IPInterfaceProperties = NetworkIntf.GetIPProperties();
                UnicastIPAddressInformationCollection UnicastIPAddressInformationCollection = IPInterfaceProperties.UnicastAddresses;
                foreach (UnicastIPAddressInformation UnicastIPAddressInformation in UnicastIPAddressInformationCollection)
                {
                    if (UnicastIPAddressInformation.Address.AddressFamily == AddressFamily.InterNetwork)
                    {
                        string IP = UnicastIPAddressInformation.Address.ToString();
                        if (IP != "127.0.0.1")
                        {
                            if (NetworkIntf.OperationalStatus == OperationalStatus.Up)
                            {
                                netWorkList.Add(IP + ":" + NetworkIntf.Name + ":" + NetworkIntf.Description);
                            }
                        }
                    }
                }
            }
            return netWorkList.ToArray();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
            string[] network = GetNetWorkInfo();
   

            gpb_rs232.Enabled = true;

            rb_rs232.Checked = true;

            com_Q.SelectedIndex = 4;
            com_Target.SelectedIndex = 0;
            int i = 0;
            for (i = 0x00; i <= 0xff; i++)
            {
                com_scantime.Items.Add(Convert.ToString(i) + "*100ms");
                comboBox_maxtime.Items.Add(Convert.ToString(i) + "*100ms");
            }
            com_scantime.SelectedIndex = 50;
            comboBox_maxtime.SelectedIndex = 0;
            com_S.SelectedIndex = 5;
            DisabledForm();
            radioButton_band2.Checked = true;
            ComboBox_baud.SelectedIndex = 3;
            
            for (i = 1; i < 256; i++)
            {
                ComboBox_RelayTime.Items.Add(Convert.ToString(i));
            }
            for (i = 2; i < 256; i++)
            {
                cbb_dwell.Items.Add(Convert.ToString(i) + "*100ms");
            }
            cbb_dwell.SelectedIndex = 0;
            ComboBox_RelayTime.SelectedIndex = 0;
            ComboBox_RelayTime.SelectedIndex = 0;
            com_wpower.SelectedIndex = 30;
            com_retrytimes.SelectedIndex = 3;
            com_MixMem.SelectedIndex = 2;
            cbbAnt.SelectedIndex = 0;

            com_queryInter.SelectedIndex = 0;
            cbb_add.SelectedIndex = 4;

            for (i = 1; i < 62; i++)
            {
                comboBox6.Items.Add(i);
            }

            ConnectToHub();

            pipeServer = new NamedPipeServer();
            DevList = new List<DeviceClass>();
            button4.Enabled = false;

        }

        private void btConnect232_Click(object sender, EventArgs e)
        {
            int portNum = ComboBox_COM.SelectedIndex + 1 ;
            int FrmPortIndex = 0;
            string strException = string.Empty;
            fBaud = Convert.ToByte(ComboBox_baud2.SelectedIndex);
            if (fBaud > 2)
                fBaud = Convert.ToByte(fBaud + 2);
            fComAdr = 255;
            fCmdRet = RWDev.OpenComPort(portNum, ref fComAdr, fBaud, ref FrmPortIndex);
            if (fCmdRet != 0)
            {
                string strLog = "Connect reader failed: " + GetReturnCodeDesc(fCmdRet);
                WriteLog(lrtxtLog, strLog, 1);
                return;
            }
            else
            {
                frmcomportindex = FrmPortIndex;
                string strLog = "Connected: " + ComboBox_COM.Text + "@" + ComboBox_baud2.Text;
                WriteLog(lrtxtLog, strLog, 0);
            }
            EnabledForm();
            btConnect232.Enabled = false;
            btDisConnect232.Enabled = true;

            btConnect232.ForeColor = Color.Black;
            btDisConnect232.ForeColor = Color.Indigo;
            SetButtonBold(btConnect232);
            SetButtonBold(btDisConnect232);
            //btGetInformation_Click(null, null);
            if (FrmPortIndex > 0)
                RWDev.InitRFIDCallBack(elegateRFIDCallBack, true, FrmPortIndex);

            SaveSettings();
        }

        private void btDisConnect232_Click(object sender, EventArgs e)
        {
            if (frmcomportindex > 0)
                fCmdRet = RWDev.CloseSpecComPort(frmcomportindex);
            if (fCmdRet == 0)
            {
                frmcomportindex = -1;
                DisabledForm();
                btConnect232.Enabled = true;
                btDisConnect232.Enabled = false;

                btConnect232.ForeColor = Color.Indigo;
                btDisConnect232.ForeColor = Color.Black;
                SetButtonBold(btConnect232);
                SetButtonBold(btDisConnect232);
            }
            if (fCmdRet != 0)
            {
                string strLog = "COM close failed: " + GetReturnCodeDesc(fCmdRet);
                WriteLog(lrtxtLog, strLog, 1);

                return;
            }
            else
            {
                string strLog = "COM close success";
                WriteLog(lrtxtLog, strLog, 0);
            }
        }

        public void refesh(){

            dataTable_RSSI.Clear();
            dataTable_Phase_begin.Clear();
            dataTable_Phase_end.Clear();
            dataTable_Antenna.Clear();
            dataTable_time.Clear();
            ctnNumberEPC = 0;
            lxLedControl1.Text = "0";
            lxLedControl2.Text = "0";
            lxLedControl3.Text = "0";
            lxLedControl4.Text = "0";
            lxLedControl5.Text = "0";
            lxLedControl6.Text = "0";
            epclist.Clear();
            tidlist.Clear();
            dataGridView1.DataSource = null;
    
            total_tagnum = 0;
            total_time = System.Environment.TickCount;
            lrtxtLog.Clear();
            pipeServer.ClearAllData();


        }

        private void btFlashCl_Click(object sender, EventArgs e)
        {
            dataTable_RSSI.Clear();
            dataTable_Phase_begin.Clear();
            dataTable_Phase_end.Clear();
            dataTable_Antenna.Clear();
            dataTable_time.Clear();
            //cbEPC.Items.Clear();

   
            ctnNumberEPC = 0;

            lxLedControl1.Text = "0";
            lxLedControl2.Text = "0";
            lxLedControl3.Text = "0";
            lxLedControl4.Text = "0";
            lxLedControl5.Text = "0";
            lxLedControl6.Text = "0";
            epclist.Clear();
            tidlist.Clear();
            dataGridView1.DataSource = null;
  
            total_tagnum = 0;
            total_time = System.Environment.TickCount;
            lrtxtLog.Clear();
            pipeServer.ClearAllData();

        }
        byte[] antlist = new byte[16];
        private volatile bool fIsInventoryScan = false;
        private volatile bool toStopThread = false;
        private volatile bool reflasg = false;
        private Thread mythread = null;

        byte[] ReadAdr = new byte[2];
        byte[] Psd = new byte[4];
        byte ReadLen = 0;
        byte ReadMem = 0;
        byte RF_Profile = 0;
        byte Profile = 0;
        int readMode = 0;
        int tagrate = 0;
        private void btIventoryG2_Click(object sender, EventArgs e)
        {
            
            if ((text_readadr.Text.Length != 4) || (text_readLen.Text.Length != 2) || (text_readpsd.Text.Length != 8))
            {
                MessageBox.Show("Mix inventory parameter error!!!");
                return;
            }

            if (btIventoryG2.Text == "Start")
            {
                //timer1.Enabled = true;
                btIventoryG2.ForeColor = Color.DarkBlue;
                //lxLedControl1.Text = "0";
                lxLedControl2.Text = "0";
                lxLedControl3.Text = "0";
                lxLedControl4.Text = "0";
                lxLedControl5.Text = "0";
                lxLedControl6.Text = "0";
                //reflasg = false;
                //epclist.Clear();
               // tidlist.Clear();
                //curList.Clear();
                //dataGridView1.DataSource = null;
                //lrtxtLog.Clear();
                //comboBox_EPC.Items.Clear();
                //text_epc.Text = "";
                AA_times = 0;

                Scantime = Convert.ToByte(com_scantime.SelectedIndex);
                if (checkBox_rate.Checked)
                    Qvalue = Convert.ToByte(com_Q.SelectedIndex | 0x80);
                else
                    Qvalue = Convert.ToByte(com_Q.SelectedIndex);

                if (ModeType == 2)
                {
                    Profile = (byte)(RF_Profile | 0xC0);
                    fCmdRet = RWDev.SetProfile(ref fComAdr, ref Profile, frmcomportindex);
                }

                if (com_S.SelectedIndex == 4)
                {
                    readMode = 255;
                }
                else if (com_S.SelectedIndex < 4)
                {
                    readMode = Convert.ToByte(com_S.SelectedIndex);
                }
                else if (com_S.SelectedIndex == 5)
                {
                    readMode = 254;
                }
                else if (com_S.SelectedIndex == 6)
                {
                    readMode = 253;
                }

                if (rb_epc.Checked)
                {
                    TIDFlag = 0;
                    scanType = 0;
                }
               
                else
                {
                    scanType = 3;
                }

                if (check_phase.Checked) Qvalue |= 0x10;

                //total_tagnum = 0;
                targettimes = Convert.ToInt32(text_target.Text);
                total_time = System.Environment.TickCount;
                fIsInventoryScan = false;
                btIventoryG2.BackColor = Color.Indigo;
                btIventoryG2.ForeColor = Color.White;
                btIventoryG2.Text = "Stop";
                Array.Clear(antlist, 0, 16);
                int SelectAntenna = 0;
                if (check_ant1.Checked)
                {
                    antlist[0] = 1;
                    InAnt = 0x80;
                    SelectAntenna |= 0x0001;
                }
                if (check_ant2.Checked)
                {
                    antlist[1] = 1;
                    InAnt = 0x81;
                    SelectAntenna |= 0x0002;
                 
                }

                if (check_ant3.Checked)
                {
                    antlist[2] = 1;
                    InAnt = 0x82;
                    SelectAntenna |= 0x0004;
                }
                if (check_ant4.Checked)
                {
                    antlist[3] = 1;
                    InAnt = 0x83;
                    SelectAntenna |= 0x0008;
                }
                PresetTarget(readMode, SelectAntenna);

                Target = (byte)com_Target.SelectedIndex;
                toStopThread = false;
                if (fIsInventoryScan == false)
                {
                    mythread = new Thread(new ThreadStart(inventory));
                    mythread.IsBackground = true;
                    mythread.Start();
                    timer_answer.Enabled = true;
                }
  
                rb_epc.Enabled = false;
            }
            else
            {
                RWDev.StopImmediately(ref fComAdr, frmcomportindex);
                toStopThread = true;
                btIventoryG2.Enabled = false;
                btIventoryG2.BackColor = Color.Transparent;
                btIventoryG2.ForeColor = Color.DarkBlue;
                btIventoryG2.Text = "Stoping";
                //timer1.Enabled = false;


            }
        }


        public void PresetTarget(int readMode, int SelectAntenna)
        {
            byte CurSession = 0;
            if (readMode > 0)
            {
                byte MaskMem = 1;
                byte[] MaskAdr = new byte[2];
                byte MaskLen = 0;
                byte[] MaskData = new byte[100];

                if ((readMode == 254 || readMode == 253) && (ModeType == 2))
                {
                    if (Session == 254)
                    {
                        Session = 253;
                        CurSession = 2;
                    }
                    else
                    {
                        Session = 254;
                        CurSession = 3;
                    }

                    if (readMode == 253)
                        Profile = 0xC1;
                    else
                        Profile = 0xC5;
                    fCmdRet = RWDev.SetProfile(ref fComAdr, ref Profile, frmcomportindex);

                }
                else if (readMode == 255)
                {
                    CurSession = (byte)2;
                    Session = (byte)readMode;
                    for (int m = 0; m < 2; m++)
                    {
                        fCmdRet = RWDev.SelectCMDByAntenna(ref fComAdr, SelectAntenna, AntennaNum, CurSession, 0, MaskMem, MaskAdr, MaskLen, MaskData, 0, frmcomportindex);
                        Thread.Sleep(5);
                    }
                    CurSession = (byte)3;
                    for (int m = 0; m < 2; m++)
                    {
                        fCmdRet = RWDev.SelectCMDByAntenna(ref fComAdr, SelectAntenna, AntennaNum, CurSession, 0, MaskMem, MaskAdr, MaskLen, MaskData, 0, frmcomportindex);
                        Thread.Sleep(5);
                    }
                }
                else if (readMode < 4)
                {
                    CurSession = (byte)readMode;
                    Session = CurSession;
                    for (int m = 0; m < 4; m++)
                    {
                        fCmdRet = RWDev.SelectCMDByAntenna(ref fComAdr, SelectAntenna, AntennaNum, CurSession, 0, MaskMem, MaskAdr, MaskLen, MaskData, 0, frmcomportindex);
                        Thread.Sleep(5);
                    }
                }


            }
            else
            {
                Session = (byte)readMode;
            }


        }


        //private void flash_G2()
        //{
        //    byte Ant = 0;
        //    int TagNum = 0;
        //    int Totallen = 0;
        //    byte[] EPC = new byte[50000];
        //    byte MaskMem = 0;
        //    byte[] MaskAdr = new byte[2];
        //    byte MaskLen = 0;
        //    byte[] MaskData = new byte[100];
        //    byte MaskFlag = 0;
        //    MaskFlag = 0;
        //    int cbtime = System.Environment.TickCount;
        //    CardNum = 0;
        //    tagrate = 0;
        //    NewCardNum = 0;
        //    fCmdRet = RWDev.Inventory_G2(ref fComAdr, Qvalue, Session, MaskMem, MaskAdr, MaskLen, MaskData, MaskFlag, tidAddr, tidLen, TIDFlag, Target, InAnt, Scantime, FastFlag, EPC, ref Ant, ref Totallen, ref TagNum, frmcomportindex);
        //    //Console.WriteLine($"CardNum:" + CardNum);
        //    int cmdTime = System.Environment.TickCount - cbtime;
        //    if ((fCmdRet != 0x01) && (fCmdRet != 0x02) && (fCmdRet != 0xF8) && (fCmdRet != 0xF9) && (fCmdRet != 0xEE) && (fCmdRet != 0xFF))
        //    {

        //    }
        //    if (fCmdRet == 0x30)
        //    {
        //        CardNum = 0;
        //    }
        //    if (CardNum == 0)
        //    {
        //        if (Session > 1)
        //            AA_times = AA_times + 1;
        //    }
        //    else
        //    {
        //        if ((ModeType == 2) && (readMode == 253 || readMode == 254) && (NewCardNum == 0))
        //            AA_times = AA_times + 1;
        //        else
        //            AA_times = 0;
        //    }
        //    if ((fCmdRet == 1) || (fCmdRet == 2) || (fCmdRet == 0xFB) || (fCmdRet == 0x26))
        //    {
        //        if (cmdTime > CommunicationTime)
        //            cmdTime = cmdTime - CommunicationTime;
        //        if (cmdTime > 0)
        //        {
        //            tagrate = (CardNum * 1000) / cmdTime;
        //            IntPtr ptrWnd = IntPtr.Zero;
        //            ptrWnd = FindWindow(null, "UHFReader288 Demo V6.1");
        //            if (ptrWnd != IntPtr.Zero)
        //            {
        //                string para = tagrate.ToString() + "," + total_tagnum.ToString() + "," + cmdTime.ToString();
        //                SendMessage(ptrWnd, WM_SENDTAGSTAT, IntPtr.Zero, para);
        //            }
        //        }

        //    }
        //    IntPtr ptrWnd1 = IntPtr.Zero;
        //    ptrWnd1 = FindWindow(null, "UHFReader288 Demo V6.1");
        //    if (ptrWnd1 != IntPtr.Zero)
        //    {
        //        string para = fCmdRet.ToString();
        //        SendMessage(ptrWnd1, WM_SENDSTATU, IntPtr.Zero, para);
        //    }
        //    ptrWnd1 = IntPtr.Zero;


        //}
        private void flash_G2()
        {
            byte Ant = 0;
            int TagNum = 0;
            int Totallen = 0;
            byte[] EPC = new byte[50000];
            byte MaskMem = 0;
            byte[] MaskAdr = new byte[2];
            byte MaskLen = 0;
            byte[] MaskData = new byte[100];
            byte MaskFlag = 0;
            MaskFlag = 0;
            int cbtime = System.Environment.TickCount;
            CardNum = 0;
            tagrate = 0;
            NewCardNum = 0;
            fCmdRet = RWDev.Inventory_G2(ref fComAdr, Qvalue, Session, MaskMem, MaskAdr, MaskLen, MaskData, MaskFlag, tidAddr, tidLen, TIDFlag, Target, InAnt, Scantime, FastFlag, EPC, ref Ant, ref Totallen, ref TagNum, frmcomportindex);
            Console.WriteLine($"EPC: {EPC}");
            int cmdTime = System.Environment.TickCount - cbtime;//命令时间
            
            if (fCmdRet == 0x30)
            {
                CardNum = 0;
            }
            if (CardNum == 0)
            {
                if (Session > 1)
                    AA_times = AA_times + 1;
            }
            else
            {
                if ((ModeType == 2) && (readMode == 253 || readMode == 254) && (NewCardNum == 0))
                    AA_times = AA_times + 1;
                else
                    AA_times = 0;
            }
            if ((fCmdRet == 1) || (fCmdRet == 2) || (fCmdRet == 0xFB) || (fCmdRet == 0x26))
            {
                if (cmdTime > CommunicationTime)
                    cmdTime = cmdTime - CommunicationTime;
                if (cmdTime > 0)
                {
                    tagrate = (CardNum * 1000) / cmdTime;
                    IntPtr ptrWnd = IntPtr.Zero;
                    ptrWnd = FindWindow(null, "UHFReader288 Demo V6.1");
                    if (ptrWnd != IntPtr.Zero)         
                    {
                        string para = tagrate.ToString() + "," + total_tagnum.ToString() + "," + cmdTime.ToString();
                        SendMessage(ptrWnd, WM_SENDTAGSTAT, IntPtr.Zero, para);
                    }
                }

            }
            IntPtr ptrWnd1 = IntPtr.Zero;
            ptrWnd1 = FindWindow(null, "UHFReader288 Demo V6.1");
            if (ptrWnd1 != IntPtr.Zero)       
            {
                string para = fCmdRet.ToString();
                SendMessage(ptrWnd1, WM_SENDSTATU, IntPtr.Zero, para);
            }
            ptrWnd1 = IntPtr.Zero;


        }



        private void inventory()
        {
            fIsInventoryScan = true;
            while (!toStopThread)
            {
                try
                {
                    if (Session == 255)
                    {
                        FastFlag = 0;

                        flash_G2();


                    }
                    else
                    {
                        for (int m = 0; m < AntennaNum; m++)
                        {
                            InAnt = (byte)(m | 0x80);
                            FastFlag = 1;
                            if (antlist[m] == 1)
                            {
                                if (Session > 1 && Session < 4)//s2,s3
                                {
                                    if ((check_num.Checked) && (AA_times + 1 > targettimes))
                                    {
                                        Target = Convert.ToByte(1 - Target);
                                        AA_times = 0;
                                    }
                                }

                                {
                                    flash_G2();
                                    PresetProfile();

                                }
                            }
                        }
                        Thread.Sleep(5);
                    }
                }
                catch (System.Exception ex)
                {
                    this.Invoke((EventHandler)delegate
                    {
                        WriteLog(lrtxtLog, "Inventory:" + ex.ToString(), 1);
                    });
                }
            }

            if (ModeType == 2)
            {
                Profile = (byte)(RF_Profile | 0xC0);
                fCmdRet = RWDev.SetProfile(ref fComAdr, ref Profile, frmcomportindex);
            }

            this.Invoke((EventHandler)delegate
            {

                if (fIsInventoryScan)
                {
                    toStopThread = true;       

                    btIventoryG2.Text = "Start";
                    
                    mythread.Abort();
                    timer_answer.Enabled = false;
                    fIsInventoryScan = false;
                }
                timer_answer.Enabled = false;

                rb_epc.Enabled = true;
            
                fIsInventoryScan = false;
                btIventoryG2.Enabled = true;
              
                mythread = null;
            });

        }

        private void PresetProfile()
        {
            if ((readMode == 254 || readMode == 253) && (ModeType == 2))//
            {
                if ((Profile == 0x01) && (readMode == 253))
                {
                    if (tagrate < 150 || CardNum < 150)
                    {
                        Profile = 0xC5;
                        fCmdRet = RWDev.SetProfile(ref fComAdr, ref Profile, frmcomportindex);
                    }
                }
                else if (Profile == 0x05)
                {
                    if (NewCardNum < 5)
                    {
                        Profile = 0xCD;
                        fCmdRet = RWDev.SetProfile(ref fComAdr, ref Profile, frmcomportindex);
                        AA_times = 0;
                    }
                }
                else if (Profile == 0x0D)
                {
                    if (NewCardNum > 20)
                    {
                        Profile = 0xC5;
                        fCmdRet = RWDev.SetProfile(ref fComAdr, ref Profile, frmcomportindex);

                    }
                    else if (AA_times >= targettimes)
                    {
                        if (readMode == 254)
                            Profile = 0xC5;
                        else if (readMode == 253)
                            Profile = 0xC1;
                        fCmdRet = RWDev.SetProfile(ref fComAdr, ref Profile, frmcomportindex);
                        AA_times = 0;
                        Target = Convert.ToByte(1 - Target); 
                    }

                }
            }
        }
        private void timer_answer_Tick(object sender, EventArgs e)
        {
            if (reflasg) return;
            reflasg = true;
            updateAnswerMode();
 
            reflasg = false;
        }

        private void updateAnswerMode()
        {
            IntPtr ptrWnd = IntPtr.Zero;
            ptrWnd = FindWindow(null, "UHFReader288 Demo V6.1");
            if (ptrWnd != IntPtr.Zero)         
            {
                string para = fCmdRet.ToString();
                SendMessage(ptrWnd, WM_SHOWNUM, IntPtr.Zero, para);
            }

            RFIDTag[] mytag = new RFIDTag[500];
            int Count = 0;
            lock (LockFlag)
            {
                lxLedControl4.Text = total_tagnum + "";
                Count = curList.Count;
                if (Count > 0)
                {
                    curList.CopyTo(mytag, 0);
                }
                curList.Clear();
            }
            for (int p = 0; p < Count; p++)
            {
                RFIDTag mtag = mytag[p];
                SendTagMessage(ptrWnd, mtag);
            }
            lxLedControl1.Text = epclist.Count + "";
            lxLedControl6.Text = tidlist.Count + "";
            // dataGridView1.DataSource = 
            ptrWnd = IntPtr.Zero;
        }


        private void radioButton_band1_CheckedChanged(object sender, EventArgs e)
        {
            int i;
            ComboBox_dmaxfre.Items.Clear();
            ComboBox_dminfre.Items.Clear();
            cmbReturnLossFreq.Items.Clear();
            for (i = 0; i < 20; i++)
            {
                ComboBox_dminfre.Items.Add(Convert.ToString(920.125 + i * 0.25) + " MHz");
                ComboBox_dmaxfre.Items.Add(Convert.ToString(920.125 + i * 0.25) + " MHz");
                cmbReturnLossFreq.Items.Add(Convert.ToString(920.125 + i * 0.25));
            }
            ComboBox_dmaxfre.SelectedIndex = 19;
            ComboBox_dminfre.SelectedIndex = 0;
            cmbReturnLossFreq.SelectedIndex = 10;
        }

        private void radioButton_band2_CheckedChanged(object sender, EventArgs e)
        {
            int i;
            ComboBox_dmaxfre.Items.Clear();
            ComboBox_dminfre.Items.Clear();
            cmbReturnLossFreq.Items.Clear();
            for (i = 0; i < 50; i++)
            {
                ComboBox_dminfre.Items.Add(Convert.ToString(902.75 + i * 0.5) + " MHz");
                ComboBox_dmaxfre.Items.Add(Convert.ToString(902.75 + i * 0.5) + " MHz");
                cmbReturnLossFreq.Items.Add(Convert.ToString(902.75 + i * 0.5));
            }
            ComboBox_dmaxfre.SelectedIndex = 49;
            ComboBox_dminfre.SelectedIndex = 0;
            cmbReturnLossFreq.SelectedIndex = 25;
        }

        private void radioButton_band3_CheckedChanged(object sender, EventArgs e)
        {
            int i;
            ComboBox_dmaxfre.Items.Clear();
            ComboBox_dminfre.Items.Clear();
            cmbReturnLossFreq.Items.Clear();
            for (i = 0; i < 32; i++)
            {
                ComboBox_dminfre.Items.Add(Convert.ToString(917.1 + i * 0.2) + " MHz");
                ComboBox_dmaxfre.Items.Add(Convert.ToString(917.1 + i * 0.2) + " MHz");
                cmbReturnLossFreq.Items.Add(Convert.ToString(917.1 + i * 0.2));
            }
            ComboBox_dmaxfre.SelectedIndex = 31;
            ComboBox_dminfre.SelectedIndex = 0;
            cmbReturnLossFreq.SelectedIndex = 16;
        }

        private void radioButton_band4_CheckedChanged(object sender, EventArgs e)
        {
            int i;
            ComboBox_dminfre.Items.Clear();
            ComboBox_dmaxfre.Items.Clear();
            cmbReturnLossFreq.Items.Clear();
            for (i = 0; i < 15; i++)
            {
                ComboBox_dminfre.Items.Add(Convert.ToString(865.1 + i * 0.2) + " MHz");
                ComboBox_dmaxfre.Items.Add(Convert.ToString(865.1 + i * 0.2) + " MHz");
                cmbReturnLossFreq.Items.Add(Convert.ToString(865.1 + i * 0.2));
            }
            ComboBox_dmaxfre.SelectedIndex = 14;
            ComboBox_dminfre.SelectedIndex = 0;
            cmbReturnLossFreq.SelectedIndex = 7;
        }

        private void CheckBox_SameFre_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox_SameFre.Checked)
                ComboBox_dmaxfre.SelectedIndex = ComboBox_dminfre.SelectedIndex;
        }





        private void btGetActivedata_Click(object sender, EventArgs e)
        {

        }


        private void timer_runmode_Tick(object sender, EventArgs e)
        {
            if (fIsInventoryScan)
                return;
            fIsInventoryScan = true;
            //GetData();
            fIsInventoryScan = false;
        }


        private void Maintab_SelectedIndexChanged(object sender, EventArgs e)
        {

            //if (fIsInventoryScan)
            //{
            //    toStopThread = true;
            //    btIventoryG2.Enabled = false;
            //    btIventoryG2.BackColor = Color.Transparent;
            //    btIventoryG2.Text = "Start";
            //}
            //if (fIsBuffScan)
            //{
            //    toStopThread = true;                             
            //    ReadThread.Abort();
            //    timer_Buff.Enabled = false;
            //    fIsInventoryScan = false;
            //}
            //timer_runmode.Enabled = false;
            //timer_answer.Enabled = false;
            //timer_EAS.Enabled = false;
            //Timer_Test_6B.Enabled = false;
            //timer_Buff.Enabled = false;
            //timer_RealTime.Enabled = false;
            //btIventoryG2.Text = "Start";
            //btIventoryG2.BackColor = Color.Transparent;



            ////if (comboBox_EPC.Text == "" && comboBox_EPC.Items.Count > 0)
            ////{
            ////    comboBox_EPC.SelectedIndex = 0;
            ////}
            //if ((ReadTypes == "16") || (ReadTypes == "21"))
            //{
            //    group_ant1.Enabled = false;
            //    check_ant1.Checked = true;


            //}
            //else
            //{
            //    if (com_S.SelectedIndex != 4)
            //        group_ant1.Enabled = true;
            //    else
            //        group_ant1.Enabled = false;
            //}


        }






        private void tb_Port_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = ("0123456789".IndexOf(Char.ToUpper(e.KeyChar)) < 0);
        }

        private void text_address_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = ("0123456789ABCDEF".IndexOf(Char.ToUpper(e.KeyChar)) < 0);
        }

        int AntennaNum = 1;
        int ModeType = 0;
   
        private void ShowAntenna(int antennanum)
        {
            ////////////
            cbbAnt.Items.Clear();
            for (int m = 0; m < antennanum; m++)
            {
                cbbAnt.Items.Add("ANT" + Convert.ToString(m + 1));
            }
            checkant1.Visible = false;
            checkant2.Visible = false;
            checkant3.Visible = false;
            checkant4.Visible = false;
          
            check_ant1.Visible = false;
            check_ant2.Visible = false;
            check_ant3.Visible = false;
            check_ant4.Visible = false;

            txtPower1.Enabled = false;
            txtPower2.Enabled = false;
            txtPower3.Enabled = false;
            txtPower4.Enabled = false;

            switch (antennanum)
            {
                case 1:
                    checkant1.Visible = true;
                    check_ant1.Visible = true;
                    txtPower1.Enabled = true;
                    break;
                case 4:
                    checkant1.Visible = true;
                    checkant2.Visible = true;
                    checkant3.Visible = true;
                    checkant4.Visible = true;
                    check_ant1.Visible = true;
                    check_ant2.Visible = true;
                    check_ant3.Visible = true;
                    check_ant4.Visible = true;

                    txtPower1.Enabled = true;
                    txtPower2.Enabled = true;
                    txtPower3.Enabled = true;
                    txtPower4.Enabled = true;
                    break;
                case 8:
                    checkant1.Visible = true;
                    checkant2.Visible = true;
                    checkant3.Visible = true;
                    checkant4.Visible = true;
                   
                    check_ant1.Visible = true;
                    check_ant2.Visible = true;
                    check_ant3.Visible = true;
                    check_ant4.Visible = true;

                    txtPower1.Enabled = true;
                    txtPower2.Enabled = true;
                    txtPower3.Enabled = true;
                    txtPower4.Enabled = true;

                    break;
                case 16:
                    checkant1.Visible = true;
                    checkant2.Visible = true;
                    checkant3.Visible = true;
                    checkant4.Visible = true;
                   

                    check_ant1.Visible = true;
                    check_ant2.Visible = true;
                    check_ant3.Visible = true;
                    check_ant4.Visible = true;
                

                    txtPower1.Enabled = true;
                    txtPower2.Enabled = true;
                    txtPower3.Enabled = true;
                    txtPower4.Enabled = true;

                    break;
            }




        }
        private void btDefault_Click(object sender, EventArgs e)
        {
            byte aNewComAdr, powerDbm, dminfre, dmaxfre, scantime;
            dminfre = 128;
            dmaxfre = 49;
            aNewComAdr = 0x00;
            powerDbm = 30;
            if (ModeType == 0)
                powerDbm = 33;
            else if (ModeType == 1)
                powerDbm = 30;
            fBaud = 5;
            scantime = 0;
            ComboBox_baud.SelectedIndex = 3;
            fCmdRet = RWDev.SetAddress(ref fComAdr, aNewComAdr, frmcomportindex);
            if (fCmdRet != 0)
            {
                string strLog = "Set Reader address failed: " + GetReturnCodeDesc(fCmdRet);
                WriteLog(lrtxtLog, strLog, 1);
            }
            else
            {
                string strLog = "Set Reader address success ";
                WriteLog(lrtxtLog, strLog, 0);
            }

            fCmdRet = RWDev.SetRfPower(ref fComAdr, powerDbm, frmcomportindex);
            if (fCmdRet != 0)
            {
                string strLog = "Set Power failed: " + GetReturnCodeDesc(fCmdRet);
                WriteLog(lrtxtLog, strLog, 1);
            }
            else
            {
                string strLog = "Set power success ";
                WriteLog(lrtxtLog, strLog, 0);
            }

            fCmdRet = RWDev.SetRegion(ref fComAdr, dmaxfre, dminfre, frmcomportindex);
            if (fCmdRet != 0)
            {
                string strLog = "Set Region failed: " + GetReturnCodeDesc(fCmdRet);
                WriteLog(lrtxtLog, strLog, 1);
            }
            else
            {
                string strLog = "Set Region success ";
                WriteLog(lrtxtLog, strLog, 0);
            }

            fCmdRet = RWDev.SetBaudRate(ref fComAdr, fBaud, frmcomportindex);
            if (fCmdRet != 0)
            {
                string strLog = "Set baud rate failed: " + GetReturnCodeDesc(fCmdRet);
                WriteLog(lrtxtLog, strLog, 1);
            }
            else
            {
                string strLog = "Set baud rate success ";
                WriteLog(lrtxtLog, strLog, 0);
            }

            fCmdRet = RWDev.SetInventoryScanTime(ref fComAdr, scantime, frmcomportindex);
            if (fCmdRet != 0)
            {
                string strLog = "Set inventory scan time failed: " + GetReturnCodeDesc(fCmdRet);
                WriteLog(lrtxtLog, strLog, 1);
            }
            else
            {
                string strLog = "Set inventory scan time success ";
                WriteLog(lrtxtLog, strLog, 0);
            }
            //btGetInformation_Click(null, null);
        }

        private void btaddress_Click(object sender, EventArgs e)
        {
            byte aNewComAdr = Convert.ToByte(text_address.Text, 16);
            fCmdRet = RWDev.SetAddress(ref fComAdr, aNewComAdr, frmcomportindex);
            if (fCmdRet != 0)
            {
                string strLog = "Set reader address failed: " + GetReturnCodeDesc(fCmdRet);
                WriteLog(lrtxtLog, strLog, 1);
            }
            else
            {
                string strLog = "Set reader address success ";
                WriteLog(lrtxtLog, strLog, 0);
            }
        }

        private void btFreq_Click(object sender, EventArgs e)
        {
            byte dminfre, dmaxfre;
            int band = 2;
            if (radioButton_band1.Checked)
                band = 1;
            if (radioButton_band2.Checked)
                band = 2;
            if (radioButton_band3.Checked)
                band = 3;
            if (radioButton_band4.Checked)
                band = 4;
            if (radioButton_band8.Checked)
                band = 8;
            if (radioButton_band12.Checked)
                band = 12;
            if (radioButton_band0.Checked)
                band = 0;
            dminfre = Convert.ToByte(((band & 3) << 6) | (ComboBox_dminfre.SelectedIndex & 0x3F));
            dmaxfre = Convert.ToByte(((band & 0x0c) << 4) | (ComboBox_dmaxfre.SelectedIndex & 0x3F));
            fCmdRet = RWDev.SetRegion(ref fComAdr, dmaxfre, dminfre, frmcomportindex);
            if (fCmdRet != 0)
            {
                string strLog = "Set region failed: " + GetReturnCodeDesc(fCmdRet);
                WriteLog(lrtxtLog, strLog, 1);
            }
            else
            {
                string strLog = "Set region success ";
                WriteLog(lrtxtLog, strLog, 0);
            }
        }

        private void BT_DBM_Click(object sender, EventArgs e)
        {
            byte powerDbm = (byte)ComboBox_PowerDbm.SelectedIndex;
            fCmdRet = RWDev.SetRfPower(ref fComAdr, powerDbm, frmcomportindex);
            if (fCmdRet != 0)
            {
                string strLog = "Set power failed: " + GetReturnCodeDesc(fCmdRet);
                WriteLog(lrtxtLog, strLog, 1);
            }
            else
            {
                string strLog = "Set power success ";
                WriteLog(lrtxtLog, strLog, 0);
                SaveSettings();
            }
           
        }

        private void btBaudRate_Click(object sender, EventArgs e)
        {
            byte fBaud = (byte)ComboBox_baud.SelectedIndex;
            if (fBaud > 2)
                fBaud = (byte)(fBaud + 2);
            fCmdRet = RWDev.SetBaudRate(ref fComAdr, fBaud, frmcomportindex);
            if (fCmdRet != 0)
            {
                string strLog = "Set baud rate failed: " + GetReturnCodeDesc(fCmdRet);
                WriteLog(lrtxtLog, strLog, 1);
            }
            else
            {
                string strLog = "Set baud rate success ";
                WriteLog(lrtxtLog, strLog, 0);
            }
        }

        private void btSerial_Click(object sender, EventArgs e)
        {
            byte[] SeriaNo = new byte[4];
            text_Serial.Text = "";
            fCmdRet = RWDev.GetSeriaNo(ref fComAdr, SeriaNo, frmcomportindex);
            if (fCmdRet != 0)
            {
                string strLog = "Get serial number failed: " + GetReturnCodeDesc(fCmdRet);
                WriteLog(lrtxtLog, strLog, 1);
            }
            else
            {
                text_Serial.Text = ByteArrayToHexString(SeriaNo);
                string strLog = "Get serial number success ";
                WriteLog(lrtxtLog, strLog, 0);
            }
        }

        private void btMDVersion_Click(object sender, EventArgs e)
        {
            byte[] Version = new byte[2];
            text_MDVersion.Text = "";
            fCmdRet = RWDev.GetModuleVersion(ref fComAdr, Version, frmcomportindex);
            if (fCmdRet != 0)
            {
                string strLog = "Get module version failed: " + GetReturnCodeDesc(fCmdRet);
                WriteLog(lrtxtLog, strLog, 1);
            }
            else
            {
                text_MDVersion.Text = Convert.ToString(Version[0], 10).PadLeft(2, '0') + "." + Convert.ToString(Version[1], 10).PadLeft(2, '0');
                string strLog = "Get module version success ";
                WriteLog(lrtxtLog, strLog, 0);
            }
        }

        private void Button_Beep_Click(object sender, EventArgs e)
        {
            byte BeepEn = 0;
            if (Radio_beepEn.Checked)
                BeepEn = 1;
            else
                BeepEn = 0;
            fCmdRet = RWDev.SetBeepNotification(ref fComAdr, BeepEn, frmcomportindex);
            if (fCmdRet != 0)
            {
                string strLog = "Set beep failed: " + GetReturnCodeDesc(fCmdRet);
                WriteLog(lrtxtLog, strLog, 1);
            }
            else
            {
                string strLog = "Set beep success ";
                WriteLog(lrtxtLog, strLog, 0);
            }
        }

        private void btRelay_Click(object sender, EventArgs e)
        {
            byte RelayTime = 0;
            RelayTime = Convert.ToByte(ComboBox_RelayTime.SelectedIndex + 1);
            fCmdRet = RWDev.SetRelay(ref fComAdr, RelayTime, frmcomportindex);
            if (fCmdRet != 0)
            {
                string strLog = "Set relay failed: " + GetReturnCodeDesc(fCmdRet);
                WriteLog(lrtxtLog, strLog, 1);
            }
            else
            {
                string strLog = "Set relay success ";
                WriteLog(lrtxtLog, strLog, 0);
            }
        }

        private void btOutputRep_Click(object sender, EventArgs e)
        {
            byte OutputRep = 0;
            if (check_OutputRep1.Checked)
                OutputRep = Convert.ToByte(OutputRep | 0x01);
            if (check_OutputRep2.Checked)
                OutputRep = Convert.ToByte(OutputRep | 0x02);
            if (check_OutputRep3.Checked)
                OutputRep = Convert.ToByte(OutputRep | 0x04);
            if (check_OutputRep3.Checked)
                OutputRep = Convert.ToByte(OutputRep | 0x08);
            fCmdRet = RWDev.SetNotificationPulseOutput(ref fComAdr, OutputRep, frmcomportindex);
            if (fCmdRet != 0)
            {
                string strLog = "Set notification pulse output failed: " + GetReturnCodeDesc(fCmdRet);
                WriteLog(lrtxtLog, strLog, 1);
            }
            else
            {
                string strLog = "Set notification pulse output success ";
                WriteLog(lrtxtLog, strLog, 0);
            }
        }

        private void Button_SetGPIO_Click(object sender, EventArgs e)
        {
            byte OutputPin = 0;
            if (check_out1.Checked)
                OutputPin = Convert.ToByte(OutputPin | 0x01);
            if (check_out2.Checked)
                OutputPin = Convert.ToByte(OutputPin | 0x02);
            if (check_out3.Checked)
                OutputPin = Convert.ToByte(OutputPin | 0x04);
            if (check_out4.Checked)
                OutputPin = Convert.ToByte(OutputPin | 0x08);
            fCmdRet = RWDev.SetGPIO(ref fComAdr, OutputPin, frmcomportindex);
            if (fCmdRet != 0)
            {
                string strLog = "Set GPIO failed: " + GetReturnCodeDesc(fCmdRet);
                WriteLog(lrtxtLog, strLog, 1);
            }
            else
            {
                string strLog = "Set GPIO success ";
                WriteLog(lrtxtLog, strLog, 0);
            }
        }

        private void Button_GetGPIO_Click(object sender, EventArgs e)
        {
            byte OutputPin = 0;
            fCmdRet = RWDev.GetGPIOStatus(ref fComAdr, ref OutputPin, frmcomportindex);
            if (fCmdRet != 0)
            {
                string strLog = "Get GPIO failed: " + GetReturnCodeDesc(fCmdRet);
                WriteLog(lrtxtLog, strLog, 1);
            }
            else
            {
                if ((OutputPin & 0x10) == 0x10)
                    check_out1.Checked = true;
                else
                    check_out1.Checked = false;

                if ((OutputPin & 0x20) == 0x20)
                    check_out2.Checked = true;
                else
                    check_out2.Checked = false;

                if ((OutputPin & 0x40) == 0x40)
                    check_out3.Checked = true;
                else
                    check_out3.Checked = false;

                if ((OutputPin & 0x80) == 0x80)
                    check_out4.Checked = true;
                else
                    check_out4.Checked = false;

                if ((OutputPin & 0x01) == 1)
                    check_int1.Checked = true;
                else
                    check_int1.Checked = false;

                if ((OutputPin & 0x02) == 2)
                    check_int2.Checked = true;
                else
                    check_int2.Checked = false;

                if ((OutputPin & 0x04) == 4)
                    check_int3.Checked = true;
                else
                    check_int3.Checked = false;

                if ((OutputPin & 0x08) == 8)
                    check_int4.Checked = true;
                else
                    check_int4.Checked = false;
                string strLog = "Get GPIO success ";
                WriteLog(lrtxtLog, strLog, 0);
            }
        }

        private void btSetcheckant_Click(object sender, EventArgs e)
        {
            byte CheckAnt = 0;
            if (rb_Opencheckant.Checked)
                CheckAnt = 1;
            else
                CheckAnt = 0;
            fCmdRet = RWDev.SetCheckAnt(ref fComAdr, CheckAnt, frmcomportindex);
            if (fCmdRet != 0)
            {
                string strLog = "Set antenna check failed: " + GetReturnCodeDesc(fCmdRet);
                WriteLog(lrtxtLog, strLog, 1);
            }
            else
            {
                string strLog = "Set antenna check success ";
                WriteLog(lrtxtLog, strLog, 0);
            }
        }

        private void Button_Ant_Click(object sender, EventArgs e)
        {
            byte ANT = 0;
            byte ANT1 = 0;
            byte SetOnce = 0;
            if (AntennaNum == 4)
            {
                if (checkant1.Checked) ANT = Convert.ToByte(ANT | 0x01);
                if (checkant2.Checked) ANT = Convert.ToByte(ANT | 0x02);
                if (checkant3.Checked) ANT = Convert.ToByte(ANT | 0x04);
                if (checkant4.Checked) ANT = Convert.ToByte(ANT | 0x08);
                if (!checkBox2.Checked) SetOnce = 0x80;
                fCmdRet = RWDev.SetAntennaMultiplexing(ref fComAdr, (byte)(ANT | SetOnce), frmcomportindex);
            }
            else if (AntennaNum == 8)
            {
                if (checkBox2.Checked)
                    SetOnce = 0;//保存
                else
                    SetOnce = 1;//不保存
                if (checkant1.Checked) ANT = Convert.ToByte(ANT | 0x01);
                if (checkant2.Checked) ANT = Convert.ToByte(ANT | 0x02);
                if (checkant3.Checked) ANT = Convert.ToByte(ANT | 0x04);
                if (checkant4.Checked) ANT = Convert.ToByte(ANT | 0x08);
             
                fCmdRet = RWDev.SetAntenna(ref fComAdr, SetOnce, ANT1, ANT, frmcomportindex);
            }
            else if (AntennaNum == 16)
            {
                if (checkBox2.Checked)
                    SetOnce = 0;//保存
                else
                    SetOnce = 1;//不保存
                if (checkant1.Checked) ANT = Convert.ToByte(ANT | 0x01);
                if (checkant2.Checked) ANT = Convert.ToByte(ANT | 0x02);
                if (checkant3.Checked) ANT = Convert.ToByte(ANT | 0x04);
                if (checkant4.Checked) ANT = Convert.ToByte(ANT | 0x08);
              

                fCmdRet = RWDev.SetAntenna(ref fComAdr, SetOnce, ANT1, ANT, frmcomportindex);

            }
            if (fCmdRet != 0)
            {
                string strLog = "Antenna config failed:" + GetReturnCodeDesc(fCmdRet);
                WriteLog(lrtxtLog, strLog, 1);
            }
            else
            {

                string strLog = "Antenna config success ";
                WriteLog(lrtxtLog, strLog, 0);
            }
        }

        private void timer_EAS_Tick(object sender, EventArgs e)
        {
            if (fIsInventoryScan)
                return;
            fIsInventoryScan = true;
            fCmdRet = RWDev.EASAlarm_G2(ref fComAdr, ref ferrorcode, frmcomportindex);
            if (fCmdRet != 0)
            {
                string strLog = "No EAS Alarm";
                WriteLog(lrtxtLog, strLog, 1);
                //pictureBox2.Visible = false;
            }
            else
            {
                //pictureBox2.Visible = true;
                string strLog = "EAS Alarm";
                WriteLog(lrtxtLog, strLog, 0);
            }
            fIsInventoryScan = false;
        }


        public void ChangeSubItem1(ListViewItem ListItem, int subItemIndex, string ItemText, string ant, string RSSI)
        {
            if (subItemIndex == 1)
            {
                if (ListItem.SubItems[subItemIndex].Text != ItemText)
                {
                    ListItem.SubItems[subItemIndex].Text = ItemText;
                    ListItem.SubItems[subItemIndex + 2].Text = "1";
                    ListItem.SubItems[subItemIndex + 1].Text = ant;
                }
                else
                {
                    ListItem.SubItems[subItemIndex + 2].Text = Convert.ToString(Convert.ToUInt32(ListItem.SubItems[subItemIndex + 2].Text) + 1);
                    if ((Convert.ToUInt32(ListItem.SubItems[subItemIndex + 2].Text) > 9999))
                        ListItem.SubItems[subItemIndex + 2].Text = "1";
                    ListItem.SubItems[subItemIndex + 1].Text = Convert.ToString(Convert.ToInt32(ListItem.SubItems[subItemIndex + 1].Text, 2) | Convert.ToInt32(ant, 2), 2).PadLeft(4, '0');

                }
                ListItem.SubItems[subItemIndex + 3].Text = RSSI;
            }
        }
        private void Timer_Test_6B_Tick(object sender, EventArgs e)
        {
            if (fisinventoryscan_6B)
                return;
            fisinventoryscan_6B = true;

            fisinventoryscan_6B = false;
        }


      
      
        private void btLoadDefault_Click(object sender, EventArgs e)
        {
            try
            {
                byte timeout = 0;
                byte cmdlen = 0;
                byte[] data = new byte[100];
                byte[] cmddata = new byte[100];
                byte recvLen = 0;
                byte[] recvdata = new byte[1000];
                string cmd = "AT!LD";
                data = Encoding.ASCII.GetBytes(cmd);
                cmdlen = Convert.ToByte(cmd.Length);
                Array.Copy(data, cmddata, cmdlen);
                timeout = 30;
                cmddata[cmdlen] = 0x0d;
                cmddata[cmdlen + 1] = 0x0a;
                cmdlen = Convert.ToByte(cmdlen + 2);
                fCmdRet = RWDev.TransparentCMD(ref fComAdr, timeout, cmdlen, cmddata, ref recvLen, recvdata, frmcomportindex);
                if (fCmdRet != 0)
                {
                    string strLog = "AT CMD failed: " + GetReturnCodeDesc(fCmdRet);
                    WriteLog(lrtxtLog, strLog, 1);
                }
                else
                {
                    string recvs = Encoding.ASCII.GetString(recvdata);
                    if ((recvs.IndexOf("ERROR") > 0) || (recvLen == 0))
                    {
                        MessageBox.Show("Set failed!", "information");
                        return;
                    }
                    string strLog = "AT CMD success";
                    WriteLog(lrtxtLog, strLog, 0);
                }
            }
            catch (System.Exception ex)
            {
                ex.ToString();
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            try
            {
                byte timeout = 0;
                byte cmdlen = 0;
                byte[] data = new byte[100];
                byte[] cmddata = new byte[100];
                byte recvLen = 0;
                byte[] recvdata = new byte[1000];
                string cmd = "AT!S";
                data = Encoding.ASCII.GetBytes(cmd);
                cmdlen = Convert.ToByte(cmd.Length);
                Array.Copy(data, cmddata, cmdlen);
                timeout = 30;
                cmddata[cmdlen] = 0x0d;
                cmddata[cmdlen + 1] = 0x0a;
                cmdlen = Convert.ToByte(cmdlen + 2);
                fCmdRet = RWDev.TransparentCMD(ref fComAdr, timeout, cmdlen, cmddata, ref recvLen, recvdata, frmcomportindex);
                if (fCmdRet != 0)
                {
                    string strLog = "AT CMD failed: " + GetReturnCodeDesc(fCmdRet);
                    WriteLog(lrtxtLog, strLog, 1);
                }
                else
                {
                    Thread.Sleep(500);
                    cmd = "AT!R";
                    data = Encoding.ASCII.GetBytes(cmd);
                    cmdlen = Convert.ToByte(cmd.Length);
                    Array.Copy(data, cmddata, cmdlen);
                    timeout = 30;
                    cmddata[cmdlen] = 0x0d;
                    cmddata[cmdlen + 1] = 0x0a;
                    cmdlen = Convert.ToByte(cmdlen + 2);
                    fCmdRet = RWDev.TransparentCMD(ref fComAdr, timeout, cmdlen, cmddata, ref recvLen, recvdata, frmcomportindex);
                    string strLog = "AT CMD success ";
                    WriteLog(lrtxtLog, strLog, 0);
                }
            }
            catch (System.Exception ex)
            {
                ex.ToString();
            }
        }

        private void btGotoAT_Click(object sender, EventArgs e)
        {
            byte ATMode = 1;
            fCmdRet = RWDev.ChangeATMode(ref fComAdr, ATMode, frmcomportindex);
            if (fCmdRet != 0)
            {
                string strLog = "Enter AT mode failed: " + GetReturnCodeDesc(fCmdRet);
                WriteLog(lrtxtLog, strLog, 1);
            }
            else
            {
                string strLog = "Enter AT mode success ";
                WriteLog(lrtxtLog, strLog, 0);
            }
        }

        private void btExitAT_Click(object sender, EventArgs e)
        {
            byte ATMode = 0;
            fCmdRet = RWDev.ChangeATMode(ref fComAdr, ATMode, frmcomportindex);
            if (fCmdRet != 0)
            {
                string strLog = "Exit AT mode failed: " + GetReturnCodeDesc(fCmdRet);
                WriteLog(lrtxtLog, strLog, 1);
            }
            else
            {
                string strLog = "Exit AT mode success ";
                WriteLog(lrtxtLog, strLog, 0);
            }
        }



        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            DevControl.tagErrorCode eCode = DevControl.DM_DeInit();
            if (eCode != DevControl.tagErrorCode.DM_ERR_OK)
            {
                ErrorHandling.HandleError(eCode);
            }
        }

        private void DeviceListView_DoubleClick(object sender, EventArgs e)
        {
            //ConfigSelectedDevice();
        }

        private void btFlashROM_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, " if change to flush mode,need restart power to restore.are you sure do this?", "Information", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                return;
            fCmdRet = RWDev.SetFlashRom(ref fComAdr, frmcomportindex);
            if (fCmdRet != 0)
            {
                string strLog = "Change to flush mode failed: " + GetReturnCodeDesc(fCmdRet);
                WriteLog(lrtxtLog, strLog, 1);
            }
            else
            {
                string strLog = "Change to flush mode success ";
                WriteLog(lrtxtLog, strLog, 0);
                if (frmcomportindex > 0 && frmcomportindex < 256)
                {
                    btDisConnect232_Click(null, null);
                }
            }
        }

        private void tabPage8_Click(object sender, EventArgs e)
        {

        }

        public class ctcplist
        {
            public Socket[] tempSocket = new Socket[100];
            public string[] ip = new string[100];
            public int[] port = new int[100];
        }
        ctcplist tcplist = new ctcplist();
        Thread listenThread = null;
        Socket newsock = null;
      

        public static string ByteArrayToHexString2(byte[] data)
        {
            StringBuilder sb = new StringBuilder(data.Length * 3);
            foreach (byte b in data)
                sb.Append(Convert.ToString(b, 16).PadLeft(2, '0').PadLeft(3, ' '));
            return sb.ToString().ToUpper();

        }
      
      
        Socket m_client;
        Thread clientThread = null;
        private void bttcpconnect_Click(object sender, EventArgs e)
        {
        }
       

        private void bttcpsend_Click(object sender, EventArgs e)
        {
          
        }

        private void bttcpdisconnect_Click(object sender, EventArgs e)
        {
            
        }

        private void com_S_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (com_S.SelectedIndex > 1)
            {
                check_num.Enabled = true;
            }
            else
            {
                check_num.Enabled = false;
            }
            if (com_S.SelectedIndex == 4)
            {
                group_ant1.Enabled = false;
                com_scantime.Enabled = false;
            }
            else
            {
                group_ant1.Enabled = true;
                com_scantime.Enabled = true;
            }
        }

        private void btSetEPCandTIDLen_Click(object sender, EventArgs e)
        {
            byte SaveLen = 0;
            if (rb128.Checked)
            {
                SaveLen = 0;
            }
            else
            {
                SaveLen = 1;
            }
            fCmdRet = RWDev.SetSaveLen(ref fComAdr, SaveLen, frmcomportindex);
            if (fCmdRet == 0)
            {
                string strLog = "Set save length success ";
                WriteLog(lrtxtLog, strLog, 0);
            }
            else
            {
                string strLog = "Set save length failed: " + GetReturnCodeDesc(fCmdRet);
                WriteLog(lrtxtLog, strLog, 0);
            }
        }

        private void btGetEPCandTIDLen_Click(object sender, EventArgs e)
        {
            byte SaveLen = 0;
            fCmdRet = RWDev.GetSaveLen(ref fComAdr, ref SaveLen, frmcomportindex);
            if (fCmdRet == 0)
            {
                if (SaveLen == 0)
                    rb128.Checked = true;
                else
                    rb496.Checked = true;
                string strLog = "Get save length success ";
                WriteLog(lrtxtLog, strLog, 0);
            }
            else
            {
                string strLog = "Get save length failed: " + GetReturnCodeDesc(fCmdRet);
                WriteLog(lrtxtLog, strLog, 0);
            }
        }




        private Thread ReadThread = null;
        private volatile bool fIsBuffScan = false;

        private void GetBuffData()
        {
            int TagNum = 0;
            int BufferCount = 0;
            byte MaskMem = 0;
            byte[] MaskAdr = new byte[2];
            byte MaskLen = 0;
            byte[] MaskData = new byte[100];
            byte MaskFlag = 0;
            byte AdrTID = 0;
            byte LenTID = 0;
            AdrTID = 0;
            LenTID = 6;
            MaskFlag = 0;
            int cbtime = System.Environment.TickCount;
            TagNum = 0;
            BufferCount = 0;
            Target = 0;
            Scantime = 0x14;
            Qvalue = 6;
            if (TIDFlag == 0)
                Session = 255;
            else
                Session = 1;
            FastFlag = 0;
            fCmdRet = RWDev.InventoryBuffer_G2(ref fComAdr, Qvalue, Session, MaskMem, MaskAdr, MaskLen, MaskData, MaskFlag, AdrTID, LenTID, TIDFlag, Target, InAnt, Scantime, FastFlag, ref BufferCount, ref TagNum, frmcomportindex);
            int x_time = System.Environment.TickCount - cbtime;
            if (fCmdRet == 0)
            {
                IntPtr ptrWnd = IntPtr.Zero;
                ptrWnd = FindWindow(null, "UHFReader288 Demo V6.1");
                if (ptrWnd != IntPtr.Zero)
                {
                    total_tagnum = total_tagnum + TagNum;
                    int tagrate = (TagNum * 1000) / x_time;
                    string para = BufferCount.ToString() + "," + x_time.ToString() + "," + tagrate.ToString() + "," + total_tagnum.ToString();
                    SendMessage(ptrWnd, WM_SENDBUFF, IntPtr.Zero, para);
                }
                ptrWnd = IntPtr.Zero;
            }
        }
        private void ReadProcess()
        {
            fIsBuffScan = true;
            while (!toStopThread)
            {
                GetBuffData();
            }
            fIsBuffScan = false;
        }
        private void timer_Buff_Tick(object sender, EventArgs e)
        {
            //lxLed_Btoltime.Text = (System.Environment.TickCount - total_time).ToString();
        }


        private void btSetMaxtime_Click(object sender, EventArgs e)
        {
            byte Scantime = 0;
            Scantime = Convert.ToByte(comboBox_maxtime.SelectedIndex);
            fCmdRet = RWDev.SetInventoryScanTime(ref fComAdr, Scantime, frmcomportindex);
            if (fCmdRet != 0)
            {
                string strLog = "Set inventory scan time failed: " + GetReturnCodeDesc(fCmdRet);
                WriteLog(lrtxtLog, strLog, 1);
            }
            else
            {
                string strLog = "Set inventory scan time success ";
                WriteLog(lrtxtLog, strLog, 0);
            }
        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }
        private void timer_RealTime_Tick(object sender, EventArgs e)
        {
            if (fIsInventoryScan) return;
            fIsInventoryScan = true;

            fIsInventoryScan = false;
        }

        private void radioButton_band8_CheckedChanged(object sender, EventArgs e)
        {
            int i;
            ComboBox_dmaxfre.Items.Clear();
            ComboBox_dminfre.Items.Clear();
            cmbReturnLossFreq.Items.Clear();
            for (i = 0; i < 20; i++)
            {
                ComboBox_dminfre.Items.Add(Convert.ToString(840.125 + i * 0.25) + " MHz");
                ComboBox_dmaxfre.Items.Add(Convert.ToString(840.125 + i * 0.25) + " MHz");
                cmbReturnLossFreq.Items.Add(Convert.ToString(840.125 + i * 0.25));
            }
            ComboBox_dmaxfre.SelectedIndex = 19;
            ComboBox_dminfre.SelectedIndex = 0;
            cmbReturnLossFreq.SelectedIndex = 10;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            byte WritePower = 0;
            WritePower = (byte)(com_wpower.SelectedIndex);
            if (rb_wp1.Checked)
            {
                ;// WritePower = WritePower;
            }
            else
            {
                WritePower = Convert.ToByte(WritePower | 0x80);
            }
            fCmdRet = RWDev.WriteRfPower(ref fComAdr, WritePower, frmcomportindex);
            if (fCmdRet != 0)
            {
                string strLog = "Set failed： " + GetReturnCodeDesc(fCmdRet);
                WriteLog(lrtxtLog, strLog, 1);
            }
            else
            {
                string strLog = "Set success ";
                WriteLog(lrtxtLog, strLog, 0);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte WritePower = 0;
            fCmdRet = RWDev.ReadRfPower(ref fComAdr, ref WritePower, frmcomportindex);
            if (fCmdRet != 0)
            {
                string strLog = "Get failed: " + GetReturnCodeDesc(fCmdRet);
                WriteLog(lrtxtLog, strLog, 1);
            }
            else
            {
                if ((WritePower & 0x80) == 0)
                {
                    rb_wp1.Checked = true;
                    com_wpower.SelectedIndex = Convert.ToInt32(WritePower);
                }
                else
                {
                    com_wpower.SelectedIndex = Convert.ToInt32(WritePower & 0x3F);
                    rb_wp2.Checked = true;
                }
                string strLog = "Get success ";
                WriteLog(lrtxtLog, strLog, 0);
            }
        }

        private void bt_Setretry_Click(object sender, EventArgs e)
        {
            byte RetryTime = 0;
            RetryTime = (byte)(com_retrytimes.SelectedIndex | 0x80);
            fCmdRet = RWDev.RetryTimes(ref fComAdr, ref RetryTime, frmcomportindex);
            if (fCmdRet != 0)
            {
                string strLog = "Set failed： " + GetReturnCodeDesc(fCmdRet);
                WriteLog(lrtxtLog, strLog, 1);
            }
            else
            {
                string strLog = "Set success ";
                WriteLog(lrtxtLog, strLog, 0);
            }
        }

        private void bt_Getretry_Click(object sender, EventArgs e)
        {
            byte Times = 0;
            fCmdRet = RWDev.RetryTimes(ref fComAdr, ref Times, frmcomportindex);
            if (fCmdRet != 0)
            {
                string strLog = "Get failed: " + GetReturnCodeDesc(fCmdRet);
                WriteLog(lrtxtLog, strLog, 1);
            }
            else
            {
                com_retrytimes.SelectedIndex = Convert.ToInt32(Times);
                string strLog = "Get success ";
                WriteLog(lrtxtLog, strLog, 0);
            }
        }

        private void rb_epc_CheckedChanged(object sender, EventArgs e)
        {
            gbp_MixRead.Enabled = false;
            com_S.Items.Clear();
            com_S.Items.Add("0");
            com_S.Items.Add("1");
            com_S.Items.Add("2");
            com_S.Items.Add("3");
            com_S.Items.Add("Auto-1");
            if (ModeType == 2)
            {
                com_S.Items.Add("Auto-2");
                com_S.Items.Add("Auto-3");
                com_S.SelectedIndex = 5;
            }
            else
            {
                com_S.SelectedIndex = 4;
            }
        }


        private void rb_mix_CheckedChanged(object sender, EventArgs e)
        {
            gbp_MixRead.Enabled = true;
            com_S.Items.Clear();
            com_S.Items.Add("0");
            com_S.Items.Add("1");
            com_S.Items.Add("2");
            com_S.Items.Add("3");
            com_S.SelectedIndex = 0;
            com_MixMem.Enabled = true;
            text_readpsd.Enabled = true;
            gbp_MixRead.Text = "Mix";
        }

        private void rb_tid_CheckedChanged(object sender, EventArgs e)
        {
            gbp_MixRead.Enabled = true;
            com_S.Items.Clear();
            com_S.Items.Add("0");
            com_S.Items.Add("1");
            com_S.Items.Add("2");
            com_S.Items.Add("3");
            com_S.SelectedIndex = 0;
            com_MixMem.Enabled = false;
            text_readpsd.Enabled = false;
            gbp_MixRead.Text = "TID";
        }

        private void rb_fastid_CheckedChanged(object sender, EventArgs e)
        {
            gbp_MixRead.Enabled = false;
            com_S.Items.Clear();
            com_S.Items.Add("0");
            com_S.Items.Add("1");
            com_S.Items.Add("2");
            com_S.Items.Add("3");
            com_S.Items.Add("Auto-1");
            if (ModeType == 2)
            {
                com_S.Items.Add("Auto-2");
                com_S.Items.Add("Auto-3");
                com_S.SelectedIndex = 5;
            }
            else
            {
                com_S.SelectedIndex = 4;
            }
        }

        private void bt_setDRM_Click(object sender, EventArgs e)
        {
            byte DRM = 0;
            if (DRM_CLOSE.Checked) DRM = 0;
            if (DRM_OPEN.Checked) DRM = 1;
            fCmdRet = RWDev.SetDRM(ref fComAdr, DRM, frmcomportindex);
            if (fCmdRet != 0)
            {
                string strLog = "Set DRM failed： " + GetReturnCodeDesc(fCmdRet);
                WriteLog(lrtxtLog, strLog, 1);
            }
            else
            {
                string strLog = "Set DRM success ";
                WriteLog(lrtxtLog, strLog, 0);
            }
        }

        private void bt_GetDRM_Click(object sender, EventArgs e)
        {
            byte DRM = 0;
            fCmdRet = RWDev.GetDRM(ref fComAdr, ref DRM, frmcomportindex);
            if (fCmdRet != 0)
            {
                string strLog = "Get DRM failed： " + GetReturnCodeDesc(fCmdRet);
                WriteLog(lrtxtLog, strLog, 1);
            }
            else
            {
                if (DRM == 0) DRM_CLOSE.Checked = true;
                if (DRM == 1) DRM_OPEN.Checked = true;
                string strLog = "Get DRM success ";
                WriteLog(lrtxtLog, strLog, 0);
            }
        }

        private void check_int2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnGetReaderTemperature_Click(object sender, EventArgs e)
        {

            byte PlusMinus = 0;
            byte Temperature = 0;
            string temp = "";
            txtReaderTemperature.Text = "";
            fCmdRet = RWDev.GetReaderTemperature(ref fComAdr, ref PlusMinus, ref Temperature, frmcomportindex);
            if (fCmdRet != 0)
            {
                string strLog = "Get Temperature failed: " + GetReturnCodeDesc(fCmdRet);
                WriteLog(lrtxtLog, strLog, 1);
            }
            else
            {
                if (PlusMinus == 0)
                    temp = "-";
                temp += (Temperature.ToString() + "°C");
                txtReaderTemperature.Text = temp;
                string strLog = "Get Temperature success ";
                WriteLog(lrtxtLog, strLog, 0);
            }
        }

        private void btReturnLoss_Click(object sender, EventArgs e)
        {
            byte[] TestFreq = new byte[4];
            byte Ant = (byte)cbbAnt.SelectedIndex;
            byte ReturnLoss = 0;
            string temp = cmbReturnLossFreq.Text;

            float freq = Convert.ToSingle(Convert.ToSingle(temp) * 1000);
            int freq0 = Convert.ToInt32(freq);
            temp = Convert.ToString(freq0, 16).PadLeft(8, '0');
            TestFreq = HexStringToByteArray(temp);
            textReturnLoss.Text = "";
            fCmdRet = RWDev.MeasureReturnLoss(ref fComAdr, TestFreq, Ant, ref ReturnLoss, frmcomportindex);
            if (fCmdRet != 0)
            {
                string strLog = "Get failed:  " + GetReturnCodeDesc(fCmdRet);
                WriteLog(lrtxtLog, strLog, 1);
            }
            else
            {
                textReturnLoss.Text = ReturnLoss.ToString() + "dB";
                string strLog = "Get success ";
                WriteLog(lrtxtLog, strLog, 0);
            }
        }

        private void radioButton_band12_CheckedChanged(object sender, EventArgs e)
        {
            int i;
            ComboBox_dmaxfre.Items.Clear();
            ComboBox_dminfre.Items.Clear();
            cmbReturnLossFreq.Items.Clear();
            for (i = 0; i < 53; i++)
            {
                ComboBox_dminfre.Items.Add(Convert.ToString(902 + i * 0.5) + " MHz");
                ComboBox_dmaxfre.Items.Add(Convert.ToString(902 + i * 0.5) + " MHz");
                cmbReturnLossFreq.Items.Add(Convert.ToString(902 + i * 0.5));
            }
            ComboBox_dmaxfre.SelectedIndex = 52;
            ComboBox_dminfre.SelectedIndex = 0;
            cmbReturnLossFreq.SelectedIndex = 26;
        }

        private void radioButton_band0_CheckedChanged(object sender, EventArgs e)
        {
            int i;
            ComboBox_dmaxfre.Items.Clear();
            ComboBox_dminfre.Items.Clear();
            cmbReturnLossFreq.Items.Clear();
            for (i = 0; i < 61; i++)
            {
                ComboBox_dminfre.Items.Add(Convert.ToString(840 + i * 2) + " MHz");
                ComboBox_dmaxfre.Items.Add(Convert.ToString(840 + i * 2) + " MHz");
                cmbReturnLossFreq.Items.Add(Convert.ToString(840 + i * 2));
            }
            ComboBox_dmaxfre.SelectedIndex = 60;
            ComboBox_dminfre.SelectedIndex = 0;
            cmbReturnLossFreq.SelectedIndex = 30;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            byte Profile = 0;
            if (ModeType == 0)
            {
                if (comboBox4.SelectedIndex == 0) Profile = 0x90;
                if (comboBox4.SelectedIndex == 1) Profile = 0x91;
                if (comboBox4.SelectedIndex == 2) Profile = 0x92;
                if (comboBox4.SelectedIndex == 3) Profile = 0x93;
                if (comboBox4.SelectedIndex == 4) Profile = 0x94;
            }
            else if (ModeType == 1)
            {
                if (comboBox4.SelectedIndex == 0) Profile = 0x80;
                if (comboBox4.SelectedIndex == 1) Profile = 0x81;
                if (comboBox4.SelectedIndex == 2) Profile = 0x82;
                if (comboBox4.SelectedIndex == 3) Profile = 0x83;
            }
            else if (ModeType == 2)
            {
                if (comboBox4.SelectedIndex == 0) Profile = 11;
                if (comboBox4.SelectedIndex == 1) Profile = 1;
                if (comboBox4.SelectedIndex == 2) Profile = 15;
                if (comboBox4.SelectedIndex == 3) Profile = 12;
                if (comboBox4.SelectedIndex == 4) Profile = 3;
                if (comboBox4.SelectedIndex == 5) Profile = 5;
                if (comboBox4.SelectedIndex == 6) Profile = 7;
                if (comboBox4.SelectedIndex == 7) Profile = 13;
                if (comboBox4.SelectedIndex == 8) Profile = 50;
                if (comboBox4.SelectedIndex == 9) Profile = 51;
                if (comboBox4.SelectedIndex == 10) Profile = 52;
                if (comboBox4.SelectedIndex == 11) Profile = 53;
                Profile |= 0x80;
            }
            else if (ModeType == 4)
            {
                if (comboBox4.SelectedIndex == 0) Profile = 0x20;
                if (comboBox4.SelectedIndex == 1) Profile = 0x21;
                if (comboBox4.SelectedIndex == 2) Profile = 0x22;
                if (comboBox4.SelectedIndex == 3) Profile = 0x23;
                if (comboBox4.SelectedIndex == 4) Profile = 0x24;
                if (comboBox4.SelectedIndex == 5) Profile = 0x25;
                if (comboBox4.SelectedIndex == 6) Profile = 0x26;
                if (comboBox4.SelectedIndex == 7) Profile = 0x27;
                if (comboBox4.SelectedIndex == 8) Profile = 0x28;
                Profile |= 0x80;
            }
            fCmdRet = RWDev.SetProfile(ref fComAdr, ref Profile, frmcomportindex);
            if (fCmdRet != 0)
            {
                string strLog = "Set RF-Link Profile failed, " + GetReturnCodeDesc(fCmdRet);
                WriteLog(lrtxtLog, strLog, 1);
            }
            else
            {
                string strLog = "Set RF-Link Profile success ";
                WriteLog(lrtxtLog, strLog, 0);
                RF_Profile = Profile;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            byte Profile = 0;
            fCmdRet = RWDev.SetProfile(ref fComAdr, ref Profile, frmcomportindex);
            if (fCmdRet != 0)
            {
                string strLog = "Get RF-Link Profile failed, " + GetReturnCodeDesc(fCmdRet);
                WriteLog(lrtxtLog, strLog, 1);
            }
            else
            {
                if (ModeType == 0)
                {
                    if (Profile == 0x10) comboBox4.SelectedIndex = 0;
                    if (Profile == 0x11) comboBox4.SelectedIndex = 1;
                    if (Profile == 0x12) comboBox4.SelectedIndex = 2;
                    if (Profile == 0x13) comboBox4.SelectedIndex = 3;
                    if (Profile == 0x14) comboBox4.SelectedIndex = 4;
                }
                else if (ModeType == 1)
                {
                    if (Profile == 0x00) comboBox4.SelectedIndex = 0;
                    if (Profile == 0x01) comboBox4.SelectedIndex = 1;
                    if (Profile == 0x02) comboBox4.SelectedIndex = 2;
                    if (Profile == 0x03) comboBox4.SelectedIndex = 3;
                }
                else if (ModeType == 2)
                {
                    if (Profile == 11) comboBox4.SelectedIndex = 0;
                    if (Profile == 1) comboBox4.SelectedIndex = 1;
                    if (Profile == 15) comboBox4.SelectedIndex = 2;
                    if (Profile == 12) comboBox4.SelectedIndex = 3;
                    if (Profile == 3) comboBox4.SelectedIndex = 4;
                    if (Profile == 5) comboBox4.SelectedIndex = 5;
                    if (Profile == 7) comboBox4.SelectedIndex = 6;
                    if (Profile == 13) comboBox4.SelectedIndex = 7;
                    if (Profile == 50) comboBox4.SelectedIndex = 8;
                    if (Profile == 51) comboBox4.SelectedIndex = 9;
                    if (Profile == 52) comboBox4.SelectedIndex = 10;
                    if (Profile == 53) comboBox4.SelectedIndex = 11;
                    RF_Profile = Profile;
                }
                else if (ModeType == 4)
                {
                    if (Profile == 0x20) comboBox4.SelectedIndex = 0;
                    if (Profile == 0x21) comboBox4.SelectedIndex = 1;
                    if (Profile == 0x22) comboBox4.SelectedIndex = 2;
                    if (Profile == 0x23) comboBox4.SelectedIndex = 3;
                    if (Profile == 0x24) comboBox4.SelectedIndex = 4;
                    if (Profile == 0x25) comboBox4.SelectedIndex = 5;
                    if (Profile == 0x26) comboBox4.SelectedIndex = 6;
                    if (Profile == 0x27) comboBox4.SelectedIndex = 7;
                    if (Profile == 0x28) comboBox4.SelectedIndex = 8;
                    RF_Profile = Profile;
                }
                string strLog = "Get RF-Link Profile success ";
                WriteLog(lrtxtLog, strLog, 0);
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }



        private void ChangeShow(int mtype)
        {
            com_MixMem.Items.Clear();
            if (mtype == 0)
            {
                com_MixMem.Items.Add("Reserve");
                com_MixMem.Items.Add("EPC");
                com_MixMem.Items.Add("TID");
                com_MixMem.Items.Add("User");
                com_MixMem.SelectedIndex = 2;
                rb_epc.Text = "EPC";
   
            }
            else
            {
                com_MixMem.Items.Add("Reserve");
                com_MixMem.Items.Add("MUII");
                com_MixMem.Items.Add("CID");
                com_MixMem.Items.Add("User");
                com_MixMem.SelectedIndex = 2;
                rb_epc.Text = "MUII";


            }
        }




        private byte[] NumtoBytes(int num)
        {
            byte[] data = new byte[2];
            data[0] = (byte)(num >> 8);
            data[1] = (byte)(num & 0xFF);
            return data;
        }


        private volatile bool jbIsInventoryScan = false;
        private volatile bool jbStopThread = false;
        private Thread jbthread = null;

        byte jbMaskMem;
        byte[] jbMaskAdr = new byte[4];
        byte jbMaskLen = 0;
        byte[] jbMaskData = new byte[256];
        byte jbMaskFlag = 0;
        byte Algo = 0;

        private void Maintab_Selecting(object sender, TabControlCancelEventArgs e)
        {
            //if ((mythread != null) || (jbthread != null) || (gbthread != null))
            //{
            //    e.Cancel = true;
            //    MessageBox.Show("Close current Thread first!!!");
            //    return;
            //}
        }

        private void GetJBconfiginfo(int index, ref byte Cfg, ref byte Action)
        {
            switch (index)
            {
                case 0:
                    Cfg = 0;
                    Action = 0;
                    break;
                case 1:
                    Cfg = 0;
                    Action = 1;
                    break;
                case 2:
                    Cfg = 0;
                    Action = 2;
                    break;
                case 3:
                    Cfg = 0;
                    Action = 3;
                    break;
            }
        }



        private volatile bool gbIsInventoryScan = false;
        private volatile bool gbStopThread = false;
        private Thread gbthread = null;

        byte gbMaskMem;
        byte[] gbMaskAdr = new byte[4];
        byte gbMaskLen = 0;
        byte[] gbMaskData = new byte[256];
        byte gbMaskFlag = 0;


        private byte GetGBSelectMem(int index)
        {
            switch (index)
            {
                case 0:
                    return 0x00;
                case 1:
                    return 0x10;
                case 2:
                    return 0x20;
                case 3:
                    return 0x30;
                case 4:
                    return 0x31;
                case 5:
                    return 0x32;
                case 6:
                    return 0x33;
                case 7:
                    return 0x34;
                case 8:
                    return 0x35;
                case 9:
                    return 0x36;
                case 10:
                    return 0x37;
                case 11:
                    return 0x38;
                case 12:
                    return 0x39;
                case 13:
                    return 0x3A;
                case 14:
                    return 0x3B;
                case 15:
                    return 0x3C;
                case 16:
                    return 0x3D;
                case 17:
                    return 0x3E;
                case 18:
                    return 0x3F;
                default:
                    return 0x00;
            }
        }



        private void getGBConfiginfo(int index, ref byte Cfg, ref byte Action)
        {
            switch (index)
            {
                case 0:
                    Cfg = 0;
                    Action = 0;
                    break;
                case 1:
                    Cfg = 0;
                    Action = 1;
                    break;
                case 2:
                    Cfg = 0;
                    Action = 2;
                    break;
                case 3:
                    Cfg = 0;
                    Action = 3;
                    break;
                case 4:
                    Cfg = 1;
                    Action = 1;
                    break;
                case 5:
                    Cfg = 1;
                    Action = 2;
                    break;
                case 6:
                    Cfg = 1;
                    Action = 3;
                    break;
            }
        }



        private void btSetRfPower_Click(object sender, EventArgs e)
        {
            byte[] powerDbm = new byte[16];
            if ((txtPower1.Text.Length == 0) || (Convert.ToByte(txtPower1.Text, 10) > 36))
            {
                return;
            }
            if ((txtPower2.Text.Length == 0) || (Convert.ToByte(txtPower2.Text, 10) > 36))
            {
                return;
            }
            if ((txtPower3.Text.Length == 0) || (Convert.ToByte(txtPower3.Text, 10) > 36))
            {
                return;
            }
            if ((txtPower4.Text.Length == 0) || (Convert.ToByte(txtPower4.Text, 10) > 36))
            {
                return;
            }

            powerDbm[0] = Convert.ToByte(txtPower1.Text, 10);
            powerDbm[1] = Convert.ToByte(txtPower2.Text, 10);
            powerDbm[2] = Convert.ToByte(txtPower3.Text, 10);
            powerDbm[3] = Convert.ToByte(txtPower4.Text, 10);

            if (!checkBox3.Checked)
            {
                powerDbm[0] |= 0x80;
                powerDbm[1] |= 0x80;
                powerDbm[2] |= 0x80;
                powerDbm[3] |= 0x80;
                powerDbm[4] |= 0x80;
                powerDbm[5] |= 0x80;
                powerDbm[6] |= 0x80;
                powerDbm[7] |= 0x80;

                powerDbm[8] |= 0x80;
                powerDbm[9] |= 0x80;
                powerDbm[10] |= 0x80;
                powerDbm[11] |= 0x80;
                powerDbm[12] |= 0x80;
                powerDbm[13] |= 0x80;
                powerDbm[14] |= 0x80;
                powerDbm[15] |= 0x80;
            }
            fCmdRet = RWDev.SetAntennaPower(ref fComAdr, powerDbm, AntennaNum, frmcomportindex);
            if (fCmdRet != 0)
            {
                string strLog = "Set Power failed： " + GetReturnCodeDesc(fCmdRet);
                WriteLog(lrtxtLog, strLog, 1);
            }
            else
            {
                string strLog = "Set Power success ";
                WriteLog(lrtxtLog, strLog, 0);
            }
        }

        private void btGetRfPower_Click(object sender, EventArgs e)
        {
            byte[] powerDbm = new byte[16];
            int length = 0;
            fCmdRet = RWDev.GetAntennaPower(ref fComAdr, powerDbm, ref length, frmcomportindex);
            if (fCmdRet != 0)
            {
                string strLog = "Get Power failed： " + GetReturnCodeDesc(fCmdRet);
                WriteLog(lrtxtLog, strLog, 1);
            }
            else
            {
                switch (length)
                {
                    case 1:
                        txtPower1.Text = powerDbm[0].ToString();
                        break;
                    case 4:
                        txtPower1.Text = powerDbm[0].ToString();
                        txtPower2.Text = powerDbm[1].ToString();
                        txtPower3.Text = powerDbm[2].ToString();
                        txtPower4.Text = powerDbm[3].ToString();
                        break;
                    case 8:
                        txtPower1.Text = powerDbm[0].ToString();
                        txtPower2.Text = powerDbm[1].ToString();
                        txtPower3.Text = powerDbm[2].ToString();
                        txtPower4.Text = powerDbm[3].ToString();

                        break;
                    case 16:
                        txtPower1.Text = powerDbm[0].ToString();
                        txtPower2.Text = powerDbm[1].ToString();
                        txtPower3.Text = powerDbm[2].ToString();
                        txtPower4.Text = powerDbm[3].ToString();

                        break;
                }

                string strLog = "Get Power success ";
                WriteLog(lrtxtLog, strLog, 0);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            byte opt = 1;
            if (checkBox6.Checked) opt = 0;
            byte cfgNo = 7;
            byte[] cfgData = new byte[256];
            int len = 3;
            cfgData[0] = (byte)com_queryInter.SelectedIndex;
            cfgData[1] = (byte)(cbb_dwell.SelectedIndex + 2);
            cfgData[2] = (byte)cbb_add.SelectedIndex;
            int fCmdRet = RWDev.SetCfgParameter(ref fComAdr, opt, cfgNo, cfgData, len, frmcomportindex);
            if (fCmdRet != 0)
            {
                string strLog = "Set parameter failed： " + GetReturnCodeDesc(fCmdRet);
                WriteLog(lrtxtLog, strLog, 1);
            }
            else
            {
                string strLog = "Set parameter success ";
                WriteLog(lrtxtLog, strLog, 0);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            byte cfgNo = 7;
            byte[] cfgData = new byte[256];
            int len = 0;
            int fCmdRet = RWDev.GetCfgParameter(ref fComAdr, cfgNo, cfgData, ref len, frmcomportindex);
            if (fCmdRet != 0)
            {
                string strLog = "Get parameter failed： " + GetReturnCodeDesc(fCmdRet);
                WriteLog(lrtxtLog, strLog, 1);
            }
            else
            {
                if (len == 3)
                {
                    com_queryInter.SelectedIndex = cfgData[0];
                    cbb_dwell.SelectedIndex = cfgData[1] - 2;
                    cbb_add.SelectedIndex = cfgData[2];
                }
                string strLog = "Get parameter success ";
                WriteLog(lrtxtLog, strLog, 0);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            byte enFlag = 1;
            if (rb_enable.Checked) enFlag = 1;
            else
                enFlag = 0;
            byte cfgNo = 8;
            byte[] cfgData = new byte[256];
            int len = 1;
            cfgData[0] = (byte)enFlag;
            int fCmdRet = RWDev.SetCfgParameter(ref fComAdr, 0, cfgNo, cfgData, len, frmcomportindex);
            if (fCmdRet != 0)
            {
                string strLog = "Set parameter failed： " + GetReturnCodeDesc(fCmdRet);
                WriteLog(lrtxtLog, strLog, 1);
            }
            else
            {
                string strLog = "Set parameter success ";
                WriteLog(lrtxtLog, strLog, 0);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            byte cfgNo = 8;
            byte[] cfgData = new byte[256];
            int len = 0;
            int fCmdRet = RWDev.GetCfgParameter(ref fComAdr, cfgNo, cfgData, ref len, frmcomportindex);
            if (fCmdRet != 0)
            {
                string strLog = "Get parameter failed： " + GetReturnCodeDesc(fCmdRet);
                WriteLog(lrtxtLog, strLog, 1);
            }
            else
            {
                if (len == 1)
                {
                    if (cfgData[0] == 1)
                    {
                        rb_enable.Checked = true;
                    }
                    else
                    {
                        rb_disable.Checked = true;
                    }
                }
                string strLog = "Get parameter sucess ";
                WriteLog(lrtxtLog, strLog, 0);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ParamSetting mSet = new ParamSetting();
            mSet.ShowDialog();
        }


        public byte GetSession()
        {
            byte cfgNum = 0x09;
            byte[] data = new byte[256];
            int len = 0;
            int fCmdRet = RWDev.GetCfgParameter(ref fComAdr, cfgNum, data, ref len, frmcomportindex);
            if (fCmdRet == 0)
            {
                return data[1];
            }
            else
            {
                return 1;
            }
        }


        private void text_target_TextChanged(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            if ((textBox2.Text == "") || (textBox1.Text == "") || (comboBox6.Text == "")) return;
            byte freSpace = 0;
            byte freNum = 0;
            byte[] freStart = new byte[3];
            byte opt = 0;
            if (!checkBox7.Checked) opt = 1;
            freSpace = Convert.ToByte(textBox2.Text, 10);
            freNum = (byte)(comboBox6.SelectedIndex + 1);
            int freq = Convert.ToInt32(textBox1.Text, 10);
            freStart[0] = (byte)(freq >> 16);
            freStart[1] = (byte)(freq >> 8);
            freStart[2] = (byte)(freq);
            int fCmdRet = RWDev.SetCustomRegion(ref fComAdr, opt, freSpace, freNum, freStart, frmcomportindex);
            if (fCmdRet != 0)
            {
                string strLog = "Set custom region failed, " + GetReturnCodeDesc(fCmdRet);
                WriteLog(lrtxtLog, strLog, 1);
            }
            else
            {
                string strLog = "Set custom region success ";
                WriteLog(lrtxtLog, strLog, 0);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            byte freSpace = 0;
            byte freNum = 0;
            byte[] freStart = new byte[3];
            int fCmdRet = RWDev.GetCustomRegion(ref fComAdr, ref freSpace, ref freNum, freStart, frmcomportindex);
            if (fCmdRet != 0)
            {
                string strLog = "Get custom region failed," + GetReturnCodeDesc(fCmdRet);
                WriteLog(lrtxtLog, strLog, 1);
            }
            else
            {
                textBox1.Text = (freStart[0] << 16) + (freStart[1] << 8) + (freStart[2]) + "";
                comboBox6.SelectedIndex = freNum - 1;
                textBox2.Text = freSpace + "";
                string strLog = "Get custom region success ";
                WriteLog(lrtxtLog, strLog, 0);
            }
        }


        List<string> ulist = new List<string>();

      
        string filePathData;


        string connectstring = @"Data Source=DESKTOP-HBDOM8V\SQLEXPRESS;Initial Catalog=Test_DB;Integrated Security=True"; //Data Source=sqldatabaserfid.database.windows.net;Initial Catalog=RFID_DB;Persist Security Info=True;User ID=RFID;Password=Admin123
        SqlConnection con;
        DataTable dataTableTestSQL = new DataTable();

        private void Main_Page1_Click(object sender, EventArgs e)
        {

        }
        // export




   
        public void scanData()
        {

            if (btIventoryG2.Text == "Start")
            {
                btIventoryG2.ForeColor = Color.DarkBlue;
                //timer1.Enabled = true;
                // lxLedControl1.Text = "0";
                lxLedControl2.Text = "0";
                lxLedControl3.Text = "0";
                lxLedControl4.Text = "0";
                lxLedControl5.Text = "0";
                lxLedControl6.Text = "0";
                //reflasg = false;
                //epclist.Clear();
                //tidlist.Clear();
                //curList.Clear();
                //dataGridView1.DataSource = null;
                //lrtxtLog.Clear();
                //comboBox_EPC.Items.Clear();
                //text_epc.Text = "";
                //AA_times = 0;

                Scantime = Convert.ToByte(com_scantime.SelectedIndex);
                if (checkBox_rate.Checked)
                    Qvalue = Convert.ToByte(com_Q.SelectedIndex | 0x80);
                else
                    Qvalue = Convert.ToByte(com_Q.SelectedIndex);

                if (ModeType == 2)
                {
                    Profile = (byte)(RF_Profile | 0xC0);
                    fCmdRet = RWDev.SetProfile(ref fComAdr, ref Profile, frmcomportindex);
                }

                if (com_S.SelectedIndex == 4)
                {
                    readMode = 255;
                }
                else if (com_S.SelectedIndex < 4)
                {
                    readMode = Convert.ToByte(com_S.SelectedIndex);
                }
                else if (com_S.SelectedIndex == 5)
                {
                    readMode = 254;
                }
                else if (com_S.SelectedIndex == 6)
                {
                    readMode = 253;
                }

                if (rb_epc.Checked)
                {
                    TIDFlag = 0;
                    scanType = 0;
                }
                else
                {
                    scanType = 3;
                }

                if (check_phase.Checked) Qvalue |= 0x10;

                //total_tagnum = 0;
                targettimes = Convert.ToInt32(text_target.Text);
                total_time = System.Environment.TickCount;
                fIsInventoryScan = false;
                btIventoryG2.BackColor = Color.Indigo;
                btIventoryG2.ForeColor = Color.White;
                btIventoryG2.Text = "Stop";
                Array.Clear(antlist, 0, 16);
                int SelectAntenna = 0;
                if (check_ant1.Checked)
                {
                    antlist[0] = 1;
                    InAnt = 0x80;
                    SelectAntenna |= 0x0001;
                }
                if (check_ant2.Checked)
                {
                    antlist[1] = 1;
                    InAnt = 0x81;
                    SelectAntenna |= 0x0002;
                }
                if (check_ant3.Checked)
                {
                    antlist[2] = 1;
                    InAnt = 0x82;
                    SelectAntenna |= 0x0004;
                }
                if (check_ant4.Checked)
                {
                    antlist[3] = 1;
                    InAnt = 0x83;
                    SelectAntenna |= 0x0008;
                }



                PresetTarget(readMode, SelectAntenna);

                Target = (byte)com_Target.SelectedIndex;
                toStopThread = false;
                if (fIsInventoryScan == false)
                {
                    mythread = new Thread(new ThreadStart(inventory));
                    mythread.IsBackground = true;
                    mythread.Start();
                    timer_answer.Enabled = true;
                }
            
                rb_epc.Enabled = false;

            }
        }


        private void StopscanData ()
        {

            if (btIventoryG2.Text != "Start")
            {
                //timer1.Enabled = false;
                RWDev.StopImmediately(ref fComAdr, frmcomportindex);
                toStopThread = true;
                btIventoryG2.Enabled = false;
                btIventoryG2.BackColor = Color.Transparent;
                btIventoryG2.ForeColor = Color.DarkBlue;
                btIventoryG2.Text = "Stoping";
            }
        }


        private Process aspNetCoreProcess;

        
        private async void SendEPCList()
        {
            try
            {
                string jsonEPCList = JsonConvert.SerializeObject(epclist);
                await _hubConnection.SendAsync("EPCList", jsonEPCList);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sending EPC list: " + ex.Message);
            }
        }
        bool isConnected = false;
        private HubConnection _hubConnection;
        public async void ConnectToHub()
        {
            _hubConnection = new HubConnectionBuilder()
                .WithUrl("http://localhost:7024/scanhub")
                .Build();

            RegisterHubEvents();

            _hubConnection.Closed += async (error) =>
            {
                isConnected = false;
                WriteLog(lrtxtLog, "Connection lost. Attempting to reconnect...", 1);
                await Task.Delay(1000);  

                ConnectToHub(); 
            };

            try
            {
                await _hubConnection.StartAsync();
                isConnected = true;
                WriteLog(lrtxtLog, "Connect to web api successfully", 1);
            }
            catch (Exception ex)
            {
                WriteLog(lrtxtLog, "Connection error: " + ex.Message, 1);
                await Task.Delay(1000);  
                ConnectToHub(); 
            }
        }

        private void RegisterHubEvents()
        {
            _hubConnection.On("ReceiveMessage", (string message) =>
            {
                ProcessReceivedMessage(message);
            });
        }

        private void ProcessReceivedMessage(string message)
        {
            if (message.StartsWith("Lamp:"))
            {
                var parts = message.Split(':');
                string mode = parts[1];
                string lampId = parts[2];
                float time = float.Parse(parts[3]);

                if (lampId == "green")
                {
                    if (mode == "simple")
                    {
                        this.Invoke((Action)(() => onGreenLamp(time)));
                    }
                    else if (mode == "blink")
                    {
                        this.Invoke((Action)(() => blinkGreenLamp(time)));
                    }
                }
                else if (lampId == "red")
                {
                    if (mode == "simple")
                    {
                        this.Invoke((Action)(() => onRedLamp(time)));
                    }
                    else if (mode == "blink")
                    {
                        this.Invoke((Action)(() => blinkRedLamp(time)));
                    }
                }
            }
            else if (message.StartsWith("Buzzer:"))
            {
                float time = float.Parse(message.Split(':')[1]);
                this.Invoke((Action)(() => onBuzzer(time)));
            }
            else if (message == "ClearAllData")
            {
                this.Invoke((Action)refesh);
            }
            else if (message.StartsWith("Mode:"))
            {
                int mode = int.Parse(message.Split(':')[1]);
                this.Invoke((Action)(() => selectMode(mode)));
            }
            else if (message.StartsWith("RemoveData:"))
            {
                string epcRemove = message.Split(':')[1];
                this.Invoke((Action)(() => RemoveDataEpc(epcRemove)));
            }
            else if (message == "StartScan")
            {
                this.Invoke((Action)scanData);
            }
            else if (message == "StopScan")
            {
                this.Invoke((Action)StopscanData);
            }
            else if (message == "Request")
            {
                this.Invoke((Action)UpdateDataEPCApi);
            }
        }


        public void PrintDataTable(DataTable dt)
        {
            if (dt == null)
            {
                Console.WriteLine("DataTable is null.");
                return;
            }

            if (dt.Columns.Count == 0)
            {
                Console.WriteLine("DataTable has no columns.");
                return;
            }
            foreach (DataColumn column in dt.Columns)
            {
                Console.Write(column.ColumnName + "\t");
            }
            Console.WriteLine();

            foreach (DataRow row in dt.Rows)
            {
                foreach (DataColumn column in dt.Columns)
                {
                    Console.Write(row[column] + "\t");
                }
                Console.WriteLine();
            }
        }
        private void UpdateDataTableFromDataGridView(DataTable dt)
        {

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                dt.Columns.Add(column.Name, column.ValueType);
            }

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow) 
                {
                    DataRow dataRow = dt.NewRow();
                    foreach (DataGridViewColumn column in dataGridView1.Columns)
                    {
                        dataRow[column.Name] = row.Cells[column.Index].Value;
                    }
                    dt.Rows.Add(dataRow);
                }
            }
        }

        


       

        private void btConnectMCU_Click(object sender, EventArgs e)
        {
            if (comboBoxBaud.SelectedItem == null)
            {
                MessageBox.Show("You have not selected baudrate.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (!serialPort2.IsOpen)
                {
                    try
                    {
                        Control.CheckForIllegalCrossThreadCalls = false;
                        serialPort2.PortName = comboBoxPort.SelectedItem.ToString();
                        serialPort2.BaudRate = int.Parse(comboBoxBaud.SelectedItem.ToString());
                        serialPort2.Open();
                        btConnectMCU.Enabled = false;
                        btDisConnectMCU.Enabled = true;

                        comboBoxPort.Enabled = false;
                        comboBoxBaud.Enabled = false;
                        btConnectMCU.ForeColor = Color.Black;
                        btDisConnectMCU.ForeColor = Color.Indigo;
                        WriteLog(lrtxtLog, "Successfully connected to " + comboBoxPort.SelectedItem?.ToString(), 1);
                    }
                    catch (UnauthorizedAccessException)
                    {
                        MessageBox.Show("Access to the port is denied. Please check if the port is already in use or you do not have the necessary permissions.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            SaveSettings();
        }
        public void onGreenLamp(float time)
        {
            if (serialPort2.IsOpen)
            {
                serialPort2.Write("G");
                serialPort2.Write("0");
                serialPort2.Write(time.ToString().PadLeft(8, '0'));
            }
            else
            {
                MessageBox.Show($"serialPort not available");
            }
        }
        public void blinkGreenLamp(float time)
        {
            if (serialPort2.IsOpen)
            {
                serialPort2.Write("G");
                serialPort2.Write("1");
                serialPort2.Write(time.ToString().PadLeft(8, '0'));
            }
            else
            {
                MessageBox.Show($"serialPort not available");
            }
        }
        public void onRedLamp(float time)
        {
            if (serialPort2.IsOpen)
            {
                serialPort2.Write("R");
                serialPort2.Write("0");
                serialPort2.Write(time.ToString().PadLeft(8, '0'));
            }
            else
            {
                MessageBox.Show($"serialPort not available");
            }
        }
        public void blinkRedLamp(float time)
        {
            if (serialPort2.IsOpen)
            {
                serialPort2.Write("R");
                serialPort2.Write("1");
     
                serialPort2.Write(time.ToString().PadLeft(8, '0'));
            }
            else
            {
                MessageBox.Show($"serialPort not available");
            }
        }
        public void onBuzzer(float time)
        {
            if (serialPort2.IsOpen)
            {
                serialPort2.Write("B");
                serialPort2.Write("1");
                serialPort2.Write(time.ToString().PadLeft(8, '0'));
            }
            else
            {
                MessageBox.Show($"serialPort not available");
            }
        }
        public void selectMode(int mode)
        {
            if (serialPort2.IsOpen)
            {
                if (mode == 1) //auto
                {
                    serialPort2.Write("M");
                    serialPort2.Write("1");
                    serialPort2.Write("********");
                    WriteLog(lrtxtLog, "Set Auto Mode successfuly", 1);
                }
                else if (mode == 0) //manual
                {
                    serialPort2.Write("M");
                    serialPort2.Write("0");
                    serialPort2.Write("********");
                    WriteLog(lrtxtLog, "Set Maunal Mode successfuly", 1);
                }
            }
            else
            {
                MessageBox.Show($"serialPort not available");
            }
        }

        private void btDisConnectMCU_Click(object sender, EventArgs e)
        {
            serialPort2.Close();
            btConnectMCU.Enabled = true;
            btDisConnectMCU.Enabled = false;
            comboBoxPort.Enabled = true;
            comboBoxBaud.Enabled = true;
            btConnectMCU.ForeColor = Color.Indigo;
            btDisConnectMCU.ForeColor = Color.Black;
        }

       

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
            //StopListeningForSerialPortChanges();
        }

        

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (serialPort2.IsOpen)
            {
                selectMode(1);
                button3.Enabled = false;
                button4.Enabled = true;
                
            }

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (serialPort2.IsOpen)
            {
                selectMode(0);
                button3.Enabled = true;
                button4.Enabled = false;
                
            }
        }

        private void serialPort2_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Console.WriteLine("DataReceived event triggered");

            if (serialPort2.BytesToRead >= 1)
            {
                byte[] buffer = new byte[1];
                serialPort2.Read(buffer, 0, 1);
                string receivedData = System.Text.Encoding.ASCII.GetString(buffer);

                //Console.WriteLine($"Received data: {receivedData}");

                Invoke((Action)(() =>
                {
                    WriteLog(lrtxtLog, receivedData, 1);
                    //Console.WriteLine("Log updated");
                }));

                if (receivedData == "1")
                {
                    Invoke((Action)(() =>
                    {
                        scanData();
                        //Console.WriteLine("scanData called");
                    }));
                }
                else if (receivedData == "0")
                {
                    Invoke((Action)(() =>
                    {
                        StopscanData();
                        //Console.WriteLine("StopscanData called");
                    }));
                }
            }


        }
        int power = 20;

        private void setPowerAuto_Click(object sender, EventArgs e)
        {
            byte powerDbm = (byte)power;
            fCmdRet = RWDev.SetRfPower(ref fComAdr, powerDbm, frmcomportindex);
            if (fCmdRet != 0)
            {
                string strLog = "Set power failed: " + GetReturnCodeDesc(fCmdRet);
                WriteLog(lrtxtLog, strLog, 1);
            }
            else
            {
                string strLog = "Set" + power + " power success ";
                WriteLog(lrtxtLog, strLog, 0);
                SaveSettings();
            }
            timer2.Enabled = true;
            
        }

        private void StopPowerAuto_Click(object sender, EventArgs e)
        {
            timer2.Enabled = false;
            WriteLog(lrtxtLog, "Stop Power Auto successfuly", 0);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if((power+=3) >29)
            {
                power = 20;
            }
            else
            {
                power += 3;
                byte powerDbm = (byte)power;
                fCmdRet = RWDev.SetRfPower(ref fComAdr, powerDbm, frmcomportindex);
                if (fCmdRet != 0)
                {
                    string strLog = "Set power failed: " + GetReturnCodeDesc(fCmdRet);
                    WriteLog(lrtxtLog, strLog, 1);
                }
                else
                {
                    string strLog = "Set" + power + " power success ";
                    WriteLog(lrtxtLog, strLog, 0);
                    SaveSettings();
                }

            }
            
        }

        //private void timer1_Tick_1(object sender, EventArgs e)
        //{
        //    UpdateDataEPCApi();
        //}
    }
}
