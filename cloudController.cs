using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudController : MonoBehaviour
{
    // Creates a game object variable to control the clouds and the rigidbody
    public GameObject cloudPrefab;
    public Rigidbody2D cloudRB;

    // Creates a set of variables to control the clouds
    public float randomY;
    public int randomTime;
    public float randomVelocity;

    // Creates a set of variables to control the water
    public GameObject water;
    float speed = 0.75f;
    public Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        // Starts the loop that spawns clouds
        StartCoroutine("cloudGenerator");
    }

    // Update runs every frame
    void Update()
    {
        // Changes the step variable based on how fast the game is running
        float step = speed * Time.deltaTime;

        // Changes the target variable based on the position of the water
        if (water.transform.position == gPos.waterStart)
        {
            target = gPos.waterEnd;
        }
        else if (water.transform.position == gPos.waterEnd)
        {
            target = gPos.waterStart;
        }

        // Moves the water
        water.transform.position = Vector3.MoveTowards(water.transform.position, target, step);
    }

    IEnumerator cloudGenerator()
    {
        // Creates random numbers to control the clouds
        randomTime = Random.Range(2, 7);
        randomY = Random.Range(2f, 4.3f);
        randomVelocity = Random.Range(-0.5f, -1f);

        // Creates a cloud
        GameObject cloudObject = (GameObject)Instantiate(cloudPrefab, new Vector3(10.5f, randomY, 0), Quaternion.identity);
        Destroy(cloudObject, 50);

        // Gives the cloud velocity
        cloudRB = cloudObject.GetComponent<Rigidbody2D>();
        cloudRB.velocity = new Vector3(randomVelocity, 0, 0);

        // Waits for a random amount of time
        yield return new WaitForSeconds(randomTime);

        // Starts the coroutine again
        StartCoroutine("cloudGenerator");
    }
}