using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Transform Character;

    public float mouseSensitivity { get; set; }


    public float xRotation;

    public bool SettingsOn = false;

    public bool RotationPaused = false;

    public GameObject Settings;

    [Header("Ylös ja alas liikkuminen")]
    public float minYangle = -70f;
    public float maxYangle = 90f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, minYangle, maxYangle);


        
        if(RotationPaused == true)
        {
            Character.transform.Rotate(Vector3.up * mouseX);
        
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if(SettingsOn == false)
            {
                SettingsOn = true;
            }
            else
            {
                SettingsOn = false;
            }
        }

        if(SettingsOn == true)
        {
            Settings.SetActive(true);
            Cursor.lockState = CursorLockMode.None;

            RotationPaused = false;
        }
        else
        {
            Settings.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;

            RotationPaused = true;
        }      
    }
}