/*
*   Name: Adanna Obibuaku
*   Purpose: For switching between cameras
*   Date: 18/12/20
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchCam : MonoBehaviour
{
    public GameObject camera1;
    public GameObject camera2;
    public GameObject camera3;
    public GameObject camera4;
    public GameObject camera5;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

      if (Input.GetButtonDown("1Key")) {
        camera1.SetActive(true);
        camera2.SetActive(false);
        camera3.SetActive(false);
        camera4.SetActive(false);
        camera5.SetActive(false);
      }
      if (Input.GetButtonDown("2Key")) {
        camera1.SetActive(false);
        camera2.SetActive(true);
        camera3.SetActive(false);
        camera4.SetActive(false);
        camera5.SetActive(false);
      }
      if (Input.GetButtonDown("3Key")) {
        camera1.SetActive(false);
        camera2.SetActive(false);
        camera3.SetActive(true);
        camera4.SetActive(false);
        camera5.SetActive(false);
      }
      if (Input.GetButtonDown("4Key")) {
        camera1.SetActive(false);
        camera2.SetActive(false);
        camera3.SetActive(false);
        camera4.SetActive(true);
        camera5.SetActive(false);;
      }
      if (Input.GetButtonDown("5Key")) {
        camera1.SetActive(false);
        camera2.SetActive(false);
        camera3.SetActive(false);
        camera4.SetActive(false);
        camera5.SetActive(true);;
      }

    }
}
