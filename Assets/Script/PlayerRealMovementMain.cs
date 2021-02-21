using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRealMovementMain : MonoBehaviour
{
    public float maxTurnRate = 1200f;
    public Vector3 maxImpulse = new Vector3(700f, 700f, 2000f);
    public Vector3 velocity = Vector3.zero;
    public float impulseSensitivity = 500f;
    public float turnSensitivity = 1200f;

    public ParticleSystem leftExhaustFX;
    public ParticleSystem rightExhaustFX;

    private Vector3 impulse = Vector3.zero;
    private float desiredImpulse = 0f;
    private Vector3 impulseActual = Vector3.zero;
    private float maxImpulseChange = 400f;
    private Vector3 turnRate = Vector3.zero;
    private float desiredImpulseInput = 0f;
    private float desiredTurnXInput = 0f;
    private float desiredTurnYInput = 0f;
   
    private float desiredTurnX = 0f;
    private float desiredTurnY = 0f;

    private Transform thisTransform;
    public float enginePowerValue = 0f;

    public AudioClip soundThrust;
    //public UnityEngine.UI.Text enginePercentageText;






    public Vector3 Velocity {
        get
        {
            return velocity;
        }
    }
    public Vector3 Impulse
    {
        get
        {
            return impulse;
        }
        set
        {
            impulse.x = Mathf.Clamp(value.x, 0, maxImpulse.x );
            impulse.y = Mathf.Clamp(value.y, 0, maxImpulse.y);
            impulse.z = Mathf.Clamp(value.z, 0, maxImpulse.z);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        thisTransform = transform;

        
        
    }
    void OnEnginePowerChange()
    {
        //if (!enginePercentageText != null)
        //{
         //   enginePowerValue = (desiredImpulse / maxImpulse.z * 100) / 100f;

         //   enginePercentageText.text = "Engines" + "" + (enginePowerValue * 100).ToString("f0") + "%";
       // }
    }

    //void AdjustEngineFX()
   //{
        //if(leftExhaustFX != null && rightExhaustFX != null)
        //{
        //    leftExhaustFX.startSize = 1f + enginePowerValue * 2f;
         //   rightExhaustFX.startSize = 1f + enginePowerValue * 2f;

          //  leftExhaustFX.startSpeed = 1f + enginePowerValue * 3f;
         //   rightExhaustFX.startSpeed = 1f + enginePowerValue * 3f;
      //  }
   // }

    // Update is called once per frame
    void Update()
    {
        
        


        OnEnginePowerChange();
       // AdjustEngineFX();
        CheckInput();

        thisTransform.Rotate(turnRate * Time.deltaTime, Space.Self);

        if (Vector3.Distance(Impulse, impulseActual) < maxImpulseChange * Time.deltaTime) 
        {
            impulseActual = impulse;
        }
        else
        {
            impulseActual += (impulse - impulseActual).normalized * maxImpulseChange * Time.deltaTime;

        }
        velocity = thisTransform.rotation * impulseActual / 3f;   // Speed Reduce
        thisTransform.Translate(velocity * Time.deltaTime, Space.World);
        
    }

    void CheckInput()
    {
        if(this == null)
        {
            return;
        }

        desiredImpulseInput = 0f;
        desiredTurnXInput = 0f;
        desiredTurnYInput = 0f;
        desiredTurnX = 0f;
        desiredTurnY = 0f;

        desiredImpulseInput += Input.GetAxis("Thrust") * impulseSensitivity * Time.deltaTime;
        desiredImpulse = (Mathf.Clamp(desiredImpulseInput, GetImpulse2(), GetMaxImpulse2()));
        desiredImpulse += desiredImpulseInput;

        desiredTurnXInput += Input.GetAxis("Vertical") * impulseSensitivity * Time.deltaTime;
        desiredTurnX = (Mathf.Clamp(desiredTurnXInput, -GetMaxTurnRate(), GetMaxTurnRate()));
        desiredTurnX += desiredTurnXInput;

        desiredTurnYInput += Input.GetAxis("Horizontal") * impulseSensitivity  *1* Time.deltaTime; // Rotate Sensitive
        desiredTurnY = (Mathf.Clamp(desiredTurnXInput, -GetMaxTurnRate(), GetMaxTurnRate()));
        desiredTurnY += desiredTurnYInput;

        SetImpulse2(desiredImpulse);
        SetTurnRate(desiredTurnX, desiredTurnY, 0);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            AudioSource.PlayClipAtPoint(soundThrust, transform.position);
            Debug.Log("Sound thrust on");
        }
    }

    public void SetImpulse2(float z) 
    {
        Impulse = new Vector3(0, 0, z);
    }

    public float GetImpulse2()
    {
        return impulse.z;
    }
    public float GetMaxImpulse2()
    {
        return maxImpulse.z;
    }
    public void SetTurnRate(float x , float y, float z)
    {
        turnRate.x = Mathf.Clamp(x, -maxTurnRate, maxTurnRate);
        turnRate.y = Mathf.Clamp(y, -maxTurnRate, maxTurnRate);
        turnRate.z = Mathf.Clamp(z, -maxTurnRate, maxTurnRate);

    }
    public void SetTurnRate(Vector3 v)
    {
        SetTurnRate(v.x, v.y, v.z);
    }
    public Vector3 GetTurnRate()
    {
        return turnRate;
    }
    public float GetMaxTurnRate()
    {
        return maxTurnRate;
    }
}
