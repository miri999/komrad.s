using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserpewpew : MonoBehaviour
{
    public LineRenderer line;
    public Camera cam;
    public string enemyTag = "enemy";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;
        Ray ray = cam.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        line.enabled = false;
        if (Input.GetMouseButton(0) && Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            line.enabled = true;
            line.SetPosition(0, this.transform.position);
            line.SetPosition(1, hit.point);
            if ((hit.transform).parent.tag == enemyTag)
            {
                Object.Destroy(hit.transform.gameObject);
            }
        }
    }
}
