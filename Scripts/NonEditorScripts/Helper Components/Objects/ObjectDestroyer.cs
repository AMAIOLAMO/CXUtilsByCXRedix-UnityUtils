﻿using UnityEngine;

namespace CXUtils.HelperComponents
{
    /// <summary> Options fields to destoy objects </summary>
    public enum ObjectDestroyOptions
    {
        NoTime_OnStart, Time_OnStart
    }

#pragma warning disable IDE0044
    /// <summary> A simple helper component for destroying an object </summary>
    public class ObjectDestroyer : MonoBehaviour
    {
        [Header("Configuration")]
        [SerializeField] private bool otherTargets;
        public bool OtherTargets { get => otherTargets; set => otherTargets = value; }

        //show if otherTargets
        [SerializeField] private GameObject target = default;
        public GameObject Target { get => target; set => target = value; }

        [SerializeField] private ObjectDestroyOptions objectDestroyOption = default;

        public ObjectDestroyOptions ObjectDestroyOption => objectDestroyOption;

        //show if object destroy option
        [SerializeField] private float time;
        public float Time { get => time; set => time = value; }

        void Start()
        {
            switch (objectDestroyOption)
            {
                case ObjectDestroyOptions.NoTime_OnStart:
                Destroy(GetTarget());
                break;

                case ObjectDestroyOptions.Time_OnStart:
                Destroy(GetTarget(), time);
                break;
            }
        }

        private GameObject GetTarget() =>
            otherTargets ? target : gameObject;
    }
}