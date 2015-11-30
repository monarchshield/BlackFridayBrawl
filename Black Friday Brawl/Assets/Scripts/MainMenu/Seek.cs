using UnityEngine;
using System.Collections;

public class Seek : MonoBehaviour 
{
    /// <Seek Summary>
    /// This is just some visuals for the front screen where all the entities
    /// will be heading towards a pivot point 
    /// </summary>
    
    private GameObject _headinglocation;
    private Vector3 _startinglocation;
    [Range(1, 100)]
    public float _movementSpeed;

    //This is just how long before i reset the objects position to give it the illusion that people are constantly
    //Running towards said building
    public float _durationbeforeResetPosition;

    private float _timer;

    
	// Use this for initialization
	void Start () 
    {
        _timer = _durationbeforeResetPosition;
        ResetPosition();
        _headinglocation = GameObject.Find("Heading Location");

        Vector3 relativePos = transform.position - _headinglocation.transform.position;
        Quaternion rotation = Quaternion.LookRotation(-relativePos);
        transform.rotation = rotation;
	}
	
	// Update is called once per frame
	void Update ()
    {

        Vector3 location = transform.position - _headinglocation.transform.position;
        location.Normalize();
        transform.position -= location * Time.deltaTime * _movementSpeed;

        ResetPosition();
	}    

    public void SetStartLocation(Vector3 location)
    {
        _startinglocation = location;
        transform.position = _startinglocation;

        //Vector3 relativePos = transform.position - _headinglocation.transform.position;
        //Quaternion rotation = Quaternion.LookRotation(relativePos);
        //transform.rotation = rotation;
    }

    private void ResetPosition()
    {
        _timer -= Time.deltaTime;

        if(_timer < 0)
        {
            _timer = _durationbeforeResetPosition;
            transform.position = _startinglocation;
        }
    }

    public void SetColour(Color colour)
    {
        Transform shader = gameObject.transform.Find("ninja 1");
        Renderer rend = shader.GetComponent<Renderer>();

        rend.material.color = colour;

       //rend.material.shader = Shader.Find("lambert2");
       //rend.material.SetColor("_Color", colour);
    }


}
