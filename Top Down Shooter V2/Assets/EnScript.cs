using UnityEngine;
using UnityEngine.AI;

public class EnemyScriptV2 : MonoBehaviour
{
    [SerializeField]
    public Transform goal;
    public NavMeshAgent agent2;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent2.updateRotation = false;
        agent2.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        agent2.SetDestination(goal.position);
    }
}
