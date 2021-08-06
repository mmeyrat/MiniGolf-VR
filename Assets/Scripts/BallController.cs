using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour {
    private int count;
    private int courseId;
    private int shotNb;
    private int clubPower;
    private int angle;
    private bool hasPassed;
    private bool hasShooted;
    private bool isMoving;
    private bool isTextDisplayed;
    public Rigidbody rigidbody;
    public Material skyboxDay;
    public Material skyboxNight;
    public Canvas canvas;
    public Text countText;
    public Text winText;
    public AudioClip audioclip;

    void Start () {
        count = 0;
        winText.text = "";
        courseId = 1;
        shotNb = 0;
        clubPower = 1;
        angle = 0;
        hasPassed = false;
        hasShooted = false;
        isMoving = false;
        isTextDisplayed = true;

        SetText ();
    }

    void FixedUpdate () {
        if (rigidbody.velocity.magnitude < 0.5f && isMoving) {
            rigidbody.velocity = Vector3.zero;
            rigidbody.angularVelocity = Vector3.zero;
            isMoving = false;
            gameObject.transform.GetChild(1).gameObject.SetActive(true);
        }
        if (OVRInput.Get (OVRInput.RawButton.A) || Input.GetKey ("m")) {
            transform.rotation = Quaternion.Euler (0, angle * 10f, 0);
            if ((angle * 10) >= 360) {
                angle = 0;
            } else {
                angle++;
            }
        }
        if (Time.frameCount % 4 == 0) {
            if (OVRInput.Get (OVRInput.RawButton.B) || Input.GetKey ("p")) {
                SetBallPos ();
            }
            if (OVRInput.Get (OVRInput.RawButton.Y) || Input.GetKeyDown ("o")) {
                if (isTextDisplayed) {
                    isTextDisplayed = false;
                    canvas.enabled = false;
                } else {
                    isTextDisplayed = true;
                    canvas.enabled = true;
                }
            }
            if (OVRInput.Get (OVRInput.RawButton.LIndexTrigger) || Input.GetKey ("i")) {
                if (clubPower > 1) {
                    clubPower--;
                }
            }
            if (OVRInput.Get (OVRInput.RawButton.RIndexTrigger) || Input.GetKey ("k")) {
                if (clubPower < 8) {
                    clubPower++;
                }
            }
        }
        SetText ();
    }

    void OnTriggerEnter (Collider other) {
        if (other.gameObject.CompareTag ("Pick Up")) {
            other.gameObject.SetActive (false);
            count++;
        }
        if (other.gameObject.CompareTag ("Hole") && !hasPassed) {
            //play the audio clip
            float xPos = this.transform.position.x;
            float yPos = this.transform.position.x;
            float zPos = this.transform.position.x;
            AudioSource.PlayClipAtPoint(audioclip, new Vector3(xPos, yPos, zPos), 10);

            hasPassed = true;
            courseId++;
            SetBallPos ();
            StartCoroutine (wait ());
        }
        if (other.gameObject.CompareTag ("Club") && !hasShooted) {
            hasShooted = true;
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
            shotNb++;
            rigidbody.AddForce (transform.forward * (clubPower * 5f), ForceMode.Impulse);
            StartCoroutine (wait ());
        }
    }

    private IEnumerator wait () {
        yield return new WaitForSeconds (3);
        hasPassed = false;
        hasShooted = false;
        isMoving = true;
    }

    void SetBallPos () {
        switch (courseId) {
            case 1:
                transform.position = new Vector3 (9.25f, 32.2f, -39);
                transform.rotation = Quaternion.Euler (0, 180, 0);
                break;
            case 2:
                RenderSettings.skybox = skyboxDay;
                transform.position = new Vector3 (10, 32.2f, -10);
                transform.rotation = Quaternion.Euler (0, -90, 0);
                break;
            case 3:
                RenderSettings.skybox = skyboxNight;
                transform.position = new Vector3 (0, 32.2f, -83.1f);
                transform.rotation = Quaternion.Euler (0, -90, 0);
                break;
            case 4:
                winText.text = "Game finished!";
                this.enabled = false;
                break;
            default:
                break;
        }
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
    }

    void SetText () {
        if (isTextDisplayed) {
            countText.text = "Score : " + count + "\n" +
                "Current course : " + courseId + "\n" +
                "Number of shots : " + shotNb + "\n" +
                "Club power : ";
            for (int i = 0; i < clubPower; i++) {
                countText.text += "▌";
            }
        }
    }
}