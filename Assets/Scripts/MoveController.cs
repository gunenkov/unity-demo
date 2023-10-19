using UnityEngine;

public class MoveController : MonoBehaviour
{
    public GameObject Camera;
    
    void Update()
    {
        var yLast = transform.position.y;
        var v = Input.GetAxis("Vertical");
        var h = Input.GetAxis("Horizontal");
        transform.position += (Camera.transform.forward * v + Camera.transform.right * h) * Time.deltaTime * 20f;
        transform.SetPositionAndRotation(new Vector3(transform.position.x, yLast, transform.position.z), transform.rotation);
    }
}
