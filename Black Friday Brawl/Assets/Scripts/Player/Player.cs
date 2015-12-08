using UnityEngine;
using System.Collections;

public enum TeamColour
{
    RED,
    BLUE,
    GREEN,
    YELLOW
};


public class Player : MonoBehaviour 
{
    public TeamColour _teamcolour;
    protected Weapon _weapon;


    public float _movespeed;
    public float _stamina;
    public int _health;
    public int _attackstrength;

    public bool _isCarryingObject;
    private float _iteamweight;
    private Animator _Animator;

	// Use this for initialization
	void Start ()
    {
        _Animator = GetComponent<Animator>();

        #region SetTeamColour
        switch (_teamcolour)
        {
            case TeamColour.RED:
                SetColour(Color.red);
                break;
            case TeamColour.BLUE:
                SetColour(Color.blue);
                break;
            case TeamColour.GREEN:
                SetColour(Color.green);
                break;
            case TeamColour.YELLOW:
                SetColour(Color.yellow);
                break;
            default:
                break;
        }
        #endregion
    }
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    /// <Use Attack Summary>
    /// TODO: Add more functunality to this
    /// its just for making the player attack
    /// this is called in the input manager anyways
    /// </summary>
    public void UseAttack()
    {
        if(!_isCarryingObject)
        {
            Debug.Log("Attacking");
                return;
        }

        Debug.Log("Cannot Attack, Holding Iteam");

        _Animator.SetTrigger("IsPunching");
    }

    /// <Move Direction summary>
    /// This just makes the player move in a Vector3 Direction there asked to go in
    /// Called in the input Manager
    /// </summary>
    /// <param name="Direction"></param>
    public void MoveInDirection(Vector3 Direction)
    {
            Vector3 NewDirection = (Direction * _movespeed * Time.deltaTime);
            Debug.Log("The Current Direction" + NewDirection.ToString());
            transform.position += NewDirection;


            Vector3 NewPosition = transform.position + NewDirection;


            if (Direction != Vector3.zero)
            {
                Vector3 relativePos = transform.position - NewPosition;
                Quaternion rotation = Quaternion.LookRotation(-relativePos);
                transform.rotation = rotation;
            }

            transform.position += NewDirection;

            _Animator.SetTrigger("IsRunning");
    }

    /// <Pick up Iteam Summary>
    /// This function adds a iteam component to parent object
    /// the parent component has a score value as well as a weightvalue
    /// we just tether the weight value though onto our player for purposes
    /// </summary>
    /// <param name="weightval"></param>
    /// <param name="scoreval"></param>
    public void PickUpIteam(int weightval, int scoreval)
    {
        if (!_isCarryingObject)
        {
            Iteam iteam = gameObject.AddComponent<Iteam>();
            iteam.SetScoreValue(scoreval);
            iteam.SetWeightValue(weightval);
            _iteamweight = weightval;
            _isCarryingObject = true;
            Debug.Log("Picked up iteam");
        }
    }

    /// <Remove Iteam summary>
    /// Removes a iteam component from this game object
    /// i hope it works
    /// </summary>
    public void RemoveIteam()
    {
        _isCarryingObject = false;
        if(GetComponent<Iteam>() != null)
        {
            _isCarryingObject = false;
            Destroy(GetComponent<Iteam>());
            Debug.Log("Dropped/Removed Iteam");
        }
    }

    public void SetColour(Color colour)
    {
        Transform shader = gameObject.transform.Find("body3");
        Renderer rend = shader.GetComponent<Renderer>();

        rend.material.color = colour;
    }

}
