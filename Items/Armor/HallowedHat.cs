using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Specializations.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class HallowedHat : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("28% increased throwing damage"
			+ "\n and 11% increased throwing critical strike chance");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 250000;
			item.rare = 5;
			item.defense = 12;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ItemID.HallowedPlateMail && legs.type == ItemID.HallowedGreaves;
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "20% increased throwing velocity"
			+ "\n and 20% increased movement speed";
			player.thrownVelocity *= 1.2f;
			player.moveSpeed *= 1.2f;
			
		}
		
		public override void ArmorSetShadows(Player player)
		{
            player.armorEffectDrawOutlines = true;
            player.armorEffectDrawShadow = true;
		}
		
		public override void UpdateEquip(Player player)
		{
			player.thrownCrit += 11;
			player.thrownDamage *= 1.28f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HallowedBar, 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}