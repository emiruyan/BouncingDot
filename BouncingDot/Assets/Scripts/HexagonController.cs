using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexagonController : MonoBehaviour
{
    private void Update()
    {
        StartCoroutine(Rotate());//Rotate'i Coroutine olarak Update'de çalıştırıyoruz.
    }

    IEnumerator Rotate()//IEnumerator olarak Rotate methodu oluşturduk.
    {//ScrnToWrldPnt için Vector3 değerlerini mousePos'a atadık.
        Vector3 _mousePos = Camera.main.ScreenToWorldPoint(new Vector3(
            Input.mousePosition.x,//Sadece x düzlemi lazım olduğu için bunu aldık
            transform.position.y,
            transform.position.z
        ));

        if (Input.GetMouseButtonDown(0) && _mousePos.x < 0)//Mouse sol click'i basılı ve x 0'dan küçükse;(Ekranın sol poz'u
        {//Hexagon'u iki aşamalı çevirdiğimizi için WaitForSeconds kullandık. Bir süre bekleyip diğer Rotate işlemini yapıyor.
            transform.Rotate(0f,0f,30f);
            yield return new WaitForSeconds(0.1f); 
            transform.Rotate(0f, 0f, 30f);
        }
        else if (Input.GetMouseButtonDown(0)&& _mousePos.x > 0)//Mouse sol click'i basılı ve x 0'dan büyükse;(Ekranın sağ poz'u
        {//Hexagon'u iki aşamalı çevirdiğimizi için WaitForSeconds kullandık. Bir süre bekleyip diğer Rotate işlemini yapıyor.
            transform.Rotate(0f,0f,-30f);
            yield return new WaitForSeconds(0.1f); 
            transform.Rotate(0f, 0f, -30f);
        }
        yield return null;
    }
}
