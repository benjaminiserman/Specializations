using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Specializations.Items.Melee
{
	public class PalladiumRapier : ModItem
	{
		private bool shoot = false;
		
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("Randomly fires bullets");
		}

		public override void SetDefaults()
		{
			Item.damage = 39;          
			Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;         
			Item.width = 44;           
			Item.height = 44;         
			Item.useTime = 16;          
			Item.useAnimation = 16;         
			Item.useStyle = 3;         
			Item.knockBack = 5;        
			Item.value = 61333;   
			Item.rare = 4;              
			Item.UseSound = SoundID.Item1;      
			Item.autoReuse = true;  
			Item.shoot = 10;
			Item.shootSpeed = 0;
			Item.useAmmo = AmmoID.Bullet;
		}
		
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
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
				SoundEngine.PlaySound(SoundID.Item36);
				return true;
			}
			else
			{
				return false;
			}
		}
		
		public override bool CanConsumeAmmo(Item ammo, Player player)
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
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.PalladiumBar, 8);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}
