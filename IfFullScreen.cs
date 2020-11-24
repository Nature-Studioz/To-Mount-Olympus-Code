using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class IfFullScreen : MonoBehaviour
{

    public TextMeshProUGUI Txt1;
    public TextMeshProUGUI Txt2;
    public TextMeshProUGUI Txt3;
    public TextMeshProUGUI Txt4;
    public TextMeshProUGUI Txt5;
    public TextMeshProUGUI Txt6;
    public TextMeshProUGUI Txt7;
    public TextMeshProUGUI Txt8;
    public TextMeshProUGUI Txt9;
    public TextMeshProUGUI Txt10;
    public TextMeshProUGUI Txt11;
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Screen.fullScreen)
        {
            Txt1.fontSize = 66;
            Txt2.fontSize = 44;
            Txt3.fontSize = 46;
            Txt4.fontSize = 46;
            Txt5.fontSize = 46;
            Txt6.fontSize = 36;
            Txt7.fontSize = 46;
            Txt8.fontSize = 46;
            Txt9.fontSize = 46;
            Txt10.fontSize = 46;
            Txt11.fontSize = 46;
        }

        else
        {
            Txt1.fontSize = 56;
            Txt2.fontSize = 34;
            Txt3.fontSize = 36;
            Txt4.fontSize = 36;
            Txt5.fontSize = 36;
            Txt6.fontSize = 26;
            Txt7.fontSize = 36;
            Txt8.fontSize = 36;
            Txt9.fontSize = 36;
            Txt10.fontSize = 36;
            Txt11.fontSize = 36;
        }
    }
}
