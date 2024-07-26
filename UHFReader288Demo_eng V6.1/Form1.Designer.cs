namespace UHFReader288Demo
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;
       
        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lrtxtLog = new CustomControl.LogRichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Maintab = new System.Windows.Forms.TabControl();
            this.Main_Page1 = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_Basic = new System.Windows.Forms.TabPage();
            this.gbReturnLoss = new System.Windows.Forms.GroupBox();
            this.cbbAnt = new System.Windows.Forms.ComboBox();
            this.label120 = new System.Windows.Forms.Label();
            this.label121 = new System.Windows.Forms.Label();
            this.cmbReturnLossFreq = new System.Windows.Forms.ComboBox();
            this.label122 = new System.Windows.Forms.Label();
            this.textReturnLoss = new System.Windows.Forms.TextBox();
            this.btReturnLoss = new System.Windows.Forms.Button();
            this.gbCmdTemperature = new System.Windows.Forms.GroupBox();
            this.btnGetReaderTemperature = new System.Windows.Forms.Button();
            this.txtReaderTemperature = new System.Windows.Forms.TextBox();
            this.gbp_DRM = new System.Windows.Forms.GroupBox();
            this.DRM_CLOSE = new System.Windows.Forms.RadioButton();
            this.DRM_OPEN = new System.Windows.Forms.RadioButton();
            this.bt_GetDRM = new System.Windows.Forms.Button();
            this.bt_setDRM = new System.Windows.Forms.Button();
            this.gbp_Retry = new System.Windows.Forms.GroupBox();
            this.com_retrytimes = new System.Windows.Forms.ComboBox();
            this.bt_Getretry = new System.Windows.Forms.Button();
            this.bt_Setretry = new System.Windows.Forms.Button();
            this.gbp_wpower = new System.Windows.Forms.GroupBox();
            this.label112 = new System.Windows.Forms.Label();
            this.com_wpower = new System.Windows.Forms.ComboBox();
            this.rb_wp2 = new System.Windows.Forms.RadioButton();
            this.rb_wp1 = new System.Windows.Forms.RadioButton();
            this.bt_GetWpower = new System.Windows.Forms.Button();
            this.bt_SetWpower = new System.Windows.Forms.Button();
            this.group_maxtime = new System.Windows.Forms.GroupBox();
            this.comboBox_maxtime = new System.Windows.Forms.ComboBox();
            this.btSetMaxtime = new System.Windows.Forms.Button();
            this.gbp_buff = new System.Windows.Forms.GroupBox();
            this.rb496 = new System.Windows.Forms.RadioButton();
            this.rb128 = new System.Windows.Forms.RadioButton();
            this.btGetEPCandTIDLen = new System.Windows.Forms.Button();
            this.btSetEPCandTIDLen = new System.Windows.Forms.Button();
            this.btDefault = new System.Windows.Forms.Button();
            this.btFlashROM = new System.Windows.Forms.Button();
            this.gpb_antconfig = new System.Windows.Forms.GroupBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.Button_Ant = new System.Windows.Forms.Button();
            this.checkant4 = new System.Windows.Forms.CheckBox();
            this.checkant3 = new System.Windows.Forms.CheckBox();
            this.checkant2 = new System.Windows.Forms.CheckBox();
            this.checkant1 = new System.Windows.Forms.CheckBox();
            this.gpb_checkant = new System.Windows.Forms.GroupBox();
            this.btSetcheckant = new System.Windows.Forms.Button();
            this.rb_Closecheckant = new System.Windows.Forms.RadioButton();
            this.rb_Opencheckant = new System.Windows.Forms.RadioButton();
            this.gpb_GPIO = new System.Windows.Forms.GroupBox();
            this.Button_GetGPIO = new System.Windows.Forms.Button();
            this.Button_SetGPIO = new System.Windows.Forms.Button();
            this.check_int4 = new System.Windows.Forms.CheckBox();
            this.check_int3 = new System.Windows.Forms.CheckBox();
            this.check_int2 = new System.Windows.Forms.CheckBox();
            this.check_int1 = new System.Windows.Forms.CheckBox();
            this.check_out4 = new System.Windows.Forms.CheckBox();
            this.check_out3 = new System.Windows.Forms.CheckBox();
            this.check_out2 = new System.Windows.Forms.CheckBox();
            this.check_out1 = new System.Windows.Forms.CheckBox();
            this.gpb_OutputRep = new System.Windows.Forms.GroupBox();
            this.btOutputRep = new System.Windows.Forms.Button();
            this.check_OutputRep4 = new System.Windows.Forms.CheckBox();
            this.check_OutputRep3 = new System.Windows.Forms.CheckBox();
            this.check_OutputRep2 = new System.Windows.Forms.CheckBox();
            this.check_OutputRep1 = new System.Windows.Forms.CheckBox();
            this.gpb_Relay = new System.Windows.Forms.GroupBox();
            this.label38 = new System.Windows.Forms.Label();
            this.ComboBox_RelayTime = new System.Windows.Forms.ComboBox();
            this.label37 = new System.Windows.Forms.Label();
            this.btRelay = new System.Windows.Forms.Button();
            this.gpb_baud = new System.Windows.Forms.GroupBox();
            this.ComboBox_baud = new System.Windows.Forms.ComboBox();
            this.btBaudRate = new System.Windows.Forms.Button();
            this.gpb_DBM = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.ComboBox_PowerDbm = new System.Windows.Forms.ComboBox();
            this.BT_DBM = new System.Windows.Forms.Button();
            this.gpb_Freq = new System.Windows.Forms.GroupBox();
            this.radioButton_band0 = new System.Windows.Forms.RadioButton();
            this.radioButton_band12 = new System.Windows.Forms.RadioButton();
            this.radioButton_band8 = new System.Windows.Forms.RadioButton();
            this.CheckBox_SameFre = new System.Windows.Forms.CheckBox();
            this.radioButton_band4 = new System.Windows.Forms.RadioButton();
            this.radioButton_band3 = new System.Windows.Forms.RadioButton();
            this.radioButton_band2 = new System.Windows.Forms.RadioButton();
            this.radioButton_band1 = new System.Windows.Forms.RadioButton();
            this.btFreq = new System.Windows.Forms.Button();
            this.ComboBox_dmaxfre = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.ComboBox_dminfre = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.gpb_beep = new System.Windows.Forms.GroupBox();
            this.Radio_beepDis = new System.Windows.Forms.RadioButton();
            this.Radio_beepEn = new System.Windows.Forms.RadioButton();
            this.Button_Beep = new System.Windows.Forms.Button();
            this.gpb_RDVersion = new System.Windows.Forms.GroupBox();
            this.text_RDVersion = new System.Windows.Forms.TextBox();
            this.gpb_MDVersion = new System.Windows.Forms.GroupBox();
            this.text_MDVersion = new System.Windows.Forms.TextBox();
            this.btMDVersion = new System.Windows.Forms.Button();
            this.gpb_Serial = new System.Windows.Forms.GroupBox();
            this.text_Serial = new System.Windows.Forms.TextBox();
            this.btSerial = new System.Windows.Forms.Button();
            this.gpb_address = new System.Windows.Forms.GroupBox();
            this.text_address = new System.Windows.Forms.TextBox();
            this.btaddress = new System.Windows.Forms.Button();
            this.gpb_rs232 = new System.Windows.Forms.GroupBox();
            this.btDisConnect232 = new System.Windows.Forms.Button();
            this.btConnect232 = new System.Windows.Forms.Button();
            this.ComboBox_baud2 = new System.Windows.Forms.ComboBox();
            this.label47 = new System.Windows.Forms.Label();
            this.ComboBox_COM = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rb_rs232 = new System.Windows.Forms.RadioButton();
            this.tabPage15 = new System.Windows.Forms.TabPage();
            this.groupBox62 = new System.Windows.Forms.GroupBox();
            this.label202 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.label200 = new System.Windows.Forms.Label();
            this.button11 = new System.Windows.Forms.Button();
            this.label201 = new System.Windows.Forms.Label();
            this.label203 = new System.Windows.Forms.Label();
            this.comboBox6 = new System.Windows.Forms.ComboBox();
            this.button12 = new System.Windows.Forms.Button();
            this.panel11 = new System.Windows.Forms.Panel();
            this.groupBox58 = new System.Windows.Forms.GroupBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.label194 = new System.Windows.Forms.Label();
            this.com_queryInter = new System.Windows.Forms.ComboBox();
            this.button7 = new System.Windows.Forms.Button();
            this.label192 = new System.Windows.Forms.Label();
            this.cbb_add = new System.Windows.Forms.ComboBox();
            this.label193 = new System.Windows.Forms.Label();
            this.cbb_dwell = new System.Windows.Forms.ComboBox();
            this.button8 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.check_phase = new System.Windows.Forms.CheckBox();
            this.checkBox_rate = new System.Windows.Forms.CheckBox();
            this.label80 = new System.Windows.Forms.Label();
            this.text_target = new System.Windows.Forms.TextBox();
            this.check_num = new System.Windows.Forms.CheckBox();
            this.com_Target = new System.Windows.Forms.ComboBox();
            this.label79 = new System.Windows.Forms.Label();
            this.com_scantime = new System.Windows.Forms.ComboBox();
            this.label39 = new System.Windows.Forms.Label();
            this.com_S = new System.Windows.Forms.ComboBox();
            this.label32 = new System.Windows.Forms.Label();
            this.com_Q = new System.Windows.Forms.ComboBox();
            this.label31 = new System.Windows.Forms.Label();
            this.groupBox57 = new System.Windows.Forms.GroupBox();
            this.rb_enable = new System.Windows.Forms.RadioButton();
            this.rb_disable = new System.Windows.Forms.RadioButton();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.groupBox45 = new System.Windows.Forms.GroupBox();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.gbp_MixRead = new System.Windows.Forms.GroupBox();
            this.text_readpsd = new System.Windows.Forms.TextBox();
            this.label118 = new System.Windows.Forms.Label();
            this.text_readLen = new System.Windows.Forms.TextBox();
            this.label117 = new System.Windows.Forms.Label();
            this.text_readadr = new System.Windows.Forms.TextBox();
            this.label115 = new System.Windows.Forms.Label();
            this.com_MixMem = new System.Windows.Forms.ComboBox();
            this.label114 = new System.Windows.Forms.Label();
            this.gbp_PowerAnt = new System.Windows.Forms.GroupBox();
            this.txtPower4 = new System.Windows.Forms.TextBox();
            this.label186 = new System.Windows.Forms.Label();
            this.txtPower3 = new System.Windows.Forms.TextBox();
            this.label187 = new System.Windows.Forms.Label();
            this.txtPower2 = new System.Windows.Forms.TextBox();
            this.label188 = new System.Windows.Forms.Label();
            this.txtPower1 = new System.Windows.Forms.TextBox();
            this.label189 = new System.Windows.Forms.Label();
            this.btGetRfPower = new System.Windows.Forms.Button();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.btSetRfPower = new System.Windows.Forms.Button();
            this.tabtest_SQL = new System.Windows.Forms.TabPage();
            this.Main_Page2 = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage_answer = new System.Windows.Forms.TabPage();
            this.chk_phase = new System.Windows.Forms.Panel();
            this.group_ant1 = new System.Windows.Forms.GroupBox();
            this.check_ant4 = new System.Windows.Forms.CheckBox();
            this.check_ant3 = new System.Windows.Forms.CheckBox();
            this.check_ant2 = new System.Windows.Forms.CheckBox();
            this.check_ant1 = new System.Windows.Forms.CheckBox();
            this.lxLedControl6 = new LxControl.LxLedControl();
            this.label119 = new System.Windows.Forms.Label();
            this.lxLedControl5 = new LxControl.LxLedControl();
            this.label9 = new System.Windows.Forms.Label();
            this.lxLedControl4 = new LxControl.LxLedControl();
            this.label8 = new System.Windows.Forms.Label();
            this.lxLedControl3 = new LxControl.LxLedControl();
            this.label7 = new System.Windows.Forms.Label();
            this.lxLedControl2 = new LxControl.LxLedControl();
            this.label6 = new System.Windows.Forms.Label();
            this.lxLedControl1 = new LxControl.LxLedControl();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rb_epc = new System.Windows.Forms.RadioButton();
            this.btIventoryG2 = new System.Windows.Forms.Button();
            this.btFlashCl = new System.Windows.Forms.Button();
            this.timer_answer = new System.Windows.Forms.Timer(this.components);
            this.timer_runmode = new System.Windows.Forms.Timer(this.components);
            this.timer_EAS = new System.Windows.Forms.Timer(this.components);
            this.Timer_Test_6B = new System.Windows.Forms.Timer(this.components);
            this.timer_Buff = new System.Windows.Forms.Timer(this.components);
            this.timer_RealTime = new System.Windows.Forms.Timer(this.components);
            this.ckClearOperationRec = new System.Windows.Forms.CheckBox();
            this.button3 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Maintab.SuspendLayout();
            this.Main_Page1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage_Basic.SuspendLayout();
            this.gbReturnLoss.SuspendLayout();
            this.gbCmdTemperature.SuspendLayout();
            this.gbp_DRM.SuspendLayout();
            this.gbp_Retry.SuspendLayout();
            this.gbp_wpower.SuspendLayout();
            this.group_maxtime.SuspendLayout();
            this.gbp_buff.SuspendLayout();
            this.gpb_antconfig.SuspendLayout();
            this.gpb_checkant.SuspendLayout();
            this.gpb_GPIO.SuspendLayout();
            this.gpb_OutputRep.SuspendLayout();
            this.gpb_Relay.SuspendLayout();
            this.gpb_baud.SuspendLayout();
            this.gpb_DBM.SuspendLayout();
            this.gpb_Freq.SuspendLayout();
            this.gpb_beep.SuspendLayout();
            this.gpb_RDVersion.SuspendLayout();
            this.gpb_MDVersion.SuspendLayout();
            this.gpb_Serial.SuspendLayout();
            this.gpb_address.SuspendLayout();
            this.gpb_rs232.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage15.SuspendLayout();
            this.groupBox62.SuspendLayout();
            this.panel11.SuspendLayout();
            this.groupBox58.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox57.SuspendLayout();
            this.groupBox45.SuspendLayout();
            this.gbp_MixRead.SuspendLayout();
            this.gbp_PowerAnt.SuspendLayout();
            this.Main_Page2.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage_answer.SuspendLayout();
            this.chk_phase.SuspendLayout();
            this.group_ant1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lxLedControl6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lxLedControl5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lxLedControl4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lxLedControl3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lxLedControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lxLedControl1)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lrtxtLog
            // 
            this.lrtxtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lrtxtLog.EnableAutoDragDrop = true;
            this.lrtxtLog.Location = new System.Drawing.Point(-1, 715);
            this.lrtxtLog.Name = "lrtxtLog";
            this.lrtxtLog.Size = new System.Drawing.Size(1144, 96);
            this.lrtxtLog.TabIndex = 0;
            this.lrtxtLog.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 659);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Operation records:";
            // 
            // Maintab
            // 
            this.Maintab.Controls.Add(this.Main_Page1);
            this.Maintab.Controls.Add(this.Main_Page2);
            this.Maintab.Dock = System.Windows.Forms.DockStyle.Top;
            this.Maintab.ItemSize = new System.Drawing.Size(72, 23);
            this.Maintab.Location = new System.Drawing.Point(0, 0);
            this.Maintab.Multiline = true;
            this.Maintab.Name = "Maintab";
            this.Maintab.SelectedIndex = 0;
            this.Maintab.Size = new System.Drawing.Size(1155, 652);
            this.Maintab.TabIndex = 3;
            this.Maintab.SelectedIndexChanged += new System.EventHandler(this.Maintab_SelectedIndexChanged);
            this.Maintab.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.Maintab_Selecting);
            // 
            // Main_Page1
            // 
            this.Main_Page1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Main_Page1.Controls.Add(this.tabControl1);
            this.Main_Page1.Location = new System.Drawing.Point(4, 27);
            this.Main_Page1.Name = "Main_Page1";
            this.Main_Page1.Padding = new System.Windows.Forms.Padding(3);
            this.Main_Page1.Size = new System.Drawing.Size(1147, 621);
            this.Main_Page1.TabIndex = 0;
            this.Main_Page1.Text = "Reader Setting";
            this.Main_Page1.UseVisualStyleBackColor = true;
            this.Main_Page1.Click += new System.EventHandler(this.Main_Page1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage_Basic);
            this.tabControl1.Controls.Add(this.tabPage15);
            this.tabControl1.Controls.Add(this.tabtest_SQL);
            this.tabControl1.HotTrack = true;
            this.tabControl1.ItemSize = new System.Drawing.Size(84, 23);
            this.tabControl1.Location = new System.Drawing.Point(1, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1144, 615);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.Maintab_SelectedIndexChanged);
            // 
            // tabPage_Basic
            // 
            this.tabPage_Basic.Controls.Add(this.gbReturnLoss);
            this.tabPage_Basic.Controls.Add(this.gbCmdTemperature);
            this.tabPage_Basic.Controls.Add(this.gbp_DRM);
            this.tabPage_Basic.Controls.Add(this.gbp_Retry);
            this.tabPage_Basic.Controls.Add(this.gbp_wpower);
            this.tabPage_Basic.Controls.Add(this.group_maxtime);
            this.tabPage_Basic.Controls.Add(this.gbp_buff);
            this.tabPage_Basic.Controls.Add(this.btDefault);
            this.tabPage_Basic.Controls.Add(this.btFlashROM);
            this.tabPage_Basic.Controls.Add(this.gpb_antconfig);
            this.tabPage_Basic.Controls.Add(this.gpb_checkant);
            this.tabPage_Basic.Controls.Add(this.gpb_GPIO);
            this.tabPage_Basic.Controls.Add(this.gpb_OutputRep);
            this.tabPage_Basic.Controls.Add(this.gpb_Relay);
            this.tabPage_Basic.Controls.Add(this.gpb_baud);
            this.tabPage_Basic.Controls.Add(this.gpb_DBM);
            this.tabPage_Basic.Controls.Add(this.gpb_Freq);
            this.tabPage_Basic.Controls.Add(this.gpb_beep);
            this.tabPage_Basic.Controls.Add(this.gpb_RDVersion);
            this.tabPage_Basic.Controls.Add(this.gpb_MDVersion);
            this.tabPage_Basic.Controls.Add(this.gpb_Serial);
            this.tabPage_Basic.Controls.Add(this.gpb_address);
            this.tabPage_Basic.Controls.Add(this.gpb_rs232);
            this.tabPage_Basic.Controls.Add(this.groupBox1);
            this.tabPage_Basic.Location = new System.Drawing.Point(4, 27);
            this.tabPage_Basic.Name = "tabPage_Basic";
            this.tabPage_Basic.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Basic.Size = new System.Drawing.Size(1136, 584);
            this.tabPage_Basic.TabIndex = 0;
            this.tabPage_Basic.Text = "Basic";
            this.tabPage_Basic.UseVisualStyleBackColor = true;
            // 
            // gbReturnLoss
            // 
            this.gbReturnLoss.BackColor = System.Drawing.Color.Transparent;
            this.gbReturnLoss.Controls.Add(this.cbbAnt);
            this.gbReturnLoss.Controls.Add(this.label120);
            this.gbReturnLoss.Controls.Add(this.label121);
            this.gbReturnLoss.Controls.Add(this.cmbReturnLossFreq);
            this.gbReturnLoss.Controls.Add(this.label122);
            this.gbReturnLoss.Controls.Add(this.textReturnLoss);
            this.gbReturnLoss.Controls.Add(this.btReturnLoss);
            this.gbReturnLoss.ForeColor = System.Drawing.Color.Black;
            this.gbReturnLoss.Location = new System.Drawing.Point(354, 288);
            this.gbReturnLoss.Name = "gbReturnLoss";
            this.gbReturnLoss.Size = new System.Drawing.Size(341, 50);
            this.gbReturnLoss.TabIndex = 77;
            this.gbReturnLoss.TabStop = false;
            this.gbReturnLoss.Text = "Measuring antenna ports Return Loss";
            // 
            // cbbAnt
            // 
            this.cbbAnt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbAnt.FormattingEnabled = true;
            this.cbbAnt.Items.AddRange(new object[] {
            "ANT1",
            "ANT2",
            "ANT3",
            "ANT4"});
            this.cbbAnt.Location = new System.Drawing.Point(198, 20);
            this.cbbAnt.Name = "cbbAnt";
            this.cbbAnt.Size = new System.Drawing.Size(70, 21);
            this.cbbAnt.TabIndex = 16;
            // 
            // label120
            // 
            this.label120.AutoSize = true;
            this.label120.Location = new System.Drawing.Point(86, 24);
            this.label120.Name = "label120";
            this.label120.Size = new System.Drawing.Size(18, 13);
            this.label120.TabIndex = 15;
            this.label120.Text = "@";
            // 
            // label121
            // 
            this.label121.AutoSize = true;
            this.label121.Location = new System.Drawing.Point(170, 24);
            this.label121.Name = "label121";
            this.label121.Size = new System.Drawing.Size(29, 13);
            this.label121.TabIndex = 14;
            this.label121.Text = "MHz";
            // 
            // cmbReturnLossFreq
            // 
            this.cmbReturnLossFreq.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReturnLossFreq.FormattingEnabled = true;
            this.cmbReturnLossFreq.Location = new System.Drawing.Point(97, 20);
            this.cmbReturnLossFreq.Name = "cmbReturnLossFreq";
            this.cmbReturnLossFreq.Size = new System.Drawing.Size(71, 21);
            this.cmbReturnLossFreq.TabIndex = 13;
            // 
            // label122
            // 
            this.label122.AutoSize = true;
            this.label122.Location = new System.Drawing.Point(11, 24);
            this.label122.Name = "label122";
            this.label122.Size = new System.Drawing.Size(24, 13);
            this.label122.TabIndex = 12;
            this.label122.Text = "RL:";
            // 
            // textReturnLoss
            // 
            this.textReturnLoss.Location = new System.Drawing.Point(40, 20);
            this.textReturnLoss.Name = "textReturnLoss";
            this.textReturnLoss.ReadOnly = true;
            this.textReturnLoss.Size = new System.Drawing.Size(44, 20);
            this.textReturnLoss.TabIndex = 11;
            this.textReturnLoss.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btReturnLoss
            // 
            this.btReturnLoss.Location = new System.Drawing.Point(276, 16);
            this.btReturnLoss.Name = "btReturnLoss";
            this.btReturnLoss.Size = new System.Drawing.Size(55, 25);
            this.btReturnLoss.TabIndex = 10;
            this.btReturnLoss.Text = "Get";
            this.btReturnLoss.UseVisualStyleBackColor = true;
            this.btReturnLoss.Click += new System.EventHandler(this.btReturnLoss_Click);
            // 
            // gbCmdTemperature
            // 
            this.gbCmdTemperature.Controls.Add(this.btnGetReaderTemperature);
            this.gbCmdTemperature.Controls.Add(this.txtReaderTemperature);
            this.gbCmdTemperature.ForeColor = System.Drawing.Color.Black;
            this.gbCmdTemperature.Location = new System.Drawing.Point(702, 286);
            this.gbCmdTemperature.Name = "gbCmdTemperature";
            this.gbCmdTemperature.Size = new System.Drawing.Size(342, 53);
            this.gbCmdTemperature.TabIndex = 76;
            this.gbCmdTemperature.TabStop = false;
            this.gbCmdTemperature.Text = "Working temperature monitoring";
            // 
            // btnGetReaderTemperature
            // 
            this.btnGetReaderTemperature.Location = new System.Drawing.Point(233, 20);
            this.btnGetReaderTemperature.Name = "btnGetReaderTemperature";
            this.btnGetReaderTemperature.Size = new System.Drawing.Size(90, 25);
            this.btnGetReaderTemperature.TabIndex = 0;
            this.btnGetReaderTemperature.Text = "Get";
            this.btnGetReaderTemperature.UseVisualStyleBackColor = true;
            this.btnGetReaderTemperature.Click += new System.EventHandler(this.btnGetReaderTemperature_Click);
            // 
            // txtReaderTemperature
            // 
            this.txtReaderTemperature.Location = new System.Drawing.Point(6, 22);
            this.txtReaderTemperature.Name = "txtReaderTemperature";
            this.txtReaderTemperature.ReadOnly = true;
            this.txtReaderTemperature.Size = new System.Drawing.Size(120, 20);
            this.txtReaderTemperature.TabIndex = 1;
            this.txtReaderTemperature.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // gbp_DRM
            // 
            this.gbp_DRM.Controls.Add(this.DRM_CLOSE);
            this.gbp_DRM.Controls.Add(this.DRM_OPEN);
            this.gbp_DRM.Controls.Add(this.bt_GetDRM);
            this.gbp_DRM.Controls.Add(this.bt_setDRM);
            this.gbp_DRM.Location = new System.Drawing.Point(702, 408);
            this.gbp_DRM.Name = "gbp_DRM";
            this.gbp_DRM.Size = new System.Drawing.Size(343, 55);
            this.gbp_DRM.TabIndex = 75;
            this.gbp_DRM.TabStop = false;
            this.gbp_DRM.Text = "DRM";
            // 
            // DRM_CLOSE
            // 
            this.DRM_CLOSE.AutoSize = true;
            this.DRM_CLOSE.Location = new System.Drawing.Point(86, 22);
            this.DRM_CLOSE.Name = "DRM_CLOSE";
            this.DRM_CLOSE.Size = new System.Drawing.Size(60, 17);
            this.DRM_CLOSE.TabIndex = 12;
            this.DRM_CLOSE.Text = "Disable";
            this.DRM_CLOSE.UseVisualStyleBackColor = true;
            // 
            // DRM_OPEN
            // 
            this.DRM_OPEN.AutoSize = true;
            this.DRM_OPEN.Location = new System.Drawing.Point(13, 22);
            this.DRM_OPEN.Name = "DRM_OPEN";
            this.DRM_OPEN.Size = new System.Drawing.Size(58, 17);
            this.DRM_OPEN.TabIndex = 11;
            this.DRM_OPEN.Text = "Enable";
            this.DRM_OPEN.UseVisualStyleBackColor = true;
            // 
            // bt_GetDRM
            // 
            this.bt_GetDRM.Location = new System.Drawing.Point(247, 19);
            this.bt_GetDRM.Name = "bt_GetDRM";
            this.bt_GetDRM.Size = new System.Drawing.Size(77, 25);
            this.bt_GetDRM.TabIndex = 9;
            this.bt_GetDRM.Text = "Get";
            this.bt_GetDRM.UseVisualStyleBackColor = true;
            this.bt_GetDRM.Click += new System.EventHandler(this.bt_GetDRM_Click);
            // 
            // bt_setDRM
            // 
            this.bt_setDRM.Location = new System.Drawing.Point(158, 19);
            this.bt_setDRM.Name = "bt_setDRM";
            this.bt_setDRM.Size = new System.Drawing.Size(77, 25);
            this.bt_setDRM.TabIndex = 8;
            this.bt_setDRM.Text = "Set";
            this.bt_setDRM.UseVisualStyleBackColor = true;
            this.bt_setDRM.Click += new System.EventHandler(this.bt_setDRM_Click);
            // 
            // gbp_Retry
            // 
            this.gbp_Retry.Controls.Add(this.com_retrytimes);
            this.gbp_Retry.Controls.Add(this.bt_Getretry);
            this.gbp_Retry.Controls.Add(this.bt_Setretry);
            this.gbp_Retry.Location = new System.Drawing.Point(702, 350);
            this.gbp_Retry.Name = "gbp_Retry";
            this.gbp_Retry.Size = new System.Drawing.Size(343, 52);
            this.gbp_Retry.TabIndex = 74;
            this.gbp_Retry.TabStop = false;
            this.gbp_Retry.Text = "Retry write times set and get";
            // 
            // com_retrytimes
            // 
            this.com_retrytimes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.com_retrytimes.FormattingEnabled = true;
            this.com_retrytimes.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.com_retrytimes.Location = new System.Drawing.Point(14, 20);
            this.com_retrytimes.Name = "com_retrytimes";
            this.com_retrytimes.Size = new System.Drawing.Size(100, 21);
            this.com_retrytimes.TabIndex = 26;
            // 
            // bt_Getretry
            // 
            this.bt_Getretry.Location = new System.Drawing.Point(247, 19);
            this.bt_Getretry.Name = "bt_Getretry";
            this.bt_Getretry.Size = new System.Drawing.Size(77, 25);
            this.bt_Getretry.TabIndex = 9;
            this.bt_Getretry.Text = "Get";
            this.bt_Getretry.UseVisualStyleBackColor = true;
            this.bt_Getretry.Click += new System.EventHandler(this.bt_Getretry_Click);
            // 
            // bt_Setretry
            // 
            this.bt_Setretry.Location = new System.Drawing.Point(158, 19);
            this.bt_Setretry.Name = "bt_Setretry";
            this.bt_Setretry.Size = new System.Drawing.Size(77, 25);
            this.bt_Setretry.TabIndex = 8;
            this.bt_Setretry.Text = "Set";
            this.bt_Setretry.UseVisualStyleBackColor = true;
            this.bt_Setretry.Click += new System.EventHandler(this.bt_Setretry_Click);
            // 
            // gbp_wpower
            // 
            this.gbp_wpower.Controls.Add(this.label112);
            this.gbp_wpower.Controls.Add(this.com_wpower);
            this.gbp_wpower.Controls.Add(this.rb_wp2);
            this.gbp_wpower.Controls.Add(this.rb_wp1);
            this.gbp_wpower.Controls.Add(this.bt_GetWpower);
            this.gbp_wpower.Controls.Add(this.bt_SetWpower);
            this.gbp_wpower.Location = new System.Drawing.Point(6, 376);
            this.gbp_wpower.Name = "gbp_wpower";
            this.gbp_wpower.Size = new System.Drawing.Size(343, 88);
            this.gbp_wpower.TabIndex = 73;
            this.gbp_wpower.TabStop = false;
            this.gbp_wpower.Text = "Write Power Set and get";
            // 
            // label112
            // 
            this.label112.AutoSize = true;
            this.label112.Location = new System.Drawing.Point(120, 48);
            this.label112.Name = "label112";
            this.label112.Size = new System.Drawing.Size(28, 13);
            this.label112.TabIndex = 27;
            this.label112.Text = "dBm";
            // 
            // com_wpower
            // 
            this.com_wpower.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.com_wpower.FormattingEnabled = true;
            this.com_wpower.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33"});
            this.com_wpower.Location = new System.Drawing.Point(14, 45);
            this.com_wpower.Name = "com_wpower";
            this.com_wpower.Size = new System.Drawing.Size(100, 21);
            this.com_wpower.TabIndex = 26;
            // 
            // rb_wp2
            // 
            this.rb_wp2.AutoSize = true;
            this.rb_wp2.Location = new System.Drawing.Point(157, 20);
            this.rb_wp2.Name = "rb_wp2";
            this.rb_wp2.Size = new System.Drawing.Size(58, 17);
            this.rb_wp2.TabIndex = 11;
            this.rb_wp2.Text = "Enable";
            this.rb_wp2.UseVisualStyleBackColor = true;
            // 
            // rb_wp1
            // 
            this.rb_wp1.AutoSize = true;
            this.rb_wp1.Checked = true;
            this.rb_wp1.Location = new System.Drawing.Point(15, 20);
            this.rb_wp1.Name = "rb_wp1";
            this.rb_wp1.Size = new System.Drawing.Size(60, 17);
            this.rb_wp1.TabIndex = 10;
            this.rb_wp1.TabStop = true;
            this.rb_wp1.Text = "Disable";
            this.rb_wp1.UseVisualStyleBackColor = true;
            // 
            // bt_GetWpower
            // 
            this.bt_GetWpower.Location = new System.Drawing.Point(247, 42);
            this.bt_GetWpower.Name = "bt_GetWpower";
            this.bt_GetWpower.Size = new System.Drawing.Size(77, 25);
            this.bt_GetWpower.TabIndex = 9;
            this.bt_GetWpower.Text = "Get";
            this.bt_GetWpower.UseVisualStyleBackColor = true;
            this.bt_GetWpower.Click += new System.EventHandler(this.button1_Click);
            // 
            // bt_SetWpower
            // 
            this.bt_SetWpower.Location = new System.Drawing.Point(158, 42);
            this.bt_SetWpower.Name = "bt_SetWpower";
            this.bt_SetWpower.Size = new System.Drawing.Size(77, 25);
            this.bt_SetWpower.TabIndex = 8;
            this.bt_SetWpower.Text = "Set";
            this.bt_SetWpower.UseVisualStyleBackColor = true;
            this.bt_SetWpower.Click += new System.EventHandler(this.button2_Click);
            // 
            // group_maxtime
            // 
            this.group_maxtime.Controls.Add(this.comboBox_maxtime);
            this.group_maxtime.Controls.Add(this.btSetMaxtime);
            this.group_maxtime.Location = new System.Drawing.Point(6, 266);
            this.group_maxtime.Name = "group_maxtime";
            this.group_maxtime.Size = new System.Drawing.Size(342, 45);
            this.group_maxtime.TabIndex = 72;
            this.group_maxtime.TabStop = false;
            this.group_maxtime.Text = "Max inventory time";
            // 
            // comboBox_maxtime
            // 
            this.comboBox_maxtime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_maxtime.FormattingEnabled = true;
            this.comboBox_maxtime.Location = new System.Drawing.Point(94, 16);
            this.comboBox_maxtime.Name = "comboBox_maxtime";
            this.comboBox_maxtime.Size = new System.Drawing.Size(122, 21);
            this.comboBox_maxtime.TabIndex = 26;
            // 
            // btSetMaxtime
            // 
            this.btSetMaxtime.Location = new System.Drawing.Point(233, 15);
            this.btSetMaxtime.Name = "btSetMaxtime";
            this.btSetMaxtime.Size = new System.Drawing.Size(90, 25);
            this.btSetMaxtime.TabIndex = 23;
            this.btSetMaxtime.Text = "Set";
            this.btSetMaxtime.UseVisualStyleBackColor = true;
            this.btSetMaxtime.Click += new System.EventHandler(this.btSetMaxtime_Click);
            // 
            // gbp_buff
            // 
            this.gbp_buff.Controls.Add(this.rb496);
            this.gbp_buff.Controls.Add(this.rb128);
            this.gbp_buff.Controls.Add(this.btGetEPCandTIDLen);
            this.gbp_buff.Controls.Add(this.btSetEPCandTIDLen);
            this.gbp_buff.Location = new System.Drawing.Point(5, 315);
            this.gbp_buff.Name = "gbp_buff";
            this.gbp_buff.Size = new System.Drawing.Size(343, 59);
            this.gbp_buff.TabIndex = 71;
            this.gbp_buff.TabStop = false;
            this.gbp_buff.Text = "Saved EPC/TID length";
            // 
            // rb496
            // 
            this.rb496.AutoSize = true;
            this.rb496.Location = new System.Drawing.Point(93, 27);
            this.rb496.Name = "rb496";
            this.rb496.Size = new System.Drawing.Size(54, 17);
            this.rb496.TabIndex = 11;
            this.rb496.Text = "496bit";
            this.rb496.UseVisualStyleBackColor = true;
            // 
            // rb128
            // 
            this.rb128.AutoSize = true;
            this.rb128.Checked = true;
            this.rb128.Location = new System.Drawing.Point(15, 27);
            this.rb128.Name = "rb128";
            this.rb128.Size = new System.Drawing.Size(54, 17);
            this.rb128.TabIndex = 10;
            this.rb128.TabStop = true;
            this.rb128.Text = "128bit";
            this.rb128.UseVisualStyleBackColor = true;
            // 
            // btGetEPCandTIDLen
            // 
            this.btGetEPCandTIDLen.Location = new System.Drawing.Point(247, 24);
            this.btGetEPCandTIDLen.Name = "btGetEPCandTIDLen";
            this.btGetEPCandTIDLen.Size = new System.Drawing.Size(77, 25);
            this.btGetEPCandTIDLen.TabIndex = 9;
            this.btGetEPCandTIDLen.Text = "Get";
            this.btGetEPCandTIDLen.UseVisualStyleBackColor = true;
            this.btGetEPCandTIDLen.Click += new System.EventHandler(this.btGetEPCandTIDLen_Click);
            // 
            // btSetEPCandTIDLen
            // 
            this.btSetEPCandTIDLen.Location = new System.Drawing.Point(158, 24);
            this.btSetEPCandTIDLen.Name = "btSetEPCandTIDLen";
            this.btSetEPCandTIDLen.Size = new System.Drawing.Size(77, 25);
            this.btSetEPCandTIDLen.TabIndex = 8;
            this.btSetEPCandTIDLen.Text = "Set";
            this.btSetEPCandTIDLen.UseVisualStyleBackColor = true;
            this.btSetEPCandTIDLen.Click += new System.EventHandler(this.btSetEPCandTIDLen_Click);
            // 
            // btDefault
            // 
            this.btDefault.Location = new System.Drawing.Point(915, 529);
            this.btDefault.Name = "btDefault";
            this.btDefault.Size = new System.Drawing.Size(130, 46);
            this.btDefault.TabIndex = 57;
            this.btDefault.Text = "Default setting";
            this.btDefault.UseVisualStyleBackColor = true;
            this.btDefault.Click += new System.EventHandler(this.btDefault_Click);
            // 
            // btFlashROM
            // 
            this.btFlashROM.Location = new System.Drawing.Point(355, 626);
            this.btFlashROM.Name = "btFlashROM";
            this.btFlashROM.Size = new System.Drawing.Size(169, 46);
            this.btFlashROM.TabIndex = 56;
            this.btFlashROM.Text = "切换至R2000模块升级模式";
            this.btFlashROM.UseVisualStyleBackColor = true;
            this.btFlashROM.Click += new System.EventHandler(this.btFlashROM_Click);
            // 
            // gpb_antconfig
            // 
            this.gpb_antconfig.Controls.Add(this.checkBox2);
            this.gpb_antconfig.Controls.Add(this.Button_Ant);
            this.gpb_antconfig.Controls.Add(this.checkant4);
            this.gpb_antconfig.Controls.Add(this.checkant3);
            this.gpb_antconfig.Controls.Add(this.checkant2);
            this.gpb_antconfig.Controls.Add(this.checkant1);
            this.gpb_antconfig.Location = new System.Drawing.Point(357, 401);
            this.gpb_antconfig.Name = "gpb_antconfig";
            this.gpb_antconfig.Size = new System.Drawing.Size(342, 63);
            this.gpb_antconfig.TabIndex = 54;
            this.gpb_antconfig.TabStop = false;
            this.gpb_antconfig.Text = "Antenna config";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.Location = new System.Drawing.Point(142, 17);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(57, 17);
            this.checkBox2.TabIndex = 18;
            this.checkBox2.Text = "Saved";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // Button_Ant
            // 
            this.Button_Ant.Location = new System.Drawing.Point(233, 12);
            this.Button_Ant.Name = "Button_Ant";
            this.Button_Ant.Size = new System.Drawing.Size(90, 25);
            this.Button_Ant.TabIndex = 5;
            this.Button_Ant.Text = "Set";
            this.Button_Ant.UseVisualStyleBackColor = true;
            this.Button_Ant.Click += new System.EventHandler(this.Button_Ant_Click);
            // 
            // checkant4
            // 
            this.checkant4.AutoSize = true;
            this.checkant4.Location = new System.Drawing.Point(269, 40);
            this.checkant4.Name = "checkant4";
            this.checkant4.Size = new System.Drawing.Size(54, 17);
            this.checkant4.TabIndex = 4;
            this.checkant4.Text = "ANT4";
            this.checkant4.UseVisualStyleBackColor = true;
            // 
            // checkant3
            // 
            this.checkant3.AutoSize = true;
            this.checkant3.Location = new System.Drawing.Point(192, 40);
            this.checkant3.Name = "checkant3";
            this.checkant3.Size = new System.Drawing.Size(54, 17);
            this.checkant3.TabIndex = 3;
            this.checkant3.Text = "ANT3";
            this.checkant3.UseVisualStyleBackColor = true;
            // 
            // checkant2
            // 
            this.checkant2.AutoSize = true;
            this.checkant2.Location = new System.Drawing.Point(95, 40);
            this.checkant2.Name = "checkant2";
            this.checkant2.Size = new System.Drawing.Size(54, 17);
            this.checkant2.TabIndex = 2;
            this.checkant2.Text = "ANT2";
            this.checkant2.UseVisualStyleBackColor = true;
            // 
            // checkant1
            // 
            this.checkant1.AutoSize = true;
            this.checkant1.Location = new System.Drawing.Point(8, 40);
            this.checkant1.Name = "checkant1";
            this.checkant1.Size = new System.Drawing.Size(54, 17);
            this.checkant1.TabIndex = 1;
            this.checkant1.Text = "ANT1";
            this.checkant1.UseVisualStyleBackColor = true;
            // 
            // gpb_checkant
            // 
            this.gpb_checkant.Controls.Add(this.btSetcheckant);
            this.gpb_checkant.Controls.Add(this.rb_Closecheckant);
            this.gpb_checkant.Controls.Add(this.rb_Opencheckant);
            this.gpb_checkant.Location = new System.Drawing.Point(354, 347);
            this.gpb_checkant.Name = "gpb_checkant";
            this.gpb_checkant.Size = new System.Drawing.Size(342, 55);
            this.gpb_checkant.TabIndex = 53;
            this.gpb_checkant.TabStop = false;
            this.gpb_checkant.Text = "Antenna checked";
            // 
            // btSetcheckant
            // 
            this.btSetcheckant.Location = new System.Drawing.Point(233, 20);
            this.btSetcheckant.Name = "btSetcheckant";
            this.btSetcheckant.Size = new System.Drawing.Size(90, 25);
            this.btSetcheckant.TabIndex = 2;
            this.btSetcheckant.Text = "Set";
            this.btSetcheckant.UseVisualStyleBackColor = true;
            this.btSetcheckant.Click += new System.EventHandler(this.btSetcheckant_Click);
            // 
            // rb_Closecheckant
            // 
            this.rb_Closecheckant.AutoSize = true;
            this.rb_Closecheckant.Location = new System.Drawing.Point(7, 35);
            this.rb_Closecheckant.Name = "rb_Closecheckant";
            this.rb_Closecheckant.Size = new System.Drawing.Size(149, 17);
            this.rb_Closecheckant.TabIndex = 1;
            this.rb_Closecheckant.Text = "Disable antenna detection";
            this.rb_Closecheckant.UseVisualStyleBackColor = true;
            // 
            // rb_Opencheckant
            // 
            this.rb_Opencheckant.AutoSize = true;
            this.rb_Opencheckant.Checked = true;
            this.rb_Opencheckant.Location = new System.Drawing.Point(7, 15);
            this.rb_Opencheckant.Name = "rb_Opencheckant";
            this.rb_Opencheckant.Size = new System.Drawing.Size(147, 17);
            this.rb_Opencheckant.TabIndex = 0;
            this.rb_Opencheckant.TabStop = true;
            this.rb_Opencheckant.Text = "Enable antenna detection";
            this.rb_Opencheckant.UseVisualStyleBackColor = true;
            // 
            // gpb_GPIO
            // 
            this.gpb_GPIO.Controls.Add(this.Button_GetGPIO);
            this.gpb_GPIO.Controls.Add(this.Button_SetGPIO);
            this.gpb_GPIO.Controls.Add(this.check_int4);
            this.gpb_GPIO.Controls.Add(this.check_int3);
            this.gpb_GPIO.Controls.Add(this.check_int2);
            this.gpb_GPIO.Controls.Add(this.check_int1);
            this.gpb_GPIO.Controls.Add(this.check_out4);
            this.gpb_GPIO.Controls.Add(this.check_out3);
            this.gpb_GPIO.Controls.Add(this.check_out2);
            this.gpb_GPIO.Controls.Add(this.check_out1);
            this.gpb_GPIO.Location = new System.Drawing.Point(361, 237);
            this.gpb_GPIO.Name = "gpb_GPIO";
            this.gpb_GPIO.Size = new System.Drawing.Size(686, 46);
            this.gpb_GPIO.TabIndex = 49;
            this.gpb_GPIO.TabStop = false;
            this.gpb_GPIO.Text = "GPIO Operation";
            // 
            // Button_GetGPIO
            // 
            this.Button_GetGPIO.Location = new System.Drawing.Point(585, 15);
            this.Button_GetGPIO.Name = "Button_GetGPIO";
            this.Button_GetGPIO.Size = new System.Drawing.Size(90, 25);
            this.Button_GetGPIO.TabIndex = 9;
            this.Button_GetGPIO.Text = "Get";
            this.Button_GetGPIO.UseVisualStyleBackColor = true;
            this.Button_GetGPIO.Click += new System.EventHandler(this.Button_GetGPIO_Click);
            // 
            // Button_SetGPIO
            // 
            this.Button_SetGPIO.Location = new System.Drawing.Point(483, 15);
            this.Button_SetGPIO.Name = "Button_SetGPIO";
            this.Button_SetGPIO.Size = new System.Drawing.Size(90, 25);
            this.Button_SetGPIO.TabIndex = 8;
            this.Button_SetGPIO.Text = "Set";
            this.Button_SetGPIO.UseVisualStyleBackColor = true;
            this.Button_SetGPIO.Click += new System.EventHandler(this.Button_SetGPIO_Click);
            // 
            // check_int4
            // 
            this.check_int4.AutoSize = true;
            this.check_int4.Enabled = false;
            this.check_int4.Location = new System.Drawing.Point(392, 20);
            this.check_int4.Name = "check_int4";
            this.check_int4.Size = new System.Drawing.Size(43, 17);
            this.check_int4.TabIndex = 7;
            this.check_int4.Text = "IN4";
            this.check_int4.UseVisualStyleBackColor = true;
            // 
            // check_int3
            // 
            this.check_int3.AutoSize = true;
            this.check_int3.Enabled = false;
            this.check_int3.Location = new System.Drawing.Point(338, 20);
            this.check_int3.Name = "check_int3";
            this.check_int3.Size = new System.Drawing.Size(43, 17);
            this.check_int3.TabIndex = 6;
            this.check_int3.Text = "IN3";
            this.check_int3.UseVisualStyleBackColor = true;
            // 
            // check_int2
            // 
            this.check_int2.AutoSize = true;
            this.check_int2.Enabled = false;
            this.check_int2.Location = new System.Drawing.Point(281, 20);
            this.check_int2.Name = "check_int2";
            this.check_int2.Size = new System.Drawing.Size(43, 17);
            this.check_int2.TabIndex = 5;
            this.check_int2.Text = "IN2";
            this.check_int2.UseVisualStyleBackColor = true;
            this.check_int2.CheckedChanged += new System.EventHandler(this.check_int2_CheckedChanged);
            // 
            // check_int1
            // 
            this.check_int1.AutoSize = true;
            this.check_int1.Enabled = false;
            this.check_int1.Location = new System.Drawing.Point(227, 20);
            this.check_int1.Name = "check_int1";
            this.check_int1.Size = new System.Drawing.Size(43, 17);
            this.check_int1.TabIndex = 4;
            this.check_int1.Text = "IN1";
            this.check_int1.UseVisualStyleBackColor = true;
            // 
            // check_out4
            // 
            this.check_out4.AutoSize = true;
            this.check_out4.Location = new System.Drawing.Point(170, 20);
            this.check_out4.Name = "check_out4";
            this.check_out4.Size = new System.Drawing.Size(55, 17);
            this.check_out4.TabIndex = 3;
            this.check_out4.Text = "OUT4";
            this.check_out4.UseVisualStyleBackColor = true;
            // 
            // check_out3
            // 
            this.check_out3.AutoSize = true;
            this.check_out3.Location = new System.Drawing.Point(116, 20);
            this.check_out3.Name = "check_out3";
            this.check_out3.Size = new System.Drawing.Size(55, 17);
            this.check_out3.TabIndex = 2;
            this.check_out3.Text = "OUT3";
            this.check_out3.UseVisualStyleBackColor = true;
            // 
            // check_out2
            // 
            this.check_out2.AutoSize = true;
            this.check_out2.Location = new System.Drawing.Point(62, 20);
            this.check_out2.Name = "check_out2";
            this.check_out2.Size = new System.Drawing.Size(55, 17);
            this.check_out2.TabIndex = 1;
            this.check_out2.Text = "OUT2";
            this.check_out2.UseVisualStyleBackColor = true;
            // 
            // check_out1
            // 
            this.check_out1.AutoSize = true;
            this.check_out1.Location = new System.Drawing.Point(8, 20);
            this.check_out1.Name = "check_out1";
            this.check_out1.Size = new System.Drawing.Size(55, 17);
            this.check_out1.TabIndex = 0;
            this.check_out1.Text = "OUT1";
            this.check_out1.UseVisualStyleBackColor = true;
            // 
            // gpb_OutputRep
            // 
            this.gpb_OutputRep.Controls.Add(this.btOutputRep);
            this.gpb_OutputRep.Controls.Add(this.check_OutputRep4);
            this.gpb_OutputRep.Controls.Add(this.check_OutputRep3);
            this.gpb_OutputRep.Controls.Add(this.check_OutputRep2);
            this.gpb_OutputRep.Controls.Add(this.check_OutputRep1);
            this.gpb_OutputRep.Location = new System.Drawing.Point(705, 189);
            this.gpb_OutputRep.Name = "gpb_OutputRep";
            this.gpb_OutputRep.Size = new System.Drawing.Size(342, 46);
            this.gpb_OutputRep.TabIndex = 48;
            this.gpb_OutputRep.TabStop = false;
            this.gpb_OutputRep.Text = "Set notification pluse output";
            // 
            // btOutputRep
            // 
            this.btOutputRep.Location = new System.Drawing.Point(234, 14);
            this.btOutputRep.Name = "btOutputRep";
            this.btOutputRep.Size = new System.Drawing.Size(90, 25);
            this.btOutputRep.TabIndex = 5;
            this.btOutputRep.Text = "Set";
            this.btOutputRep.UseVisualStyleBackColor = true;
            this.btOutputRep.Click += new System.EventHandler(this.btOutputRep_Click);
            // 
            // check_OutputRep4
            // 
            this.check_OutputRep4.AutoSize = true;
            this.check_OutputRep4.Location = new System.Drawing.Point(184, 17);
            this.check_OutputRep4.Name = "check_OutputRep4";
            this.check_OutputRep4.Size = new System.Drawing.Size(55, 17);
            this.check_OutputRep4.TabIndex = 4;
            this.check_OutputRep4.Text = "OUT4";
            this.check_OutputRep4.UseVisualStyleBackColor = true;
            // 
            // check_OutputRep3
            // 
            this.check_OutputRep3.AutoSize = true;
            this.check_OutputRep3.Location = new System.Drawing.Point(125, 17);
            this.check_OutputRep3.Name = "check_OutputRep3";
            this.check_OutputRep3.Size = new System.Drawing.Size(55, 17);
            this.check_OutputRep3.TabIndex = 3;
            this.check_OutputRep3.Text = "OUT3";
            this.check_OutputRep3.UseVisualStyleBackColor = true;
            // 
            // check_OutputRep2
            // 
            this.check_OutputRep2.AutoSize = true;
            this.check_OutputRep2.Location = new System.Drawing.Point(66, 17);
            this.check_OutputRep2.Name = "check_OutputRep2";
            this.check_OutputRep2.Size = new System.Drawing.Size(55, 17);
            this.check_OutputRep2.TabIndex = 2;
            this.check_OutputRep2.Text = "OUT2";
            this.check_OutputRep2.UseVisualStyleBackColor = true;
            // 
            // check_OutputRep1
            // 
            this.check_OutputRep1.AutoSize = true;
            this.check_OutputRep1.Location = new System.Drawing.Point(8, 17);
            this.check_OutputRep1.Name = "check_OutputRep1";
            this.check_OutputRep1.Size = new System.Drawing.Size(55, 17);
            this.check_OutputRep1.TabIndex = 1;
            this.check_OutputRep1.Text = "OUT1";
            this.check_OutputRep1.UseVisualStyleBackColor = true;
            // 
            // gpb_Relay
            // 
            this.gpb_Relay.Controls.Add(this.label38);
            this.gpb_Relay.Controls.Add(this.ComboBox_RelayTime);
            this.gpb_Relay.Controls.Add(this.label37);
            this.gpb_Relay.Controls.Add(this.btRelay);
            this.gpb_Relay.Location = new System.Drawing.Point(357, 189);
            this.gpb_Relay.Name = "gpb_Relay";
            this.gpb_Relay.Size = new System.Drawing.Size(342, 46);
            this.gpb_Relay.TabIndex = 31;
            this.gpb_Relay.TabStop = false;
            this.gpb_Relay.Text = "Relay control";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(182, 20);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(36, 13);
            this.label38.TabIndex = 26;
            this.label38.Text = "*50ms";
            // 
            // ComboBox_RelayTime
            // 
            this.ComboBox_RelayTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_RelayTime.FormattingEnabled = true;
            this.ComboBox_RelayTime.Location = new System.Drawing.Point(82, 16);
            this.ComboBox_RelayTime.Name = "ComboBox_RelayTime";
            this.ComboBox_RelayTime.Size = new System.Drawing.Size(96, 21);
            this.ComboBox_RelayTime.TabIndex = 25;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(17, 20);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(71, 13);
            this.label37.TabIndex = 24;
            this.label37.Text = "Release time:";
            // 
            // btRelay
            // 
            this.btRelay.Location = new System.Drawing.Point(233, 14);
            this.btRelay.Name = "btRelay";
            this.btRelay.Size = new System.Drawing.Size(90, 25);
            this.btRelay.TabIndex = 23;
            this.btRelay.Text = "Set";
            this.btRelay.UseVisualStyleBackColor = true;
            this.btRelay.Click += new System.EventHandler(this.btRelay_Click);
            // 
            // gpb_baud
            // 
            this.gpb_baud.Controls.Add(this.ComboBox_baud);
            this.gpb_baud.Controls.Add(this.btBaudRate);
            this.gpb_baud.Location = new System.Drawing.Point(707, 135);
            this.gpb_baud.Name = "gpb_baud";
            this.gpb_baud.Size = new System.Drawing.Size(342, 49);
            this.gpb_baud.TabIndex = 30;
            this.gpb_baud.TabStop = false;
            this.gpb_baud.Text = "RS232/485 baud rate";
            // 
            // ComboBox_baud
            // 
            this.ComboBox_baud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_baud.FormattingEnabled = true;
            this.ComboBox_baud.Items.AddRange(new object[] {
            "9600bps",
            "19200bps",
            "38400bps",
            "57600bps",
            "115200bps"});
            this.ComboBox_baud.Location = new System.Drawing.Point(69, 19);
            this.ComboBox_baud.Name = "ComboBox_baud";
            this.ComboBox_baud.Size = new System.Drawing.Size(121, 21);
            this.ComboBox_baud.TabIndex = 24;
            // 
            // btBaudRate
            // 
            this.btBaudRate.Location = new System.Drawing.Point(233, 15);
            this.btBaudRate.Name = "btBaudRate";
            this.btBaudRate.Size = new System.Drawing.Size(90, 25);
            this.btBaudRate.TabIndex = 23;
            this.btBaudRate.Text = "Set";
            this.btBaudRate.UseVisualStyleBackColor = true;
            this.btBaudRate.Click += new System.EventHandler(this.btBaudRate_Click);
            // 
            // gpb_DBM
            // 
            this.gpb_DBM.Controls.Add(this.label10);
            this.gpb_DBM.Controls.Add(this.ComboBox_PowerDbm);
            this.gpb_DBM.Controls.Add(this.BT_DBM);
            this.gpb_DBM.Location = new System.Drawing.Point(355, 136);
            this.gpb_DBM.Name = "gpb_DBM";
            this.gpb_DBM.Size = new System.Drawing.Size(342, 48);
            this.gpb_DBM.TabIndex = 29;
            this.gpb_DBM.TabStop = false;
            this.gpb_DBM.Text = "Power";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(157, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(28, 13);
            this.label10.TabIndex = 25;
            this.label10.Text = "dBm";
            // 
            // ComboBox_PowerDbm
            // 
            this.ComboBox_PowerDbm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_PowerDbm.FormattingEnabled = true;
            this.ComboBox_PowerDbm.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36"});
            this.ComboBox_PowerDbm.Location = new System.Drawing.Point(51, 22);
            this.ComboBox_PowerDbm.Name = "ComboBox_PowerDbm";
            this.ComboBox_PowerDbm.Size = new System.Drawing.Size(100, 21);
            this.ComboBox_PowerDbm.TabIndex = 24;
            // 
            // BT_DBM
            // 
            this.BT_DBM.Location = new System.Drawing.Point(233, 17);
            this.BT_DBM.Name = "BT_DBM";
            this.BT_DBM.Size = new System.Drawing.Size(90, 25);
            this.BT_DBM.TabIndex = 23;
            this.BT_DBM.Text = "Set";
            this.BT_DBM.UseVisualStyleBackColor = true;
            this.BT_DBM.Click += new System.EventHandler(this.BT_DBM_Click);
            // 
            // gpb_Freq
            // 
            this.gpb_Freq.Controls.Add(this.radioButton_band0);
            this.gpb_Freq.Controls.Add(this.radioButton_band12);
            this.gpb_Freq.Controls.Add(this.radioButton_band8);
            this.gpb_Freq.Controls.Add(this.CheckBox_SameFre);
            this.gpb_Freq.Controls.Add(this.radioButton_band4);
            this.gpb_Freq.Controls.Add(this.radioButton_band3);
            this.gpb_Freq.Controls.Add(this.radioButton_band2);
            this.gpb_Freq.Controls.Add(this.radioButton_band1);
            this.gpb_Freq.Controls.Add(this.btFreq);
            this.gpb_Freq.Controls.Add(this.ComboBox_dmaxfre);
            this.gpb_Freq.Controls.Add(this.label15);
            this.gpb_Freq.Controls.Add(this.ComboBox_dminfre);
            this.gpb_Freq.Controls.Add(this.label14);
            this.gpb_Freq.Location = new System.Drawing.Point(354, 60);
            this.gpb_Freq.Name = "gpb_Freq";
            this.gpb_Freq.Size = new System.Drawing.Size(695, 76);
            this.gpb_Freq.TabIndex = 28;
            this.gpb_Freq.TabStop = false;
            this.gpb_Freq.Text = "Region";
            // 
            // radioButton_band0
            // 
            this.radioButton_band0.AutoSize = true;
            this.radioButton_band0.Location = new System.Drawing.Point(249, 48);
            this.radioButton_band0.Name = "radioButton_band0";
            this.radioButton_band0.Size = new System.Drawing.Size(71, 17);
            this.radioButton_band0.TabIndex = 21;
            this.radioButton_band0.TabStop = true;
            this.radioButton_band0.Text = "ALL band";
            this.radioButton_band0.UseVisualStyleBackColor = true;
            this.radioButton_band0.CheckedChanged += new System.EventHandler(this.radioButton_band0_CheckedChanged);
            // 
            // radioButton_band12
            // 
            this.radioButton_band12.AutoSize = true;
            this.radioButton_band12.Location = new System.Drawing.Point(172, 48);
            this.radioButton_band12.Name = "radioButton_band12";
            this.radioButton_band12.Size = new System.Drawing.Size(73, 17);
            this.radioButton_band12.TabIndex = 18;
            this.radioButton_band12.TabStop = true;
            this.radioButton_band12.Text = "US band3";
            this.radioButton_band12.UseVisualStyleBackColor = true;
            this.radioButton_band12.CheckedChanged += new System.EventHandler(this.radioButton_band12_CheckedChanged);
            // 
            // radioButton_band8
            // 
            this.radioButton_band8.AutoSize = true;
            this.radioButton_band8.Location = new System.Drawing.Point(10, 19);
            this.radioButton_band8.Name = "radioButton_band8";
            this.radioButton_band8.Size = new System.Drawing.Size(96, 17);
            this.radioButton_band8.TabIndex = 17;
            this.radioButton_band8.TabStop = true;
            this.radioButton_band8.Text = "Chinese band1";
            this.radioButton_band8.UseVisualStyleBackColor = true;
            this.radioButton_band8.CheckedChanged += new System.EventHandler(this.radioButton_band8_CheckedChanged);
            // 
            // CheckBox_SameFre
            // 
            this.CheckBox_SameFre.AutoSize = true;
            this.CheckBox_SameFre.Location = new System.Drawing.Point(585, 17);
            this.CheckBox_SameFre.Name = "CheckBox_SameFre";
            this.CheckBox_SameFre.Size = new System.Drawing.Size(55, 17);
            this.CheckBox_SameFre.TabIndex = 16;
            this.CheckBox_SameFre.Text = "Single";
            this.CheckBox_SameFre.UseVisualStyleBackColor = true;
            this.CheckBox_SameFre.CheckedChanged += new System.EventHandler(this.CheckBox_SameFre_CheckedChanged);
            // 
            // radioButton_band4
            // 
            this.radioButton_band4.AutoSize = true;
            this.radioButton_band4.Location = new System.Drawing.Point(103, 48);
            this.radioButton_band4.Name = "radioButton_band4";
            this.radioButton_band4.Size = new System.Drawing.Size(67, 17);
            this.radioButton_band4.TabIndex = 15;
            this.radioButton_band4.TabStop = true;
            this.radioButton_band4.Text = "EU band";
            this.radioButton_band4.UseVisualStyleBackColor = true;
            this.radioButton_band4.CheckedChanged += new System.EventHandler(this.radioButton_band4_CheckedChanged);
            // 
            // radioButton_band3
            // 
            this.radioButton_band3.AutoSize = true;
            this.radioButton_band3.Location = new System.Drawing.Point(10, 48);
            this.radioButton_band3.Name = "radioButton_band3";
            this.radioButton_band3.Size = new System.Drawing.Size(86, 17);
            this.radioButton_band3.TabIndex = 14;
            this.radioButton_band3.TabStop = true;
            this.radioButton_band3.Text = "Korean band";
            this.radioButton_band3.UseVisualStyleBackColor = true;
            this.radioButton_band3.CheckedChanged += new System.EventHandler(this.radioButton_band3_CheckedChanged);
            // 
            // radioButton_band2
            // 
            this.radioButton_band2.AutoSize = true;
            this.radioButton_band2.Location = new System.Drawing.Point(247, 17);
            this.radioButton_band2.Name = "radioButton_band2";
            this.radioButton_band2.Size = new System.Drawing.Size(67, 17);
            this.radioButton_band2.TabIndex = 13;
            this.radioButton_band2.TabStop = true;
            this.radioButton_band2.Text = "US band";
            this.radioButton_band2.UseVisualStyleBackColor = true;
            this.radioButton_band2.CheckedChanged += new System.EventHandler(this.radioButton_band2_CheckedChanged);
            // 
            // radioButton_band1
            // 
            this.radioButton_band1.AutoSize = true;
            this.radioButton_band1.Location = new System.Drawing.Point(127, 19);
            this.radioButton_band1.Name = "radioButton_band1";
            this.radioButton_band1.Size = new System.Drawing.Size(96, 17);
            this.radioButton_band1.TabIndex = 12;
            this.radioButton_band1.TabStop = true;
            this.radioButton_band1.Text = "Chinese band2";
            this.radioButton_band1.UseVisualStyleBackColor = true;
            this.radioButton_band1.CheckedChanged += new System.EventHandler(this.radioButton_band1_CheckedChanged);
            // 
            // btFreq
            // 
            this.btFreq.Location = new System.Drawing.Point(585, 40);
            this.btFreq.Name = "btFreq";
            this.btFreq.Size = new System.Drawing.Size(90, 25);
            this.btFreq.TabIndex = 11;
            this.btFreq.Text = "Set";
            this.btFreq.UseVisualStyleBackColor = true;
            this.btFreq.Click += new System.EventHandler(this.btFreq_Click);
            // 
            // ComboBox_dmaxfre
            // 
            this.ComboBox_dmaxfre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_dmaxfre.FormattingEnabled = true;
            this.ComboBox_dmaxfre.Location = new System.Drawing.Point(421, 46);
            this.ComboBox_dmaxfre.Name = "ComboBox_dmaxfre";
            this.ComboBox_dmaxfre.Size = new System.Drawing.Size(100, 21);
            this.ComboBox_dmaxfre.TabIndex = 10;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(332, 50);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(42, 13);
            this.label15.TabIndex = 9;
            this.label15.Text = "Maxfre:";
            // 
            // ComboBox_dminfre
            // 
            this.ComboBox_dminfre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_dminfre.FormattingEnabled = true;
            this.ComboBox_dminfre.Location = new System.Drawing.Point(421, 14);
            this.ComboBox_dminfre.Name = "ComboBox_dminfre";
            this.ComboBox_dminfre.Size = new System.Drawing.Size(100, 21);
            this.ComboBox_dminfre.TabIndex = 8;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(332, 19);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(39, 13);
            this.label14.TabIndex = 7;
            this.label14.Text = "Minfre:";
            // 
            // gpb_beep
            // 
            this.gpb_beep.Controls.Add(this.Radio_beepDis);
            this.gpb_beep.Controls.Add(this.Radio_beepEn);
            this.gpb_beep.Controls.Add(this.Button_Beep);
            this.gpb_beep.Location = new System.Drawing.Point(707, 6);
            this.gpb_beep.Name = "gpb_beep";
            this.gpb_beep.Size = new System.Drawing.Size(342, 48);
            this.gpb_beep.TabIndex = 27;
            this.gpb_beep.TabStop = false;
            this.gpb_beep.Text = "Beep";
            // 
            // Radio_beepDis
            // 
            this.Radio_beepDis.AutoSize = true;
            this.Radio_beepDis.Checked = true;
            this.Radio_beepDis.Location = new System.Drawing.Point(123, 20);
            this.Radio_beepDis.Name = "Radio_beepDis";
            this.Radio_beepDis.Size = new System.Drawing.Size(51, 17);
            this.Radio_beepDis.TabIndex = 10;
            this.Radio_beepDis.TabStop = true;
            this.Radio_beepDis.Text = "Close";
            this.Radio_beepDis.UseVisualStyleBackColor = true;
            // 
            // Radio_beepEn
            // 
            this.Radio_beepEn.AutoSize = true;
            this.Radio_beepEn.Location = new System.Drawing.Point(33, 20);
            this.Radio_beepEn.Name = "Radio_beepEn";
            this.Radio_beepEn.Size = new System.Drawing.Size(51, 17);
            this.Radio_beepEn.TabIndex = 9;
            this.Radio_beepEn.Text = "Open";
            this.Radio_beepEn.UseVisualStyleBackColor = true;
            // 
            // Button_Beep
            // 
            this.Button_Beep.Location = new System.Drawing.Point(232, 15);
            this.Button_Beep.Name = "Button_Beep";
            this.Button_Beep.Size = new System.Drawing.Size(90, 25);
            this.Button_Beep.TabIndex = 8;
            this.Button_Beep.Text = "Set";
            this.Button_Beep.UseVisualStyleBackColor = true;
            this.Button_Beep.Click += new System.EventHandler(this.Button_Beep_Click);
            // 
            // gpb_RDVersion
            // 
            this.gpb_RDVersion.Controls.Add(this.text_RDVersion);
            this.gpb_RDVersion.Location = new System.Drawing.Point(354, 6);
            this.gpb_RDVersion.Name = "gpb_RDVersion";
            this.gpb_RDVersion.Size = new System.Drawing.Size(342, 48);
            this.gpb_RDVersion.TabIndex = 26;
            this.gpb_RDVersion.TabStop = false;
            this.gpb_RDVersion.Text = "Firmware version";
            // 
            // text_RDVersion
            // 
            this.text_RDVersion.Location = new System.Drawing.Point(95, 16);
            this.text_RDVersion.MaxLength = 2;
            this.text_RDVersion.Name = "text_RDVersion";
            this.text_RDVersion.ReadOnly = true;
            this.text_RDVersion.Size = new System.Drawing.Size(160, 20);
            this.text_RDVersion.TabIndex = 24;
            // 
            // gpb_MDVersion
            // 
            this.gpb_MDVersion.Controls.Add(this.text_MDVersion);
            this.gpb_MDVersion.Controls.Add(this.btMDVersion);
            this.gpb_MDVersion.Location = new System.Drawing.Point(6, 604);
            this.gpb_MDVersion.Name = "gpb_MDVersion";
            this.gpb_MDVersion.Size = new System.Drawing.Size(342, 64);
            this.gpb_MDVersion.TabIndex = 25;
            this.gpb_MDVersion.TabStop = false;
            this.gpb_MDVersion.Text = "R2000模块版本号";
            // 
            // text_MDVersion
            // 
            this.text_MDVersion.Location = new System.Drawing.Point(95, 25);
            this.text_MDVersion.MaxLength = 2;
            this.text_MDVersion.Name = "text_MDVersion";
            this.text_MDVersion.ReadOnly = true;
            this.text_MDVersion.Size = new System.Drawing.Size(121, 20);
            this.text_MDVersion.TabIndex = 24;
            // 
            // btMDVersion
            // 
            this.btMDVersion.Location = new System.Drawing.Point(233, 25);
            this.btMDVersion.Name = "btMDVersion";
            this.btMDVersion.Size = new System.Drawing.Size(90, 25);
            this.btMDVersion.TabIndex = 23;
            this.btMDVersion.Text = "读取";
            this.btMDVersion.UseVisualStyleBackColor = true;
            this.btMDVersion.Click += new System.EventHandler(this.btMDVersion_Click);
            // 
            // gpb_Serial
            // 
            this.gpb_Serial.Controls.Add(this.text_Serial);
            this.gpb_Serial.Controls.Add(this.btSerial);
            this.gpb_Serial.Location = new System.Drawing.Point(6, 189);
            this.gpb_Serial.Name = "gpb_Serial";
            this.gpb_Serial.Size = new System.Drawing.Size(342, 72);
            this.gpb_Serial.TabIndex = 6;
            this.gpb_Serial.TabStop = false;
            this.gpb_Serial.Text = "Reader serial number\n";
            // 
            // text_Serial
            // 
            this.text_Serial.Location = new System.Drawing.Point(67, 29);
            this.text_Serial.MaxLength = 8;
            this.text_Serial.Name = "text_Serial";
            this.text_Serial.ReadOnly = true;
            this.text_Serial.Size = new System.Drawing.Size(121, 20);
            this.text_Serial.TabIndex = 24;
            // 
            // btSerial
            // 
            this.btSerial.Location = new System.Drawing.Point(233, 26);
            this.btSerial.Name = "btSerial";
            this.btSerial.Size = new System.Drawing.Size(90, 25);
            this.btSerial.TabIndex = 23;
            this.btSerial.Text = "Get";
            this.btSerial.UseVisualStyleBackColor = true;
            this.btSerial.Click += new System.EventHandler(this.btSerial_Click);
            // 
            // gpb_address
            // 
            this.gpb_address.Controls.Add(this.text_address);
            this.gpb_address.Controls.Add(this.btaddress);
            this.gpb_address.Location = new System.Drawing.Point(6, 135);
            this.gpb_address.Name = "gpb_address";
            this.gpb_address.Size = new System.Drawing.Size(342, 59);
            this.gpb_address.TabIndex = 5;
            this.gpb_address.TabStop = false;
            this.gpb_address.Text = "Reader address";
            // 
            // text_address
            // 
            this.text_address.Location = new System.Drawing.Point(95, 15);
            this.text_address.MaxLength = 2;
            this.text_address.Name = "text_address";
            this.text_address.Size = new System.Drawing.Size(121, 20);
            this.text_address.TabIndex = 24;
            this.text_address.Text = "00";
            this.text_address.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.text_address_KeyPress);
            // 
            // btaddress
            // 
            this.btaddress.Location = new System.Drawing.Point(233, 15);
            this.btaddress.Name = "btaddress";
            this.btaddress.Size = new System.Drawing.Size(90, 25);
            this.btaddress.TabIndex = 23;
            this.btaddress.Text = "Set";
            this.btaddress.UseVisualStyleBackColor = true;
            this.btaddress.Click += new System.EventHandler(this.btaddress_Click);
            // 
            // gpb_rs232
            // 
            this.gpb_rs232.Controls.Add(this.btDisConnect232);
            this.gpb_rs232.Controls.Add(this.btConnect232);
            this.gpb_rs232.Controls.Add(this.ComboBox_baud2);
            this.gpb_rs232.Controls.Add(this.label47);
            this.gpb_rs232.Controls.Add(this.ComboBox_COM);
            this.gpb_rs232.Controls.Add(this.label3);
            this.gpb_rs232.Location = new System.Drawing.Point(5, 55);
            this.gpb_rs232.Name = "gpb_rs232";
            this.gpb_rs232.Size = new System.Drawing.Size(343, 76);
            this.gpb_rs232.TabIndex = 3;
            this.gpb_rs232.TabStop = false;
            this.gpb_rs232.Text = "RS232";
            // 
            // btDisConnect232
            // 
            this.btDisConnect232.Enabled = false;
            this.btDisConnect232.Location = new System.Drawing.Point(234, 45);
            this.btDisConnect232.Name = "btDisConnect232";
            this.btDisConnect232.Size = new System.Drawing.Size(90, 25);
            this.btDisConnect232.TabIndex = 20;
            this.btDisConnect232.Text = "Disconnect";
            this.btDisConnect232.UseVisualStyleBackColor = true;
            this.btDisConnect232.Click += new System.EventHandler(this.btDisConnect232_Click);
            // 
            // btConnect232
            // 
            this.btConnect232.Location = new System.Drawing.Point(234, 14);
            this.btConnect232.Name = "btConnect232";
            this.btConnect232.Size = new System.Drawing.Size(90, 25);
            this.btConnect232.TabIndex = 19;
            this.btConnect232.Text = "Connect";
            this.btConnect232.UseVisualStyleBackColor = true;
            this.btConnect232.Click += new System.EventHandler(this.btConnect232_Click);
            // 
            // ComboBox_baud2
            // 
            this.ComboBox_baud2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_baud2.FormattingEnabled = true;
            this.ComboBox_baud2.Items.AddRange(new object[] {
            "9600bps",
            "19200bps",
            "38400bps",
            "57600bps",
            "115200bps"});
            this.ComboBox_baud2.Location = new System.Drawing.Point(96, 46);
            this.ComboBox_baud2.Name = "ComboBox_baud2";
            this.ComboBox_baud2.Size = new System.Drawing.Size(121, 21);
            this.ComboBox_baud2.TabIndex = 18;
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(21, 52);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(56, 13);
            this.label47.TabIndex = 17;
            this.label47.Text = "Baud rate:";
            // 
            // ComboBox_COM
            // 
            this.ComboBox_COM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_COM.FormattingEnabled = true;
            this.ComboBox_COM.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9"});
            this.ComboBox_COM.Location = new System.Drawing.Point(96, 16);
            this.ComboBox_COM.Name = "ComboBox_COM";
            this.ComboBox_COM.Size = new System.Drawing.Size(121, 21);
            this.ComboBox_COM.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Serial Port:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rb_rs232);
            this.groupBox1.Location = new System.Drawing.Point(5, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(343, 48);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connect Type";
            // 
            // rb_rs232
            // 
            this.rb_rs232.AutoSize = true;
            this.rb_rs232.Location = new System.Drawing.Point(33, 20);
            this.rb_rs232.Name = "rb_rs232";
            this.rb_rs232.Size = new System.Drawing.Size(58, 17);
            this.rb_rs232.TabIndex = 0;
            this.rb_rs232.Text = "RS232";
            this.rb_rs232.UseVisualStyleBackColor = true;
            this.rb_rs232.CheckedChanged += new System.EventHandler(this.rb_rs232_CheckedChanged);
            // 
            // tabPage15
            // 
            this.tabPage15.Controls.Add(this.groupBox62);
            this.tabPage15.Controls.Add(this.panel11);
            this.tabPage15.Location = new System.Drawing.Point(4, 27);
            this.tabPage15.Name = "tabPage15";
            this.tabPage15.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage15.Size = new System.Drawing.Size(1136, 584);
            this.tabPage15.TabIndex = 3;
            this.tabPage15.Text = "Add-Function";
            this.tabPage15.UseVisualStyleBackColor = true;
            // 
            // groupBox62
            // 
            this.groupBox62.Controls.Add(this.label202);
            this.groupBox62.Controls.Add(this.textBox2);
            this.groupBox62.Controls.Add(this.textBox1);
            this.groupBox62.Controls.Add(this.checkBox7);
            this.groupBox62.Controls.Add(this.label200);
            this.groupBox62.Controls.Add(this.button11);
            this.groupBox62.Controls.Add(this.label201);
            this.groupBox62.Controls.Add(this.label203);
            this.groupBox62.Controls.Add(this.comboBox6);
            this.groupBox62.Controls.Add(this.button12);
            this.groupBox62.Location = new System.Drawing.Point(7, 235);
            this.groupBox62.Name = "groupBox62";
            this.groupBox62.Size = new System.Drawing.Size(771, 58);
            this.groupBox62.TabIndex = 87;
            this.groupBox62.TabStop = false;
            this.groupBox62.Text = "Custom Region";
            // 
            // label202
            // 
            this.label202.AutoSize = true;
            this.label202.Location = new System.Drawing.Point(454, 26);
            this.label202.Name = "label202";
            this.label202.Size = new System.Drawing.Size(46, 13);
            this.label202.TabIndex = 34;
            this.label202.Text = "*125khz";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(376, 20);
            this.textBox2.MaxLength = 3;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(72, 20);
            this.textBox2.TabIndex = 33;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(102, 20);
            this.textBox1.MaxLength = 6;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(70, 20);
            this.textBox1.TabIndex = 32;
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.Checked = true;
            this.checkBox7.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox7.Location = new System.Drawing.Point(511, 25);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(51, 17);
            this.checkBox7.TabIndex = 31;
            this.checkBox7.Text = "Save";
            this.checkBox7.UseVisualStyleBackColor = true;
            // 
            // label200
            // 
            this.label200.AutoSize = true;
            this.label200.Location = new System.Drawing.Point(4, 26);
            this.label200.Name = "label200";
            this.label200.Size = new System.Drawing.Size(82, 13);
            this.label200.TabIndex = 30;
            this.label200.Text = "Start Freq(khz)：";
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(683, 20);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(75, 25);
            this.button11.TabIndex = 28;
            this.button11.Text = "Get";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // label201
            // 
            this.label201.AutoSize = true;
            this.label201.Location = new System.Drawing.Point(335, 26);
            this.label201.Name = "label201";
            this.label201.Size = new System.Drawing.Size(41, 13);
            this.label201.TabIndex = 27;
            this.label201.Text = "Space:";
            // 
            // label203
            // 
            this.label203.AutoSize = true;
            this.label203.Location = new System.Drawing.Point(203, 26);
            this.label203.Name = "label203";
            this.label203.Size = new System.Drawing.Size(38, 13);
            this.label203.TabIndex = 25;
            this.label203.Text = "Count:";
            // 
            // comboBox6
            // 
            this.comboBox6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox6.FormattingEnabled = true;
            this.comboBox6.Location = new System.Drawing.Point(246, 20);
            this.comboBox6.Name = "comboBox6";
            this.comboBox6.Size = new System.Drawing.Size(72, 21);
            this.comboBox6.TabIndex = 24;
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(603, 20);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(75, 25);
            this.button12.TabIndex = 23;
            this.button12.Text = "Set";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.groupBox58);
            this.panel11.Controls.Add(this.groupBox4);
            this.panel11.Controls.Add(this.groupBox57);
            this.panel11.Controls.Add(this.groupBox45);
            this.panel11.Controls.Add(this.gbp_MixRead);
            this.panel11.Controls.Add(this.gbp_PowerAnt);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel11.Location = new System.Drawing.Point(3, 3);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(1130, 578);
            this.panel11.TabIndex = 0;
            // 
            // groupBox58
            // 
            this.groupBox58.Controls.Add(this.checkBox6);
            this.groupBox58.Controls.Add(this.label194);
            this.groupBox58.Controls.Add(this.com_queryInter);
            this.groupBox58.Controls.Add(this.button7);
            this.groupBox58.Controls.Add(this.label192);
            this.groupBox58.Controls.Add(this.cbb_add);
            this.groupBox58.Controls.Add(this.label193);
            this.groupBox58.Controls.Add(this.cbb_dwell);
            this.groupBox58.Controls.Add(this.button8);
            this.groupBox58.Location = new System.Drawing.Point(4, 170);
            this.groupBox58.Name = "groupBox58";
            this.groupBox58.Size = new System.Drawing.Size(771, 58);
            this.groupBox58.TabIndex = 83;
            this.groupBox58.TabStop = false;
            this.groupBox58.Text = "Query Param";
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Checked = true;
            this.checkBox6.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox6.Location = new System.Drawing.Point(511, 25);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(51, 17);
            this.checkBox6.TabIndex = 31;
            this.checkBox6.Text = "Save";
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // label194
            // 
            this.label194.AutoSize = true;
            this.label194.Location = new System.Drawing.Point(12, 26);
            this.label194.Name = "label194";
            this.label194.Size = new System.Drawing.Size(48, 13);
            this.label194.TabIndex = 30;
            this.label194.Text = "Interval：";
            // 
            // com_queryInter
            // 
            this.com_queryInter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.com_queryInter.FormattingEnabled = true;
            this.com_queryInter.Items.AddRange(new object[] {
            "00ms",
            "10ms",
            "20ms",
            "30ms",
            "40ms",
            "50ms",
            "60ms"});
            this.com_queryInter.Location = new System.Drawing.Point(76, 22);
            this.com_queryInter.Name = "com_queryInter";
            this.com_queryInter.Size = new System.Drawing.Size(72, 21);
            this.com_queryInter.TabIndex = 29;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(683, 20);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 25);
            this.button7.TabIndex = 28;
            this.button7.Text = "Get";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // label192
            // 
            this.label192.AutoSize = true;
            this.label192.Location = new System.Drawing.Point(331, 26);
            this.label192.Name = "label192";
            this.label192.Size = new System.Drawing.Size(77, 13);
            this.label192.TabIndex = 27;
            this.label192.Text = "Append times：";
            // 
            // cbb_add
            // 
            this.cbb_add.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_add.FormattingEnabled = true;
            this.cbb_add.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4"});
            this.cbb_add.Location = new System.Drawing.Point(423, 22);
            this.cbb_add.Name = "cbb_add";
            this.cbb_add.Size = new System.Drawing.Size(72, 21);
            this.cbb_add.TabIndex = 26;
            // 
            // label193
            // 
            this.label193.AutoSize = true;
            this.label193.Location = new System.Drawing.Point(161, 26);
            this.label193.Name = "label193";
            this.label193.Size = new System.Drawing.Size(62, 13);
            this.label193.TabIndex = 25;
            this.label193.Text = "DwellTime：";
            // 
            // cbb_dwell
            // 
            this.cbb_dwell.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_dwell.FormattingEnabled = true;
            this.cbb_dwell.Location = new System.Drawing.Point(235, 22);
            this.cbb_dwell.Name = "cbb_dwell";
            this.cbb_dwell.Size = new System.Drawing.Size(72, 21);
            this.cbb_dwell.TabIndex = 24;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(603, 20);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 25);
            this.button8.TabIndex = 23;
            this.button8.Text = "Set";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.check_phase);
            this.groupBox4.Controls.Add(this.checkBox_rate);
            this.groupBox4.Controls.Add(this.label80);
            this.groupBox4.Controls.Add(this.text_target);
            this.groupBox4.Controls.Add(this.check_num);
            this.groupBox4.Controls.Add(this.com_Target);
            this.groupBox4.Controls.Add(this.label79);
            this.groupBox4.Controls.Add(this.com_scantime);
            this.groupBox4.Controls.Add(this.label39);
            this.groupBox4.Controls.Add(this.com_S);
            this.groupBox4.Controls.Add(this.label32);
            this.groupBox4.Controls.Add(this.com_Q);
            this.groupBox4.Controls.Add(this.label31);
            this.groupBox4.Location = new System.Drawing.Point(243, 296);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(400, 90);
            this.groupBox4.TabIndex = 17;
            this.groupBox4.TabStop = false;
            // 
            // check_phase
            // 
            this.check_phase.AutoSize = true;
            this.check_phase.Checked = true;
            this.check_phase.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_phase.Location = new System.Drawing.Point(342, 50);
            this.check_phase.Name = "check_phase";
            this.check_phase.Size = new System.Drawing.Size(56, 17);
            this.check_phase.TabIndex = 38;
            this.check_phase.Text = "Phase";
            this.check_phase.UseVisualStyleBackColor = true;
            // 
            // checkBox_rate
            // 
            this.checkBox_rate.AutoSize = true;
            this.checkBox_rate.Location = new System.Drawing.Point(317, 68);
            this.checkBox_rate.Name = "checkBox_rate";
            this.checkBox_rate.Size = new System.Drawing.Size(87, 17);
            this.checkBox_rate.TabIndex = 37;
            this.checkBox_rate.Text = "return Speed";
            this.checkBox_rate.UseVisualStyleBackColor = true;
            this.checkBox_rate.Visible = false;
            // 
            // label80
            // 
            this.label80.AutoSize = true;
            this.label80.Location = new System.Drawing.Point(184, 52);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(144, 13);
            this.label80.TabIndex = 36;
            this.label80.Text = "times no tag A/B conversion ";
            // 
            // text_target
            // 
            this.text_target.ForeColor = System.Drawing.Color.Red;
            this.text_target.Location = new System.Drawing.Point(139, 46);
            this.text_target.MaxLength = 2;
            this.text_target.Name = "text_target";
            this.text_target.Size = new System.Drawing.Size(43, 20);
            this.text_target.TabIndex = 35;
            this.text_target.Text = "5";
            this.text_target.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.text_target.TextChanged += new System.EventHandler(this.text_target_TextChanged);
            this.text_target.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_Port_KeyPress);
            // 
            // check_num
            // 
            this.check_num.AutoSize = true;
            this.check_num.Checked = true;
            this.check_num.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_num.Location = new System.Drawing.Point(122, 50);
            this.check_num.Name = "check_num";
            this.check_num.Size = new System.Drawing.Size(15, 14);
            this.check_num.TabIndex = 34;
            this.check_num.UseVisualStyleBackColor = true;
            // 
            // com_Target
            // 
            this.com_Target.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.com_Target.FormattingEnabled = true;
            this.com_Target.Items.AddRange(new object[] {
            "A",
            "B"});
            this.com_Target.Location = new System.Drawing.Point(58, 46);
            this.com_Target.Name = "com_Target";
            this.com_Target.Size = new System.Drawing.Size(51, 21);
            this.com_Target.TabIndex = 33;
            // 
            // label79
            // 
            this.label79.AutoSize = true;
            this.label79.Location = new System.Drawing.Point(13, 52);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(41, 13);
            this.label79.TabIndex = 32;
            this.label79.Text = "Target:";
            // 
            // com_scantime
            // 
            this.com_scantime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.com_scantime.FormattingEnabled = true;
            this.com_scantime.Location = new System.Drawing.Point(316, 17);
            this.com_scantime.Name = "com_scantime";
            this.com_scantime.Size = new System.Drawing.Size(77, 21);
            this.com_scantime.TabIndex = 31;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(249, 20);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(58, 13);
            this.label39.TabIndex = 30;
            this.label39.Text = "ScanTime:";
            // 
            // com_S
            // 
            this.com_S.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.com_S.FormattingEnabled = true;
            this.com_S.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "AUTO-1",
            "AUTO-2",
            "AUTO-3"});
            this.com_S.Location = new System.Drawing.Point(182, 17);
            this.com_S.Name = "com_S";
            this.com_S.Size = new System.Drawing.Size(59, 21);
            this.com_S.TabIndex = 29;
            this.com_S.SelectedIndexChanged += new System.EventHandler(this.com_S_SelectedIndexChanged);
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(120, 22);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(50, 13);
            this.label32.TabIndex = 28;
            this.label32.Text = "Session：";
            // 
            // com_Q
            // 
            this.com_Q.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.com_Q.FormattingEnabled = true;
            this.com_Q.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15"});
            this.com_Q.Location = new System.Drawing.Point(58, 16);
            this.com_Q.Name = "com_Q";
            this.com_Q.Size = new System.Drawing.Size(51, 21);
            this.com_Q.TabIndex = 27;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(15, 20);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(18, 13);
            this.label31.TabIndex = 26;
            this.label31.Text = "Q:";
            // 
            // groupBox57
            // 
            this.groupBox57.Controls.Add(this.rb_enable);
            this.groupBox57.Controls.Add(this.rb_disable);
            this.groupBox57.Controls.Add(this.button5);
            this.groupBox57.Controls.Add(this.button6);
            this.groupBox57.Location = new System.Drawing.Point(781, 7);
            this.groupBox57.Name = "groupBox57";
            this.groupBox57.Size = new System.Drawing.Size(264, 78);
            this.groupBox57.TabIndex = 82;
            this.groupBox57.TabStop = false;
            this.groupBox57.Text = "TagFocus";
            // 
            // rb_enable
            // 
            this.rb_enable.AutoSize = true;
            this.rb_enable.Checked = true;
            this.rb_enable.Location = new System.Drawing.Point(96, 33);
            this.rb_enable.Name = "rb_enable";
            this.rb_enable.Size = new System.Drawing.Size(58, 17);
            this.rb_enable.TabIndex = 11;
            this.rb_enable.TabStop = true;
            this.rb_enable.Text = "Enable";
            this.rb_enable.UseVisualStyleBackColor = true;
            // 
            // rb_disable
            // 
            this.rb_disable.AutoSize = true;
            this.rb_disable.Location = new System.Drawing.Point(14, 33);
            this.rb_disable.Name = "rb_disable";
            this.rb_disable.Size = new System.Drawing.Size(66, 17);
            this.rb_disable.TabIndex = 10;
            this.rb_disable.Text = "Disabled";
            this.rb_disable.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(184, 46);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(77, 25);
            this.button5.TabIndex = 9;
            this.button5.Text = "Get";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(184, 20);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(77, 25);
            this.button6.TabIndex = 8;
            this.button6.Text = "Set";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // groupBox45
            // 
            this.groupBox45.Controls.Add(this.comboBox4);
            this.groupBox45.Controls.Add(this.button1);
            this.groupBox45.Controls.Add(this.button2);
            this.groupBox45.Location = new System.Drawing.Point(4, 104);
            this.groupBox45.Name = "groupBox45";
            this.groupBox45.Size = new System.Drawing.Size(771, 56);
            this.groupBox45.TabIndex = 81;
            this.groupBox45.TabStop = false;
            this.groupBox45.Text = "RF link profile.";
            // 
            // comboBox4
            // 
            this.comboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(6, 22);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(550, 21);
            this.comboBox4.TabIndex = 29;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(682, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(77, 25);
            this.button1.TabIndex = 9;
            this.button1.Text = "Get";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(603, 22);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(77, 25);
            this.button2.TabIndex = 8;
            this.button2.Text = "Set";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // gbp_MixRead
            // 
            this.gbp_MixRead.Controls.Add(this.text_readpsd);
            this.gbp_MixRead.Controls.Add(this.label118);
            this.gbp_MixRead.Controls.Add(this.text_readLen);
            this.gbp_MixRead.Controls.Add(this.label117);
            this.gbp_MixRead.Controls.Add(this.text_readadr);
            this.gbp_MixRead.Controls.Add(this.label115);
            this.gbp_MixRead.Controls.Add(this.com_MixMem);
            this.gbp_MixRead.Controls.Add(this.label114);
            this.gbp_MixRead.Enabled = false;
            this.gbp_MixRead.Location = new System.Drawing.Point(5, 296);
            this.gbp_MixRead.Name = "gbp_MixRead";
            this.gbp_MixRead.Size = new System.Drawing.Size(222, 90);
            this.gbp_MixRead.TabIndex = 29;
            this.gbp_MixRead.TabStop = false;
            this.gbp_MixRead.Text = "Mix";
            // 
            // text_readpsd
            // 
            this.text_readpsd.Location = new System.Drawing.Point(64, 46);
            this.text_readpsd.MaxLength = 8;
            this.text_readpsd.Name = "text_readpsd";
            this.text_readpsd.Size = new System.Drawing.Size(65, 20);
            this.text_readpsd.TabIndex = 7;
            this.text_readpsd.Text = "00000000";
            this.text_readpsd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.text_address_KeyPress);
            // 
            // label118
            // 
            this.label118.AutoSize = true;
            this.label118.Location = new System.Drawing.Point(6, 50);
            this.label118.Name = "label118";
            this.label118.Size = new System.Drawing.Size(56, 13);
            this.label118.TabIndex = 6;
            this.label118.Text = "Password:";
            // 
            // text_readLen
            // 
            this.text_readLen.Location = new System.Drawing.Point(176, 48);
            this.text_readLen.MaxLength = 2;
            this.text_readLen.Name = "text_readLen";
            this.text_readLen.Size = new System.Drawing.Size(41, 20);
            this.text_readLen.TabIndex = 5;
            this.text_readLen.Text = "04";
            this.text_readLen.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.text_address_KeyPress);
            // 
            // label117
            // 
            this.label117.AutoSize = true;
            this.label117.Location = new System.Drawing.Point(136, 52);
            this.label117.Name = "label117";
            this.label117.Size = new System.Drawing.Size(28, 13);
            this.label117.TabIndex = 4;
            this.label117.Text = "Len:";
            // 
            // text_readadr
            // 
            this.text_readadr.Location = new System.Drawing.Point(176, 14);
            this.text_readadr.MaxLength = 4;
            this.text_readadr.Name = "text_readadr";
            this.text_readadr.Size = new System.Drawing.Size(41, 20);
            this.text_readadr.TabIndex = 3;
            this.text_readadr.Text = "0002";
            this.text_readadr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.text_address_KeyPress);
            // 
            // label115
            // 
            this.label115.AutoSize = true;
            this.label115.Location = new System.Drawing.Point(136, 19);
            this.label115.Name = "label115";
            this.label115.Size = new System.Drawing.Size(32, 13);
            this.label115.TabIndex = 2;
            this.label115.Text = "Addr:";
            // 
            // com_MixMem
            // 
            this.com_MixMem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.com_MixMem.FormattingEnabled = true;
            this.com_MixMem.Items.AddRange(new object[] {
            "Reserve",
            "EPC",
            "TID",
            "User"});
            this.com_MixMem.Location = new System.Drawing.Point(64, 13);
            this.com_MixMem.Name = "com_MixMem";
            this.com_MixMem.Size = new System.Drawing.Size(66, 21);
            this.com_MixMem.TabIndex = 1;
            // 
            // label114
            // 
            this.label114.AutoSize = true;
            this.label114.Location = new System.Drawing.Point(5, 17);
            this.label114.Name = "label114";
            this.label114.Size = new System.Drawing.Size(33, 13);
            this.label114.TabIndex = 0;
            this.label114.Text = "Mem:";
            // 
            // gbp_PowerAnt
            // 
            this.gbp_PowerAnt.Controls.Add(this.txtPower4);
            this.gbp_PowerAnt.Controls.Add(this.label186);
            this.gbp_PowerAnt.Controls.Add(this.txtPower3);
            this.gbp_PowerAnt.Controls.Add(this.label187);
            this.gbp_PowerAnt.Controls.Add(this.txtPower2);
            this.gbp_PowerAnt.Controls.Add(this.label188);
            this.gbp_PowerAnt.Controls.Add(this.txtPower1);
            this.gbp_PowerAnt.Controls.Add(this.label189);
            this.gbp_PowerAnt.Controls.Add(this.btGetRfPower);
            this.gbp_PowerAnt.Controls.Add(this.checkBox3);
            this.gbp_PowerAnt.Controls.Add(this.btSetRfPower);
            this.gbp_PowerAnt.Location = new System.Drawing.Point(4, 6);
            this.gbp_PowerAnt.Name = "gbp_PowerAnt";
            this.gbp_PowerAnt.Size = new System.Drawing.Size(771, 91);
            this.gbp_PowerAnt.TabIndex = 80;
            this.gbp_PowerAnt.TabStop = false;
            this.gbp_PowerAnt.Text = "Antenna power config(dBm)";
            // 
            // txtPower4
            // 
            this.txtPower4.Location = new System.Drawing.Point(300, 20);
            this.txtPower4.MaxLength = 2;
            this.txtPower4.Name = "txtPower4";
            this.txtPower4.Size = new System.Drawing.Size(26, 20);
            this.txtPower4.TabIndex = 22;
            this.txtPower4.Text = "30";
            // 
            // label186
            // 
            this.label186.AutoSize = true;
            this.label186.Location = new System.Drawing.Point(261, 25);
            this.label186.Name = "label186";
            this.label186.Size = new System.Drawing.Size(38, 13);
            this.label186.TabIndex = 21;
            this.label186.Text = "ANT4:";
            // 
            // txtPower3
            // 
            this.txtPower3.Location = new System.Drawing.Point(215, 20);
            this.txtPower3.MaxLength = 2;
            this.txtPower3.Name = "txtPower3";
            this.txtPower3.Size = new System.Drawing.Size(26, 20);
            this.txtPower3.TabIndex = 20;
            this.txtPower3.Text = "30";
            // 
            // label187
            // 
            this.label187.AutoSize = true;
            this.label187.Location = new System.Drawing.Point(176, 25);
            this.label187.Name = "label187";
            this.label187.Size = new System.Drawing.Size(38, 13);
            this.label187.TabIndex = 19;
            this.label187.Text = "ANT3:";
            // 
            // txtPower2
            // 
            this.txtPower2.Location = new System.Drawing.Point(130, 20);
            this.txtPower2.MaxLength = 2;
            this.txtPower2.Name = "txtPower2";
            this.txtPower2.Size = new System.Drawing.Size(26, 20);
            this.txtPower2.TabIndex = 18;
            this.txtPower2.Text = "30";
            // 
            // label188
            // 
            this.label188.AutoSize = true;
            this.label188.Location = new System.Drawing.Point(91, 25);
            this.label188.Name = "label188";
            this.label188.Size = new System.Drawing.Size(38, 13);
            this.label188.TabIndex = 17;
            this.label188.Text = "ANT2:";
            // 
            // txtPower1
            // 
            this.txtPower1.Location = new System.Drawing.Point(47, 20);
            this.txtPower1.MaxLength = 2;
            this.txtPower1.Name = "txtPower1";
            this.txtPower1.Size = new System.Drawing.Size(26, 20);
            this.txtPower1.TabIndex = 16;
            this.txtPower1.Text = "30";
            // 
            // label189
            // 
            this.label189.AutoSize = true;
            this.label189.Location = new System.Drawing.Point(8, 25);
            this.label189.Name = "label189";
            this.label189.Size = new System.Drawing.Size(38, 13);
            this.label189.TabIndex = 15;
            this.label189.Text = "ANT1:";
            // 
            // btGetRfPower
            // 
            this.btGetRfPower.Location = new System.Drawing.Point(681, 62);
            this.btGetRfPower.Name = "btGetRfPower";
            this.btGetRfPower.Size = new System.Drawing.Size(77, 25);
            this.btGetRfPower.TabIndex = 11;
            this.btGetRfPower.Text = "Get";
            this.btGetRfPower.UseVisualStyleBackColor = true;
            this.btGetRfPower.Click += new System.EventHandler(this.btGetRfPower_Click);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Checked = true;
            this.checkBox3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox3.Location = new System.Drawing.Point(686, 15);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(51, 17);
            this.checkBox3.TabIndex = 10;
            this.checkBox3.Text = "Save";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // btSetRfPower
            // 
            this.btSetRfPower.Location = new System.Drawing.Point(681, 35);
            this.btSetRfPower.Name = "btSetRfPower";
            this.btSetRfPower.Size = new System.Drawing.Size(77, 25);
            this.btSetRfPower.TabIndex = 5;
            this.btSetRfPower.Text = "Set";
            this.btSetRfPower.UseVisualStyleBackColor = true;
            this.btSetRfPower.Click += new System.EventHandler(this.btSetRfPower_Click);
            // 
            // tabtest_SQL
            // 
            this.tabtest_SQL.Location = new System.Drawing.Point(4, 27);
            this.tabtest_SQL.Name = "tabtest_SQL";
            this.tabtest_SQL.Size = new System.Drawing.Size(1136, 584);
            this.tabtest_SQL.TabIndex = 4;
            this.tabtest_SQL.Text = "TEST_SQL";
            this.tabtest_SQL.UseVisualStyleBackColor = true;
            this.tabtest_SQL.Click += new System.EventHandler(this.tabtest_SQL_Click);
            // 
            // Main_Page2
            // 
            this.Main_Page2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Main_Page2.Controls.Add(this.tabControl2);
            this.Main_Page2.Location = new System.Drawing.Point(4, 27);
            this.Main_Page2.Name = "Main_Page2";
            this.Main_Page2.Padding = new System.Windows.Forms.Padding(3);
            this.Main_Page2.Size = new System.Drawing.Size(1147, 621);
            this.Main_Page2.TabIndex = 1;
            this.Main_Page2.Text = "EPCC1-G2";
            this.Main_Page2.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage_answer);
            this.tabControl2.ItemSize = new System.Drawing.Size(120, 23);
            this.tabControl2.Location = new System.Drawing.Point(-1, 6);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(1131, 612);
            this.tabControl2.TabIndex = 0;
            // 
            // tabPage_answer
            // 
            this.tabPage_answer.Controls.Add(this.chk_phase);
            this.tabPage_answer.Location = new System.Drawing.Point(4, 27);
            this.tabPage_answer.Name = "tabPage_answer";
            this.tabPage_answer.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_answer.Size = new System.Drawing.Size(1123, 581);
            this.tabPage_answer.TabIndex = 0;
            this.tabPage_answer.Text = "Answer Mode";
            this.tabPage_answer.UseVisualStyleBackColor = true;
            // 
            // chk_phase
            // 
            this.chk_phase.Controls.Add(this.group_ant1);
            this.chk_phase.Controls.Add(this.lxLedControl6);
            this.chk_phase.Controls.Add(this.label119);
            this.chk_phase.Controls.Add(this.lxLedControl5);
            this.chk_phase.Controls.Add(this.label9);
            this.chk_phase.Controls.Add(this.lxLedControl4);
            this.chk_phase.Controls.Add(this.label8);
            this.chk_phase.Controls.Add(this.lxLedControl3);
            this.chk_phase.Controls.Add(this.label7);
            this.chk_phase.Controls.Add(this.lxLedControl2);
            this.chk_phase.Controls.Add(this.label6);
            this.chk_phase.Controls.Add(this.lxLedControl1);
            this.chk_phase.Controls.Add(this.label5);
            this.chk_phase.Controls.Add(this.groupBox5);
            this.chk_phase.Controls.Add(this.groupBox2);
            this.chk_phase.Enabled = false;
            this.chk_phase.Location = new System.Drawing.Point(2, 2);
            this.chk_phase.Name = "chk_phase";
            this.chk_phase.Size = new System.Drawing.Size(1121, 574);
            this.chk_phase.TabIndex = 0;
            // 
            // group_ant1
            // 
            this.group_ant1.Controls.Add(this.check_ant4);
            this.group_ant1.Controls.Add(this.check_ant3);
            this.group_ant1.Controls.Add(this.check_ant2);
            this.group_ant1.Controls.Add(this.check_ant1);
            this.group_ant1.Location = new System.Drawing.Point(8, 84);
            this.group_ant1.Name = "group_ant1";
            this.group_ant1.Size = new System.Drawing.Size(89, 478);
            this.group_ant1.TabIndex = 44;
            this.group_ant1.TabStop = false;
            this.group_ant1.Text = "Antenna";
            // 
            // check_ant4
            // 
            this.check_ant4.AutoSize = true;
            this.check_ant4.Checked = true;
            this.check_ant4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_ant4.ForeColor = System.Drawing.Color.RoyalBlue;
            this.check_ant4.Location = new System.Drawing.Point(16, 88);
            this.check_ant4.Name = "check_ant4";
            this.check_ant4.Size = new System.Drawing.Size(54, 17);
            this.check_ant4.TabIndex = 37;
            this.check_ant4.Text = "ANT4";
            this.check_ant4.UseVisualStyleBackColor = true;
            // 
            // check_ant3
            // 
            this.check_ant3.AutoSize = true;
            this.check_ant3.Checked = true;
            this.check_ant3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_ant3.ForeColor = System.Drawing.Color.RoyalBlue;
            this.check_ant3.Location = new System.Drawing.Point(16, 66);
            this.check_ant3.Name = "check_ant3";
            this.check_ant3.Size = new System.Drawing.Size(54, 17);
            this.check_ant3.TabIndex = 36;
            this.check_ant3.Text = "ANT3";
            this.check_ant3.UseVisualStyleBackColor = true;
            // 
            // check_ant2
            // 
            this.check_ant2.AutoSize = true;
            this.check_ant2.Checked = true;
            this.check_ant2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_ant2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.check_ant2.Location = new System.Drawing.Point(16, 42);
            this.check_ant2.Name = "check_ant2";
            this.check_ant2.Size = new System.Drawing.Size(54, 17);
            this.check_ant2.TabIndex = 35;
            this.check_ant2.Text = "ANT2";
            this.check_ant2.UseVisualStyleBackColor = true;
            // 
            // check_ant1
            // 
            this.check_ant1.AutoSize = true;
            this.check_ant1.Checked = true;
            this.check_ant1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_ant1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.check_ant1.Location = new System.Drawing.Point(16, 20);
            this.check_ant1.Name = "check_ant1";
            this.check_ant1.Size = new System.Drawing.Size(54, 17);
            this.check_ant1.TabIndex = 34;
            this.check_ant1.Text = "ANT1";
            this.check_ant1.UseVisualStyleBackColor = true;
            // 
            // lxLedControl6
            // 
            this.lxLedControl6.BackColor = System.Drawing.Color.Transparent;
            this.lxLedControl6.BackColor_1 = System.Drawing.Color.Transparent;
            this.lxLedControl6.BackColor_2 = System.Drawing.Color.DarkRed;
            this.lxLedControl6.BevelRate = 0.5F;
            this.lxLedControl6.BorderColor = System.Drawing.Color.Lavender;
            this.lxLedControl6.BorderWidth = 3;
            this.lxLedControl6.FadedColor = System.Drawing.SystemColors.ControlLight;
            this.lxLedControl6.FocusedBorderColor = System.Drawing.Color.LightCoral;
            this.lxLedControl6.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lxLedControl6.HighlightOpaque = ((byte)(50));
            this.lxLedControl6.Location = new System.Drawing.Point(805, 241);
            this.lxLedControl6.Name = "lxLedControl6";
            this.lxLedControl6.RoundCorner = true;
            this.lxLedControl6.ShowHighlight = true;
            this.lxLedControl6.Size = new System.Drawing.Size(277, 88);
            this.lxLedControl6.TabIndex = 43;
            this.lxLedControl6.Text = "0";
            this.lxLedControl6.TextAlignment = LxControl.LxLedControl.Alignment.Right;
            this.lxLedControl6.TotalCharCount = 6;
            // 
            // label119
            // 
            this.label119.AutoSize = true;
            this.label119.Location = new System.Drawing.Point(807, 221);
            this.label119.Name = "label119";
            this.label119.Size = new System.Drawing.Size(68, 13);
            this.label119.TabIndex = 42;
            this.label119.Text = "TID Number:";
            // 
            // lxLedControl5
            // 
            this.lxLedControl5.BackColor = System.Drawing.Color.Transparent;
            this.lxLedControl5.BackColor_1 = System.Drawing.Color.Transparent;
            this.lxLedControl5.BackColor_2 = System.Drawing.Color.DarkRed;
            this.lxLedControl5.BevelRate = 0.5F;
            this.lxLedControl5.BorderColor = System.Drawing.Color.Lavender;
            this.lxLedControl5.BorderWidth = 3;
            this.lxLedControl5.FadedColor = System.Drawing.SystemColors.ControlLight;
            this.lxLedControl5.FocusedBorderColor = System.Drawing.Color.LightCoral;
            this.lxLedControl5.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lxLedControl5.HighlightOpaque = ((byte)(50));
            this.lxLedControl5.Location = new System.Drawing.Point(944, 481);
            this.lxLedControl5.Name = "lxLedControl5";
            this.lxLedControl5.RoundCorner = true;
            this.lxLedControl5.ShowHighlight = true;
            this.lxLedControl5.Size = new System.Drawing.Size(126, 30);
            this.lxLedControl5.TabIndex = 41;
            this.lxLedControl5.Text = "0";
            this.lxLedControl5.TextAlignment = LxControl.LxLedControl.Alignment.Right;
            this.lxLedControl5.TotalCharCount = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label9.Location = new System.Drawing.Point(942, 459);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(98, 13);
            this.label9.TabIndex = 40;
            this.label9.Text = "Total-cmd-time(ms):";
            // 
            // lxLedControl4
            // 
            this.lxLedControl4.BackColor = System.Drawing.Color.Transparent;
            this.lxLedControl4.BackColor_1 = System.Drawing.Color.Transparent;
            this.lxLedControl4.BackColor_2 = System.Drawing.Color.DarkRed;
            this.lxLedControl4.BevelRate = 0.5F;
            this.lxLedControl4.BorderColor = System.Drawing.Color.Lavender;
            this.lxLedControl4.BorderWidth = 3;
            this.lxLedControl4.FadedColor = System.Drawing.SystemColors.ControlLight;
            this.lxLedControl4.FocusedBorderColor = System.Drawing.Color.LightCoral;
            this.lxLedControl4.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lxLedControl4.HighlightOpaque = ((byte)(50));
            this.lxLedControl4.Location = new System.Drawing.Point(800, 480);
            this.lxLedControl4.Name = "lxLedControl4";
            this.lxLedControl4.RoundCorner = true;
            this.lxLedControl4.ShowHighlight = true;
            this.lxLedControl4.Size = new System.Drawing.Size(126, 32);
            this.lxLedControl4.TabIndex = 39;
            this.lxLedControl4.Text = "0";
            this.lxLedControl4.TextAlignment = LxControl.LxLedControl.Alignment.Right;
            this.lxLedControl4.TotalCharCount = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label8.Location = new System.Drawing.Point(798, 459);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 13);
            this.label8.TabIndex = 38;
            this.label8.Text = "Total tag number:";
            // 
            // lxLedControl3
            // 
            this.lxLedControl3.BackColor = System.Drawing.Color.Transparent;
            this.lxLedControl3.BackColor_1 = System.Drawing.Color.Transparent;
            this.lxLedControl3.BackColor_2 = System.Drawing.Color.DarkRed;
            this.lxLedControl3.BevelRate = 0.5F;
            this.lxLedControl3.BorderColor = System.Drawing.Color.Lavender;
            this.lxLedControl3.BorderWidth = 3;
            this.lxLedControl3.FadedColor = System.Drawing.SystemColors.ControlLight;
            this.lxLedControl3.FocusedBorderColor = System.Drawing.Color.LightCoral;
            this.lxLedControl3.ForeColor = System.Drawing.Color.Purple;
            this.lxLedControl3.HighlightOpaque = ((byte)(50));
            this.lxLedControl3.Location = new System.Drawing.Point(944, 392);
            this.lxLedControl3.Name = "lxLedControl3";
            this.lxLedControl3.RoundCorner = true;
            this.lxLedControl3.ShowHighlight = true;
            this.lxLedControl3.Size = new System.Drawing.Size(126, 32);
            this.lxLedControl3.TabIndex = 37;
            this.lxLedControl3.Text = "0";
            this.lxLedControl3.TextAlignment = LxControl.LxLedControl.Alignment.Right;
            this.lxLedControl3.TotalCharCount = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label7.Location = new System.Drawing.Point(942, 366);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 13);
            this.label7.TabIndex = 36;
            this.label7.Text = "cmd time(ms):";
            // 
            // lxLedControl2
            // 
            this.lxLedControl2.BackColor = System.Drawing.Color.Transparent;
            this.lxLedControl2.BackColor_1 = System.Drawing.Color.Transparent;
            this.lxLedControl2.BackColor_2 = System.Drawing.Color.DarkRed;
            this.lxLedControl2.BevelRate = 0.5F;
            this.lxLedControl2.BorderColor = System.Drawing.Color.Lavender;
            this.lxLedControl2.BorderWidth = 3;
            this.lxLedControl2.FadedColor = System.Drawing.SystemColors.ControlLight;
            this.lxLedControl2.FocusedBorderColor = System.Drawing.Color.LightCoral;
            this.lxLedControl2.ForeColor = System.Drawing.Color.Purple;
            this.lxLedControl2.HighlightOpaque = ((byte)(50));
            this.lxLedControl2.Location = new System.Drawing.Point(800, 392);
            this.lxLedControl2.Name = "lxLedControl2";
            this.lxLedControl2.RoundCorner = true;
            this.lxLedControl2.ShowHighlight = true;
            this.lxLedControl2.Size = new System.Drawing.Size(126, 32);
            this.lxLedControl2.TabIndex = 35;
            this.lxLedControl2.Text = "0";
            this.lxLedControl2.TextAlignment = LxControl.LxLedControl.Alignment.Right;
            this.lxLedControl2.TotalCharCount = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label6.Location = new System.Drawing.Point(798, 366);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 34;
            this.label6.Text = "Speed:";
            // 
            // lxLedControl1
            // 
            this.lxLedControl1.BackColor = System.Drawing.Color.Transparent;
            this.lxLedControl1.BackColor_1 = System.Drawing.Color.Transparent;
            this.lxLedControl1.BackColor_2 = System.Drawing.Color.DarkRed;
            this.lxLedControl1.BevelRate = 0.5F;
            this.lxLedControl1.BorderColor = System.Drawing.Color.Lavender;
            this.lxLedControl1.BorderWidth = 3;
            this.lxLedControl1.FadedColor = System.Drawing.SystemColors.ControlLight;
            this.lxLedControl1.FocusedBorderColor = System.Drawing.Color.LightCoral;
            this.lxLedControl1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lxLedControl1.HighlightOpaque = ((byte)(50));
            this.lxLedControl1.Location = new System.Drawing.Point(805, 114);
            this.lxLedControl1.Name = "lxLedControl1";
            this.lxLedControl1.RoundCorner = true;
            this.lxLedControl1.ShowHighlight = true;
            this.lxLedControl1.Size = new System.Drawing.Size(277, 88);
            this.lxLedControl1.TabIndex = 33;
            this.lxLedControl1.Text = "0";
            this.lxLedControl1.TextAlignment = LxControl.LxLedControl.Alignment.Right;
            this.lxLedControl1.TotalCharCount = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(807, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 32;
            this.label5.Text = "EPC Number:";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.dataGridView1);
            this.groupBox5.Location = new System.Drawing.Point(100, 85);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(704, 482);
            this.groupBox5.TabIndex = 18;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Tag list(No Repeat)";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(5, 22);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(691, 456);
            this.dataGridView1.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rb_epc);
            this.groupBox2.Controls.Add(this.btIventoryG2);
            this.groupBox2.Location = new System.Drawing.Point(5, 1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(422, 77);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            // 
            // rb_epc
            // 
            this.rb_epc.AutoSize = true;
            this.rb_epc.Checked = true;
            this.rb_epc.Location = new System.Drawing.Point(120, 37);
            this.rb_epc.Name = "rb_epc";
            this.rb_epc.Size = new System.Drawing.Size(46, 17);
            this.rb_epc.TabIndex = 1;
            this.rb_epc.TabStop = true;
            this.rb_epc.Text = "EPC";
            this.rb_epc.UseVisualStyleBackColor = true;
            this.rb_epc.CheckedChanged += new System.EventHandler(this.rb_epc_CheckedChanged);
            // 
            // btIventoryG2
            // 
            this.btIventoryG2.BackColor = System.Drawing.Color.Transparent;
            this.btIventoryG2.Font = new System.Drawing.Font("SimSun", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btIventoryG2.ForeColor = System.Drawing.Color.DarkBlue;
            this.btIventoryG2.Location = new System.Drawing.Point(6, 22);
            this.btIventoryG2.Name = "btIventoryG2";
            this.btIventoryG2.Size = new System.Drawing.Size(109, 43);
            this.btIventoryG2.TabIndex = 0;
            this.btIventoryG2.Text = "Start";
            this.btIventoryG2.UseVisualStyleBackColor = false;
            this.btIventoryG2.Click += new System.EventHandler(this.btIventoryG2_Click);
            // 
            // btFlashCl
            // 
            this.btFlashCl.Location = new System.Drawing.Point(939, 656);
            this.btFlashCl.Name = "btFlashCl";
            this.btFlashCl.Size = new System.Drawing.Size(100, 25);
            this.btFlashCl.TabIndex = 5;
            this.btFlashCl.Text = "Refresh";
            this.btFlashCl.UseVisualStyleBackColor = true;
            this.btFlashCl.Click += new System.EventHandler(this.btFlashCl_Click);
            // 
            // timer_answer
            // 
            this.timer_answer.Interval = 50;
            this.timer_answer.Tick += new System.EventHandler(this.timer_answer_Tick);
            // 
            // timer_runmode
            // 
            this.timer_runmode.Interval = 50;
            this.timer_runmode.Tick += new System.EventHandler(this.timer_runmode_Tick);
            // 
            // timer_EAS
            // 
            this.timer_EAS.Tick += new System.EventHandler(this.timer_EAS_Tick);
            // 
            // Timer_Test_6B
            // 
            this.Timer_Test_6B.Tick += new System.EventHandler(this.Timer_Test_6B_Tick);
            // 
            // timer_Buff
            // 
            this.timer_Buff.Interval = 50;
            this.timer_Buff.Tick += new System.EventHandler(this.timer_Buff_Tick);
            // 
            // timer_RealTime
            // 
            this.timer_RealTime.Interval = 50;
            this.timer_RealTime.Tick += new System.EventHandler(this.timer_RealTime_Tick);
            // 
            // ckClearOperationRec
            // 
            this.ckClearOperationRec.AutoSize = true;
            this.ckClearOperationRec.Checked = true;
            this.ckClearOperationRec.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckClearOperationRec.Location = new System.Drawing.Point(134, 657);
            this.ckClearOperationRec.Name = "ckClearOperationRec";
            this.ckClearOperationRec.Size = new System.Drawing.Size(75, 17);
            this.ckClearOperationRec.TabIndex = 18;
            this.ckClearOperationRec.Text = "Auto-Clear";
            this.ckClearOperationRec.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(841, 657);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(77, 25);
            this.button3.TabIndex = 12;
            this.button3.Text = "run";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1155, 813);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.ckClearOperationRec);
            this.Controls.Add(this.btFlashCl);
            this.Controls.Add(this.Maintab);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lrtxtLog);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UHFReader288 Demo V6.1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Maintab.ResumeLayout(false);
            this.Main_Page1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage_Basic.ResumeLayout(false);
            this.gbReturnLoss.ResumeLayout(false);
            this.gbReturnLoss.PerformLayout();
            this.gbCmdTemperature.ResumeLayout(false);
            this.gbCmdTemperature.PerformLayout();
            this.gbp_DRM.ResumeLayout(false);
            this.gbp_DRM.PerformLayout();
            this.gbp_Retry.ResumeLayout(false);
            this.gbp_wpower.ResumeLayout(false);
            this.gbp_wpower.PerformLayout();
            this.group_maxtime.ResumeLayout(false);
            this.gbp_buff.ResumeLayout(false);
            this.gbp_buff.PerformLayout();
            this.gpb_antconfig.ResumeLayout(false);
            this.gpb_antconfig.PerformLayout();
            this.gpb_checkant.ResumeLayout(false);
            this.gpb_checkant.PerformLayout();
            this.gpb_GPIO.ResumeLayout(false);
            this.gpb_GPIO.PerformLayout();
            this.gpb_OutputRep.ResumeLayout(false);
            this.gpb_OutputRep.PerformLayout();
            this.gpb_Relay.ResumeLayout(false);
            this.gpb_Relay.PerformLayout();
            this.gpb_baud.ResumeLayout(false);
            this.gpb_DBM.ResumeLayout(false);
            this.gpb_DBM.PerformLayout();
            this.gpb_Freq.ResumeLayout(false);
            this.gpb_Freq.PerformLayout();
            this.gpb_beep.ResumeLayout(false);
            this.gpb_beep.PerformLayout();
            this.gpb_RDVersion.ResumeLayout(false);
            this.gpb_RDVersion.PerformLayout();
            this.gpb_MDVersion.ResumeLayout(false);
            this.gpb_MDVersion.PerformLayout();
            this.gpb_Serial.ResumeLayout(false);
            this.gpb_Serial.PerformLayout();
            this.gpb_address.ResumeLayout(false);
            this.gpb_address.PerformLayout();
            this.gpb_rs232.ResumeLayout(false);
            this.gpb_rs232.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage15.ResumeLayout(false);
            this.groupBox62.ResumeLayout(false);
            this.groupBox62.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.groupBox58.ResumeLayout(false);
            this.groupBox58.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox57.ResumeLayout(false);
            this.groupBox57.PerformLayout();
            this.groupBox45.ResumeLayout(false);
            this.gbp_MixRead.ResumeLayout(false);
            this.gbp_MixRead.PerformLayout();
            this.gbp_PowerAnt.ResumeLayout(false);
            this.gbp_PowerAnt.PerformLayout();
            this.Main_Page2.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage_answer.ResumeLayout(false);
            this.chk_phase.ResumeLayout(false);
            this.chk_phase.PerformLayout();
            this.group_ant1.ResumeLayout(false);
            this.group_ant1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lxLedControl6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lxLedControl5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lxLedControl4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lxLedControl3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lxLedControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lxLedControl1)).EndInit();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomControl.LogRichTextBox lrtxtLog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl Maintab;
        private System.Windows.Forms.TabPage Main_Page1;
        private System.Windows.Forms.TabPage Main_Page2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_Basic;
        private System.Windows.Forms.GroupBox gpb_rs232;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rb_rs232;
        private System.Windows.Forms.Button btDisConnect232;
        private System.Windows.Forms.Button btConnect232;
        private System.Windows.Forms.ComboBox ComboBox_baud2;
        private System.Windows.Forms.Label label47;
        internal System.Windows.Forms.ComboBox ComboBox_COM;
        internal System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage_answer;
        private System.Windows.Forms.Button btFlashCl;
        private System.Windows.Forms.Timer timer_answer;
        private System.Windows.Forms.Panel chk_phase;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox com_scantime;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.ComboBox com_S;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.ComboBox com_Q;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rb_epc;
        private System.Windows.Forms.Button btIventoryG2;
        private System.Windows.Forms.GroupBox gpb_address;
        private System.Windows.Forms.TextBox text_address;
        private System.Windows.Forms.Button btaddress;
        private System.Windows.Forms.GroupBox gpb_MDVersion;
        private System.Windows.Forms.TextBox text_MDVersion;
        private System.Windows.Forms.Button btMDVersion;
        private System.Windows.Forms.GroupBox gpb_Serial;
        private System.Windows.Forms.TextBox text_Serial;
        private System.Windows.Forms.Button btSerial;
        private System.Windows.Forms.GroupBox gpb_beep;
        private System.Windows.Forms.GroupBox gpb_RDVersion;
        private System.Windows.Forms.TextBox text_RDVersion;
        private System.Windows.Forms.RadioButton Radio_beepDis;
        private System.Windows.Forms.RadioButton Radio_beepEn;
        private System.Windows.Forms.Button Button_Beep;
        private System.Windows.Forms.GroupBox gpb_Freq;
        private System.Windows.Forms.RadioButton radioButton_band4;
        private System.Windows.Forms.RadioButton radioButton_band3;
        private System.Windows.Forms.RadioButton radioButton_band2;
        private System.Windows.Forms.RadioButton radioButton_band1;
        private System.Windows.Forms.Button btFreq;
        private System.Windows.Forms.ComboBox ComboBox_dmaxfre;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox ComboBox_dminfre;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox CheckBox_SameFre;
        private System.Windows.Forms.GroupBox gpb_DBM;
        private System.Windows.Forms.Button BT_DBM;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox ComboBox_PowerDbm;
        private System.Windows.Forms.GroupBox gpb_baud;
        private System.Windows.Forms.Button btBaudRate;
        private System.Windows.Forms.ComboBox ComboBox_baud;
        private System.Windows.Forms.GroupBox gpb_Relay;
        private System.Windows.Forms.Button btRelay;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.ComboBox ComboBox_RelayTime;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.GroupBox gpb_OutputRep;
        private System.Windows.Forms.Button btOutputRep;
        private System.Windows.Forms.CheckBox check_OutputRep4;
        private System.Windows.Forms.CheckBox check_OutputRep3;
        private System.Windows.Forms.CheckBox check_OutputRep2;
        private System.Windows.Forms.CheckBox check_OutputRep1;
        private System.Windows.Forms.GroupBox gpb_checkant;
        private System.Windows.Forms.Button btSetcheckant;
        private System.Windows.Forms.RadioButton rb_Closecheckant;
        private System.Windows.Forms.RadioButton rb_Opencheckant;
        private System.Windows.Forms.GroupBox gpb_GPIO;
        private System.Windows.Forms.Button Button_GetGPIO;
        private System.Windows.Forms.Button Button_SetGPIO;
        private System.Windows.Forms.CheckBox check_int4;
        private System.Windows.Forms.CheckBox check_int3;
        private System.Windows.Forms.CheckBox check_int2;
        private System.Windows.Forms.CheckBox check_int1;
        private System.Windows.Forms.CheckBox check_out4;
        private System.Windows.Forms.CheckBox check_out3;
        private System.Windows.Forms.CheckBox check_out2;
        private System.Windows.Forms.CheckBox check_out1;
        private System.Windows.Forms.Button btDefault;
        private System.Windows.Forms.Button btFlashROM;
        private System.Windows.Forms.Timer timer_runmode;
        private System.Windows.Forms.Timer timer_EAS;
        private System.Windows.Forms.Timer Timer_Test_6B;
        private System.Windows.Forms.TextBox text_target;
        private System.Windows.Forms.CheckBox check_num;
        private System.Windows.Forms.ComboBox com_Target;
        private System.Windows.Forms.Label label79;
        private System.Windows.Forms.Label label80;
        private System.Windows.Forms.GroupBox gbp_buff;
        private System.Windows.Forms.RadioButton rb496;
        private System.Windows.Forms.RadioButton rb128;
        private System.Windows.Forms.Button btGetEPCandTIDLen;
        private System.Windows.Forms.Button btSetEPCandTIDLen;
        private System.Windows.Forms.Timer timer_Buff;
        private System.Windows.Forms.GroupBox group_maxtime;
        private System.Windows.Forms.Button btSetMaxtime;
        private System.Windows.Forms.ComboBox comboBox_maxtime;
        private System.Windows.Forms.CheckBox checkBox_rate;
        private System.Windows.Forms.Timer timer_RealTime;
        private System.Windows.Forms.RadioButton radioButton_band8;
        private System.Windows.Forms.GroupBox gbp_wpower;
        private System.Windows.Forms.RadioButton rb_wp2;
        private System.Windows.Forms.RadioButton rb_wp1;
        private System.Windows.Forms.Button bt_GetWpower;
        private System.Windows.Forms.Button bt_SetWpower;
        private System.Windows.Forms.Label label112;
        private System.Windows.Forms.ComboBox com_wpower;
        private System.Windows.Forms.GroupBox gbp_Retry;
        private System.Windows.Forms.ComboBox com_retrytimes;
        private System.Windows.Forms.Button bt_Getretry;
        private System.Windows.Forms.Button bt_Setretry;
        private System.Windows.Forms.GroupBox gbp_MixRead;
        private System.Windows.Forms.ComboBox com_MixMem;
        private System.Windows.Forms.Label label114;
        private System.Windows.Forms.TextBox text_readpsd;
        private System.Windows.Forms.Label label118;
        private System.Windows.Forms.TextBox text_readLen;
        private System.Windows.Forms.Label label117;
        private System.Windows.Forms.TextBox text_readadr;
        private System.Windows.Forms.Label label115;
        private System.Windows.Forms.GroupBox gbp_DRM;
        private System.Windows.Forms.RadioButton DRM_CLOSE;
        private System.Windows.Forms.RadioButton DRM_OPEN;
        private System.Windows.Forms.Button bt_GetDRM;
        private System.Windows.Forms.Button bt_setDRM;
        private System.Windows.Forms.GroupBox gbReturnLoss;
        private System.Windows.Forms.Label label120;
        private System.Windows.Forms.Label label121;
        private System.Windows.Forms.ComboBox cmbReturnLossFreq;
        private System.Windows.Forms.Label label122;
        private System.Windows.Forms.TextBox textReturnLoss;
        private System.Windows.Forms.Button btReturnLoss;
        private System.Windows.Forms.GroupBox gbCmdTemperature;
        private System.Windows.Forms.Button btnGetReaderTemperature;
        private System.Windows.Forms.TextBox txtReaderTemperature;
        private System.Windows.Forms.ComboBox cbbAnt;
        private System.Windows.Forms.CheckBox ckClearOperationRec;
        private System.Windows.Forms.RadioButton radioButton_band12;
        private System.Windows.Forms.RadioButton radioButton_band0;
        private System.Windows.Forms.GroupBox group_ant1;
        public System.Windows.Forms.CheckBox check_ant4;
        public System.Windows.Forms.CheckBox check_ant3;
        public System.Windows.Forms.CheckBox check_ant2;
        public System.Windows.Forms.CheckBox check_ant1;
        private LxControl.LxLedControl lxLedControl6;
        private System.Windows.Forms.Label label119;
        private LxControl.LxLedControl lxLedControl5;
        private System.Windows.Forms.Label label9;
        private LxControl.LxLedControl lxLedControl4;
        private System.Windows.Forms.Label label8;
        private LxControl.LxLedControl lxLedControl3;
        private System.Windows.Forms.Label label7;
        private LxControl.LxLedControl lxLedControl2;
        private System.Windows.Forms.Label label6;
        private LxControl.LxLedControl lxLedControl1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabPage tabPage15;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.GroupBox gbp_PowerAnt;
        private System.Windows.Forms.TextBox txtPower4;
        private System.Windows.Forms.Label label186;
        private System.Windows.Forms.TextBox txtPower3;
        private System.Windows.Forms.Label label187;
        private System.Windows.Forms.TextBox txtPower2;
        private System.Windows.Forms.Label label188;
        private System.Windows.Forms.TextBox txtPower1;
        private System.Windows.Forms.Label label189;
        private System.Windows.Forms.Button btGetRfPower;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.Button btSetRfPower;
        private System.Windows.Forms.GroupBox groupBox57;
        private System.Windows.Forms.RadioButton rb_enable;
        private System.Windows.Forms.RadioButton rb_disable;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.GroupBox groupBox58;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.Label label194;
        private System.Windows.Forms.ComboBox com_queryInter;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label label192;
        private System.Windows.Forms.ComboBox cbb_add;
        private System.Windows.Forms.Label label193;
        private System.Windows.Forms.ComboBox cbb_dwell;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.CheckBox check_phase;
        private System.Windows.Forms.GroupBox groupBox62;
        private System.Windows.Forms.Label label202;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.Label label200;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Label label201;
        private System.Windows.Forms.Label label203;
        private System.Windows.Forms.ComboBox comboBox6;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.GroupBox groupBox45;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TabPage tabtest_SQL;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridView dataGridView4;
        private System.Windows.Forms.GroupBox gpb_antconfig;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Button Button_Ant;
        private System.Windows.Forms.CheckBox checkant4;
        private System.Windows.Forms.CheckBox checkant3;
        private System.Windows.Forms.CheckBox checkant2;
        private System.Windows.Forms.CheckBox checkant1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Timer timer1;
    }
}

