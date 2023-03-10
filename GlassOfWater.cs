using Kitchen;
using KitchenData;
using KitchenLib.Colorblind;
using KitchenLib.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static KitchenData.ItemGroup;
using UnityEngine;
using KitchenLib.Customs;
using static KitchenWaterMod.GlassOfWater;
using IngredientLib.Util;

namespace KitchenWaterMod
{
    internal class GlassOfWater : CustomItemGroup<GlassOfWaterItemGroupView>
    {
        public override string UniqueNameID => "Glass Of Water";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("GlassOfWater");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemValue ItemValue => ItemValue.Small;
        public override bool AutoCollapsing => false;

        public override List<ItemSet> Sets => new List<ItemSet>()
        {
            new ItemSet()
            {
                Max = 2,
                Min = 2,
                IsMandatory = true,
                Items = new List<Item>()
                {
                    Mod.Glass,
                    Mod.Water
                }
            },
            new ItemSet()
            {
                Max = 2,
                Min = 2,
                OrderingOnly = false,
                Items = new List<Item>()
                {
                    Mod.Ice,
                    Mod.LemonSlices
                }
            }
        };

        //Well-done  Burger for spots on burrito
        //Bread - Inside Cooked for Main Burrito
        public override void OnRegister(GameDataObject gameDataObject)
        {
            Prefab.GetComponent<GlassOfWaterItemGroupView>()?.Setup(Prefab);

            //TO DO : Change to chicken

            Prefab.ApplyMaterialToChild("Glass", "Glass");


            Prefab.ApplyMaterialToChild("ChoppedLemon", "Lemon", "Lemon Inner", "White Fruit");
            Prefab.ApplyMaterialToChild("Water", "Paper - Postit Blue");


            GameObject ice = Prefab.GetChild("Ice");
            Prefab.ApplyMaterialToChild("Ice", "Water");
            ice.ApplyMaterialToChild("Ice1", "Water");
            ice.ApplyMaterialToChild("Ice2", "Water");



            if (Prefab.TryGetComponent<ItemGroupView>(out var itemGroupView))
            {
                GameObject clonedColourBlind = ColorblindUtils.cloneColourBlindObjectAndAddToItem(GameDataObject as ItemGroup);
                ColorblindUtils.setColourBlindLabelObjectOnItemGroupView(itemGroupView, clonedColourBlind);
            }
        }
        public class GlassOfWaterItemGroupView : ItemGroupView
        {
            internal void Setup(GameObject prefab)
            {
                // This tells which sub-object of the prefab corresponds to each component of the ItemGroup
                // All of these sub-objects are hidden unless the item is present

                ComponentGroups = new()
            {
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Glass"),
                    Item = Mod.Glass
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "ChoppedLemon"),
                    Item = Mod.LemonSlices
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Water"),
                    Item = Mod.Water
                },
                new()
                {
                    GameObject = GameObjectUtils.GetChildObject(prefab, "Ice"),
                    Item = Mod.Ice
                }
            };
                ComponentLabels = new()
            {
                new()
                {
                    Text = "Gl",
                    Item = Mod.Glass
                },
                new()
                {
                    Text = "W",
                    Item = Mod.Water
                },
                new()
                {
                    Text = "I",
                    Item = Mod.Ice
                },
                new()
                {
                    Text = "L",
                    Item = Mod.LemonSlices
                }
            };
            }
        }
    }
}
