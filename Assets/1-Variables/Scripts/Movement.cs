using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clean Code: CTRL+K+D

namespace Variables
{ 
    public class Movement : MonoBehaviour
    {
        public float movementSpeed = 20f;
        public float rotationSpeed = 200f;

        // Update is called once per frame
        void Update()
        {
            // Get Horizontal Input
            float inputH = Input.GetAxis("Horizontal");
            float inputV = Input.GetAxis("Vertical");

            // Direction (variable) x Movement Speed (variable) x DeltaTime (constant)
            // transform.Translate(new Vector3(inputH, inputV) * movementSpeed * Time.deltaTime);
            // transform.position += new Vector3(inputH, inputV) * movementSpeed * Time.deltaTime;
            // Creating new Vector3 Function for this transform line
            // Using Inputs, multiplied by movementSpeed then multiplied by deltaTime (which is CPU speed!)

            // Direction x Input(sign) x Speed x DeltaTime
            transform.position += transform.right * inputV * movementSpeed * Time.deltaTime; // Forward goes Right
            // transform.position += -transform.up * inputH * movementSpeed * Time.deltaTime;

            // Velocity (i.e. Direction x Rotation Speed) x DeltaTime
            // transform.Rotate(new Vector3(0, 0, rotationSpeed) * Time.deltaTime);
            // transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
            // another e.g.: transform.eulerAngles += Vector3.forward * rotationSpeed * Time.deltaTime;

            transform.eulerAngles += Vector3.back * inputH * rotationSpeed * Time.deltaTime; // -Vector3.forward?

            // if(inputH !=0) // if InputH NOT EQUAL to 0
            // {
            //    Debug.Log(inputH); // show values in DebugLog
            // }
            // if(inputV !=0)
            // {
            //    Debug.Log(inputV);
            // }
        }
    }
}
