using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandSquareChild : MonoBehaviour
{
    public LandSquare mainCharacter;
    public bool prepareToDestroy = false;
    private MovementDelegates objectMoveDelegate = new Movement(); 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void giveMovemenTowardsMain() {
        this.objectMoveDelegate.setObject(
                this.transform, this.mainCharacter.transform.position
            );

        float x = this.mainCharacter.transform.position.x;
        float y = this.mainCharacter.transform.position.y;
        float z = this.mainCharacter.transform.position.z;

        float x2 = this.transform.position.x;
        float y2 = this.transform.position.y;
        float z2 = this.transform.position.z;

        float tolerance = 0.1f;
        if (Mathf.Abs(x - x2) < tolerance &&
            Mathf.Abs(y - y2) < tolerance &&
            Mathf.Abs(z - z2) < tolerance) {
            print("Reached");
            this.prepareToDestroy = true;
        }
    }

    public void stopMovement() {
        // this.objectMoveDelegate.stopMovement();
    }
    public void callTest() {
        Debug.Log("callTest");
    }
}
