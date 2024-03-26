using System;
using System.Runtime.CompilerServices;
using UnityEngine;


namespace CharacterModel {

    [Serializable]
    public class NeedSatisfier {
        [SerializeField] NeedEffect effect;
        [Tooltip ("How long it takes to gain the full effect in world time.")]
        [SerializeField] float timeToUse;

        public NeedEffect Effect => effect;
        public float  TimeToUse => timeToUse;

    }
}