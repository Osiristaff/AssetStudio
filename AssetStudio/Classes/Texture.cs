﻿namespace AssetStudio
{
    public abstract class Texture : NamedObject
    {
        protected Texture() { }

        protected Texture(ObjectReader reader) : base(reader)
        {
            if (version[0] > 2017 || (version[0] == 2017 && version[1] >= 3)) //2017.3 and up
            {
                if (version[0] < 2023 || (version[0] == 2023 && version[1] < 2)) //2023.2 down
                {
                    var m_ForcedFallbackFormat = reader.ReadInt32();
                    var m_DownscaleFallback = reader.ReadBoolean();
                }

                if (version[0] > 2020 || (version[0] == 2020 && version[1] >= 2)) //2020.2 and up
                {
                    var m_IsAlphaChannelOptional = reader.ReadBoolean();
                }
                reader.AlignStream();
            }
        }
    }
}
