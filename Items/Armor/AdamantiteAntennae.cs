using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Specializations.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class AdamantiteAntennae : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("25% increased throwing damage"
			+ "\n and 10% increased throwing critical strike chance");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 150000;
			item.rare = 4;
			item.defense = 12;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ItemID.AdamantiteBreastplate && legs.type == ItemID.AdamantiteLeggings;
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "10% increased throwing velocity"
			+ "\n and 15% increased movement speed";
			player.thrownVelocity *= 1.1f;
			player.moveSpeed *= 1.15f;
			
		}
		
		public override void ArmorSetShadows(Player player)
		{
            player.armorEffectDrawOutlines = true;
		}
		
		public override void UpdateEquip(Player player)
		{
			player.thrownCrit += 10;
			player.thrownDamage *= 1.25f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.AdamantiteBar, 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}