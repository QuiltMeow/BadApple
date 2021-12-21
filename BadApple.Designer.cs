namespace BadApple
{
    partial class BadApple
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BadApple));
            this.timerPlay = new System.Windows.Forms.Timer(this.components);
            this.labelASCII = new System.Windows.Forms.Label();
            this.labelInformation = new System.Windows.Forms.Label();
            this.progressFrame = new System.Windows.Forms.ProgressBar();
            this.cmsRightMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiTransparent = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiColor = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiShowStatusBar = new System.Windows.Forms.ToolStripMenuItem();
            this.tssStyle = new System.Windows.Forms.ToolStripSeparator();
            this.txtReplace = new System.Windows.Forms.ToolStripTextBox();
            this.tssSettingSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.tstbTransparentPercent = new ToolStripExtend.ToolStripTrackBar();
            this.tssStatusControl = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiPause = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiReset = new System.Windows.Forms.ToolStripMenuItem();
            this.tssOutput = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiExtract = new System.Windows.Forms.ToolStripMenuItem();
            this.tssOther = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.music = new AxWMPLib.AxWindowsMediaPlayer();
            this.cmsRightMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.music)).BeginInit();
            this.SuspendLayout();
            // 
            // timerPlay
            // 
            this.timerPlay.Interval = 31;
            this.timerPlay.Tick += new System.EventHandler(this.timerPlay_Tick);
            // 
            // labelASCII
            // 
            this.labelASCII.BackColor = System.Drawing.Color.Black;
            this.labelASCII.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelASCII.Font = new System.Drawing.Font("細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelASCII.ForeColor = System.Drawing.Color.White;
            this.labelASCII.Location = new System.Drawing.Point(0, 0);
            this.labelASCII.Name = "labelASCII";
            this.labelASCII.Size = new System.Drawing.Size(1127, 807);
            this.labelASCII.TabIndex = 0;
            this.labelASCII.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelASCII_MouseDown);
            // 
            // labelInformation
            // 
            this.labelInformation.AutoSize = true;
            this.labelInformation.BackColor = System.Drawing.Color.Transparent;
            this.labelInformation.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labelInformation.ForeColor = System.Drawing.Color.GreenYellow;
            this.labelInformation.Location = new System.Drawing.Point(0, 779);
            this.labelInformation.Name = "labelInformation";
            this.labelInformation.Size = new System.Drawing.Size(60, 17);
            this.labelInformation.TabIndex = 1;
            this.labelInformation.Text = "尚未播放";
            // 
            // progressFrame
            // 
            this.progressFrame.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressFrame.Location = new System.Drawing.Point(0, 797);
            this.progressFrame.Name = "progressFrame";
            this.progressFrame.Size = new System.Drawing.Size(1127, 10);
            this.progressFrame.TabIndex = 2;
            // 
            // cmsRightMenu
            // 
            this.cmsRightMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiTransparent,
            this.tsmiColor,
            this.tsmiShowStatusBar,
            this.tssStyle,
            this.txtReplace,
            this.tssSettingSeparator,
            this.tstbTransparentPercent,
            this.tssStatusControl,
            this.tsmiPause,
            this.tsmiReset,
            this.tssOutput,
            this.tsmiExtract,
            this.tssOther,
            this.tsmiExit});
            this.cmsRightMenu.Name = "cmsRightMenu";
            this.cmsRightMenu.Size = new System.Drawing.Size(261, 261);
            // 
            // tsmiTransparent
            // 
            this.tsmiTransparent.Name = "tsmiTransparent";
            this.tsmiTransparent.Size = new System.Drawing.Size(260, 22);
            this.tsmiTransparent.Text = "前景透明";
            this.tsmiTransparent.Click += new System.EventHandler(this.tsmiTransparent_Click);
            // 
            // tsmiColor
            // 
            this.tsmiColor.Name = "tsmiColor";
            this.tsmiColor.Size = new System.Drawing.Size(260, 22);
            this.tsmiColor.Text = "彩色文字";
            this.tsmiColor.Click += new System.EventHandler(this.tsmiColor_Click);
            // 
            // tsmiShowStatusBar
            // 
            this.tsmiShowStatusBar.Checked = true;
            this.tsmiShowStatusBar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiShowStatusBar.Name = "tsmiShowStatusBar";
            this.tsmiShowStatusBar.Size = new System.Drawing.Size(260, 22);
            this.tsmiShowStatusBar.Text = "顯示狀態列";
            this.tsmiShowStatusBar.Click += new System.EventHandler(this.tsmiShowStatusBar_Click);
            // 
            // tssStyle
            // 
            this.tssStyle.Name = "tssStyle";
            this.tssStyle.Size = new System.Drawing.Size(257, 6);
            // 
            // txtReplace
            // 
            this.txtReplace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReplace.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.txtReplace.Name = "txtReplace";
            this.txtReplace.Size = new System.Drawing.Size(100, 23);
            this.txtReplace.TextChanged += new System.EventHandler(this.txtReplace_TextChanged);
            // 
            // tssSettingSeparator
            // 
            this.tssSettingSeparator.Name = "tssSettingSeparator";
            this.tssSettingSeparator.Size = new System.Drawing.Size(257, 6);
            // 
            // tstbTransparentPercent
            // 
            this.tstbTransparentPercent.BackColor = System.Drawing.Color.White;
            this.tstbTransparentPercent.Name = "tstbTransparentPercent";
            this.tstbTransparentPercent.Size = new System.Drawing.Size(200, 45);
            this.tstbTransparentPercent.Text = "透明度";
            // 
            // tssStatusControl
            // 
            this.tssStatusControl.Name = "tssStatusControl";
            this.tssStatusControl.Size = new System.Drawing.Size(257, 6);
            // 
            // tsmiPause
            // 
            this.tsmiPause.Name = "tsmiPause";
            this.tsmiPause.Size = new System.Drawing.Size(260, 22);
            this.tsmiPause.Text = "暫停";
            this.tsmiPause.Click += new System.EventHandler(this.tsmiPause_Click);
            // 
            // tsmiReset
            // 
            this.tsmiReset.Name = "tsmiReset";
            this.tsmiReset.Size = new System.Drawing.Size(260, 22);
            this.tsmiReset.Text = "重播";
            this.tsmiReset.Click += new System.EventHandler(this.tsmiReset_Click);
            // 
            // tssOutput
            // 
            this.tssOutput.Name = "tssOutput";
            this.tssOutput.Size = new System.Drawing.Size(257, 6);
            // 
            // tsmiExtract
            // 
            this.tsmiExtract.Name = "tsmiExtract";
            this.tsmiExtract.Size = new System.Drawing.Size(260, 22);
            this.tsmiExtract.Text = "解壓畫格";
            this.tsmiExtract.Click += new System.EventHandler(this.tsmiExtract_Click);
            // 
            // tssOther
            // 
            this.tssOther.Name = "tssOther";
            this.tssOther.Size = new System.Drawing.Size(257, 6);
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(260, 22);
            this.tsmiExit.Text = "離開";
            this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
            // 
            // music
            // 
            this.music.Enabled = true;
            this.music.Location = new System.Drawing.Point(0, 0);
            this.music.Name = "music";
            this.music.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("music.OcxState")));
            this.music.Size = new System.Drawing.Size(0, 0);
            this.music.TabIndex = 3;
            this.music.Visible = false;
            // 
            // BadApple
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1127, 807);
            this.Controls.Add(this.music);
            this.Controls.Add(this.progressFrame);
            this.Controls.Add(this.labelInformation);
            this.Controls.Add(this.labelASCII);
            this.Font = new System.Drawing.Font("新細明體-ExtB", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.MaximizeBox = false;
            this.Name = "BadApple";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bad Apple";
            this.TransparencyKey = System.Drawing.Color.Pink;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BadApple_FormClosing);
            this.cmsRightMenu.ResumeLayout(false);
            this.cmsRightMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.music)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timerPlay;
        private System.Windows.Forms.Label labelASCII;
        private System.Windows.Forms.Label labelInformation;
        private System.Windows.Forms.ProgressBar progressFrame;
        private System.Windows.Forms.ContextMenuStrip cmsRightMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmiTransparent;
        private System.Windows.Forms.ToolStripMenuItem tsmiColor;
        private System.Windows.Forms.ToolStripSeparator tssStyle;
        private System.Windows.Forms.ToolStripTextBox txtReplace;
        private System.Windows.Forms.ToolStripSeparator tssStatusControl;
        private System.Windows.Forms.ToolStripMenuItem tsmiPause;
        private System.Windows.Forms.ToolStripMenuItem tsmiReset;
        private ToolStripExtend.ToolStripTrackBar tstbTransparentPercent;
        private AxWMPLib.AxWindowsMediaPlayer music;
        private System.Windows.Forms.ToolStripMenuItem tsmiShowStatusBar;
        private System.Windows.Forms.ToolStripMenuItem tsmiExtract;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.ToolStripSeparator tssSettingSeparator;
        private System.Windows.Forms.ToolStripSeparator tssOutput;
        private System.Windows.Forms.ToolStripSeparator tssOther;
    }
}