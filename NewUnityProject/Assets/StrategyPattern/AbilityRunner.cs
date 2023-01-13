// AbilityRunner.cs
// 04-22-2022
// James LaFritz

using UnityEngine;
using UnityEngine.UI;
using System;
namespace DesignPatterns.StrategyPattern
{
    public class AbilityRunner : MonoBehaviour
    {
        [SerializeField]
        Button[] btnSkills;

        private IAbility m_currentAbility;

        IAbility[] arrayAbility = new IAbility[4];
        public IAbility CurrentAbility
        {
            get => m_currentAbility;
            set => m_currentAbility = value;
        }

        private void Start()
        {
            string className = "DesignPatterns.StrategyPattern.FireBallAbility";
            Type classType = Type.GetType(className);
            m_currentAbility = (IAbility)Activator.CreateInstance(classType);

            btnSkills[0].onClick.AddListener(()=>m_currentAbility?.Use());
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_currentAbility?.Use();
            }
        }
    }
}