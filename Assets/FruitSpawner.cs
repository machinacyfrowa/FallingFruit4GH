using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    //legacy
    GameObject fruitPrefab;
    //lista owoców
    public List<GameObject> fruitPrefabs;
    //szerokoœæ gry
    public float spawnWidth = 10f;
    List<GameObject> fruits = new List<GameObject>();
    // Start is called before the first frame update
    CameraController cameraController;
    //levelmanager
    LevelManager levelManager;
    void Start()
    {
        cameraController = Camera.main.GetComponent<CameraController>();
        fruits = new List<GameObject>();
        InvokeRepeating("Spawn", 0, 1f);
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //CheckFruit();
    }
    void Spawn()
    {
        //losowa liczba lewo/prawo
        float x = Random.Range(-spawnWidth, spawnWidth);
        //losowy owoc
        fruitPrefab = fruitPrefabs[Random.Range(0, fruitPrefabs.Count)];
        //pozycja spawnu wygenerowana z lowej wspó³rzêdnej x oraz wspó³rzêdnych y i z spawnera
        Vector3 spawnPosition = new Vector3(x, transform.position.y, transform.position.z);
        //spawnuje owoc
        GameObject fruit = Instantiate(fruitPrefab, spawnPosition, Quaternion.identity);
        //ustawia autodestrukcje owocu po 5 sekundach
        //Destroy(fruit, 5f);
        fruits.Add(fruit);
    }
    //void CheckFruit()
    //{
    //    foreach (GameObject fruit in fruits)
    //    {
    //        if (fruit.transform.position.y < -6) 
    //        {
    //            //tutaj zerujemy punkty lub konczymy gre
    //            levelManager.ZeroScore();
    //            fruits.Remove(fruit);
    //            Destroy(fruit);
    //        }
    //    }
    //}
}