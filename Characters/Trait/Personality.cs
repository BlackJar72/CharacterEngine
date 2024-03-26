using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CharacterModel {

    public class Personality {

        public struct PersonalityPacket {
            public readonly CoreTraitIntPacket coreTraits;
            public readonly TalentIntPacket talents;
            public PersonalityPacket(CoreTraitIntPacket coreTraits, TalentIntPacket talents) {
                this.coreTraits = coreTraits;
                this.talents = talents;
            }
        }

        public const int MAX_NUM_QUIRKS = 6;
        public const int MAX_TRAIT = 20;
        public const int AVG_TRAIT = 10;
        public const int MIN_TRAIT =  1;

        public const float F_MAX_TRAIT = MAX_TRAIT;
        public const float F_AVG_TRAIT = AVG_TRAIT;
        public const float F_MIN_TRAIT =  MIN_TRAIT;

        //Core Traits, base on HEXACO
        CoreTrait open;
        CoreTrait moral; // Honesty-Humility, but dumbed-down for non-psychologists
        CoreTrait extroverted;
        CoreTrait sensitive;
        CoreTrait emotional;
        CoreTrait industrious; // Concientiousness, dumbed-down (though differently than that game that called it neat)

        //Talents, some inspiration from Holland Career Interest codes, though representing talents not interests
        AbiltyScore physical;
        AbiltyScore intellectual;
        AbiltyScore practical;
        AbiltyScore creative;
        AbiltyScore social;

        // Minor traits / Quirks -- refers to small traits based on simple description
        List<MinorTrait> quirks;




        /// <summary>
        /// Returns a compatibility score based on core traits and modeled as the distance between the
        /// two personalities (in an abstract six-dimensional space, of course).
        /// </summary>
        /// <param name="other">The personalit of the one with which compatibilities is being calculated</param>
        /// <returns>A base compatibility</returns>
        /// TODO: This will need to be tweaked through testing mostllikely the inclusion of a scaling factor
        /// TODO  and/or other addition transformation.
        public float Compatibility(Personality other) {
            return Mathf.Sqrt((float)((open.Value - other.open.Value)
                                        * (open.Value - other.open.Value))
                                  + ((moral.Value - other.moral.Value)
                                        * (open.Value - other.moral.Value))
                                  + ((extroverted.Value - other.extroverted.Value)
                                        * (extroverted.Value - other.extroverted.Value))
                                  + ((sensitive.Value - other.sensitive.Value)
                                        * (sensitive.Value - other.sensitive.Value))
                                  + ((emotional.Value - other.emotional.Value)
                                        * (emotional.Value - other.emotional.Value))
                                  + ((industrious.Value - other.industrious.Value)
                                        * (industrious.Value - other.industrious.Value)));
        }


        

    }

}