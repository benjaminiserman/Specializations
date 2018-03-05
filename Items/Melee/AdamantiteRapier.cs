using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Specializations.Items.Melee
{
	public class AdamantiteRapier : ModItem
	{
		
		private bool shoot = true;
		
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Fires lasers");
		}

		public override void SetDefaults()
		{
			item.damage = 48;          
			item.melee = true;         
			item.width = 44;           
			item.height = 44;         
			item.useTime = 19;          
			item.useAnimation = 19;         
			item.useStyle = 3;         
			item.knockBack = 5;        
			item.value = 92000;   
			item.rare = 4;              
			item.UseSound = SoundID.Item1;      
			item.autoReuse = true;  
			item.shoot = mod.ProjectileType("RedLaser");
			item.shootSpeed = 0;

		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{	
			
			speedX = 10 * player.direction;
			speedY = 0;
			
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY+1)) * 25f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
			
			if (shoot)
			{
				Main.PlaySound(SoundID.Item91);
				return true;
			}
			else
			{
				return false;
			}
		}
	
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.AdamantiteBar, 8);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

	}
}
