using System;
using System.Windows.Forms;

namespace KuWoMusic2019
{
    partial class frmMain
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.pnlControlBar = new System.Windows.Forms.Panel();
            this.lblDisplayTime = new System.Windows.Forms.Label();
            this.picVoide = new System.Windows.Forms.PictureBox();
            this.picRandom = new System.Windows.Forms.PictureBox();
            this.picAfterPlay = new System.Windows.Forms.PictureBox();
            this.picPlay = new System.Windows.Forms.PictureBox();
            this.picBeforePlay = new System.Windows.Forms.PictureBox();
            this.picSongName = new System.Windows.Forms.PictureBox();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.axWindowsMediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.timCurrentLine = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.picNarrow = new System.Windows.Forms.PictureBox();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.listSongName = new System.Windows.Forms.ListBox();
            this.picImage = new System.Windows.Forms.PictureBox();
            this.pnlSound = new System.Windows.Forms.Panel();
            this.pnlControlBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picVoide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRandom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAfterPlay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBeforePlay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSongName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNarrow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlControlBar
            // 
            this.pnlControlBar.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlControlBar.Controls.Add(this.pnlSound);
            this.pnlControlBar.Controls.Add(this.picImage);
            this.pnlControlBar.Controls.Add(this.lblDisplayTime);
            this.pnlControlBar.Controls.Add(this.picVoide);
            this.pnlControlBar.Controls.Add(this.picRandom);
            this.pnlControlBar.Controls.Add(this.picAfterPlay);
            this.pnlControlBar.Controls.Add(this.picPlay);
            this.pnlControlBar.Controls.Add(this.picBeforePlay);
            this.pnlControlBar.Controls.Add(this.picSongName);
            this.pnlControlBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlControlBar.Location = new System.Drawing.Point(0, 633);
            this.pnlControlBar.Name = "pnlControlBar";
            this.pnlControlBar.Size = new System.Drawing.Size(1510, 98);
            this.pnlControlBar.TabIndex = 0;
            this.pnlControlBar.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlControlBar_Paint);
            this.pnlControlBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlControlBar_MouseDown);
            this.pnlControlBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlControlBar_MouseMove);
            this.pnlControlBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlControlBar_MouseUp);
            // 
            // lblDisplayTime
            // 
            this.lblDisplayTime.AutoSize = true;
            this.lblDisplayTime.Font = new System.Drawing.Font("宋体", 12F);
            this.lblDisplayTime.Location = new System.Drawing.Point(1085, 49);
            this.lblDisplayTime.Name = "lblDisplayTime";
            this.lblDisplayTime.Size = new System.Drawing.Size(59, 20);
            this.lblDisplayTime.TabIndex = 1;
            this.lblDisplayTime.Text = "00:00";
            // 
            // picVoide
            // 
            this.picVoide.BackColor = System.Drawing.Color.Transparent;
            this.picVoide.BackgroundImage = global::KuWoMusic2019.Properties.Resources.sound;
            this.picVoide.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picVoide.Location = new System.Drawing.Point(1299, 26);
            this.picVoide.Name = "picVoide";
            this.picVoide.Size = new System.Drawing.Size(53, 57);
            this.picVoide.TabIndex = 0;
            this.picVoide.TabStop = false;
            this.picVoide.Click += new System.EventHandler(this.picVoide_Click);
            // 
            // picRandom
            // 
            this.picRandom.BackColor = System.Drawing.Color.Transparent;
            this.picRandom.BackgroundImage = global::KuWoMusic2019.Properties.Resources.retweet;
            this.picRandom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picRandom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picRandom.Location = new System.Drawing.Point(1221, 25);
            this.picRandom.Name = "picRandom";
            this.picRandom.Size = new System.Drawing.Size(53, 57);
            this.picRandom.TabIndex = 0;
            this.picRandom.TabStop = false;
            this.picRandom.Click += new System.EventHandler(this.picRandom_Click);
            // 
            // picAfterPlay
            // 
            this.picAfterPlay.BackColor = System.Drawing.Color.Transparent;
            this.picAfterPlay.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picAfterPlay.BackgroundImage")));
            this.picAfterPlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picAfterPlay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picAfterPlay.Location = new System.Drawing.Point(247, 26);
            this.picAfterPlay.Name = "picAfterPlay";
            this.picAfterPlay.Size = new System.Drawing.Size(53, 57);
            this.picAfterPlay.TabIndex = 0;
            this.picAfterPlay.TabStop = false;
            this.picAfterPlay.Click += new System.EventHandler(this.picAfterPlay_Click);
            // 
            // picPlay
            // 
            this.picPlay.BackColor = System.Drawing.Color.Transparent;
            this.picPlay.BackgroundImage = global::KuWoMusic2019.Properties.Resources.play_circle_o;
            this.picPlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picPlay.Location = new System.Drawing.Point(152, 21);
            this.picPlay.Name = "picPlay";
            this.picPlay.Size = new System.Drawing.Size(65, 67);
            this.picPlay.TabIndex = 0;
            this.picPlay.TabStop = false;
            this.picPlay.Click += new System.EventHandler(this.picPlay_Click);
            // 
            // picBeforePlay
            // 
            this.picBeforePlay.BackColor = System.Drawing.Color.Transparent;
            this.picBeforePlay.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picBeforePlay.BackgroundImage")));
            this.picBeforePlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picBeforePlay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picBeforePlay.Location = new System.Drawing.Point(69, 25);
            this.picBeforePlay.Name = "picBeforePlay";
            this.picBeforePlay.Size = new System.Drawing.Size(53, 57);
            this.picBeforePlay.TabIndex = 0;
            this.picBeforePlay.TabStop = false;
            this.picBeforePlay.Click += new System.EventHandler(this.picBeforePlay_Click);
            // 
            // picSongName
            // 
            this.picSongName.BackColor = System.Drawing.Color.Transparent;
            this.picSongName.BackgroundImage = global::KuWoMusic2019.Properties.Resources.radioRight_h;
            this.picSongName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picSongName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picSongName.Location = new System.Drawing.Point(-19, 22);
            this.picSongName.Name = "picSongName";
            this.picSongName.Size = new System.Drawing.Size(61, 61);
            this.picSongName.TabIndex = 0;
            this.picSongName.TabStop = false;
            this.picSongName.Click += new System.EventHandler(this.picSongName_Click);
            this.picSongName.MouseEnter += new System.EventHandler(this.picSongName_MouseEnter);
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(-19, -19);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(75, 23);
            this.axWindowsMediaPlayer1.TabIndex = 1;
            // 
            // axWindowsMediaPlayer
            // 
            this.axWindowsMediaPlayer.Enabled = true;
            this.axWindowsMediaPlayer.Location = new System.Drawing.Point(1080, 130);
            this.axWindowsMediaPlayer.Name = "axWindowsMediaPlayer";
            this.axWindowsMediaPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer.OcxState")));
            this.axWindowsMediaPlayer.Size = new System.Drawing.Size(159, 99);
            this.axWindowsMediaPlayer.TabIndex = 2;
            this.axWindowsMediaPlayer.Visible = false;
            // 
            // timCurrentLine
            // 
            this.timCurrentLine.Tick += new System.EventHandler(this.timCurrentLine_Tick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // picNarrow
            // 
            this.picNarrow.BackColor = System.Drawing.Color.LightSteelBlue;
            this.picNarrow.BackgroundImage = global::KuWoMusic2019.Properties.Resources.minus;
            this.picNarrow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picNarrow.Location = new System.Drawing.Point(1401, 12);
            this.picNarrow.Name = "picNarrow";
            this.picNarrow.Size = new System.Drawing.Size(39, 37);
            this.picNarrow.TabIndex = 3;
            this.picNarrow.TabStop = false;
            this.picNarrow.Click += new System.EventHandler(this.picNarrow_Click);
            this.picNarrow.MouseEnter += new System.EventHandler(this.picNarrow_MouseEnter);
            this.picNarrow.MouseLeave += new System.EventHandler(this.picNarrow_MouseLeave);
            // 
            // picClose
            // 
            this.picClose.BackColor = System.Drawing.Color.LightSteelBlue;
            this.picClose.BackgroundImage = global::KuWoMusic2019.Properties.Resources.close;
            this.picClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picClose.Location = new System.Drawing.Point(1459, 12);
            this.picClose.Name = "picClose";
            this.picClose.Size = new System.Drawing.Size(39, 37);
            this.picClose.TabIndex = 3;
            this.picClose.TabStop = false;
            this.picClose.Click += new System.EventHandler(this.picClose_Click);
            this.picClose.MouseEnter += new System.EventHandler(this.picClose_MouseEnter);
            this.picClose.MouseLeave += new System.EventHandler(this.picClose_MouseLeave);
            // 
            // listSongName
            // 
            this.listSongName.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.listSongName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listSongName.Font = new System.Drawing.Font("宋体", 15F);
            this.listSongName.FormattingEnabled = true;
            this.listSongName.ItemHeight = 50;
            this.listSongName.Location = new System.Drawing.Point(0, -1);
            this.listSongName.Name = "listSongName";
            this.listSongName.ScrollAlwaysVisible = true;
            this.listSongName.Size = new System.Drawing.Size(281, 654);
            this.listSongName.TabIndex = 4;
            this.listSongName.Visible = false;
            this.listSongName.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listSongName_DrawItem);
            // 
            // picImage
            // 
            this.picImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picImage.Location = new System.Drawing.Point(323, 22);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(68, 68);
            this.picImage.TabIndex = 2;
            this.picImage.TabStop = false;
            // 
            // pnlSound
            // 
            this.pnlSound.BackColor = System.Drawing.Color.Transparent;
            this.pnlSound.Location = new System.Drawing.Point(1358, 39);
            this.pnlSound.Name = "pnlSound";
            this.pnlSound.Size = new System.Drawing.Size(139, 29);
            this.pnlSound.TabIndex = 3;
            this.pnlSound.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlSound_Paint);
            this.pnlSound.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlSound_MouseDown);
            this.pnlSound.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlSound_MouseMove);
            this.pnlSound.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlSound_MouseUp);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1510, 731);
            this.Controls.Add(this.listSongName);
            this.Controls.Add(this.picNarrow);
            this.Controls.Add(this.picClose);
            this.Controls.Add(this.axWindowsMediaPlayer);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Controls.Add(this.pnlControlBar);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMain";
            this.Text = "酷我音乐盒";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmMain_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmMain_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmMain_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.frmMain_MouseUp);
            this.pnlControlBar.ResumeLayout(false);
            this.pnlControlBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picVoide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRandom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAfterPlay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBeforePlay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSongName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNarrow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlControlBar;
        private System.Windows.Forms.PictureBox picAfterPlay;
        private System.Windows.Forms.PictureBox picSongName;
        private System.Windows.Forms.PictureBox picVoide;
        private System.Windows.Forms.PictureBox picRandom;
        private System.Windows.Forms.PictureBox picPlay;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer;
        private System.Windows.Forms.Label lblDisplayTime;
        private System.Windows.Forms.Timer timCurrentLine;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.PictureBox picClose;
        private System.Windows.Forms.PictureBox picNarrow;
        private System.Windows.Forms.PictureBox picBeforePlay;
        private System.Windows.Forms.ListBox listSongName;
        private PictureBox picImage;
        private Panel pnlSound;
    }
}

