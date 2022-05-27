using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{

    [SerializeField] LandSquare target;

    private float tolerance = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.updateToCenterFromTarget();
    }

    void updateToCenterFromTarget() {
        // this.transform.position = new Vector3(
        //     this.target.transform.position.x,
        //     this.target.transform.position.y,
        //     this.transform.position.z
        // );
    }

}
