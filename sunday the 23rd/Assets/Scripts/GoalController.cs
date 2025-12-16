using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalController : MonoBehaviour
{
    public int sceneNumber;

    void Start()
    {
        gameObject.tag = "Player";
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (sceneNumber == 1)
        {
            if (other.tag == "LoadZone")
            {
                SceneManager.LoadScene("Level2");
            }
        }

        if (sceneNumber == 2)
        {
            if (other.tag == "LoadZone")
            {
                //SceneManager.LoadScene("Level3");
            }
        }
    }
}

//    private void OnTriggerExit2D(Collider2D collision)
//    {
//        if (collision.GetComponent<Hatch>() || collision.GetComponent<TreeHouse>())
//        {
//            enterAllowed = false;
//        }
//    }

//    private void Update()
//    {
//        if (enterAllowed && Input.GetKey(KeyCode.Return))
//        {
//            SceneManager.LoadScene(sceneToLoad);
//        }
//    }
//}
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.SceneManagement;

//public class GoalController : MonoBehaviour
//{
//    // Start is called before the first frame update
//    void OnTriggerEnter2D (Collider2D collision)
//    {
//        if (collision.GetComponent<LoadZone>())
//        {
//            SceneManager.LoadScene("Level2");
//            Debug.Log("Load next level");
//        }
//    }
//}
