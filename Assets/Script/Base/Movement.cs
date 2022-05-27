using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface MovementDelegates
{
    float getObjectSpeed();
    void setObject(Transform source, Vector3 target);
    void restoreSpeed();
    void movementOnUpdates(Transform transform);
}
public class Movement : MovementDelegates
{
    enum MovementDirection
    {
        UP,
        UPLEFT,
        UPRIGHT,
        DOWN,
        DOWNLEFT,
        DOWNRIGHT,
        LEFT,
        RIGHT,
        STAY
    }

    private float currentSpeed = 0f;
    private float magnetSpeed = 10.0f;
    private float velocity = 0.01f;
    private MovementDirection currentDirection = MovementDirection.STAY;
    public void movementOnUpdates(Transform transform)
    {
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S)) this.currentDirection = MovementDirection.DOWNRIGHT;
        else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S)) this.currentDirection = MovementDirection.DOWNLEFT;
        else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W)) this.currentDirection = MovementDirection.UPRIGHT;
        else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W)) this.currentDirection = MovementDirection.UPLEFT;
        else if (Input.GetKey(KeyCode.A)) this.currentDirection = MovementDirection.LEFT;
        else if (Input.GetKey(KeyCode.D)) this.currentDirection = MovementDirection.RIGHT;
        else if (Input.GetKey(KeyCode.W)) this.currentDirection = MovementDirection.UP;
        else if (Input.GetKey(KeyCode.S)) this.currentDirection = MovementDirection.DOWN;
        else this.decreaseMovementSpeed();
        this.internalUpdateMovement(transform);
    }
    public void setObject(Transform source, Vector3 target)
    {
        source.position = target / magnetSpeed;
        if (this.magnetSpeed > 1f && this.magnetSpeed - velocity > 1) this.magnetSpeed -= velocity;
        else this.magnetSpeed = 1f;
        this.velocity += 0.0025f;
    }
    public void restoreSpeed() {
        this.magnetSpeed = 10f;
        this.velocity = 0.01f;
    }
    public float getObjectSpeed()
    {
        return this.currentSpeed;
    }

    private void internalUpdateMovement(Transform transform)
    {
        switch (this.currentDirection)
        {
            case MovementDirection.UP:
                moveObjectTo(transform, Vector3.up * this.currentSpeed * Time.deltaTime);
                break;
            case MovementDirection.DOWN:
                moveObjectTo(transform, Vector3.down * this.currentSpeed * Time.deltaTime);
                break;
            case MovementDirection.LEFT:
                moveObjectTo(transform, Vector3.left * this.currentSpeed * Time.deltaTime);
                break;
            case MovementDirection.RIGHT:
                moveObjectTo(transform, Vector3.right * this.currentSpeed * Time.deltaTime);
                break;
            case MovementDirection.DOWNRIGHT:
                moveObjectTo(transform, Vector3.down * this.currentSpeed * Time.deltaTime, true);
                moveObjectTo(transform, Vector3.right * this.currentSpeed * Time.deltaTime, true);
                break;
            case MovementDirection.DOWNLEFT:
                moveObjectTo(transform, Vector3.down * this.currentSpeed * Time.deltaTime, true);
                moveObjectTo(transform, Vector3.left * this.currentSpeed * Time.deltaTime, true);
                break;
            case MovementDirection.UPLEFT:
                moveObjectTo(transform, Vector3.up * this.currentSpeed * Time.deltaTime, true);
                moveObjectTo(transform, Vector3.left * this.currentSpeed * Time.deltaTime, true);
                break;
            case MovementDirection.UPRIGHT:
                moveObjectTo(transform, Vector3.up * this.currentSpeed * Time.deltaTime, true);
                moveObjectTo(transform, Vector3.right * this.currentSpeed * Time.deltaTime, true);
                break;
            case MovementDirection.STAY:
                break;
        }
    }

    private void moveObjectTo(Transform transform, Vector3 to, bool dualMovement = false)
    {
        transform.position += to;
        if (currentSpeed < 3.0f)
            currentSpeed += (dualMovement) ? 0.0125f : 0.025f;
    }
    private void decreaseMovementSpeed()
    {
        if (currentSpeed > 0.0000f && currentSpeed - 0.05f > 0.0000f)
        {
            currentSpeed -= 0.05f;
        }
        else
        {
            currentSpeed = 0f;
        }
        // Debug.Log("currentSpeed: " + currentSpeed);
    }
}