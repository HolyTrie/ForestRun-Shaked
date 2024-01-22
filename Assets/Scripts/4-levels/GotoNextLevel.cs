using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class GotoNextLevel : MonoBehaviour
{
    [SerializeField] string sceneName;
    [SerializeField] NumberField scoreField;
    [SerializeField] int winScore;
    private GameObject NextLevelSign;
    private void Start()
    {
        NextLevelSign = transform.GetChild(0).gameObject;
        NextLevelSign.SetActive(false);
    }
    private void Update()
    {
        if (scoreField.GetNumber() == winScore) // checking if the player reached a designated amount of points so he can proceed next level
        {
            Debug.Log("Win!");
            NextLevelSign.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.transform.position = Vector3.zero;
            SceneManager.LoadScene(sceneName);    // Input can either be a serial number or a name; here we use name.
        }
    }
}
