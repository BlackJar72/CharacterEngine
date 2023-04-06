using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CharacterModel {

    public class ActiveState : MonoBehaviour {
        private ConcreteAction currentAction;
        private List<ConcreteAction> currentPlan;
    }

}
