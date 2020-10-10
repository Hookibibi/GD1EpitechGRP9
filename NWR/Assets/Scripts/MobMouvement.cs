using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class MobMouvement : MonoBehaviour
{
    public float MobSpeed;
    public float DistAggro;
    public float DistDesaggro;
    private bool Aggro = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var gObj = GameObject.Find("Player");
        if (gObj)
        {
            var distx = gObj.transform.position.x - transform.position.x;
            var disty = gObj.transform.position.y - transform.position.y;
            var dist = Mathf.Sqrt(Mathf.Pow(distx, 2) + Mathf.Pow(disty, 2));
            if (Mathf.Abs(dist) < DistAggro)
            {
                Aggro = true;
            }
            if (Mathf.Abs(dist) > DistDesaggro)
            {
                Aggro = false;
            }
            if (Aggro)
            {
                transform.position += new Vector3(MobSpeed * 0.001f * distx / (Mathf.Abs(distx) + Mathf.Abs(disty)), MobSpeed * 0.001f * disty / (Mathf.Abs(distx) + Mathf.Abs(disty)), 0.0f);
                transform.rotation = Quaternion.Euler(0, 0, (180 / Mathf.PI) * Mathf.Atan2(disty, distx) + 90);
            }
        }
    }
}
