using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class Zadanie5 : MonoBehaviour
{
    // Assumptions:
    // 1. Plane is 10x10 on (0, 0, 0) position
    // 2. Cubes are 1x1x1 size

    public GameObject myPrefab;
    public System.Random randomGenerator = new System.Random();
    public List<List<float>> coordinates = new List<List<float>>();


    void Start()
    {
        GenerateRandomUniqueCoordinates();
        InstantiateCubes(coordinates);
    }

    void GenerateRandomUniqueCoordinates()
    {
        for (int i = 0; i < 10; i++)
        {
            List<float> newPair = new List<float>();
            bool isNotUnique = true;
            while (isNotUnique)
            {
                isNotUnique = false;
                newPair = new List<float>() { randomGenerator.Next(-5, 5), randomGenerator.Next(-5, 5) };

                foreach (var pair in coordinates)
                {
                    var difference = pair.Except(newPair).ToList();
                    if (difference.Any() == false)
                        isNotUnique = true;
                }
            }

            coordinates.Add(newPair);
        }
    }

    void InstantiateCubes(List<List<float>> coordinates)
    {
        foreach (var pair in coordinates)
        {
            Instantiate(myPrefab, new Vector3(pair[0] + 0.5f, 0.5f, pair[1] + 0.5f), Quaternion.identity);
        }
    }
}
