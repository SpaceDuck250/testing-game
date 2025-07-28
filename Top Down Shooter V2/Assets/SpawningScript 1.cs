using UnityEngine;
using UnityEngine.Events;
using UnityEditor;

public class SpawningScript : MonoBehaviour
{
    public static SpawningScript instance; // For triggering death event
    public UnityEvent OnEnemyDestroyed;

    public float SpawnPeriod = 2f;
    public float Timer;


    public int EnemiesAlive;

    public float wavecooldown = 2.5f;
    public float wavesmult = 0.7f;
    public bool isSpawning = false;

    public Vector2 startingpoint;
    public float SpawnRadius = 8;

    public int maxmobs;
    public GameObject testmob;

    private void OnDrawGizmosSelected()
    {

    }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        EnemiesAlive = 0;
        maxmobs = 8;
        startingpoint = transform.position;
        OnEnemyDestroyed.AddListener(WhenDie);

    }

    private void Update()
    {
        if (EnemiesAlive >= maxmobs)
        {
            isSpawning = false;
        }
        else
        {
            isSpawning = true;
        }


        if (!isSpawning)
        {
            return;
        }

        Timer += Time.deltaTime;

        if (Timer >= SpawnPeriod)
        {
            Timer = 0;
            EnemiesAlive++;
            SpawnEnemy();
        }



    }

    public void WhenDie()
    {
        EnemiesAlive--;
        Debug.Log("Enemy Destroyed");
    }

    public void SpawnEnemy()
    {
        Vector2 pointoncircle = startingpoint + Random.insideUnitCircle.normalized * SpawnRadius;


        float RanZ = Random.Range(0, 360);

        Instantiate(testmob, pointoncircle, Quaternion.Euler(0, 0, RanZ));
    }

    public int CalculateNewAmount()
    {
        return Mathf.RoundToInt(maxmobs * Mathf.Pow(2, wavesmult));
    }

    public void OnLevelUp()
    {
        maxmobs = CalculateNewAmount();
        SpawnPeriod -= 0.4f;
        if (SpawnPeriod <= 0)
        {
            SpawnPeriod = 0.2f;
        }
    }
}
