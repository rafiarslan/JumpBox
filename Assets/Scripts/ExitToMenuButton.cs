﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitToMenuButton : MonoBehaviour {

    public void ExitToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
