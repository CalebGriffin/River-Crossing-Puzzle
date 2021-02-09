using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class confirmController : MonoBehaviour
{
    // Run by the yes button on the confirm canvas
    public void Yes()
    {
        gPos.confirmed = "true";
    }

    // Run by the no button on the confirm canvas
    public void No()
    {
        gPos.confirmed = "false";
    }
}
