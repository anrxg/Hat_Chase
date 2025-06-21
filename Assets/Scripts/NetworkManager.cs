using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using UnityEngine.Assertions.Must;
using TMPro;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    // instance
    public static NetworkManager instance;
    public TMP_InputField userName;

    void Update()
    {
        Debug.Log("Network State : " + PhotonNetwork.NetworkClientState);
    }

    public void OnLoginClick()
    {
        string name = userName.text;
        if (!string.IsNullOrEmpty(name))
        {
            PhotonNetwork.LocalPlayer.NickName = name;
            PhotonNetwork.ConnectUsingSettings();
        }
        else
        {
            Debug.Log("Empty...");
        }
    }

    public override void OnConnected()
    {
        Debug.Log("Connected..");
    }
    public override void OnConnectedToMaster()
    {
        Debug.Log(PhotonNetwork.LocalPlayer.NickName + " is connected to photon");
    }

}
