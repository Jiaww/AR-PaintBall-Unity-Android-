using UnityEngine;

public class MobileNetwork : Photon.PunBehaviour
{
 
    // TODO-2.a: the same as 1.b
    //   and join a room

	// LOOK-1.b: creating a room on PC
	void Start()
	{
		// Make sure "Auto-Join Lobby" was checked at 
		//   Assets-> Photon Unity Networking-> PhotonServerSettings
		//   so the application will automatically connect to Lobby
		//   and call OnJoinedLobby()
		PhotonNetwork.ConnectUsingSettings("0.1");
	}



	void OnGUI()
	{
		GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
	}

	public override void OnJoinedLobby()
	{
		//PhotonNetwork.CreateRoom(null);
		PhotonNetwork.JoinRandomRoom();
	}

	public override void OnJoinedRoom()
	{
		//TODO-1.c: use PhotonNetwork.Instantiate to create a "PhoneCube" across the network
		GetComponent<MobileShooter>().Activate();
	}


	// Look-1.b: We are not doing anything in the functions below
	// , but you may want to do something at the corresponding mobile function
	// On mobile client, use OnJoinedRoom() instead of OnCreatedRoom()
	public override void OnPhotonJoinRoomFailed(object[] codeAndMsg)
	{
		base.OnPhotonJoinRoomFailed(codeAndMsg);
	}
	public override void OnCreatedRoom()
	{
		base.OnCreatedRoom();
	}
    //public override void OnJoinedRoom()
    //{
    //    GetComponent<MobileShooter>().Activate();
    //}


}
