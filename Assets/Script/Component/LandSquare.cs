using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface LandSquareMovedDelegate {
    void didMove();
} 
public class LandSquare : MonoBehaviour
{

    [SerializeField] SpriteRenderer objectRenderer;

    public LandSquareMovedDelegate movedDelegate;
    public MainEventOnGrid mainSceneDelegate;

    private MovementDelegates currentControllerMovement = new Movement();

    // Start is called before the first frame update
    void Start()
    {
        // embed on mouse down

    }

    // Update is called once per frame
    void Update()
    {
        this.currentControllerMovement.movementOnUpdates(this.transform);
    }
    private void OnMouseDown() {
        objectRenderer.color = Color.white;
    }

    private void OnMouseUp() {
        objectRenderer.color = Color.black;
    }
    private void OnTriggerEnter(Collider other) {
        Debug.Log("Collision " + other.gameObject.name);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (mainSceneDelegate == null) return;
        mainSceneDelegate.didPlayerCollided(other.gameObject.name);
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (mainSceneDelegate == null) return;
        mainSceneDelegate.didPlayerStillInCollide(other.gameObject.name);
    }

}
