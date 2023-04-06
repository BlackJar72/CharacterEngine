using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CharacterModel {

    /// <summary>
    /// This represents an gaol that a character might choose to take, such as
    /// reading or eating, talking or sleeping, or whatever action might be taken.
    ///
    /// The targetAction is the action intended.  The prerequisite is an action that
    /// will be taken first.  Multi-step plans are chained, effectively a linked list.
    /// </summary>
    public class Goal : ScriptableObject {
        ConcreteAction targetAction; // The action the character intends to do.
        Goal prerequisite; // An action that must be done to enable to target action
    }

}