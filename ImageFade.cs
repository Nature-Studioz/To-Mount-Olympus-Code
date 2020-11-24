using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

public class ImageFade : MonoBehaviour
{

    // the image you want to fade, assign in inspector
    public Image img;
    public bool istrue;
    public GameObject obss;
    public TextMeshProUGUI mesh;
    public TextMeshProUGUI mesh2;
    public Canvas canvas;
    public string Scene;
    public bool isdone = false;
    Vector2 pos1;
    float b = 1;
    public bool ishit = true;

    public void Start()
    {

        // fades the image out when you click
        StartCoroutine(IsDone());
        for (float i = 1; i >= 0; i -= 0.009f)
        {
            // set color with i as alpha
            Debug.Log(i);
            b -= 0.06f;
            mesh2.text += "a";
            img.color = new Color(0.1f, 0.1f, 0.1f, i);

            img.transform.SetAsLastSibling();
           

        }




    }
    private void Update()
    {
   
        
        if (b <= 0)
        {
            isdone = true;
            b = 2;
        }
        if (isdone)
        {
            img.transform.SetSiblingIndex(1);
        }
    }

    IEnumerator IsDone()
    {
        yield return new WaitForSeconds(2);

    }

    public void FadeAway()
    {
        if (ishit)
        {
            ishit = false;
            StartCoroutine(FadeImage(istrue));
            StartCoroutine(MoveLecel());
            StartCoroutine(Kills());
        }
    }

    IEnumerator MoveLecel()
    {
        yield return new WaitForSeconds(4);

        SceneManager.LoadScene(Scene);


    }



    IEnumerator Kills()
    {
        yield return new WaitForSeconds(4);

        Destroy(obss.gameObject);


    }

    IEnumerator FadeImage(bool fadeAway)
    {
        // fade from opaque to transparent
        if (fadeAway)
        {
            // loop over 1 second backwards
            for (float i = 1; i >= 0; i -= 0.009f)
            {
                // set color with i as alpha
                Debug.Log(i);
                b -= 0.06f;
                mesh2.text += "a";
                img.color = new Color(0.1f, 0.1f, 0.1f, i);
               
                img.transform.SetAsLastSibling();
                yield return null;
                
            }
        }
        // fade from transparent to opaque
        else
        {
            // loop over 1 second
            for (float i = 0; i <= 1; i += 0.009f)
            {
                // set color with i as alpha
                img.transform.parent = canvas.transform;
                isdone = false;
                img.transform.SetAsLastSibling();
                
                img.color = new Color(0.1f, 0.1f, 0.1f, i);

                yield return null;
            }
        }
    }
}