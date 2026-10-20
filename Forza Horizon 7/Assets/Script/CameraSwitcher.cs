using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraSwitcher : MonoBehaviour
{
    public Camera mainCamera;
    public Camera hoodCamera;
    public KeyCode switchKey = KeyCode.C;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera.gameObject.SetActive(true);
        hoodCamera.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(switchKey))
        {
            mainCamera.gameObject.SetActive(!mainCamera.gameObject.activeInHierarchy);
            hoodCamera.gameObject.SetActive(!hoodCamera.gameObject.activeInHierarchy);
        }
    }
}
