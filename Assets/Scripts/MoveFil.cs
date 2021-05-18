using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFil : MonoBehaviour
{
   private float speed = 30 ;
   private PlayetController playetControllerScript;
   private float leftBound= -15;
    // Start is called before the first frame update
    void Start()
    {
        playetControllerScript=GameObject.Find("Player").GetComponent<PlayetController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playetControllerScript.gameOver==false)
        {
         transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if(transform.position.x < leftBound && gameObject.CompareTag("Barrier"))
        {
         Destroy(gameObject);
        }
        
    }
}
