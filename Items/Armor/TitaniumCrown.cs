using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Specializations.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class TitaniumCrown : ModItem
	{
		public override void SetStaticDefaults()
		{
			/* Tooltip.SetDefault("15% increased throwing damage"
                + "\n 10% increased throwing critical strike chance"); */
		}

		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 18;
			Item.value = 150000;
			Item.rare = 4;
			Item.defense = 11;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ItemID.TitaniumBreastplate && legs.type == ItemID.TitaniumLeggings;
		}
		
		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Briefly become invulnerable after striking an enemy";
			player.onHitDodge = true;
			
		}
		
		public override void UpdateEquip(Player player)
		{
			player.GetDamage(DamageClass.Throwing) *= 1.15f;
            player.GetCritChance(DamageClass.Throwing) += 10;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.TitaniumBar, 13);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}