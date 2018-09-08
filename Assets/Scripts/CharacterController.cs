using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class CharacterController : MonoBehaviour {

    private const float speed = .15f;
    private Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        float x = CrossPlatformInputManager.GetAxis("Horizontal");
        float y = CrossPlatformInputManager.GetAxis("Vertical");

        // Rotate to face direction if we are moving
        if (!x.Equals(0) && !y.Equals(0)) {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Atan2(x, y) * Mathf.Rad2Deg, transform.eulerAngles.z);
            //anim.SetFloat("Direction", Mathf.Atan2(x, y) * Mathf.Rad2Deg);
        }

        // Move Unity-chan in direction
        if (!x.Equals(0) || !y.Equals(0)) {
            transform.position += transform.forward * Time.deltaTime * speed;
            anim.SetFloat("Speed", speed);
        } else {
            anim.SetFloat("Speed", 0);
        }
	}

    public void PlaceCharacter () {
        transform.localPosition = Vector3.zero;
    }
}
