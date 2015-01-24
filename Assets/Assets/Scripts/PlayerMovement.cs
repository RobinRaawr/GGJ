using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

    public bool walking, ducking, jumping, isJumping;
    public KeyCode Left, Right, jumpKey, duckKey;
    public int minLane, maxLane, jumpingTimer;
    int timer;
    public float laneHeight = 2.7f;
    public int startLane, currentLane;
    public GameObject otherPlayer;
    bool outOfBoundsMin = false, outOfBoundsMax = false, isOverlapped = false;

    void Start()
    {
        walking = true;
        currentLane = startLane; // De currentLane wordt berekend in Movement();
    }

    void Update()
    {
        CantGoOffLane();
        Movement();
        if (isJumping == true)
        {
            timer++;
            if (timer > jumpingTimer)
            {
                timer = 0;
                this.transform.position += new Vector3(0f, -1f, 0f);
                isJumping = false;
                jumping = false;
                walking = true;
            }
        }
    }

    void Movement()
    {
        float verticalMovement = (Input.GetAxisRaw("Vertical"));

        if (!outOfBoundsMin)
        {
            if (Input.GetKeyDown(Left))
            {
                this.transform.position += new Vector3(0, 0, laneHeight);
                currentLane--;
            }
        }

        if (!outOfBoundsMax)
        {
            if (Input.GetKeyDown(Right))
            {
                this.transform.position -= new Vector3(0, 0, laneHeight);
                currentLane++;
            }
        }

        if(Input.GetKeyDown(duckKey))
        {
            if (walking == true)
            {
                transform.localScale += new Vector3(0f, -0.6f, 0f);
                ducking = true;
                walking = false;
            }
        }

        if (Input.GetKeyUp(duckKey))
        {
            if (ducking == true)
            {
                transform.localScale += new Vector3(0f, 0.6f, 0f);
                ducking = false;
                walking = true;
            }
        }

        if (Input.GetKeyDown(jumpKey))
        {
            if (isJumping == false && walking == true)
            {
                this.transform.position += new Vector3(0f, 1f, 0f);
                jumping = true;
                walking = false;
                isJumping = true;
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
