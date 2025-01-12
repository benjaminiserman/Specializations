using Microsoft.Xna.Framework;
using Specializations.Projectiles;
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
			Item.DamageType = DamageClass.Melee;         
			Item.width = 44;           
			Item.height = 44;         
			Item.useTime = 19;          
			Item.useAnimation = 19;         
			Item.useStyle = ItemUseStyleID.Rapier;         
			Item.knockBack = 5;        
			Item.value = 92000;   
			Item.rare = 4;              
			Item.UseSound = SoundID.Item1;      
			Item.autoReuse = true;  
			Item.shoot = ModContent.ProjectileType<RedLaser>();
			Item.shootSpeed = 0;
		}

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            velocity.X = 10 * player.direction;
			velocity.Y = 0;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
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
