using UnityEngine;

public class MobileNetwork_Cube : Photon.PunBehaviour
{
    // TODO-1.b: write any functions needed to establish connection
    //   and join a room. Joining a random room will do for now if you are testing
    //   it yourself. But you can also list the rooms or require player to enter
    //   the room name in case there are more people playing
    //   your game - though it is not required for the assignment.


 

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
		var cube = PhotonNetwork.Instantiate("PhoneCube", Vector3.zero, Quaternion.identity, 0);
	    GetComponent<GyroController>().ControlledObject = cube;
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
}
