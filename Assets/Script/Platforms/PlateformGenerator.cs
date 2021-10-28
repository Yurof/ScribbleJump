using UnityEngine;

public class PlateformGenerator : MonoBehaviour
{
    public GameObject greenPlateform;
    public GameObject brownPlateform;
    public GameObject bluePlateform;

    public GameObject spring;
    public GameObject hat;
    public GameObject jetpack;

    public GameObject blackHole;
    public GameObject noahMonster;
    public GameObject rachelMonster;

    public GameObject player;
    public float bluePlateformPercent = 0.1f;

    public float jetpackPercent = 0f;
    public float hatPercent = 0f;
    public float springPercent = 0.05f;

    public float blackHolePercent = 0f;
    public float noahPercent = 0.001f;
    public float RachelPercent = 0.5f;

    private float playerpastos;
    private float randomGreen;
    private float highest;
    private float var1 = 5.5f;

    //private Vector2 spawnpos;
    // Start is called before the first frame update
    private void Start()
    {
        playerpastos = player.transform.position.y;
        Vector3 spawnpos = new Vector3();
        spawnpos.y += 1;
        spawnpos = Generate2(spawnpos);
        highest = spawnpos.y;
    }

    // Update is called once per frame
    private void Update()
    {
        Vector3 currentpos = player.transform.position;
        Vector3 spawnpos = new Vector3();
        if (currentpos.y - playerpastos > highest - var1)
        {
            var1 = 4f;
            playerpastos = currentpos.y;
            spawnpos = player.transform.position;
            spawnpos.y += 5;
            spawnpos = Generate2(spawnpos);
            highest = spawnpos.y - player.transform.position.y;
        }
    }

    private Vector3 Generate(Vector3 spawnpos)
    {
        for (int i = 0; i < 15; i++)
        {
            spawnpos.y += Random.Range(0.5f, 0.7f);
            spawnpos.x = Random.Range(-2.2f, 2.2f);
            float randomg = Random.Range(0.0f, 1.0f);

            if (randomg < 0.001 && spawnpos.y > 10f)
            {
                Instantiate(blackHole, spawnpos, Quaternion.identity);
            }
            else if (0.02 <= randomg && randomg < 0.08)
            {
                Instantiate(bluePlateform, spawnpos, Quaternion.identity);
            }
            else if (0.08 <= randomg && randomg < 0.20)
            {
                Instantiate(brownPlateform, spawnpos, Quaternion.identity);
            }
            else
            {
                randomGreen = Random.Range(0.0f, 1.0f);
                Instantiate(greenPlateform, spawnpos, Quaternion.identity);
                if (springPercent > randomGreen)
                {
                    Debug.Log(randomGreen);
                    Debug.Log(springPercent);
                    Debug.Log("create monster");
                    Instantiate(noahMonster, new Vector3(spawnpos.x, spawnpos.y + 0.65f, spawnpos.z), Quaternion.identity);
                }
                else
                {
                    if (springPercent + springPercent > randomGreen) Instantiate(spring, new Vector3(spawnpos.x, spawnpos.y + 0.2f, spawnpos.z), Quaternion.identity);
                }
            }
        }
        return spawnpos;
    }

    private Vector3 Generate2(Vector3 spawnpos)
    {
        Vector3 spawnpos2 = spawnpos;
        for (int i = 0; i < 20; i++)
        {
            spawnpos.y += Random.Range(0.3f, 0.5f);
            spawnpos.x = Random.Range(-2.2f, 2.2f);

            float randomPlateformType = Random.Range(0.0f, 1.0f);
            float randomMonsterOrObject = Random.Range(0.0f, 1.0f);
            //float randomMonsterSpawn = Random.Range(0.0f, 1.0f);

            if (randomPlateformType < bluePlateformPercent)
            {
                Instantiate(bluePlateform, spawnpos, Quaternion.identity);
            }
            else
            {
                Instantiate(greenPlateform, spawnpos, Quaternion.identity);
                spawnpos.y += 0.5f;

                //Debug.Log(randomMonsterOrObject);
                if (randomMonsterOrObject < hatPercent)
                {
                    Debug.Log("hat");
                    spawnpos.y -= 0.2f;
                    Instantiate(hat, spawnpos, Quaternion.identity);
                    spawnpos.y -= 0.3f;
                }
                else if (randomMonsterOrObject < hatPercent + jetpackPercent)
                {
                    Debug.Log("jetpack");
                    Instantiate(jetpack, spawnpos, Quaternion.identity);
                    spawnpos.y -= 0.5f;
                }
                else if (randomMonsterOrObject < hatPercent + jetpackPercent + springPercent)
                {
                    Debug.Log("spring");
                    spawnpos.y -= 0.4f;
                    Instantiate(spring, spawnpos, Quaternion.identity);
                    spawnpos.y -= 0.1f;
                }
                else if (randomMonsterOrObject < hatPercent + jetpackPercent + springPercent + noahPercent)
                {
                    Debug.Log("noahMonster");
                    Instantiate(noahMonster, spawnpos, Quaternion.identity);
                    spawnpos.y -= 0.5f;
                }
                else if (randomMonsterOrObject < hatPercent + jetpackPercent + springPercent + noahPercent + RachelPercent)
                {
                    Debug.Log("rachelMonster");
                    spawnpos.y += 0.3f;
                    Instantiate(rachelMonster, spawnpos, Quaternion.identity);
                    spawnpos.y -= 0.7f;
                }
                else if (randomMonsterOrObject > hatPercent + jetpackPercent + springPercent + noahPercent + RachelPercent)
                {
                    Debug.Log("plop");
                }
            }
        }

        for (int i = 0; i < 10; i++)
        {
            spawnpos2.y += Random.Range(1f, 3f);
            spawnpos2.x = Random.Range(-2.2f, 2.2f);

            float randomPlateformType = Random.Range(0.0f, 1.0f);
            float randomMonsterOrObject = Random.Range(0.0f, 1.0f);
            //float randomMonsterSpawn = Random.Range(0.0f, 1.0f);

            if (randomPlateformType < blackHolePercent)
            {
                Instantiate(blackHole, spawnpos2, Quaternion.identity);
            }
            else
            {
                Instantiate(brownPlateform, spawnpos2, Quaternion.identity);
            }
        }

        return spawnpos;
    }

/*    private void OnBecameInvisible()
    {
        Destroy(greenPlateform);
        Destroy(bluePlateform);
        Destroy(brownPlateform);
        Destroy(blackHole);
        Destroy(noahMonster);
    }*/
}