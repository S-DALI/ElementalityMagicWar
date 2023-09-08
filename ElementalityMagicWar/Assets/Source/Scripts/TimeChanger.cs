using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeChanger : MonoBehaviour
{

    void Update()
    {
        if(Input.GetKey(KeyCode.Q))
        {
            Time.timeScale = 0.5f;
        }else Time.timeScale = 1.0f;
    }
}
