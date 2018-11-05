using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KuWoMusic2019
{
    /// <summary>
    /// 编写者：欧连红
    /// 功能：仿酷我音乐盒
    /// </summary>
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        //歌曲文件名集合
        List<String> songName = new List<string>();
        //歌词文件类
        LyricFiles lyricFiles = new LyricFiles();
        //显示歌词的label链表
        //List<Label> lstLabel = new List<Label>();
        //歌词集合
        List<string> lyrics = new List<string>();
        int currentSong = 0;//当前所放歌曲
        int random = 1, singleplay = 1, sweet = 0;//标志播放类型
        //trackBar_Scroll
        private void FrmMain_Load(object sender, EventArgs e)
        {
            timCurrentLine.Enabled = true;
            //控制条变透明
            pnlControlBar.BackColor = Color.FromArgb(127,200,200,200);
            //加载歌曲到songName链表中
            songName.Add("陈一发儿-童话镇");
            songName.Add("大壮-我们不一样");
            songName.Add("金南玲-逆流成河");
            songName.Add("薛之谦-演员");
            songName.Add("音阙诗听-红昭愿");
            //加载歌词到lyrics链表中(歌曲名和内容要排序一致) 
            DirectoryInfo strLyricFile = new DirectoryInfo("lyric");
            for (int i = 0; i < songName.Count; i++)
            {
                string name = songName[i];
                listSongName.Items.Add(name);
                foreach (FileInfo lyric in strLyricFile.GetFiles("*.lrc"))
                {
                    if (name == lyric.Name.Substring(0, lyric.Name.Length - 4))
                    {
                        lyrics.Add("lyric\\" + lyric.Name);
                        Console.WriteLine(lyric.Name);
                        break;
                    }
                }
            }
            //加载第一首歌曲
            loadSong();
           // writeLabel();
            axWindowsMediaPlayer.Ctlcontrols.stop();
           
        }

        //加载歌曲、歌词、背景图片
        Image img;
        public void loadSong() {
            //加载歌曲
            axWindowsMediaPlayer.URL = @"song\" + songName[currentSong] + ".mp3";
            isplay = true;
            //加载歌词
            lyricFiles.listLyric.Clear();
            lyricFiles.LoadLyricFromFile(lyrics[currentSong]);
            //加载图片
            img = Image.FromFile(@"img\" + songName[currentSong] + ".jpg");
            this.BackgroundImage = img;
            picImage.BackgroundImage = img;
        }
        //绘制歌词
        Graphics g;
        private void frmMain_Paint(object sender, PaintEventArgs e)
        {
             g = e.Graphics;
            int yStep = 30;
            int x = (int)(this.Width * 0.35);
            int y = 100;
            for(int i = 0; i < 11; i++)
            {
                Point p = new Point(x, y);
                int line = i - 6 + curLyricLine;
                if (line >= 0 && line < lyricFiles.listLyric.Count)
                {
                    if (i == 5)
                    {
                        g.DrawString(lyricFiles.listLyric[line].strLyric, new Font("Segoe Print", 16), new LinearGradientBrush(new Rectangle(x, y, 300, 30), Color.BlueViolet, Color.BlueViolet, LinearGradientMode.Horizontal), p);
                    }
                    else if (i == 3 || i==4||i == 6||i==7)
                    {
                        g.DrawString(lyricFiles.listLyric[line].strLyric, new Font("Segoe Print", 13), new SolidBrush(Color.White), p);
                    }
                    else if (i == 2 || i == 8)
                    {
                        g.DrawString(lyricFiles.listLyric[line].strLyric, new Font("Segoe Print", 13), new SolidBrush(Color.FromArgb(200, 255, 255, 255)), p);
                    }
                    else if (i == 1 || i == 9)
                    {
                        g.DrawString(lyricFiles.listLyric[line].strLyric, new Font("Segoe Print", 13), new SolidBrush(Color.FromArgb(80, 255, 255, 255)), p);

                    }
                    else if (i == 0 || i == 10)
                    {
                        g.DrawString(lyricFiles.listLyric[line].strLyric, new Font("Segoe Print", 13), new SolidBrush(Color.FromArgb(20, 255, 255, 255)), p);
                    }
                }
                y += yStep;
            }
        }
        //绘制显示歌词的label
        /* public void writeLabel() {
             int yStep = 200;
             //绘制歌词的label
             for (int i = 0; i < lyricFiles.listLyric.Count; i++)
             {
                 Label lblLyric = new Label();
                 lblLyric.Size = new Size(400, 30);
                 lblLyric.BackColor = Color.Transparent;
                 lblLyric.ForeColor = Color.White;
                 lblLyric.Font = new Font("微软雅黑", 14);
                 lblLyric.Text = lyricFiles.listLyric[i].strLyric;
                 lblLyric.Location = new Point(300, yStep);
                 yStep += 30;
                 Console.WriteLine(lblLyric.Text);
                 this.Controls.Add(lblLyric);
                 lstLabel.Add(lblLyric);
             }
         }
         */
        bool isplay;
        //暂停播放
        private void picPlay_Click(object sender, EventArgs e)
        {
            //isplay = !isplay;
            if(isplay)
            {
                timCurrentLine.Enabled = true;
                axWindowsMediaPlayer.Ctlcontrols.play();
                picPlay.BackgroundImage = Properties.Resources.pause_circle_o;
                isplay = false;
            } else
            {
                timCurrentLine.Enabled = false;
                axWindowsMediaPlayer.Ctlcontrols.pause();
                picPlay.BackgroundImage = Properties.Resources.play_circle_o;
                isplay = true;  

            }
        }
       
        //滚动条
       /* private void trbProcess_Scroll(object sender, EventArgs e)
        {
            axWindowsMediaPlayer.Ctlcontrols.currentPosition = trbProcess.Value * (int)axWindowsMediaPlayer.currentMedia.duration / trbProcess.Maximum;
        }
        */
        
        int curLyricLine = 0;//当前行
        double setRectX = 0;//播放记录百分比
        //当前行的timer
        private void timCurrentLine_Tick(object sender, EventArgs e)
        {
            lblDisplayTime.Text = axWindowsMediaPlayer.Ctlcontrols.currentPositionString + "/" + axWindowsMediaPlayer.currentMedia.durationString;
            if (axWindowsMediaPlayer.Ctlcontrols.currentPosition != 0)
                setRectX = axWindowsMediaPlayer.Ctlcontrols.currentPosition / axWindowsMediaPlayer.currentMedia.duration;
            pnlControlBar.Invalidate();//刷新进度条
            //判断播放器状态,看是哪种播放形式
            if (axWindowsMediaPlayer.playState == WMPLib.WMPPlayState.wmppsStopped)
            {
                if (singleplay==0)
                {
                    Console.WriteLine("单曲");
                    Console.WriteLine(currentSong);
                    loadSong();
                    axWindowsMediaPlayer.Ctlcontrols.play();
                }
                else if (sweet==0)
                {
                    currentSong++;
                    loadSong();
                    axWindowsMediaPlayer.Ctlcontrols.play();
                    Console.WriteLine("顺序");
                    Console.WriteLine(currentSong);
                }
                else {
                    Random num = new Random();
                    currentSong = num.Next(0, songName.Count);
                    loadSong();
                    axWindowsMediaPlayer.Ctlcontrols.play();
                    Console.WriteLine("随机");
                    Console.WriteLine(currentSong);
                }
                loadSong();
                axWindowsMediaPlayer.Ctlcontrols.play();
            }
                //当前所唱歌词颜色大小变化
              double pos = axWindowsMediaPlayer.Ctlcontrols.currentPosition;//当前位置
              /*  if (lyricFiles.listLyric.Count > 0 && pos >= lyricFiles.listLyric[curLyricLine].totSecond)
                {
                    for (int j = 0; j < lstLabel.Count; j++)
                    {
                        if (j == curLyricLine)
                        {
                            lstLabel[curLyricLine].ForeColor = Color.Yellow;
                            lstLabel[curLyricLine].Font = new Font("微软雅黑", 18);
                        }
                        else
                        {
                            lstLabel[j].ForeColor = Color.White;
                            lstLabel[j].Font = new Font("微软雅黑", 14);
                        }
                            //歌词在指定时间段内向上滚动
                            lstLabel[j].Location = new Point(lstLabel[j].Location.X, lstLabel[j].Location.Y - 25);
                        
                    }*/
             for(int i=0;i<lyricFiles.listLyric.Count;i++)
             {
                if (pos <= lyricFiles.listLyric[i].totSecond)
                {
                    curLyricLine = i;
                    //scrollLine();
                    break;
                }
                else if (curLyricLine == lyricFiles.listLyric.Count-2  && pos > lyricFiles.listLyric.Last().totSecond) {
                    curLyricLine = lyricFiles.listLyric.Count-1;
                   // scrollLine();
                }
             }
            this.Refresh();      
        }
      /*  //滚动条根据歌词滚动
        public void scrollLine() {
            float currentSecond = lyricFiles.listLyric[curLyricLine].totSecond;
            int count = lyricFiles.listLyric.Count;
            float allSecond = lyricFiles.listLyric[count - 1].totSecond;
            if (allSecond == 0)
            {
                trbProcess.Value = 0;
            }
            else
            {
                if (currentSong != allSecond)
                {
                    trbProcess.Value = Convert.ToInt32((10 / allSecond) * currentSecond);
                }
                else
                {
                    trbProcess.Value = 10;
                }
            }
        }*/
        //上一首
        private void picBeforePlay_Click(object sender, EventArgs e)
        {
            if (currentSong == 0)
            {
                MessageBox.Show("前面没有其他歌曲了！！！");
            }
            else {
                currentSong--;
                loadSong();
                axWindowsMediaPlayer.Ctlcontrols.play();
                picPlay.BackgroundImage = Properties.Resources.pause_circle_o;
                // writeLabel();
            }
        }
        //下一首
        private void picAfterPlay_Click(object sender, EventArgs e)
        {
            if (currentSong == songName.Count)
            {
                MessageBox.Show("后面没有其他歌曲了！！！");
            }
            else
            {
                currentSong++;
                loadSong();
                axWindowsMediaPlayer.Ctlcontrols.play();
                picPlay.BackgroundImage = Properties.Resources.pause_circle_o;
                //  writeLabel();
            }
        }
        //随机播放与循环播放与单曲循环
        bool isSingleCycle;//是否循环播放
        bool isRandom;//是否随机播放
        private void picRandom_Click(object sender, EventArgs e)
        {
            if (isSingleCycle)
            {
                picRandom.BackgroundImage = Properties.Resources.singleplay;
                isSingleCycle = false;
                isRandom = true;
                singleplay = 0;
                sweet = 1;
                random = 1;
                MessageBox.Show("已经切换到单曲循环");
            }
            else {
                if (isRandom)
                {
                    picRandom.BackgroundImage = Properties.Resources.retweet;
                    isRandom = false;
                    MessageBox.Show("已切换到循环播放播放");
                    sweet = 0;
                    singleplay = 1;
                    random = 1;
                }
                else {
                    picRandom.BackgroundImage = Properties.Resources.suiji;
                    isSingleCycle = true;
                    MessageBox.Show("已经切换到随机播放");
                    random = 0;
                    singleplay = 1;
                    sweet = 1;
                }
                
            }
           // writeLabel();
        }
        //是否为静音
        bool isMute;
        private void picVoide_Click(object sender, EventArgs e)
        {
            if (isMute)
            {
                axWindowsMediaPlayer.settings.mute = true;
                picVoide.BackgroundImage = Properties.Resources.Mute;
                isMute = false;
            }
            else {
                axWindowsMediaPlayer.settings.mute = false;
                picVoide.BackgroundImage = Properties.Resources.sound;
                isMute = true;
            }

        }
        //解决Label闪屏
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
       
        //关闭、缩小
        private void picClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void picClose_MouseEnter(object sender, EventArgs e)
        {
            picClose.BackColor = Color.Red;
        }
       
        private void picClose_MouseLeave(object sender, EventArgs e)
        {
            picClose.BackColor = Color.LightSteelBlue;
        }
        private void picNarrow_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void picNarrow_MouseEnter(object sender, EventArgs e)
        {
            picNarrow.BackColor= Color.FromArgb(30, 255, 255, 255);
        }

        private void picNarrow_MouseLeave(object sender, EventArgs e)
        {
            picNarrow.BackColor = Color.LightSteelBlue;
        }
        //出现listbox的列表
        int flag = 0;//表示列表未出现
        private void picSongName_MouseEnter(object sender, EventArgs e)
        {
            ToolTip p = new ToolTip();
            p.ShowAlways = true;
            p.SetToolTip(this.picSongName, "点击出歌词列表详情");
        }
        private void picSongName_Click(object sender, EventArgs e)
        {
            if (flag == 0)
            {
                listSongName.Visible = true;
                picSongName.BackgroundImage = Properties.Resources.radioLeft_h;
                flag = 1;
            }
            else
            {
                listSongName.Visible = false;
                picSongName.BackgroundImage = Properties.Resources.radioRight_h;
                flag = 0;
            }
        }
        private void listSongName_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawFocusRectangle();
            StringFormat strFmt = new System.Drawing.StringFormat();
            strFmt.Alignment = StringAlignment.Center; //文本垂直居中
            strFmt.LineAlignment = StringAlignment.Center; //文本水平居中
            if (e.Index == currentSong)
            {
                e.Graphics.DrawString(listSongName.Items[e.Index].ToString(), e.Font, new SolidBrush(Color.Red), e.Bounds, strFmt);
            }
            else
            {
                e.Graphics.DrawString(listSongName.Items[e.Index].ToString(), e.Font, new SolidBrush(Color.Black), e.Bounds, strFmt);
            }
        }
        //实现窗体拖动
        bool isDrag = false;
        Point clickPoint;
        private void frmMain_MouseDown(object sender, MouseEventArgs e)
        {
            isDrag = true;
            clickPoint = new Point(e.X, e.Y);
        }

        private void frmMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrag) {
                int offsetX = e.X - clickPoint.X;
                int offsetY = e.Y - clickPoint.Y;
                this.Location = new Point(this.Location.X + offsetX, this.Location.Y + offsetY);
            }
        }

        private void frmMain_MouseUp(object sender, MouseEventArgs e)
        {
            isDrag = false;
        }
        //绘制进度条
        Rectangle backRect;//进度条背景
        Rectangle foreRect;//进度
        Rectangle setRect;//滑块
        private void pnlControlBar_Paint(object sender, PaintEventArgs e)
      {
            //绘制进度条背景
            backRect = new Rectangle(300,45,500,4);
            e.Graphics.FillRectangle(Brushes.LightGray, backRect);
            e.Graphics.DrawRectangle(Pens.LightGray,backRect);
            //进度
            foreRect = new Rectangle(300,45,(int)(setRectX*500),4);
            e.Graphics.FillRectangle(Brushes.IndianRed,foreRect);
            e.Graphics.DrawRectangle(Pens.IndianRed,foreRect);
            //滑块
            setRect = new Rectangle((int)(setRectX*500)+300,43,8,8);
            e.Graphics.FillRectangle(Brushes.White,setRect);
            e.Graphics.DrawRectangle(Pens.LightGray,setRect);
        }
        //拖动进度条
        Point originPoint;//记录鼠标点下的坐标
        Point originSetRectPoint;//记录点下时滑块的坐标
        bool setRectDown = false;//是否拖动滑块
        bool backRectDown = false;//是否点击进度条
        private void pnlControlBar_MouseDown(object sender, MouseEventArgs e)
        {
            //拖动滑块
            if (setRect.Contains(e.Location))
            {
                originPoint = e.Location;//鼠标点下的坐标
                originSetRectPoint = setRect.Location;
                setRectDown = true;
            }
            //直接点击进度条
            else if(backRect.Contains(e.Location)){
                backRectDown = true;
            }
        }
        private void pnlControlBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (setRectDown) {
                int d = e.Location.X - originPoint.X;
                //拖动后进度的百分比
                double percent = (double)(originSetRectPoint.X + d - backRect.X) / (backRect.Width - backRect.Height);
                if (percent < 0)
                {
                    axWindowsMediaPlayer.Ctlcontrols.currentPosition = 0;
                    setRect.X = 300;
                    foreRect.Width = 0;
                }
                else if (percent > 1)
                {
                    axWindowsMediaPlayer.Ctlcontrols.currentPosition = percent * axWindowsMediaPlayer.currentMedia.duration;
                    setRect.X = 800;
                    foreRect.Width = 500;
                }
                else {
                    axWindowsMediaPlayer.Ctlcontrols.currentPosition = percent * axWindowsMediaPlayer.currentMedia.duration;
                    foreRect.Width = (int)(percent * backRect.Width);
                    setRect.X = originSetRectPoint.X + d;
                }
            }
        }

        private void pnlControlBar_MouseUp(object sender, MouseEventArgs e)
        {
            setRectDown = false;
            if (backRectDown) {
                int d = e.X - 300;
                double percent = (double)d / 500;
                axWindowsMediaPlayer.Ctlcontrols.currentPosition = percent * axWindowsMediaPlayer.currentMedia.duration;
                foreRect.Width = (int)(percent * backRect.Width);
                setRect.X = originSetRectPoint.X + d;
            }
            backRectDown = false;
        }
        //音乐进度条
        Rectangle backMRect;
        Rectangle foreMRect;
        Rectangle setMRect;
        private void pnlSound_Paint(object sender, PaintEventArgs e)
        {
            backMRect = new Rectangle(0,10,100,4);
            e.Graphics.FillRectangle(Brushes.LightGray,backMRect);
            e.Graphics.DrawRectangle(Pens.LightGray,backMRect);
            if (!isMute)
            {
                foreMRect = new Rectangle(0,10,axWindowsMediaPlayer.settings.volume*100/100,4);
                e.Graphics.FillRectangle(Brushes.IndianRed,foreMRect);
                e.Graphics.DrawRectangle(Pens.IndianRed,foreMRect);

                setMRect = new Rectangle(axWindowsMediaPlayer.settings.volume * 100 / 100,8,8,8);
                e.Graphics.FillRectangle(Brushes.White,setMRect);
                e.Graphics.DrawRectangle(Pens.LightGray,setMRect);
            }

        }
        Point clickMPoint;//鼠标在音量上点击的位置
        Point originSetMRectPoint;//点击时音量滑块的坐标
        bool isDragSetRect = false;//拖动滑块
        bool isClickSoundRect = false;//点击音量条
        private void pnlSound_MouseDown(object sender, MouseEventArgs e)
        {
            //点在滑块上
            if (setMRect.Contains(e.Location))
            {
                clickMPoint = e.Location;
                originSetMRectPoint = setMRect.Location;
                isDragSetRect = true;
            }
            //点在音量条上
            else if (backMRect.Contains(e.Location)) {
                isClickSoundRect = true;
            }
            
        }

        private void pnlSound_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragSetRect) {
                int d = e.X - clickMPoint.X;
                double percent = (double)(originSetMRectPoint.X + d - setMRect.X) / (setMRect.Width - setMRect.Height);
                if (percent < 0)
                {
                    axWindowsMediaPlayer.settings.volume = 0;
                    setMRect.X = 0;
                    foreMRect.Width = 0;
                }
                else if (percent > 1)
                {
                    axWindowsMediaPlayer.settings.volume = 100;
                    setMRect.X = 100;
                    foreMRect.Width = 100;
                }
                else {
                    axWindowsMediaPlayer.settings.volume = (int)(percent * 100);
                    foreMRect.Width = (int)(percent * backMRect.Width);
                    setMRect.X = originSetMRectPoint.X + d;
                }
                pnlSound.Invalidate();
            }
        }

        private void pnlSound_MouseUp(object sender, MouseEventArgs e)
        {
            isDragSetRect = false;
            if (isClickSoundRect) {
                double vol = (double)(e.X * 100 / 100);
                axWindowsMediaPlayer.settings.volume = (int)vol;
                foreRect.Width = e.X;
                setMRect.X = e.X;
                pnlSound.Invalidate();

            }
            isClickSoundRect = false;
        }



    }
}
