using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareLandScript : MonoBehaviour
{

    Grid landGrid;

    // Start is called before the first frame update
    void Start()
    {
        // this.square = gameObject.GetComponent("LandsMainLands");
        this.landGrid = gameObject.GetComponent("Grid") as Grid;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
