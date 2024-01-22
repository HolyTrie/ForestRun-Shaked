using UnityEngine;

public class MoveCameraVertical : MonoBehaviour
{
    public GameObject CameraFollow;
    public Vector3 offset;

    private void Update()
    {
        transform.position = new Vector3(CameraFollow.transform.position.x, 0f, CameraFollow.transform.position.z) + offset;
        if (CameraFollow.transform.position.y > 0)
        {
            transform.position = new Vector3(CameraFollow.transform.position.x, CameraFollow.transform.position.y, CameraFollow.transform.position.z) + offset;
        }
    }
}
