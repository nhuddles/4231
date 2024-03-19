using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToMouse : MonoBehaviour
{
    void Update()
    {
        // Convert the mouse position to a ray
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Perform a raycast to find the point on the ground plane
        if (Physics.Raycast(ray, out hit))
        {
            // Calculate the direction from the object to the hit point
            Vector3 directionToMouse = hit.point - transform.position;

            // Create a rotation that looks along the direction to the mouse
            Quaternion rotationToMouse = Quaternion.LookRotation(directionToMouse);

            // Apply the rotation to the object
            transform.rotation = Quaternion.Slerp(transform.rotation, rotationToMouse, Time.deltaTime * 5f);
        }
    }
}
