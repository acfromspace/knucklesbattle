﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CameraController : MonoBehaviour
{
    private Vector2 mouseLook;
    private Vector2 smoothV;
    public float sensitivity = 5.0f;
    public float smoothing = 2.0f;
    public static GameObject character;
    private bool setCam;
    public Vector3 offset;

    // Use this for initialization
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if (character && !setCam)
        {
            transform.parent = character.transform;
            setCam = true;
        }
        
        //Gets Mouse direction and smooths the rotation
        Vector2 md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);
        mouseLook += smoothV;


        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        if (character)
        {
            character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);
        }
    }
}