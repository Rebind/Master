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

       // public GameObject transParticle;
        private float m_OffsetZ;
        private Vector3 m_LastTargetPosition;
        private Vector3 m_CurrentVelocity;
        private Vector3 m_LookAheadPos;

        // Use this for initialization
        private void Start()
        {
            m_LastTargetPosition = target.position;
            m_OffsetZ = (transform.position - target.position).z;
            transform.parent = null;
        }


        // Update is called once per frame
        private void Update()
        {
            // Keybindings to number pad to switch Main Camera 
            // to certain game objects
            if (Input.GetKeyUp(KeyCode.Keypad1))
            {
                Debug.Log("1 is pressed");
              //  Instantiate(transParticle, GameObject.Find("Player").transform.position, GameObject.Find("Player").transform.rotation);
                target = GameObject.Find("Player").transform;
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