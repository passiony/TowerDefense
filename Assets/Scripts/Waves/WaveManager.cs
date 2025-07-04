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
    public Path path;
    public Wave[] waves;

    private int index;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(delay);
        var wave = waves[index];
        StartCoroutine(SpawnWave(wave));
    }

    private IEnumerator SpawnWave(Wave wave)
    {
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
}