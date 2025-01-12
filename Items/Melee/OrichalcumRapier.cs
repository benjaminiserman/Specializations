using Microsoft.Xna.Framework;
using Specializations.Projectiles;
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
		
		public override void SetDefaults()
		{
			Item.damage = 43;          
			Item.DamageType = DamageClass.Melee;         
			Item.width = 44;           
			Item.height = 44;         
			Item.useTime = 20;          
			Item.useAnimation = 20;         
			Item.useStyle = ItemUseStyleID.Rapier;         
			Item.knockBack = 5;        
			Item.value = 84333;
			Item.rare = 4;              
			Item.UseSound = SoundID.Item1;      
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<OrichalcumRapierProjectile>();
			Item.shootSpeed = 2.1f;
			Item.noUseGraphic = true;
			Item.noMelee = true;
		}

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			shoot = !shoot;
			
			if (shoot)
			{
				Projectile.NewProjectile(source, position, velocity * 2, ProjectileID.FlowerPetal, damage, knockback, player.whoAmI);
				SoundEngine.PlaySound(SoundID.Item71);
				return true;			
			}

			return true;
		}

		public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
		{
			target.AddBuff(Mod.Find<ModBuff>("RapierBleed").Type, 300);
            player.AddBuff(BuffID.Swiftness, 300);
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
