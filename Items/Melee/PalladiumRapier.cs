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

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
			velocity.X = 10 * player.direction;
			velocity.Y = 0;

			if (type == ProjectileID.Bullet) 
			{
				type = ProjectileID.BulletHighVelocity;
			}
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
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
			shoot = Main.rand.NextBool(3);		
			
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
