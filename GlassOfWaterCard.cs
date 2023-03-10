using KitchenData;
using KitchenLib.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Entities;
using UnityEngine;
using WaterMod.Registry;
using IngredientLib.Util;


namespace KitchenWaterMod
{
    class GlassOfWaterCard : ModDish
    {
        public override string UniqueNameID => "Glass Of Water Dish";
        public override DishType Type => DishType.Starter;
        public override GameObject DisplayPrefab => Mod.Bundle.LoadAsset<GameObject>("GlassOfWaterIcon");
        public override GameObject IconPrefab => DisplayPrefab;
        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.SmallDecrease;
        public override CardType CardType => CardType.Default;
        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Small;
        public override UnlockGroup UnlockGroup => UnlockGroup.Dish;
        public override bool IsAvailableAsLobbyOption => false;
        public override bool DestroyAfterModUninstall => true;

        public override List<Dish.MenuItem> ResultingMenuItems => new List<Dish.MenuItem>
        {
            new Dish.MenuItem
            {
                Item = Mod.GlassOfWater,
                Phase = MenuPhase.Starter,
                Weight = 1
            }
        };
        public override HashSet<Item> MinimumIngredients => new HashSet<Item>
        {
            Mod.Water,
            Mod.Glass,
            Mod.Ice,
            Mod.LemonSlices,
        };

        public override Dictionary<Locale, string> Recipe => new Dictionary<Locale, string>
        {
            { Locale.English, "Fill a glass with water, add Ice and a Slice and serve!" }
        };

        public override IDictionary<Locale, UnlockInfo> LocalisedInfo => new Dictionary<Locale, UnlockInfo>
        {
            { Locale.English, LocalisationUtils.CreateUnlockInfo("Glass Of Water", "Adds Glass Of Water as a starter", "Mmmm, Refreshing!") }
        };

        public override void OnRegister(GameDataObject gameDataObject)
        {
            DisplayPrefab.ApplyMaterialToChild("Glass", "Glass");


            DisplayPrefab.ApplyMaterialToChild("ChoppedLemon", "Lemon", "Lemon Inner", "White Fruit");
            DisplayPrefab.ApplyMaterialToChild("Water", "Paper - Postit Blue");


            GameObject ice = DisplayPrefab.GetChild("Ice");
            DisplayPrefab.ApplyMaterialToChild("Ice", "Water");
            ice.ApplyMaterialToChild("Ice1", "Water");
            ice.ApplyMaterialToChild("Ice2", "Water");
        }

    }
}
