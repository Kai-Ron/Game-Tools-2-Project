using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public int room;
    public GameObject inventoryManager;
    public GameObject SceneTransitonText;

    // Start is called before the first frame update
    void Start()
    {
        SceneTransitonText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collision other)
    {
        if(other.transform.gameObject.tag == "Player")
        {
            SceneTransitonText.SetActive(true);

            if(Input.GetKeyDown(KeyCode.E))
            {
                DontDestroyOnLoad(inventoryManager);
                SceneManager.LoadScene(room);
                SceneTransitonText.SetActive(false);
            }
            
        }
    }
}
