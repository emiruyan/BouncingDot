using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   [SerializeField] private TMP_Text _scoreText;
   public int score;

   private void Update()
   {
       _scoreText.text = score.ToString();
   }

   public void RestartGame()
   {
       SceneManager.LoadScene(0);//0 indexli sahneyi yüklüyoruz.
   }
}
