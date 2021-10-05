using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Specializations.Items.Melee
{
	public class PalladiumRapier : ModItem
	{
		private bool shoot = false;
		
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Randomly fires bullets");
		}

		public override void SetDefaults()
		{
			item.damage = 39;          
			item.melee = true;         
			item.width = 44;           
			item.height = 44;         
			item.useTime = 16;          
			item.useAnimation = 16;         
			item.useStyle = 3;         
			item.knockBack = 5;        
			item.value = 61333;   
			item.rare = 4;              
			item.UseSound = SoundID.Item1;      
			item.autoReuse = true;  
			item.shoot = 10;
			item.shootSpeed = 0;
			item.useAmmo = AmmoID.Bullet;
		}
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (type == ProjectileID.Bullet) 
			{
				type = ProjectileID.BulletHighVelocity;
			}
			
			speedX = 10 * player.direction;
			speedY = 0;
			
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY+1)) * 25f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
			
			if (shoot)
			{
				Main.PlaySound(SoundID.Item36);
				return true;
			}
			else
			{
				return false;
			}
		}
		
		public override bool ConsumeAmmo(Player player)
		{			
			shoot = (Main.rand.Next(3) == 0);		
			
			if (shoot)
			{
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
			recipe.AddIngredient(ItemID.PalladiumBar, 8);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
