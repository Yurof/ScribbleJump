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
    public float maxNumberOfBrownP = 5;

    private float playerpastos;
    private float highest;
    private float var1 = 5.5f;

    private void Start()
    {
        playerpastos = player.transform.position.y;
        Vector3 spawnpos = new Vector3();
        spawnpos.y += 1;
        spawnpos = Generate(spawnpos, true);
        highest = spawnpos.y;
    }

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
            spawnpos = Generate(spawnpos, false);
            highest = spawnpos.y - player.transform.position.y;
        }
    }

    private Vector3 Generate(Vector3 spawnpos, bool start)
    {
        Vector3 spawnpos2 = spawnpos;
        for (int i = 0; i < 20; i++)
        {
            spawnpos.y += Random.Range(0.3f, 0.5f);
            spawnpos.x = Random.Range(-2.2f, 2.2f);

            float randomPlateformType = Random.Range(0.0f, 1.0f);
            float randomMonsterOrObject = Random.Range(0.0f, 1.0f);

            if (randomPlateformType < bluePlateformPercent)
            {
                Instantiate(bluePlateform, spawnpos, Quaternion.identity);
            }
            else
            {
                Instantiate(greenPlateform, spawnpos, Quaternion.identity);
                spawnpos.y += 0.5f;

                if (randomMonsterOrObject < hatPercent)
                {
                    spawnpos.y -= 0.2f;
                    Instantiate(hat, spawnpos, Quaternion.identity);
                    spawnpos.y -= 0.3f;
                }
                else if (randomMonsterOrObject < hatPercent + jetpackPercent)
                {
                    Instantiate(jetpack, spawnpos, Quaternion.identity);
                    spawnpos.y -= 0.5f;
                }
                else if (randomMonsterOrObject < hatPercent + jetpackPercent + springPercent)
                {
                    spawnpos.y -= 0.4f;
                    Instantiate(spring, spawnpos, Quaternion.identity);
                    spawnpos.y -= 0.1f;
                }
                else if (randomMonsterOrObject < hatPercent + jetpackPercent + springPercent + noahPercent && !start)
                {
                    Instantiate(noahMonster, spawnpos, Quaternion.identity);
                    spawnpos.y -= 0.5f;
                }
                else if (randomMonsterOrObject < hatPercent + jetpackPercent + springPercent + noahPercent + RachelPercent && !start)
                {
                    spawnpos.y += 0.3f;
                    Instantiate(rachelMonster, spawnpos, Quaternion.identity);
                    spawnpos.y -= 0.7f;
                }
            }
        }

        for (int i = 0; i < maxNumberOfBrownP; i++)
        {
            spawnpos2.y += Random.Range(1f, 3f);
            spawnpos2.x = Random.Range(-2.2f, 2.2f);

            float randomPlateformType = Random.Range(0.0f, 1.0f);

            if (randomPlateformType < blackHolePercent && !start)
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
}