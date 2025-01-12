using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Specializations.Items.Melee
{
	public class AdamantiteRapier : ModItem
	{
		private bool shoot = true;
		
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("Fires lasers");
		}

		public override void SetDefaults()
		{
			Item.damage = 48;          
			Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;         
			Item.width = 44;           
			Item.height = 44;         
			Item.useTime = 19;          
			Item.useAnimation = 19;         
			Item.useStyle = 3;         
			Item.knockBack = 5;        
			Item.value = 92000;   
			Item.rare = 4;              
			Item.UseSound = SoundID.Item1;      
			Item.autoReuse = true;  
			Item.shoot = Mod.Find<ModProjectile>("RedLaser").Type;
			Item.shootSpeed = 0;
		}
		
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
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
				SoundEngine.PlaySound(SoundID.Item91);
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
			recipe.AddIngredient(ItemID.AdamantiteBar, 8);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}
