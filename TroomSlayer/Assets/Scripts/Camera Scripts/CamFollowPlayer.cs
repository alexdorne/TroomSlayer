using UnityEngine;

public class CameraScript : MonoBehaviour
{
    Transform playerTransform;
    Vector3 cameraOffset;
    [SerializeField] private float cameraSmoothTime;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        cameraOffset = new Vector3(0, 8, -7);
    }

    void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        transform.position = Vector3.Slerp(transform.position, playerTransform.position + cameraOffset, cameraSmoothTime * Time.deltaTime);
    }
}
