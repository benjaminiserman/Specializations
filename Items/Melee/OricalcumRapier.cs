using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Specializations.Items.Melee
{
	public class OrichalcumRapier : ModItem
	{
		bool shoot = false;
		
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Randomly fires a petal that can go through walls");
		}

		public override void SetDefaults()
		{
			item.damage = 43;          
			item.melee = true;         
			item.width = 44;           
			item.height = 44;         
			item.useTime = 20;          
			item.useAnimation = 20;         
			item.useStyle = 3;         
			item.knockBack = 5;        
			item.value = 84333;
			item.rare = 4;              
			item.UseSound = SoundID.Item1;      
			item.autoReuse = true;  
			item.shoot = ProjectileID.FlowerPetal;
			item.shootSpeed = 0;
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			shoot = (Main.rand.Next(2) == 0);
		
			speedX = 10 * player.direction;
			speedY = 0;
			
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY+1)) * 25f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
			
			if (shoot)
			{
				Main.PlaySound(SoundID.Item71);
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
			recipe.AddIngredient(ItemID.OrichalcumBar, 8);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
