using UnityEngine;
using System.Collections;

public class PCNetwork : Photon.PunBehaviour
{
    // This is for Paint Ball networking at PC
    //     if you are looking for LOOK-1.b, please refer to PCNetwork_Cube.cs 
    string roomName;

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings("0.1");
        roomName = GenerateRoomName();
    }

    void OnGUI()
    {
        GUI.contentColor = Color.red;
        GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString() + " Room Name: " + roomName);

    }

    public override void OnJoinedLobby()
    {
        PhotonNetwork.CreateRoom(roomName);
    }

    public override void OnPhotonJoinRoomFailed(object[] codeAndMsg)
    {
        base.OnPhotonJoinRoomFailed(codeAndMsg);
    }

    public override void OnCreatedRoom()
    {
        base.OnCreatedRoom();
    }

    static string GenerateRoomName()
    {
        const string characters = "abcdefghijklmnopqrstuvwxyz0123456789";

        string result = "";

        int charAmount = Random.Range(4, 6);
        for (int i = 0; i < charAmount; i++)
        {
            result += characters[Random.Range(0, characters.Length)];
        }

        return result;
    }
}