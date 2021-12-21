using BadApple.Properties;
using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BadApple
{
    public partial class BadApple : Form
    {
        private const int EXIT_SUCCESS = 0, EXIT_FAILURE = 1;
        private const int FRAME_LINE_COUNT = 61, FRAME_TEXT_LENGTH = 9720;
        private const string ORIGIN_TEXT = "W";
        private const string MUSIC_URL = "http://127.0.0.1:3333/";

        private static readonly Random RANDOM = new Random(Guid.NewGuid().GetHashCode());
        private readonly IList<string> renderText;

        private bool intervalChange;
        private int index;
        private string replaceText;

        public BadApple()
        {
            InitializeComponent();

            renderText = new List<string>();
            initResource();
            postInitUI();
            initServer();

            replaceText = ORIGIN_TEXT;
            music.URL = MUSIC_URL;
            play();
        }

        private byte[] musicResponse(HttpListenerRequest request)
        {
            return Resources.Music;
        }

        public static string space(int count)
        {
            return new string(' ', count);
        }

        private void postInitUI()
        {
            // 選單標籤
            ToolStripItemCollection item = cmsRightMenu.Items;
            item.Insert(4, new ToolStripLabel(space(7) + "替換文字"));
            item.Insert(7, new ToolStripLabel(space(26) + "透明度"));

            TrackBar trackBar = tstbTransparentPercent.trackBar;
            trackBar.Minimum = 10;
            trackBar.Maximum = 100;
            trackBar.TickFrequency = 10;
            trackBar.Value = 100;
            trackBar.Scroll += new EventHandler((sender, e) =>
            {
                Opacity = (double)tstbTransparentPercent.trackBar.Value / 100;
            });
            progressFrame.Maximum = renderText.Count;
        }

        private static void exit(int code = EXIT_SUCCESS)
        {
            Environment.Exit(code);
        }

        private void initServer()
        {
            try
            {
                MediaServer server = new MediaServer(MUSIC_URL, musicResponse);
                server.run();
            }
            catch (Exception ex)
            {
                MessageBox.Show("初始化服務端時發生例外狀況 : " + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                exit(EXIT_FAILURE);
            }
        }

        private bool readFrame(StreamReader reader)
        {
            StringBuilder data = new StringBuilder(FRAME_TEXT_LENGTH);
            for (int i = 0; i < FRAME_LINE_COUNT; ++i)
            {
                string line = reader.ReadLine();
                if (line == null)
                {
                    return false;
                }
                data.AppendLine(line);
            }
            renderText.Add(data.ToString());
            return true;
        }

        private void initResource()
        {
            try
            {
                using (MemoryStream ms = new MemoryStream(Resources.Text))
                {
                    using (ZipFile zip = ZipFile.Read(ms))
                    {
                        ZipEntry entry = zip[0];
                        using (MemoryStream extract = new MemoryStream())
                        {
                            entry.Extract(extract);
                            extract.Position = 0;
                            using (StreamReader reader = new StreamReader(extract))
                            {
                                while (readFrame(reader))
                                {
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("載入資源時發生例外狀況 : " + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                exit(EXIT_FAILURE);
            }
        }

        private Color getRandomColor()
        {
            Color ret;
            do
            {
                ret = Color.FromArgb(RANDOM.Next(0, 255), RANDOM.Next(0, 255), RANDOM.Next(0, 255));
            }
            while (ret == TransparencyKey);
            return ret;
        }

        private void timerPlay_Tick(object sender, EventArgs e)
        {
            int progress = index + 1;
            if (progress > progressFrame.Maximum)
            {
                timerPlay.Stop();
                return;
            }
            progressFrame.Value = progress;

            string information = "第 " + progress + " 畫格";
            string playTime = music.Ctlcontrols.currentPositionString;
            if (playTime != string.Empty)
            {
                information += "，播放時間 " + playTime;
            }
            labelInformation.Text = information;

            if (tsmiColor.Checked)
            {
                labelASCII.ForeColor = getRandomColor();
            }
            labelASCII.Text = renderText[index++].Replace(ORIGIN_TEXT, replaceText);

            // 同步算法 (大約估計值)
            if (progress % 134 == 100 || progress % 134 == 0) // 34 : 100
            {
                intervalChange = !intervalChange;
            }
            timerPlay.Interval = intervalChange ? 32 : 31;
        }

        private void tsmiTransparent_Click(object sender, EventArgs e)
        {
            tsmiTransparent.Checked = !tsmiTransparent.Checked;
            if (tsmiTransparent.Checked)
            {
                BackColor = labelASCII.BackColor = TransparencyKey;
                FormBorderStyle = FormBorderStyle.None;
            }
            else
            {
                BackColor = labelASCII.BackColor = Color.Black;
                FormBorderStyle = FormBorderStyle.FixedSingle;
            }
            updateStatusBar();
        }

        private void tsmiColor_Click(object sender, EventArgs e)
        {
            tsmiColor.Checked = !tsmiColor.Checked;
        }

        private void play()
        {
            music.Ctlcontrols.play();
            timerPlay.Start();
        }

        private void tsmiPause_Click(object sender, EventArgs e)
        {
            tsmiPause.Checked = !tsmiPause.Checked;
            if (tsmiPause.Checked)
            {
                music.Ctlcontrols.pause();
                timerPlay.Stop();
            }
            else
            {
                play();
            }
        }

        private void txtReplace_TextChanged(object sender, EventArgs e)
        {
            if (Encoding.UTF8.GetBytes(txtReplace.Text).Length > 1)
            {
                txtReplace.Text = string.Empty;
            }
            replaceText = txtReplace.Text == string.Empty ? ORIGIN_TEXT : txtReplace.Text;
        }

        private void BadApple_FormClosing(object sender, FormClosingEventArgs e)
        {
            exit();
        }

        private async void tsmiExtract_Click(object sender, EventArgs e)
        {
            const string output = "Extract.txt";
            tsmiExit.Enabled = false;
            try
            {
                await Task.Run(() =>
                {
                    using (MemoryStream ms = new MemoryStream(Resources.Text))
                    {
                        using (ZipFile zip = ZipFile.Read(ms))
                        {
                            ZipEntry entry = zip[0];
                            using (MemoryStream extract = new MemoryStream())
                            {
                                entry.Extract(extract);
                                using (FileStream fs = new FileStream(output, FileMode.Create, FileAccess.Write))
                                {
                                    extract.WriteTo(fs);
                                }
                                new Thread(() => MessageBox.Show("導出完畢，檔案名稱 : " + output, "資訊", MessageBoxButtons.OK, MessageBoxIcon.Information)).Start();
                            }
                        }
                    }
                });
            }
            catch (Exception ex)
            {
                new Thread(() => MessageBox.Show("導出檔案時發生例外狀況 : " + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error)).Start();
            }
            tsmiExit.Enabled = true;
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            exit();
        }

        private void tsmiReset_Click(object sender, EventArgs e)
        {
            music.Ctlcontrols.stop();
            timerPlay.Stop();

            labelASCII.Text = string.Empty;
            labelInformation.Text = "尚未播放";
            progressFrame.Value = 0;

            timerPlay.Interval = 31;
            intervalChange = false;
            index = 0;

            if (!tsmiPause.Checked)
            {
                play();
            }
        }

        private void updateStatusBar()
        {
            if (tsmiTransparent.Checked)
            {
                labelInformation.Visible = progressFrame.Visible = false;
                Size = new Size(1127, 780); // 無狀態列 & 無標題列時視窗大小
            }
            else
            {
                labelInformation.Visible = progressFrame.Visible = tsmiShowStatusBar.Checked;
                Size = tsmiShowStatusBar.Checked ? new Size(1143, 846) : new Size(1143, 819); // 狀態列開關時視窗大小
            }
        }

        private void tsmiShowStatusBar_Click(object sender, EventArgs e)
        {
            tsmiShowStatusBar.Checked = !tsmiShowStatusBar.Checked;
            updateStatusBar();
        }

        private void labelASCII_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    {
                        ReleaseCapture();
                        SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                        break;
                    }
                case MouseButtons.Right:
                    {
                        cmsRightMenu.Show(labelASCII, new Point(e.X, e.Y));
                        break;
                    }
            }
        }

        #region P / Invoke

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        #endregion P / Invoke
    }
}