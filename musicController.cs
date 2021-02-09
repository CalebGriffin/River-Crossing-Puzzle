using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Checks to see how many objects exist with the music tag and destroys any that there shouldn't be
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        // Prevents the object from being destroyed
        DontDestroyOnLoad(this.gameObject);
    }
}
