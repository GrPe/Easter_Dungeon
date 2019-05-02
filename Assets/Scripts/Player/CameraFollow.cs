using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject target = null;
    [SerializeField] private float distanceFromTarget = 10f;
    
    void Start()
    {
        transform.position = target.transform.position + new Vector3(0, distanceFromTarget, 0);
        transform.rotation = Quaternion.Euler(90, 0, 0);
    }
    
    void Update()
    {
        transform.position = target.transform.position + new Vector3(0, distanceFromTarget, 0);
    }
}
