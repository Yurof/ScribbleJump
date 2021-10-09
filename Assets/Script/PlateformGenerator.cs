using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateformGenerator : MonoBehaviour
{   
    public GameObject plateformPrefabgreen;
    public GameObject plateformPrefabbrown;
    public GameObject plateformPrefabblue;
    public GameObject spring;
    public GameObject monsterPrefab;
    //private Vector2 spawnpos;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 spawnpos = new Vector3();
        for (int i = 0; i < 100; i++)
        {
            spawnpos.y += Random.Range(0.5f, 1f);
            spawnpos.x = Random.Range(-2.2f, 2.2f);
            float randomg = Random.Range(0f, 1f);

            if (randomg < 0.02)
            {
                Instantiate(monsterPrefab, spawnpos, Quaternion.identity);
            }
            else if (0.02 <= randomg && randomg < 0.08)
            {
                Instantiate(plateformPrefabblue, spawnpos, Quaternion.identity);
            }
            else if (0.08 <= randomg && randomg < 0.20)
            {
                Instantiate(plateformPrefabbrown, spawnpos, Quaternion.identity);
            }
            else
            {
                Instantiate(plateformPrefabgreen, spawnpos, Quaternion.identity);
                if (0.35 <= randomg && randomg < 0.45)
                {
                    spawnpos.y += 0.2f;
                    Instantiate(spring, spawnpos, Quaternion.identity);
                }
            }

        }

    }

    void OnBecameInvisible()
    {
        Destroy(plateformPrefabgreen);
        Destroy(plateformPrefabblue);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
