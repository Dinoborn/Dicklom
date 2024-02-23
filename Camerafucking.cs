using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyCamera : MonoBehaviour
{
    public float movementSpeed = 10.0f;
    public float rotationSpeed = 2.0f;
    public float zoomSpeed = 2.0f;
    private Vector3 initialPosition;
    private Vector3 lastPosition;
    private Vector3 targetPosition;
    private bool isRightMouseButtonDown = false;

    void Start()
    {
        initialPosition = new Vector3(10f, 3551.69f, 10f);
        transform.position = initialPosition;
        targetPosition = initialPosition;
    }

    void Update()
    {
        // Camera movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(horizontal, 0, vertical) * movementSpeed * Time.deltaTime);
        if (Input.GetMouseButtonDown(1))
        {
            isRightMouseButtonDown = true;
        }
        else if (Input.GetMouseButtonUp(1))
        {
            isRightMouseButtonDown = false;
        }

        // Camera rotation
        if (isRightMouseButtonDown)
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");
            // Явное управление углами поворота
            transform.eulerAngles += new Vector3(-mouseY * rotationSpeed, mouseX * rotationSpeed, 0);
        }

        // Camera zoom
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        targetPosition = transform.position + transform.forward * scroll * zoomSpeed;

        // Apply limits to camera movement
        targetPosition.x = Mathf.Clamp(targetPosition.x, -20f, 15f);
        targetPosition.y = Mathf.Clamp(targetPosition.y, 3541.69f, 3561.69f);
        targetPosition.z = Mathf.Clamp(targetPosition.z, -15f, 20f);

        // Check for collisions with objects
        RaycastHit hit;
        if (Physics.Linecast(targetPosition, transform.position, out hit))
        {
            targetPosition = hit.point;
        }

        // Smoothly move the camera to the target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 5.0f);
    }
}