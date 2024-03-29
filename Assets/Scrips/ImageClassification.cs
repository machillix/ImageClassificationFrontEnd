/******************************************************************************
* File         : ImageClassification.cs
* Authors      : Toni Westerlund (MaChilli/machillix)
* Lisence      : MIT Licence
* Copyright    : Toni Westerlund (MaChilli/machillix)
* 
 * MIT License
* 
 * Copyright (c) 2024 Toni Westerlund (MaChilli/machillix)
* 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
* of this software and associated documentation files (the "Software"), to deal
* in the Software without restriction, including without limitation the rights
* to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
* copies of the Software, and to permit persons to whom the Software is
* furnished to do so, subject to the following conditions:
* 
 * The above copyright notice and this permission notice shall be included in all
* copies or substantial portions of the Software.
* 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
* IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
* FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
* AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
* LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
* OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
* SOFTWARE.
*****************************************************************************/
using UnityEngine;

public class ImageClassification : MonoBehaviour
{

    /// <summary>
    /// Reference to screen shot Class
    /// </summary>
    private ScreenShot screenShot;

    /// <summary>
    /// Reference to Rest communication Class
    /// </summary>
    private RestCommunication restCommunication;


    /// <summary>
    /// Unity calls Awake when an enabled script instance is being loaded.
    /// </summary>
    void Awake()
    {
        screenShot = GetComponent<ScreenShot>();
        if(null == screenShot)
        {
            this.gameObject.SetActive(false);
        }

        restCommunication = GetComponent<RestCommunication>();
        if(null == restCommunication)
        {
            this.gameObject.SetActive(false);
        }

    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.B)){
            Texture2D texture2D = screenShot.TakePhoto();
            string base64Texture = RestCommunication.Textute2DToBase64(texture2D);
            StartCoroutine(restCommunication.Send(base64Texture));
        }
    }
}
