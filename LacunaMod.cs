using Terraria.ModLoader;

namespace LacunaMod
{
	class LacunaMod : Mod
	{
		public LacunaMod()
		{
			Properties = new ModProperties()
			{
				Autoload = true,
				AutoloadGores = true,
				AutoloadSounds = true
			};
		}
	}
}
