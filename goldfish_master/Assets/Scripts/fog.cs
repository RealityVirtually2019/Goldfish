using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fog : MonoBehaviour
{
    // Start is called before the first frame update
    void Test()
    {
        //set the fog color to be blue
        RenderSettings.fogColor = Color.blue;
        RenderSettings.fog = true;
    }

}