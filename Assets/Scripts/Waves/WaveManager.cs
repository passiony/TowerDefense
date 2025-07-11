using System.Collections;
using UnityEngine;

/// <summary>
/// 波次管理器
/// </summary>
public class WaveManager : MonoBehaviour
{
    public float delay;
    public float interval;
    public Transform bornPoint;
    private Path path;
    public Wave[] waves;

    private int index;
    public static WaveManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    IEnumerator Start()
    {
        GameForm.Instance.SetWaveNum(0, waves.Length);
        path = FindObjectOfType<Path>();
        yield return new WaitForSeconds(delay);
        var wave = waves[index];
        StartCoroutine(SpawnWave(wave));
    }

    private IEnumerator SpawnWave(Wave wave)
    {
        GameForm.Instance.SetWaveNum(index + 1, waves.Length);
        for (int i = 0; i < wave.enemyCount; i++)
        {
            yield return new WaitForSeconds(wave.interval);
            var go = Instantiate(wave.enemy);
            go.transform.position = bornPoint.position;
            go.transform.rotation = bornPoint.rotation;
            go.GetComponent<EnemyMove>().StartMove(path);
        }

        index++;
        if (index < waves.Length)
        {
            yield return new WaitForSeconds(interval);
            StartCoroutine(SpawnWave(waves[index]));
        }
    }

    public void CheckGameOver()
    {
        if (index >= waves.Length)
        {
            var enemys = FindObjectsOfType<Enemy>();
            bool allDead = true;
            foreach (var enemy in enemys)
            {
                if (enemy.HP > 0)
                {
                    allDead = false;
                    break;
                }
            }

            if (allDead)
            {
                var player = GameObject.FindObjectOfType<Player>();
                if (player.HP > 0)
                {
                    GameOver.Instance.ShowOver(true);
                }
            }
        }
    }
}