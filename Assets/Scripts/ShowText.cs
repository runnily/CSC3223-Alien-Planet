/*
*   Name: Adanna Obibuaku
*   Purpose: For showing fps and memory being used on ui text element
*   Date: 15/12/20
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowText : MonoBehaviour
{
    public string fps;
    public string memory;

    public float memoryFlo = 0.0f;
    public float deltaTime;
    public Text element;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

      memoryFlo = UnityEngine.Profiling.Profiler.GetTotalAllocatedMemoryLong()/1e+6f;

      deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
      float fpsFlo = 1.0f / deltaTime;

      memory = "memory: " + (memoryFlo).ToString();
      fps = "fps: " + (fpsFlo).ToString();

      element.text = fps + "    " + memory;



    }
}
