using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public float forceMultiplier = 10f;
    private Rigidbody2D rb;

    public float powerIncriment = 5;
    private float power = 0f;

    [SerializeField]
    private GameObject highlighter;
    [SerializeField] 
    private GameObject aimImage;

    [SerializeField]
    private GameObject energyBallImage;
    private float rotationSpeed = 270f;

    public BallState State { get; private set; }
    public enum BallState
    {
        REST,
        CHARGING,
        MOVING
    }

    // Start is called before the first frame update
    void Start()
    {
        State = BallState.REST;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManagerScript.instance.gameState != GameManagerScript.GameState.PLAY)
            return;

        SetScale();

        if (State == BallState.REST)
        {
            SetRestImages(true);
            if(Input.GetMouseButtonDown(0))
            {
                power = 0f;
                State = BallState.CHARGING;
            }
        }
        else
        {
            
        }

        if (State == BallState.CHARGING)
        {
            if(Input.GetMouseButton(0))
            {
                power += powerIncriment * Time.deltaTime;
                power = Mathf.Clamp(power, 0f, 10f);
            }

            if(Input.GetMouseButtonUp(0))
            {
                Debug.Log(power);
                Shoot(power);
            }
        }

        if (State == BallState.MOVING)
        {
            SetRestImages(false);
            RotateImage();
            if (rb.velocity.magnitude < 0.5f)
            {
                rb.velocity = Vector2.zero;
                State = BallState.REST;
            }
        }

        if(State == BallState.REST || State == BallState.CHARGING)
        {
            LookAtMouse();
        }
    }

    private void SetRestImages(bool _state)
    {
        highlighter.SetActive(_state);
        aimImage.SetActive(_state);
    }

    private void RotateImage()
    {
        if(State == BallState.MOVING)
        {
            energyBallImage.transform.Rotate(0, 0, -rotationSpeed * Time.deltaTime);
        }
    }

    public void LookAtMouse()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mouseWorldPos - transform.position;
        direction.z = 0f;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    public void Shoot(float _power)
    {
        Vector2 ballPos = transform.position;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 dir = (mousePos - ballPos).normalized;

        rb.AddForce(forceMultiplier * _power * dir, ForceMode2D.Impulse);
        State = BallState.MOVING;
    }

    public void SetScale()
    {
        transform.localScale = new Vector3(0.75f + (0.125f * GameManagerScript.instance.ballEnergy), 0.75f + (0.125f * GameManagerScript.instance.ballEnergy), 0); 
    }
}
