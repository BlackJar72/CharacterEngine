using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CharacterModel {

    /// <summary>
    /// This represents an action that a character might choose to take, such as
    /// cooking or eating, talking or sleeping, or whatever action might be taken.
    /// </summary>
    public class ActionPrototype : ScriptableObject {
        [SerializeField] int animationID;
        [SerializeField] bool discrete;
        [SerializeField] ICanDo doable;
        [SerializeField] IAmDone done;
    }

}