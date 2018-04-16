using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pyramid : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        int maxHeight = 10;
        SpringJoint spring;
        GameObject gameObject;

        for (int height = 0; height < maxHeight; height++)
        {
            int length = maxHeight - height;
            for (int x = -length; x <= length; x++)
            {
                for (int z = -length; z <= length; z++)
                {
                    gameObject = Tools.MakeCapsule(x - 30, height, z - 40);
                    gameObject.transform.localScale = new Vector3(1f, 0.5f, 1f);
                    spring = gameObject.AddComponent<SpringJoint>();
                }
            }
        }
    }
}
public class Tools : MonoBehaviour
{
    public static GameObject capsulePrefab;
    public static GameObject capsuleContainer;
    public static List<GameObject> capsules;
    public static GameObject cylinder;
    public static int Count = 0;

    public static GameObject MakeCapsule(Vector3 position, Color color, float size)
    {
        Count++;
        if (capsuleContainer == null)
        {
            capsuleContainer = new GameObject("cylinder container");
            capsules = new List<GameObject>();
        }

        cylinder = Instantiate(GetCubePrefab()) as GameObject;
        capsules.Add(cylinder);
        cylinder.transform.position = position;
        cylinder.transform.parent = capsuleContainer.transform;
        cylinder.name = "cylinder " + Count;

        cylinder.GetComponent<Renderer>().material.color = color;
        cylinder.transform.localScale = new Vector3(size, size, size);

        return cylinder;
    }

    public static GameObject MakeCapsule(float x, float y, float z)
    {
        return MakeCapsule(x, y, z, Color.yellow, 1f);
    }

    public static GameObject MakeCapsule(float x, float y, float z, Color color, float size)
    {
        return MakeCapsule(new Vector3(x, y, z), color, size);
    }

    private static GameObject GetCubePrefab()
    {
        if (capsulePrefab == null)
            capsulePrefab = Resources.Load("Cylinder") as GameObject;
        return capsulePrefab;
    }
}
