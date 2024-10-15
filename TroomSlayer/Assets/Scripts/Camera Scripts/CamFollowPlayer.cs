using UnityEngine;

public class CameraScript : MonoBehaviour
{
    Transform playerTransform;
    [SerializeField] Vector3 cameraOffset = new Vector3(0, 8, -7);
    [SerializeField] private float cameraSmoothTime;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void LateUpdate()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        transform.position = Vector3.Slerp(transform.position, playerTransform.position + cameraOffset, cameraSmoothTime * Time.deltaTime);
    }
}
