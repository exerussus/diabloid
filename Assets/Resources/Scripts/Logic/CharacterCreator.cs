using Resources.Scripts.Components;
using Resources.Scripts.Data;
using UnityEngine;

namespace Resources.Scripts.Logic
{
    public static class CharacterCreator
    {
        public static GameObject CreateCharacter(
                CharacterData characterData,
                ref MoveComponent moveComponent,
                ref ClassComponent classComponent,
                ref ParametersComponent parametersComponent,
                ref CharacterResourceComponent characterResourceComponent,
                Transform spawnPosition
                )
        {
            var spawnedCharacter = GameObject.Instantiate(characterData.CharacterPrefab, spawnPosition);
            var rigidbody = spawnedCharacter.AddComponent<Rigidbody>();
            rigidbody.freezeRotation = true;
            
            moveComponent.Transform = spawnedCharacter.transform;
            moveComponent.Rigidbody = rigidbody;
            moveComponent.MovementSpeed = characterData.MovementSpeed;
            SetClassAttributes(ref classComponent, characterData.ClassData);
            SetParameters(ref classComponent, ref parametersComponent);
            SetCharacterResource(ref characterResourceComponent, ref parametersComponent);
            return spawnedCharacter;
        }

        private static void SetClassAttributes(ref ClassComponent classComponent, ClassData classData)
        {
            classComponent.Name = classData.Name;
            classComponent.Strength = classData.Strength;
            classComponent.Constitution = classData.Constitution;
            classComponent.Wisdom = classData.Wisdom;
            classComponent.Agility = classData.Agility;
        }

        private static void SetCharacterResource(
            ref CharacterResourceComponent characterResourceComponent, 
            ref ParametersComponent parametersComponent)
        {
            characterResourceComponent.Health = parametersComponent.Health;
            characterResourceComponent.Stamina = parametersComponent.Stamina;
            characterResourceComponent.Mana = parametersComponent.Mana;
        }
        
        private static void SetParameters(ref ClassComponent classComponent, ref ParametersComponent parametersComponent)
        {
            parametersComponent.Health = classComponent.Constitution * 3 + classComponent.Strength;
            parametersComponent.Stamina = classComponent.Agility * 3;
            parametersComponent.Mana = classComponent.Wisdom * 2;
            parametersComponent.PhysicalDamage = classComponent.Strength + classComponent.Agility;
            parametersComponent.MagicalDamage = classComponent.Wisdom * 1.5f;
            parametersComponent.PhysicalArmor = classComponent.Agility;
            parametersComponent.MagicalArmor = classComponent.Wisdom + classComponent.Agility;
            parametersComponent.MovementSpeed = 2 + classComponent.Agility * 0.1f;
        }
    }
}