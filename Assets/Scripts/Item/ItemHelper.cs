using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

namespace Items
{
    public static class ItemHelper
    {
        public static bool CanBeEquiped(EquipmentType type, EquipmentSlotType slotType)
        {
            switch (type)
            {
                case EquipmentType.Weapon:
                    return slotType == EquipmentSlotType.ItemRigth;
                case EquipmentType.Shield:
                    return slotType == EquipmentSlotType.ItemLeft;
                case EquipmentType.Chest:
                    return slotType == EquipmentSlotType.Chest;
                default:
                    Debug.Log("Not suported type");
                    return false;
            }
        }
    }

    /* [Serializable]
     public class Stat
     {
         public StatType StatType;
         public int Amount;
     }*/
    [Serializable]
    public class ItemStat : Stat
    {
        public IncreaserTime IncreaserTime;
    }

    public enum ItemId
    {
        Gold = 1,
        Scrap = 2,
        Shard = 3,
        Hp_Potion = 4,
        Mp_potion = 5,
        Emerald = 6,
        SoldierSword = 7,
        WarriorSword = 8,
        SoldierArmor = 9,



    }

    public enum IncreaserTime
    {
        Value,
        Persent,

    }

    public enum EquipmentType
    {
        Weapon,
        Shield,
        Helmet,
        Chest,
        Shoulders,
        Leggins,
        Boots,
        Belt,
        Ring,
        Medal,
        Amulet,
        Rune,
    }

    public enum RarityLvl
    {
        Common = 0,
        Uncommon = 1,
        Magical = 2,
        Rare = 3,
        Epic = 4,
        Legendary = 5,

    }

    public enum ComponentType
    {
        SmallComponent,
        MediumComponent,
        BigComponent,
    }



}
