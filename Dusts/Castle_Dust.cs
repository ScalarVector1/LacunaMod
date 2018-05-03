using Terraria;
using Terraria.ModLoader;

namespace LacunaMod.Dusts
{
	public class Castle_Dust : ModDust
	{
		public override void OnSpawn(Dust dust)
		{
			dust.velocity *= 0.2f;
			dust.noGravity = true;
			dust.noLight = true;
			dust.scale *= 1.1f;
		}

		public override bool Update(Dust dust)
		{
			dust.position += dust.velocity;
			dust.rotation += dust.velocity.X * 0.65f;
			dust.scale *= 0.98f;
			float light = 0.02f * dust.scale;
			Lighting.AddLight(dust.position, 0.15f, 0.15f, 0.1f);
			if (dust.scale < 0.2f)
			{
				dust.active = false;
			}
			return false;
		}
	}
}