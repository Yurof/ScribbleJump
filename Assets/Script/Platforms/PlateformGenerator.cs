using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateformGenerator : MonoBehaviour
{   
    public GameObject plateformPrefabgreen;
    public GameObject plateformPrefabbrown;
    public GameObject plateformPrefabblue;
    public GameObject spring;
    public GameObject monsterPrefab1;
    public GameObject monsterPrefab2;
    public GameObject player;
    private float playerpastos;
    private float highest;
    private float var1=5.5f;
    public float springpercent =0.1f;
    public float mosnterpercent = 0.1f;
    //private Vector2 spawnpos;
    // Start is called before the first frame update
    void Start()
    {
        playerpastos = player.transform.position.y;
        Vector3 spawnpos = new Vector3();
        spawnpos = Generate(spawnpos);
        
        highest = spawnpos.y;


    }

    void OnBecameInvisible()
    {
        Destroy(plateformPrefabgreen);
        Destroy(plateformPrefabblue);

    }

    // Update is called once per frame
    void Update()
    {

        
        Vector3 currentpos = player.transform.position;
        Vector3 spawnpos = new Vector3();
        if (currentpos.y- playerpastos> highest- var1)
        {
            Debug.Log("in if");
            var1 = 4f;
            playerpastos = currentpos.y;
            spawnpos = player.transform.position;
            spawnpos.y += 5;
            spawnpos=Generate(spawnpos);
            highest = spawnpos.y - player.transform.position.y;
        }

    }

    Vector3 Generate(Vector3 spawnpos)
    {
        for (int i = 0; i < 15; i++)
        {
            spawnpos.y += Random.Range(0.5f, 0.7f);
            spawnpos.x = Random.Range(-2.2f, 2.2f);
            float randomg = Random.Range(0f, 1f);

            if (randomg < 0.02)
            {
                Instantiate(monsterPrefab1, spawnpos, Quaternion.identity);
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
                float r = Random.Range(0f, 1f);
                Instantiate(plateformPrefabgreen, spawnpos, Quaternion.identity);
                if (springpercent> r)
                {
                    Instantiate(spring, new Vector3(spawnpos.x,spawnpos.y+0.2f,spawnpos.z), Quaternion.identity);
                }
                else if(mosnterpercent+ springpercent > r)
                {
                    //Instantiate(monsterPrefab2, new Vector3(spawnpos.x, spawnpos.y + 0.01f, spawnpos.z), Quaternion.identity);
                }

            }
        }
        return spawnpos;
    }
    
}
