using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawn : MonoBehaviour
{
    public GameObject box_Prefab;

    void Start()
    {

    }

    public void Update()
    {
        
    }

    public void SpawnBox()
    {
        GameObject box_obj = Instantiate(box_Prefab);

        Vector3 temp = transform.position;
        temp.z = 0f;

        box_obj.transform.position = temp;
    }
}
