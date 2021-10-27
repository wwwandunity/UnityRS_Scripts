using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class RandomCubesGenerator : MonoBehaviour
{   
    // Zadanie 1
    // In this script it is assured that Unity base cube 1x1x1 object is going to spawn in the Unity plane (with position in the center of the plane, not in the corner like
    // in ProBuilder plane)

    List<Vector3> positions = new List<Vector3>();
    public float delay = 3.0f;
    int objectCounter = 0;
    public int numberOfObjects = 5;
    public GameObject block;
    static System.Random rnd = new System.Random();

    public Material redMaterial;
    public Material greenMaterial;
    public Material blueMaterial;
    public Material yellowMaterial;
    public Material purpleMaterial;
    public List<Material> materials;

    void Start()
    {
        redMaterial = Resources.Load("Materials/RedMaterial", typeof(Material)) as Material;
        greenMaterial = Resources.Load("Materials/GreenMaterial", typeof(Material)) as Material;
        blueMaterial = Resources.Load("Materials/BlueMaterial", typeof(Material)) as Material;
        yellowMaterial = Resources.Load("Materials/YellowMaterial", typeof(Material)) as Material;
        purpleMaterial = Resources.Load("Materials/PurpleMaterial", typeof(Material)) as Material;
        materials = new List<Material> { redMaterial, greenMaterial, blueMaterial, yellowMaterial, purpleMaterial };

        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Bounds bounds = mesh.bounds;

        var XrangeLimit = bounds.extents.x * 2 * transform.localScale.x;
        var ZrangeLimit = bounds.extents.z * 2 * transform.localScale.z;
        List<int> pozycje_x = new List<int>(Enumerable.Range(0, (int)XrangeLimit).OrderBy(x => Guid.NewGuid()).Take(this.numberOfObjects));
        List<int> pozycje_z = new List<int>(Enumerable.Range(0, (int)ZrangeLimit).OrderBy(x => Guid.NewGuid()).Take(this.numberOfObjects));

        var startX = transform.position.x - bounds.extents.x * transform.localScale.x + 0.5f;
        var startZ = transform.position.z - bounds.extents.z * transform.localScale.z + 0.5f;

        for (int i = 0; i < numberOfObjects; i++)
        {
            this.positions.Add(new Vector3(startX + pozycje_x[i], transform.position.y + 3, startZ + pozycje_z[i]));
        }
        foreach (Vector3 elem in positions)
        {
            Debug.Log(elem);
        }
        // uruchamiamy coroutine
        StartCoroutine(GenerujObiekt());
    }

    void Update()
    {

    }

    IEnumerator GenerujObiekt()
    {
        Debug.Log("wywołano coroutine");
        foreach (Vector3 pos in positions)
        {
            int randomNumber = rnd.Next(this.materials.Count);
            var new_cube = Instantiate(this.block, this.positions.ElementAt(this.objectCounter++), Quaternion.identity);
            new_cube.GetComponent<MeshRenderer>().material = this.materials[randomNumber];

            yield return new WaitForSeconds(this.delay);
        }
        // zatrzymujemy coroutine
        StopCoroutine(GenerujObiekt());
    }
}
