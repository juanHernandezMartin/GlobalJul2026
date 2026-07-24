using System;
using UnityEngine;

public class TestCLR : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log(System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
