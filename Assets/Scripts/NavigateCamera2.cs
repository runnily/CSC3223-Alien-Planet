/*
*   Name: Adanna Obibuaku
*   Purpose: For navigating camera
*   Date: 16/12/20
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigateCamera2 : MonoBehaviour
{
  //public float scrollSpeed = 2.0f;
  public GameObject parnet;
  public float panSpeed = 2.0f;
  public float panBorderThickness = 1.0f; //how far at the edge cursor would be to move
  private float pitch = 0.0f;
  //private float yaw = 0.0f;
  public Vector2 pitchYaw; // x contains the pitch, y contains yaw
  RectTransform rt;


  void Update()
  {
      Vector3 pos = transform.position;
      if ( Input.GetKey("w") || Input.GetKey("up") ) {//|| Input.mousePosition.y >= Screen.height- panBorderThickness) {
        pos.z -= panSpeed*Time.deltaTime;
      }

      if ( Input.GetKey("s") || Input.GetKey("down")) { //|| Input.mousePosition.y <= panBorderThickness) {
        pos.z += panSpeed*Time.deltaTime;
      }

      if (Input.GetKey("d") || Input.GetKey("right")) { //|| Input.mousePosition.x >= Screen.width - panBorderThickness) {
        pos.x -= panSpeed*Time.deltaTime;
      }

      if (Input.GetKey("a") || Input.GetKey("left"))   { //|| Input.mousePosition.x <= panBorderThickness) {
        pos.x += panSpeed*Time.deltaTime;
      }



      //float scroll = Input.GetAxis("Mouse ScrollWheel");
      float maxY = Terrain.activeTerrain.SampleHeight(transform.position);
      //pos.y+= scroll * scrollSpeed * 100f * Time.deltaTime;

      //pos.y = maxY+7.0f;
      transform.position = pos;

      //yaw += pitchYaw.y * Input.GetAxis("Mouse X");
      pitch -= pitchYaw.x * Input.GetAxis("Mouse Y");
      transform.eulerAngles = new Vector3(pitch, 180.0f, 0.0f);


  }
}
