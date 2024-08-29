﻿namespace UI_UX_Targeting_api.DataModel
{
    public class JwtSettings
    {
        public string Secret { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int ExpireHours { get; set; }
    }
}
