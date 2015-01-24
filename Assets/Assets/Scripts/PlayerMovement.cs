using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

    public bool walking, ducking, jumping, isJumping;
    public KeyCode Up, Down, jumpKey, duckKey;

    public int jumpingTimer;
    int timer;
	
    public float laneHeight = 2.7f;
    public int startLane, currentLane;
    public GameObject otherPlayer;
	bool outOfBoundsMin = false, outOfBoundsMax = false;

    void Start()
    {
        walking = true;
        currentLane = startLane; // De currentLane wordt berekend in Movement();
		CantGoOffLane();
    }

    void Update()
    {
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

        if (Input.GetKeyDown(Up))
        {
			if (!outOfBoundsMin)
			{
				if (LaneFree(currentLane - 1))
				{
					this.transform.position += new Vector3(0, 0, laneHeight);
					currentLane--;
					CantGoOffLane();
				}
            }
        }

        if (Input.GetKeyDown(Down))
        {
			if (!outOfBoundsMax)
			{
				if (LaneFree(currentLane + 1))
				{
					this.transform.position -= new Vector3(0, 0, laneHeight);
                	currentLane++;
					CantGoOffLane();
				}
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
		outOfBoundsMin = false;
		outOfBoundsMax = false;

        if (currentLane <= 0)
            outOfBoundsMin = true;
        else if (currentLane >= PlaneControl.control.lanes - 1)
            outOfBoundsMax = true;
    }

	bool LaneFree(int lane)
	{
		if (lane == otherPlayer.GetComponent<PlayerMovement> ().currentLane)
			return false;
		else
			return true;
	}
}
