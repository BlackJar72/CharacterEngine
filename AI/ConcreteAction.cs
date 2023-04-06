using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CharacterModel {

    public class ConcreteAction : MonoBehaviour {
        private ActionPrototype currentAction;
        private IInteractiveObject target;
    }

}