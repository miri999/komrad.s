using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float damage=10;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (damage < 0)
        {
            Destroy(this);
        }
    }
}
