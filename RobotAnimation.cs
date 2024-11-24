using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotAnimation : MonoBehaviour
{
    public Animator ani;

    //animator parameters
    string[] animatorParams = new string[] { "hi_hat", "snare", "hi_tom", "mid_tom", "low_tom", "crash", "cymbal", "kick" };
    // public string boolHiHat = "hi-hat_snare";
    // public string boolToms = "toms";
    int numHittingTargets = 8;
    int numTimeFrames = 16;
    int[,] drumMatrix;
    float timePerFrame = 1.0f;
    // private bool switchAnimation = false;
    // private string nextAnimation = "";


    private PlayerControls controls;

    // Start is called before the first frame update

    void Start()
    {
        ani = GetComponent<Animator>();
        GenerateRandomMatrix();
        StartCoroutine(PlayDrumMatrix());
    }

    // Generate a random matrix with 0s and 1s
    // void GenerateRandomMatrix()
    // {
    //     drumMatrix = new int[numHittingTargets, numTimeFrames];
    //     for (int i = 0; i < numHittingTargets; i++)
    //     {
    //         for (int j = 0; j < numTimeFrames; j++)
    //         {
    //             drumMatrix[i, j] = Random.Range(0, 2); // Randomly assign 0 or 1
    //         }
    //     }
    // }
    void GenerateRandomMatrix()
    {
        drumMatrix = new int[numHittingTargets, numTimeFrames];
        for (int frame = 0; frame < numTimeFrames; frame++)
        {
            // Randomly select one hitting target for this time frame
            int target = Random.Range(0, numHittingTargets);

            // Set the selected target to 1 and others to 0
            for (int i = 0; i < numHittingTargets; i++)
            {
                if (i == target)
                    drumMatrix[i, frame] = 1;
                else
                    drumMatrix[i, frame] = 0;
            }
        }
    }

    // Coroutine to play the drum matrix
    IEnumerator PlayDrumMatrix()
    {
        for (int frame = 0; frame < numTimeFrames; frame++)
        {
            // For each hitting target at the current time frame
            for (int target = 0; target < numHittingTargets; target++)
            {
                if (drumMatrix[target, frame] == 1)
                {
                    // Trigger the animation for this hitting target
                    TriggerAnimationForTarget(target);
                }
            }
            // Wait for the duration of the time per frame
            yield return new WaitForSeconds(timePerFrame);
        }
    }

    // Function to trigger the animation for a specific hitting target
    void TriggerAnimationForTarget(int target)
    {
        string paramName = animatorParams[target];
        ani.SetTrigger(paramName);
    }
 


    // Update is called once per frame

    void Awake()
    {
        //controls = new PlayerControls();

        // Subscribe to the SwitchAnimation action
        // controls.Gameplay.SwitchToToms.performed += ctx => switchToToms();
        // controls.Gameplay.SwitchToHihat.performed += ctx => switchToHihat();
    }

    void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    void OnDisable()
    {
        controls.Gameplay.Disable();
    }

    // void switchToToms()
    // {
    //     ani.SetBool(boolToms, true);
    // }

    // void switchToHihat()
    // {
    //     ani.SetBool(boolHiHat, true);
    // }


    // void OnSwitchAnimation()
    // {
    //     // Set the flag to switch animation
    //     switchAnimation = true;
    //     // Specify the name of the next animation state
    //     nextAnimation = "toms"; // Replace with your actual animation state name
    // }

    void Update()
    {
        // Check if hi-hat_snare animation is playing
        if (ani.GetCurrentAnimatorStateInfo(0).IsName("hi_hat"))
        {
            AnimatorStateInfo stateInfo = ani.GetCurrentAnimatorStateInfo(0);
            if (stateInfo.normalizedTime >= 0.7f && !ani.IsInTransition(0))
            {
                ani.SetBool("hi_hat", false); // Reset the boolean when animation completes
            }
        }

        // Check if toms animation is playing
        if (ani.GetCurrentAnimatorStateInfo(0).IsName("snare"))
        {
            AnimatorStateInfo stateInfo = ani.GetCurrentAnimatorStateInfo(0);
            if (stateInfo.normalizedTime >= 0.7f && !ani.IsInTransition(0))
            {
                ani.SetBool("snare", false); // Reset the boolean when animation completes
            }
        }

        // Check if toms animation is playing
        if (ani.GetCurrentAnimatorStateInfo(0).IsName("hi_tom"))
        {
            AnimatorStateInfo stateInfo = ani.GetCurrentAnimatorStateInfo(0);
            if (stateInfo.normalizedTime >= 0.7f && !ani.IsInTransition(0))
            {
                ani.SetBool("hi_tom", false); // Reset the boolean when animation completes
            }
        }

        // Check if toms animation is playing
        if (ani.GetCurrentAnimatorStateInfo(0).IsName("mid_tom"))
        {
            AnimatorStateInfo stateInfo = ani.GetCurrentAnimatorStateInfo(0);
            if (stateInfo.normalizedTime >= 0.7f && !ani.IsInTransition(0))
            {
                ani.SetBool("mid_tom", false); // Reset the boolean when animation completes
            }
        }

        // Check if toms animation is playing
        if (ani.GetCurrentAnimatorStateInfo(0).IsName("low_tom"))
        {
            AnimatorStateInfo stateInfo = ani.GetCurrentAnimatorStateInfo(0);
            if (stateInfo.normalizedTime >= 0.7f && !ani.IsInTransition(0))
            {
                ani.SetBool("low_tom", false); // Reset the boolean when animation completes
            }
        }

        // Check if toms animation is playing
        if (ani.GetCurrentAnimatorStateInfo(0).IsName("crash"))
        {
            AnimatorStateInfo stateInfo = ani.GetCurrentAnimatorStateInfo(0);
            if (stateInfo.normalizedTime >= 0.7f && !ani.IsInTransition(0))
            {
                ani.SetBool("crash", false); // Reset the boolean when animation completes
            }
        }

        // Check if toms animation is playing
        if (ani.GetCurrentAnimatorStateInfo(0).IsName("symbal"))
        {
            AnimatorStateInfo stateInfo = ani.GetCurrentAnimatorStateInfo(0);
            if (stateInfo.normalizedTime >= 0.7f && !ani.IsInTransition(0))
            {
                ani.SetBool("symbal", false); // Reset the boolean when animation completes
            }
        }

        // Check if toms animation is playing
        if (ani.GetCurrentAnimatorStateInfo(0).IsName("kick"))
        {
            AnimatorStateInfo stateInfo = ani.GetCurrentAnimatorStateInfo(0);
            if (stateInfo.normalizedTime >= 0.7f && !ani.IsInTransition(0))
            {
                ani.SetBool("kick", false); // Reset the boolean when animation completes
            }
        }
    }

    // void Update()
    // {
    //     if (switchAnimation)
    //     {
    //         // Get the current animation state information
    //         AnimatorStateInfo stateInfo = ani.GetCurrentAnimatorStateInfo(0);

    //         // Check if the current animation has finished playing
    //         if ( ((int)stateInfo.normalizedTime>=(stateInfo.normalizedTime*0.9))  && !ani.IsInTransition(0))
    //         {
    //             // Play the next animation
    //             ani.Play(nextAnimation);
    //             // Reset the flag
    //             switchAnimation = false;
    //         }
    //     }
    // }
}
