using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastDemo : MonoBehaviour
{
    RaycastHit hit;
    public Material HitMaterial;
    public Canvas ui;
    public GameObject BaseCamera;
    public GameObject AnotherCamera;
    public GameObject Cylinder;
    public IList<GameObject> Cylinders = new List<GameObject>();
    public GameObject AnimObject;

    void Start() {
        StartCoroutine(MyCoroutine());
    }

    void Update()
    {
        var r = Camera.main.ScreenPointToRay( Input.mousePosition);
        //var r = new Ray(Camera.main.transform.position, Camera.main.transform.forward * 2);
        if (Physics.Raycast(r, out hit, Mathf.Infinity) && hit.transform.tag == "Target")
        {
            if (Input.GetMouseButtonDown(0)) {
                Debug.Log("Done");
                //hit.transform.gameObject.GetComponent<MeshRenderer>().material = HitMaterial;
                var point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Cylinders.Add(Instantiate(Cylinder, point + Camera.main.transform.forward * 3, Quaternion.identity));
            }
            ui.enabled = true;
        }
        else {
            ui.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.C)) {
            AnotherCamera.SetActive(!AnotherCamera.activeSelf);
            BaseCamera.SetActive(!BaseCamera.activeSelf);
        }
    }

    IEnumerator MyCoroutine() {
        for (var i = 0; i < 100; i++) {
            Debug.Log($"{i}");
            foreach (var cylinder in Cylinders) {
                Destroy(cylinder);
            }
            Cylinders.Clear();
            yield return new WaitForSeconds(5);
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.transform.tag == "AnimTrigger") {
            Debug.Log("Colider");
            AnimObject.GetComponent<Animation>().Play("CubeUp");
        }
        
    }

    // void OnTriggerStay, OnTriggerExit
}
