using UnityEngine;
using System.Collections;

public class RotateCamera : MonoBehaviour 
{

	// Use this for initialization
    [Range(0, 100)]
    public float _rotationspeed;
    Quaternion identity;
    public float _totalrotation;


	void Start () 
    {
        _totalrotation = 0;
        identity = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () 
    {   
        _totalrotation += _rotationspeed * Time.deltaTime;

        Quaternion rotation = transform.rotation;
        rotation.y += _totalrotation;
        transform.rotation = rotation;

        //identity.y += _rotationspeed;
        //transform.rotation = identity;
      
        transform.Rotate(new Vector3(0, _totalrotation, 0));
	}
}
