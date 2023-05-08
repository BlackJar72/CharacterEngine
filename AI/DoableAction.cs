using System;
using UnityEngine;


namespace CharacterModel {

    /// <summary>
    /// This is any action a character can take, but only the general type of action, that is
    /// the action minus any object.  For example, "Cook on Stove" would be an action, but
    /// the act of cooking on a specific stove would combine this with a reference to the
    /// the stove IInteractableObject.
    ///
    /// Every character should have their own identical list of these that can be sorted and selected
    /// from to find a target behavior before selecting the object to use.
    ///
    /// Before the sort, any unavailable actions should be given a negative value.  Then, those available
    /// should be set based on needs and then modifiers for traits, emotions, etc., applied.  After which
    /// these should be sorted and a waited random selection from the first 5 or 6 should be done.
    /// </summary>
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


        public void SetBasedOnNeed(float valueFromNeed) {
            // FIXME/TODO: There might be a better way, and should the need be passed in or pass it a vallue?
            utility = valueFromNeed;
        }


        public void ResetUtility() {Utility = 1.0f;}


        public void ApplyModifier(UtilityModifier modifier) {
            utility = (utility * modifier.multiplier) + modifier.additive;
        }


    }

}