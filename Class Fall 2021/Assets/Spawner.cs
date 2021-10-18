using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    const int NUM_COINS = 10;
    [SerializeField] GameObject coin;

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Spawn()
    {
        int xMin = -12;
        int xMax = 10;
        int yMin = -1;
        int yMax = 7;

        for (int i = 0; i < NUM_COINS; i++)
        {
            Vector2 position = new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax));
            Instantiate(coin, position, Quaternion.identity);
        }

    }

    void Spawn2()
    {
        Vector2 position = new Vector2(-9, 2);
        for (int i = 0; i < NUM_COINS; i++)
        {
            Instantiate(coin, position, Quaternion.identity);
            position = new Vector2 (position.x + Random.Range(-5, 5), position.y + Random.Range(-3, 3));
        }
    }
}
