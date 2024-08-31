using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

namespace CharacterModel {


    public class ActivityChooser : MonoBehaviour
    {

        [System.Serializable]
        public class ActivityChoice : IComparer<ActivityChoice>, System.IComparable<ActivityChoice> {
            [SerializeField] public Activity activity;
            //[SerializeField] public AbstractNeedEvaluator evaluator;
            public float desirability = 0;
            public float GetDesirability(CoreNeeds needs, float situation)
                                        => needs.GetNeed(activity.need).Evaluator.GetDesirability(this, needs.GetNeed(activity.need), situation);
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void SetDesirability(CoreNeeds needs, float situation) {
                needs.GetNeed(activity.need).Evaluator.SetDesirability(this, needs.GetNeed(activity.need), situation);
            }
            public static bool operator >(ActivityChoice a, ActivityChoice b) => a.desirability > b.desirability;
            public static bool operator <(ActivityChoice a, ActivityChoice b) => a.desirability < b.desirability;
            public static bool operator >=(ActivityChoice a, ActivityChoice b) => a.desirability >= b.desirability;
            public static bool operator <=(ActivityChoice a, ActivityChoice b) => a.desirability <= b.desirability;
            public int Compare(ActivityChoice a, ActivityChoice b) {
                return -a.desirability.CompareTo(b.desirability); // Should I do this, or use arithmetic?
            }
            public int CompareTo(ActivityChoice other) {
                return -desirability.CompareTo(other.desirability); // Should I do this, or use arithmetic?
            }
        }


        [SerializeField] List<ActivityChoice> choices = new List<ActivityChoice>();
        [SerializeField] Character character;
        [SerializeField] CoreNeeds needs;

        private float activityTimer = 0;
        private bool  atLoction     = false;

        //Testing Stuff
        [SerializeField] GameObject testingPlaceShower;
        [SerializeField] Activity currentChoice;
        [SerializeField] NavMeshAgent navAgent;


        // Start is called before the first frame update
        void Start()
        {
            needs = character.Needs;
            navAgent = GetComponent<NavMeshAgent>();
        }

        // Update is called once per frame
        // FIXME/TODO: This ultimately needs to be removed, but first it must be replaced with a call from outside
        void Update()
        {
            if(activityTimer <= 0) {
                currentChoice = Choose();
                testingPlaceShower.transform.position = currentChoice.actorLocation.position;
                //testingPlaceShower.transform.rotation = currentChoice.actorLocation.rotation;
                activityTimer = currentChoice.timeToDo * Need.TIME_SCALE;
                if(currentChoice.need == ENeeds.SITUATIONAL) needs.Situation = currentChoice.satisfaction;
                else needs.Situation = 0.2f;
                navAgent.SetDestination(currentChoice.actorLocation.position);
                atLoction = false;
                testingPlaceShower.SetActive(false);
            } else {
                //FIXME: Remember, in the real game anything similar must use worled (simulation) time, not engine game time!
                if(atLoction) {
                    activityTimer -= Time.deltaTime;
                    needs.GetNeed(currentChoice.need).AddSafe((currentChoice.satisfaction / currentChoice.timeToDo)
                        * Time.deltaTime);
                } else {
                    atLoction = navAgent.remainingDistance < 0.1f;
                    testingPlaceShower.SetActive(atLoction);
                }
            }
            character.Emotions.EmoUpdate(Time.deltaTime);
            needs.UpdateNeedsTesting();
            if(needs.GetNeed(ENeeds.HEALTH).Value == 0) {
                GameObject.Destroy(gameObject);
                Debug.Log("Character Died");
            }
        }


        public void SortChoices() {
            foreach(ActivityChoice choice in choices) {
                choice.SetDesirability(needs, needs.Situation);

            }
            choices.Sort();
        }


        public Activity Choose() {
            SortChoices();
            int numToConsider = choices.Count;
            if(choices.Count > 3) {
                numToConsider = Mathf.Min(Mathf.Max((choices.Count / 5), 2), 6);
            }
            float selector = 0;
            for(int i = 0; i < numToConsider; i++) {
                selector += choices[i].desirability;
            }
            selector = Random.Range(0, selector);
            int selection = 0;
            while(selector > choices[selection].desirability) {
                selector -= choices[selection].desirability;
                selection++;
                #if UNITY_EDITOR
                //Testing Failsage
                if(selection >= numToConsider) {
                    selection = 0;
                    selector = 0.0f;
                    Debug.LogError("ActivityChooser.Choose(): Selector overran range; something is wrong!");
                    break;
                }
                #endif
            }
            return choices[selection].activity;
            return choices[selection].activity;
        }



    }

}
