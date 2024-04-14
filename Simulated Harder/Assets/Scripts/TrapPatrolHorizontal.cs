using UnityEngine;

public class TrapPatrolHorizontal : MonoBehaviour
{
    [SerializeField] private Transform leftLimit, rightLimit, trap;
    [SerializeField] private float speedPatrol;
    private float direc;
    private void Start()
    {
        direc = 1f;
    }
    private void Update()
    {
        HandlePatrol();
    }
    private void HandlePatrol()
    {
        if (trap.position.x <= leftLimit.position.x)
        {
            direc = 1f;
        }
        if (trap.position.x >= rightLimit.position.x)
        {
            direc = -1f;
        }
        trap.position += new Vector3(speedPatrol * direc * Time.deltaTime, 0f, 0f);
    }
}
