using UnityEngine;
using UnityEngine.AI;

public class EneScript : MonoBehaviour
{
    [SerializeField]
    public Transform goala;
    public NavMeshAgent agent2a;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent2a.updateRotation = false;
        agent2a.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        agent2a.SetDestination(goala.position);
    }
}