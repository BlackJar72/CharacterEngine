using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharacterEngine;


namespace CharacterModel {

    public struct GeneticTrait {
        private float geneA, geneB, fake;

        const float REAL_MAX = 10.0f / 3.0f;
        const float FAKE_MAX = REAL_MAX;

        public float Raw => geneA + geneB + fake;
        public int   Value => (int)(geneA + geneB + fake + 0.5f);

        public float[] Data() => new float[]{geneA, geneB, fake}; 


        // FIXME: Move to a static utility class, since it may be used elsewhere.
        public static bool CoinToss() {
            return Random.Range(0, 2) > 0; // 50%/50%
        }


        private GeneticTrait(float a, float b, float complexity) {
            geneA = a;
            geneB = b;
            fake  = complexity;
        }


        public static GeneticTrait GetRandom() {
            return new GeneticTrait(Random.Range(0f, REAL_MAX),
                                    Random.Range(0f, REAL_MAX),
                                    Random.Range(0f, FAKE_MAX));
        }


        /// <summary>
        /// Use to create a Genetic repressentation from a single value, such
        /// as from player inpput.
        /// This will create one with equal genes so as to produce intuitive
        /// inheritence patterns.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static GeneticTrait FromValueSimple(float value) {
            float part = Mathf.Clamp(value / 3f, 0, REAL_MAX);
            return new GeneticTrait(part, part, part);
        }


        public static GeneticTrait Mate(GeneticTrait moms, GeneticTrait dads, int mutationChance = 0) {
            GeneticTrait output = new GeneticTrait();
            if(CoinToss()) {
                output.geneA = moms.geneA;
                output.geneB = dads.geneB;
            } else {
                output.geneA = dads.geneA;
                output.geneB = moms.geneB;
            }
            if(CoinToss()) output.Crossover();
            if(Random.Range(0, 99) < mutationChance) output.Mutate();
            output.fake = Random.Range(0f, FAKE_MAX);
            return output;
        }


        private void Crossover() {
            float tmp = geneA;
            geneA = geneB;
            geneB = tmp;
        }


        private void Mutate() {
            if(CoinToss()) {
                geneA = Random.Range(0f, REAL_MAX);
            } else {
                geneB = Random.Range(0f, REAL_MAX);
            }
        }


    }

}
