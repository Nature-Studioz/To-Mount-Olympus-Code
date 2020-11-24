using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextApper : MonoBehaviour
{

    string[] text = {" ", " ",  "T", "o", " ", "M", "o", "u", "n", "t" };

    string textss = "";
    public TextMeshProUGUI texts;
    public TextMeshProUGUI textsTwo;
    float a = -1f;
    void Start()
    // Start is called before the first frame upda
    {
        StartCoroutine(addText());
        StartCoroutine(Stop());

    }

    // Update is called once per frame
    void Update()
    {
        texts.text = textss;
        textsTwo.rectTransform.Translate(0f, a, 0f);
      
       

        
    }

    IEnumerator addText()
    {
        WaitForSeconds wait = new WaitForSeconds(0.1f);
        foreach(string i in text)
        {
            textss += i;
            yield return wait;

        }
    }

    IEnumerator Stop()
    {
        yield return new WaitForSeconds(3);
        a = 0f;

    }
}
