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

        if (this.mainCharacter.transform.position == this.transform.position) {
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
