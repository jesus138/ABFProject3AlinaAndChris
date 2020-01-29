using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public enum MoveState
{
    WALKING,
    JUMPING,
    CROUCHING,
    RUNNING,
    STANDING
}

[Serializable]
public struct TypeClip{
    public string Type;
    public AudioClip Sound;
}

[RequireComponent(typeof(ThirdPersonCharacter))]
public class ChrisScript : MonoBehaviour
{
    [Tooltip("The event system for changes, by default objet named \"ABFEventSystem\"")]
    public ABFEvents eventSystem;
    [Header("Mapping of Ground Types to Audio Clips")]
    public TypeClip[] m_audioTypes;

    private ThirdPersonCharacter m_Controller;
    private float moveMultiplier;
    private AudioSource soundWalk;
    private AudioSource soundJumpEnd;
    private MoveState moveState;
    private Dictionary<string, AudioClip> audioTypesDict;

    // start position for resetting
    private Transform startTransform;

    // Start is called before the first frame update
    void Start()
    {
        startTransform = transform;

        m_Controller = GetComponent<ThirdPersonCharacter>();
        moveMultiplier = m_Controller.m_MoveSpeedMultiplier;
        soundWalk = GetComponent<AudioSource>();

        moveState = MoveState.STANDING;

        initSoundSystem();
        initEventSystem();
    }

    // Update is called once per frame
    void Update()
    {
        // 1. check movement
        if(m_Controller.m_IsGrounded)
        {
            if(moveState == MoveState.JUMPING)
            {
                moveState = MoveState.STANDING;
                soundJumpEnd.Play();
                Debug.Log("Landed");
            }

            if(inputMoving())
            {
                
                //Debug.Log("Moving");
                if(!soundWalk.isPlaying)
                {
                    soundWalk.Play();
                }
                if(moveState == MoveState.RUNNING)
                {
                    soundWalk.pitch = 2f;
                }
                else
                {
                    soundWalk.pitch = 1f;
                }
            }
            else
            {
                soundWalk.Pause();
                if(m_Controller.m_Crouching)
                {
                    if(moveState != MoveState.CROUCHING)
                    {
                        moveState = MoveState.CROUCHING;
                        Debug.Log("Crouching");
                    }
                }
                else
                {
                    if(moveState != MoveState.STANDING)
                    {
                        moveState = MoveState.STANDING;
                        Debug.Log("Standing");
                    }
                }
            }
        }
        else if(moveState != MoveState.JUMPING)
        {
            moveState = MoveState.JUMPING;
            soundWalk.Pause();
            Debug.Log("Jumping");
        }

        // 2. check for out of game area / falloff
        if(this.transform.position.y < -10)
        {
            Debug.Log("Game Over");
        } 
    }

    void FixedUpdate()
    {
        // running
        if(inputMoving() && moveState != MoveState.JUMPING)
        {
            if(Input.GetKey(KeyCode.LeftControl))
            {
                m_Controller.m_MoveSpeedMultiplier = 2*moveMultiplier;
                if(moveState != MoveState.RUNNING)
                {
                    moveState = MoveState.RUNNING;
                    Debug.Log("Running");
                }
            }
            else
            {
                m_Controller.m_MoveSpeedMultiplier = moveMultiplier;
                if(moveState != MoveState.WALKING)
                {
                    moveState = MoveState.WALKING;
                    Debug.Log("Walking");
                }
            }
        }
    }

    private bool inputMoving()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        return h < -0.1f || h > 0.1f || v < -0.1f || v > 0.1f; 
    }

    private void initEventSystem()
    {
        if(eventSystem == null)
        {
            GameObject obj = GameObject.Find(ABFEvents.DEFAULT_EVENT_SYSTEM_NAME);
            if(obj != null)
            {
                var evts = obj.GetComponent<ABFEvents>();
                if(evts != null)
                {
                    this.eventSystem = evts;
                }
                else
                {
                    Debug.LogError($"{name} has no event system");
                }
            }
            else
            {
                Debug.LogError($"{name} has no event system");
            }
        }
        eventSystem.GroundEvent += OnGroundChange;
    }

    private void OnGroundChange(string type)
    {
        Debug.Log($"Player: Ground={type}");
        if(audioTypesDict.ContainsKey(type))
        {
            AudioClip clip = audioTypesDict[type];
            this.soundWalk.clip = clip;
        }
    }

    private void initSoundSystem()
    {
        Transform patrans = transform.Find("PersonAudio");
        if(patrans != null)
        {
            Transform t = patrans.Find("JumpEnd");
            soundJumpEnd = t.GetComponent<AudioSource>();
        }
        else{
            Debug.LogError("PersonAudio not found");
        }

        // ground type to audio
        audioTypesDict = new Dictionary<string, AudioClip>();
        foreach(var e in this.m_audioTypes)
        {
            audioTypesDict.Add(e.Type, e.Sound);
        }
    }
}
