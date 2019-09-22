// Date   : 21.09.2019 18.15
// Project: Game
// Author : bradur

using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class SpawnerManager : MonoBehaviour
{
    [SerializeField]
    private GameData gameData;
    [SerializeField]
    private EnemyPrefabConfig enemyPrefabConfig;
    [SerializeField]
    private GameObject cargoTarget;
    [SerializeField]
    private Transform groundSpawnPoint;
    [SerializeField]
    private Transform midSpawnPoint;
    [SerializeField]
    private Transform highSpawnPoint;

    private bool waveOngoing = false;
    private int currentWave = -1;
    private float timeWaveStarted = 0;

    private bool groupOngoing = false;
    private int currentGroup = -1;
    private float timeGroupStarted = 0;
    private bool groupStarted = false;

    private WaveData currentWaveData = null;
    private Group currentGroupData = null;

    private List<GameObject> activeEnemies = new List<GameObject>();

    void Start()
    {

    }


    void StartWave()
    {
        currentWaveData = gameData.Waves[currentWave];

        waveOngoing = true;
        groupOngoing = false;
        groupStarted = false;

        timeWaveStarted = Time.fixedTime;
        timeGroupStarted = 0;
        currentGroup = -1;

        UIManager.main.ToggleWarning(true);
    }

    void StartGroup()
    {
        currentGroupData = currentWaveData.Groups[currentGroup];
        groupOngoing = true;
        timeGroupStarted = Time.fixedTime;
    }

    void EndWave()
    {
        if (waveOngoing) {
            UIManager.main.ShowShop();
        }
    }

    public void StartNextWave()
    {
        UIManager.main.HideShop();
        waveOngoing = false;
    }

    void GameEnd()
    {

    }
    void FixedUpdate()
    {
        if (!waveOngoing)
        {
            currentWave++;
            if (currentWave >= gameData.Waves.Count)
            {
                GameEnd();
            }
            else
            {
                StartWave();
            }
        }
        else
        {
            if (!groupOngoing)
            {
                currentGroup++;
                if (currentGroup >= currentWaveData.Groups.Count)
                {
                    // if there are enemies left, do not proceed to the next wave
                    if (activeEnemies.Count == 0)
                    {
                        EndWave();
                    }
                }
                else
                {
                    StartGroup();
                }
            }
            else if (!groupStarted)
            {
                if (Time.fixedTime - timeGroupStarted > currentGroupData.startDelay)
                {
                    UIManager.main.ToggleWarning(false);

                    groupStarted = true;
                    StartCoroutine(SpawnGroup());
                }
            }
        }
        /*for (int index = activeEnemies.Count; index > 0; index -= 1)
        {
            if (activeEnemies[index] == null)
            {
                activeEnemies.Remove(activeEnemies[index]);
            }
        }*/
        activeEnemies = activeEnemies.Where(x => x != null).ToList();
    }

    // Coroutine that spawns a group
    private IEnumerator SpawnGroup()
    {
        foreach (Enemy enemy in currentGroupData.enemies)
        {
            EnemyPrefabMapping prefabMapping = enemyPrefabConfig.EnemyPrefabs
                .Where(x => x.type == enemy.type)
                .FirstOrDefault();


            if (prefabMapping == null)
            {
                continue;
            }

            GameObject prefab = prefabMapping.prefab;

            GameObject obj = Instantiate(prefab);
            //flying poop code
            if (enemy.type == EnemyType.Flying)
            {
                Flying flyingObj = obj.GetComponent<Flying>();
                if (flyingObj != null)
                {
                    flyingObj.SetDropOffTarget(cargoTarget);
                }
            }

            if (enemy.spawn == SpawnPoint.Mid)
            {
                obj.transform.position = midSpawnPoint.position;
            }
            else if (enemy.spawn == SpawnPoint.High)
            {
                obj.transform.position = highSpawnPoint.position;
            }
            else
            {
                obj.transform.position = groundSpawnPoint.position;
            }
            activeEnemies.Add(obj);
            yield return new WaitForSeconds(currentGroupData.interval);
        }

        groupOngoing = false;
        groupStarted = false;

        yield return null;
    }
}
