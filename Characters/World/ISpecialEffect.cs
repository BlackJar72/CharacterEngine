using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using static CharacterModel.ENeeds;


namespace CharacterModel {

    public interface ISpecialEffect {
        void Activate(Character character);
    }
}