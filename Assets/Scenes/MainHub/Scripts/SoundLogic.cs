using UnityEngine;

public class CharacterMovementSound : MonoBehaviour
{
    [Header("References")]
    [Tooltip("Assign your existing character's Transform here.")]
    public Transform characterTransform;

    [Tooltip("Assign an AudioSource that will play the walking sound.")]
    public AudioSource walkAudioSource;

    [Tooltip("Assign the walking AudioClip here.")]
    public AudioClip walkClip;

    [Header("Settings")]
    [Tooltip("Minimum movement per frame to count as 'moving'.")]
    public float movementThreshold = 0.01f;

    private Vector3 lastPosition;
    private bool isMoving = false;

    void Start()
    {
        if (characterTransform == null)
        {
            Debug.LogError("CharacterMovementSound: Please assign your character's Transform in the Inspector.");
            enabled = false;
            return;
        }
        if (walkAudioSource == null)
        {
            Debug.LogError("CharacterMovementSound: Please assign an AudioSource in the Inspector.");
            enabled = false;
            return;
        }
        if (walkClip == null)
        {
            Debug.LogError("CharacterMovementSound: Please assign a walking AudioClip in the Inspector.");
            enabled = false;
            return;
        }

        walkAudioSource.clip = walkClip;
        walkAudioSource.loop = true;
        lastPosition = characterTransform.position;
    }

    void Update()
    {
        // Calculate how much the character has moved in any direction
        float distanceMoved = Vector3.Distance(characterTransform.position, lastPosition);

        bool currentlyMoving = distanceMoved > movementThreshold;

        if (currentlyMoving && !isMoving)
        {
            StartWalkingSound();
        }
        else if (!currentlyMoving && isMoving)
        {
            StopWalkingSound();
        }

        isMoving = currentlyMoving;
        lastPosition = characterTransform.position;
    }

    void StartWalkingSound()
    {
        if (!walkAudioSource.isPlaying)
        {
            walkAudioSource.Play();
        }
    }

    void StopWalkingSound()
    {
        if (walkAudioSource.isPlaying)
        {
            walkAudioSource.Stop();
        }
    }
}
