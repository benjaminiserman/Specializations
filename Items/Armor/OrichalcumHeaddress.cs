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
			/* Tooltip.SetDefault("15% increased throwing critical strike chance"
			+ "\n and 8% increased movement speed"); */
		}

		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 18;
			Item.value = 112500;
			Item.rare = 4;
			Item.defense = 10;
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
			player.GetCritChance(DamageClass.Throwing) += 15;
			player.moveSpeed *= 1.08f;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.OrichalcumBar, 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}