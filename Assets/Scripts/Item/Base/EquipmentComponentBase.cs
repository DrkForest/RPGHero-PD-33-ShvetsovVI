using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Items
{
    [CreateAssetMenu(fileName = "EquipmentComponent", menuName = "Item/EquipmentComponents")]
    public class EquipmentComponentBase : StatItemBase
    {
        [SerializeField] private EquipmentType[] _allowedEquipmentTypes;
        [SerializeField] private ComponentType _componentType;

        public EquipmentType[] AllowedEquipmentTypes => _allowedEquipmentTypes;
        public ComponentType ComponentType => _componentType;
    }
}
