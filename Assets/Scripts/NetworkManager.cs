using UnityEngine;
using Photon.Pun;

public class NetworkManager : MonoBehaviour
{
    // instance
    public static NetworkManager instance;

    void Awake()
    {
        // if there is any other instance then don't make this instance but if not make this instace
        if (instance != null && instance != this)
            gameObject.SetActive(false);

        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public void CreateRoom(string roomName)
    {
        PhotonNetwork.CreateRoom(roomName);
    }

    public void JoinRoom(string roomName)
    {
        PhotonNetwork.JoinRoom(roomName);
    }

    public void ChangeScene(string sceneName)
    {
        PhotonNetwork.LoadLevel(sceneName);
    }

}
