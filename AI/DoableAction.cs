using System;
using UnityEngine;


namespace CharacterModel {

    public class DoableAction : IEquatable<DoableAction>, IComparable<DoableAction> {
        [SerializeField] float utility;
        [SerializeField] ActionPrototype prototype;
        [SerializeField] ICanDo doable;
        [SerializeField] IAmDone done;

        public float Utility { get => utility;  set => utility = value; }


        public int CompareTo(DoableAction other) {
            return (int)((other.utility - utility) * 1000f);
        }


        public bool Equals(DoableAction other) {
            return (prototype == other.prototype);
        }


        public void ResetUtility() {Utility = 1.0f;}


        public bool ApplyModifier(UtilityModifier modifier) {
            utility = (utility * modifier.multiplier) + modifier.additive;
        }


    }

}