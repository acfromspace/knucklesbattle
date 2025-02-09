﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour
{
    public Text levelText;

    // Use this for initialization
    void Start()
    {
        levelText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (LevelManager.Instance)
        {
            levelText.text = "Level " + LevelManager.Instance.level.ToString();
        }
    }
}