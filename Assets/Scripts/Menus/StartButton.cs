﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{

    public void startGame(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

}
