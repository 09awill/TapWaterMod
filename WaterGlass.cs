using IngredientLib.Util;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace KitchenWaterMod
{
    internal class WaterGlass : CustomItem
    {
        public override string UniqueNameID => "Water Glass";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("WaterGlass");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemValue ItemValue => ItemValue.Medium;
        public override Appliance DedicatedProvider => Mod.GlassProvider;


        public override void OnRegister(GameDataObject gameDataObject)
        {
            Prefab.ApplyMaterialToChild("Glass", "Glass");
        }
    }
}
