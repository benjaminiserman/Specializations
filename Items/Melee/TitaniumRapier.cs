using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Specializations.Items.Melee
{
	public class TitaniumRapier : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Inflicts bleeding on hit, and gives the user ironskin");
		}

		public override void SetDefaults()
		{
			item.damage = 50;          
			item.melee = true;         
			item.width = 60;           
			item.height = 60;         
			item.useTime = 13;          
			item.useAnimation = 13;         
			item.useStyle = 3;         
			item.knockBack = 4;        
			item.value = 107333;         
			item.rare = 4;              
			item.UseSound = SoundID.Item1;      
			item.autoReuse = true;   
		}
		
		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{

			target.AddBuff(mod.BuffType("RapierBleed"), 300);
			player.AddBuff(BuffID.Ironskin, 180);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.TitaniumBar, 8);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

	}
}
