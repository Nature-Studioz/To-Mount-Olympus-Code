using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject ob;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawner());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Spawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            GameObject obs = Instantiate(ob) as GameObject;
            obs.transform.position = new Vector2(Random.Range(-8f, 8f), 10f);


        }
    }
}
