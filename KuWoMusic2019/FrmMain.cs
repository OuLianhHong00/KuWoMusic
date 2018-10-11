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
        }
        //绘制歌词
       
        private void frmMain_Paint(object sender, PaintEventArgs e)
        {
            Graphics  g = e.Graphics;
            double position = axWindowsMediaPlayer.Ctlcontrols.currentPosition;
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
        private void trbProcess_Scroll(object sender, EventArgs e)
        {
            axWindowsMediaPlayer.Ctlcontrols.currentPosition = trbProcess.Value * (int)axWindowsMediaPlayer.currentMedia.duration / trbProcess.Maximum;
        }
        
        
        int curLyricLine = 0;//当前行
        //当前行的timer
        private void timCurrentLine_Tick(object sender, EventArgs e)
        {
            lblDisplayTime.Text = axWindowsMediaPlayer.Ctlcontrols.currentPositionString + "/" + axWindowsMediaPlayer.currentMedia.durationString;
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
                    scrollLine();
                    break;
                }
                else if (curLyricLine == lyricFiles.listLyric.Count-2  && pos > lyricFiles.listLyric.Last().totSecond) {
                    curLyricLine = lyricFiles.listLyric.Count-1;
                    scrollLine();
                }
             }
            this.Refresh();      
        }
        //滚动条根据歌词滚动
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
        }
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

        
    }
}
