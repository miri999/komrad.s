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
    public GameObject sphere;
    private GameObject cursw;
    public float rotSpeed =10;
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
        Destroy(cursw);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, mask) && Input.GetMouseButtonUp(1))
        {
            //phisics stuff (ask miri)
            Transform objectHit = hit.transform;
            if(Vector3.Distance(this.transform.position, objectHit.position) < 50)
            {
                playerBody.transform.up = hit.normal;
            }
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(hit.normal.x, hit.normal.y, hit.normal.z), rotSpeed * Time.deltaTime);
        }
        else if (Physics.Raycast(ray, out hit, Mathf.Infinity, mask) && Input.GetMouseButton(1))
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
            cursw = Instantiate(sphere,hit.point, new Quaternion(0,0,0,0));
            cursw.transform.localScale = new Vector3(hit.distance/30, hit.distance/30, hit.distance/30);
            sphere.GetComponent<Renderer>().material = highlight;
        }
    }
}
