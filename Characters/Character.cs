using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using kfutils.UI;
using CharacterModel;
using System;

namespace CharacterModel {

    public class Character {
        [SerializeField] Personality personality;
        [SerializeField] CoreNeeds needs;
        [SerializeField] EmotionalState emotions;
    }


}