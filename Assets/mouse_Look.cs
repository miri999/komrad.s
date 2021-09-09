using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse_Look : MonoBehaviour
{

    //variables (uuhhhhmm?!?!)
    public float mouseSensitivity = 100f;
    float xRotation = 0f;
    public Transform playerBody;
    private GameObject prev;
    Material orig;
    private Material highlight;
    public Material UngUhn;
    public Material yes;
    public LayerMask mask;
    // Start is called before the first frame update
    void Start()
    {
        //cursor stuff
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //THE IMPORTANT STUFF
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);

        //raycasting
        RaycastHit hit;
        Ray ray = this.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

        //some rendering stuff
        if (prev == null)
        {}
        else
        {
            prev.GetComponent<Renderer>().material = orig;
        }
        
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, mask) && Input.GetMouseButtonUp(0))
        {
            //phisics stuff (ask miri)
            Transform objectHit = hit.transform;
            if(Vector3.Distance(this.transform.position, objectHit.position) < 50)
            {
                playerBody.transform.up = hit.normal;
            }
        }else if (Physics.Raycast(ray, out hit, Mathf.Infinity, mask) && Input.GetMouseButton(0))
        {
            //feedback
            Transform objectHit = hit.transform;
            if(Vector3.Distance(this.transform.position, objectHit.position) > 50)
            {
                highlight = UngUhn;
            }
            else
            {
                highlight = yes;
            }
            GameObject hitgo = objectHit.gameObject;
            orig = hitgo.GetComponent<Renderer>().material;
            hitgo.GetComponent<Renderer>().material = highlight;
            prev = hitgo;
        }
    }
}
