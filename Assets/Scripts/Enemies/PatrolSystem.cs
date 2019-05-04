using System.Collections.Generic;
using UnityEngine;

public class PatrolSystem : MonoBehaviour
{
    [SerializeField] private List<GameObject> watchPoints = new List<GameObject>();
    private int currentPoint = 0;

    public Vector3 GetNextTarget()
    {
        if (currentPoint >= watchPoints.Count) currentPoint = 0;
        return watchPoints[currentPoint++].transform.position;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        for(int i = 1; i < watchPoints.Count; i++)
        {
            Gizmos.DrawLine(watchPoints[i - 1].transform.position, watchPoints[i].transform.position);
        }

        Gizmos.DrawLine(watchPoints[0].transform.position, watchPoints[watchPoints.Count-1].transform.position);
    }

}
