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
    public partial class MainForm : Form
    {
        private int portNo = 16332;
        public const int MainServerCapacity = 10000, SubServerCapacity = 5000;
        public List<int> requestsMain;
        public StreamWriter streamWriter;
        public StreamReader streamReader;
        public const float percentage = .7f;

        internal List<SubServer> SubServers { get; set; } = new List<SubServer>();

        private delegate void SafeCallDelegate(ProgressBar progressBar, int value);
        private delegate void SafeCallDelegateText(Label label, string text);

        public MainForm()
        {
            InitializeComponent();

            Thread threadServer = new Thread(RunMainServer);
            threadServer.Start();
        }

        private void WritePBValueSafe(ProgressBar progressBar, int value)
        {
            if (progressBar.InvokeRequired)
            {
                var d = new SafeCallDelegate(WritePBValueSafe);
                progressBar.Invoke(d, new object[] { progressBar, value });
            }
            else
            {
                if (progressBar.Maximum != 0)
                    progressBar.Value = value;
            }
        }

        private void WriteTextSafe(Label label, string text)
        {
            if (label.InvokeRequired)
            {
                var d = new SafeCallDelegateText(WriteTextSafe);
                label.Invoke(d, new object[] { label, text });
            }
            else
            {
                label.Text = text;
            }
        }

        public void PrintLine()
        {
            for (int i = 0; i < 25; i++)
                Console.Write("-");

            Console.WriteLine();
        }

        public void RunMainServer()
        {
            List<Thread> threads = new List<Thread>(10000);
            requestsMain = new List<int>(10000);
            TcpListener tcpListener = new TcpListener(IPAddress.Any, portNo);
            tcpListener.Start();
            Random random = new Random();

            PrintLine();
            Console.WriteLine("Server running...");

            Socket socket = tcpListener.AcceptSocket();

            if (!socket.Connected)
            {
                Console.WriteLine("Server can not start!!!");
            }
            else
            {
                Console.WriteLine("Client connected...");
                PrintLine();

                NetworkStream networkStream = new NetworkStream(socket);
                streamWriter = new StreamWriter(networkStream);
                streamReader = new StreamReader(networkStream);

                #region Main Server

                var startTimeSpan = TimeSpan.Zero;
                var periodTimeSpan = TimeSpan.FromSeconds(.5);
                var startTimeSpan2 = TimeSpan.Zero;
                var periodTimeSpan2 = TimeSpan.FromSeconds(.2);

                var timer = new System.Threading.Timer((e) =>
                {
                    int rnd = random.Next(100);

                    WriteTextSafe(lblMTAlinanIstekSayisi, "Main Threadin aldığı istek sayısı = " + rnd.ToString());

                    for (int i = 0; i < rnd; i++)
                    {
                        if (requestsMain.Count < MainServerCapacity)
                        {
                            requestsMain.Add(GetRequest(streamReader));
                            //requests.Add(GetRequest2(socket));

                            //WritePBValueSafe(pBMainServer, requestsMain?.Count ?? 0);
                            //WriteTextSafe(lblMainserverPrc, requestsMain?.Count.ToString() + " / " + MainServerCapacity ?? "0");
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
                        if (requestsMain.Count > 0)
                        {
                            try
                            {
                                SendResponse(streamWriter, requestsMain[requestsMain.Count - 1]);
                                //SendResponse2(socket, requests[requests.Count - 1]);

                                requestsMain.RemoveAt(requestsMain.Count - 1);

                                //WritePBValueSafe(pBMainServer, requestsMain?.Count ?? 0);
                                //WriteTextSafe(lblMainserverPrc, requestsMain?.Count.ToString() + " / " + MainServerCapacity ?? "0");
                            }
                            catch (Exception)
                            {
                            }
                        }
                        else
                            break;
                    }
                }, null, startTimeSpan2, periodTimeSpan2);

                #endregion Main Server

                Thread subThreadCreatorThread = new Thread(SubThreadCreator);
                subThreadCreatorThread.Priority = ThreadPriority.AboveNormal;
                subThreadCreatorThread.Start();

                Thread serverSpotterThread = new Thread(RunServerSpotter);
                serverSpotterThread.Priority = ThreadPriority.AboveNormal;
                serverSpotterThread.Start();

                SubServers.Add(new SubServer(this));
                SubServers.Add(new SubServer(this));
                SubServers[0].subServerThread.Start();
                SubServers[1].subServerThread.Start();
            }

            while (true)
            {
            }
            socket.Close();
        }

        #region Getter Sender

        private int GetRequest(object streamReaderObj)
        {
            StreamReader streamReader = (StreamReader)streamReaderObj;

            string istemciMesaji;
            try
            {
                istemciMesaji = streamReader.ReadLine();
            }
            catch (Exception)
            {
                istemciMesaji = "0";
            }

            Console.WriteLine(DateTime.Now + "  Gelen Mesaj : " + istemciMesaji);

            try
            {
                return Convert.ToInt32(istemciMesaji);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public void SendResponse(object streamWriterObj, int response)
        {
            StreamWriter streamWriter = (StreamWriter)streamWriterObj;

            String sunucuMesaji = (response + 2).ToString();
            Console.WriteLine(DateTime.Now + "  Giden Mesaj : " + sunucuMesaji);

            streamWriter.WriteLine(sunucuMesaji);
            streamWriter.Flush();
        }

        #endregion Getter Sender

        public void RunServerSpotter()
        {
            while (true)
            {
                WritePBValueSafe(pBMainServer, requestsMain.Count);
                WriteTextSafe(lblMainserverPrc, requestsMain.Count.ToString() + " / " + MainServerCapacity);

                for (int i = 0; i < SubServers.Count; i++)
                {
                    SubServer subServer = SubServers[i];

                    WritePBValueSafe(subServer.subProgressBar, subServer.requestsSub.Count);
                    WriteTextSafe(subServer.subLabel2, subServer.requestsSub.Count.ToString() + " / " + SubServerCapacity);
                }
            }
        }

        public void SubThreadCreator()
        {
            int subServerCapacity70 = Convert.ToInt32(SubServerCapacity * percentage);

            while (true)
            {
                for (int i = 0; i < SubServers.Count; i++)
                {
                    SubServer subServer = SubServers[i];

                    if (subServer.requestsSub.Count > subServerCapacity70)
                    {
                        SubServer subServerNew = new SubServer(this);
                        SubServers.Add(subServerNew);
                        int half = subServer.requestsSub.Count / 2;

                        for (int j = 0; j < half; j++)
                        {
                            if (subServer.requestsSub.Count > 0 && subServerNew.requestsSub.Count < 5000)
                            {
                                try
                                {
                                    subServerNew.requestsSub.Add(subServer.requestsSub.ElementAt(subServer.requestsSub.Count - 1));
                                    subServer.requestsSub.RemoveAt(subServer.requestsSub.Count - 1);
                                }
                                catch (Exception)
                                {
                                }
                            }
                            else
                                break;
                        }

                        subServerNew.subServerThread.Start();
                    }
                    else if (subServer.requestsSub.Count < 1 && SubServers.Count > 2)
                    {
                        subServer.subServerThread.Abort();

                        BeginInvoke((MethodInvoker)delegate
                        {
                            subServer.panel.Controls.Clear();
                            flowLayoutPanelSubServers.Controls.Remove(subServer.panel);
                        });

                        SubServers.RemoveAt(i);
                    }
                }
            }
        }
    }
}