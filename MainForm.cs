using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace CryptoFinder
{
    /// <summary>
    /// Summary description for MainForm.
    /// </summary>
    public class MainForm : System.Windows.Forms.Form
    {
        private ZinoLib.Windows.Controls.DriveComboBox _cbDrives;
        private System.Windows.Forms.Button RestoreWalletFilesButton;
        private Label SelectedDrive;
        private CheckBox deletedFilesCB;
        private CheckBox existingFilesCB;
        private FolderBrowserDialog restoreFolderDialog;
        private Button recoveredFolderButton;
        private Label SelectCryptoCurrencies;
        private CheckBox ArmoryCB;
        private CheckBox BitcoinQTCB;
        private CheckBox CopayCB;
        private CheckBox ElectrumCB;
        private CheckBox MultibitHDCB;
        private CheckBox MultibitCB;
        private IContainer components;
        private CheckBox mSIGNACB;
        private CheckBox BitherCB;
        private long MaxFileSize = 524288;
        public bool DeletedFiles { get; set; }
        public string RestoreFolder { get; set; }
        public string RestoreFolderDrive { get; set; }
        public string RestoreFolderTemp
        {
            get { return RestoreFolder + @"RestoredTemp\"; }
        }

        public MainForm()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this._cbDrives = new ZinoLib.Windows.Controls.DriveComboBox();
            this.RestoreWalletFilesButton = new System.Windows.Forms.Button();
            this.SelectedDrive = new System.Windows.Forms.Label();
            this.deletedFilesCB = new System.Windows.Forms.CheckBox();
            this.existingFilesCB = new System.Windows.Forms.CheckBox();
            this.restoreFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.recoveredFolderButton = new System.Windows.Forms.Button();
            this.SelectCryptoCurrencies = new System.Windows.Forms.Label();
            this.ElectrumCB = new System.Windows.Forms.CheckBox();
            this.MultibitHDCB = new System.Windows.Forms.CheckBox();
            this.MultibitCB = new System.Windows.Forms.CheckBox();
            this.CopayCB = new System.Windows.Forms.CheckBox();
            this.BitcoinQTCB = new System.Windows.Forms.CheckBox();
            this.ArmoryCB = new System.Windows.Forms.CheckBox();
            this.mSIGNACB = new System.Windows.Forms.CheckBox();
            this.BitherCB = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // _cbDrives
            // 
            this._cbDrives.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this._cbDrives.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cbDrives.Location = new System.Drawing.Point(13, 35);
            this._cbDrives.Name = "_cbDrives";
            this._cbDrives.Size = new System.Drawing.Size(512, 27);
            this._cbDrives.TabIndex = 0;
            // 
            // RestoreWalletFilesButton
            // 
            this.RestoreWalletFilesButton.Location = new System.Drawing.Point(954, 383);
            this.RestoreWalletFilesButton.Name = "RestoreWalletFilesButton";
            this.RestoreWalletFilesButton.Size = new System.Drawing.Size(200, 69);
            this.RestoreWalletFilesButton.TabIndex = 1;
            this.RestoreWalletFilesButton.Text = "Restore wallet files";
            this.RestoreWalletFilesButton.Click += new System.EventHandler(this.RestoreWalletFilesButton_Click);
            // 
            // SelectedDrive
            // 
            this.SelectedDrive.AutoSize = true;
            this.SelectedDrive.Location = new System.Drawing.Point(9, 9);
            this.SelectedDrive.Name = "SelectedDrive";
            this.SelectedDrive.Size = new System.Drawing.Size(147, 20);
            this.SelectedDrive.TabIndex = 2;
            this.SelectedDrive.Text = "Select drive to scan";
            // 
            // deletedFilesCB
            // 
            this.deletedFilesCB.AutoSize = true;
            this.deletedFilesCB.Location = new System.Drawing.Point(628, 398);
            this.deletedFilesCB.Name = "deletedFilesCB";
            this.deletedFilesCB.Size = new System.Drawing.Size(191, 24);
            this.deletedFilesCB.TabIndex = 3;
            this.deletedFilesCB.Text = "Search in deleted files";
            this.deletedFilesCB.UseVisualStyleBackColor = true;
            // 
            // existingFilesCB
            // 
            this.existingFilesCB.AutoSize = true;
            this.existingFilesCB.Location = new System.Drawing.Point(628, 428);
            this.existingFilesCB.Name = "existingFilesCB";
            this.existingFilesCB.Size = new System.Drawing.Size(191, 24);
            this.existingFilesCB.TabIndex = 4;
            this.existingFilesCB.Text = "Search in existing files";
            this.existingFilesCB.UseVisualStyleBackColor = true;
            // 
            // recoveredFolderButton
            // 
            this.recoveredFolderButton.Location = new System.Drawing.Point(13, 141);
            this.recoveredFolderButton.Name = "recoveredFolderButton";
            this.recoveredFolderButton.Size = new System.Drawing.Size(356, 69);
            this.recoveredFolderButton.TabIndex = 6;
            this.recoveredFolderButton.Text = "Select folder to copy recovered files to";
            this.recoveredFolderButton.UseVisualStyleBackColor = true;
            this.recoveredFolderButton.Click += new System.EventHandler(this.recoveredFolderButton_Click);
            // 
            // SelectCryptoCurrencies
            // 
            this.SelectCryptoCurrencies.AutoSize = true;
            this.SelectCryptoCurrencies.Location = new System.Drawing.Point(624, 35);
            this.SelectCryptoCurrencies.Name = "SelectCryptoCurrencies";
            this.SelectCryptoCurrencies.Size = new System.Drawing.Size(344, 20);
            this.SelectCryptoCurrencies.TabIndex = 8;
            this.SelectCryptoCurrencies.Text = "Select which wallets would you like to search for";
            // 
            // ElectrumCB
            // 
            this.ElectrumCB.AutoSize = true;
            this.ElectrumCB.Checked = true;
            this.ElectrumCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ElectrumCB.Location = new System.Drawing.Point(628, 200);
            this.ElectrumCB.Name = "ElectrumCB";
            this.ElectrumCB.Size = new System.Drawing.Size(98, 24);
            this.ElectrumCB.TabIndex = 10;
            this.ElectrumCB.Text = "Electrum";
            this.ElectrumCB.UseVisualStyleBackColor = true;
            // 
            // MultibitHDCB
            // 
            this.MultibitHDCB.AutoSize = true;
            this.MultibitHDCB.Checked = true;
            this.MultibitHDCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MultibitHDCB.Location = new System.Drawing.Point(628, 260);
            this.MultibitHDCB.Name = "MultibitHDCB";
            this.MultibitHDCB.Size = new System.Drawing.Size(109, 24);
            this.MultibitHDCB.TabIndex = 11;
            this.MultibitHDCB.Text = "MultibitHD";
            this.MultibitHDCB.UseVisualStyleBackColor = true;
            // 
            // MultibitCB
            // 
            this.MultibitCB.AutoSize = true;
            this.MultibitCB.Checked = true;
            this.MultibitCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MultibitCB.Location = new System.Drawing.Point(628, 290);
            this.MultibitCB.Name = "MultibitCB";
            this.MultibitCB.Size = new System.Drawing.Size(85, 24);
            this.MultibitCB.TabIndex = 12;
            this.MultibitCB.Text = "Multibit";
            this.MultibitCB.UseVisualStyleBackColor = true;
            // 
            // CopayCB
            // 
            this.CopayCB.AutoSize = true;
            this.CopayCB.Checked = true;
            this.CopayCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CopayCB.Location = new System.Drawing.Point(628, 170);
            this.CopayCB.Name = "CopayCB";
            this.CopayCB.Size = new System.Drawing.Size(80, 24);
            this.CopayCB.TabIndex = 13;
            this.CopayCB.Text = "Copay";
            this.CopayCB.UseVisualStyleBackColor = true;
            // 
            // BitcoinQTCB
            // 
            this.BitcoinQTCB.AutoSize = true;
            this.BitcoinQTCB.Checked = true;
            this.BitcoinQTCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.BitcoinQTCB.Location = new System.Drawing.Point(628, 110);
            this.BitcoinQTCB.Name = "BitcoinQTCB";
            this.BitcoinQTCB.Size = new System.Drawing.Size(104, 24);
            this.BitcoinQTCB.TabIndex = 14;
            this.BitcoinQTCB.Text = "BitcoinQT";
            this.BitcoinQTCB.UseVisualStyleBackColor = true;
            // 
            // ArmoryCB
            // 
            this.ArmoryCB.AutoSize = true;
            this.ArmoryCB.Checked = true;
            this.ArmoryCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ArmoryCB.Location = new System.Drawing.Point(628, 76);
            this.ArmoryCB.Name = "ArmoryCB";
            this.ArmoryCB.Size = new System.Drawing.Size(85, 24);
            this.ArmoryCB.TabIndex = 15;
            this.ArmoryCB.Text = "Armory";
            this.ArmoryCB.UseVisualStyleBackColor = true;
            // 
            // mSIGNACB
            // 
            this.mSIGNACB.AutoSize = true;
            this.mSIGNACB.Checked = true;
            this.mSIGNACB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mSIGNACB.Location = new System.Drawing.Point(628, 230);
            this.mSIGNACB.Name = "mSIGNACB";
            this.mSIGNACB.Size = new System.Drawing.Size(99, 24);
            this.mSIGNACB.TabIndex = 16;
            this.mSIGNACB.Text = "mSIGNA";
            this.mSIGNACB.UseVisualStyleBackColor = true;
            // 
            // BitherCB
            // 
            this.BitherCB.AutoSize = true;
            this.BitherCB.Checked = true;
            this.BitherCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.BitherCB.Location = new System.Drawing.Point(628, 140);
            this.BitherCB.Name = "BitherCB";
            this.BitherCB.Size = new System.Drawing.Size(77, 24);
            this.BitherCB.TabIndex = 17;
            this.BitherCB.Text = "Bither";
            this.BitherCB.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 19);
            this.ClientSize = new System.Drawing.Size(1156, 455);
            this.Controls.Add(this.BitherCB);
            this.Controls.Add(this.mSIGNACB);
            this.Controls.Add(this.ArmoryCB);
            this.Controls.Add(this.BitcoinQTCB);
            this.Controls.Add(this.CopayCB);
            this.Controls.Add(this.MultibitCB);
            this.Controls.Add(this.MultibitHDCB);
            this.Controls.Add(this.ElectrumCB);
            this.Controls.Add(this.SelectCryptoCurrencies);
            this.Controls.Add(this.recoveredFolderButton);
            this.Controls.Add(this.existingFilesCB);
            this.Controls.Add(this.deletedFilesCB);
            this.Controls.Add(this.SelectedDrive);
            this.Controls.Add(this.RestoreWalletFilesButton);
            this.Controls.Add(this._cbDrives);
            this.Name = "MainForm";
            this.Text = "Crypto Restore 1.0";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        private void RestoreWalletFilesButton_Click(object sender, System.EventArgs e)
        {
            DeletedFiles = deletedFilesCB.Checked;
            IDCryptoFiles _idCryptoFiles;
            _idCryptoFiles = new IDCryptoFiles();
            _idCryptoFiles.Armory = ArmoryCB.Checked;
            _idCryptoFiles.BitcoinQT = BitcoinQTCB.Checked;
            _idCryptoFiles.Bither = BitherCB.Checked;
            _idCryptoFiles.Copay = CopayCB.Checked;
            _idCryptoFiles.DeletedFiles = DeletedFiles;
            //_idCryptoFiles.DeepScan = deepScanCB.Checked;
            _idCryptoFiles.Electrum = ElectrumCB.Checked;
            _idCryptoFiles.mSIGNA = mSIGNACB.Checked;
            _idCryptoFiles.Multibit = MultibitCB.Checked;
            _idCryptoFiles.MultibitHD = MultibitHDCB.Checked;
            _idCryptoFiles.MaxFileSize = MaxFileSize;
            _idCryptoFiles.RestoreFolder = RestoreFolder;
            //RestoreFolder = @"C:\Restore\";
            if (RestoreFolder == null)
            {
                MessageBox.Show("Please select the folder to copy recovered files to.");
            }
            if (_cbDrives.SelectedIndex != -1 && RestoreFolder != null)
                if (IsDirectoryEmpty(RestoreFolder) == false)
                {
                    MessageBox.Show("Please select an empty directory to restore to");
                }
                else
                {
                    if ((RestoreFolderDrive == _cbDrives.SelectedDrive) && DeletedFiles == true)
                    {
                        MessageBox.Show("Please select a different path to restore to, such as a USB drive or another partition. If you restore to the same partition, you risk overwritting deleted files.");
                    }
                    else
                    {
                        if (DeletedFiles == false && existingFilesCB.Checked == false)
                        {
                            MessageBox.Show("Please select at least one recovery mode");
                        }
                        else
                        {
                            MessageBox.Show("Now we'll start recovering wallet files. This process might take a few minutes and the program might appear unresponsive in the meantime. Please hold...");
                            if (DeletedFiles == true)
                            {
                                KickassUndelete.ConsoleCommands.RestoreFiles(_cbDrives.SelectedDrive, RestoreFolderTemp);
                                _idCryptoFiles.WalletFilesLister(RestoreFolderTemp);
                            }
                            if (existingFilesCB.Checked == true)
                            {
                                _idCryptoFiles.DeletedFiles = false;
                                _idCryptoFiles.WalletFilesLister(_cbDrives.SelectedDrive);
                            }
                        }
                    }
                }
        }

        private void recoveredFolderButton_Click(object sender, EventArgs e)
        {
            DialogResult result = restoreFolderDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                RestoreFolder = restoreFolderDialog.SelectedPath;
                if (RestoreFolder.EndsWith(@"\") == false)
                {
                    RestoreFolder = restoreFolderDialog.SelectedPath + @"\";
                }
                RestoreFolderDrive = Path.GetPathRoot(RestoreFolder);
                recoveredFolderButton.Text = RestoreFolder;
            }
        }
        public bool IsDirectoryEmpty(string path)
        {
            string[] dirs = System.IO.Directory.GetDirectories(path); string[] files = System.IO.Directory.GetFiles(path);
            return dirs.Length == 0 && files.Length == 0;
        }
    }
}
