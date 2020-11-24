using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToAndBack : MonoBehaviour
{
    public Image img;
    public Image img2;
    Vector2 pos1;
    // Start is called before the first frame update
    void Start()
    {
        pos1 = img.transform.position; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void To()
    {
        img.transform.position = new Vector2(1000f, 1000f);
        img2.transform.position = new Vector2(pos1.x, pos1.y);
    }

    public void Back()
    {
        img2.transform.position = new Vector2(1000f, 1000f);
        img.transform.position = new Vector2(pos1.x, pos1.y);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
