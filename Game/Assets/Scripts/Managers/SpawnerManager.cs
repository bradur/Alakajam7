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

    void FixedUpdate()
    {
        if (!waveOngoing)
        {
            currentWave++;
            if (currentWave >= gameData.Waves.Count)
            {
                //end the game here!
            }
            else
            {
                // get a new wave
                currentWaveData = gameData.Waves[currentWave];

                waveOngoing = true;
                groupOngoing = false;
                groupStarted = false;

                timeWaveStarted = Time.fixedTime;
                timeGroupStarted = 0;
                currentGroup = -1;

                UIManager.main.ToggleWarning(true);
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
                    if(activeEnemies.Count == 0)
                    {
                        waveOngoing = false;
                    }
                }
                else
                {
                    // get a new group
                    currentGroupData = currentWaveData.Groups[currentGroup];
                    groupOngoing = true;
                    timeGroupStarted = Time.fixedTime;
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

        // wave time duration has gone, next wave starts even if there are enemies left
        if(Time.fixedTime - timeWaveStarted > currentWaveData.Duration)
        {
            waveOngoing = false;
        }
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
            if(enemy.type == EnemyType.Flying)
            {
                Flying flyingObj = obj.GetComponent<Flying>();
                if (flyingObj != null)
                {
                    flyingObj.SetDropOffTarget(cargoTarget);
                }
            }
            yield return new WaitForSeconds(currentGroupData.interval);
        }

        groupOngoing = false;
        groupStarted = false;

        yield return null;
    }
}
