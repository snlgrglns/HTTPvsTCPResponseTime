using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfApplication.Pages
{
    /// <summary>
    /// Interaction logic for MessageTimer.xaml
    /// </summary>
    public partial class MessageTimer : UserControl
    {
         Thread th1, th2;
        static string ipval;
        static string postData;
        static string loop_no;
        static string portval;
        static string webUrl;
        public MessageTimer()
        {
            InitializeComponent();
        }

        private void webBtn_Click(object sender, RoutedEventArgs e)
        {
            SetValue();
            th1 = new Thread(() => RunWeb(webUrl, postData, loop_no));
            th1.Start();
        }
        private void serviceBtn_Click(object sender, RoutedEventArgs e)
        {
            SetValue();
            th2 = new Thread(() => RunTcp(ipval, postData, loop_no, portval));
            th2.Start();
        }

        public void RunTcp(string ipval, string postData, string loop_no, string portval)
        {
            //            String ipval = ipVal.Text;
            //            String portval = portNo.Text;
            //                        String input = "018B30313030767B464128E1B20A313635343337313230303030303030313037303130303030303030303030303031353030303030303030303035363538303232333133333333383733373732303030303030303031313333333338303232333032323330323233363031313035313030303034303630313233343533373534333731323030303030303031303744313730343232313332313431393233343135313230383530303031303030303131323334353637383132333435363738393132333435364D656D6265722046696E616E6369616C20496E73746920426F73746F6E2020202020202020204D413030375A3830303254563834";
            //            String input = message.Text;
            string input = postData;
            if (ipval == "")
            {
                MessageBox.Show("Enter IP Address");
            }
            else if (portval == "")
            {
                MessageBox.Show("Enter Port No.");
            }
            else
            {
                List<TimeSpan> list = new List<TimeSpan>();

                //                string loop_no = loopNo.Text;
                if (loop_no != "" & input != "")
                {
                    int loop_to_int = Convert.ToInt32(loop_no);
                    int port = Convert.ToInt32(portval);

                    using (TcpClient server = new TcpClient(ipval, port))
                    {
                        try
                        {

                            //Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                            NetworkStream stream = server.GetStream();
                            //if (!server.Connected)
                            //{
                            //    IPEndPoint ip = new IPEndPoint(IPAddress.Parse(ipval), Convert.ToInt32(portval));
                            //    server.Connect(ip);
                            //}

                            Stopwatch per_send = new Stopwatch();
                            byte[] msg = GetBytes(input);
                            int length = msg.Length;
                            for (int j = 1; j <= loop_to_int; j++)
                            {
                                per_send.Start();
                                stream.Write(msg, 0, length);
                                byte[] data = new byte[length];
                                int receivedDataLength = stream.Read(data, 0, length);
                                string stringData = BitConverter.ToString(data);//Encoding.ASCII.GetString(data, 0, receivedDataLength);
                                Debug.WriteLine(stringData);

                                per_send.Stop();
                                list.Add(per_send.Elapsed);
                                per_send.Reset();
                            }

                            TimeSpan totalSpan = new TimeSpan(list.Sum(r => r.Ticks));
                            TimeSpan avg = new TimeSpan(totalSpan.Ticks / loop_to_int);



                            new Thread((ThreadStart)delegate
                            {
                                //then dispatch back to the UI thread to update the progress bar
                                Dispatcher.Invoke((ThreadStart)delegate
                                    {
                                        serviceTotal.Text = totalSpan.ToString();
                                        serviceMin.Text = list.Min<TimeSpan>().ToString();
                                        serviceMax.Text = list.Max<TimeSpan>().ToString();
                                        serviceAvg.Text = avg.ToString();
                                    });

                            }).Start();
                        }
                        catch (SocketException ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }
                }
            }
        }

        public void RunWeb(string webUrl, string postData, string loop_no)
        {
            //            String webUrl = urlVal.Text;
            //            String postData = message.Text;

            if (webUrl == "")
            {
                MessageBox.Show("Enter Url");
            }
            else
            {
                List<TimeSpan> list = new List<TimeSpan>();
                //                string loop_no = loopNo.Text;
                if (loop_no != "" & postData != "")
                {
                    try
                    {
                        byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                        int loop_to_int = Convert.ToInt32(loop_no);
                        //                    Stopwatch clock = new Stopwatch();
                        Stopwatch per_send = new Stopwatch();
                        //                    clock.Start();
                        for (int i = 1; i <= loop_to_int; i++)
                        {
                            per_send.Start();
                            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://" + webUrl);
                            request.Method = "POST";
                            // Set the ContentType property of the WebRequest.
                            request.ContentType = "application/x-www-form-urlencoded";
                            // Set the ContentLength property of the WebRequest.
                            request.ContentLength = byteArray.Length;

                            // Get the request stream.
                            Stream dataStream = request.GetRequestStream();
                            // Write the data to the request stream.
                            dataStream.Write(byteArray, 0, byteArray.Length);
                            // Close the Stream object.
                            dataStream.Close();

                            // Get the response.
                            var response = request.GetResponse() as HttpWebResponse;
                            // Display the status.
                            dataStream = response.GetResponseStream();
                            // Open the stream using a StreamReader for easy access.
                            StreamReader reader = new StreamReader(dataStream);
                            // Read the content.
                            string responseFromServer = reader.ReadToEnd();
                            // Display the content.
                            Debug.WriteLine(responseFromServer);
                            per_send.Stop();
                            list.Add(per_send.Elapsed);
                            per_send.Reset();
                        }
                        //                    clock.Stop();
                        TimeSpan totalSpan = new TimeSpan(list.Sum(r => r.Ticks));
                        TimeSpan avg = new TimeSpan(totalSpan.Ticks / loop_to_int);
                        new Thread((ThreadStart)delegate
                        {
                            //then dispatch back to the UI thread to update the progress bar
                            Dispatcher.Invoke((ThreadStart)delegate
                            {
                                webTotal.Text = totalSpan.ToString();
                                webMin.Text = list.Min<TimeSpan>().ToString();
                                webMax.Text = list.Max<TimeSpan>().ToString();
                                webAvg.Text = avg.ToString();
                            });

                        }).Start();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
        }

        public void show(TextBlock tB)
        {
            DispatcherTimer timer = new DispatcherTimer()
            {
                Interval = TimeSpan.FromSeconds(5)
            };

            timer.Tick += delegate (object sender, EventArgs e)
            {
                ((DispatcherTimer)timer).Stop();
                tB.Visibility = Visibility.Hidden;
            };
            timer.Start();
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void IpValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"^(?<ip>(?:\[[\da-fA-F:]+\])|(?:\d{1,3}\.){3}\d{1,3})(?::(?<port>\d+))?$", System.Text.RegularExpressions.RegexOptions.Compiled);
            e.Handled = regex.IsMatch(e.Text);
        }

        private void UrlValidationTextBox(object sender, TextCompositionEventArgs ex)
        {
            Regex regex = new Regex(@"^(ht|f)tp(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&amp;%\$#_]*)?$");
            ex.Handled = regex.IsMatch(ex.Text);
        }

        private void startBoth_Click(object sender, RoutedEventArgs e)
        {
            SetValue();
            th1 = new Thread(() => RunWeb(webUrl, postData, loop_no));
            th2 = new Thread(() => RunTcp(ipval, postData, loop_no, portval));

            if (th1.IsAlive)
                th1.Join();
            else
            {
                th1.Start();
            }
            if (th2.IsAlive)
                th2.Join();
            else
            {
                th2.Start();
            }
        }

        private void SetValue()
        {
            ipval = ipVal.Text;
            postData = message.Text;
            loop_no = loopNo.Text;
            portval = portNo.Text;
            webUrl = urlVal.Text;
        }

        public static byte[] GetBytes(string hex)
        {
            int bytes = (int)Math.Ceiling(hex.Count() / 2.0);
            byte[] bytedata = new byte[bytes];
            try
            {
                bytedata = Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            return bytedata;
        }
    }
}
