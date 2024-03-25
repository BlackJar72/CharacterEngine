using System;
using UnityEngine;


namespace CharacterModel {

    /// <summary>
    /// This represents an action that a character might choose to take, such as
    /// cooking or eating, talking or sleeping, or whatever action might be taken.
    /// </summary>
    public class ActionPrototype : ScriptableObject,  IEquatable<ActionPrototype> {
        [SerializeField] string name;
        [SerializeField] int ID;
        [SerializeField] int animationID;
        [SerializeField] bool discrete;


        public bool Equals(ActionPrototype other) {
            #if UNITY_EDITOR
            bool output = (ID == other.ID);
            if(output) Debug.Assert((animationID == other.animationID) && (discrete == other.discrete) && (name == other.name));
            return output;
            #else
            return ID == other.ID;
            #endif
        }





    }

}