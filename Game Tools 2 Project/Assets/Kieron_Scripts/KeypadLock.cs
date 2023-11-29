using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeypadLock : MonoBehaviour
{
    public string code;
    private int count;
    public TMP_Text display;
    public GameObject item;
    public GameObject box;


    // Start is called before the first frame update
    void Start()
    {
        count = code.Length;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TypeCode(int number)
    {
        if (code.Length == count)
        {
            ResetCode();
            code += number;
            display.text = code;
            Debug.Log(number);
        }
        else
        {
            code += number;
            display.text = code;
            Debug.Log(number);
        }
    }

    public void EnterCode(string input)
    {
        if (code == input)
        {
            box.SetActive(false);
            item.SetActive(true);
            //item.transform.position = new Vector3(item.transform.position.x, item.transform.position.y -2.5f, item.transform.position.z);
        }
        else
        {
            code = "";
            display.text = code;
        }
    }

    public void ResetCode()
    {
        code = "";
        display.text = code;
    }
}
