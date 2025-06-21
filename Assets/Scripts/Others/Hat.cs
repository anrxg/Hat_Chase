using UnityEngine;
using Photon.Pun;

public class Hat : MonoBehaviourPunCallbacks
{
    public static Hat instance;

    private void Awake()
    {
        instance = this;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        Debug.Log("Hat triggered by: " + other.name);
        if (!PhotonNetwork.IsMasterClient) return;

        Player player = other.GetComponent<Player>();
        if (player != null)
        {
            photonView.RPC("AttachHatToPlayer", RpcTarget.AllBuffered, player.photonView.ViewID);
        }
    }

    [PunRPC]
    void AttachHatToPlayer(int viewID)
    {
        PhotonView playerView = PhotonView.Find(viewID);
        if (playerView != null)
        {
            GameObject playerObj = playerView.gameObject;
            Player playerScript = playerObj.GetComponent<Player>();

            transform.SetParent(playerScript.hatPosition);
            transform.localPosition = Vector3.zero;
        }
    }
}
