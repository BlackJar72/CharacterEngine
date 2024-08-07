using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharacterEngine;


namespace CharacterModel {

    public struct Skill {
        // Constant representing base XP for skill levels
        // Values may change with development and testing
        public const double ZERO    = 0;
        public const double ONE     = 100;
        public const double TWO     = 100  * 1.58489319246;
        public const double THREE   = 100  * 2.51188643151;
        public const double FOUR    = 100  * 3.98107170554;
        public const double FIVE    = 100  * 6.3095734448;
        public const double SIX     = 1000;
        public const double SEVEN   = 1000 * 1.58489319246;
        public const double EIGHT   = 1000 * 2.51188643151;
        public const double NINE    = 1000 * 3.98107170554;
        public const double TEN     = 1000 * 6.3095734448;
        public static readonly double[] XP_FOR_LEVELS
                = { ZERO, ONE, TWO, THREE, FOUR, FIVE, SIX, SEVEN, EIGHT, NINE, TEN };
        // The maximum value achievable;
        public const double MAX     = 10000;


        // DATA
        private double xp;
        private float minXp;
        private int level;
        private int highestReached;
        private float bonus;
        private double lastUsed;

        public double XP => xp;
        public int Level => level;


        /// <summary>
        /// Handles increases in skill XP for the skill, and raises the skill if needed.
        /// </summary>
        /// <param name="amount">How much the skill has increased (skill XP)</param>
        /// <returns>Any general character XP gain from leveling the skill;
        /// 0 if the skill level did not change</returns>
        public int Increase(float amount) {
            BeUsed();
            int output = 0;
            xp += (amount * bonus);
            if(xp > MAX) xp = MAX;
            if(xp > XP_FOR_LEVELS[level]) {
                level++;
                if(level > highestReached) {
                    highestReached = level;
                    // This is equal to the sum of all numbers from 1 to level
                    output =  (level * (level + 1)) / 2;
                }
            }
            // Decay will not reduce the level to less than 1/2 the highest obtained.
            float newMinimum = Mathf.Sqrt((float)xp);
            if(newMinimum > minXp) minXp = newMinimum;
            // If the character has gained at least one level never loose the skill.
            if((level >= 1) && (minXp < ONE)) minXp = (float)ONE;
            return output;
        }


        public int Decay(float amount) {
            xp -= amount;
            if(xp < minXp) xp = minXp;
            if(xp < XP_FOR_LEVELS[level]) level--;
            return level;
        }


        /// <summary>
        /// This should be called after character creation or after certain age-ups
        /// </summary>
        /// <param name="attribute"></param> The AbilityScore, or similar, from which the bonus applies
        public void SetBonus(float attribute) {
            bonus = Mathf.Pow(1.58489319246f, (attribute / 5) - 2);
        }


        /// <summary>
        /// This updates the lastUsed variable, and is called when the skill is used or learning occurs
        /// </summary>
        public void BeUsed() {
            // FIXME??? Get from manager?
            lastUsed = WorldTime.Instance.Days;
        }


        /// <summary>
        /// To be called once per day (probably at midnight or 6:00 am / 06:00, mosty to handle skill
        /// decay from non-use.
        /// </summary>
        /// <returns>True if a skill level was lost</returns>
        public bool DailyUpdate() {
            int currentLevel = level;
            // FIXME??? Get from manager?
            if((lastUsed - 1.5) > WorldTime.GetWorldTime().Days) {
                Decay(100);
                return level < currentLevel;
            }
            return false;
        }


        //TODO: Code for actually using the skill (success?  Speed?)

    }

}
