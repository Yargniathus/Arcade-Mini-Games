using System.Threading;
using UnityEngine;
using Xamk.GymApi;

public class MovementScriptLabyrintti : MonoBehaviour
{
    // Transforms to act as start and end markers for the journey.
    public Vector2 startMarker;
    public Vector2 endMarker;

    public bool movement;

    // Movement speed in units per second.
    public float speed = 1.0F;

    // Time when the movement started.
    private float startTime;

    // Total distance between the markers.
    private float journeyLength;

    public static Animator LabyrinttiJonesAnimator;

    private CancellationTokenSource cancelTokenSource;
    private GymMachineListener gymMachineListener;

    private void Start()
    {
        movement = false;
        LabyrinttiJonesAnimator = GetComponent<Animator>();
        // Keep a note of the time the movement started.
        startTime = Time.time;

        // Calculate the journey length.
        journeyLength = Vector2.Distance(startMarker, endMarker);

        cancelTokenSource = new CancellationTokenSource();
        gymMachineListener = new GymMachineListener(HurObject.Machine.OptimalRhomb);
        gymMachineListener.LeftRepHandler += LeftRepHandler;
        gymMachineListener.RightRepHandler += RightRepHandler;
        gymMachineListener.StartListener(cancelTokenSource.Token);
    }

    private void LeftRepHandler(object sender, LeftRepEventArgs e)
    {
        if(movement)
            return;

        startTime = Time.time;
        startMarker = new Vector2(transform.position.x, transform.position.y);
        endMarker = new Vector2(transform.position.x - 1, transform.position.y);
        movement = true;
        LabyrinttiJonesAnimator.SetBool("MovingLeft", true);
        LabyrinttiJonesAnimator.SetInteger("LastMovementDirection", 0);
        MovementHandling();
    }

    private void RightRepHandler(object sender, RightRepEventArgs e)
    {
        if (movement)
            return;

        startTime = Time.time;
        startMarker = new Vector2(transform.position.x, transform.position.y);
        endMarker = new Vector2(transform.position.x + 1, transform.position.y);
        movement = true;
        LabyrinttiJonesAnimator.SetBool("MovingRight", true);
        LabyrinttiJonesAnimator.SetInteger("LastMovementDirection", 2);
        MovementHandling();
    }

    // Move to the target end position.
    private void Update()
    {
        if (GameStartLabyrintti.LabyrinttiGameStarted)
        {
            if (!movement)
            {
                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    startTime = Time.time;
                    startMarker = new Vector2(transform.position.x, transform.position.y);
                    endMarker = new Vector2(transform.position.x, transform.position.y - 1);
                    movement = true;
                    LabyrinttiJonesAnimator.SetBool("MovingDown", true);
                    LabyrinttiJonesAnimator.SetInteger("LastMovementDirection", 1);
                }

                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    gymMachineListener.SimulateLeftRep(1, 20, 500);
                }

                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    gymMachineListener.SimulateRightRep(1, 20, 500);
                } 
            }

            MovementHandling();
        }
    }

    private void MovementHandling()
    {
        if (!movement)
            return;

        // Distance moved equals elapsed time times speed..
        var distCovered = (Time.time - startTime) * speed;

        // Fraction of journey completed equals current distance divided by total distance.
        var fractionOfJourney = distCovered / journeyLength;

        // Set our position as a fraction of the distance between the markers.
        transform.position = Vector2.Lerp(startMarker, endMarker, fractionOfJourney);
        if (fractionOfJourney > 0.99)
        {
            movement = false;
            LabyrinttiJonesAnimator.SetBool("MovingDown", false);
            LabyrinttiJonesAnimator.SetBool("MovingLeft", false);
            LabyrinttiJonesAnimator.SetBool("MovingRight", false);
        }
    }

    private void OnDestroy()
    {
        if (gymMachineListener != null) cancelTokenSource.Cancel();
    }
}


//if (Input.GetKeyDown(KeyCode.RightArrow))
//{

//    this.transform.position = new Vector2(this.transform.position.x + 1, this.transform.position.y);
//}
//if (Input.GetKeyDown(KeyCode.LeftArrow))
//{
//    this.transform.position = new Vector2(this.transform.position.x + -1, this.transform.position.y);
//}