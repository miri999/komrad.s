using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserpewpew : MonoBehaviour
{
    public LineRenderer line;
    public Camera cam;
    public string enemyTag = "enemy";
    public GameObject fx;
    public float speed=100;
    public float interval = 0.2f;
    private float time = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.rotation = Quaternion.Euler(new Vector3(cam.gameObject.transform.rotation.eulerAngles.x, cam.gameObject.transform.rotation.eulerAngles.y, cam.gameObject.transform.rotation.eulerAngles.z));
        RaycastHit hit;
        time += Time.deltaTime;
        if (Input.GetMouseButton(0) && Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity) && time>interval)
        {
            GameObject go = Instantiate(fx, transform);
            Object.Destroy(go, hit.distance / speed);
            if ((hit.transform).gameObject.tag == enemyTag)
            {
                Object.Destroy(hit.transform.gameObject, hit.distance/speed+1);
            }
            time = 0f;
        }else if(Input.GetMouseButton(0)&& time > interval&& !Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            GameObject go = Instantiate(fx, transform);
            Object.Destroy(go, 5);
            time = 0f;
        }
    }
}
