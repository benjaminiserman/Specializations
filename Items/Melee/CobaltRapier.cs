using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Specializations.Items.Melee
{
	public class CobaltRapier : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Inflicts bleeding on hit, and gives the wielder swiftness");
		}

		public override void SetDefaults()
		{
			item.damage = 36;          
			item.melee = true;         
			item.width = 44;           
			item.height = 44;         
			item.useTime = 13;          
			item.useAnimation = 13;         
			item.useStyle = 3;         
			item.knockBack = 4;        
			item.value = 55200;         
			item.rare = 4;              
			item.UseSound = SoundID.Item1;      
			item.autoReuse = true;   
		}
		
		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{

			target.AddBuff(mod.BuffType("RapierBleed"), 300);
            player.AddBuff(BuffID.Swiftness, 300);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CobaltBar, 8);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
