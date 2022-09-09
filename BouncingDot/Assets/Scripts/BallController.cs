using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallController : MonoBehaviour
{
   [SerializeField] private Rigidbody2D rb;
   [SerializeField] private SpriteRenderer sr;
   [SerializeField] private Sprite[] _ballSprite;//Topun renklerini atayacağımız dizi.
   [SerializeField] private float _jumpForce;
   [SerializeField] private string _currentColor;
   private GameManager gm;


   private void Start()
   {
      gm = GameObject.FindObjectOfType<GameManager>();
      RandomBall(3);//Oyun içerisinde ilk rengimiz yeşil olduğu için burada parametreyi "Green" verdik.
   }
   
   public void RandomBall(int index) //Topa rastgele renk vereceğimiz method:
   {
      switch (index)
      {
         case 0: _currentColor = "Red";
            sr.sprite = _ballSprite[0];//Unity içerisinden verdiğimiz sprite'ı sr.sprite'a atıyoruz.
            gameObject.tag = "Red";//Top belirttiğimiz index'i alırsa tag'ı o indexe göre değişiyor.
            break;
         case 1: _currentColor = "Yellow";
            sr.sprite = _ballSprite[1];
            gameObject.tag = "Yellow";
            break;
         case 2: _currentColor = "Blue";
            sr.sprite = _ballSprite[2];
            gameObject.tag = "Blue";
            break;
         case 3: _currentColor = "Green";
            sr.sprite = _ballSprite[3];
            gameObject.tag = "Green";
            break;
         case 4: _currentColor = "Purple";
            sr.sprite = _ballSprite[4];
            gameObject.tag = "Purple";
            break;
         case 5: _currentColor = "Orange";
            sr.sprite = _ballSprite[5];
            gameObject.tag = "Orange";
            break;
      }
   }
   
   private void OnCollisionEnter2D(Collision2D other)
   {
      //Vector3.up ile jumpForce değerini velocity'e atadık. Çarpışma olduğunda topa güç uyguluyoruz.
      rb.velocity = Vector3.up * _jumpForce;
      
      if (other.gameObject.tag != _currentColor)//Çarptığımız diğer objenin tagı _currentColor'dan farklı ise;
      {//Game Over
         gm.RestartGame();//gm içerisinde ki RestartGame methodunu çalıştır.
      }
      else
      {//Ball ve Hexagon renk aynı ise;
         gm.score += 1;//aynı renkler çarpışırsa score'u bir bir arttıyoruz.
         int _randomNumber = Random.Range(0, 6);//Random bir indexi _randomNumber'a atıyoruz.
         RandomBall(_randomNumber);//Renkler aynı ise oluşturduğumuz method'da Random.Range yardımı ile topun rengi değişiyor.
      }
   }
}
