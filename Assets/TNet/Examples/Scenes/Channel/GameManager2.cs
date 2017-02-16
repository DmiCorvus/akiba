using UnityEngine;
using TNet;

public class GameManager2 : MonoBehaviour 
{
	List<Channel.Info> mChannels;
	int mSelectedChannel = 0;
	string mChannelName = "";
	string mChannelInfo = "";

	void Start ()
	{
		TNServerInstance.Start(5127);
		TNManager.Connect("127.0.0.1");
	}

	void OnEnable ()
	{
		TNManager.onConnect += OnNetworkConnect;
		TNManager.onJoinChannel += OnNetworkJoinChannel;
		TNManager.onSetChannelData += OnSetChannelData;
	}

	void OnDisable ()
	{
		TNManager.onConnect -= OnNetworkConnect;
		TNManager.onJoinChannel -= OnNetworkJoinChannel;
		TNManager.onSetChannelData -= OnSetChannelData;
	}

	void OnNetworkConnect (bool success, string message)
	{
		if (success)
		{
			TNManager.SetPlayerSave(SystemInfo.deviceUniqueIdentifier + "/Player.dat");
			TNManager.JoinChannel(Random.Range(0, 5));
		}
		else Debug.LogError("OnNetworkConnect(): " + message);
	}

	void OnNetworkJoinChannel (int channelID, bool success, string message)
	{
		if (success)
		{
			TNManager.GetChannelList(OnGetChannels);
		}
		else Debug.LogError("OnNetworkJoinChannel(): " + message);
	}

	void OnGetChannels (List<Channel.Info> list)
	{
		mChannels = list;
	}

	void DrawChannel (Channel.Info info, ref Rect rect)
	{
		if (mSelectedChannel == info.id) GUI.color = Color.yellow;

		if (GUI.Button(rect, "Channel " + info.id))
			mSelectedChannel = info.id;

		rect.y += 20f;

		if (mSelectedChannel == info.id && info.data != null)
		{
			GUI.Label(rect, "Name: " + info.data.GetChild<string>("name"));
			rect.y += 20f;
			GUI.Label(rect, "Info: " + info.data.GetChild<string>("info"));
			rect.y += 20f;
		}

		GUI.color = Color.white;
	}

	void OnGUI()
	{
		if (GUI.Button(new Rect(10, 10, 130, 20), "Refresh Channels"))
		{
			TNManager.GetChannelList(OnGetChannels);
		}

		Rect rect = new Rect(10f, 50f, 300f, 20f);

		if (mChannels != null)
		{
			for (int i = 0; i < mChannels.size; ++i)
				DrawChannel(mChannels[i], ref rect);
		}

		GUI.enabled = (TNManager.IsInChannel(mSelectedChannel));

		rect.y += 40f;
		GUI.Label(rect, "Name2:");
		rect.y += 20f;
		mChannelName = GUI.TextField(rect, mChannelName);

		rect.y += 20f;
		GUI.Label(rect, "Info:");
		rect.y += 20f;
		mChannelInfo = GUI.TextArea(rect, mChannelInfo);
		rect.y += 20f;

		if (GUI.Button(rect, "Save"))
		{
			TNManager.SetChannelData("name", mChannelName);
			TNManager.SetChannelData("info", mChannelInfo);
			TNManager.GetChannelList(OnGetChannels);
		}
	}

	void OnSetChannelData(Channel ch, string path, DataNode node)
	{
		if (TNManager.IsInChannel(ch.id))
		{
			mChannelName = ch.Get<string>("name");
			mChannelInfo = ch.Get<string>("info");
		}
	}

}
