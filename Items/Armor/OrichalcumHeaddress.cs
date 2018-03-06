using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Specializations.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class OrichalcumHeaddress : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("15% increased throwing critical strike chance"
			+ "\n and 8% increased movement speed");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 112500;
			item.rare = 4;
			item.defense = 10;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ItemID.OrichalcumBreastplate && legs.type == ItemID.OrichalcumLeggings;
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Flower petals will fall on your target for extra damage";
			player.onHitPetal = true;
			
		}
		
		public override void UpdateEquip(Player player)
		{
			player.thrownCrit += 15;
			player.moveSpeed *= 1.08f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.OrichalcumBar, 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}