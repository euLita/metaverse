using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    [SerializeField] private List<Pin> pins = new List<Pin>();

    private GameObject ballInstance;
    private int totalFrames;
    private int balls = 1;
    private bool = countingPins; // here
    public static GameController Instance;

    void Awake ()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        NextFrame(); 
    }

    public void NextFrame () {
        if (totalFrames == 10) {
            // End Game
            return;
        }
        balls = 1;
        ResetBall(); // here
        ResetPins();
        totalFrames = totalFrames + 1; // or totalFrames++
    }

    public void ResetPins () {
        if (countingPins) return;
        countingPins = true;
        StartCoroutine(CountingPins());
    }

    IEnumerator CountingPins () {
        yield return new WaitForSeconds(5);
        if (balls == 1) {
            int fallenPins = 0;

            foreach(Pin pin in pins) {
                if (pin.fallen) fallenPins++;
            }

            if (fallenPins == 10) {
                // strike
            } else {
                balls = 2;
                CountingPins = false;
                ResetBall();
                RemoveFallenPins();
                yield break;
            }
        } else {
            int fallenPins = 0;
            foreach (Pin pin in pins) {
                if (pin.fallen && !pin.removed) {
                    fallenPins++;
                }
            }
        } 

        CountingPins = false;
        NextFrame(); 
    }

    void RemoveFallenPins() {
        foreach (Pin pin in pins) {
            if (pin.fallen) pin.RemovePin();
        }
    }

    public void ResetPins () {
        foreach (Pin pin in pins) {
            if (pin.fallen) pin.Reset ();
        }
    }

    public void ResetBall ()
    {
        if (ballInstance != null) Destroy(ballInstance);
        ballInstance = Instantiate(ball, transform.position, transform.rotation);
    }
}
