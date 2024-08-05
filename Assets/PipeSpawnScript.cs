using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{

    public GameObject pipe;
    public float spawnRate = 5;
    public float heightOffset = 10;
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        spawnPipe();
    }

    // Update is called once per frame
    void Update()
    {

        if (timer < spawnRate) {
            timer += Time.deltaTime; // basically a timer that counts up 1 every frame and does this no matter what computer user has
        }
        else {
            spawnPipe();
            timer = 0;
        }

        // Instantiate is a method for spawning game objects
        // This spawns a pipe game object at the position of this spawner as well as keeps the rotation the same as the spawner (none)
        
    }


    void spawnPipe() {
        float highestPoint = transform.position.y + heightOffset;
        float lowestPoint = transform.position.y - heightOffset;
        // allows each pipe spawn to randomly select a y position between the set boundaries.
        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }
}
