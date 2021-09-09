using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jgf : MonoBehaviour
{
    public float speed=200;
    public float killdist=1000;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Rigidbody>().velocity = speed * this.transform.up;
        if (killdist <Vector3.Distance(new Vector3(0,0,0), this.transform.position))
        {
            Destroy(this);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this);
    }
}
