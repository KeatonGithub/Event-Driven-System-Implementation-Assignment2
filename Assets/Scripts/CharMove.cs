using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.SceneView;

public class PlayerMove : MonoBehaviour
{


    CharacterController Controller; //calling and defining the character controller

    public float Speed; // the players speed

    public Transform Cam; //the cameras position


    // Start is called before the first frame update
    void Start()
    {

        Controller = GetComponent<CharacterController>(); //get character controller

    }

    // Update is called once per frame
    void Update()
    {

        float Horizontal = Input.GetAxis("Horizontal") * Speed * Time.deltaTime; //horizontal movement
        float Vertical = Input.GetAxis("Vertical") * Speed * Time.deltaTime;//vertical movement

        Vector3 Movement = Cam.transform.right * Horizontal + Cam.transform.forward * Vertical; //camera movement
        Movement.y = 0f; 



        Controller.Move(Movement);

        if (Movement.magnitude != 0f)
        {
            transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * Cam.GetComponent<CameraMove>().sensivity * Time.deltaTime);


            Quaternion CamRotation = Cam.rotation;
            CamRotation.x = 0f;
            CamRotation.z = 0f;

            transform.rotation = Quaternion.Lerp(transform.rotation, CamRotation, 0.1f);

        }
    }

}