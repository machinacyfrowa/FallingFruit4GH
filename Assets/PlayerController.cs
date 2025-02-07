using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    //�r�d�o d�wi�ku przy z�apaniu owocu
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        //binduj audio source z tego samego obiektu
        audioSource = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        //input obrazuje co mamy naci�ni�te na klawiaturze
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), 0);

        //jestesmy na prawej kraw�dzi
        if (transform.position.x >= 10f)
        {
            //zerujemy ruch w prawo, �eby nie wyjed�a� poza kraw�d�
            //je�eli naci�ni�te jest w prawo to mathf.min zwr�ci maksymalnie 0
            //je�li w lewo to normaln� warto��
            input.x = Mathf.Min(input.x, 0);
        }
        //jeste�my na lewej kraw�dzi
        if (transform.position.x <= -10f)
        {
            //zerujemy ruch w lewo, �eby nie wyjed�a� poza kraw�d�
            //je�eli naci�ni�te jest w lewo to mathf.max zwr�ci maksymalnie 0
            //je�li w prawo to normaln� warto��
            input.x = Mathf.Max(input.x, 0);
        }

        //przesuwa gracza o input
        transform.Translate(input * Time.deltaTime * moveSpeed);
    }
    private void OnCollisionEnter(Collision collision)
    {
        //odtw�rz d�wi�k
        audioSource.Play();
        //dodaj punkty do wyniku
        //find potrzebuje nazwe obiektu
        //get component potrzebuje nazwe klasy
        GameObject.Find("LevelManager").GetComponent<LevelManager>().AddScore();
        
        //zniszcz obiekt
        Destroy(collision.gameObject);
    }
}
