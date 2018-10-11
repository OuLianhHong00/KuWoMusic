using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// 编写者：欧连红
/// 功能：歌词文件类
/// </summary>
namespace KuWoMusic2019
{
    //歌词文件
    class LyricFiles {
        public List<Lyric> listLyric = new List<Lyric>();
        
        public void LoadLyricFromFile(string fileName) {
            //从文件载入歌词
            Encoding encoder = Encoding.GetEncoding("GB2312");//解码
            FileStream fs = new FileStream(fileName, FileMode.Open);
            StreamReader sr = new StreamReader(fs, encoder);
            string strLyric;
            while ((strLyric = sr.ReadLine())!=null)
            {
                if (strLyric == "")
                {
                    continue;
                }
                Lyric lyric = new Lyric();
                lyric.minute = int.Parse(strLyric.Substring(1, 2));
                lyric.second = float.Parse(strLyric.Substring(4, 5));
                lyric.strLyric = strLyric.Substring(10);
                lyric.totSecond = lyric.minute * 60 + lyric.second;
                listLyric.Add(lyric);
            }
            sr.Close();
            fs.Close();
        }


    }
    //一行歌词
    class Lyric
    {
       public int minute;
       public float second;
        public float totSecond;//总秒
       public string strLyric;//歌词
    }
}
