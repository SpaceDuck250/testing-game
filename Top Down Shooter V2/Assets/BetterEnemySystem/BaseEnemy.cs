using UnityEngine;
using UnityEngine.AI;

public class BaseEnemy : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public Vector2 startPosition;

    public TurnScript turnscript;

    private void Start()
    {
        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            startPosition = transform.position;
            agent.updateRotation = false;
            agent.updateUpAxis = false;
        }
    }

    private void Update()
    {

    }




}
