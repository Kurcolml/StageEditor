using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class SpawnPrefabs : MonoBehaviour {

    public bool spawn;
    public bool destroy;
    public int cantidad;
    public List <GameObject> prefab;
    public List<GameObject> childs;
    public Vector3 rango;
    public float min;
    public float height;
    public float max;
    public bool desparentar;
    public bool parentar;

    void Start()
    {

    }


    void Update()
    {



        if (spawn)
        {
            spawn = false;
            for (int i = 0; i < cantidad; i++)
            {
                rango = new Vector3(Random.Range(min, max), transform.position.y - height, Random.Range(min, max));
                foreach (GameObject item in prefab)
                {
                    GameObject obj = Instantiate(item, transform.position + rango, Quaternion.Euler(0, 0, 0)) as GameObject;
                    var x = Random.Range(-1, 1);
                    if (x < 0)
                    {
                        obj.transform.Rotate(0, 90, 0);
                        obj.transform.localScale = new Vector3(Random.Range(3, 6), 1, 1);
                    }

                    obj.transform.parent = transform;
                } 
            }
        }
        if (destroy)
        {
            destroy = false;
            for (int i = 0; i < transform.childCount; i++)
            {

                DestroyImmediate(transform.GetChild(i).gameObject);
            }
        }
        if (desparentar)
        {
            desparentar = false;
            for (int i = 0; i < transform.childCount; i++)
            {
                childs.Add(transform.GetChild(i).gameObject);
                transform.GetChild(i).parent = null;
            }
        }
        if (parentar)
        {
            parentar = false;
            for (int i = 0; i < childs.Count; i++)
            {
                childs[i].gameObject.transform.SetParent(transform);
            }
        }

    }
}
