using System;
using UnityEngine;

public class RotateController : MonoBehaviour
{
    private Vector2 rotation;

    void Start() {
    }
    void Update()
    {
        rotation.x += Input.GetAxis("Mouse X") * 200f * Time.deltaTime;
        rotation.y += Input.GetAxis("Mouse Y") * 200f * Time.deltaTime;
        rotation.y = Mathf.Clamp(rotation.y, -90f, 90f);
        transform.localRotation = Quaternion.Euler(-rotation.y, rotation.x, 0f);
    }
}
