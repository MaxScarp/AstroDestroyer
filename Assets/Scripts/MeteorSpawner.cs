using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waves;
    [SerializeField] bool looping = false;

    int waveIndex = 0;

    IEnumerator Start()
    {
        while(looping)
        {
            yield return StartCoroutine(SpawnAllWaves());
        }
    }

    IEnumerator SpawnAllWaves()
    {
        for(int i = waveIndex; i < waves.Count; i++)
        {
            WaveConfig currentWave = waves[i];
            yield return StartCoroutine(SpawnAllMeteorsInWave(currentWave));
        }
    }

    IEnumerator SpawnAllMeteorsInWave(WaveConfig currentWave)
    {
        for(int i = 0; i < currentWave.GetNumberOfMeteor(); i++)
        {
            int random = Random.Range(0, currentWave.GetMeteorPrefabs().Count);
            var meteorClone = Instantiate(currentWave.GetMeteorPrefabs()[random], currentWave.GetWaypoints()[0].transform.position, currentWave.GetMeteorPrefabs()[random].transform.rotation);
            meteorClone.GetComponent<MeteorPathing>().SetWaveConfig(currentWave);
            yield return new WaitForSeconds(currentWave.GetTimeOfSpawn());
        }
    }
}
