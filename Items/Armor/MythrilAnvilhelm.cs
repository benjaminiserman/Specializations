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
			Tooltip.SetDefault("30% increased throwing velocity"
			+ "\n and 10% increased throwing critical strike chance");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 112500;
			item.rare = 4;
			item.defense = 9;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ItemID.MythrilChainmail && legs.type == ItemID.MythrilGreaves;
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "20% increased throwing velocity";
			player.thrownVelocity *= 1.2f;
			
		}
		
		public override void UpdateEquip(Player player)
		{
			player.thrownVelocity *= 1.3f;
			player.thrownCrit += 10;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MythrilBar, 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}