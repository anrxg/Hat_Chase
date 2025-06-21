using UnityEngine;
using Photon.Pun;

public class Bullet : MonoBehaviourPunCallbacks
{
    public float speed = 10f;
    public float slowDuration = 2f;
    public float slowFactor = 2f;

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (photonView.IsMine)
        {
            Player player = other.GetComponent<Player>();
            if (player != null && !player.photonView.IsMine)
            {
                player.photonView.RPC("ApplySlow", RpcTarget.AllBuffered, slowFactor, slowDuration);
                PhotonNetwork.Destroy(gameObject);
            }
        }
    }
}
