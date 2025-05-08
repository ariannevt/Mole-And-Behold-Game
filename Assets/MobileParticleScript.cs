using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MobileParticleScript : MonoBehaviour  //user may attach this to any particle that should move and experience random collisions
{
    public float ParticleSpeed = 4;   //this will determine the average speed of this particle.  Default is speed 4
    private bool UsingTempSlider;
    private float SpeedMultiplierWhenUsingTempSlider = 1;  //default is 1, if the user makes this higher, this type of particle will move faster than the default
    private GameObject TempSlider;
    private Vector2 ParticleVelocityVector;
    private Rigidbody ThisRigidbody;
    private float RandomRadianMeasure;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Physics.bounceThreshold = 0;
        SpeedMultiplierWhenUsingTempSlider = ParticleSpeed / 4;
        if (SpeedMultiplierWhenUsingTempSlider > 2)
        {
            SpeedMultiplierWhenUsingTempSlider = 2;
        }
        ThisRigidbody = GetComponent<Rigidbody>();  //initalize this variable--this script can only be attached to Rigidbody objects
        RandomizeVelocities();
        if (GameObject.Find("TemperatureSlider"))
        {
            UsingTempSlider = true;
            TempSlider = GameObject.Find("TemperatureSlider");
        }

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("MainHub", LoadSceneMode.Single);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (UsingTempSlider)
        {
            ParticleSpeed = TempSlider.GetComponent<TemperatureSliderScript>().SpeedValueFromTempSlider * SpeedMultiplierWhenUsingTempSlider;
            if(ParticleSpeed > 40)
            {
                ParticleSpeed = 40;   //sets a maximum speed of 40 for particles in the scene
            }
        }
        AdjustParticleSpeed();

    }


    public void AdjustParticleSpeed()
    {
        if (ThisRigidbody.velocity.magnitude < (0.6f * ParticleSpeed))  //was 0.5 * ParticleSpeed
        {
            if (gameObject.tag == "WaterMolecule")
            {
                //print("speed up water molecule");
                ParticleVelocityVector = ThisRigidbody.velocity;
                ThisRigidbody.velocity = ParticleVelocityVector.normalized * ParticleSpeed;
            }

            else
            {
                //print(gameObject + "Randomize velocity--too slow");
                RandomizeVelocities();   //If particle is going too slow, randomize velocity direction and set to original speed
            }


        }

        if (ThisRigidbody.velocity.magnitude > 2.5f * ParticleSpeed)  //was 1.2
        {
            //print("speed = " + ThisRigidbody.velocity.magnitude);
            //print("need to reduce speed");
            ParticleVelocityVector = ThisRigidbody.velocity;
            ThisRigidbody.velocity = 1.5f * ParticleVelocityVector.normalized * ParticleSpeed;
        }
    }



    public void RandomizeVelocities()  //this is called initially and if velocity gets too low (which often occurs when particle collides inelastically)
    {
        //set Random velocity direction using random angle measure and trigonometry!
        RandomRadianMeasure = Random.Range(0, 6.27f);
        ParticleVelocityVector = new Vector3(Mathf.Cos(RandomRadianMeasure), Mathf.Sin(RandomRadianMeasure), 0);  //this should create a unit vector with random direction
        ThisRigidbody.velocity = ParticleVelocityVector * ParticleSpeed;

    }
}
