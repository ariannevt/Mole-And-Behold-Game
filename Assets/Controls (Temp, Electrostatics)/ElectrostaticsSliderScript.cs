using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ElectrostaticsSliderScript : MonoBehaviour  //attached to the ElectrostaticsSlider (only one instance in scene)
{
    //public int ChargeValue;  //user must specifically state if charge is negative (e.g. -2)
    public ChargedParticleScript[] ArrayOfParticlesThatHaveChargedParticleScript;
    public List<GameObject> ListOfChargedParticlesInScene;
    public float ElectrostaticConstant;
    public Slider ElectrostaticSlider;
    public TMP_Text ElectrostaticDisplayValue;

    private float DistanceBetweenParticles;
    private float StrengthOfForceBetweenTheseParticles;
    private Vector3 ForceOnParticle1;
    private Vector3 ForceOnParticle2;
    private float Q1;
    private float Q2;


    // Start is called before the first frame update
    void Start()
    {
        ElectrostaticSlider = GetComponent<Slider>();
        ChangeElectrostaticConstantUsingSlider();

        ArrayOfParticlesThatHaveChargedParticleScript = FindObjectsOfType<ChargedParticleScript>();  //this will find any sphere that has the ChargedParticleScript attached
        foreach (ChargedParticleScript ChargeBearer in ArrayOfParticlesThatHaveChargedParticleScript)
        {
            ListOfChargedParticlesInScene.Add(ChargeBearer.gameObject);
            //the ArrayOfParticlesThatHaveChargedParticleScript isn't a list of actual GameObjects.  The function above will get the GameObjects and put in ListOfChargedParticlesInScene
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.timeScale == 0)
        {
            //do nothing--otherwise you get a weird build-up of forces while the scene is paused.

        }
        else
        {
            foreach (GameObject particle in ListOfChargedParticlesInScene)
            {
                
                foreach (GameObject otherParticle in ListOfChargedParticlesInScene)
                {
                    if (otherParticle.transform == particle.transform)  //Can't calculate force on a single particle--need "other" to be a different particle!
                    {
                        //do nothing 
                    }


                    else     //calculate forces based on Coulomb's Law
                    {
                        //print("Calculating force between " + particle + " and " + otherParticle);
                        Vector3 ForceDirection = Vector3.Normalize(otherParticle.transform.position - particle.transform.position);
                        DistanceBetweenParticles = Vector3.Distance(otherParticle.transform.position, particle.transform.position);
                        Q1 = particle.GetComponent<ChargedParticleScript>().ChargeOfThisParticle;         //charge;
                        Q2 = otherParticle.GetComponent<ChargedParticleScript>().ChargeOfThisParticle;          //GetComponent<ChargeScript>().charge;

                        //StrengthOfForceBetweenTheseParticles includes direction (+ or -) depending on whether charges are alike or opposite
                        StrengthOfForceBetweenTheseParticles = -Q1 * Q2 * ElectrostaticConstant / (Mathf.Pow(DistanceBetweenParticles, 2));
                        ForceOnParticle1 = ForceDirection * StrengthOfForceBetweenTheseParticles;
                       
                        particle.GetComponent<Rigidbody>().AddForce(ForceDirection * StrengthOfForceBetweenTheseParticles);                  

                    }


                }
            }
        }
    }

    public void ChangeElectrostaticConstantUsingSlider()
    {
        //called whenever the value of the slider is changed by user
        ElectrostaticConstant = ElectrostaticSlider.value * 20;
        ElectrostaticDisplayValue.text = ElectrostaticSlider.value.ToString();
    }
}
