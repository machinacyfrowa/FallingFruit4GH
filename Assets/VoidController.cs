using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidController : MonoBehaviour
{
    public GameObject levelManager;
    LevelManager levelManagerScript;
    // Start is called before the first frame update
    void Start()
    {
        levelManagerScript = levelManager.GetComponent<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
        levelManagerScript.ZeroScore();
    }
}
