using UnityEngine;

public class TrapPatrolVertical : MonoBehaviour
{
    [SerializeField] private Transform topLimit, bottomLimit, trap;
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
        if (trap.position.y >= topLimit.position.y)
        {
            direc = -1f;
        }
        if (trap.position.y <= bottomLimit.position.y)
        {
            direc = 1f;
        }
        trap.position += new Vector3(0f , speedPatrol * direc * Time.deltaTime , 0f);
    }
}
