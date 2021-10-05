using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Specializations.Items.Melee
{
	public class ChlorophyteRapier : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Inflicts bleeding and poison on hit");
		}

		public override void SetDefaults()
		{
			item.damage = 72;          
			item.melee = true;         
			item.width = 60;           
			item.height = 60;         
			item.useTime = 12;          
			item.useAnimation = 12;         
			item.useStyle = 3;         
			item.knockBack = 4;        
			item.value = 184000;         
			item.rare = 4;              
			item.UseSound = SoundID.Item71;      
			item.autoReuse = true;   
		}
		
		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(mod.BuffType("RapierBleed"), 300);
			target.AddBuff(BuffID.Poisoned, 300);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ChlorophyteBar, 8);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
