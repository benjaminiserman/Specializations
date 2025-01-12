using Microsoft.Xna.Framework;
using Specializations.Projectiles;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Specializations.Items.Melee
{
    public class ChlorophyteRapier : ModItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("Inflicts bleeding and poison on hit");
		}

		public override void SetDefaults()
		{
			Item.damage = 65;          
			Item.DamageType = DamageClass.Melee;         
			Item.width = 63;           
			Item.height = 60;         
			Item.useTime = 16;          
			Item.useAnimation = 12;         
			Item.useStyle = ItemUseStyleID.Rapier;         
			Item.knockBack = 4;        
			Item.value = 184000;         
			Item.rare = 4;              
			Item.UseSound = SoundID.Item71;      
			Item.autoReuse = true;   
			Item.shoot = ModContent.ProjectileType<ChlorophyteRapierProjectile>();
			Item.shootSpeed = 4.0f;
			Item.noUseGraphic = true;
			Item.noMelee = true;
		}

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
			Projectile.NewProjectile(source, position, velocity.RotatedBy(-0.1) * 1.8f, ProjectileID.SporeCloud, damage / 4, knockback, player.whoAmI);
			Projectile.NewProjectile(source, position, velocity.RotatedBy(+0.1) * 1.8f, ProjectileID.SporeCloud, damage / 4, knockback, player.whoAmI);

			return true;
        }

        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
		{
			target.AddBuff(Mod.Find<ModBuff>("RapierBleed").Type, 300);
			target.AddBuff(BuffID.Poisoned, 300);
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.ChlorophyteBar, 8);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}
