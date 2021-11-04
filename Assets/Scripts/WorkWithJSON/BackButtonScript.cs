using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void Menu()
    {
        Debug.Log("fdf");
        SceneManager.LoadScene("MainScene");
    }
}
