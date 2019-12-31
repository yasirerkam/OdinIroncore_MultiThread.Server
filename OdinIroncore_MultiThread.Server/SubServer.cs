using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YazLabP2_Server
{
    internal class SubServer
    {
        public List<int> requestsSub = new List<int>(5000);
        public Panel panel;
        public Thread subServerThread;
        private MainForm mainForm;
        public ProgressBar subProgressBar;
        public Label subLabel2;

        public SubServer(MainForm mainForm)
        {
            this.mainForm = mainForm;

            panel = CreatePanel(mainForm);
            subServerThread = new Thread(RunSubServer);
        }

        public void RunSubServer()
        {
            List<int> requestsMain = mainForm.requestsMain;
            Random random = new Random();
            var startTimeSpan = TimeSpan.Zero;
            var periodTimeSpan = TimeSpan.FromSeconds(.5);
            var startTimeSpan2 = TimeSpan.Zero;
            var periodTimeSpan2 = TimeSpan.FromSeconds(.3);

            var timer = new System.Threading.Timer((e) =>
            {
                int rnd = random.Next(50);

                for (int i = 0; i < rnd; i++)
                {
                    if (requestsMain.Count > 0 && requestsSub.Count < MainForm.SubServerCapacity)
                    {
                        try
                        {
                            requestsSub.Add(requestsMain.ElementAt(requestsMain.Count - 1));
                            requestsMain.RemoveAt(requestsMain.Count - 1);
                        }
                        catch (Exception)
                        {
                        }
                    }
                    else
                        break;
                }
            }, null, startTimeSpan, periodTimeSpan);

            var timer2 = new System.Threading.Timer((e) =>
            {
                int rnd = random.Next(50);

                for (int i = 0; i < rnd; i++)
                {
                    if (requestsSub.Count > 0)
                    {
                        mainForm.SendResponse(mainForm.streamWriter, requestsSub[requestsSub.Count - 1]);
                        //SendResponse2(socket, requests[requests.Count - 1]);
                        requestsSub.RemoveAt(requestsSub.Count - 1);
                    }
                    else
                        break;
                }
            }, null, startTimeSpan2, periodTimeSpan2);

            while (true)
            {
            }
        }

        public Panel CreatePanel(Form mainForm)
        {
            Panel panel = new Panel();
            Label subLabel = new Label();
            subProgressBar = new ProgressBar();
            subLabel2 = new Label();

            mainForm.BeginInvoke((MethodInvoker)delegate
            {
                panel.Size = new Size(400, 40);
                panel.Location = new Point(12, 126);
                //panel.BorderStyle = BorderStyle.FixedSingle;

                panel.Controls.Add(subLabel);
                panel.Controls.Add(subProgressBar);
                panel.Controls.Add(subLabel2);

                subLabel.Parent = panel;
                subProgressBar.Parent = panel;
                subLabel2.Parent = panel;

                subLabel.Text = "Sub Server " + this.GetHashCode();
                subLabel.Size = new Size(120, 13);
                subLabel.Location = new Point(5, 12);

                subProgressBar.Maximum = MainForm.SubServerCapacity;
                subProgressBar.Size = new Size(170, 23);
                subProgressBar.Location = new Point(128, 8);

                subLabel2.Text = "Sub Server";
                //subLabel2.Size = new Size(13, 25);
                subLabel2.Location = new Point(304, 12);

                mainForm.Controls.Add(panel);

                panel.Controls.SetChildIndex(subLabel, 0);
                panel.Controls.SetChildIndex(subProgressBar, 1);
                panel.Controls.SetChildIndex(subLabel2, 2);

                ((FlowLayoutPanel)mainForm.Controls["flowLayoutPanelSubServers"]).Controls.Add(panel);
                mainForm.Show();
            });

            return panel;
        }
    }
}