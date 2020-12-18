/*
*   Name: Adanna Obibuaku
*   Purpose: For moving spaceships
*   Date: 17/12/20
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveFrigate : MonoBehaviour
{
    // Start is called before the first frame update
    public int wait = 10;
    private float i = 0.0f;
    public float panSpeed = 15.0f;
    public float rotSpeed = 3.0f;
    private float maxY;
    public Vector2 panLimit;
    private float angleY = 0.0f;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
      maxY = Terrain.activeTerrain.SampleHeight(transform.position);
      Vector3 pos = transform.localPosition;
      Vector3 rot = new Vector3(0,0,0);

      pos.x = Mathf.Clamp(pos.x, -panLimit.x, panLimit.x);
      pos.z = Mathf.Clamp(pos.z, -panLimit.y, panLimit.y);
      pos.y = maxY+20.0f; // ensure position y is above
      pos += transform.forward * Time.deltaTime * panSpeed; // make it go forward
      transform.position = pos; // transform position


      if (i >= wait) { // acts as a timer -> when i exceed wait time
        i = 0;
        angleY = fly(); // gets back what angle to rotate y.
      }

      if (angleY > 0.0f) { // when angleY is greater than 0
        rot.y += 1*rotSpeed; // rotate by an increment
        angleY -= 1*rotSpeed;
      }

      transform.Rotate(rot);


      i += Time.deltaTime;
    }

    float fly() {
      // wait = wait*3; // make wait less
      float rnd = Random.Range(0,4); // generates random number between 0, 5
      float y = 0.0f;
      if (rnd == 0) {
        y = 0f;
      }
      if (rnd == 1) {
        y = 90.0f;
      }
      if (rnd == 2) {
        y = -90.0f;
      }
      if (rnd == 3) {
        y = 180f;
      }
      return y;
    }
}
