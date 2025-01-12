using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Specializations.Items.Melee
{
	public class OrichalcumRapier : ModItem
	{
		bool shoot = false;
		
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("Randomly fires a petal that can go through walls");
		}

		public override void SetDefaults()
		{
			Item.damage = 43;          
			Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;         
			Item.width = 44;           
			Item.height = 44;         
			Item.useTime = 20;          
			Item.useAnimation = 20;         
			Item.useStyle = 3;         
			Item.knockBack = 5;        
			Item.value = 84333;
			Item.rare = 4;              
			Item.UseSound = SoundID.Item1;      
			Item.autoReuse = true;  
			Item.shoot = ProjectileID.FlowerPetal;
			Item.shootSpeed = 0;
		}
		
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
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
				SoundEngine.PlaySound(SoundID.Item71);
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
			recipe.AddIngredient(ItemID.OrichalcumBar, 8);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}
