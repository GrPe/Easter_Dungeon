using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject target = null;
    [SerializeField] private float distanceFromTarget = 10f;
    
    void Start()
    {
        transform.position = target.transform.position + new Vector3(0, distanceFromTarget, 0);
        transform.rotation = Quaternion.Euler(90, 0, 0);
    }
    
    void FixedUpdate()
    {
        transform.position = target.transform.position + new Vector3(0, distanceFromTarget, 0);

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("MainMenu");
        }
    }
}
