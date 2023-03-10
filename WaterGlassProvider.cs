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
    internal class WaterGlassProvider : CustomAppliance
    {
        public override string UniqueNameID => "Water Glass Provder";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("WaterGlassProvider");
        public override PriceTier PriceTier => PriceTier.Medium;
        public override bool SellOnlyAsDuplicate => true;
        public override bool IsPurchasable => true;
        public override ShoppingTags ShoppingTags => ShoppingTags.Cooking | ShoppingTags.Misc;
        public override List<(Locale, ApplianceInfo)> InfoList => new()
        {
            ( Locale.English, LocalisationUtils.CreateApplianceInfo("Water Glass", "Provides Glasses for water", new(), new()) )
        };

        public override List<IApplianceProperty> Properties => new List<IApplianceProperty>()
        {
            KitchenPropertiesUtils.GetUnlimitedCItemProvider(Mod.Glass.ID)
        };
        public override void OnRegister(GameDataObject gameDataObject)
        {
            GameObject stack = Prefab.GetChild("Stack");
            stack.GetChild("WaterGlass").ApplyMaterialToChild("Glass", "Glass");
            stack.GetChild("WaterGlass (1)").ApplyMaterialToChild("Glass", "Glass");
            stack.GetChild("WaterGlass (2)").ApplyMaterialToChild("Glass", "Glass");
            stack.GetChild("WaterGlass (3)").ApplyMaterialToChild("Glass", "Glass");


            Material[] mats = new Material[] { MaterialUtils.GetExistingMaterial("Wood 4 - Painted") };

            Prefab.GetChildFromPath("Tray Counter/Counter2/Counter").ApplyMaterial(mats);
            Prefab.GetChildFromPath("Tray Counter/Counter2/Counter Doors").ApplyMaterial(mats);


            mats = new Material[] { MaterialUtils.GetExistingMaterial("Wood - Default") };
            Prefab.GetChildFromPath("Tray Counter/Counter2/Counter Surface").ApplyMaterial(mats);
            Prefab.GetChildFromPath("Tray Counter/Counter2/Counter Top").ApplyMaterial(mats);


            mats = new Material[] { MaterialUtils.GetExistingMaterial("Knob") };
            Prefab.GetChildFromPath("Tray Counter/Counter2/Handles").ApplyMaterial(mats);

        }
    }
}
