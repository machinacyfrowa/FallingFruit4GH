using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    //Ÿród³o dŸwiêku przy z³apaniu owocu
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
        //input obrazuje co mamy naciœniête na klawiaturze
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), 0);

        //jestesmy na prawej krawêdzi
        if (transform.position.x >= 10f)
        {
            //zerujemy ruch w prawo, ¿eby nie wyjed¿a³ poza krawêdŸ
            //je¿eli naciœniête jest w prawo to mathf.min zwróci maksymalnie 0
            //jeœli w lewo to normaln¹ wartoœæ
            input.x = Mathf.Min(input.x, 0);
        }
        //jesteœmy na lewej krawêdzi
        if (transform.position.x <= -10f)
        {
            //zerujemy ruch w lewo, ¿eby nie wyjed¿a³ poza krawêdŸ
            //je¿eli naciœniête jest w lewo to mathf.max zwróci maksymalnie 0
            //jeœli w prawo to normaln¹ wartoœæ
            input.x = Mathf.Max(input.x, 0);
        }

        //przesuwa gracza o input
        transform.Translate(input * Time.deltaTime * moveSpeed);
    }
    private void OnCollisionEnter(Collision collision)
    {
        //odtwórz dŸwiêk
        audioSource.Play();
        //dodaj punkty do wyniku
        //find potrzebuje nazwe obiektu
        //get component potrzebuje nazwe klasy
        GameObject.Find("LevelManager").GetComponent<LevelManager>().AddScore();
        
        //zniszcz obiekt
        Destroy(collision.gameObject);
    }
}
