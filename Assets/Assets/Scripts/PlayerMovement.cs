using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

    public bool walking, ducking, jumping;
    public KeyCode Up, Down;
    public int minLane, maxLane;
    public float laneHeight = 2.7f;
    public int startLane, currentLane;
    public GameObject otherPlayer;
    bool outOfBoundsMin = false, outOfBoundsMax = false, isOverlapped = false;

    void Start()
    {
        currentLane = startLane; // De currentLane wordt berekend in Movement();
    }

    void Update()
    {
        CantGoOffLane();
        Movement();
    }

    void Movement()
    {
        float verticalMovement = (Input.GetAxisRaw("Vertical"));

        if (!outOfBoundsMin)
        {
            if (Input.GetKeyDown(Up))
            {
                this.transform.position += new Vector3(0, 0, laneHeight);
                currentLane--;
            }
        }

        if (!outOfBoundsMax)
        {
            if (Input.GetKeyDown(Down))
            {
                this.transform.position -= new Vector3(0, 0, laneHeight);
                currentLane++;
            }
        }
    }
    void CantGoOffLane()
    {
        if (currentLane <= minLane)
        {
            outOfBoundsMin = true;
        }
        else
        {
            outOfBoundsMin = false;
        }
        if (currentLane >= maxLane)
        {
            outOfBoundsMax = true;
        }
        else
        {
            outOfBoundsMax = false;
        }
    }

    void AvoidPlayerOverlap()
    {
        if (Vector3.Distance(this.transform.position, otherPlayer.transform.position) <= 0)
        {
            isOverlapped = true;
        }
        else
        {
            isOverlapped = false;
        }
    }

}
