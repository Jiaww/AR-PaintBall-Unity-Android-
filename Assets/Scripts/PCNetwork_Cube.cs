using UnityEngine;
using System.Collections;
using Photon;

// LOOK-1.b: the parent class is not a basic MonoBehavior!
public class PCNetwork_Cube : Photon.PunBehaviour
{
    string roomName;

    // LOOK-1.b: creating a room on PC
    void Start()
    {
        // Make sure "Auto-Join Lobby" was checked at 
        //   Assets-> Photon Unity Networking-> PhotonServerSettings
        //   so the application will automatically connect to Lobby
        //   and call OnJoinedLobby()
        PhotonNetwork.ConnectUsingSettings("0.1");
        roomName = GenerateRoomName();
    }

    static string GenerateRoomName()
    {
        const string characters = "abcdefghijklmnopqrstuvwxyz0123456789"; //add the characters you want

        string result = "";

        int charAmount = Random.Range(4, 6); //set those to the minimum and maximum length of your string
        for (int i = 0; i < charAmount; i++)
        {
            result += characters[Random.Range(0, characters.Length)];
        }

        return result;
    }

    void OnGUI()
    {
        GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
        GUILayout.Label("Room Name: " + roomName);
    }

    public override void OnJoinedLobby()
    {
        //PhotonNetwork.CreateRoom(null);
        PhotonNetwork.CreateRoom(roomName);
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