using UnityEngine;
using UnityEngine.AI;

public class NPCMovement : MonoBehaviour
{
    [SerializeField] private NavMeshAgent NPC;
    [SerializeField] private Transform[] posArr;
    private int arrCount = 1;

    void Update()
    {
        if (arrCount < 5)
        {
            if (this.transform.position.x != posArr[arrCount].position.x && this.transform.position.y != posArr[arrCount].position.y)
            {
                NPC.SetDestination(posArr[arrCount].position);
            }
            else { arrCount++; }
        }
        else
        {
            arrCount = 0;
        }
    }
}
