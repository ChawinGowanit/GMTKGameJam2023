using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameController : MonoBehaviour
{
    [SerializeField] int currentNPC = 1;
    [SerializeField] List<int> queue = new List<int>();
    [SerializeField] List<string> pQueueTier = new List<string>();
    [SerializeField] List<string> pQueueName = new List<string>();
    [SerializeField] List<string> skillQueue= new List<string>();
    [SerializeField] List<bool> reaction =  new List<bool>();
    void Start()
    {
        randomNPC();
        randomPref();
        randomSkill();
        showNPC(currentNPC);
    }
    void Update()
    {
        
    }
    public void randomNPC(){
        while (queue.Count < 3) {
            bool isIn = false;
            int r = Random.Range(1, 5);
            foreach (var item in queue)
            {
                if (r == item){
                    isIn = true;
                }
            }
            if (!isIn){
                queue.Add(r);
            }
        }
    }
    public void randomPref(){
        for (int i = 0;i <3;i++){
            var tiers = new string[] {"silver","gold","rainbow"};
            var names = new string[] {"Miyu","???"};

            string name = names[Random.Range(0, names.Length)];
            string tier = tiers[Random.Range(0, tiers.Length)];
            pQueueName.Add(name);
            pQueueTier.Add(tier);
        }
    }
    public void randomSkill(){
        for (int i = 0;i <3;i++){
            var skills = new string[] {"none","lucky"};
            string skill = skills[Random.Range(0, skills.Length)];
            skillQueue.Add(skill);
        }
    }
    public void showNPC(int currentNPC){
        //show npc pref /skill
    }
    public void onCloseShowNPC(){
        //release ball to start the game
    }
    public void showNPCStory(){
        //show NPC story when button is clicked
    }
    public void onFirstBallReach(string prefTier,List<string> prefName){
        //add NPC reaction
    }
    public void showAllReaction(){
        //show all NPC reaction
        //finsih game loop
    }
}
