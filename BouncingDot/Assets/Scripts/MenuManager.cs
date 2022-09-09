using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _bestScore;


    private void Start()
    {
        _bestScore.text = PlayerPrefs.GetInt("_bestScore").ToString();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))//Mouse sol click basılı ise;
        {
            SceneManager.LoadScene(1);//GameScene'i yükle
        }
    }
}
