//-------------------------------------------------
//                    TNet 3
// Copyright © 2012-2016 Tasharen Entertainment Inc
//-------------------------------------------------

using UnityEngine;
using UnityEngine.UI;
using UnityTools = TNet.UnityTools;

namespace TNet
{
/// <summary>
/// Extremely simplified "join a server" functionality. Attaching this script will
/// make it possible to automatically join a remote server when the game starts.
/// It's best to place this script in a clean scene with a message that displays
/// a "Connecting, please wait..." message.
/// </summary>

public class TNAutoJoin : MonoBehaviour
{
	static public TNAutoJoin instance;

	public string serverAddress = "127.0.0.1";
	public int serverPort = 5127;
	public string firstLevel = "";
	public int channelID = 1;
	public bool persistent = false;
	public string disconnectLevel;
	public bool allowUDP = true;
	public bool connectOnStart = true;


        //МОИ ПРАВКИ

       

        public GameObject connectButtonACT;
        public GameObject serverStatusOffline;
        public GameObject serverStatusOnline;
        public GameObject needUpdate;


        //проверка версии
        private int gVersion;

        public static int checkVersion;
        public Text serverVersionTXTconnect;

        //проверка установок лобби
        private int lobbyDefaultCHK;


        /// <summary>
        /// Set the instance so this script can be easily found.
        /// </summary>

        void Awake ()
	{
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
	}

	void OnEnable ()
	{
            if (connectOnStart) Connect();

            TNManager.onConnect += OnConnect;
		TNManager.onDisconnect += OnDisconnect;
        TNManager.onJoinChannel += OnJoinChannel;


        }

        void OnDisable ()
	{
		TNManager.onConnect -= OnConnect;
		TNManager.onDisconnect -= OnDisconnect;
        TNManager.onJoinChannel -= OnJoinChannel;

        }


        void OnJoinChannel(int channelID, bool success, string msg)
        {
        //    if (NetSettings.connectionDone == false)
            {
                // NetSettings.connectionDone = true;
                 checkVersion = 1;
                 print("connected to channel");
            }

        }
        /// <summary>
        /// Connect to the server if requested.
        /// </summary>

        void Start () {

       //     print("STATUS" + NetSettings.connectionDone);
         //   if(NetSettings.connectionDone ==false)
            {               
            //отключаем кнопки
 
          //  if (connectOnStart) Connect();
            }


        }

        /// <summary>
        /// Connect to the server.
        /// </summary>
        /// 
        public void Connect ()
	{
		// We don't want mobile devices to dim their screen and go to sleep while the app is running
		Screen.sleepTimeout = SleepTimeout.NeverSleep;

		// Connect to the remote server
		TNManager.Connect(serverAddress, serverPort);
            
        }

	/// <summary>
	/// On success -- join a channel.
	/// </summary>

	void OnConnect (bool result, string message)
	{
		if (result)
		{
                // Make it possible to use UDP using a random port
                if (allowUDP)
                {
                    TNManager.StartUDP(Random.Range(10000, 50000));
                    TNManager.JoinChannel(channelID, firstLevel, persistent, 10000, null);
                    //МОИ ПРАВКИ

                }
            }
	//	else Debug.LogError(message);

        else {

                Connect();
            }
    
        }

	/// <summary>
	/// Disconnected? Go back to the menu.
	/// </summary>
    void Update()
        {
            //ХОСТ НАСТРОЙКИ
              //       TNManager.SetServerData("game versionAKIBA", 20170203);
               //     TNManager.SetServerData("game versionAKIBAvisual", "0.1a");
            if (checkVersion == 1)
            {
                gVersion = TNManager.GetServerData<int>("game versionAKIBA");
                //КОНЕЦ

                print("ver" + gVersion);

                //отображаем версию
                string chkVisualVersion;
                chkVisualVersion = TNManager.GetServerData<string>("game versionAKIBAvisual");
                serverVersionTXTconnect.GetComponent<Text>().text = chkVisualVersion;

                if (gVersion == MMOsettings.clientVersion)
                {
                    lobbyDefaultCHK = TNManager.GetChannelData<int>("SETDEFAULTSLOBBY");

                    serverStatusOffline.SetActive(false);
                    serverStatusOnline.SetActive(true);
                    connectButtonACT.SetActive(true);

                    //activate menu           
                    checkVersion = 0;
                    print("CHECK DONE");

                }

                //OLD VERSION
                if (gVersion != MMOsettings.clientVersion)
                {
                    
                    serverStatusOffline.SetActive(false);
                    serverStatusOnline.SetActive(true);
                    needUpdate.SetActive(true);
                    print("FAIL CHECK");

                    checkVersion = 0;
                }
                else { return; }
            }


        }

 


        //отключение
        void OnDisconnect ()
	{
#if UNITY_4_6 || UNITY_4_7 || UNITY_5_0 || UNITY_5_1 || UNITY_5_2
		if (!string.IsNullOrEmpty(disconnectLevel) && Application.loadedLevelName != disconnectLevel)
			Application.LoadLevel(disconnectLevel);
#else
		if (!string.IsNullOrEmpty(disconnectLevel) &&
			UnityEngine.SceneManagement.SceneManager.GetActiveScene().name != disconnectLevel)
			UnityEngine.SceneManagement.SceneManager.LoadScene(disconnectLevel);
            print("CONNECTION LOSE");
#endif
        }
}
}
