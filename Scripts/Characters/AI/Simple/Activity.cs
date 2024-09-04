using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using kfutils.UI;
using CharacterEngine;

namespace CharacterModel {

    [System.Serializable]
    public class Activity {

        public ENeeds need;
        public float satisfaction;
        public float timeToDo;
        public Transform actorLocation;


    }

}