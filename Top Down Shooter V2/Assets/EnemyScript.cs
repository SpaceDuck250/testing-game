using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent agent;
    public States currentstate = States.Idle;

    public float distance;

    public float AggroRange = 2;
    public float AttackRange = 0.1f; //set
    public float TriggeredRange = 7; //After aggro this is new range for AggroRange so set
    public float UntriggeredRange = 2; //set

    public Vector2 startPosition;
    public float patrolRadius = 2;
    public int ranvalue;
    public float setyourself = 1;

    public float timer = 0;
    public float RanTime = 3;
    public float smoothvalue;

    public LayerMask playerlayer;

    public enum States
    {
        Idle,
        Aggro,
        Attacking,
    }

    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.red;
        Handles.DrawWireDisc(transform.position, Vector3.forward, setyourself);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        startPosition = transform.position;
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        CheckState();

        switch (currentstate)
        {
            case States.Aggro:
                TurnToTarget(player.position);
                agent.SetDestination(player.position);
                break;
            case States.Attacking:

                break;
            case States.Idle:
                randomgenerator();
                GetToRandomPatrolPoint();
                break;
        }

    }

    public void CheckState()
    {
        distance = Vector2.Distance(transform.position, player.position);
        if (distance <= AggroRange && distance > AttackRange)
        {
            Vector2 Direction = (player.position - transform.position).normalized;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Direction, AggroRange, playerlayer);
            Debug.Log(hit.collider.tag);
            if (hit.collider.CompareTag("Player"))
            {
                currentstate = States.Aggro;
                //The range for searching will increase
                AggroRange = TriggeredRange;
                agent.speed = 10;
            }

        }
        else if (distance <= AttackRange)
        {
            currentstate = States.Attacking;
        }
        else
        {
            currentstate = States.Idle;

            AggroRange = UntriggeredRange;
            agent.speed = 3; // Speed when patrolling
        }
    }

    public void GetToRandomPatrolPoint()
    {
        if (ranvalue == 1)
        {
            Vector2 randomCircle = Random.insideUnitCircle * patrolRadius;
            Vector2 randomPoint = startPosition + randomCircle;
            TurnToTarget(randomPoint);
            agent.SetDestination(randomPoint);
            ranvalue = 0;
        }
    }

    public void randomgenerator()
    {
        timer += Time.deltaTime;

        if (timer >= RanTime)
        {
            timer = 0;
            ranvalue = Random.Range(0, 2);
            Debug.Log(ranvalue);
        }
    }

    public void TurnToTarget(Vector3 target)
    {
        Vector3 anglevector = (target - transform.position).normalized;
        float angle = Mathf.Atan2(anglevector.y, anglevector.x) * Mathf.Rad2Deg;
        Quaternion Qangle = Quaternion.Euler(0, 0, angle);
        transform.rotation = Qangle;
    }

}

// When using dont forget to make the environment first