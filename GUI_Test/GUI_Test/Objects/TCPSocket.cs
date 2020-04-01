using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Windows;
using System.Windows.Threading;
using Newtonsoft.Json;


namespace GUI
{
    public class TCPSocket
    {

        //public variables
        public bool connected = false;
        public bool delay;
        public struct obj
        {
            public string Name;
            public dynamic Value;
            public string Feedback;
            public obj(string arg1, dynamic arg2, string arg3)
            {
                Name = arg1;
                Value = arg2;
                Feedback = arg3;
            }
        };
        //private variables
        private Stopwatch stopWatch = new Stopwatch();
        private DispatcherTimer timer = new DispatcherTimer();
        private string Address;
        private IPAddress ip;
        private Int32 Port;
        private TcpClient client;
        private NetworkStream stream;

        //public functions

        public TCPSocket(string address, Int32 port)
        {
            Address = address;
            ip = IPAddress.Parse(Address);
            Port = port;
        }
        public void init()
        {
            if (connected == false)
            {
                try { client = new TcpClient(Address, Port); }
                catch (SocketException)
                {
                    MessageBox.Show("Connection Failed", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                stream = client.GetStream();
                connected = true;
                delay = true;
                timer.Interval = TimeSpan.FromSeconds(.10);
                timer.Tick += timer_Tick;
                timer.Start();
            }

        }
        
        public void sendMessage(string name, dynamic command)
        {
            if (connected == true)
            {
                obj JsonObj = new obj(name, command, "N/A");
                string JasonText = JsonConvert.SerializeObject(JsonObj) + ';';
                Byte[] data = System.Text.Encoding.UTF8.GetBytes(JasonText);
                //Byte[] data = System.Text.Encoding.UTF8.GetBytes(command.ToString());
                try { stream.Write(data, 0, data.Length); }
                catch (System.IO.IOException)
                {
                    MessageBox.Show("Connection Failed", "Send ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                    connected = false;
                }
                //if (command == 128) { connected = false; }
            }
        }
        public void recvMessage()
        {
            if (connected == true)
            {
                Byte[] buffer = new Byte[4096];
                try { stream.Read(buffer, 0, buffer.Length); }
                catch (System.IO.IOException)
                {
                    MessageBox.Show("Connection Failed", "Recieve ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                    connected = false;
                    return;
                }
                string message = System.Text.Encoding.UTF8.GetString(buffer, 0, buffer.Length);
                string[] messages = message.Split(';');
                for (int index = 0; index < messages.Length; index++)
                {
                    IList<obj> ObjList = new List<obj>();
                    ObjList = JsonConvert.DeserializeObject<List<obj>>(messages[index]);
                    Paser(ObjList);
                }
            }

        }
        private void Paser(IList<obj> ObjList)
        {
            //placeholder till I do this :)
            if (ObjList != null)
            {
                for (int i = 0; i < ObjList.Count; i++)
                {
                    switch (ObjList[i].Name)
                    {
                        case "Console":
                            MainWindow.secondWindow.Write_to_Console(ObjList[i].Value);
                            break;
                        case "State":
                            MainWindow.Current.UpdateState(ObjList[i].Value);
                            break;                     
                        case "Fill Valve":
                            UpdateValve(ObjList[i], MainWindow.Fill_Valve);
                            break;
                        case "Fill Vent Valve":
                            UpdateValve(ObjList[i], MainWindow.Fill_Vent_Valve);
                            break;
                        case "Tank Vent Valve":
                            UpdateValve(ObjList[i], MainWindow.Tank_Valve);
                            break;
                        case "Propane Valve":
                            UpdateValve(ObjList[i], MainWindow.Propane_Valve);
                            break;
                        case "Servo Valve":
                            UpdateValve(ObjList[i], MainWindow.Servo_Valve);
                            break;
                        case "P1":
                            MainWindow.P1.Value = ObjList[i].Value;
                            break;
                        case "P2":
                            MainWindow.P2.Value = ObjList[i].Value;
                            break;
                        case "P3":
                            MainWindow.P3.Value = ObjList[i].Value;
                            break;
                        case "P4":
                            MainWindow.P4.Value = ObjList[i].Value;
                            break;
                        case "T1":
                            MainWindow.T1.Value = ObjList[i].Value;
                            break;
                        case "T2":
                            MainWindow.T2.Value = ObjList[i].Value;
                            break;
                        case "T3":
                            MainWindow.T3.Value = ObjList[i].Value;
                            break;
                        case "T4":
                            MainWindow.T4.Value = ObjList[i].Value;
                            break;
                        case "T5":
                            MainWindow.T5.Value = ObjList[i].Value;
                            break;
                        case "T6":
                            MainWindow.T6.Value = ObjList[i].Value;
                            break;
                    }
                }
            }
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            if (connected == true)
            {
                sendMessage("CMD",0);
                recvMessage();
            }
        }
        private void UpdateValve(obj Object, Valve valve)
        {
            if (Object.Value == "Open")
            {
                valve.Open();
            }
            else if (Object.Value == "Close")
            {
                valve.Close();
            }
            //update feedback
            if(Object.Feedback == "Nom")
            {
                valve.Feedback = Valve.State.Nominal;
            }
            else if(Object.Feedback == "Fail")
            {
                valve.Feedback = Valve.State.Failure;
            }
            else
            {
                valve.Feedback = Valve.State.Unknown;
            }
        }

        //private variables
    }
}
