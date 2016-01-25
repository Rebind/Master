using System;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    public class Camera2DFollow : MonoBehaviour
    {
        public Transform target;
        public float damping = 1;
        public float lookAheadFactor = 3;
        public float lookAheadReturnSpeed = 0.5f;
        public float lookAheadMoveThreshold = 0.1f;
        //public GameObject tmp; 

        private float m_OffsetZ;
        private Vector3 m_LastTargetPosition;
        private Vector3 m_CurrentVelocity;
        private Vector3 m_LookAheadPos;

        //function to disable a script
        private void disable(String off)
        {
            GameObject focus = GameObject.Find(off);
            focus.GetComponent<Player>().enabled=false;
        }

        //function to enable a script
        private void enable(String on)
        {
            GameObject focus = GameObject.Find(on);
            focus.GetComponent<Player>().enabled=true;
        }

        // Use this for initialization
        private void Start()
        {
            m_LastTargetPosition = target.position;
            m_OffsetZ = (transform.position - target.position).z;
            transform.parent = null;

            disable("Player2");
        }


        // Update is called once per frame
        private void Update()
        {
            // Keybindings to number pad to switch Main Camera 
            // to certain game objects
            if (Input.GetKeyUp(KeyCode.Q))
            {
                Debug.Log("Q is pressed");
                target = GameObject.Find("Player2").transform;
                disable("Player");
                enable("Player2");
            }
            if (Input.GetKeyUp(KeyCode.E))
            {
                Debug.Log("E is pressed");
                target = GameObject.Find("Player").transform;
                disable("Player2");
                enable("Player");
            }
            if (Input.GetKeyUp(KeyCode.Keypad2))
            {
                Debug.Log("2 is pressed");
                target = GameObject.Find("Arm").transform;
            }
            if (Input.GetKeyUp(KeyCode.Keypad3))
            {
                Debug.Log("3 is pressed");
                target = GameObject.Find("Arm (1)").transform;
            }
            if (Input.GetKeyUp(KeyCode.Keypad4))
            {
                Debug.Log("4 is pressed");
                target = GameObject.Find("Torso").transform;
            }
            if (Input.GetKeyUp(KeyCode.Keypad5))
            {
                Debug.Log("5 is pressed");
                target = GameObject.Find("Leg").transform;
            }
            if (Input.GetKeyUp(KeyCode.Keypad6))
            {
                Debug.Log("6 is pressed");
                target = GameObject.Find("Leg (1)").transform;
            }
            // only update lookahead pos if accelerating or changed direction
            float xMoveDelta = (target.position - m_LastTargetPosition).x;

            bool updateLookAheadTarget = Mathf.Abs(xMoveDelta) > lookAheadMoveThreshold;

            if (updateLookAheadTarget)
            {
                m_LookAheadPos = lookAheadFactor * Vector3.right * Mathf.Sign(xMoveDelta);
            }
            else
            {
                m_LookAheadPos = Vector3.MoveTowards(m_LookAheadPos, Vector3.zero, Time.deltaTime * lookAheadReturnSpeed);
            }

            Vector3 aheadTargetPos = target.position + m_LookAheadPos + Vector3.forward * m_OffsetZ;
            Vector3 newPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref m_CurrentVelocity, damping);

            transform.position = newPos;

            m_LastTargetPosition = target.position;
        }
    }
}