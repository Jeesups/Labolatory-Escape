using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingOnTouch : MonoBehaviour
{

    //TODO: Obiekt platformy powinien być pusty i posiadać obiekt platformy jako dziecko, to powoduje że gracz się deformuje, ponieważ otrzymuje wartości relatywne do obiektu.
    //BUG: Skrypt nie reagowal na postac gracza ze wzgledu na to ze skrypt byl podlaczony do rodzica nie posiadajacego collidera, sam obiekt platformy posiadal 
    // owego collidera, mozna bylo utworzyc skrpyt ktory przy uzyciu eventa wyslalby informacje o kontakcie.
    
    [SerializeField] private Transform platform;
    private void Start()
    {
        platform = GetComponent<Transform>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag.Equals("Player"))
        {
            collision.transform.SetParent(platform.transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag.Equals("Player"))
        {
            collision.transform.SetParent(null);
        }
               
    }
}
