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
			/* Tooltip.SetDefault("20% increased throwing damage"
			+ "\n and 20% increased throwing velocity"); */
		}

		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 18;
			Item.value = 75000;
			Item.rare = 4;
			Item.defense = 6;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ItemID.CobaltBreastplate && legs.type == ItemID.CobaltLeggings;
		}
		
		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "15% increased throwing critical strike chance";
			player.GetCritChance(DamageClass.Throwing) += 7;
		}
		
		public override void ArmorSetShadows(Player player)
		{
			player.armorEffectDrawShadow = true;
		}
		
		public override void UpdateEquip(Player player)
		{
			player.GetDamage(DamageClass.Throwing) *= 1.2f;
			player.ThrownVelocity *= 1.2f;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.CobaltBar, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}