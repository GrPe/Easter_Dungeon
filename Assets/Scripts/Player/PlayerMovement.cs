using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent = null;
    [SerializeField] private Animator animator;

    void Update()
    {
        Move();
        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        if(agent.remainingDistance < 0.01)
        {
            animator.SetBool("IsRunning", false);
        }
    }

    private void Move()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
                animator.SetBool("IsRunning", true);
            }
        }
    }
}
