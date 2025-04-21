using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider collision) //on collision send the play to the next level
    {
        if (collision.gameObject.name == "Player")
        {
            SceneManager.LoadScene("YouWin");
        }
    }
}