using Microsoft.Xna.Framework;
using Specializations.Projectiles;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Specializations.Items.Melee
{
	public class PalladiumRapier : ModItem
	{
		private int shoot = 0;

		public override void SetDefaults()
		{
			Item.damage = 39;          
			Item.DamageType = DamageClass.Melee;         
			Item.width = 44;           
			Item.height = 44;         
			Item.useTime = 16;          
			Item.useAnimation = 16;         
			Item.useStyle = ItemUseStyleID.Rapier;         
			Item.knockBack = 5;        
			Item.value = 61333;   
			Item.rare = 4;              
			Item.UseSound = SoundID.Item1;      
			Item.autoReuse = true;  
			Item.useAmmo = AmmoID.Bullet;
			Item.shoot = ModContent.ProjectileType<PalladiumRapierProjectile>();
			Item.shootSpeed = 2.1f;
			Item.noUseGraphic = true;
			Item.noMelee = true;
		}

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
			if (type == ProjectileID.Bullet) 
			{
				type = ProjectileID.BulletHighVelocity;
			}
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			if (shoot == 0 && source.AmmoItemIdUsed != 0 && player.ChooseAmmo(Item) != null)
			{
				SoundEngine.PlaySound(SoundID.Item36);
				var bulletProjectile = type == ProjectileID.Bullet ? ProjectileID.BulletHighVelocity : type;
				Projectile.NewProjectile(source, position, velocity * 2, bulletProjectile, damage, knockback, player.whoAmI);
			}
			
			Projectile.NewProjectile(source, position, velocity.SafeNormalize(default) * Item.shootSpeed, ModContent.ProjectileType<PalladiumRapierProjectile>(), damage, knockback, player.whoAmI);

			return false;
		}

        public override bool NeedsAmmo(Player player)
        {
            return false;
        }

        public override bool CanConsumeAmmo(Item ammo, Player player)
		{			
			shoot += 1;
			if (shoot > 2)
			{
				shoot = 0;
			}		
			
			if (shoot == 0)
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
