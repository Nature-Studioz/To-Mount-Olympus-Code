using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorSpawner : MonoBehaviour
{
    public GameObject ob;
    public float X = 132.31f;
    public float Y = 40.4f;
    public float time = 16f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(9);
            GameObject obs = Instantiate(ob) as GameObject;
            obs.transform.position = new Vector2(X, Y);
            Destroy(obs, time);
        }
    }
}