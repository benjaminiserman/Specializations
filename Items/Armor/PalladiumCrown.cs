using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Specializations.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class PalladiumCrown : ModItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("35% increased throwing damage");
		}

		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 18;
			Item.value = 75000;
			Item.rare = 4;
			Item.defense = 7;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ItemID.PalladiumBreastplate && legs.type == ItemID.PalladiumLeggings;
		}
		
		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Greatly increases life regeneration after striking an enemy";
			player.onHitRegen = true;
			
		}
		
		public override void UpdateEquip(Player player)
		{
			player.GetDamage(DamageClass.Throwing) *= 1.35f;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.PalladiumBar, 12);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}