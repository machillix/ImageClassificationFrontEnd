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

using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// Only for Demo purpose
/// </summary>
public class RestCommunication : MonoBehaviour
{

    /// <summary>
    /// Convert Texture2D to Base64 string
    /// </summary>
    /// <param name="texture2D"></param>
    /// <returns>Returns base64 string</returns>
    public static string Textute2DToBase64(Texture2D texture2D)
    {
        byte[] bytes = texture2D.EncodeToPNG();
        return Convert.ToBase64String(bytes);
    }
    
    /// <summary>
    /// Only for demo purpose
    /// </summary>
    /// <param name="e"></param>
    /// <returns></returns>
    public IEnumerator Send(string base64)
    {
        // Send json to backend
        using (UnityWebRequest www = UnityWebRequest.Post("http://127.0.0.1:8888", "{ \"img\": \""+base64+"\"}", "application/json"))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
            }
        }
    }
}
