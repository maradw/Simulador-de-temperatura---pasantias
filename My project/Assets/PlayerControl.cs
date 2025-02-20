using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
 
    private float _horizontal;
    private float _vertical;
    //private float _rotation = 3f;
    private Rigidbody myRBD;
    [SerializeField] private float velocityModifier = 5f;
    //[SerializeField] private NPCNavMovement NPC
    public Transform cameraRef;

    //public float smoothTime = 0.1f;
    //float smoothVelocity;

    public static event Action OnPlayerGather;
    public static event Action<int> OnPlayerDamage;
    public int _playerLife = 50;
    int force = 3;

    [Header("Anlges Rotations")]
    /*[SerializeField] private Quaternion CameraRotaiton;
    [SerializeField] private Quaternion PlayerRotation;
    [SerializeField] private Vector3 RBVelocity;*/
    [SerializeField] private Vector3 direction;

    /*[SerializeField] private float positionMagnitud;
    [SerializeField] private float ConstAngle;
    [SerializeField] private float TargetAngle;*/

    private bool _canJump;
    private float jumpForce = 7.5f;
    // private Vector3 forceDirection = Vector3.zero;
    private RaycastHit _rayHit1;
    [SerializeField] private LayerMask layer;
    [SerializeField] private float _rayLenght;
    [SerializeField] private Transform _refMovement;

    void Start()
    {
        _canJump = true;
        myRBD = GetComponent<Rigidbody>();
    }

    public void OnMovement(InputAction.CallbackContext move)
    {
        direction = move.ReadValue<Vector3>();

    }
    public void OnShoot(InputAction.CallbackContext shoot)
    {
        if (shoot.performed)
        {

        }
    }
    public void Interact(InputAction.CallbackContext interact)
    {
        // NPC.CallInteract();
    }
    public void Jump(InputAction.CallbackContext jump)
    {
        if (jump.performed && _canJump == true)
        {
            myRBD.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            _canJump = false;

        }

    }

    public void FixedUpdate()
    {
        myRBD.velocity = new Vector3(_refMovement.TransformDirection(direction).normalized.x * velocityModifier, myRBD.velocity.y, _refMovement.TransformDirection(direction).normalized.z * velocityModifier);
        transform.rotation = Quaternion.LookRotation(_refMovement.TransformDirection(Vector3.forward));
        _refMovement.rotation = new Quaternion(0, cameraRef.rotation.y, 0, cameraRef.rotation.w);


        if (Physics.Raycast(transform.position, Vector3.down, out _rayHit1, _rayLenght, layer))
        {
            Debug.DrawRay(transform.position, Vector3.down * _rayHit1.distance, Color.magenta);
            _canJump = true;

        }
        else
        {
            Debug.DrawRay(transform.position, Vector3.down * _rayLenght, Color.green);

        }
    }

    public void DetectEnemy()
    {
        bool hit = false;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hitinfo, 10f))
        {
            hit = true;
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hitinfo.distance, Color.green);

            print("hit");

        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 10f, Color.magenta);
            hit = false;
            if (hit == false)
            {

            }
        }

    }
    public void CreateInventory()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Portal")
        {
           // GameManager.Instance.ChangeScene("Roulette");

        }

        if (other.tag == "Book")
        {
            OnPlayerGather?.Invoke();
        }


        if (other.tag == "ChozuyaTalk")
        {
            Debug.Log("a");
        }
        if (other.tag == "Damage")
        {
            Restlife(6);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {

    }
    private void Restlife(int damage)
    {
        _playerLife -= damage;
    }
    void Update()
    {

       
    }
    

}
