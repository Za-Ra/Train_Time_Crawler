using System;
using System.Xml.Serialization;
using System.Xml;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;
//using System.Net;
//using System.Net.Http;
//using System.Net.Http.Headers;
//using System.Web;
//using System.Threading.Tasks;


namespace Train_Time_Crawler
{
    public partial class Train_Time_Crawler : Form
    {
        bool ShowNowTime_Flag = true;
        Thread ShowNowTime_Thread ;

        public void New_Thread_Renew_Msg(object smsg)
        {
            string[] NameAndMsg = ((string)smsg).Split(',');
            Control[] Ctrl = Controls.Find(NameAndMsg[0], true);
            if (Ctrl.Length > 0)
                Ctrl_Msg_Renew(Ctrl[0], NameAndMsg[1]);
        }
        public void Ctrl_Msg_Renew(Control Target_Label, string Msg)
        {
            try
            {
                if (this.InvokeRequired == true)
                {
                    Ctrl_Msg_RenewCallback d = Ctrl_Msg_Renew;
                    this.Invoke(d, Target_Label, Msg);
                }
                else
                {
                        Target_Label.Text = Msg;
                }
            }
            catch (Exception eer)
            {
                //MessageBox.Show(eer.Message, "Label Renew Error !!");
            }
        }
        public delegate void Ctrl_Msg_RenewCallback(Control Target_Label, string Msg);

        public Train_Time_Crawler()
        {
            InitializeComponent();

            ShowNowTime_Thread = new Thread(ShowNowTime);
            ShowNowTime_Thread.Start();

            


            useWebBrowser();
        }

        private void Train_Time_Crawler_FormClosing(object sender, FormClosingEventArgs e)
        {
            ShowNowTime_Flag = false;
        }

        private void ShowNowTime()
        {
            bool alreadyDone = false;
            while(ShowNowTime_Flag)
            {
                string sendMsg = "label_Now_Time," + DateTime.Now.ToString("HH:mm:ss");
                New_Thread_Renew_Msg(sendMsg);
                Thread.Sleep(250);
                if (DateTime.Now.ToString("mm") == "00" || DateTime.Now.ToString("mm") == "30")
                {
                    if (!alreadyDone)
                    {
                        useWebBrowser();
                        alreadyDone = true;
                    }
                }
                else
                    alreadyDone = false;
                analizeXML("");
            }
        }

        private string PTX_URI = "https://ptx.transportdata.tw/MOTC/v3/Rail/TRA/DailyTrainTimetable/OD/";
        private string OriginStationID = "1080/";
        private string DestinationStationID = "1120/";
        private string ReadFormat = "?$format=xml";


        private void button_Tese_Button_Click(object sender, EventArgs e)
        {
            //Crawler();
            //useHttpClient_Get();
            useWebBrowser();
        }

        private void useWebBrowser()
        {
            ////web browser cannot catch json directly.
            webBrowser1.Navigate(PTX_URI + OriginStationID + "to/" + DestinationStationID + DateTime.Now.ToString("yyyy-MM-dd") + ReadFormat);
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try
            {
                HtmlDocument doc = webBrowser1.Document;
                analizeXML(doc.All[0].InnerText.Trim().Replace("- ", ""));
                File.WriteAllText("xmlFile.txt", doc.All[0].InnerText.Trim().Replace("- ", ""));
            }
            catch (Exception err)
            {
                textBox_Msg.Text = err.ToString();
            }
        }

        private void analizeXML(string readxml)
        {
            bool isReadFile = false;
            if (readxml == "")
            {
                readxml = File.ReadAllText("xmlFile.txt");
                isReadFile = true;
            }

            try
            {
                StringReader reader = new StringReader(readxml);//xmlstring 是傳入 XML 格式的 string
                XmlSerializer serializer = new XmlSerializer(typeof(TRADailyTrainTimeTableList));//documents 是 paste xml as class 來的類別
                TRADailyTrainTimeTableList instance = (TRADailyTrainTimeTableList)serializer.Deserialize(reader);

                XmlDocument XmlDoc = new XmlDocument();
                XmlDoc.LoadXml(readxml);//xmlstring 是傳入 XML 格式的 string

                XmlNodeList TrainTimetable = XmlDoc.GetElementsByTagName("TrainTimetable");
                List<string> TrainTableList = new List<string>();
                foreach(XmlElement XE in TrainTimetable)
                {
                    string TrainInfo = XE.GetElementsByTagName("TrainNo")[0].InnerText;
                    string DepartureTime = XE.GetElementsByTagName("DepartureTime")[0].InnerText;

                    TrainTableList.Add(DepartureTime + "," + TrainInfo);
                }
                TrainTableList.Sort();
                int only_3_Data = 1;
                foreach (string T_Info in TrainTableList)
                {
                    //New_Thread_Renew_Msg("textBox_Msg," + T_Info + "\r\n");
                    if(!isReadFile)
                        textBox_Msg.Text += T_Info + "\r\n";

                    if (only_3_Data <4)
                    {
                        string[] Info_TIME_NO = T_Info.Split(',');
                        int T_Hour = Int32.Parse(Info_TIME_NO[0].Substring(0, 2));
                        int T_Minute = Int32.Parse(Info_TIME_NO[0].Substring(3, 2));
                        if (T_Hour == DateTime.Now.Hour)
                        {
                            if (T_Minute > DateTime.Now.Minute)
                            {
                                string sndmsg = Info_TIME_NO[1] + "                    " + Info_TIME_NO[0];
                                New_Thread_Renew_Msg("label_Train_Time_" + only_3_Data + "," + sndmsg);
                                //Control[] label_Target = this.Controls.Find("label_Train_Time_" + only_3_Data, true);
                                //label_Target[0].Text = Info_TIME_NO[1] + "                    " + Info_TIME_NO[0];
                                only_3_Data++;
                            }
                            
                        }
                        else if(T_Hour > DateTime.Now.Hour)
                        {
                            string sndmsg = Info_TIME_NO[1] + "                    " + Info_TIME_NO[0];
                            New_Thread_Renew_Msg("label_Train_Time_" + only_3_Data + "," + sndmsg);
                            //Control[] label_Target = this.Controls.Find("label_Train_Time_" + only_3_Data, true);
                            //label_Target[0].Text = Info_TIME_NO[1] + "                    " + Info_TIME_NO[0];
                            only_3_Data++;
                        }
                    }

                }
            }
            catch (Exception err)
            {
                New_Thread_Renew_Msg("textBox_Msg,"+err.ToString());
                //textBox_Msg.Text = err.ToString();
            }


        }

        /*
                private const string WebApi_s = "https://ptx.transportdata.tw/MOTC/v3/Rail/TRA/DailyTrainTimetable/OD/Inclusive/1080/to/1120/2021-07-08?";
                private void Use_PTX_API()
                {
                  //ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11;
                    useHttpClient_Get();
                }

                private void useHttpClient_Get()
                {
                    HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri(WebApi_s);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //client.DefaultRequestHeaders.Authorization = "hmac";

                    var response = client.GetAsync("api/products").Result;
                    var body = response.Content.ReadAsStringAsync().Result;

                    //TODO:反序列化
                    //var serializer = new JavaScriptSerializer();
                    //var list = serializer.Deserialize<List<Product>>(body);
                    //this.dataGridView1.DataSource = list;
                    this.textBox_Msg.Text = body;
                }


                //請替換為串接使用的 appID 與 appKey
                const string appID = "FFFFFFFF-FFFF-FFFF-FFFF-FFFFFFFFFFFF";//"your appID";
                const string appKey = "tNijtuwfZFNz0P9+6idtHGyCh54=";//"your appKey";
                const string baseAddress = "https://ptx.transportdata.tw/";
                const string requestUri = "MOTC/v3/Rail/TRA/DailyTrainTimetable/OD/Inclusive/1080/to/1120/2021-07-06?$format=json";
                private void myTest()
                {
                    string _json;

                    HttpClient _client;
                    HttpClientHandler _clientHandler = new HttpClientHandler();

                    //啟用 GZip, Deflate 壓縮傳輸 / 減少傳遞的資料量
                    _clientHandler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

                    _client = new HttpClient(_clientHandler);
                    _client.BaseAddress = new Uri(baseAddress);

                    Console.WriteLine("start api request");

                    for (int i = 0; i < 3; i++)
                    {
                        //_client.GetAsync("/api").Result.Content.ReadAsStringAsync();
                        //設定 RequestHeader 驗證簽章
                       // _client.SetSignature(appID, appKey);

                        var _response = _client.GetAsync(requestUri).Result;

                        if (_response.IsSuccessStatusCode == true)
                        {
                            _json = _response.Content.ReadAsStringAsync().Result;

                            Console.WriteLine("{0}\t{1}\t{2}"
                                            , i
                                            , _response.StatusCode
                                            , _json.Substring(0, 50));
                        }
                        else
                        {
                            Console.WriteLine("Status Cdoe: {0}", (int)_response.StatusCode);
                            Console.WriteLine("Message: {0}", _response.ReasonPhrase);
                        }
                    }

                    Console.WriteLine("press any key to exit");
                    Console.ReadKey();
                }

                private void Crawler()
                {
                    System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                    //ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11;

                    string s_url = @"https://tip.railway.gov.tw/tra-tip-web/tip/tip001/tip112/gobytime";
                    //Uri uri = new Uri(s_url);

                    //WebRequest webReq = WebRequest.Create(uri);
                    //WebResponse webRes = webReq.GetResponse();
                    //HttpWebRequest myReq = (HttpWebRequest)webReq;


                    string kWebStr = "";
                    //string url = @"https://masteryeeeeee.wordpress.com/";
                    WebRequest kRequest = WebRequest.Create(@s_url);
                    WebResponse kResponse;
                    StreamReader sr;
                    kRequest.Method = "GET";


                    //try
                    //{
                    kResponse = kRequest.GetResponse();
                    //}
                    //catch
                    //{
                    //    return;
                    //}

                    sr = new StreamReader(kResponse.GetResponseStream());
                    kWebStr = sr.ReadToEnd();
                    textBox_Msg.Text = kWebStr;

                    // 關閉 StreamReader 與 WebResponse
                    sr.Close();
                    kResponse.Close();


                }
        */
    }
}


/// <remarks/>
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "https://ptx.transportdata.tw/standard/schema/")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "https://ptx.transportdata.tw/standard/schema/", IsNullable = false)]
public partial class TRADailyTrainTimeTableList
{

    private System.DateTime updateTimeField;

    private ushort updateIntervalField;

    private System.DateTime srcUpdateTimeField;

    private sbyte srcUpdateIntervalField;

    private System.DateTime trainDateField;

    private TRADailyTrainTimeTableListTrainTimetable[] trainTimetablesField;

    private object countField;

    /// <remarks/>
    public System.DateTime UpdateTime
    {
        get
        {
            return this.updateTimeField;
        }
        set
        {
            this.updateTimeField = value;
        }
    }

    /// <remarks/>
    public ushort UpdateInterval
    {
        get
        {
            return this.updateIntervalField;
        }
        set
        {
            this.updateIntervalField = value;
        }
    }

    /// <remarks/>
    public System.DateTime SrcUpdateTime
    {
        get
        {
            return this.srcUpdateTimeField;
        }
        set
        {
            this.srcUpdateTimeField = value;
        }
    }

    /// <remarks/>
    public sbyte SrcUpdateInterval
    {
        get
        {
            return this.srcUpdateIntervalField;
        }
        set
        {
            this.srcUpdateIntervalField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
    public System.DateTime TrainDate
    {
        get
        {
            return this.trainDateField;
        }
        set
        {
            this.trainDateField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("TrainTimetable", IsNullable = false)]
    public TRADailyTrainTimeTableListTrainTimetable[] TrainTimetables
    {
        get
        {
            return this.trainTimetablesField;
        }
        set
        {
            this.trainTimetablesField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
    public object Count
    {
        get
        {
            return this.countField;
        }
        set
        {
            this.countField = value;
        }
    }
}

/// <remarks/>
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "https://ptx.transportdata.tw/standard/schema/")]
public partial class TRADailyTrainTimeTableListTrainTimetable
{

    private TRADailyTrainTimeTableListTrainTimetableTrainInfo trainInfoField;

    private TRADailyTrainTimeTableListTrainTimetableStopTime[] stopTimesField;

    /// <remarks/>
    public TRADailyTrainTimeTableListTrainTimetableTrainInfo TrainInfo
    {
        get
        {
            return this.trainInfoField;
        }
        set
        {
            this.trainInfoField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("StopTime", IsNullable = false)]
    public TRADailyTrainTimeTableListTrainTimetableStopTime[] StopTimes
    {
        get
        {
            return this.stopTimesField;
        }
        set
        {
            this.stopTimesField = value;
        }
    }
}

/// <remarks/>
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "https://ptx.transportdata.tw/standard/schema/")]
public partial class TRADailyTrainTimeTableListTrainTimetableTrainInfo
{

    private ushort trainNoField;

    private object routeIDField;

    private byte directionField;

    private ushort trainTypeIDField;

    private byte trainTypeCodeField;

    private TRADailyTrainTimeTableListTrainTimetableTrainInfoTrainTypeName trainTypeNameField;

    private string tripHeadSignField;

    private ushort startingStationIDField;

    private TRADailyTrainTimeTableListTrainTimetableTrainInfoStartingStationName startingStationNameField;

    private ushort endingStationIDField;

    private TRADailyTrainTimeTableListTrainTimetableTrainInfoEndingStationName endingStationNameField;

    private string overNightStationIDField;

    private byte tripLineField;

    private byte wheelChairFlagField;

    private byte packageServiceFlagField;

    private byte diningFlagField;

    private byte breastFeedFlagField;

    private byte bikeFlagField;

    private object carFlagField;

    private byte dailyFlagField;

    private byte extraTrainFlagField;

    private string noteField;

    /// <remarks/>
    public ushort TrainNo
    {
        get
        {
            return this.trainNoField;
        }
        set
        {
            this.trainNoField = value;
        }
    }

    /// <remarks/>
    public object RouteID
    {
        get
        {
            return this.routeIDField;
        }
        set
        {
            this.routeIDField = value;
        }
    }

    /// <remarks/>
    public byte Direction
    {
        get
        {
            return this.directionField;
        }
        set
        {
            this.directionField = value;
        }
    }

    /// <remarks/>
    public ushort TrainTypeID
    {
        get
        {
            return this.trainTypeIDField;
        }
        set
        {
            this.trainTypeIDField = value;
        }
    }

    /// <remarks/>
    public byte TrainTypeCode
    {
        get
        {
            return this.trainTypeCodeField;
        }
        set
        {
            this.trainTypeCodeField = value;
        }
    }

    /// <remarks/>
    public TRADailyTrainTimeTableListTrainTimetableTrainInfoTrainTypeName TrainTypeName
    {
        get
        {
            return this.trainTypeNameField;
        }
        set
        {
            this.trainTypeNameField = value;
        }
    }

    /// <remarks/>
    public string TripHeadSign
    {
        get
        {
            return this.tripHeadSignField;
        }
        set
        {
            this.tripHeadSignField = value;
        }
    }

    /// <remarks/>
    public ushort StartingStationID
    {
        get
        {
            return this.startingStationIDField;
        }
        set
        {
            this.startingStationIDField = value;
        }
    }

    /// <remarks/>
    public TRADailyTrainTimeTableListTrainTimetableTrainInfoStartingStationName StartingStationName
    {
        get
        {
            return this.startingStationNameField;
        }
        set
        {
            this.startingStationNameField = value;
        }
    }

    /// <remarks/>
    public ushort EndingStationID
    {
        get
        {
            return this.endingStationIDField;
        }
        set
        {
            this.endingStationIDField = value;
        }
    }

    /// <remarks/>
    public TRADailyTrainTimeTableListTrainTimetableTrainInfoEndingStationName EndingStationName
    {
        get
        {
            return this.endingStationNameField;
        }
        set
        {
            this.endingStationNameField = value;
        }
    }

    /// <remarks/>
    public string OverNightStationID
    {
        get
        {
            return this.overNightStationIDField;
        }
        set
        {
            this.overNightStationIDField = value;
        }
    }

    /// <remarks/>
    public byte TripLine
    {
        get
        {
            return this.tripLineField;
        }
        set
        {
            this.tripLineField = value;
        }
    }

    /// <remarks/>
    public byte WheelChairFlag
    {
        get
        {
            return this.wheelChairFlagField;
        }
        set
        {
            this.wheelChairFlagField = value;
        }
    }

    /// <remarks/>
    public byte PackageServiceFlag
    {
        get
        {
            return this.packageServiceFlagField;
        }
        set
        {
            this.packageServiceFlagField = value;
        }
    }

    /// <remarks/>
    public byte DiningFlag
    {
        get
        {
            return this.diningFlagField;
        }
        set
        {
            this.diningFlagField = value;
        }
    }

    /// <remarks/>
    public byte BreastFeedFlag
    {
        get
        {
            return this.breastFeedFlagField;
        }
        set
        {
            this.breastFeedFlagField = value;
        }
    }

    /// <remarks/>
    public byte BikeFlag
    {
        get
        {
            return this.bikeFlagField;
        }
        set
        {
            this.bikeFlagField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
    public object CarFlag
    {
        get
        {
            return this.carFlagField;
        }
        set
        {
            this.carFlagField = value;
        }
    }

    /// <remarks/>
    public byte DailyFlag
    {
        get
        {
            return this.dailyFlagField;
        }
        set
        {
            this.dailyFlagField = value;
        }
    }

    /// <remarks/>
    public byte ExtraTrainFlag
    {
        get
        {
            return this.extraTrainFlagField;
        }
        set
        {
            this.extraTrainFlagField = value;
        }
    }

    /// <remarks/>
    public string Note
    {
        get
        {
            return this.noteField;
        }
        set
        {
            this.noteField = value;
        }
    }
}

/// <remarks/>
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "https://ptx.transportdata.tw/standard/schema/")]
public partial class TRADailyTrainTimeTableListTrainTimetableTrainInfoTrainTypeName
{

    private string zh_twField;

    private string enField;

    /// <remarks/>
    public string Zh_tw
    {
        get
        {
            return this.zh_twField;
        }
        set
        {
            this.zh_twField = value;
        }
    }

    /// <remarks/>
    public string En
    {
        get
        {
            return this.enField;
        }
        set
        {
            this.enField = value;
        }
    }
}

/// <remarks/>
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "https://ptx.transportdata.tw/standard/schema/")]
public partial class TRADailyTrainTimeTableListTrainTimetableTrainInfoStartingStationName
{

    private string zh_twField;

    private string enField;

    /// <remarks/>
    public string Zh_tw
    {
        get
        {
            return this.zh_twField;
        }
        set
        {
            this.zh_twField = value;
        }
    }

    /// <remarks/>
    public string En
    {
        get
        {
            return this.enField;
        }
        set
        {
            this.enField = value;
        }
    }
}

/// <remarks/>
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "https://ptx.transportdata.tw/standard/schema/")]
public partial class TRADailyTrainTimeTableListTrainTimetableTrainInfoEndingStationName
{

    private string zh_twField;

    private string enField;

    /// <remarks/>
    public string Zh_tw
    {
        get
        {
            return this.zh_twField;
        }
        set
        {
            this.zh_twField = value;
        }
    }

    /// <remarks/>
    public string En
    {
        get
        {
            return this.enField;
        }
        set
        {
            this.enField = value;
        }
    }
}

/// <remarks/>
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "https://ptx.transportdata.tw/standard/schema/")]
public partial class TRADailyTrainTimeTableListTrainTimetableStopTime
{

    private byte stopSequenceField;

    private ushort stationIDField;

    private TRADailyTrainTimeTableListTrainTimetableStopTimeStationName stationNameField;

    private string arrivalTimeField;

    private string departureTimeField;

    /// <remarks/>
    public byte StopSequence
    {
        get
        {
            return this.stopSequenceField;
        }
        set
        {
            this.stopSequenceField = value;
        }
    }

    /// <remarks/>
    public ushort StationID
    {
        get
        {
            return this.stationIDField;
        }
        set
        {
            this.stationIDField = value;
        }
    }

    /// <remarks/>
    public TRADailyTrainTimeTableListTrainTimetableStopTimeStationName StationName
    {
        get
        {
            return this.stationNameField;
        }
        set
        {
            this.stationNameField = value;
        }
    }

    /// <remarks/>
    public string ArrivalTime
    {
        get
        {
            return this.arrivalTimeField;
        }
        set
        {
            this.arrivalTimeField = value;
        }
    }

    /// <remarks/>
    public string DepartureTime
    {
        get
        {
            return this.departureTimeField;
        }
        set
        {
            this.departureTimeField = value;
        }
    }
}

/// <remarks/>
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "https://ptx.transportdata.tw/standard/schema/")]
public partial class TRADailyTrainTimeTableListTrainTimetableStopTimeStationName
{

    private string zh_twField;

    private string enField;

    /// <remarks/>
    public string Zh_tw
    {
        get
        {
            return this.zh_twField;
        }
        set
        {
            this.zh_twField = value;
        }
    }

    /// <remarks/>
    public string En
    {
        get
        {
            return this.enField;
        }
        set
        {
            this.enField = value;
        }
    }
}

