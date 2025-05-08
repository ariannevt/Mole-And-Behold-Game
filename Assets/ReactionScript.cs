using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ReactionScript : MonoBehaviour  //Attached to particles that can react on collision with other, specified particles
{
    public string OtherReactantTag;
    private AudioSource ReactionSound;
    public List<GameObject> ProductsToInstantiate;  //could be a single particle or a pair of particles--user will specify which spheres to instantiate
    public float ReactionProbability = 1;  //a value between 0 and 1 to indicate likelihood of productive reaction upon collision.  If greater than 1, rxn prob is 100%
    private float RandomProbabilityValue;

    // Start is called before the first frame update
    void Start()
    {
        ReactionSound = GameObject.Find("ReactionSound").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision other)
    {         
        if (other.gameObject.tag == OtherReactantTag)
        {
            RandomProbabilityValue = Random.Range(0f, 1f);
            if (RandomProbabilityValue < ReactionProbability)
            {
                print("reaction occurs");
                ReactionSound.Play();
                foreach (GameObject Product in ProductsToInstantiate)
                {
                    Instantiate(Product, gameObject.transform.position, Quaternion.identity);
                }
                Destroy(gameObject);  //this removes the gameObject to which this script is attached
                Destroy(other.gameObject);  //this removes the gameObject that this gameObject collided with
            }
            else
            {
                print(RandomProbabilityValue + " probability threshold not reached");
            }

        }



    }
}
