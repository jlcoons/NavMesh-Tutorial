using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameController gameController;
    public float speed;
    public Camera cam;

    private float frontBack;
    private float leftRight;

    private float lookY = 0;
    private float lookX = 0;

    // Use this for initialization
    void Start () {
        Cursor.lockState = CursorLockMode.Locked;
        lookX = transform.rotation.y;
	}
	
	// Update is called once per frame
	void Update () {
        if (GameController.state.Equals("PLAY"))
        {
            frontBack = Input.GetAxis("Vertical") * speed * Time.deltaTime;
            leftRight = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            transform.Translate(leftRight, 0, frontBack);

            lookY -= Input.GetAxis("Mouse Y");
            lookX += Input.GetAxis("Mouse X");
            cam.transform.localRotation = Quaternion.AngleAxis(lookY, Vector3.right);
            transform.localRotation = Quaternion.AngleAxis(lookX, Vector3.up);
        }
        else if (GameController.state.Equals("BETWEEN_ROUNDS"))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                gameController.StartRound();
            }
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemy" && GameController.state.Equals("PLAY"))
        {
            gameController.EndRound();
        }
    }
}
