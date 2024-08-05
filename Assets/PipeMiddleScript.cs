using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PipeMiddleScript : MonoBehaviour
{

    public LogicScript logic; // reference to our logic script
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>(); // sets reference to our logic manager's script component
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // when the trigger for this middle collider gets hit, this method runs
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.layer == 3) { // checks if the gameobject the trigger collided with was with a gameobject on the birds layer (the bird)
            Debug.Log("Collided with Bird");
            logic.addScore(1);
        }
    }
}
