using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Specializations.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class CobaltHood : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("20% increased throwing damage"
			+ "\n and 20% increased throwing velocity");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 75000;
			item.rare = 4;
			item.defense = 6;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ItemID.CobaltBreastplate && legs.type == ItemID.CobaltLeggings;
		}
		
		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "15% increased throwing critical strike chance";
			player.thrownCrit += 7;
			
		}
		
		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawShadow = true;
		}
		
		public override void UpdateEquip(Player player)
		{
			player.thrownDamage *= 1.2f;
			player.thrownVelocity *= 1.2f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CobaltBar, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}