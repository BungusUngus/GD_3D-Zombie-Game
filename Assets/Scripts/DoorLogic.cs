using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLogic : MonoBehaviour
{
    public enum DoorStates
    {
        Opened,
        Closed,
        Opening,
        Closing,
        Locked,
    }

    public Quaternion openingDirection = Quaternion.Euler(0f, 0f, 0f);

    public float waitTime = 5f;
    private float _startOfWait = 0f;

    public float speed = 5f;
    public bool unlockDoor = false;
    public bool doorCycle = true;

    private Quaternion _closedPosition;
    private Quaternion _openPosition;

    public DoorStates state = DoorStates.Closed;

    void Start()
    {
        _closedPosition = transform.rotation;
        _openPosition = openingDirection;
    }

    void Update()
    {
        switch (state)
        {
            case DoorStates.Closed:
                if (waitTime < Time.time - _startOfWait)
                {
                    state = DoorStates.Opening;
                }
                break;

            case DoorStates.Opened:
                if (doorCycle)
                {
                    if (waitTime < Time.time - _startOfWait)
                    {
                        state = DoorStates.Closing;
                    }
                }

                break;
                
            case DoorStates.Closing:
                transform.rotation = Quaternion.RotateTowards(transform.rotation, _closedPosition, speed * Time.deltaTime);

                if (Quaternion.Dot(transform.rotation, _closedPosition) < 0.01f)
                {
                    state = DoorStates.Closed;
                    _startOfWait = Time.time;
                }
                break;

            case DoorStates.Opening:
                transform.rotation = Quaternion.RotateTowards(transform.rotation, _openPosition, speed * Time.deltaTime);

                if (Quaternion.Dot(transform.rotation, _openPosition) < 0.01f)
                {
                    state = DoorStates.Opened;
                    _startOfWait = Time.time;
                }
                break;

            case DoorStates.Locked:
                if (unlockDoor)
                {
                    state = DoorStates.Opening;
                }
                break;
            default:
                break;
        }
    }
}
