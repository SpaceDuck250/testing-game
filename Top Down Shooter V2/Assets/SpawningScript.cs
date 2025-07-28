using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using UnityEditor;

public class SpawningScriptorino : MonoBehaviour
{
    public static SpawningScriptorino instance; // For triggering death event
    public UnityEvent OnEnemyDestroyed;

    public GameObject[] enemies;

    public float SpawnPeriod = 2f;
    public float Timer;

    public int BaseEnemies = 5;
    public int EnemiesLeftToSpawn;
    public int EnemiesAlive;

    public int wave = 1;
    public float wavecooldown = 2.5f;
    public float wavesmult = 0.5f;
    public bool isSpawning = false;

    public Vector2 startingpoint;
    public float SpawnRadius = 5;

    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.red;
        Handles.DrawWireDisc(transform.position, Vector3.forward, SpawnRadius);
    }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        startingpoint = transform.position;
        OnEnemyDestroyed.AddListener(WhenDie);
        StartCoroutine(StartWave());
    }

    private void Update()
    {
        if (!isSpawning)
        {
            return;
        }

        Timer += Time.deltaTime;

        if (Timer >= SpawnPeriod && EnemiesLeftToSpawn > 0)
        {
            Timer = 0;
            EnemiesLeftToSpawn--;
            EnemiesAlive++;
            SpawnEnemy();
        }

        if (EnemiesLeftToSpawn == 0 && EnemiesAlive == 0)
        {
            StopWave();
        }
    }

    public void WhenDie()
    {
        EnemiesAlive--;
        Debug.Log("Enemy Destroyed");
    }

    public void SpawnEnemy()
    {
        Vector2 randomCircle = Random.insideUnitCircle * SpawnRadius;
        Vector2 randomPoint = startingpoint + randomCircle;

        float RanZ = Random.Range(0, 360);
        Quaternion Ran = Quaternion.Euler(0, 0, RanZ);

        Instantiate(enemies[0], randomPoint, Ran);
    }

    public IEnumerator StartWave()
    {
        EnemiesLeftToSpawn = CalculateNewAmount();
        yield return new WaitForSeconds(wavecooldown);
        isSpawning = true;
    }

    public void StopWave()
    {
        isSpawning = false;
        Timer = 0;
        wave++;
        StartCoroutine(StartWave());
    }

    public int CalculateNewAmount()
    {
        return Mathf.RoundToInt(BaseEnemies * Mathf.Pow(wave, wavesmult));
    }
}
