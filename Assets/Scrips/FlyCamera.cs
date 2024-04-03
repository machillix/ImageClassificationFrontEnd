/******************************************************************************
* File         : FlyCamera.cs
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
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Simple Fly Camera / Spectator Camera 
/// </summary>
public class FlyCamera : MonoBehaviour
{

    /// <summary>
    /// Movement Speed
    /// </summary>
    [SerializeField] private float speed = 200f;

    /// <summary>
    /// Mouse Sensitivity
    /// </summary>
    [SerializeField] private float mouseSensitivity = 1f;
 
    /// <summary>
    /// Previus mouse Position (Used to compute delta)
    /// </summary>
    private Vector3 prevMousePos = new Vector3(255, 255, 255);

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            prevMousePos = Input.mousePosition;

        }
 
        if (Input.GetMouseButton(1))
        {
            prevMousePos = Input.mousePosition - prevMousePos;
 
            prevMousePos = new Vector3(transform.eulerAngles.x + (-prevMousePos.y * mouseSensitivity),
                transform.eulerAngles.y + (prevMousePos.x * mouseSensitivity),
                0);
 
            transform.eulerAngles = prevMousePos;
            prevMousePos = Input.mousePosition;
 
        }
 
        Vector3 newPos = ReadInputs();
 
        newPos = newPos * speed * Time.deltaTime;
        transform.Translate(newPos);
 
 
    }
 
    /// <summary>
    /// Read User inputs and compute movement vector
    /// </summary>
    /// <returns>Movement Vector</returns>
    private Vector3 ReadInputs()
    {
        Vector3 velocity = new Vector3();
 
        if (Input.GetKey(KeyCode.W))
        {
            velocity += new Vector3(0, 0, 1);
        }
        if (Input.GetKey(KeyCode.S))
        {
            velocity += new Vector3(0, 0, -1);
        }
        if (Input.GetKey(KeyCode.A))
        {
            velocity += new Vector3(-1, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            velocity += new Vector3(1, 0, 0);
        }
 
        return velocity;
    }
}
