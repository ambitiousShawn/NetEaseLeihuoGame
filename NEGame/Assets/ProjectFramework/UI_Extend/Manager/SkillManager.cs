using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shawn.ProjectFramework
{

    public class SkillManager : IBaseManager
    {
        public static SkillManager Instance;
        public const string Skill_Path = "SO/Skill_SO";

        public Dictionary<string, SkillNode> currSkillDic = new Dictionary<string, SkillNode>();
        public List<SkillNode> tempSkillList;

        

        public void Init()
        {
            Instance = this;

            tempSkillList = Resources.Load<SkillData_SO>(Skill_Path).Nodes;

        }

        public void Tick()
        {
            
            if (Input.GetKeyDown(KeyCode.F))
            {
            
            }
            if (Input.GetKeyDown(KeyCode.G))
            {
                InitAllSkills();
                
            }

        }
    

        public void InitAllSkills()
        {
            foreach (SkillNode node in tempSkillList)
            {
                if (!currSkillDic.ContainsKey(node.Name))
                {
                    currSkillDic.Add(node.Name, node);
                }
            }
        }
    }

}