using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class forkliftMove : MonoBehaviour {

    private float speed, turnSpeed,lifterSpeed,lifterTopConstraint;
    private float lifterAngle;

    public GameObject lifter,lifterArm, rayCastPt,palletProp;

	void Start () {
        speed = 30f;
        turnSpeed = 50f;
        lifterSpeed = 10;
	
	}
	
	// Update is called once per frame
	void Update () {

        //raycast
        RaycastHit hit;
        Vector3 forward = rayCastPt.transform.TransformDirection(Vector3.forward) * 10;

        if (Physics.Raycast(rayCastPt.transform.position,forward,out hit,10))
        {
            Debug.Log(hit.collider.gameObject.tag); //test
            if (hit.collider.gameObject.tag.Equals("Crate"))
            {
                Destroy(hit.collider.gameObject);
                palletProp.SetActive(true);
                //hit.collider.gameObject.transform.position = lifter.transform.position;
            }
        }

        
        Debug.DrawRay(rayCastPt.transform.position, forward, Color.green);
     

            float vert = Input.GetAxis("Vertical");
        float horiz = Input.GetAxis("Horizontal");

        transform.Translate(0, -vert * speed * Time.deltaTime, 0);//move forward
        if (!vert.Equals(0))
            transform.Rotate(0, 0, turnSpeed * horiz * Time.deltaTime);//turn

        if (Input.GetButton("Fire1") && lifterTopConstraint < 252)//raise lifter
        {
            lifter.transform.Translate(-lifterSpeed * Time.deltaTime, 0, 0);
            lifterTopConstraint+=2;
        }
        else if (Input.GetButton("Fire2") && lifterTopConstraint > 0)//lower lifter
        {
            lifter.transform.Translate(lifterSpeed * Time.deltaTime, 0, 0);
            lifterTopConstraint-=2;
        }


        if (Input.GetButton("Fire3") && lifterAngle > -150)//angle lifter
        {
            lifterArm.transform.Rotate(0, lifterSpeed * Time.deltaTime, 0);
            lifterAngle-=2;
        }
        else if (Input.GetButton("Jump") && lifterAngle < 70)//angle lifter
        {
            lifterArm.transform.Rotate(0, -lifterSpeed * Time.deltaTime, 0);
            lifterAngle += 2;
        }


    }
   
}
