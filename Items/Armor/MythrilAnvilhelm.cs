using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Specializations.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class MythrilAnvilhelm : ModItem
	{
		public override void SetStaticDefaults()
		{
			/* Tooltip.SetDefault("30% increased throwing velocity"
			+ "\n and 10% increased throwing critical strike chance"); */
		}

		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 18;
			Item.value = 112500;
			Item.rare = 4;
			Item.defense = 9;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ItemID.MythrilChainmail && legs.type == ItemID.MythrilGreaves;
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "20% increased throwing velocity";
			player.ThrownVelocity *= 1.2f;
			
		}
		
		public override void UpdateEquip(Player player)
		{
			player.ThrownVelocity *= 1.3f;
			player.GetCritChance(DamageClass.Throwing) += 10;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.MythrilBar, 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}