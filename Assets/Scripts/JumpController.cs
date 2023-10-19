using UnityEngine;

public class JumpController : MonoBehaviour
{
    void Update()
    {
       if (Input.GetKeyUp(KeyCode.Space)) {
            GetComponent<Rigidbody>().AddForce(transform.up * 400f);
        }
    }
}
