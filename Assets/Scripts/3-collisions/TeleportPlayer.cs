using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportPlayer : MonoBehaviour
{

    [SerializeField]
    Transform teleport_destination;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player Teleports");
            other.transform.position = new Vector3(teleport_destination.position.x, other.transform.position.y, other.transform.position.z);
        }
    }
}
