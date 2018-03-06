/*using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Specializations.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class ChlorophyteCrown : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("15% increased throwing critical strike chance"
			+ "\n and 16% increased throwing damage");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 300000;
			item.rare = 7;
			item.defense = 16;
        }

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ItemID.ChlorophytePlateMail && legs.type == ItemID.ChlorophyteGreaves;
		}
        
		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Summons a powerful leaf crystal to shoot at nearby enemies.";
            player.crystalLeaf = true;
            player.AddBuff(BuffID.LeafCrystal, 0);
            Projectile.NewProjectile(new Microsoft.Xna.Framework.Vector2(0, -5), new Microsoft.Xna.Framework.Vector2(0, 0), ProjectileID.CrystalLeaf, 0, 0, item.owner, 0, 0);
			
		}
		
		public override void UpdateEquip(Player player)
		{
			player.thrownCrit += 15;
			player.thrownDamage *= 1.15f;
		}

        public override void ArmorSetShadows(Player player)
        {
            player.armorEffectDrawShadowSubtle = true;
        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ChlorophyteBar, 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
*/