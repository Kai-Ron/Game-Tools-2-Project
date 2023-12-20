using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public int room;
    public GameObject inventoryManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.transform.gameObject.tag == "Player")
        {
            DontDestroyOnLoad(inventoryManager);
            SceneManager.LoadScene(room);
        }
    }
}
