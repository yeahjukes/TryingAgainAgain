using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloWorld : MonoBehaviour
{
    public string stringToPrint = "Love it!";

    private float timeSincePrint = 0f;

    // Start is called before the first frame update
    void Start()
    {
        PrintHelloWorld("Start");
    }

    // Update is called once per frame
    void Update()
    {
        timeSincePrint += Time.deltaTime;

        if (timeSincePrint >= 3f)
        {
            PrintHelloWorld(stringToPrint);
            timeSincePrint = 0f;
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            PrintHelloWorld("Yippee!");
        }

        //PrintHelloWorld(timeSincePrint.ToString());
    }

    public void PrintHelloWorld(string toPrint)
    {
        Debug.Log(toPrint);
    }
}
