using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoCamera : MonoBehaviour
{

    /// <summary>
    /// Reference to screen shot Class
    /// </summary>
    private ScreenShot screenShot;


    // Start is called before the first frame update
    void Start()
    {

        screenShot = GetComponent<ScreenShot>();
        if(null == screenShot)
        {
            this.gameObject.SetActive(false);
        }

        int i = 0;

        int x = -90;
        int y = 0;

        for(y = 0; y <=360;){

            Texture2D texture2D = screenShot.TakePhoto();

            ScreenShot.SaveTextureAsPNG(texture2D, Application.dataPath + "./../" + i + ".png");

            gameObject.transform.eulerAngles = new Vector3(0,y,0);




            y += 15;
            i++;

        }



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
