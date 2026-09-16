using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    [SerializeField] private Vector3 _offset;

    private void LateUpdate()
    {
        //Move camera with player
        transform.position = player.transform.position + _offset;
    }
}
