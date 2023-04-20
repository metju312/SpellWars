using UnityEngine;
using UnityEngine.AI;

public class PeonMovement : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public GameObject headquarters;
    public GameObject woodcutter;
    public float minimumDistance = 0.5f;

    private GameObject targetBuilding;
    private bool isMoving = false;

    private void Update()
    {
        if (isMoving)
        {
            if (navMeshAgent.remainingDistance <= minimumDistance)
            {
                isMoving = false;
                targetBuilding.GetComponent<Building>().AddPeon(gameObject);
            }
        }
    }

    public void MoveToBuilding(GameObject building)
    {
        targetBuilding = building;
        navMeshAgent.SetDestination(building.transform.position);
        isMoving = true;
    }

    public void MoveToHeadquarters()
    {
        MoveToBuilding(headquarters);
    }

    public void MoveToWoodcutter()
    {
        MoveToBuilding(woodcutter);
    }
}