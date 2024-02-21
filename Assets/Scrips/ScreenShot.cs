/******************************************************************************
* File         : ScreenShot.cs
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

using System.Collections;
using UnityEngine;
using System;
using UnityEngine.Networking;

/// <summary>
/// The class offers the functionality to take a screen shot from the game
/// camera view
/// </summary>
public class ScreenShot : MonoBehaviour
{

    /// <summary>
    /// Take screenshot by using main camera
    /// </summary>
    /// <returns>Screenshot (Texture2D)</returns>
    public Texture2D TakePhoto()
    {

        RenderTexture rt = new RenderTexture(640, 480, 24);
        Camera.main.targetTexture = rt;
        Texture2D screenShot = new Texture2D(640, 480, TextureFormat.RGB24, false);
        Camera.main.Render();
        RenderTexture.active = rt;
        screenShot.ReadPixels(new Rect(0, 0, 640, 480), 0, 0);
        Camera.main.targetTexture = null;
        RenderTexture.active = null;
        Destroy(rt);

        return screenShot;

    }

}
